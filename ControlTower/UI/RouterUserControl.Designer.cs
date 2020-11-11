namespace ControlTower
{
    partial class RouterUserControl
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
            this.listView_routes = new System.Windows.Forms.ListView();
            this.columnHeader_from = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ip_src = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ip_dst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_separateur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_new_ip_src = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_new_ip_dst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox_ajout = new System.Windows.Forms.GroupBox();
            this.button_start = new System.Windows.Forms.Button();
            this.button_supprimer = new System.Windows.Forms.Button();
            this.button_update = new System.Windows.Forms.Button();
            this.button_ajouter = new System.Windows.Forms.Button();
            this.groupBox_new_route = new System.Windows.Forms.GroupBox();
            this.comboBox_new_ip_dst = new System.Windows.Forms.ComboBox();
            this.comboBox_new_ip_src = new System.Windows.Forms.ComboBox();
            this.label_new_ip_dst = new System.Windows.Forms.Label();
            this.label_new_ip_src = new System.Windows.Forms.Label();
            this.groupBox_filtre = new System.Windows.Forms.GroupBox();
            this.comboBoxFrom = new System.Windows.Forms.ComboBox();
            this.comboBox_ip_dst = new System.Windows.Forms.ComboBox();
            this.comboBox_ip_src = new System.Windows.Forms.ComboBox();
            this.label_ip_dst = new System.Windows.Forms.Label();
            this.label_ip_src = new System.Windows.Forms.Label();
            this.label_provenance = new System.Windows.Forms.Label();
            this.groupBox_ajout.SuspendLayout();
            this.groupBox_new_route.SuspendLayout();
            this.groupBox_filtre.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView_routes
            // 
            this.listView_routes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_routes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_from,
            this.columnHeader_ip_src,
            this.columnHeader_ip_dst,
            this.columnHeader_separateur,
            this.columnHeader_new_ip_src,
            this.columnHeader_new_ip_dst});
            this.listView_routes.FullRowSelect = true;
            this.listView_routes.HideSelection = false;
            this.listView_routes.Location = new System.Drawing.Point(3, 3);
            this.listView_routes.Name = "listView_routes";
            this.listView_routes.Size = new System.Drawing.Size(1602, 606);
            this.listView_routes.TabIndex = 0;
            this.listView_routes.UseCompatibleStateImageBehavior = false;
            this.listView_routes.View = System.Windows.Forms.View.Details;
            this.listView_routes.SelectedIndexChanged += new System.EventHandler(this.listView_routes_SelectedIndexChanged);
            // 
            // columnHeader_from
            // 
            this.columnHeader_from.Text = "From";
            this.columnHeader_from.Width = 116;
            // 
            // columnHeader_ip_src
            // 
            this.columnHeader_ip_src.Text = "Source IP";
            this.columnHeader_ip_src.Width = 95;
            // 
            // columnHeader_ip_dst
            // 
            this.columnHeader_ip_dst.Text = "Destination IP";
            this.columnHeader_ip_dst.Width = 82;
            // 
            // columnHeader_separateur
            // 
            this.columnHeader_separateur.Text = "=>";
            this.columnHeader_separateur.Width = 29;
            // 
            // columnHeader_new_ip_src
            // 
            this.columnHeader_new_ip_src.Text = "Source IP";
            this.columnHeader_new_ip_src.Width = 95;
            // 
            // columnHeader_new_ip_dst
            // 
            this.columnHeader_new_ip_dst.Text = "Destination IP";
            this.columnHeader_new_ip_dst.Width = 110;
            // 
            // groupBox_ajout
            // 
            this.groupBox_ajout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_ajout.Controls.Add(this.button_start);
            this.groupBox_ajout.Controls.Add(this.button_supprimer);
            this.groupBox_ajout.Controls.Add(this.button_update);
            this.groupBox_ajout.Controls.Add(this.button_ajouter);
            this.groupBox_ajout.Controls.Add(this.groupBox_new_route);
            this.groupBox_ajout.Controls.Add(this.groupBox_filtre);
            this.groupBox_ajout.Location = new System.Drawing.Point(0, 615);
            this.groupBox_ajout.Name = "groupBox_ajout";
            this.groupBox_ajout.Size = new System.Drawing.Size(1602, 201);
            this.groupBox_ajout.TabIndex = 2;
            this.groupBox_ajout.TabStop = false;
            this.groupBox_ajout.Text = "Routes";
            // 
            // button_start
            // 
            this.button_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_start.Location = new System.Drawing.Point(1519, 162);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_enable_Click);
            // 
            // button_supprimer
            // 
            this.button_supprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_supprimer.Location = new System.Drawing.Point(170, 162);
            this.button_supprimer.Name = "button_supprimer";
            this.button_supprimer.Size = new System.Drawing.Size(75, 23);
            this.button_supprimer.TabIndex = 8;
            this.button_supprimer.Text = "Remove";
            this.button_supprimer.UseVisualStyleBackColor = true;
            this.button_supprimer.Click += new System.EventHandler(this.button_remove_Click);
            // 
            // button_update
            // 
            this.button_update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_update.Location = new System.Drawing.Point(89, 162);
            this.button_update.Name = "button_update";
            this.button_update.Size = new System.Drawing.Size(75, 23);
            this.button_update.TabIndex = 7;
            this.button_update.Text = "Update";
            this.button_update.UseVisualStyleBackColor = true;
            this.button_update.Click += new System.EventHandler(this.button_update_Click);
            // 
            // button_ajouter
            // 
            this.button_ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_ajouter.Location = new System.Drawing.Point(8, 162);
            this.button_ajouter.Name = "button_ajouter";
            this.button_ajouter.Size = new System.Drawing.Size(75, 23);
            this.button_ajouter.TabIndex = 6;
            this.button_ajouter.Text = "Add";
            this.button_ajouter.UseVisualStyleBackColor = true;
            this.button_ajouter.Click += new System.EventHandler(this.button_add_Click);
            // 
            // groupBox_new_route
            // 
            this.groupBox_new_route.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_new_route.Controls.Add(this.comboBox_new_ip_dst);
            this.groupBox_new_route.Controls.Add(this.comboBox_new_ip_src);
            this.groupBox_new_route.Controls.Add(this.label_new_ip_dst);
            this.groupBox_new_route.Controls.Add(this.label_new_ip_src);
            this.groupBox_new_route.Location = new System.Drawing.Point(7, 97);
            this.groupBox_new_route.Name = "groupBox_new_route";
            this.groupBox_new_route.Size = new System.Drawing.Size(1587, 47);
            this.groupBox_new_route.TabIndex = 5;
            this.groupBox_new_route.TabStop = false;
            this.groupBox_new_route.Text = "New route";
            // 
            // comboBox_new_ip_dst
            // 
            this.comboBox_new_ip_dst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_new_ip_dst.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_new_ip_dst.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_new_ip_dst.FormattingEnabled = true;
            this.comboBox_new_ip_dst.Items.AddRange(new object[] {
            "Unchanged"});
            this.comboBox_new_ip_dst.Location = new System.Drawing.Point(1262, 17);
            this.comboBox_new_ip_dst.MaxLength = 15;
            this.comboBox_new_ip_dst.Name = "comboBox_new_ip_dst";
            this.comboBox_new_ip_dst.Size = new System.Drawing.Size(319, 21);
            this.comboBox_new_ip_dst.TabIndex = 10;
            this.comboBox_new_ip_dst.Text = "Unchanged";
            // 
            // comboBox_new_ip_src
            // 
            this.comboBox_new_ip_src.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_new_ip_src.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_new_ip_src.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_new_ip_src.FormattingEnabled = true;
            this.comboBox_new_ip_src.Items.AddRange(new object[] {
            "Unchanged"});
            this.comboBox_new_ip_src.Location = new System.Drawing.Point(82, 17);
            this.comboBox_new_ip_src.MaxLength = 15;
            this.comboBox_new_ip_src.Name = "comboBox_new_ip_src";
            this.comboBox_new_ip_src.Size = new System.Drawing.Size(1089, 21);
            this.comboBox_new_ip_src.TabIndex = 7;
            this.comboBox_new_ip_src.Text = "Unchanged";
            // 
            // label_new_ip_dst
            // 
            this.label_new_ip_dst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_new_ip_dst.AutoSize = true;
            this.label_new_ip_dst.Location = new System.Drawing.Point(1177, 20);
            this.label_new_ip_dst.Name = "label_new_ip_dst";
            this.label_new_ip_dst.Size = new System.Drawing.Size(76, 13);
            this.label_new_ip_dst.TabIndex = 9;
            this.label_new_ip_dst.Text = "Destination IP:";
            // 
            // label_new_ip_src
            // 
            this.label_new_ip_src.AutoSize = true;
            this.label_new_ip_src.Location = new System.Drawing.Point(6, 20);
            this.label_new_ip_src.Name = "label_new_ip_src";
            this.label_new_ip_src.Size = new System.Drawing.Size(57, 13);
            this.label_new_ip_src.TabIndex = 7;
            this.label_new_ip_src.Text = "Source IP:";
            // 
            // groupBox_filtre
            // 
            this.groupBox_filtre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_filtre.Controls.Add(this.comboBoxFrom);
            this.groupBox_filtre.Controls.Add(this.comboBox_ip_dst);
            this.groupBox_filtre.Controls.Add(this.comboBox_ip_src);
            this.groupBox_filtre.Controls.Add(this.label_ip_dst);
            this.groupBox_filtre.Controls.Add(this.label_ip_src);
            this.groupBox_filtre.Controls.Add(this.label_provenance);
            this.groupBox_filtre.Location = new System.Drawing.Point(6, 19);
            this.groupBox_filtre.Name = "groupBox_filtre";
            this.groupBox_filtre.Size = new System.Drawing.Size(1588, 72);
            this.groupBox_filtre.TabIndex = 4;
            this.groupBox_filtre.TabStop = false;
            this.groupBox_filtre.Text = "Filter";
            // 
            // comboBoxFrom
            // 
            this.comboBoxFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrom.FormattingEnabled = true;
            this.comboBoxFrom.Location = new System.Drawing.Point(83, 13);
            this.comboBoxFrom.Name = "comboBoxFrom";
            this.comboBoxFrom.Size = new System.Drawing.Size(1499, 21);
            this.comboBoxFrom.TabIndex = 8;
            // 
            // comboBox_ip_dst
            // 
            this.comboBox_ip_dst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_ip_dst.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_ip_dst.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_ip_dst.FormattingEnabled = true;
            this.comboBox_ip_dst.Items.AddRange(new object[] {
            "All"});
            this.comboBox_ip_dst.Location = new System.Drawing.Point(1263, 44);
            this.comboBox_ip_dst.MaxLength = 15;
            this.comboBox_ip_dst.Name = "comboBox_ip_dst";
            this.comboBox_ip_dst.Size = new System.Drawing.Size(319, 21);
            this.comboBox_ip_dst.TabIndex = 7;
            this.comboBox_ip_dst.Text = "All";
            // 
            // comboBox_ip_src
            // 
            this.comboBox_ip_src.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_ip_src.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBox_ip_src.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_ip_src.FormattingEnabled = true;
            this.comboBox_ip_src.Items.AddRange(new object[] {
            "All"});
            this.comboBox_ip_src.Location = new System.Drawing.Point(83, 44);
            this.comboBox_ip_src.MaxLength = 15;
            this.comboBox_ip_src.Name = "comboBox_ip_src";
            this.comboBox_ip_src.Size = new System.Drawing.Size(1089, 21);
            this.comboBox_ip_src.TabIndex = 6;
            this.comboBox_ip_src.Text = "All";
            // 
            // label_ip_dst
            // 
            this.label_ip_dst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ip_dst.AutoSize = true;
            this.label_ip_dst.Location = new System.Drawing.Point(1178, 47);
            this.label_ip_dst.Name = "label_ip_dst";
            this.label_ip_dst.Size = new System.Drawing.Size(76, 13);
            this.label_ip_dst.TabIndex = 5;
            this.label_ip_dst.Text = "Destination IP:";
            // 
            // label_ip_src
            // 
            this.label_ip_src.AutoSize = true;
            this.label_ip_src.Location = new System.Drawing.Point(6, 47);
            this.label_ip_src.Name = "label_ip_src";
            this.label_ip_src.Size = new System.Drawing.Size(57, 13);
            this.label_ip_src.TabIndex = 3;
            this.label_ip_src.Text = "Source IP:";
            // 
            // label_provenance
            // 
            this.label_provenance.AutoSize = true;
            this.label_provenance.Location = new System.Drawing.Point(6, 16);
            this.label_provenance.Name = "label_provenance";
            this.label_provenance.Size = new System.Drawing.Size(36, 13);
            this.label_provenance.TabIndex = 1;
            this.label_provenance.Text = "From :";
            // 
            // RouterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox_ajout);
            this.Controls.Add(this.listView_routes);
            this.MinimumSize = new System.Drawing.Size(810, 350);
            this.Name = "RouterUserControl";
            this.Size = new System.Drawing.Size(1608, 819);
            this.groupBox_ajout.ResumeLayout(false);
            this.groupBox_new_route.ResumeLayout(false);
            this.groupBox_new_route.PerformLayout();
            this.groupBox_filtre.ResumeLayout(false);
            this.groupBox_filtre.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView_routes;
        private System.Windows.Forms.ColumnHeader columnHeader_from;
        private System.Windows.Forms.ColumnHeader columnHeader_ip_src;
        private System.Windows.Forms.ColumnHeader columnHeader_ip_dst;
        private System.Windows.Forms.ColumnHeader columnHeader_separateur;
        private System.Windows.Forms.ColumnHeader columnHeader_new_ip_src;
        private System.Windows.Forms.ColumnHeader columnHeader_new_ip_dst;
        private System.Windows.Forms.GroupBox groupBox_ajout;
        private System.Windows.Forms.Label label_provenance;
        private System.Windows.Forms.Label label_ip_src;
        private System.Windows.Forms.GroupBox groupBox_new_route;
        private System.Windows.Forms.Label label_new_ip_dst;
        private System.Windows.Forms.Label label_new_ip_src;
        private System.Windows.Forms.GroupBox groupBox_filtre;
        private System.Windows.Forms.Label label_ip_dst;
        private System.Windows.Forms.Button button_ajouter;
        private System.Windows.Forms.ComboBox comboBox_ip_src;
        private System.Windows.Forms.ComboBox comboBox_new_ip_dst;
        private System.Windows.Forms.ComboBox comboBox_new_ip_src;
        private System.Windows.Forms.ComboBox comboBox_ip_dst;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.ComboBox comboBoxFrom;
        private System.Windows.Forms.Button button_supprimer;
        private System.Windows.Forms.Button button_update;
    }
}
