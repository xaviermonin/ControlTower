using ControlTower.Network;
using ControlTower.Network.Common;
using ControlTower.Network.Data;
using ControlTower.UI;
using SharpPcap.LibPcap;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ControlTower
{
    public partial class ControlTowerForm : Form
    {
        public ControlTowerForm()
        {
            InitializeComponent();

            tabPageMitm.Controls.Add(new ManInTheMiddleUserControl());
            tabPageArpPoisoning.Controls.Add(new ArpPoisoningUserControl());
            tabPageRouter.Controls.Add(new RouterUserControl());
            tabPageDnsPoisoning.Controls.Add(new DnsPoisoningUserControl());

            scanner.StatusChanged += UpdateButton;
            scanner.HostFind += HostManager.Instance.AddHost;

            HostManager.Instance.HostAdded += AddHostToListView;
        }

        private void SetDevice(LibPcapLiveDevice device)
        {
            var ip_info = NetUtils.GetIPAddressInfo(device);

            textBox_ip_debut.Text = NetUtils.GetNextIP(ip_info.IPNetwork).ToString();
            textBox_ip_fin.Text = NetUtils.GetPreviousIp(ip_info.IPBroadcast).ToString();

            scanner.Device = device;

            foreach (TabPage tab in tabControl.TabPages)
            {
                var uc = tab.Controls[0] as ControlTowerUserControl;
                if (uc != null)
                    uc.Device = device;
            }
        }

        private void buttonScanner_Click(object sender, EventArgs e)
        {
            if (!IPAddress.TryParse(textBox_ip_debut.Text, out IPAddress ip_debut))
                textBox_ip_debut.BackColor = Color.Tomato;

            if (!IPAddress.TryParse(textBox_ip_fin.Text, out IPAddress ip_fin))
                textBox_ip_fin.BackColor = Color.Tomato;

            if (ip_fin == IPAddress.None || ip_debut == IPAddress.None)
                return;

            if (scanner.IsRunning)
                scanner.Stop();
            else
            {
                scanner.StartIp = ip_debut;
                scanner.EndIp = ip_fin;
                scanner.ResolveHostname = checkBoxResolveHostname.Checked;

                scanner.Start();
            }
        }

        private const string StopString = "Stop";
        private const string ScanString = "Scan";

        private void UpdateButton(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler(UpdateButton), sender, e);
                return;
            }

            if (scanner.IsRunning)
                button_scanner.Text = StopString;
            else
                button_scanner.Text = ScanString;
        }

        private Scanner scanner = new Scanner();

        private void ControlTower_FormClosing(object sender, FormClosingEventArgs e)
        {
            scanner.StatusChanged -= UpdateButton;
            scanner.Stop();
        }

        private void AddHostToListView(object sender, HostEventArgs eventArgs)
        {
            if (InvokeRequired)
            {
                Invoke(new HostManager.HostAddedDelegate(AddHostToListView), sender, eventArgs);
                return;
            }

            Host host = eventArgs.Host;

            ListViewItem item = new ListViewItem(host.IpAddress.ToString());
            item.SubItems.Add(host.MacAddress.ToString());
            item.SubItems.Add(host.Name);

            listView_hotes.Items.Add(item);
        }

        private void listView_hotes_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            listView_hotes.ColumnWidthChanging -= listView_hotes_ColumnWidthChanging;
            listView_hotes.Columns[listView_hotes.Columns.Count - 1].Width = -2;
            listView_hotes.ColumnWidthChanging += listView_hotes_ColumnWidthChanging;
        }

        private void button_export_Click(object sender, EventArgs e)
        {
            SaveFileDialog save_dialog = new SaveFileDialog();
            save_dialog.Filter = "Files hosts (*.hosts)|*.hosts|All files (*.*)|*.*";
            save_dialog.Title = "Save hosts list";

            if (save_dialog.ShowDialog() != DialogResult.OK)
                return;

            if (string.IsNullOrEmpty(save_dialog.FileName))
                return;

            try
            {
                using (Stream writer = new FileStream(save_dialog.FileName, FileMode.Create))
                {
                    BinaryFormatter binary_serialiser = new BinaryFormatter();
                    binary_serialiser.Serialize(writer, HostManager.Instance.Hosts);
                }
            }
            catch (Exception except)
            {
                MessageBox.Show(String.Format("Unable to export host list: {0}", except.Message));
            }
        }

        private void Button_importer_Click(object sender, EventArgs e)
        {

        }

        private void ControlTowerForm_Load(object sender, EventArgs e)
        {
            InterfaceForm interfaceForm = new InterfaceForm();
            if (interfaceForm.ShowDialog() != DialogResult.OK ||
                interfaceForm.Device == null)
            {
                Close();
                return;
            }

            SetDevice(interfaceForm.Device);
        }
    }
}
