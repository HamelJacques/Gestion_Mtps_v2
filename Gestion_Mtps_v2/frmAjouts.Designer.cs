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
            this.btnAjouter = new System.Windows.Forms.Button();
            this.grbxMotPasseUsager = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbxLstValsDispo = new System.Windows.Forms.GroupBox();
            this.lstValsDispo = new System.Windows.Forms.ListBox();
            this.grbxMotPasseUsager.SuspendLayout();
            this.grbxLstValsDispo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFermer
            // 
            this.btnFermer.Location = new System.Drawing.Point(13, 211);
            this.btnFermer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(561, 63);
            this.btnFermer.TabIndex = 0;
            this.btnFermer.Text = "btnFermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // lblTypeAjout
            // 
            this.lblTypeAjout.AutoSize = true;
            this.lblTypeAjout.Location = new System.Drawing.Point(14, 12);
            this.lblTypeAjout.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTypeAjout.Name = "lblTypeAjout";
            this.lblTypeAjout.Size = new System.Drawing.Size(95, 20);
            this.lblTypeAjout.TabIndex = 1;
            this.lblTypeAjout.Text = "lblTypeAjout";
            // 
            // txtNouvelleValeur
            // 
            this.txtNouvelleValeur.Location = new System.Drawing.Point(18, 35);
            this.txtNouvelleValeur.Name = "txtNouvelleValeur";
            this.txtNouvelleValeur.Size = new System.Drawing.Size(259, 26);
            this.txtNouvelleValeur.TabIndex = 2;
            this.txtNouvelleValeur.Text = "txtNouvelleValeur";
            this.txtNouvelleValeur.TextChanged += new System.EventHandler(this.txtNouvelleValeur_TextChanged);
            this.txtNouvelleValeur.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNouvelleValeur_KeyUp);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(13, 170);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(224, 33);
            this.btnAjouter.TabIndex = 3;
            this.btnAjouter.Text = "btnAjouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // grbxMotPasseUsager
            // 
            this.grbxMotPasseUsager.BackColor = System.Drawing.Color.PapayaWhip;
            this.grbxMotPasseUsager.Controls.Add(this.textBox1);
            this.grbxMotPasseUsager.Location = new System.Drawing.Point(604, 32);
            this.grbxMotPasseUsager.Name = "grbxMotPasseUsager";
            this.grbxMotPasseUsager.Size = new System.Drawing.Size(272, 68);
            this.grbxMotPasseUsager.TabIndex = 4;
            this.grbxMotPasseUsager.TabStop = false;
            this.grbxMotPasseUsager.Text = "grbxMotPasseUsager";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(477, 26);
            this.textBox1.TabIndex = 0;
            // 
            // grbxLstValsDispo
            // 
            this.grbxLstValsDispo.Controls.Add(this.lstValsDispo);
            this.grbxLstValsDispo.Location = new System.Drawing.Point(320, 21);
            this.grbxLstValsDispo.Name = "grbxLstValsDispo";
            this.grbxLstValsDispo.Size = new System.Drawing.Size(242, 111);
            this.grbxLstValsDispo.TabIndex = 5;
            this.grbxLstValsDispo.TabStop = false;
            this.grbxLstValsDispo.Text = "grbxLstValsDispo";
            // 
            // lstValsDispo
            // 
            this.lstValsDispo.FormattingEnabled = true;
            this.lstValsDispo.ItemHeight = 20;
            this.lstValsDispo.Location = new System.Drawing.Point(51, 28);
            this.lstValsDispo.Name = "lstValsDispo";
            this.lstValsDispo.Size = new System.Drawing.Size(185, 64);
            this.lstValsDispo.TabIndex = 0;
            // 
            // frmAjouts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 295);
            this.Controls.Add(this.grbxLstValsDispo);
            this.Controls.Add(this.grbxMotPasseUsager);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.txtNouvelleValeur);
            this.Controls.Add(this.lblTypeAjout);
            this.Controls.Add(this.btnFermer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmAjouts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAjouts";
            this.grbxMotPasseUsager.ResumeLayout(false);
            this.grbxMotPasseUsager.PerformLayout();
            this.grbxLstValsDispo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.Label lblTypeAjout;
        private System.Windows.Forms.TextBox txtNouvelleValeur;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.GroupBox grbxMotPasseUsager;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox grbxLstValsDispo;
        private System.Windows.Forms.ListBox lstValsDispo;
    }
}