namespace Gestion_Mtps_v2
{
    partial class frmModifFiltres
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFermer = new System.Windows.Forms.Button();
            this.lblAncienNom = new System.Windows.Forms.Label();
            this.txtAncienNom = new System.Windows.Forms.TextBox();
            this.lblNouveauNom = new System.Windows.Forms.Label();
            this.txtNouveauNom = new System.Windows.Forms.TextBox();
            this.btnSoumettre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFermer
            // 
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.Location = new System.Drawing.Point(9, 167);
            this.btnFermer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(383, 41);
            this.btnFermer.TabIndex = 0;
            this.btnFermer.Text = "btnFermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // lblAncienNom
            // 
            this.lblAncienNom.AutoSize = true;
            this.lblAncienNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAncienNom.Location = new System.Drawing.Point(12, 9);
            this.lblAncienNom.Name = "lblAncienNom";
            this.lblAncienNom.Size = new System.Drawing.Size(97, 16);
            this.lblAncienNom.TabIndex = 1;
            this.lblAncienNom.Text = "lblAncienNom :";
            // 
            // txtAncienNom
            // 
            this.txtAncienNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAncienNom.Location = new System.Drawing.Point(123, 9);
            this.txtAncienNom.Name = "txtAncienNom";
            this.txtAncienNom.Size = new System.Drawing.Size(223, 22);
            this.txtAncienNom.TabIndex = 2;
            // 
            // lblNouveauNom
            // 
            this.lblNouveauNom.AutoSize = true;
            this.lblNouveauNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNouveauNom.Location = new System.Drawing.Point(12, 50);
            this.lblNouveauNom.Name = "lblNouveauNom";
            this.lblNouveauNom.Size = new System.Drawing.Size(105, 16);
            this.lblNouveauNom.TabIndex = 3;
            this.lblNouveauNom.Text = "lblNouveauNom";
            // 
            // txtNouveauNom
            // 
            this.txtNouveauNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNouveauNom.Location = new System.Drawing.Point(123, 47);
            this.txtNouveauNom.Name = "txtNouveauNom";
            this.txtNouveauNom.Size = new System.Drawing.Size(223, 22);
            this.txtNouveauNom.TabIndex = 4;
            this.txtNouveauNom.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNouveauNom_KeyUp);
            // 
            // btnSoumettre
            // 
            this.btnSoumettre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoumettre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoumettre.Location = new System.Drawing.Point(11, 108);
            this.btnSoumettre.Margin = new System.Windows.Forms.Padding(2);
            this.btnSoumettre.Name = "btnSoumettre";
            this.btnSoumettre.Size = new System.Drawing.Size(383, 41);
            this.btnSoumettre.TabIndex = 5;
            this.btnSoumettre.Text = "btnSoumettre";
            this.btnSoumettre.UseVisualStyleBackColor = true;
            this.btnSoumettre.Click += new System.EventHandler(this.btnSoumettre_Click);
            // 
            // frmModifFiltres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 219);
            this.Controls.Add(this.btnSoumettre);
            this.Controls.Add(this.txtNouveauNom);
            this.Controls.Add(this.lblNouveauNom);
            this.Controls.Add(this.txtAncienNom);
            this.Controls.Add(this.lblAncienNom);
            this.Controls.Add(this.btnFermer);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmModifFiltres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmModifFiltres";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label lblAncienNom;
        private System.Windows.Forms.TextBox txtAncienNom;
        private System.Windows.Forms.Label lblNouveauNom;
        private System.Windows.Forms.TextBox txtNouveauNom;
        private System.Windows.Forms.Button btnSoumettre;
    }
}