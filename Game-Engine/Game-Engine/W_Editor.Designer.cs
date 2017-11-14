namespace Game_Engine
{
    partial class W_Editor
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
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speicherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grösseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xPositionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TB_Grösse_X = new System.Windows.Forms.ToolStripTextBox();
            this.yToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TB_Grösse_Y = new System.Windows.Forms.ToolStripTextBox();
            this.hilfeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.P_Spielfeld = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CB_Objekt = new System.Windows.Forms.ComboBox();
            this.CB_Layer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CB_ShowallLayers = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.einstellungenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(874, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.speicherToolStripMenuItem,
            this.ladenToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.neuToolStripMenuItem_Click);
            // 
            // speicherToolStripMenuItem
            // 
            this.speicherToolStripMenuItem.Name = "speicherToolStripMenuItem";
            this.speicherToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.speicherToolStripMenuItem.Text = "Speicher";
            this.speicherToolStripMenuItem.Click += new System.EventHandler(this.speicherToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ladenToolStripMenuItem.Text = "Laden";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.ladenToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grösseToolStripMenuItem,
            this.hilfeToolStripMenuItem});
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            // 
            // grösseToolStripMenuItem
            // 
            this.grösseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xPositionToolStripMenuItem,
            this.yToolStripMenuItem});
            this.grösseToolStripMenuItem.Name = "grösseToolStripMenuItem";
            this.grösseToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.grösseToolStripMenuItem.Text = "Grösse";
            // 
            // xPositionToolStripMenuItem
            // 
            this.xPositionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TB_Grösse_X});
            this.xPositionToolStripMenuItem.Name = "xPositionToolStripMenuItem";
            this.xPositionToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.xPositionToolStripMenuItem.Text = "X";
            // 
            // TB_Grösse_X
            // 
            this.TB_Grösse_X.Name = "TB_Grösse_X";
            this.TB_Grösse_X.Size = new System.Drawing.Size(100, 21);
            this.TB_Grösse_X.Text = "50";
            // 
            // yToolStripMenuItem
            // 
            this.yToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TB_Grösse_Y});
            this.yToolStripMenuItem.Name = "yToolStripMenuItem";
            this.yToolStripMenuItem.Size = new System.Drawing.Size(91, 22);
            this.yToolStripMenuItem.Text = "Y";
            // 
            // TB_Grösse_Y
            // 
            this.TB_Grösse_Y.Name = "TB_Grösse_Y";
            this.TB_Grösse_Y.Size = new System.Drawing.Size(100, 21);
            this.TB_Grösse_Y.Text = "50";
            // 
            // hilfeToolStripMenuItem
            // 
            this.hilfeToolStripMenuItem.Name = "hilfeToolStripMenuItem";
            this.hilfeToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.hilfeToolStripMenuItem.Text = "Hilfe";
            this.hilfeToolStripMenuItem.Click += new System.EventHandler(this.hilfeToolStripMenuItem_Click);
            // 
            // P_Spielfeld
            // 
            this.P_Spielfeld.BackColor = System.Drawing.Color.Black;
            this.P_Spielfeld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Spielfeld.Location = new System.Drawing.Point(0, 24);
            this.P_Spielfeld.Name = "P_Spielfeld";
            this.P_Spielfeld.Size = new System.Drawing.Size(874, 533);
            this.P_Spielfeld.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CB_Objekt
            // 
            this.CB_Objekt.FormattingEnabled = true;
            this.CB_Objekt.Items.AddRange(new object[] {
            "Spieler",
            "KI_Nr1",
            "KI_Nr2",
            "KI_Nr3",
            "KI_Nr4",
            "KI_Nr5",
            "KI_Nr6",
            "Spawnpoint",
            "Final_Destination",
            "Blockade",
            "Lava",
            "OneUp",
            "Coin",
            "Stein",
            "Grün",
            "Blau",
            "Schwarz",
            "Löschen"});
            this.CB_Objekt.Location = new System.Drawing.Point(741, 0);
            this.CB_Objekt.Name = "CB_Objekt";
            this.CB_Objekt.Size = new System.Drawing.Size(121, 21);
            this.CB_Objekt.TabIndex = 3;
            this.CB_Objekt.Text = "Grün";
            // 
            // CB_Layer
            // 
            this.CB_Layer.FormattingEnabled = true;
            this.CB_Layer.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
            this.CB_Layer.Location = new System.Drawing.Point(702, 0);
            this.CB_Layer.Name = "CB_Layer";
            this.CB_Layer.Size = new System.Drawing.Size(33, 21);
            this.CB_Layer.TabIndex = 4;
            this.CB_Layer.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y";
            // 
            // CB_ShowallLayers
            // 
            this.CB_ShowallLayers.AutoSize = true;
            this.CB_ShowallLayers.Location = new System.Drawing.Point(494, 2);
            this.CB_ShowallLayers.Name = "CB_ShowallLayers";
            this.CB_ShowallLayers.Size = new System.Drawing.Size(100, 17);
            this.CB_ShowallLayers.TabIndex = 7;
            this.CB_ShowallLayers.Text = "Show all Layers";
            this.CB_ShowallLayers.UseVisualStyleBackColor = true;
            // 
            // W_Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 557);
            this.Controls.Add(this.CB_ShowallLayers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_Layer);
            this.Controls.Add(this.CB_Objekt);
            this.Controls.Add(this.P_Spielfeld);
            this.Controls.Add(this.menuStrip1);
            this.Name = "W_Editor";
            this.Text = "Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speicherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.Panel P_Spielfeld;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grösseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xPositionToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox TB_Grösse_X;
        private System.Windows.Forms.ToolStripMenuItem yToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox TB_Grösse_Y;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox CB_Objekt;
        private System.Windows.Forms.ComboBox CB_Layer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox CB_ShowallLayers;
        private System.Windows.Forms.ToolStripMenuItem hilfeToolStripMenuItem;

    }
}