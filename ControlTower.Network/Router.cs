using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.NetworkInformation;
using System.Net;
using SharpPcap;
using SharpPcap.LibPcap;
using PacketDotNet;
using System.Diagnostics;
using ControlTower.Network.Data;
using ControlTower.Network;

namespace ControlTower
{
    public class Router
    {
        private Router()
        {
            IsRunning = false;
        }
        public LibPcapLiveDevice Device { get; set; }

        public bool IsRunning
        {
            get;
            set;
        }

        public void Start()
        {
            if (IsRunning)
                return;

            device = LibPcapLiveDeviceList.New()[Device.Name];
            
            device.Open(DeviceModes.Promiscuous, 50);

            device.Filter = "(ether dst " + device.MacAddress + ") and ip and " +
                             "(not dst " + NetUtils.GeIPv4Address(device) + ")";

            device.OnPacketArrival += OnPacketArrival;
            device.StartCapture();
            IsRunning = true;
        }

        public void Stop()
        {
            if (!IsRunning)
                return;

            device.OnPacketArrival -= OnPacketArrival;
            device.StopCapture();

            IsRunning = false;
        }

        public PhysicalAddress ResolveMacAdress(IPAddress ip)
        {
            IPAddress gateway = device.Interface.GatewayAddresses.Single();
            IPAddress ipToResolve;

            if (NetUtils.IsIpAddressOfNetwork(device, ip))
                ipToResolve = ip;
            else
                ipToResolve = gateway;

            foreach (Host hote in NetUtils.GetLocalArpTable())
            {
                if (hote.IpAddress.Equals(ipToResolve))
                    return hote.MacAddress;
            }

            PhysicalAddress physicalAddress = arp.Resolve(ipToResolve);
            if (physicalAddress == null)
                Debug.WriteLine("ERROR");

            return physicalAddress;
        }

        public delegate void ReceivedPacketHandle(ref IPv4Packet packet);
        public event ReceivedPacketHandle ReceivedPacked;

        private void OnPacketArrival(object sender, PacketCapture e)
        {
            var rowPacket = e.GetPacket();
            Packet packet = Packet.ParsePacket(rowPacket.LinkLayerType, rowPacket.Data);

            if (!(packet is EthernetPacket eth_packet))
                return;

            IPv4Packet ip_packet = packet.Extract<IPv4Packet>();

            if (ip_packet == null)
                return;

            ip_packet.ParentPacket = eth_packet;

            ReceivedPacked?.Invoke(ref ip_packet);

            if (!Route(ref ip_packet))
                eth_packet.DestinationHardwareAddress = ResolveMacAdress(ip_packet.DestinationAddress);

            eth_packet.SourceHardwareAddress = device.MacAddress;

            // Compute checksums
            eth_packet.UpdateCalculatedValues();

            device.SendPacket(eth_packet);
        }

        private bool Route(ref IPv4Packet packet)
        {
            bool done = false;

            EthernetPacket eth_packet = packet.ParentPacket as EthernetPacket;

            foreach (Route route in Routes)
            {
                if (eth_packet.SourceHardwareAddress.Equals(route.Source.MacAddress) &&
                    (route.SourceIp == null || route.SourceIp.Equals(packet.SourceAddress)) &&
                    (route.DestIp == null || route.DestIp.Equals(packet.DestinationAddress)))
                {
                    if (route.NewSourceIp != null)
                    {
                        packet.SourceAddress = route.NewSourceIp.IpAddress;
                        eth_packet.SourceHardwareAddress = route.NewSourceIp.MacAddress;

                        done = true;
                    }

                    if (route.NewDestIp != null)
                    {
                        packet.DestinationAddress = route.NewDestIp.IpAddress;
                        eth_packet.DestinationHardwareAddress = route.NewDestIp.MacAddress;

                        done = true;
                    }
                }
            }

            return done;
        }

        public static Router Instance
        {
            get {
                if (_instance == null)
                    _instance = new Router();

                return _instance;
            }
        }

        private static Router _instance;

        public List<Route> Routes { get; } = new List<Route>();

        private readonly ARP arp;
        private LibPcapLiveDevice device;
    }
}
