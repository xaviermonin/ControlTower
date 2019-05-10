using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.NetworkInformation;

namespace ControlTower.Network.Data
{
    public struct Route
    {
        public Host Source { get; set; }
        public IPAddress SourceIp { get; set; }
        public IPAddress DestIp { get; set; }

        public Host NewSourceIp { get; set; }
        public Host NewDestIp { get; set; }
    }
}
