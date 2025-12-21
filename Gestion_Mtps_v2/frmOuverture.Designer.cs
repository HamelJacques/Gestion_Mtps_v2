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
            this.btnFermer = new System.Windows.Forms.Button();
            this.lblChBD = new System.Windows.Forms.Label();
            this.lblmessage = new System.Windows.Forms.Label();
            this.lstUsagers = new System.Windows.Forms.ListBox();
            this.lblUsagers = new System.Windows.Forms.Label();
            this.btnAjout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFermer
            // 
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Font = new System.Drawing.Font("Arial Unicode MS", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.Location = new System.Drawing.Point(14, 135);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(701, 52);
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
            this.lblmessage.Location = new System.Drawing.Point(12, 198);
            this.lblmessage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(59, 13);
            this.lblmessage.TabIndex = 2;
            this.lblmessage.Text = "lblmessage";
            // 
            // lstUsagers
            // 
            this.lstUsagers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstUsagers.FormattingEnabled = true;
            this.lstUsagers.ItemHeight = 18;
            this.lstUsagers.Location = new System.Drawing.Point(34, 55);
            this.lstUsagers.Name = "lstUsagers";
            this.lstUsagers.Size = new System.Drawing.Size(241, 40);
            this.lstUsagers.TabIndex = 3;
            this.lstUsagers.DoubleClick += new System.EventHandler(this.lstUsagers_DoubleClick);
            // 
            // lblUsagers
            // 
            this.lblUsagers.AutoSize = true;
            this.lblUsagers.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsagers.Location = new System.Drawing.Point(36, 36);
            this.lblUsagers.Name = "lblUsagers";
            this.lblUsagers.Size = new System.Drawing.Size(78, 18);
            this.lblUsagers.TabIndex = 4;
            this.lblUsagers.Text = "lblUsagers";
            // 
            // btnAjout
            // 
            this.btnAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout.Location = new System.Drawing.Point(301, 55);
            this.btnAjout.Name = "btnAjout";
            this.btnAjout.Size = new System.Drawing.Size(403, 40);
            this.btnAjout.TabIndex = 5;
            this.btnAjout.Text = "btnAjout";
            this.btnAjout.UseVisualStyleBackColor = true;
            this.btnAjout.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // frmOuverture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 220);
            this.Controls.Add(this.btnAjout);
            this.Controls.Add(this.lblUsagers);
            this.Controls.Add(this.lstUsagers);
            this.Controls.Add(this.lblmessage);
            this.Controls.Add(this.lblChBD);
            this.Controls.Add(this.btnFermer);
            this.Name = "frmOuverture";
            this.Text = "Form1";
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
    }
}

