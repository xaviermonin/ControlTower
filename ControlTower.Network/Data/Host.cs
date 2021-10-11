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

        public override int GetHashCode()
        {
            return IpAddress.GetHashCode() + MacAddress.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Host host))
                return false;

            return IpAddress.Equals(host.IpAddress) && MacAddress.Equals(host.MacAddress);
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return string.Join(Name, IpAddress.ToString());
        }

        [NonSerialized]
        private PhysicalAddress mac;
        private string mac_address;
    }
}
