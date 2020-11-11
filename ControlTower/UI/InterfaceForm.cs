using ControlTower.Network;
using SharpPcap.LibPcap;
using System;
using System.Windows.Forms;
using System.Linq;

namespace ControlTower.UI
{
    public partial class InterfaceForm : Form
    {
        public InterfaceForm()
        {
            InitializeComponent();

            foreach (var device in NetUtils.GetLibPcapLiveEthernetDevices())
                listViewInterfaces.Items.Add(new ListViewItem(new string[] { device.Name, device.Description, NetUtils.GeIPv4Address(device).ToString() }));

            listViewInterfaces.ItemChecked += ListViewInterfaces_ItemChecked;
        }

        bool _doCheck = true;

        private void ListViewInterfaces_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!_doCheck)
                return;

            _doCheck = false;
            foreach (ListViewItem lvi in listViewInterfaces.Items)
            {
                if (lvi != e.Item)
                    lvi.Checked = false;
            }
            _doCheck = true;

            if (e.Item.Checked)
                Device = NetUtils.GetLibPcapLiveEthernetDevices().Single(d => d.Name == e.Item.Text);

            buttonOk.Enabled = e.Item.Checked;
        }

        public LibPcapLiveDevice Device
        {
            get;
            private set;
        }
    }
}
