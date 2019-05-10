namespace ControlTower
{
    partial class ControlTowerForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageHosts = new System.Windows.Forms.TabPage();
            this.groupBox_import_export = new System.Windows.Forms.GroupBox();
            this.button_exporter = new System.Windows.Forms.Button();
            this.button_importer = new System.Windows.Forms.Button();
            this.groupBox_scan = new System.Windows.Forms.GroupBox();
            this.checkBoxResolveHostname = new System.Windows.Forms.CheckBox();
            this.label_ip_fin = new System.Windows.Forms.Label();
            this.button_scanner = new System.Windows.Forms.Button();
            this.label_ip_debut = new System.Windows.Forms.Label();
            this.textBox_ip_fin = new System.Windows.Forms.TextBox();
            this.textBox_ip_debut = new System.Windows.Forms.TextBox();
            this.listView_hotes = new System.Windows.Forms.ListView();
            this.columnHeader_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_mac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_hostname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageMitm = new System.Windows.Forms.TabPage();
            this.tabPageArpPoisoning = new System.Windows.Forms.TabPage();
            this.tabPageRouter = new System.Windows.Forms.TabPage();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageDnsPoisoning = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageHosts.SuspendLayout();
            this.groupBox_import_export.SuspendLayout();
            this.groupBox_scan.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageHosts);
            this.tabControl.Controls.Add(this.tabPageMitm);
            this.tabControl.Controls.Add(this.tabPageArpPoisoning);
            this.tabControl.Controls.Add(this.tabPageRouter);
            this.tabControl.Controls.Add(this.tabPageDnsPoisoning);
            this.tabControl.Location = new System.Drawing.Point(0, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1047, 614);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageHosts
            // 
            this.tabPageHosts.Controls.Add(this.groupBox_import_export);
            this.tabPageHosts.Controls.Add(this.groupBox_scan);
            this.tabPageHosts.Controls.Add(this.listView_hotes);
            this.tabPageHosts.Location = new System.Drawing.Point(4, 22);
            this.tabPageHosts.Name = "tabPageHosts";
            this.tabPageHosts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHosts.Size = new System.Drawing.Size(1039, 588);
            this.tabPageHosts.TabIndex = 0;
            this.tabPageHosts.Text = "Hosts";
            this.tabPageHosts.UseVisualStyleBackColor = true;
            // 
            // groupBox_import_export
            // 
            this.groupBox_import_export.Controls.Add(this.button_exporter);
            this.groupBox_import_export.Controls.Add(this.button_importer);
            this.groupBox_import_export.Location = new System.Drawing.Point(8, 520);
            this.groupBox_import_export.Name = "groupBox_import_export";
            this.groupBox_import_export.Size = new System.Drawing.Size(1023, 62);
            this.groupBox_import_export.TabIndex = 5;
            this.groupBox_import_export.TabStop = false;
            this.groupBox_import_export.Text = "Import/Export";
            // 
            // button_exporter
            // 
            this.button_exporter.Location = new System.Drawing.Point(529, 19);
            this.button_exporter.Name = "button_exporter";
            this.button_exporter.Size = new System.Drawing.Size(75, 23);
            this.button_exporter.TabIndex = 1;
            this.button_exporter.Text = "Exporter";
            this.button_exporter.UseVisualStyleBackColor = true;
            this.button_exporter.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_importer
            // 
            this.button_importer.Location = new System.Drawing.Point(350, 19);
            this.button_importer.Name = "button_importer";
            this.button_importer.Size = new System.Drawing.Size(75, 23);
            this.button_importer.TabIndex = 0;
            this.button_importer.Text = "Importer";
            this.button_importer.UseVisualStyleBackColor = true;
            this.button_importer.Click += new System.EventHandler(this.Button_importer_Click);
            // 
            // groupBox_scan
            // 
            this.groupBox_scan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_scan.Controls.Add(this.checkBoxResolveHostname);
            this.groupBox_scan.Controls.Add(this.label_ip_fin);
            this.groupBox_scan.Controls.Add(this.button_scanner);
            this.groupBox_scan.Controls.Add(this.label_ip_debut);
            this.groupBox_scan.Controls.Add(this.textBox_ip_fin);
            this.groupBox_scan.Controls.Add(this.textBox_ip_debut);
            this.groupBox_scan.Location = new System.Drawing.Point(8, 459);
            this.groupBox_scan.Name = "groupBox_scan";
            this.groupBox_scan.Size = new System.Drawing.Size(1023, 54);
            this.groupBox_scan.TabIndex = 4;
            this.groupBox_scan.TabStop = false;
            this.groupBox_scan.Text = "Scan IP adress range";
            // 
            // checkBox_resoudre_nom
            // 
            this.checkBoxResolveHostname.AutoSize = true;
            this.checkBoxResolveHostname.Checked = true;
            this.checkBoxResolveHostname.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxResolveHostname.Location = new System.Drawing.Point(350, 21);
            this.checkBoxResolveHostname.Name = "checkBox_resoudre_nom";
            this.checkBoxResolveHostname.Size = new System.Drawing.Size(114, 17);
            this.checkBoxResolveHostname.TabIndex = 5;
            this.checkBoxResolveHostname.Text = "Resolve hostname";
            this.checkBoxResolveHostname.UseVisualStyleBackColor = true;
            // 
            // label_ip_fin
            // 
            this.label_ip_fin.AutoSize = true;
            this.label_ip_fin.Location = new System.Drawing.Point(186, 22);
            this.label_ip_fin.Name = "label_ip_fin";
            this.label_ip_fin.Size = new System.Drawing.Size(42, 13);
            this.label_ip_fin.TabIndex = 4;
            this.label_ip_fin.Text = "End IP:";
            // 
            // button_scanner
            // 
            this.button_scanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_scanner.Location = new System.Drawing.Point(942, 17);
            this.button_scanner.Name = "button_scanner";
            this.button_scanner.Size = new System.Drawing.Size(75, 23);
            this.button_scanner.TabIndex = 1;
            this.button_scanner.Text = "Scan";
            this.button_scanner.UseVisualStyleBackColor = true;
            this.button_scanner.Click += new System.EventHandler(this.buttonScanner_Click);
            // 
            // label_ip_debut
            // 
            this.label_ip_debut.AutoSize = true;
            this.label_ip_debut.Location = new System.Drawing.Point(6, 22);
            this.label_ip_debut.Name = "label_ip_debut";
            this.label_ip_debut.Size = new System.Drawing.Size(45, 13);
            this.label_ip_debut.TabIndex = 0;
            this.label_ip_debut.Text = "Start IP:";
            // 
            // textBox_ip_fin
            // 
            this.textBox_ip_fin.Location = new System.Drawing.Point(244, 19);
            this.textBox_ip_fin.Name = "textBox_ip_fin";
            this.textBox_ip_fin.Size = new System.Drawing.Size(100, 20);
            this.textBox_ip_fin.TabIndex = 3;
            // 
            // textBox_ip_debut
            // 
            this.textBox_ip_debut.Location = new System.Drawing.Point(80, 19);
            this.textBox_ip_debut.Name = "textBox_ip_debut";
            this.textBox_ip_debut.Size = new System.Drawing.Size(100, 20);
            this.textBox_ip_debut.TabIndex = 2;
            // 
            // listView_hotes
            // 
            this.listView_hotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_hotes.AutoArrange = false;
            this.listView_hotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_ip,
            this.columnHeader_mac,
            this.columnHeader_hostname});
            this.listView_hotes.FullRowSelect = true;
            this.listView_hotes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_hotes.LabelWrap = false;
            this.listView_hotes.Location = new System.Drawing.Point(8, 6);
            this.listView_hotes.MultiSelect = false;
            this.listView_hotes.Name = "listView_hotes";
            this.listView_hotes.Size = new System.Drawing.Size(1023, 447);
            this.listView_hotes.TabIndex = 0;
            this.listView_hotes.UseCompatibleStateImageBehavior = false;
            this.listView_hotes.View = System.Windows.Forms.View.Details;
            this.listView_hotes.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_hotes_ColumnWidthChanging);
            // 
            // columnHeader_ip
            // 
            this.columnHeader_ip.Text = "IP Address";
            this.columnHeader_ip.Width = 214;
            // 
            // columnHeader_mac
            // 
            this.columnHeader_mac.Text = "Mac Address";
            this.columnHeader_mac.Width = 251;
            // 
            // columnHeader_hostname
            // 
            this.columnHeader_hostname.Text = "Hostname";
            this.columnHeader_hostname.Width = 526;
            // 
            // tabPageMitm
            // 
            this.tabPageMitm.Location = new System.Drawing.Point(4, 22);
            this.tabPageMitm.Name = "tabPageMitm";
            this.tabPageMitm.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMitm.Size = new System.Drawing.Size(1039, 588);
            this.tabPageMitm.TabIndex = 3;
            this.tabPageMitm.Text = "MITM";
            this.tabPageMitm.UseVisualStyleBackColor = true;
            // 
            // tabPageArpPoisoning
            // 
            this.tabPageArpPoisoning.Location = new System.Drawing.Point(4, 22);
            this.tabPageArpPoisoning.Name = "tabPageArpPoisoning";
            this.tabPageArpPoisoning.Size = new System.Drawing.Size(1039, 588);
            this.tabPageArpPoisoning.TabIndex = 4;
            this.tabPageArpPoisoning.Text = "ARP Poisoning";
            this.tabPageArpPoisoning.UseVisualStyleBackColor = true;
            // 
            // tabPageRouter
            // 
            this.tabPageRouter.Location = new System.Drawing.Point(4, 22);
            this.tabPageRouter.Name = "tabPageRouter";
            this.tabPageRouter.Size = new System.Drawing.Size(1039, 588);
            this.tabPageRouter.TabIndex = 5;
            this.tabPageRouter.Text = "Router";
            this.tabPageRouter.UseVisualStyleBackColor = true;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Cible 1";
            this.columnHeader1.Width = 313;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cible 2";
            this.columnHeader2.Width = 312;
            // 
            // tabPageDnsPoisoning
            // 
            this.tabPageDnsPoisoning.Location = new System.Drawing.Point(4, 22);
            this.tabPageDnsPoisoning.Name = "tabPageDnsPoisoning";
            this.tabPageDnsPoisoning.Size = new System.Drawing.Size(1039, 588);
            this.tabPageDnsPoisoning.TabIndex = 6;
            this.tabPageDnsPoisoning.Text = "DNS Poisoning";
            this.tabPageDnsPoisoning.UseVisualStyleBackColor = true;
            // 
            // ControlTowerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 627);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(750, 550);
            this.Name = "ControlTowerForm";
            this.Text = "Control Tower";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ControlTower_FormClosing);
            this.Load += new System.EventHandler(this.ControlTowerForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageHosts.ResumeLayout(false);
            this.groupBox_import_export.ResumeLayout(false);
            this.groupBox_scan.ResumeLayout(false);
            this.groupBox_scan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageHosts;
        private System.Windows.Forms.ListView listView_hotes;
        private System.Windows.Forms.ColumnHeader columnHeader_ip;
        private System.Windows.Forms.ColumnHeader columnHeader_mac;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button button_scanner;
        private System.Windows.Forms.TextBox textBox_ip_fin;
        private System.Windows.Forms.TextBox textBox_ip_debut;
        private System.Windows.Forms.ColumnHeader columnHeader_hostname;
        private System.Windows.Forms.GroupBox groupBox_scan;
        private System.Windows.Forms.Label label_ip_debut;
        private System.Windows.Forms.Label label_ip_fin;
        private System.Windows.Forms.CheckBox checkBoxResolveHostname;
        private System.Windows.Forms.TabPage tabPageMitm;
        private System.Windows.Forms.GroupBox groupBox_import_export;
        private System.Windows.Forms.Button button_exporter;
        private System.Windows.Forms.Button button_importer;
        private System.Windows.Forms.TabPage tabPageArpPoisoning;
        private System.Windows.Forms.TabPage tabPageRouter;
        private System.Windows.Forms.TabPage tabPageDnsPoisoning;
    }
}

