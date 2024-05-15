namespace AppServer
{
    partial class Form1
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
            this.JournalPanel = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // JournalPanel
            // 
            this.JournalPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.JournalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JournalPanel.Location = new System.Drawing.Point(0, 0);
            this.JournalPanel.Margin = new System.Windows.Forms.Padding(4);
            this.JournalPanel.Multiline = true;
            this.JournalPanel.Name = "JournalPanel";
            this.JournalPanel.ReadOnly = true;
            this.JournalPanel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.JournalPanel.Size = new System.Drawing.Size(572, 440);
            this.JournalPanel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 440);
            this.Controls.Add(this.JournalPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task App Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox JournalPanel;
    }
}

