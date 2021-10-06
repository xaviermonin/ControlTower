using ControlTower.Network;
using ControlTower.Network.Common;
using ControlTower.Network.Data;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Net;

namespace ControlTower
{
    public class Scanner : Threadable
    {
        public delegate void HostFindDelegate(object sender, HostEventArgs eventArgs);
        public event HostFindDelegate HostFind;

        public LibPcapLiveDevice Device
        {
            get;
            set;
        }

        public IPAddress StartIp { get; set; }

        public IPAddress EndIp { get; set; }

        protected override void OnStarting()
        {
            byte[] byte_start = StartIp.GetAddressBytes();
            byte[] byte_end = EndIp.GetAddressBytes();

            for (int i = 0; i < byte_end.Length; i++)
            {
                if (byte_end[i] < byte_start[i])
                    throw new Exception("Start ip must be lower than end ip");
            }

            if (byte_start[3] == 255 || byte_start[3] == 0 ||
                byte_end[3] == 255 || byte_end[3] == 0)
                throw new Exception("Network and broadcast ip can't be scanned.");

            current_ip = StartIp;
        }

        protected override void Run()
        {
            EndIp = NetUtils.GetNextIP(EndIp);

            ARP arp = new ARP(Device)
            {
                Timeout = new TimeSpan(0, 0, 0, 0, 200)
            };

            // TODO: Filter by interface
            // HostManager.Instance.AddHosts(NetUtils.GetLocalArpTable());

            do
            {
                if (StopAsked)
                    break;
                
                var physicalAddress = arp.Resolve(current_ip);

                if (physicalAddress == null)
                    continue;

                Host host = new Host
                {
                    IpAddress = current_ip,
                    MacAddress = physicalAddress
                };

                if (ResolveHostname)
                {
                    string hostName = string.Empty;
                    try { hostName = Dns.GetHostEntry(host.IpAddress).HostName; } catch { }

                    if (hostName != host.IpAddress.ToString())
                        host.Name = hostName;
                }

                HostFind?.Invoke(this, new HostEventArgs() { Host = host});

            } while (!(current_ip = NetUtils.GetNextIP(current_ip)).Equals(EndIp));
        }

        public List<Host> Hosts { get; } = new List<Host>();

        public bool ResolveHostname { get; set; } = true;

        private IPAddress current_ip;
    }
}
