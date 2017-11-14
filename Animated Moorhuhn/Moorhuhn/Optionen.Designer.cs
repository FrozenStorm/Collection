namespace Moorhuhn
{
    partial class Optionen
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
            this.L_Schwirikeitsgrad = new System.Windows.Forms.Label();
            this.CB_Schwirikeitsgrad = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // L_Schwirikeitsgrad
            // 
            this.L_Schwirikeitsgrad.AutoSize = true;
            this.L_Schwirikeitsgrad.Location = new System.Drawing.Point(12, 27);
            this.L_Schwirikeitsgrad.Name = "L_Schwirikeitsgrad";
            this.L_Schwirikeitsgrad.Size = new System.Drawing.Size(84, 13);
            this.L_Schwirikeitsgrad.TabIndex = 0;
            this.L_Schwirikeitsgrad.Text = "Schwirikeitsgrad";
            // 
            // CB_Schwirikeitsgrad
            // 
            this.CB_Schwirikeitsgrad.FormattingEnabled = true;
            this.CB_Schwirikeitsgrad.Items.AddRange(new object[] {
            "Leicht",
            "Mittel",
            "Schwer",
            "Ultra"});
            this.CB_Schwirikeitsgrad.Location = new System.Drawing.Point(141, 24);
            this.CB_Schwirikeitsgrad.Name = "CB_Schwirikeitsgrad";
            this.CB_Schwirikeitsgrad.Size = new System.Drawing.Size(121, 21);
            this.CB_Schwirikeitsgrad.TabIndex = 1;
            // 
            // Optionen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 78);
            this.Controls.Add(this.CB_Schwirikeitsgrad);
            this.Controls.Add(this.L_Schwirikeitsgrad);
            this.Name = "Optionen";
            this.Text = "Optionen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Schwirikeitsgrad;
        private System.Windows.Forms.ComboBox CB_Schwirikeitsgrad;
    }
}