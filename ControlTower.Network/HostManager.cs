﻿using ControlTower.Network.Common;
using ControlTower.Network.Data;
using System.Collections.Generic;
using System.Linq;

namespace ControlTower
{
    public class HostManager
    {
        public HostManager()
        {
            Hosts = new List<Host>(253);
        }

        public delegate void HostAddedDelegate(object sender, HostEventArgs eventArgs);
        public event HostAddedDelegate HostAdded;

        public void AddHost(object sender, HostEventArgs eventArgs)
        {
            Host host = eventArgs.Host;

            for (int i = 0; i < Hosts.Count(); i++)
            {
                if (host.IpAddress.Equals(Hosts[i].IpAddress) &&
                    host.MacAddress.Equals(Hosts[i].MacAddress) &&
                    host.Name != Hosts[i].Name)
                {
                    Hosts[i] = host;
                    return;
                }
            }

            Hosts.Add(host);

            HostAdded?.Invoke(this, new HostEventArgs() { Host = host });
        }

        public static HostManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new HostManager();

                return _instance;
            }
        }

        public List<Host> Hosts { get; private set; }
        private static HostManager _instance;
    }
}
