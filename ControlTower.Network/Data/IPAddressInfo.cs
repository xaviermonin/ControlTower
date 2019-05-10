using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlTower.Data
{
    public struct IPAddressInfo
    {
        public IPAddress IPAddress { get; set; }
        public IPAddress Mask { get; set; }
        public IPAddress Gateway { get; set; }
        public IPAddress IPNetwork { get; set; }
        public IPAddress IPBroadcast { get; set; }
    }
}
