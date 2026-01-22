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
            this.SuspendLayout();
            // 
            // lblMessInput
            // 
            this.lblMessInput.AutoSize = true;
            this.lblMessInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessInput.Location = new System.Drawing.Point(25, 30);
            this.lblMessInput.Name = "lblMessInput";
            this.lblMessInput.Size = new System.Drawing.Size(122, 25);
            this.lblMessInput.TabIndex = 0;
            this.lblMessInput.Text = "lblMessInput";
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(192, 30);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(437, 30);
            this.txtInput.TabIndex = 1;
            // 
            // btnSoumettre
            // 
            this.btnSoumettre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSoumettre.Location = new System.Drawing.Point(192, 96);
            this.btnSoumettre.Name = "btnSoumettre";
            this.btnSoumettre.Size = new System.Drawing.Size(164, 32);
            this.btnSoumettre.TabIndex = 2;
            this.btnSoumettre.Text = "btnSoumettre";
            this.btnSoumettre.UseVisualStyleBackColor = true;
            this.btnSoumettre.Click += new System.EventHandler(this.btnSoumettre_Click);
            // 
            // frmMonInputBx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 209);
            this.Controls.Add(this.btnSoumettre);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblMessInput);
            this.Name = "frmMonInputBx";
            this.Text = "frmMonInputBx";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessInput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnSoumettre;
    }
}