namespace otelotomasyonu
{
    partial class adminpanel
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminKayıtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otelEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odaEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.başvurularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminKayıtToolStripMenuItem,
            this.otelEkleToolStripMenuItem,
            this.odaEkleToolStripMenuItem,
            this.başvurularToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(386, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // adminKayıtToolStripMenuItem
            // 
            this.adminKayıtToolStripMenuItem.Name = "adminKayıtToolStripMenuItem";
            this.adminKayıtToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.adminKayıtToolStripMenuItem.Text = "admin kayıt";
            this.adminKayıtToolStripMenuItem.Click += new System.EventHandler(this.adminKayıtToolStripMenuItem_Click);
            // 
            // otelEkleToolStripMenuItem
            // 
            this.otelEkleToolStripMenuItem.Name = "otelEkleToolStripMenuItem";
            this.otelEkleToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.otelEkleToolStripMenuItem.Text = "otel ekle";
            this.otelEkleToolStripMenuItem.Click += new System.EventHandler(this.otelEkleToolStripMenuItem_Click);
            // 
            // odaEkleToolStripMenuItem
            // 
            this.odaEkleToolStripMenuItem.Name = "odaEkleToolStripMenuItem";
            this.odaEkleToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.odaEkleToolStripMenuItem.Text = "oda ekle";
            this.odaEkleToolStripMenuItem.Click += new System.EventHandler(this.odaEkleToolStripMenuItem_Click);
            // 
            // başvurularToolStripMenuItem
            // 
            this.başvurularToolStripMenuItem.Name = "başvurularToolStripMenuItem";
            this.başvurularToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.başvurularToolStripMenuItem.Text = "otel başvuruları";
            // 
            // adminpanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 291);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "adminpanel";
            this.Text = "adminpanel";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminKayıtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otelEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odaEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem başvurularToolStripMenuItem;
    }
}