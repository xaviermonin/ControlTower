using ControlTower.Network.Common;
using ControlTower.Network.Data;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace ControlTower.Network
{
    public class ArpCommunicator
    {
        public ArpCommunicator()
        {
            
        }

        public delegate void ReceivedPacketHandle(Host host, byte[] payload);
        public event ReceivedPacketHandle ReceivedPacket;

        private LibPcapLiveDevice _device;
        private const byte HwPrefix = 0x5B;

        public LibPcapLiveDevice Device
        {
            get;
            set;
        }

        public void StartListen()
        {
            if (_device != null)
                throw new InvalidOperationException("ArpCommunicator allready listen");

            _device = LibPcapLiveDeviceList.New()[Device.Name];

            _device.Open(DeviceModes.Promiscuous);
            _device.Filter = $"arp and (ether dst {_device.MacAddress})"; // and arp.opcode eq 1 and !(arp.dst.hw_mac eq 00:00:00:00:00:00)";

            _device.OnPacketArrival += Device_OnPacketArrival;
            _device.StartCapture();
        }

        public void StopListen()
        {
            if (_device == null)
                throw new InvalidOperationException("ArpCommunicator doesn't listen");

            _device.Close();
            _device.Dispose();
            _device = null;
        }

        public void Send(Host target, byte[] payload)
        {
            var device = LibPcapLiveDeviceList.New()[Device.Name];
            var currentIpAddrInfo = NetUtils.GetIPAddressInfo(device);

            device.Open(DeviceModes.Promiscuous, 50);

            try
            {
                for (int taken = 0; taken < payload.Length; taken += 5)
                {
                    var currentPayload = payload.Skip(taken).Take(5).ToList();
                    currentPayload.Insert(0, HwPrefix);

                    while (currentPayload.Count < 6)
                        currentPayload.Add(0); // Fill with 0

                    Packet arpPacket = CreateArpPacket(
                        currentIpAddrInfo.IPAddress, device.MacAddress,
                        target.IpAddress, target.MacAddress,
                        currentPayload.ToArray());

                    device.SendPacket(arpPacket);
                }
            }
            finally
            {
                device.Close();
            }
        }

        private void Device_OnPacketArrival(object sender, PacketCapture e)
        {
            var packet = Packet.ParsePacket(LinkLayers.Ethernet, e.Data.ToArray());
            var ethPacket = packet.Extract<EthernetPacket>();
            var arpPacket = ethPacket.PayloadPacket as ArpPacket;

            if (ethPacket.DestinationHardwareAddress.Equals(Device.MacAddress) &&
                arpPacket.Operation == ArpOperation.Request &&
                arpPacket.TargetHardwareAddress.GetAddressBytes()[0] == HwPrefix
                /*// 000000000000 Hw exclude => legitime
                !arpPacket.TargetHardwareAddress.Equals(PhysicalAddress.None) &&
                // Sender want to confirm no change
                !arpPacket.TargetHardwareAddress.Equals(_device.MacAddress)*/)
            {
                byte[] payload = arpPacket.TargetHardwareAddress.GetAddressBytes().Skip(1).ToArray();
                ReceivedPacket?.Invoke(new Host()
                {
                    IpAddress = arpPacket.SenderProtocolAddress,
                    MacAddress = ethPacket.SourceHardwareAddress
                }, payload);
            }
        }

        private Packet CreateArpPacket(IPAddress senderIpAddress, PhysicalAddress senderPhysicalAddress,
                                       IPAddress targetIpAddress, PhysicalAddress targetPhysicalAddress,
                                       byte[] payload)
        {
            if (payload.Length != 6)
                throw new ArgumentException("Incorrect payload size: must be 6", nameof(payload));

            var ipAddressPayLoad = new PhysicalAddress(payload);

            var arpPacket = new ArpPacket(ArpOperation.Request, ipAddressPayLoad, targetIpAddress, senderPhysicalAddress, senderIpAddress);

            return new EthernetPacket(Device.MacAddress, targetPhysicalAddress, EthernetType.Arp) { PayloadPacket = arpPacket };
        }
    }
}
