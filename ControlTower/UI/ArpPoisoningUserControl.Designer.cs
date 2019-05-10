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
            this.button_supprimer = new System.Windows.Forms.Button();
            this.button_modifier = new System.Windows.Forms.Button();
            this.label_cible2 = new System.Windows.Forms.Label();
            this.label_cible1 = new System.Windows.Forms.Label();
            this.button_ajouter_mtm = new System.Windows.Forms.Button();
            this.comboBoxTarget1 = new System.Windows.Forms.ComboBox();
            this.comboBoxTarget2 = new System.Windows.Forms.ComboBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader_cible1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_cible2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_statut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_activation_mtm.SuspendLayout();
            this.groupBox_cible.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_activation_mtm
            // 
            this.groupBox_activation_mtm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_activation_mtm.Controls.Add(this.button_desactiver_ts);
            this.groupBox_activation_mtm.Controls.Add(this.button_activer_ts_mtm);
            this.groupBox_activation_mtm.Location = new System.Drawing.Point(254, 286);
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
            this.groupBox_cible.Controls.Add(this.button_supprimer);
            this.groupBox_cible.Controls.Add(this.button_modifier);
            this.groupBox_cible.Controls.Add(this.label_cible2);
            this.groupBox_cible.Controls.Add(this.label_cible1);
            this.groupBox_cible.Controls.Add(this.button_ajouter_mtm);
            this.groupBox_cible.Controls.Add(this.comboBoxTarget1);
            this.groupBox_cible.Controls.Add(this.comboBoxTarget2);
            this.groupBox_cible.Location = new System.Drawing.Point(3, 203);
            this.groupBox_cible.Name = "groupBox_cible";
            this.groupBox_cible.Size = new System.Drawing.Size(567, 77);
            this.groupBox_cible.TabIndex = 11;
            this.groupBox_cible.TabStop = false;
            this.groupBox_cible.Text = "Targets";
            // 
            // button_supprimer
            // 
            this.button_supprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_supprimer.Location = new System.Drawing.Point(486, 37);
            this.button_supprimer.Name = "button_supprimer";
            this.button_supprimer.Size = new System.Drawing.Size(75, 23);
            this.button_supprimer.TabIndex = 9;
            this.button_supprimer.Text = "Remove";
            this.button_supprimer.UseVisualStyleBackColor = true;
            // 
            // button_modifier
            // 
            this.button_modifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_modifier.Location = new System.Drawing.Point(405, 37);
            this.button_modifier.Name = "button_modifier";
            this.button_modifier.Size = new System.Drawing.Size(75, 23);
            this.button_modifier.TabIndex = 8;
            this.button_modifier.Text = "Update";
            this.button_modifier.UseVisualStyleBackColor = true;
            // 
            // label_cible2
            // 
            this.label_cible2.AutoSize = true;
            this.label_cible2.Location = new System.Drawing.Point(9, 47);
            this.label_cible2.Name = "label_cible2";
            this.label_cible2.Size = new System.Drawing.Size(50, 13);
            this.label_cible2.TabIndex = 7;
            this.label_cible2.Text = "Target 2:";
            // 
            // label_cible1
            // 
            this.label_cible1.AutoSize = true;
            this.label_cible1.Location = new System.Drawing.Point(9, 20);
            this.label_cible1.Name = "label_cible1";
            this.label_cible1.Size = new System.Drawing.Size(50, 13);
            this.label_cible1.TabIndex = 6;
            this.label_cible1.Text = "Target 1:";
            // 
            // button_ajouter_mtm
            // 
            this.button_ajouter_mtm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ajouter_mtm.Location = new System.Drawing.Point(324, 37);
            this.button_ajouter_mtm.Name = "button_ajouter_mtm";
            this.button_ajouter_mtm.Size = new System.Drawing.Size(75, 23);
            this.button_ajouter_mtm.TabIndex = 4;
            this.button_ajouter_mtm.Text = "Add";
            this.button_ajouter_mtm.UseVisualStyleBackColor = true;
            this.button_ajouter_mtm.Click += new System.EventHandler(this.buttonAddTargets_Click);
            // 
            // comboBoxTarget1
            // 
            this.comboBoxTarget1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTarget1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTarget1.FormattingEnabled = true;
            this.comboBoxTarget1.Location = new System.Drawing.Point(66, 17);
            this.comboBoxTarget1.Name = "comboBoxTarget1";
            this.comboBoxTarget1.Size = new System.Drawing.Size(221, 21);
            this.comboBoxTarget1.TabIndex = 2;
            // 
            // comboBoxTarget2
            // 
            this.comboBoxTarget2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTarget2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTarget2.FormattingEnabled = true;
            this.comboBoxTarget2.Location = new System.Drawing.Point(66, 44);
            this.comboBoxTarget2.Name = "comboBoxTarget2";
            this.comboBoxTarget2.Size = new System.Drawing.Size(221, 21);
            this.comboBoxTarget2.TabIndex = 3;
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_cible1,
            this.columnHeader_cible2,
            this.columnHeader_statut});
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.LabelWrap = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(567, 197);
            this.listView.TabIndex = 10;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.listView_ColumnWidthChanging);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // columnHeader_cible1
            // 
            this.columnHeader_cible1.Text = "Target 1";
            this.columnHeader_cible1.Width = 247;
            // 
            // columnHeader_cible2
            // 
            this.columnHeader_cible2.Text = "Target 2";
            this.columnHeader_cible2.Width = 254;
            // 
            // columnHeader_statut
            // 
            this.columnHeader_statut.Text = "Statut";
            // 
            // ArpPoisoningUserControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.groupBox_activation_mtm);
            this.Controls.Add(this.groupBox_cible);
            this.Controls.Add(this.listView);
            this.MinimumSize = new System.Drawing.Size(570, 350);
            this.Name = "ArpPoisoningUserControl";
            this.Size = new System.Drawing.Size(570, 350);
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
        private System.Windows.Forms.ComboBox comboBoxTarget1;
        private System.Windows.Forms.ComboBox comboBoxTarget2;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader_cible1;
        private System.Windows.Forms.ColumnHeader columnHeader_cible2;
        private System.Windows.Forms.ColumnHeader columnHeader_statut;
        private System.Windows.Forms.Button button_supprimer;
        private System.Windows.Forms.Button button_modifier;
    }
}
