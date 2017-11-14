namespace Moorhuhn
{
    partial class Moorhuhn
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Moorhuhn));
            this.P_Hintergrund = new System.Windows.Forms.Panel();
            this.P_Huhn_2 = new System.Windows.Forms.PictureBox();
            this.P_Huhn_1 = new System.Windows.Forms.PictureBox();
            this.P_Verfolger = new System.Windows.Forms.Panel();
            this.P_Huhn_Leben = new System.Windows.Forms.Panel();
            this.L_Punkte = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.L_Leben = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintergrundfarbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CheatBox = new System.Windows.Forms.ToolStripTextBox();
            this.optionenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.P_Hintergrund.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P_Huhn_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_Huhn_1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // P_Hintergrund
            // 
            this.P_Hintergrund.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("P_Hintergrund.BackgroundImage")));
            this.P_Hintergrund.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Hintergrund.Controls.Add(this.P_Huhn_2);
            this.P_Hintergrund.Controls.Add(this.P_Huhn_1);
            this.P_Hintergrund.Controls.Add(this.P_Verfolger);
            this.P_Hintergrund.Controls.Add(this.P_Huhn_Leben);
            this.P_Hintergrund.Controls.Add(this.L_Punkte);
            this.P_Hintergrund.Controls.Add(this.label3);
            this.P_Hintergrund.Controls.Add(this.L_Leben);
            this.P_Hintergrund.Controls.Add(this.label1);
            this.P_Hintergrund.Cursor = System.Windows.Forms.Cursors.NoMove2D;
            this.P_Hintergrund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Hintergrund.Location = new System.Drawing.Point(0, 24);
            this.P_Hintergrund.Name = "P_Hintergrund";
            this.P_Hintergrund.Size = new System.Drawing.Size(676, 463);
            this.P_Hintergrund.TabIndex = 0;
            this.P_Hintergrund.Click += new System.EventHandler(this.P_Hintergrund_Click);
            // 
            // P_Huhn_2
            // 
            this.P_Huhn_2.BackColor = System.Drawing.Color.Transparent;
            this.P_Huhn_2.Image = global::Moorhuhn.Properties.Resources.Moorhuhn_Flieg_L;
            this.P_Huhn_2.Location = new System.Drawing.Point(503, 107);
            this.P_Huhn_2.Name = "P_Huhn_2";
            this.P_Huhn_2.Size = new System.Drawing.Size(109, 101);
            this.P_Huhn_2.TabIndex = 9;
            this.P_Huhn_2.TabStop = false;
            this.P_Huhn_2.Click += new System.EventHandler(this.Huhn2_Click);
            // 
            // P_Huhn_1
            // 
            this.P_Huhn_1.BackColor = System.Drawing.Color.Transparent;
            this.P_Huhn_1.Image = global::Moorhuhn.Properties.Resources.gif11;
            this.P_Huhn_1.Location = new System.Drawing.Point(22, 234);
            this.P_Huhn_1.Name = "P_Huhn_1";
            this.P_Huhn_1.Size = new System.Drawing.Size(162, 118);
            this.P_Huhn_1.TabIndex = 8;
            this.P_Huhn_1.TabStop = false;
            this.P_Huhn_1.Click += new System.EventHandler(this.Huhn1_Click);
            // 
            // P_Verfolger
            // 
            this.P_Verfolger.BackColor = System.Drawing.Color.Red;
            this.P_Verfolger.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("P_Verfolger.BackgroundImage")));
            this.P_Verfolger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Verfolger.Location = new System.Drawing.Point(353, 197);
            this.P_Verfolger.Name = "P_Verfolger";
            this.P_Verfolger.Size = new System.Drawing.Size(51, 48);
            this.P_Verfolger.TabIndex = 7;
            this.P_Verfolger.Visible = false;
            this.P_Verfolger.Click += new System.EventHandler(this.P_Verfolger_Click);
            // 
            // P_Huhn_Leben
            // 
            this.P_Huhn_Leben.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("P_Huhn_Leben.BackgroundImage")));
            this.P_Huhn_Leben.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.P_Huhn_Leben.Location = new System.Drawing.Point(281, 391);
            this.P_Huhn_Leben.Name = "P_Huhn_Leben";
            this.P_Huhn_Leben.Size = new System.Drawing.Size(91, 79);
            this.P_Huhn_Leben.TabIndex = 6;
            this.P_Huhn_Leben.Visible = false;
            this.P_Huhn_Leben.Click += new System.EventHandler(this.P_Huhn_Leben_Click);
            // 
            // L_Punkte
            // 
            this.L_Punkte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Punkte.AutoSize = true;
            this.L_Punkte.BackColor = System.Drawing.Color.Lime;
            this.L_Punkte.Location = new System.Drawing.Point(639, 424);
            this.L_Punkte.Name = "L_Punkte";
            this.L_Punkte.Size = new System.Drawing.Size(13, 13);
            this.L_Punkte.TabIndex = 4;
            this.L_Punkte.Text = "0";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(576, 424);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Punkte";
            // 
            // L_Leben
            // 
            this.L_Leben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Leben.AutoSize = true;
            this.L_Leben.BackColor = System.Drawing.Color.Red;
            this.L_Leben.Location = new System.Drawing.Point(639, 441);
            this.L_Leben.Name = "L_Leben";
            this.L_Leben.Size = new System.Drawing.Size(13, 13);
            this.L_Leben.TabIndex = 2;
            this.L_Leben.Text = "3";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(576, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Leben";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionenToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(676, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionenToolStripMenuItem
            // 
            this.optionenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.hintergrundfarbeToolStripMenuItem,
            this.optionenToolStripMenuItem1,
            this.beendenToolStripMenuItem});
            this.optionenToolStripMenuItem.Name = "optionenToolStripMenuItem";
            this.optionenToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.optionenToolStripMenuItem.Text = "Optionen";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // hintergrundfarbeToolStripMenuItem
            // 
            this.hintergrundfarbeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheatBox});
            this.hintergrundfarbeToolStripMenuItem.Name = "hintergrundfarbeToolStripMenuItem";
            this.hintergrundfarbeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.hintergrundfarbeToolStripMenuItem.Text = "Cheat";
            // 
            // CheatBox
            // 
            this.CheatBox.ForeColor = System.Drawing.Color.White;
            this.CheatBox.Name = "CheatBox";
            this.CheatBox.Size = new System.Drawing.Size(100, 21);
            this.CheatBox.TextChanged += new System.EventHandler(this.CheatBox_TextChanged);
            // 
            // optionenToolStripMenuItem1
            // 
            this.optionenToolStripMenuItem1.Name = "optionenToolStripMenuItem1";
            this.optionenToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
            this.optionenToolStripMenuItem1.Text = "Optionen";
            this.optionenToolStripMenuItem1.Click += new System.EventHandler(this.optionenToolStripMenuItem1_Click);
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.beendenToolStripMenuItem.Text = "Beenden";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 35;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 10;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Moorhuhn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 487);
            this.Controls.Add(this.P_Hintergrund);
            this.Controls.Add(this.menuStrip1);
            this.Location = new System.Drawing.Point(500, 500);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(684, 521);
            this.MinimumSize = new System.Drawing.Size(684, 521);
            this.Name = "Moorhuhn";
            this.Text = "Moorhuhn";
            this.P_Hintergrund.ResumeLayout(false);
            this.P_Hintergrund.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.P_Huhn_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.P_Huhn_1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel P_Hintergrund;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hintergrundfarbeToolStripMenuItem;
        private System.Windows.Forms.Label L_Punkte;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_Leben;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripTextBox CheatBox;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel P_Huhn_Leben;
        private System.Windows.Forms.ToolStripMenuItem optionenToolStripMenuItem1;
        private System.Windows.Forms.Panel P_Verfolger;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.PictureBox P_Huhn_1;
        private System.Windows.Forms.PictureBox P_Huhn_2;
    }
}

