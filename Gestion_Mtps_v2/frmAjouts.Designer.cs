namespace Gestion_Mtps_v2
{
    partial class frmAjouts
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
            this.lblTypeAjout = new System.Windows.Forms.Label();
            this.txtNouvelleValeur = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(18, 625);
            this.btnFermer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(1164, 63);
            this.btnFermer.TabIndex = 0;
            this.btnFermer.Text = "button1";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // lblTypeAjout
            // 
            this.lblTypeAjout.AutoSize = true;
            this.lblTypeAjout.Location = new System.Drawing.Point(52, 32);
            this.lblTypeAjout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeAjout.Name = "lblTypeAjout";
            this.lblTypeAjout.Size = new System.Drawing.Size(95, 20);
            this.lblTypeAjout.TabIndex = 1;
            this.lblTypeAjout.Text = "lblTypeAjout";
            // 
            // txtNouvelleValeur
            // 
            this.txtNouvelleValeur.Location = new System.Drawing.Point(56, 55);
            this.txtNouvelleValeur.Name = "txtNouvelleValeur";
            this.txtNouvelleValeur.Size = new System.Drawing.Size(259, 26);
            this.txtNouvelleValeur.TabIndex = 2;
            this.txtNouvelleValeur.Text = "txtNouvelleValeur";
            // 
            // frmAjouts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.txtNouvelleValeur);
            this.Controls.Add(this.lblTypeAjout);
            this.Controls.Add(this.btnFermer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAjouts";
            this.Text = "frmAjouts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label lblTypeAjout;
        private System.Windows.Forms.TextBox txtNouvelleValeur;
    }
}