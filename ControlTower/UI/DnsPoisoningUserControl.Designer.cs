namespace ControlTower
{
    partial class DnsPoisoningUserControl
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
            this.button_activer = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader_nom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_ip = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_ajouter = new System.Windows.Forms.Button();
            this.groupBox_selection = new System.Windows.Forms.GroupBox();
            this.label_select_ip = new System.Windows.Forms.Label();
            this.textBox_select_ip = new System.Windows.Forms.TextBox();
            this.label_select_nom = new System.Windows.Forms.Label();
            this.textBox_select = new System.Windows.Forms.TextBox();
            this.button_appliquer = new System.Windows.Forms.Button();
            this.groupBox_selection.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_activer
            // 
            this.button_activer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_activer.Location = new System.Drawing.Point(1418, 600);
            this.button_activer.Name = "button_activer";
            this.button_activer.Size = new System.Drawing.Size(75, 23);
            this.button_activer.TabIndex = 0;
            this.button_activer.Text = "Start";
            this.button_activer.UseVisualStyleBackColor = true;
            this.button_activer.Click += new System.EventHandler(this.button_activer_Click);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_nom,
            this.columnHeader_ip});
            this.listView.Location = new System.Drawing.Point(3, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(1496, 542);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            // 
            // columnHeader_nom
            // 
            this.columnHeader_nom.Text = "Domain Name";
            this.columnHeader_nom.Width = 225;
            // 
            // columnHeader_ip
            // 
            this.columnHeader_ip.Text = "IP Address";
            this.columnHeader_ip.Width = 165;
            // 
            // button_ajouter
            // 
            this.button_ajouter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ajouter.Location = new System.Drawing.Point(1414, 13);
            this.button_ajouter.Name = "button_ajouter";
            this.button_ajouter.Size = new System.Drawing.Size(78, 23);
            this.button_ajouter.TabIndex = 2;
            this.button_ajouter.Text = "Add";
            this.button_ajouter.UseVisualStyleBackColor = true;
            this.button_ajouter.Click += new System.EventHandler(this.button_ajouter_Click);
            // 
            // groupBox_selection
            // 
            this.groupBox_selection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_selection.Controls.Add(this.label_select_ip);
            this.groupBox_selection.Controls.Add(this.textBox_select_ip);
            this.groupBox_selection.Controls.Add(this.label_select_nom);
            this.groupBox_selection.Controls.Add(this.button_ajouter);
            this.groupBox_selection.Controls.Add(this.textBox_select);
            this.groupBox_selection.Controls.Add(this.button_appliquer);
            this.groupBox_selection.Location = new System.Drawing.Point(3, 548);
            this.groupBox_selection.Name = "groupBox_selection";
            this.groupBox_selection.Size = new System.Drawing.Size(1496, 46);
            this.groupBox_selection.TabIndex = 7;
            this.groupBox_selection.TabStop = false;
            this.groupBox_selection.Text = "Domain";
            // 
            // label_select_ip
            // 
            this.label_select_ip.AutoSize = true;
            this.label_select_ip.Location = new System.Drawing.Point(198, 18);
            this.label_select_ip.Name = "label_select_ip";
            this.label_select_ip.Size = new System.Drawing.Size(61, 13);
            this.label_select_ip.TabIndex = 6;
            this.label_select_ip.Text = "IP Address:";
            // 
            // textBox_select_ip
            // 
            this.textBox_select_ip.Location = new System.Drawing.Point(265, 13);
            this.textBox_select_ip.Name = "textBox_select_ip";
            this.textBox_select_ip.Size = new System.Drawing.Size(100, 20);
            this.textBox_select_ip.TabIndex = 5;
            // 
            // label_select_nom
            // 
            this.label_select_nom.AutoSize = true;
            this.label_select_nom.Location = new System.Drawing.Point(6, 16);
            this.label_select_nom.Name = "label_select_nom";
            this.label_select_nom.Size = new System.Drawing.Size(80, 13);
            this.label_select_nom.TabIndex = 4;
            this.label_select_nom.Text = "Domain Name: ";
            // 
            // textBox_select
            // 
            this.textBox_select.Location = new System.Drawing.Point(92, 13);
            this.textBox_select.Name = "textBox_select";
            this.textBox_select.Size = new System.Drawing.Size(100, 20);
            this.textBox_select.TabIndex = 3;
            // 
            // button_appliquer
            // 
            this.button_appliquer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_appliquer.Location = new System.Drawing.Point(1333, 13);
            this.button_appliquer.Name = "button_appliquer";
            this.button_appliquer.Size = new System.Drawing.Size(78, 23);
            this.button_appliquer.TabIndex = 2;
            this.button_appliquer.Text = "Update";
            this.button_appliquer.UseVisualStyleBackColor = true;
            // 
            // DnsPoisoningUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_selection);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.button_activer);
            this.Name = "DnsPoisoningUserControl";
            this.Size = new System.Drawing.Size(1502, 633);
            this.groupBox_selection.ResumeLayout(false);
            this.groupBox_selection.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_activer;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader_nom;
        private System.Windows.Forms.ColumnHeader columnHeader_ip;
        private System.Windows.Forms.Button button_ajouter;
        private System.Windows.Forms.GroupBox groupBox_selection;
        private System.Windows.Forms.Label label_select_ip;
        private System.Windows.Forms.TextBox textBox_select_ip;
        private System.Windows.Forms.Label label_select_nom;
        private System.Windows.Forms.TextBox textBox_select;
        private System.Windows.Forms.Button button_appliquer;
    }
}
