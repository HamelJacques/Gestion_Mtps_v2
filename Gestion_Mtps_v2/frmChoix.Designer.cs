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
            this.btnAjoutCatego = new System.Windows.Forms.Button();
            this.lstBxCategories = new System.Windows.Forms.ListBox();
            this.grbxSousCategories = new System.Windows.Forms.GroupBox();
            this.btnAjoutSousCatego = new System.Windows.Forms.Button();
            this.lstBxSousCategories = new System.Windows.Forms.ListBox();
            this.grbxSites = new System.Windows.Forms.GroupBox();
            this.btnAjoutSite = new System.Windows.Forms.Button();
            this.lstBxSites = new System.Windows.Forms.ListBox();
            this.grbxInfosSites = new System.Windows.Forms.GroupBox();
            this.dgInfos = new System.Windows.Forms.DataGridView();
            this.btnAjoutInfos = new System.Windows.Forms.Button();
            this.grbxCategories.SuspendLayout();
            this.grbxSousCategories.SuspendLayout();
            this.grbxSites.SuspendLayout();
            this.grbxInfosSites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFermer
            // 
            this.btnFermer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFermer.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFermer.Location = new System.Drawing.Point(22, 403);
            this.btnFermer.Name = "btnFermer";
            this.btnFermer.Size = new System.Drawing.Size(870, 32);
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
            // btnAjoutCatego
            // 
            this.btnAjoutCatego.Location = new System.Drawing.Point(200, 23);
            this.btnAjoutCatego.Name = "btnAjoutCatego";
            this.btnAjoutCatego.Size = new System.Drawing.Size(87, 38);
            this.btnAjoutCatego.TabIndex = 3;
            this.btnAjoutCatego.Text = "btnAjoutCatego";
            this.btnAjoutCatego.UseVisualStyleBackColor = true;
            this.btnAjoutCatego.Click += new System.EventHandler(this.btnAjoutCatego_Click);
            // 
            // lstBxCategories
            // 
            this.lstBxCategories.FormattingEnabled = true;
            this.lstBxCategories.ItemHeight = 18;
            this.lstBxCategories.Location = new System.Drawing.Point(10, 23);
            this.lstBxCategories.Name = "lstBxCategories";
            this.lstBxCategories.Size = new System.Drawing.Size(184, 94);
            this.lstBxCategories.TabIndex = 2;
            this.lstBxCategories.Click += new System.EventHandler(this.lstBxCategories_Click);
            // 
            // grbxSousCategories
            // 
            this.grbxSousCategories.Controls.Add(this.btnAjoutSousCatego);
            this.grbxSousCategories.Controls.Add(this.lstBxSousCategories);
            this.grbxSousCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxSousCategories.Location = new System.Drawing.Point(311, 12);
            this.grbxSousCategories.Name = "grbxSousCategories";
            this.grbxSousCategories.Size = new System.Drawing.Size(293, 159);
            this.grbxSousCategories.TabIndex = 2;
            this.grbxSousCategories.TabStop = false;
            this.grbxSousCategories.Text = "grbxSousCategories";
            // 
            // btnAjoutSousCatego
            // 
            this.btnAjoutSousCatego.Location = new System.Drawing.Point(200, 23);
            this.btnAjoutSousCatego.Name = "btnAjoutSousCatego";
            this.btnAjoutSousCatego.Size = new System.Drawing.Size(87, 38);
            this.btnAjoutSousCatego.TabIndex = 3;
            this.btnAjoutSousCatego.Text = "btnAjoutSousCatego";
            this.btnAjoutSousCatego.UseVisualStyleBackColor = true;
            this.btnAjoutSousCatego.Click += new System.EventHandler(this.btnAjoutSousCatego_Click);
            // 
            // lstBxSousCategories
            // 
            this.lstBxSousCategories.FormattingEnabled = true;
            this.lstBxSousCategories.ItemHeight = 18;
            this.lstBxSousCategories.Location = new System.Drawing.Point(10, 23);
            this.lstBxSousCategories.Name = "lstBxSousCategories";
            this.lstBxSousCategories.Size = new System.Drawing.Size(184, 94);
            this.lstBxSousCategories.TabIndex = 2;
            this.lstBxSousCategories.Click += new System.EventHandler(this.lstBxSousCategories_Click);
            // 
            // grbxSites
            // 
            this.grbxSites.Controls.Add(this.btnAjoutSite);
            this.grbxSites.Controls.Add(this.lstBxSites);
            this.grbxSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxSites.Location = new System.Drawing.Point(610, 12);
            this.grbxSites.Name = "grbxSites";
            this.grbxSites.Size = new System.Drawing.Size(293, 159);
            this.grbxSites.TabIndex = 4;
            this.grbxSites.TabStop = false;
            this.grbxSites.Text = "grbxSites";
            // 
            // btnAjoutSite
            // 
            this.btnAjoutSite.Location = new System.Drawing.Point(200, 23);
            this.btnAjoutSite.Name = "btnAjoutSite";
            this.btnAjoutSite.Size = new System.Drawing.Size(87, 38);
            this.btnAjoutSite.TabIndex = 3;
            this.btnAjoutSite.Text = "btnAjoutSite";
            this.btnAjoutSite.UseVisualStyleBackColor = true;
            this.btnAjoutSite.Click += new System.EventHandler(this.btnAjoutSite_Click);
            // 
            // lstBxSites
            // 
            this.lstBxSites.FormattingEnabled = true;
            this.lstBxSites.ItemHeight = 18;
            this.lstBxSites.Location = new System.Drawing.Point(10, 23);
            this.lstBxSites.Name = "lstBxSites";
            this.lstBxSites.Size = new System.Drawing.Size(184, 94);
            this.lstBxSites.TabIndex = 2;
            this.lstBxSites.Click += new System.EventHandler(this.lstBxSites_Click);
            // 
            // grbxInfosSites
            // 
            this.grbxInfosSites.Controls.Add(this.dgInfos);
            this.grbxInfosSites.Controls.Add(this.btnAjoutInfos);
            this.grbxInfosSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbxInfosSites.Location = new System.Drawing.Point(12, 177);
            this.grbxInfosSites.Name = "grbxInfosSites";
            this.grbxInfosSites.Size = new System.Drawing.Size(891, 120);
            this.grbxInfosSites.TabIndex = 5;
            this.grbxInfosSites.TabStop = false;
            this.grbxInfosSites.Text = "grbxInfosSites";
            // 
            // dgInfos
            // 
            this.dgInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgInfos.Location = new System.Drawing.Point(113, 11);
            this.dgInfos.Name = "dgInfos";
            this.dgInfos.Size = new System.Drawing.Size(767, 103);
            this.dgInfos.TabIndex = 1;
            // 
            // btnAjoutInfos
            // 
            this.btnAjoutInfos.Location = new System.Drawing.Point(6, 30);
            this.btnAjoutInfos.Name = "btnAjoutInfos";
            this.btnAjoutInfos.Size = new System.Drawing.Size(79, 29);
            this.btnAjoutInfos.TabIndex = 0;
            this.btnAjoutInfos.Text = "btnAjoutInfos";
            this.btnAjoutInfos.UseVisualStyleBackColor = true;
            this.btnAjoutInfos.Click += new System.EventHandler(this.btnAjoutInfos_Click);
            // 
            // frmChoix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 447);
            this.Controls.Add(this.grbxInfosSites);
            this.Controls.Add(this.grbxSites);
            this.Controls.Add(this.grbxSousCategories);
            this.Controls.Add(this.grbxCategories);
            this.Controls.Add(this.btnFermer);
            this.Name = "frmChoix";
            this.Text = "frmChoix";
            this.grbxCategories.ResumeLayout(false);
            this.grbxSousCategories.ResumeLayout(false);
            this.grbxSites.ResumeLayout(false);
            this.grbxInfosSites.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInfos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFermer;
        private System.Windows.Forms.GroupBox grbxCategories;
        private System.Windows.Forms.ListBox lstBxCategories;
        private System.Windows.Forms.Button btnAjoutCatego;
        private System.Windows.Forms.GroupBox grbxSousCategories;
        private System.Windows.Forms.Button btnAjoutSousCatego;
        private System.Windows.Forms.ListBox lstBxSousCategories;
        private System.Windows.Forms.GroupBox grbxSites;
        private System.Windows.Forms.Button btnAjoutSite;
        private System.Windows.Forms.ListBox lstBxSites;
        private System.Windows.Forms.GroupBox grbxInfosSites;
        private System.Windows.Forms.Button btnAjoutInfos;
        private System.Windows.Forms.DataGridView dgInfos;
    }
}