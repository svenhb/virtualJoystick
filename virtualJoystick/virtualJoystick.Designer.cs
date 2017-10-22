namespace virtualJoystick
{
    partial class virtualJoystick
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.jogTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // jogTimer
            // 
            this.jogTimer.Interval = 500;
            this.jogTimer.Tick += new System.EventHandler(this.jogTimer_Tick);
            // 
            // virtualJoystick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(25, 100);
            this.Name = "virtualJoystick";
            this.Load += new System.EventHandler(this.virtualJoystick_Load);
            this.SizeChanged += new System.EventHandler(this.virtualJoystick_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.virtualJoystick_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.virtualJoystick_MouseDown);
            this.MouseLeave += new System.EventHandler(this.virtualJoystick_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.virtualJoystick_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.virtualJoystick_MouseUp);
            this.Resize += new System.EventHandler(this.virtualJoystick_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer jogTimer;
    }
}
