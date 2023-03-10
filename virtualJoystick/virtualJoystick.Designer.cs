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
            this.Btn1 = new System.Windows.Forms.Button();
            this.CMSIndex = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Tsmi5 = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.Btn6 = new System.Windows.Forms.Button();
            this.Btn5 = new System.Windows.Forms.Button();
            this.Btn4 = new System.Windows.Forms.Button();
            this.Btn9 = new System.Windows.Forms.Button();
            this.Btn8 = new System.Windows.Forms.Button();
            this.Btn7 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CMSIndex.SuspendLayout();
            this.SuspendLayout();
            // 
            // jogTimer
            // 
            this.jogTimer.Interval = 500;
            this.jogTimer.Tick += new System.EventHandler(this.JogTimer_Tick);
            // 
            // Btn1
            // 
            this.Btn1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn1.ContextMenuStrip = this.CMSIndex;
            this.Btn1.Location = new System.Drawing.Point(5, 5);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(40, 40);
            this.Btn1.TabIndex = 0;
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.Click += new System.EventHandler(this.Btn_Click);
            this.Btn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn1.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn1.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // CMSIndex
            // 
            this.CMSIndex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsmi5,
            this.Tsmi4,
            this.Tsmi3,
            this.Tsmi2,
            this.Tsmi1});
            this.CMSIndex.Name = "CMSIndex";
            this.CMSIndex.Size = new System.Drawing.Size(81, 114);
            this.CMSIndex.Text = "Step size";
            // 
            // Tsmi5
            // 
            this.Tsmi5.Name = "Tsmi5";
            this.Tsmi5.Size = new System.Drawing.Size(80, 22);
            this.Tsmi5.Text = "5";
            this.Tsmi5.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Tsmi4
            // 
            this.Tsmi4.Name = "Tsmi4";
            this.Tsmi4.Size = new System.Drawing.Size(80, 22);
            this.Tsmi4.Text = "4";
            this.Tsmi4.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Tsmi3
            // 
            this.Tsmi3.Name = "Tsmi3";
            this.Tsmi3.Size = new System.Drawing.Size(80, 22);
            this.Tsmi3.Text = "3";
            this.Tsmi3.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Tsmi2
            // 
            this.Tsmi2.Name = "Tsmi2";
            this.Tsmi2.Size = new System.Drawing.Size(80, 22);
            this.Tsmi2.Text = "2";
            this.Tsmi2.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Tsmi1
            // 
            this.Tsmi1.CheckOnClick = true;
            this.Tsmi1.Name = "Tsmi1";
            this.Tsmi1.Size = new System.Drawing.Size(80, 22);
            this.Tsmi1.Text = "1";
            this.Tsmi1.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Btn2
            // 
            this.Btn2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn2.ContextMenuStrip = this.CMSIndex;
            this.Btn2.Location = new System.Drawing.Point(55, 5);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(40, 40);
            this.Btn2.TabIndex = 1;
            this.Btn2.UseVisualStyleBackColor = true;
            this.Btn2.Click += new System.EventHandler(this.Btn_Click);
            this.Btn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn2.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn2.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // Btn3
            // 
            this.Btn3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn3.ContextMenuStrip = this.CMSIndex;
            this.Btn3.Location = new System.Drawing.Point(105, 5);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(40, 40);
            this.Btn3.TabIndex = 2;
            this.Btn3.UseVisualStyleBackColor = true;
            this.Btn3.Click += new System.EventHandler(this.Btn_Click);
            this.Btn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn3.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn3.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // Btn6
            // 
            this.Btn6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn6.ContextMenuStrip = this.CMSIndex;
            this.Btn6.Location = new System.Drawing.Point(105, 55);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(40, 40);
            this.Btn6.TabIndex = 5;
            this.Btn6.UseVisualStyleBackColor = true;
            this.Btn6.Click += new System.EventHandler(this.Btn_Click);
            this.Btn6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn6.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn6.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // Btn5
            // 
            this.Btn5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn5.ContextMenuStrip = this.CMSIndex;
            this.Btn5.Location = new System.Drawing.Point(55, 55);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(40, 40);
            this.Btn5.TabIndex = 4;
            this.Btn5.UseVisualStyleBackColor = true;
            this.Btn5.Click += new System.EventHandler(this.Btn_Click);
            this.Btn5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn5.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn5.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // Btn4
            // 
            this.Btn4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn4.ContextMenuStrip = this.CMSIndex;
            this.Btn4.Location = new System.Drawing.Point(5, 55);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(40, 40);
            this.Btn4.TabIndex = 3;
            this.Btn4.UseVisualStyleBackColor = true;
            this.Btn4.Click += new System.EventHandler(this.Btn_Click);
            this.Btn4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn4.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn4.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // Btn9
            // 
            this.Btn9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn9.ContextMenuStrip = this.CMSIndex;
            this.Btn9.Location = new System.Drawing.Point(105, 105);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(40, 40);
            this.Btn9.TabIndex = 8;
            this.Btn9.UseVisualStyleBackColor = true;
            this.Btn9.Click += new System.EventHandler(this.Btn_Click);
            this.Btn9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn9.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn9.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // Btn8
            // 
            this.Btn8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn8.ContextMenuStrip = this.CMSIndex;
            this.Btn8.Location = new System.Drawing.Point(55, 105);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(40, 40);
            this.Btn8.TabIndex = 7;
            this.Btn8.UseVisualStyleBackColor = true;
            this.Btn8.Click += new System.EventHandler(this.Btn_Click);
            this.Btn8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn8.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn8.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // Btn7
            // 
            this.Btn7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn7.ContextMenuStrip = this.CMSIndex;
            this.Btn7.Location = new System.Drawing.Point(5, 105);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(40, 40);
            this.Btn7.TabIndex = 6;
            this.Btn7.UseVisualStyleBackColor = true;
            this.Btn7.Click += new System.EventHandler(this.Btn_Click);
            this.Btn7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.Btn7.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Btn7.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            this.Btn7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            // 
            // virtualJoystick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn9);
            this.Controls.Add(this.Btn8);
            this.Controls.Add(this.Btn7);
            this.Controls.Add(this.Btn6);
            this.Controls.Add(this.Btn5);
            this.Controls.Add(this.Btn4);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn1);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(400, 400);
            this.MinimumSize = new System.Drawing.Size(25, 100);
            this.Name = "virtualJoystick";
            this.Load += new System.EventHandler(this.VirtualJoystick_Load);
            this.EnabledChanged += new System.EventHandler(this.VirtualJoystick_EnabledChanged);
            this.SizeChanged += new System.EventHandler(this.VirtualJoystick_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VirtualJoystick_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseDown);
            this.MouseLeave += new System.EventHandler(this.VirtualJoystick_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.VirtualJoystick_MouseUp);
            this.Resize += new System.EventHandler(this.VirtualJoystick_SizeChanged);
            this.CMSIndex.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer jogTimer;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.Button Btn6;
        private System.Windows.Forms.Button Btn5;
        private System.Windows.Forms.Button Btn4;
        private System.Windows.Forms.Button Btn9;
        private System.Windows.Forms.Button Btn8;
        private System.Windows.Forms.Button Btn7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip CMSIndex;
        private System.Windows.Forms.ToolStripMenuItem Tsmi1;
        private System.Windows.Forms.ToolStripMenuItem Tsmi2;
        private System.Windows.Forms.ToolStripMenuItem Tsmi3;
        private System.Windows.Forms.ToolStripMenuItem Tsmi4;
        private System.Windows.Forms.ToolStripMenuItem Tsmi5;
    }
}
