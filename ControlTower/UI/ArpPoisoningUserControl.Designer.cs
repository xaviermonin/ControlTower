namespace ControlTower
{
    partial class ArpPoisoningUserControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_activation_mtm = new System.Windows.Forms.GroupBox();
            this.button_desactiver_ts = new System.Windows.Forms.Button();
            this.button_activer_ts_mtm = new System.Windows.Forms.Button();
            this.groupBox_cible = new System.Windows.Forms.GroupBox();
            this.comboBoxIs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_supprimer = new System.Windows.Forms.Button();
            this.button_modifier = new System.Windows.Forms.Button();
            this.label_cible2 = new System.Windows.Forms.Label();
            this.label_cible1 = new System.Windows.Forms.Label();
            this.button_ajouter_mtm = new System.Windows.Forms.Button();
            this.comboBoxSayTo = new System.Windows.Forms.ComboBox();
            this.comboBoxThat = new System.Windows.Forms.ComboBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeadersayTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderThat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_activation_mtm.SuspendLayout();
            this.groupBox_cible.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_activation_mtm
            // 
            this.groupBox_activation_mtm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_activation_mtm.Controls.Add(this.button_desactiver_ts);
            this.groupBox_activation_mtm.Controls.Add(this.button_activer_ts_mtm);
            this.groupBox_activation_mtm.Location = new System.Drawing.Point(1129, 681);
            this.groupBox_activation_mtm.Name = "groupBox_activation_mtm";
            this.groupBox_activation_mtm.Size = new System.Drawing.Size(316, 49);
            this.groupBox_activation_mtm.TabIndex = 12;
            this.groupBox_activation_mtm.TabStop = false;
            this.groupBox_activation_mtm.Text = "Poison targets";
            // 
            // button_desactiver_ts
            // 
            this.button_desactiver_ts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_desactiver_ts.Location = new System.Drawing.Point(200, 19);
            this.button_desactiver_ts.Name = "button_desactiver_ts";
            this.button_desactiver_ts.Size = new System.Drawing.Size(100, 23);
            this.button_desactiver_ts.TabIndex = 2;
            this.button_desactiver_ts.Text = "Disable all";
            this.button_desactiver_ts.UseVisualStyleBackColor = true;
            this.button_desactiver_ts.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // button_activer_ts_mtm
            // 
            this.button_activer_ts_mtm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_activer_ts_mtm.Location = new System.Drawing.Point(29, 19);
            this.button_activer_ts_mtm.Name = "button_activer_ts_mtm";
            this.button_activer_ts_mtm.Size = new System.Drawing.Size(100, 23);
            this.button_activer_ts_mtm.TabIndex = 1;
            this.button_activer_ts_mtm.Text = "Enable all";
            this.button_activer_ts_mtm.UseVisualStyleBackColor = true;
            this.button_activer_ts_mtm.Click += new System.EventHandler(this.button_activer_ts_Click);
            // 
            // groupBox_cible
            // 
            this.groupBox_cible.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_cible.Controls.Add(this.comboBoxIs);
            this.groupBox_cible.Controls.Add(this.label1);
            this.groupBox_cible.Controls.Add(this.button_supprimer);
            this.groupBox_cible.Controls.Add(this.button_modifier);
            this.groupBox_cible.Controls.Add(this.label_cible2);
            this.groupBox_cible.Controls.Add(this.label_cible1);
            this.groupBox_cible.Controls.Add(this.button_ajouter_mtm);
            this.groupBox_cible.Controls.Add(this.comboBoxSayTo);
            this.groupBox_cible.Controls.Add(this.comboBoxThat);
            this.groupBox_cible.Location = new System.Drawing.Point(3, 598);
            this.groupBox_cible.Name = "groupBox_cible";
            this.groupBox_cible.Size = new System.Drawing.Size(1448, 77);
            this.groupBox_cible.TabIndex = 11;
            this.groupBox_cible.TabStop = false;
            this.groupBox_cible.Text = "Poisoning";
            // 
            // comboBoxIs
            // 
            this.comboBoxIs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxIs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIs.FormattingEnabled = true;
            this.comboBoxIs.Location = new System.Drawing.Point(535, 17);
            this.comboBoxIs.Name = "comboBoxIs";
            this.comboBoxIs.Size = new System.Drawing.Size(189, 21);
            this.comboBoxIs.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "is";
            // 
            // button_supprimer
            // 
            this.button_supprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_supprimer.Location = new System.Drawing.Point(1367, 48);
            this.button_supprimer.Name = "button_supprimer";
            this.button_supprimer.Size = new System.Drawing.Size(75, 23);
            this.button_supprimer.TabIndex = 9;
            this.button_supprimer.Text = "Remove";
            this.button_supprimer.UseVisualStyleBackColor = true;
            this.button_supprimer.Click += new System.EventHandler(this.Button_supprimer_Click);
            // 
            // button_modifier
            // 
            this.button_modifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_modifier.Location = new System.Drawing.Point(1286, 48);
            this.button_modifier.Name = "button_modifier";
            this.button_modifier.Size = new System.Drawing.Size(75, 23);
            this.button_modifier.TabIndex = 8;
            this.button_modifier.Text = "Update";
            this.button_modifier.UseVisualStyleBackColor = true;
            this.button_modifier.Click += new System.EventHandler(this.Button_modifier_Click);
            // 
            // label_cible2
            // 
            this.label_cible2.AutoSize = true;
            this.label_cible2.Location = new System.Drawing.Point(289, 20);
            this.label_cible2.Name = "label_cible2";
            this.label_cible2.Size = new System.Drawing.Size(25, 13);
            this.label_cible2.TabIndex = 7;
            this.label_cible2.Text = "that";
            // 
            // label_cible1
            // 
            this.label_cible1.AutoSize = true;
            this.label_cible1.Location = new System.Drawing.Point(9, 20);
            this.label_cible1.Name = "label_cible1";
            this.label_cible1.Size = new System.Drawing.Size(43, 13);
            this.label_cible1.TabIndex = 6;
            this.label_cible1.Text = "Say to :";
            // 
            // button_ajouter_mtm
            // 
            this.button_ajouter_mtm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ajouter_mtm.Location = new System.Drawing.Point(1205, 48);
            this.button_ajouter_mtm.Name = "button_ajouter_mtm";
            this.button_ajouter_mtm.Size = new System.Drawing.Size(75, 23);
            this.button_ajouter_mtm.TabIndex = 4;
            this.button_ajouter_mtm.Text = "Add";
            this.button_ajouter_mtm.UseVisualStyleBackColor = true;
            this.button_ajouter_mtm.Click += new System.EventHandler(this.buttonAddTargets_Click);
            // 
            // comboBoxSayTo
            // 
            this.comboBoxSayTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSayTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSayTo.FormattingEnabled = true;
            this.comboBoxSayTo.Location = new System.Drawing.Point(58, 17);
            this.comboBoxSayTo.Name = "comboBoxSayTo";
            this.comboBoxSayTo.Size = new System.Drawing.Size(225, 21);
            this.comboBoxSayTo.TabIndex = 2;
            // 
            // comboBoxThat
            // 
            this.comboBoxThat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxThat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThat.FormattingEnabled = true;
            this.comboBoxThat.Location = new System.Drawing.Point(320, 17);
            this.comboBoxThat.Name = "comboBoxThat";
            this.comboBoxThat.Size = new System.Drawing.Size(189, 21);
            this.comboBoxThat.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeadersayTo,
            this.columnHeaderThat,
            this.columnHeaderIs,
            this.columnHeaderStatus});
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1448, 592);
            this.listView.TabIndex = 10;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_ColumnWidthChanging);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // columnHeadersayTo
            // 
            this.columnHeadersayTo.Text = "Say to";
            this.columnHeadersayTo.Width = 247;
            // 
            // columnHeaderThat
            // 
            this.columnHeaderThat.Text = "that";
            this.columnHeaderThat.Width = 265;
            // 
            // columnHeaderIs
            // 
            this.columnHeaderIs.Text = "is";
            this.columnHeaderIs.Width = 219;
            // 
            // columnHeaderStatus
            // 
            this.columnHeaderStatus.Text = "Status";
            this.columnHeaderStatus.Width = 88;
            // 
            // ArpPoisoningUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.groupBox_activation_mtm);
            this.Controls.Add(this.groupBox_cible);
            this.Controls.Add(this.listView);
            this.MinimumSize = new System.Drawing.Size(570, 350);
            this.Name = "ArpPoisoningUserControl";
            this.Size = new System.Drawing.Size(1451, 745);
            this.groupBox_activation_mtm.ResumeLayout(false);
            this.groupBox_cible.ResumeLayout(false);
            this.groupBox_cible.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_activation_mtm;
        private System.Windows.Forms.Button button_desactiver_ts;
        private System.Windows.Forms.Button button_activer_ts_mtm;
        private System.Windows.Forms.GroupBox groupBox_cible;
        private System.Windows.Forms.Label label_cible2;
        private System.Windows.Forms.Label label_cible1;
        private System.Windows.Forms.Button button_ajouter_mtm;
        private System.Windows.Forms.ComboBox comboBoxSayTo;
        private System.Windows.Forms.ComboBox comboBoxThat;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeadersayTo;
        private System.Windows.Forms.ColumnHeader columnHeaderThat;
        private System.Windows.Forms.ColumnHeader columnHeaderStatus;
        private System.Windows.Forms.Button button_supprimer;
        private System.Windows.Forms.Button button_modifier;
        private System.Windows.Forms.ComboBox comboBoxIs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeaderIs;
    }
}
