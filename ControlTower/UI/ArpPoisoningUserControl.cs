using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SharpPcap;
using SharpPcap.LibPcap;
using ControlTower.Network.Data;
using ControlTower.UI;
using ControlTower.Network.Common;

namespace ControlTower
{
    partial class ArpPoisoningUserControl : ControlTowerUserControl
    {
        public ArpPoisoningUserControl()
        {
            InitializeComponent();

            HostManager.Instance.HostAdded += AddHostToComboBox;
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            foreach (var arp in _list_arp_poisonning)
            {
                arp.StatusChanged -= UpdateStatut;
                arp.Stop();
            }
        }
        
        private void buttonAddTargets_Click(object sender, EventArgs e)
        {
            Host target1 = null;
            Host target2 = null;

            foreach (Host host in HostManager.Instance.Hosts)
            {
                if (host.Equals(comboBoxTarget1.SelectedItem))
                    target1 = host;
                if (host.Equals(comboBoxTarget2.SelectedItem))
                    target2 = host;
            }

            if (target1 == null || target2 == null)
                return;

            ArpPoisoning arp_poisoning = new ArpPoisoning(target1, target2);
            arp_poisoning.StatusChanged += UpdateStatut;
            _list_arp_poisonning.Add(arp_poisoning);

            UpdateView();
        }

        private void UpdateStatut(object sender, EventArgs args)
        {
            UpdateSelection();
            UpdateView();
        }

        private void UpdateSelection()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateSelection));
                return;
            }

            /*Nullable<int> indice = ItemSelectionne();

            if (indice != null)
            {
                ArpPoisoning mtm = mtms[indice.Value];

            }*/
        }

        private int? SelectedItem
        {
            get
            {
                if (listView.SelectedIndices.Count == 0)
                    return null;

                return listView.SelectedIndices[0];
            }
        }

        private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            listView.ColumnWidthChanging -= listView_ColumnWidthChanging;
            listView.Columns[listView.Columns.Count - 1].Width = -2;
            listView.ColumnWidthChanging += listView_ColumnWidthChanging;
        }

        private void AddHostToComboBox(object sender, HostEventArgs eventArgs)
        {
            if (InvokeRequired)
            {
                Invoke(new HostManager.HostAddedDelegate(AddHostToComboBox), sender, eventArgs);

                return;
            }

            Host host = eventArgs.Host;

            comboBoxTarget1.Items.Add(host);
            comboBoxTarget2.Items.Add(host);
        }

        private void UpdateView()
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(UpdateView));
                return;
            }

            listView.Items.Clear();
            foreach (ArpPoisoning arp_poisoning in _list_arp_poisonning)
            {
                ListViewItem item = new ListViewItem(arp_poisoning.Target1.ToString());
                item.SubItems.Add(arp_poisoning.Target2.ToString());
                item.SubItems.Add(arp_poisoning.IsRunning ? "Enabled" : "Disabled");

                listView.Items.Add(item);
            }
        }

        private void button_activer_ts_Click(object sender, EventArgs e)
        {
            foreach (ArpPoisoning arp_poisoning in _list_arp_poisonning)
            {
                if (!arp_poisoning.IsRunning)
                {
                    arp_poisoning.Device = Device;
                    arp_poisoning.Start();
                }
            }
        }

        private List<ArpPoisoning> _list_arp_poisonning = new List<ArpPoisoning>();

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                int indice = listView.SelectedIndices[0];

                ArpPoisoning arp_poisoning = _list_arp_poisonning[indice];
                arp_poisoning.StatusChanged -= UpdateStatut;
                arp_poisoning.Stop();

                _list_arp_poisonning.RemoveAt(indice);

                UpdateView();
                UpdateSelection();

                e.Handled = true;
            }
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Nullable<int> indice = SelectedItem;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            foreach (ArpPoisoning arp_poisoning in _list_arp_poisonning)
                arp_poisoning.Stop();
        }
    }
}
