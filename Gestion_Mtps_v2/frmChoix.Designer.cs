namespace Gestion_Mtps_v2
{
    partial class frmChoix
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
            this.grbxCategories = new System.Windows.Forms.GroupBox();
            this.lstBxCategories = new System.Windows.Forms.ListBox();
            this.btnAjoutCatego = new System.Windows.Forms.Button();
            this.grbxCategories.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFermer
            // 
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFermer.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.Location = new System.Drawing.Point(22, 314);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(909, 32);
            this.btnFermer.TabIndex = 0;
            this.btnFermer.Text = "btnFermer";
            this.btnFermer.UseVisualStyleBackColor = true;
            this.btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // 
            // grbxCategories
            // 
            this.grbxCategories.Controls.Add(this.btnAjoutCatego);
            this.grbxCategories.Controls.Add(this.lstBxCategories);
            this.grbxCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxCategories.Location = new System.Drawing.Point(12, 12);
            this.grbxCategories.Name = "grbxCategories";
            this.grbxCategories.Size = new System.Drawing.Size(293, 159);
            this.grbxCategories.TabIndex = 1;
            this.grbxCategories.TabStop = false;
            this.grbxCategories.Text = "grbxCategories";
            // 
            // lstBxCategories
            // 
            this.lstBxCategories.FormattingEnabled = true;
            this.lstBxCategories.ItemHeight = 18;
            this.lstBxCategories.Location = new System.Drawing.Point(10, 23);
            this.lstBxCategories.Name = "lstBxCategories";
            this.lstBxCategories.Size = new System.Drawing.Size(184, 130);
            this.lstBxCategories.TabIndex = 2;
            // 
            // btnAjoutCatego
            // 
            this.btnAjoutCatego.Location = new System.Drawing.Point(200, 23);
            this.btnAjoutCatego.Name = "btnAjoutCatego";
            this.btnAjoutCatego.Size = new System.Drawing.Size(87, 27);
            this.btnAjoutCatego.TabIndex = 3;
            this.btnAjoutCatego.Text = "btnAjoutCatego";
            this.btnAjoutCatego.UseVisualStyleBackColor = true;
            this.btnAjoutCatego.Click += new System.EventHandler(this.btnAjoutCatego_Click);
            // 
            // frmChoix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 358);
            this.Controls.Add(this.grbxCategories);
            this.Controls.Add(this.btnFermer);
            this.Name = "frmChoix";
            this.Text = "frmChoix";
            this.grbxCategories.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.GroupBox grbxCategories;
        private System.Windows.Forms.ListBox lstBxCategories;
        private System.Windows.Forms.Button btnAjoutCatego;
    }
}