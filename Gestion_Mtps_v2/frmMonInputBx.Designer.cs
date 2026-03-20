namespace Gestion_Mtps_v2
{
    partial class frmMonInputBx
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
            this.lblMessInput = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnSoumettre = new System.Windows.Forms.Button();
            this.txtAncienmps = new System.Windows.Forms.TextBox();
            this.lblAncienmps = new System.Windows.Forms.Label();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessInput
            // 
            this.lblMessInput.AutoSize = true;
            this.lblMessInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessInput.Location = new System.Drawing.Point(25, 53);
            this.lblMessInput.Name = "lblMessInput";
            this.lblMessInput.Size = new System.Drawing.Size(122, 25);
            this.lblMessInput.TabIndex = 0;
            this.lblMessInput.Text = "lblMessInput";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(192, 53);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(437, 30);
            this.txtInput.TabIndex = 1;
            // 
            // btnSoumettre
            // 
            this.btnSoumettre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSoumettre.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSoumettre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoumettre.Location = new System.Drawing.Point(15, 97);
            this.btnSoumettre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSoumettre.Name = "btnSoumettre";
            this.btnSoumettre.Size = new System.Drawing.Size(761, 50);
            this.btnSoumettre.TabIndex = 2;
            this.btnSoumettre.Text = "btnSoumettre";
            this.btnSoumettre.UseVisualStyleBackColor = true;
            this.btnSoumettre.Click += new System.EventHandler(this.btnSoumettre_Click);
            // 
            // txtAncienmps
            // 
            this.txtAncienmps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAncienmps.Location = new System.Drawing.Point(192, 16);
            this.txtAncienmps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAncienmps.Name = "txtAncienmps";
            this.txtAncienmps.Size = new System.Drawing.Size(437, 30);
            this.txtAncienmps.TabIndex = 4;
            this.txtAncienmps.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAncienmps_KeyPress);
            // 
            // lblAncienmps
            // 
            this.lblAncienmps.AutoSize = true;
            this.lblAncienmps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAncienmps.Location = new System.Drawing.Point(25, 16);
            this.lblAncienmps.Name = "lblAncienmps";
            this.lblAncienmps.Size = new System.Drawing.Size(129, 25);
            this.lblAncienmps.TabIndex = 3;
            this.lblAncienmps.Text = "lblAncienmps";
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnuler.Location = new System.Drawing.Point(15, 153);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(761, 50);
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.Text = "btnAnnuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // frmMonInputBx
            // 
            this.AcceptButton = this.btnSoumettre;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 209);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.txtAncienmps);
            this.Controls.Add(this.lblAncienmps);
            this.Controls.Add(this.btnSoumettre);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblMessInput);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMonInputBx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMonInputBx";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSoumettre;
        private System.Windows.Forms.TextBox txtAncienmps;
        private System.Windows.Forms.Label lblAncienmps;
        private System.Windows.Forms.Button btnAnnuler;
    }
}