﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpPcap;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using SharpPcap.LibPcap;
using ControlTower.Data;
using ControlTower.Network.Data;
using ControlTower.Network;

namespace ControlTower.Network
{
    public class NetUtils
    {
        public static IEnumerable<LibPcapLiveDevice> GetLibPcapLiveEthernetDevices()
        {
            return LibPcapLiveDeviceList.Instance.Where(device => !device.Loopback && device.Addresses.Count() > 0 &&
                                                        device.Addresses.Any(a => a.Addr.type == Sockaddr.AddressTypes.AF_INET_AF_INET6));
        }

        public static List<Host> GetLocalArpTable()
        {
            List<Host> liste = new List<Host>();

            // The number of bytes needed.
            int bytesNeeded = 0;

            // The result from the API call.
            int result = IpHlpApiWrapper.GetIpNetTable(IntPtr.Zero, ref bytesNeeded, true);

            // Call the function, expecting an insufficient buffer.
            if (result != IpHlpApiWrapper.ERROR_INSUFFICIENT_BUFFER)
            {
                // Throw an exception.
                throw new Exception(result.ToString());
            }

            // Allocate the memory, do it in a try/finally block, to ensure
            // that it is released.
            IntPtr buffer = IntPtr.Zero;

            // Try/finally.
            try
            {
                // Allocate the memory.
                buffer = Marshal.AllocCoTaskMem(bytesNeeded);

                // Make the call again. If it did not succeed, then
                // raise an error.
                result = IpHlpApiWrapper.GetIpNetTable(buffer, ref bytesNeeded, false);

                // If the result is not 0 (no error), then throw an exception.
                if (result != 0)
                {
                    // Throw an exception.
                    throw new Exception(result.ToString());
                }

                // Now we have the buffer, we have to marshal it. We can read
                // the first 4 bytes to get the length of the buffer.
                int entries = Marshal.ReadInt32(buffer);

                // Increment the memory pointer by the size of the int.
                IntPtr currentBuffer = new IntPtr(buffer.ToInt64() +
                   Marshal.SizeOf(typeof(int)));

                // Allocate an array of entries.
                IpHlpApiWrapper.MIB_IPNETROW[] table = new IpHlpApiWrapper.MIB_IPNETROW[entries];

                // Cycle through the entries.
                for (int index = 0; index < entries; index++)
                {
                    // Call PtrToStructure, getting the structure information.
                    table[index] = (IpHlpApiWrapper.MIB_IPNETROW)Marshal.PtrToStructure(new
                       IntPtr(currentBuffer.ToInt64() + (index *
                       Marshal.SizeOf(typeof(IpHlpApiWrapper.MIB_IPNETROW)))), typeof(IpHlpApiWrapper.MIB_IPNETROW));
                }

                for (int index = 0; index < entries; index++)
                {
                    uint adr = (uint)table[index].dwAddr;
                    IPAddress ip = new IPAddress(adr);

                    byte[] byte_mac = { table[index].mac0, table[index].mac1,
                                           table[index].mac2, table[index].mac3,
                                           table[index].mac4, table[index].mac5 };

                    PhysicalAddress mac = new PhysicalAddress(byte_mac);

                    if (table[index].dwType != IpHlpApiWrapper.MIB_IPNET_TYPE_INVALID &&
                        !mac.Equals(PhysicalAddress.Parse("000000000000")))
                    {
                        Host hote = new Host();
                        hote.IpAddress = ip;
                        hote.MacAddress = mac;
                        liste.Add(hote);
                    }
                }
            }
            finally
            {
                // Release the memory.
                Marshal.FreeCoTaskMem(buffer);
            }

            return liste;
        }

        public static PhysicalAddress GetPhysicalAddress(PcapDevice device)
        {
            PhysicalAddress physicalAddress = null;

            if (device.Interface.Addresses.Count > 0)
            {
                physicalAddress = device.Interface.Addresses
                    .Where(a => a.Addr.type == Sockaddr.AddressTypes.HARDWARE)
                    .Select(b => b.Addr.hardwareAddress).Single();
            }

            return physicalAddress;
        }

        public static IPAddress GeIPv4Address(PcapDevice device)
        {
            IPAddress localIpAdress = null;

            if (device.Interface.Addresses.Count > 0)
            {
                localIpAdress = device.Interface.Addresses
                                .Where(a => a.Addr.type == Sockaddr.AddressTypes.AF_INET_AF_INET6 &&
                                            a.Addr.ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                .Select(b => b.Addr.ipAddress).Single();
                
                if (localIpAdress == null)
                    localIpAdress = System.Net.IPAddress.Parse("127.0.0.1");
            }

            return localIpAdress;
        }

        public static IPAddressInfo GetIPAddressInfo(PcapDevice device)
        {
            PcapAddress pcap_address = null;

            if (device.Interface.Addresses.Count == 0)
                throw new InvalidOperationException("Aucune adresse IP dans l'interface.");

            pcap_address = device.Interface.Addresses
                                .Where(a => a.Addr.type == Sockaddr.AddressTypes.AF_INET_AF_INET6 &&
                                            a.Addr.ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                                .SingleOrDefault();

            if (pcap_address == null)
                throw new InvalidOperationException("IP address not found");

            IPAddressInfo ipaddressinfo = new IPAddressInfo();
            ipaddressinfo.IPAddress = pcap_address.Addr.ipAddress;
            ipaddressinfo.Mask = pcap_address.Netmask.ipAddress;
            ipaddressinfo.Gateway = device.Interface.GatewayAddresses.Single();

            ipaddressinfo.IPNetwork = GetNetworkAddress(ipaddressinfo.Mask, ipaddressinfo.IPAddress);
            ipaddressinfo.IPBroadcast = GetBroadcastAddress(ipaddressinfo.Mask, ipaddressinfo.IPAddress);

            return ipaddressinfo;
        }

        private static IPAddress GetBroadcastAddress(IPAddress mask, IPAddress ip)
        {
            byte[] byte_mask = mask.GetAddressBytes();
            byte[] byte_ip_end = { 0, 0, 0, 0 }; // A déterminer
            byte[] byte_ip_start = ip.GetAddressBytes();

            for (int i = 0; i < 4; i++)
            {
                byte_mask[i] = (byte)(byte_mask[i] ^ (byte)0xFF);
                byte_ip_end[i] = (byte)((byte_ip_start[i] | byte_mask[i]));
            }

            return new IPAddress(byte_ip_end);
        }

        private static IPAddress GetNetworkAddress(IPAddress mask, IPAddress ip)
        {
            byte[] byte_mask = mask.GetAddressBytes();
            byte[] byte_ip_start = { 0, 0, 0, 0 };
            byte[] byte_ip_network = ip.GetAddressBytes(); // IPv4 CARTE

            for (int i = 0; i < 4; i++)
                byte_ip_start[i] = (byte)(byte_mask[i] & byte_ip_network[i]);

            return new IPAddress(byte_ip_start);
        }

        public static IPAddress GeMaskAddress(PcapDevice device)
        {
            IPAddress mask = null;

            if (device.Interface.Addresses.Count > 0)
            {
                foreach (var address in device.Interface.Addresses)
                {
                    if (address.Addr.type == Sockaddr.AddressTypes.AF_INET_AF_INET6)
                    {
                        mask = address.Netmask.ipAddress;
                        break; // break out of the foreach
                    }
                }

                if (mask == null)
                {
                    mask = System.Net.IPAddress.Parse("255.255.255.0");
                }
            }

            return mask;
        }     

        public static IPAddress GetNextIP(IPAddress ip)
        {
            byte[] octets_ip = ip.GetAddressBytes();

            for (int i = (octets_ip.Length - 1); i > 0; i--)
            {
                if (octets_ip[i] == 254)
                {
                    if (i == (octets_ip.Length - 1))
                        octets_ip[i] = 1; // 0 = reserved by network
                    else
                        octets_ip[i] = 0;

                    continue;
                }

                octets_ip[i]++;

                break;
            }

            return new IPAddress(octets_ip);
        }

        public static IPAddress GetPreviousIp(IPAddress ip)
        {
            byte[] byte_ip = ip.GetAddressBytes();

            for (int i = (byte_ip.Length - 1); i > 0; i--)
            {
                if (byte_ip[i] == 1)
                {
                    if (i == (byte_ip.Length - 1))
                        byte_ip[i] = 254; // 255 is broadcast (if mask /24)
                    else
                        byte_ip[i] = 255;

                    continue;
                }

                byte_ip[i]--;

                break;
            }

            return new IPAddress(byte_ip);
        }

        public static bool IsIpAddressOfNetwork(PcapDevice device, IPAddress ipAdress)
        {
            IPAddressInfo ip_info = GetIPAddressInfo(device);

            byte[] bytes_ip_device = ip_info.IPAddress.GetAddressBytes(); // IPv4
            byte[] bytes_ip_start = ip_info.IPNetwork.GetAddressBytes();
            byte[] bytes_ip_end = ip_info.IPBroadcast.GetAddressBytes();

            byte[] byte_ipAddress = ipAdress.GetAddressBytes();

            for (int i = 0; i < 4; i++)
            {
                if (byte_ipAddress[i] < bytes_ip_start[i] ||
                    byte_ipAddress[i] > bytes_ip_end[i])
                    return false;
            }

            return true;
        }
    }
}