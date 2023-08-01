namespace ChronClient.GUI.Forms
{
    partial class OldOverlay
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
            this.components = new System.ComponentModel.Container();
            this.Timer_SnapToWindow = new System.Windows.Forms.Timer(this.components);
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // Timer_SnapToWindow
            // 
            this.Timer_SnapToWindow.Enabled = true;
            this.Timer_SnapToWindow.Interval = 10;
            this.Timer_SnapToWindow.Tick += new System.EventHandler(this.Timer_SnapToWindow_Tick);
            // 
            // elementHost
            // 
            this.elementHost.Location = new System.Drawing.Point(12, 12);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(776, 426);
            this.elementHost.TabIndex = 0;
            this.elementHost.Text = "elementHost1";
            this.elementHost.Child = null;
            // 
            // Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.elementHost);
            this.Name = "Overlay";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChronClient";
            this.TopMost = true;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Overlay_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer_SnapToWindow;
        private System.Windows.Forms.Integration.ElementHost elementHost;
    }
}