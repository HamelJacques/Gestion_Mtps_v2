namespace Gestion_Mtps_v2
{
    partial class frmOuverture
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOuverture));
            this.btnFermer = new System.Windows.Forms.Button();
            this.lblChBD = new System.Windows.Forms.Label();
            this.lblmessage = new System.Windows.Forms.Label();
            this.lstUsagers = new System.Windows.Forms.ListBox();
            this.contextMenuOuverture = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemOuvrir = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUsagers = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.btnModifUser = new System.Windows.Forms.Button();
            this.btnModifMps = new System.Windows.Forms.Button();
            this.btnOuvrir = new System.Windows.Forms.Button();
            this.contextMenuOuverture.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFermer
            // 
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Font = new System.Drawing.Font("Arial Unicode MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.Location = new System.Drawing.Point(14, 159);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(541, 52);
            this.btnFermer.TabIndex = 0;
            this.btnFermer.Text = "Fermer l\'application";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // lblChBD
            // 
            this.lblChBD.AutoSize = true;
            this.lblChBD.Location = new System.Drawing.Point(12, 9);
            this.lblChBD.Name = "lblChBD";
            this.lblChBD.Size = new System.Drawing.Size(45, 13);
            this.lblChBD.TabIndex = 1;
            this.lblChBD.Text = "lblChBD";
            // 
            // lblmessage
            // 
            this.lblmessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblmessage.AutoSize = true;
            this.lblmessage.Location = new System.Drawing.Point(12, 222);
            this.lblmessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(59, 13);
            this.lblmessage.TabIndex = 2;
            this.lblmessage.Text = "lblmessage";
            // 
            // lstUsagers
            // 
            this.lstUsagers.ContextMenuStrip = this.contextMenuOuverture;
            this.lstUsagers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUsagers.FormattingEnabled = true;
            this.lstUsagers.ItemHeight = 18;
            this.lstUsagers.Location = new System.Drawing.Point(21, 55);
            this.lstUsagers.Name = "lstUsagers";
            this.lstUsagers.Size = new System.Drawing.Size(241, 58);
            this.lstUsagers.TabIndex = 3;
            this.lstUsagers.Click += new System.EventHandler(this.lstUsagers_Click);
            this.lstUsagers.DoubleClick += new System.EventHandler(this.lstUsagers_DoubleClick);
            this.lstUsagers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstUsagers_MouseDown);
            this.lstUsagers.MouseHover += new System.EventHandler(this.lstUsagers_MouseHover);
            // 
            // contextMenuOuverture
            // 
            this.contextMenuOuverture.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemOuvrir});
            this.contextMenuOuverture.Name = "contextMenuOuverture";
            this.contextMenuOuverture.Size = new System.Drawing.Size(108, 26);
            this.contextMenuOuverture.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuOuverture_Opening);
            // 
            // MenuItemOuvrir
            // 
            this.MenuItemOuvrir.Name = "MenuItemOuvrir";
            this.MenuItemOuvrir.Size = new System.Drawing.Size(107, 22);
            this.MenuItemOuvrir.Text = "Ouvrir";
            this.MenuItemOuvrir.Click += new System.EventHandler(this.MenuItemOuvrir_Click);
            // 
            // lblUsagers
            // 
            this.lblUsagers.AutoSize = true;
            this.lblUsagers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsagers.Location = new System.Drawing.Point(23, 36);
            this.lblUsagers.Name = "lblUsagers";
            this.lblUsagers.Size = new System.Drawing.Size(78, 18);
            this.lblUsagers.TabIndex = 4;
            this.lblUsagers.Text = "lblUsagers";
            // 
            // btnAjout
            // 
            this.btnAjout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout.Location = new System.Drawing.Point(374, 39);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(183, 30);
            this.btnAjout.TabIndex = 5;
            this.btnAjout.Text = "btnAjout";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // btnModifUser
            // 
            this.btnModifUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifUser.Location = new System.Drawing.Point(374, 76);
            this.btnModifUser.Name = "btnModifUser";
            this.btnModifUser.Size = new System.Drawing.Size(183, 30);
            this.btnModifUser.TabIndex = 6;
            this.btnModifUser.Text = "btnModifUser";
            this.btnModifUser.UseVisualStyleBackColor = true;
            this.btnModifUser.Click += new System.EventHandler(this.btnModifUser_Click);
            // 
            // btnModifMps
            // 
            this.btnModifMps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModifMps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifMps.Location = new System.Drawing.Point(372, 112);
            this.btnModifMps.Name = "btnModifMps";
            this.btnModifMps.Size = new System.Drawing.Size(183, 30);
            this.btnModifMps.TabIndex = 7;
            this.btnModifMps.Text = "btnModifMps";
            this.btnModifMps.UseVisualStyleBackColor = true;
            this.btnModifMps.Click += new System.EventHandler(this.btnModifMps_Click);
            // 
            // btnOuvrir
            // 
            this.btnOuvrir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOuvrir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOuvrir.Location = new System.Drawing.Point(268, 39);
            this.btnOuvrir.Name = "btnOuvrir";
            this.btnOuvrir.Size = new System.Drawing.Size(98, 103);
            this.btnOuvrir.TabIndex = 8;
            this.btnOuvrir.Text = "btnOuvrir";
            this.btnOuvrir.UseVisualStyleBackColor = true;
            this.btnOuvrir.Click += new System.EventHandler(this.btnOuvrir_Click);
            // 
            // frmOuverture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 244);
            this.Controls.Add(this.btnOuvrir);
            this.Controls.Add(this.btnModifMps);
            this.Controls.Add(this.btnModifUser);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.lblUsagers);
            this.Controls.Add(this.lstUsagers);
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.lblChBD);
            this.Controls.Add(this.btnFermer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOuverture";
            this.Text = "Form1";
            this.contextMenuOuverture.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label lblChBD;
        private System.Windows.Forms.Label lblmessage;
        private System.Windows.Forms.ListBox lstUsagers;
        private System.Windows.Forms.Label lblUsagers;
        private System.Windows.Forms.Button btnAjout;
        private System.Windows.Forms.Button btnModifUser;
        private System.Windows.Forms.Button btnModifMps;
        private System.Windows.Forms.ContextMenuStrip contextMenuOuverture;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOuvrir;
        private System.Windows.Forms.Button btnOuvrir;
    }
}

