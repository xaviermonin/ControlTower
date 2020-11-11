using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using ControlTower.UI;

namespace ControlTower
{
     partial class DnsPoisoningUserControl : ControlTowerUserControl
    {
        public DnsPoisoningUserControl()
        {
            InitializeComponent();
        }
        private void button_add_Click(object sender, EventArgs e)
        {
            IPAddress address;

            if (!IPAddress.TryParse(textBox_select_ip.Text, out address))
            {
                textBox_select_ip.BackColor = Color.Tomato;
                return;
            }

            textBox_select_ip.BackColor = SystemColors.Window;

            dns_poisoning.Resolutions.Add(textBox_select.Text, address);
            UpdateListView();
        }

        private DnsPoisoning dns_poisoning = new DnsPoisoning();

        private void UpdateListView()
        {
            listView.Items.Clear();
            foreach (KeyValuePair<string, IPAddress> paire in dns_poisoning.Resolutions)
            {
                ListViewItem item = new ListViewItem(paire.Key);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, paire.Value.ToString()));
                listView.Items.Add(item);
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (button_activer.Text == "Start")
            {
                button_activer.Text = "Stop";
                Router.Instance.ReceivedPacked += dns_poisoning.Poison;
            }
            else
            {
                button_activer.Text = "Start";
                Router.Instance.ReceivedPacked -= dns_poisoning.Poison;
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
