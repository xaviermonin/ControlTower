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
using ControlTower.Network;
using ControlTower.Network.Data;

namespace ControlTower
{
     partial class ArpCommunicatorUserControl : ControlTowerUserControl
    {
        public ArpCommunicatorUserControl()
        {
            InitializeComponent();

            HostManager.Instance.HostAdded += AddHostToComboBox;
            arpCommunicator.ReceivedPacket += OnPacketReceived;
        }

        private readonly ArpCommunicator arpCommunicator = new ArpCommunicator();
        private Host lastMessageHost;

        private void OnPacketReceived(Host host, byte[] payload)
        {
            if (InvokeRequired)
            {
                Invoke(new ArpCommunicator.ReceivedPacketHandle(OnPacketReceived), host, payload);
                return;
            }

            if (lastMessageHost?.Equals(host) != true)
            {
                tbMessage.Text += $"{host} say: \r\n";
                lastMessageHost = host;
            }

            tbMessage.Text += Encoding.UTF8.GetString(payload);
        }

        private void AddHostToComboBox(object sender, Network.Common.HostEventArgs eventArgs)
        {
            if (InvokeRequired)
            {
                Invoke(new HostManager.HostAddedDelegate(AddHostToComboBox), sender, eventArgs);
                return;
            }

            cmbHosts.Items.Add(eventArgs.Host);
        }

        private void ArpCommunicatorUserControl_Load(object sender, EventArgs e)
        {
            arpCommunicator.Device = Device;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            arpCommunicator.StartListen();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            var dstHost = cmbHosts.SelectedItem as Host;

            var payload = Encoding.UTF8.GetBytes(tbSend.Text);
            arpCommunicator.Send(dstHost, payload);

            tbSend.Clear();
        }
    }
}
