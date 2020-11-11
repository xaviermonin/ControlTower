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
            Host hostSayTo = null;
            Host hostThat = null;
            Host hostIs = null;

            foreach (Host host in HostManager.Instance.Hosts)
            {
                if (host.Equals(comboBoxSayTo.SelectedItem))
                    hostSayTo = host;
                if (host.Equals(comboBoxThat.SelectedItem))
                    hostThat = host;
                if (host.Equals(comboBoxIs.SelectedItem))
                    hostIs = host;
            }

            if (hostSayTo == null || hostThat == null || hostIs == null)
                return;

            ArpPoisoning arp_poisoning = new ArpPoisoning(hostSayTo, hostThat, hostIs);
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

        private int SelectedIndice
        {
            get
            {
                if (listView.SelectedIndices.Count == 0)
                    return -1;

                return listView.SelectedIndices[0];
            }
        }

        private ArpPoisoning SelectedItem
        {
            get
            {
                int indice = SelectedIndice;
                if (indice != -1)
                    return _list_arp_poisonning[indice];
                else
                    return null;
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

            comboBoxSayTo.Items.Add(host);
            comboBoxThat.Items.Add(host);
            comboBoxIs.Items.Add(host);
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
                ListViewItem item = new ListViewItem(arp_poisoning.Target.ToString());
                item.SubItems.Add(arp_poisoning.Sender.ToString());
                item.SubItems.Add(arp_poisoning.FalsifiedSender.ToString());
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
                RemoveSelectedItem();

                e.Handled = true;
            }
        }

        private void RemoveSelectedItem()
        {
            int indice = SelectedIndice;
            if (indice == -1) return;

            ArpPoisoning arp_poisoning = SelectedItem;
            arp_poisoning.StatusChanged -= UpdateStatut;
            arp_poisoning.Stop();

            _list_arp_poisonning.RemoveAt(indice);

            UpdateView();
            UpdateSelection();
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            int? indice = SelectedIndice;

            if (indice == null)
                return;

            comboBoxSayTo.SelectedItem = _list_arp_poisonning[indice.Value].Target;
            comboBoxThat.SelectedItem = _list_arp_poisonning[indice.Value].Sender;
            comboBoxIs.SelectedItem = _list_arp_poisonning[indice.Value].FalsifiedSender;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            foreach (ArpPoisoning arp_poisoning in _list_arp_poisonning)
                arp_poisoning.Stop();
        }

        private void Button_modifier_Click(object sender, EventArgs e)
        {
            
        }

        private void Button_supprimer_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem();
        }
    }
}
