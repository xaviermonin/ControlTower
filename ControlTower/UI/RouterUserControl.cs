using ControlTower.Network.Common;
using ControlTower.Network.Data;
using ControlTower.UI;
using SharpPcap.LibPcap;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace ControlTower
{
    partial class RouterUserControl : ControlTowerUserControl
    {
        public RouterUserControl()
        {
            InitializeComponent();

            HostManager.Instance.HostAdded += UpdateHosts;
        }

        private void button_enable_Click(object sender, EventArgs e)
        {
            if (router.IsRunning)
            {
                button_start.Text = "Start";
                router.Stop();
            }
            else
            {
                button_start.Text = "Stop"; 
                router.Device = Device;
                router.Start();
            }
        }

        public override LibPcapLiveDevice Device
        {
            get { return router.Device; }
            set { router.Device = value; }
        }

        private const string AllText = "All";
        private const string UnchangedText = "Unchanged";
        internal Router router = Router.Instance;

        private int? SelectedRoute
        {
            get
            {
                if (listView_routes.SelectedIndices.Count == 0)
                    return null;

                return listView_routes.SelectedIndices[0];
            }
        }

        private void UpdateHosts(object sender, HostEventArgs eventArgs)
        {
            if (InvokeRequired)
            {
                Invoke(new HostManager.HostAddedDelegate(UpdateHosts), sender, eventArgs);
                return;
            }

            comboBoxFrom.Items.Add(eventArgs.Host);
        }

        private void listView_routes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? indice = SelectedRoute;

            if (indice == null)
                button_update.Enabled = false;
            else
            {
                Route route = router.Routes[indice.Value];
                
                for (int i = 0; i < comboBoxFrom.Items.Count; i++)
                {
                    Host hote = comboBoxFrom.Items[i] as Host;
                    if (hote.MacAddress.Equals(route.Source.MacAddress))
                        comboBoxFrom.SelectedIndex = i;
                }

                comboBox_ip_src.Text = (route.SourceIp == null ?
                                               AllText : route.SourceIp.ToString());
                comboBox_ip_dst.Text = (route.DestIp == null ?
                                               AllText : route.DestIp.ToString());
                comboBox_new_ip_src.Text = (route.NewSourceIp == null ?
                                               UnchangedText : route.NewSourceIp.ToString());
                comboBox_new_ip_dst.Text = (route.NewDestIp == null ?
                                               UnchangedText : route.NewDestIp.ToString());

                button_update.Enabled = true;
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            Route route = new Route();

            if (comboBoxFrom.SelectedItem == null)
            {
                comboBoxFrom.BackColor = Color.Tomato;
                return;
            }
            else
                comboBoxFrom.BackColor = System.Drawing.SystemColors.Window;

            Host hote = (Host)comboBoxFrom.SelectedItem;
            route.Source = hote;

            UpdateCurrentRouteView(route);

            router.Routes.Add(route);

            UpdateRoutesView();
        }

        private void UpdateCurrentRouteView(Route route)
        {
            if (comboBox_ip_src.Text != AllText)
            {
                IPAddress ip;
                if (IPAddress.TryParse(comboBox_ip_src.Text, out ip))
                {
                    route.SourceIp = ip;
                    comboBox_ip_src.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    comboBox_ip_src.BackColor = Color.Tomato;
                    return;
                }
            }

            if (comboBox_ip_dst.Text != AllText)
            {
                IPAddress ip;
                if (IPAddress.TryParse(comboBox_ip_dst.Text, out ip))
                {
                    route.DestIp = ip;
                    comboBox_ip_dst.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    comboBox_ip_dst.BackColor = Color.Tomato;
                    return;
                }
            }

            if (comboBox_new_ip_src.Text != UnchangedText)
            {
                IPAddress ip;
                if (IPAddress.TryParse(comboBox_new_ip_src.Text, out ip))
                {
                    route.NewSourceIp = new Host() { IpAddress = ip, MacAddress = router.ResolveMacAdress(ip) };
                    comboBox_new_ip_src.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    comboBox_new_ip_src.BackColor = Color.Tomato;
                    return;
                }
            }

            if (comboBox_new_ip_dst.Text != UnchangedText)
            {
                IPAddress ip;
                if (IPAddress.TryParse(comboBox_new_ip_dst.Text, out ip))
                {
                    route.NewDestIp = new Host() { IpAddress = ip, MacAddress = router.ResolveMacAdress(ip) };
                    comboBox_new_ip_dst.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    comboBox_new_ip_dst.BackColor = Color.Tomato;
                    return;
                }
            }
        }

        private void UpdateRoutesView()
        {
            listView_routes.Items.Clear();

            foreach (Route route in router.Routes)
            {
                ListViewItem item = new ListViewItem(route.Source.ToString());

                if (route.SourceIp != null)
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, route.SourceIp.ToString()));
                else
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, AllText));

                if (route.DestIp != null)
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, route.DestIp.ToString()));
                else
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, AllText));

                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, "=>"));

                if (route.NewSourceIp != null)
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, route.NewSourceIp.ToString()));
                else
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, UnchangedText));

                if (route.NewDestIp != null)
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, route.NewDestIp.ToString()));
                else
                    item.SubItems.Add(new ListViewItem.ListViewSubItem(item, UnchangedText));

                listView_routes.Items.Add(item);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            int? indice = SelectedRoute;

            if (indice == null)
                return;

            Route route = new Route();

            if (comboBoxFrom.SelectedItem == null)
            {
                comboBoxFrom.BackColor = Color.Tomato;
                return;
            }
            else
                comboBoxFrom.BackColor = SystemColors.Window;

            Host hote = comboBoxFrom.SelectedItem as Host;
            route.Source = hote;

            UpdateCurrentRouteView(route);

            router.Routes[indice.Value] = route;

            UpdateRoutesView();
        }

        private void button_remove_Click(object sender, EventArgs e)
        {
            int? indice = SelectedRoute;

            if (indice == null)
                return;

            router.Routes.RemoveAt(indice.Value);
            UpdateRoutesView();
        }
    }
}
