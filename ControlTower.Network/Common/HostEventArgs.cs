using ControlTower.Network.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControlTower.Network.Common
{
    public class HostEventArgs : EventArgs
    {
        public Host Host { get; set; }
    }
}
