namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.beendenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Hintergrund_1 = new System.Windows.Forms.TabPage();
            this.n_geschwindikeit_1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.n_winkel_1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.B_New_1 = new System.Windows.Forms.Button();
            this.Hintergrund_2 = new System.Windows.Forms.TabPage();
            this.n_grösse = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.n_geschwindikeit_2 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.B_New_2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.n_Timer = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Hintergrund_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_geschwindikeit_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_winkel_1)).BeginInit();
            this.Hintergrund_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_grösse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_geschwindikeit_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_Timer)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.beendenToolStripMenuItem,
            this.beendenToolStripMenuItem1});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // beendenToolStripMenuItem
            // 
            this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
            this.beendenToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.beendenToolStripMenuItem.Text = "Neustart";
            this.beendenToolStripMenuItem.Click += new System.EventHandler(this.neustartToolStripMenuItem_Click);
            // 
            // beendenToolStripMenuItem1
            // 
            this.beendenToolStripMenuItem1.Name = "beendenToolStripMenuItem1";
            this.beendenToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
            this.beendenToolStripMenuItem1.Text = "Beenden";
            this.beendenToolStripMenuItem1.Click += new System.EventHandler(this.beendenToolStripMenuItem1_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hilfeToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Hintergrund_1);
            this.tabControl1.Controls.Add(this.Hintergrund_2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(832, 566);
            this.tabControl1.TabIndex = 1;
            // 
            // Hintergrund_1
            // 
            this.Hintergrund_1.Controls.Add(this.n_geschwindikeit_1);
            this.Hintergrund_1.Controls.Add(this.label4);
            this.Hintergrund_1.Controls.Add(this.n_winkel_1);
            this.Hintergrund_1.Controls.Add(this.label3);
            this.Hintergrund_1.Controls.Add(this.B_New_1);
            this.Hintergrund_1.Location = new System.Drawing.Point(4, 22);
            this.Hintergrund_1.Name = "Hintergrund_1";
            this.Hintergrund_1.Padding = new System.Windows.Forms.Padding(3);
            this.Hintergrund_1.Size = new System.Drawing.Size(824, 540);
            this.Hintergrund_1.TabIndex = 0;
            this.Hintergrund_1.Text = "Mausverfolgung";
            this.Hintergrund_1.UseVisualStyleBackColor = true;
            // 
            // n_geschwindikeit_1
            // 
            this.n_geschwindikeit_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.n_geschwindikeit_1.Location = new System.Drawing.Point(64, 512);
            this.n_geschwindikeit_1.Name = "n_geschwindikeit_1";
            this.n_geschwindikeit_1.Size = new System.Drawing.Size(37, 20);
            this.n_geschwindikeit_1.TabIndex = 14;
            this.n_geschwindikeit_1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(107, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Geschwindikeit";
            // 
            // n_winkel_1
            // 
            this.n_winkel_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.n_winkel_1.Location = new System.Drawing.Point(64, 486);
            this.n_winkel_1.Name = "n_winkel_1";
            this.n_winkel_1.Size = new System.Drawing.Size(37, 20);
            this.n_winkel_1.TabIndex = 15;
            this.n_winkel_1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(107, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Wendikeit";
            // 
            // B_New_1
            // 
            this.B_New_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_New_1.Location = new System.Drawing.Point(8, 486);
            this.B_New_1.Name = "B_New_1";
            this.B_New_1.Size = new System.Drawing.Size(50, 46);
            this.B_New_1.TabIndex = 1;
            this.B_New_1.Text = "New";
            this.B_New_1.UseVisualStyleBackColor = true;
            this.B_New_1.Click += new System.EventHandler(this.B_New_1_Click);
            // 
            // Hintergrund_2
            // 
            this.Hintergrund_2.Controls.Add(this.n_grösse);
            this.Hintergrund_2.Controls.Add(this.label2);
            this.Hintergrund_2.Controls.Add(this.n_geschwindikeit_2);
            this.Hintergrund_2.Controls.Add(this.label1);
            this.Hintergrund_2.Controls.Add(this.B_New_2);
            this.Hintergrund_2.Location = new System.Drawing.Point(4, 22);
            this.Hintergrund_2.Name = "Hintergrund_2";
            this.Hintergrund_2.Padding = new System.Windows.Forms.Padding(3);
            this.Hintergrund_2.Size = new System.Drawing.Size(824, 540);
            this.Hintergrund_2.TabIndex = 1;
            this.Hintergrund_2.Text = "Freiefahrt";
            this.Hintergrund_2.UseVisualStyleBackColor = true;
            // 
            // n_grösse
            // 
            this.n_grösse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.n_grösse.Location = new System.Drawing.Point(64, 486);
            this.n_grösse.Name = "n_grösse";
            this.n_grösse.Size = new System.Drawing.Size(37, 20);
            this.n_grösse.TabIndex = 21;
            this.n_grösse.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(107, 493);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Grösse";
            // 
            // n_geschwindikeit_2
            // 
            this.n_geschwindikeit_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.n_geschwindikeit_2.Location = new System.Drawing.Point(64, 512);
            this.n_geschwindikeit_2.Name = "n_geschwindikeit_2";
            this.n_geschwindikeit_2.Size = new System.Drawing.Size(37, 20);
            this.n_geschwindikeit_2.TabIndex = 19;
            this.n_geschwindikeit_2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(107, 519);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Geschwindikeit";
            // 
            // B_New_2
            // 
            this.B_New_2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_New_2.Location = new System.Drawing.Point(8, 482);
            this.B_New_2.Name = "B_New_2";
            this.B_New_2.Size = new System.Drawing.Size(50, 50);
            this.B_New_2.TabIndex = 0;
            this.B_New_2.Text = "New";
            this.B_New_2.UseVisualStyleBackColor = true;
            this.B_New_2.Click += new System.EventHandler(this.B_New_2_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(723, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Timer";
            // 
            // n_Timer
            // 
            this.n_Timer.Location = new System.Drawing.Point(762, 2);
            this.n_Timer.Name = "n_Timer";
            this.n_Timer.Size = new System.Drawing.Size(68, 20);
            this.n_Timer.TabIndex = 3;
            this.n_Timer.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.n_Timer.ValueChanged += new System.EventHandler(this.n_Timer_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 590);
            this.Controls.Add(this.n_Timer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Vektorprogramme";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Hintergrund_1.ResumeLayout(false);
            this.Hintergrund_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_geschwindikeit_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_winkel_1)).EndInit();
            this.Hintergrund_2.ResumeLayout(false);
            this.Hintergrund_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.n_grösse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_geschwindikeit_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_Timer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Hintergrund_1;
        private System.Windows.Forms.TabPage Hintergrund_2;
        private System.Windows.Forms.Button B_New_2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown n_geschwindikeit_1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown n_winkel_1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button B_New_1;
        private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem1;
        private System.Windows.Forms.NumericUpDown n_geschwindikeit_2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown n_grösse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown n_Timer;

    }
}

