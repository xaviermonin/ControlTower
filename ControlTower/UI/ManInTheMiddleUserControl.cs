using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPcap.LibPcap;
using ControlTower.UI;

namespace ControlTower
{
    partial class ManInTheMiddleUserControl : ControlTowerUserControl
    {
        public ManInTheMiddleUserControl()
        {
            InitializeComponent();
        }

        public void Free()
        {
        }

        public LibPcapLiveDevice Device
        {
            get;
            set;
        }
    }
}

