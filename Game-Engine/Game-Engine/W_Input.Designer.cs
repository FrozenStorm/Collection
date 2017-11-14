namespace Game_Engine
{
    partial class W_Input
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
            this.B_M_Right = new System.Windows.Forms.Button();
            this.B_M_Left = new System.Windows.Forms.Button();
            this.B_Space = new System.Windows.Forms.Button();
            this.B_Up = new System.Windows.Forms.Button();
            this.B_Left = new System.Windows.Forms.Button();
            this.B_Down = new System.Windows.Forms.Button();
            this.B_Right = new System.Windows.Forms.Button();
            this.T_Update = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.L_X_Position = new System.Windows.Forms.Label();
            this.L_Y_Position = new System.Windows.Forms.Label();
            this.B_Control = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // B_M_Right
            // 
            this.B_M_Right.Location = new System.Drawing.Point(94, 3);
            this.B_M_Right.Name = "B_M_Right";
            this.B_M_Right.Size = new System.Drawing.Size(63, 98);
            this.B_M_Right.TabIndex = 13;
            this.B_M_Right.Text = "Right";
            this.B_M_Right.UseVisualStyleBackColor = true;
            // 
            // B_M_Left
            // 
            this.B_M_Left.Location = new System.Drawing.Point(3, 3);
            this.B_M_Left.Name = "B_M_Left";
            this.B_M_Left.Size = new System.Drawing.Size(63, 98);
            this.B_M_Left.TabIndex = 12;
            this.B_M_Left.Text = "Left";
            this.B_M_Left.UseVisualStyleBackColor = true;
            // 
            // B_Space
            // 
            this.B_Space.Location = new System.Drawing.Point(86, 181);
            this.B_Space.Name = "B_Space";
            this.B_Space.Size = new System.Drawing.Size(189, 23);
            this.B_Space.TabIndex = 11;
            this.B_Space.Text = "Space";
            this.B_Space.UseVisualStyleBackColor = true;
            // 
            // B_Up
            // 
            this.B_Up.Location = new System.Drawing.Point(357, 151);
            this.B_Up.Name = "B_Up";
            this.B_Up.Size = new System.Drawing.Size(47, 23);
            this.B_Up.TabIndex = 10;
            this.B_Up.Text = "Up";
            this.B_Up.UseVisualStyleBackColor = true;
            // 
            // B_Left
            // 
            this.B_Left.Location = new System.Drawing.Point(304, 180);
            this.B_Left.Name = "B_Left";
            this.B_Left.Size = new System.Drawing.Size(47, 23);
            this.B_Left.TabIndex = 9;
            this.B_Left.Text = "Left";
            this.B_Left.UseVisualStyleBackColor = true;
            // 
            // B_Down
            // 
            this.B_Down.Location = new System.Drawing.Point(357, 180);
            this.B_Down.Name = "B_Down";
            this.B_Down.Size = new System.Drawing.Size(47, 23);
            this.B_Down.TabIndex = 8;
            this.B_Down.Text = "Down";
            this.B_Down.UseVisualStyleBackColor = true;
            // 
            // B_Right
            // 
            this.B_Right.Location = new System.Drawing.Point(410, 180);
            this.B_Right.Name = "B_Right";
            this.B_Right.Size = new System.Drawing.Size(47, 23);
            this.B_Right.TabIndex = 7;
            this.B_Right.Text = "Right";
            this.B_Right.UseVisualStyleBackColor = true;
            // 
            // T_Update
            // 
            this.T_Update.Enabled = true;
            this.T_Update.Interval = 10;
            this.T_Update.Tick += new System.EventHandler(this.T_Update_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.B_M_Left);
            this.panel1.Controls.Add(this.B_M_Right);
            this.panel1.Location = new System.Drawing.Point(519, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(160, 286);
            this.panel1.TabIndex = 14;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DimGray;
            this.panel2.Location = new System.Drawing.Point(595, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 122);
            this.panel2.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.B_Control);
            this.panel3.Controls.Add(this.B_Space);
            this.panel3.Controls.Add(this.B_Right);
            this.panel3.Controls.Add(this.B_Down);
            this.panel3.Controls.Add(this.B_Left);
            this.panel3.Controls.Add(this.B_Up);
            this.panel3.Location = new System.Drawing.Point(12, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(491, 220);
            this.panel3.TabIndex = 16;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DimGray;
            this.panel4.Location = new System.Drawing.Point(257, -1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 108);
            this.panel4.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(535, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "X-Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Y-Position";
            // 
            // L_X_Position
            // 
            this.L_X_Position.AutoSize = true;
            this.L_X_Position.Location = new System.Drawing.Point(554, 102);
            this.L_X_Position.Name = "L_X_Position";
            this.L_X_Position.Size = new System.Drawing.Size(13, 13);
            this.L_X_Position.TabIndex = 20;
            this.L_X_Position.Text = "0";
            // 
            // L_Y_Position
            // 
            this.L_Y_Position.AutoSize = true;
            this.L_Y_Position.Location = new System.Drawing.Point(611, 102);
            this.L_Y_Position.Name = "L_Y_Position";
            this.L_Y_Position.Size = new System.Drawing.Size(13, 13);
            this.L_Y_Position.TabIndex = 21;
            this.L_Y_Position.Text = "0";
            // 
            // B_Control
            // 
            this.B_Control.Location = new System.Drawing.Point(14, 181);
            this.B_Control.Name = "B_Control";
            this.B_Control.Size = new System.Drawing.Size(51, 23);
            this.B_Control.TabIndex = 12;
            this.B_Control.Text = "Control";
            this.B_Control.UseVisualStyleBackColor = true;
            // 
            // W_Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 413);
            this.Controls.Add(this.L_Y_Position);
            this.Controls.Add(this.L_X_Position);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "W_Input";
            this.Text = "W_Input";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_M_Right;
        private System.Windows.Forms.Button B_M_Left;
        private System.Windows.Forms.Button B_Space;
        private System.Windows.Forms.Button B_Up;
        private System.Windows.Forms.Button B_Left;
        private System.Windows.Forms.Button B_Down;
        private System.Windows.Forms.Button B_Right;
        private System.Windows.Forms.Timer T_Update;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label L_X_Position;
        private System.Windows.Forms.Label L_Y_Position;
        private System.Windows.Forms.Button B_Control;
    }
}