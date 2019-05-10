using SharpPcap.LibPcap;
using System.Windows.Forms;

namespace ControlTower.UI
{
    class ControlTowerUserControl : UserControl
    {
        public ControlTowerUserControl()
        {
            Dock = DockStyle.Fill;
        }

        public virtual LibPcapLiveDevice Device
        {
            get;
            set;
        }
    }
}
