using System;
using System.Net;
using System.Net.NetworkInformation;

namespace ControlTower.Network.Data
{
    [Serializable]
    public class Host
    {
        public Host()
        {
            if (!string.IsNullOrEmpty(mac_address))
                mac = PhysicalAddress.Parse(mac_address);
        }

        public IPAddress IpAddress { get; set; }

        public PhysicalAddress MacAddress
        {
            get { return mac; }
            set { mac = value; mac_address = mac.ToString(); }
        }

        public string Name { get; set; }

        public override string ToString()
        {
            if (Name != string.Empty)
                return Name + ' ' + IpAddress.ToString();
            else
                return IpAddress.ToString();
        }

        [NonSerialized]
        private PhysicalAddress mac;
        private string mac_address;
    }
}
