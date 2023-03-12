using System;
using System.Drawing;
using System.Windows.Forms;

/*
 * 2023-03-10 add choice of real buttons
 * 2023-03-12 avoid move-command on right-click for context-menu
*/
namespace virtualJoystick
{
    public delegate void JogEventHandler(object sender, JogEventArgs e);

    public partial class virtualJoystick : UserControl
    {
        private bool is2d = true;
        private int jogRaster = 5;
        private int jogRasterMark = 0;
        private string jogText = "";
        private double[] jogValues = new double[] { 0, 0.1, 0.5, 1, 5, 10, 50 };
        private Color jogColorStandby = Color.Orange;
        private Color jogColorActive = Color.Red;
		private System.Drawing.Bitmap jogBackground = new System.Drawing.Bitmap(10, 10);
        private SolidBrush jogBrush;
        private SolidBrush jogBrushStandby = new SolidBrush(Color.Orange);
        private SolidBrush jogBrushActive = new SolidBrush(Color.Red);
        private int jogRadius = 10;
        private int jogPosX, jogPosY;
        private bool jogStart = false;

		// button specific - will be enabled via jogRaster = 1
		private bool useClassicButtons = false;
        private int BtnPosX=0, BtnPosY=0;
        private int BtnIndex = 5;
        private bool showStop = true;	// show stop button
        private readonly Image arrow_r = Properties.Resources.a_r;		// arrow to the right
        private readonly Image arrow_d = Properties.Resources.a_d;		// arrow to upper-right
        private readonly Color CBtnDisabled = SystemColors.Control;
		private readonly Color CBtnHighlight = Color.Yellow;

        public virtualJoystick()
        {
            InitializeComponent();
            SetButtonImages();
		}

		#region properties
        public double[] JoystickLabel
        {
            get
            { return jogValues; }
            set
            {
                jogValues = value;
                SetToolStripText();
                MakeBackgroundPicture();
            }
        }
        public bool Joystick2Dimension
        {
            get
            { return is2d; }
            set
            {
                is2d = value;
                MakeBackgroundPicture();
            }
        }
        public int JoystickRaster
        {
            get
            { return jogRaster; }
            set
            {
                jogRaster = value;
				useClassicButtons = (jogRaster == 1);
                MakeBackgroundPicture();
            }
        }
        public int JoystickRasterMark
        {
            get
            { return jogRasterMark; }
            set
            {
                jogRasterMark = value;
                MakeBackgroundPicture();
            }
        }
        public string JoystickText
        {
            get
            { return jogText; }
            set
            {
                jogText = value;
                MakeBackgroundPicture();
            }
        }

        public Color JoystickActive
        {
            get
            { return jogColorActive; }
            set
            {
                jogColorActive = value;
                jogBrushActive = new SolidBrush(jogColorActive);
            }
        }
        public Color JoystickStanby
        {
            get
            { return jogColorStandby; }
            set
            {
                jogColorStandby = value;
                jogBrushStandby = new SolidBrush(jogColorStandby);
            }
        }
        public bool ShowStop
        {
            get
            { return showStop; }
            set
            {
                showStop = value;
                MakeBackgroundPicture();
            }
        }
		#endregion
		
		#region events

        private void VirtualJoystick_Load(object sender, EventArgs e)
        {
            jogPosX = Width / 2;
            jogPosY = Height / 2;
            jogBrush = jogBrushStandby;
            MakeBackgroundPicture();
            SetToolStripText();
            Tsmi5.Checked = true;
        }
		
        private void VirtualJoystick_Paint(object sender, PaintEventArgs e)
        {
            if (!useClassicButtons)	//jogRaster > 1)
            {
                int stepY = Height / (2 * jogRaster);
                jogRadius = stepY / 2;
                if (is2d)
                    e.Graphics.FillEllipse(jogBrush, new Rectangle(jogPosX - jogRadius, jogPosY - jogRadius, 2 * jogRadius, 2 * jogRadius));
                else
                    e.Graphics.FillEllipse(jogBrush, new Rectangle(0, jogPosY - jogRadius, Width - 2, 2 * jogRadius));
            }
        }

        private void VirtualJoystick_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!useClassicButtons) //jogRaster > 1)
                {
                    jogPosX = JogSetlimit(e.X, Width);
                    jogPosY = JogSetlimit(e.Y, Height);
                    jogBrush = jogBrushActive;
                    SendPositions();
                }
                else
                { FindButtonSetStep(sender); }
                jogStart = true;
                jogTimer.Start();
                this.Refresh();
            }
        }

        private void VirtualJoystick_MouseLeave(object sender, EventArgs e)
        {
            JogDisable();
            this.Focus();
        }

        private void VirtualJoystick_MouseUp(object sender, MouseEventArgs e)
        {
            JogDisable();
        }

        private void VirtualJoystick_MouseMove(object sender, MouseEventArgs e)
        {
            if (jogStart)
            {
                jogPosX = JogSetlimit(e.X, Width);
                jogPosY = JogSetlimit(e.Y, Height);
            }
            Refresh();
        }

        private void VirtualJoystick_SizeChanged(object sender, EventArgs e)
        {
            if (!useClassicButtons)	//jogRaster > 1)
            {
                jogPosX = Width / 2;
                jogPosY = Height / 2;
                jogBrush = jogBrushStandby;
                MakeBackgroundPicture();
            }
            else
            {
                int x = Width / 3;
                int BtnWidth = x - 4;
                int y = Height / 3;
                int BtnHeight = y - 4;
                string s = jogValues[BtnIndex].ToString();
                if (is2d)
                {
                    Btn1.Left = Btn4.Left = Btn7.Left = 2;
                    Btn2.Left = Btn5.Left = Btn8.Left = x + 2;
                    Btn3.Left = Btn6.Left = Btn9.Left = 2 * x + 2;
                    toolTip1.SetToolTip(Btn1, "X-" + s + ";Y" + s);
                    toolTip1.SetToolTip(Btn2, "X0;Y" + s);
                    toolTip1.SetToolTip(Btn3, "X" + s + ";Y" + s);
                    toolTip1.SetToolTip(Btn4, "X-" + s + ";Y0");
                    toolTip1.SetToolTip(Btn5, "Stop");
                    toolTip1.SetToolTip(Btn6, "X" + s + ";Y0");
                    toolTip1.SetToolTip(Btn7, "X-" + s + ";Y-" + s);
                    toolTip1.SetToolTip(Btn8, "X0;Y-" + s);
                    toolTip1.SetToolTip(Btn9, "X" + s + ";Y-" + s);
                }
                else
                {
                    Btn2.Left = Btn5.Left = Btn8.Left = 1;
                    BtnWidth = Width - 2;
                    toolTip1.SetToolTip(Btn2, jogText + jogValues[BtnIndex].ToString());
                    toolTip1.SetToolTip(Btn8, jogText + "-" + jogValues[BtnIndex].ToString());
                }
                Btn1.Top = Btn2.Top = Btn3.Top = 2;
                Btn4.Top = Btn5.Top = Btn6.Top = y + 2;
                Btn7.Top = Btn8.Top = Btn9.Top = 2 * y + 2;
                Btn1.Width = Btn2.Width = Btn3.Width = Btn4.Width = Btn5.Width = Btn6.Width = Btn7.Width = Btn8.Width = Btn9.Width = BtnWidth;
                Btn1.Height = Btn2.Height = Btn3.Height = Btn4.Height = Btn5.Height = Btn6.Height = Btn7.Height = Btn8.Height = Btn9.Height = BtnHeight;

                //    Btn2.Text = jogText;
            }
            this.Refresh();
        }

        private void VirtualJoystick_EnabledChanged(object sender, EventArgs e)
		{	SetEnabledApperance();}

        protected virtual void JogTimer_Tick(object sender, EventArgs e)
        {
            if (jogStart)
            {
                if (!useClassicButtons)	//jogRaster > 1)
                { SendPositions(); }
                else 
                { OnJogTimer(new JogEventArgs(BtnPosX, BtnPosY)); }
            }
        }
		
		private void Btn_Click(object sender, EventArgs e)
        {            //FindButtonSetStep(sender);
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            HighlightButton(sender, true);
            var btn = (Button)sender;
            btn.Focus();
        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            HighlightButton(sender, false);
            Btn5.Focus();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tsmi1.Checked = Tsmi2.Checked = Tsmi3.Checked = Tsmi4.Checked = Tsmi5.Checked = false;
            if (sender == Tsmi1) { BtnIndex = 1; Tsmi1.Checked = true; }
            if (sender == Tsmi2) { BtnIndex = 2; Tsmi2.Checked = true; }
            if (sender == Tsmi3) { BtnIndex = 3; Tsmi3.Checked = true; }
            if (sender == Tsmi4) { BtnIndex = 4; Tsmi4.Checked = true; }
            if (sender == Tsmi5) { BtnIndex = 5; Tsmi5.Checked = true; }
        }

		#endregion
		
        private void SendPositions()
        {
            OnJogTimer(new JogEventArgs(GetValue(Width, jogPosX), -1 * GetValue(Height, jogPosY)));    // new Point(distanceX, distanceY));
        }

        public event JogEventHandler JoyStickEvent;
        private void OnJogTimer(JogEventArgs e)
        {
            if (JoyStickEvent != null)
                JoyStickEvent(this, e);
        }

		
        private void MakeBackgroundPicture(bool border = true)                  // create background picture for control
        {
			if (useClassicButtons)
            {
                this.BackgroundImage = null;
                EnableButton(true);
				this.Refresh();
				return;
			}			
				
			jogBackground = new System.Drawing.Bitmap(Width, Height);
			int stepX = Width / (2 * jogRaster);
			int stepY = Height / (2 * jogRaster);
			Font stringFont = new Font("Microsoft Sans Serif", stepY - 5, GraphicsUnit.Pixel);
			SizeF stringSize;// = new SizeF();

	
			EnableButton(false);
			jogRadius = stepX / 2;
			Pen borderColor = new Pen(Color.Black, 1);
			using (Graphics grp = Graphics.FromImage(jogBackground))
			{
				for (int i = 0; i < jogRaster; i++)
				{
					SolidBrush bkgrColor = new SolidBrush(Color.FromArgb(255, 255, 255, i * (255 / jogRaster)));
					if (i == (jogRaster - jogRasterMark))
						bkgrColor = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
					int locationX = i * stepX;
					int locationY = i * stepY;
					int sizeX = Width - 2 * locationX;
					int sizeY = Height - 2 * locationY;
					if (!is2d)
					{
						locationX = 0;
						sizeX = Width;
					}
					grp.FillRectangle(bkgrColor, new Rectangle(locationX, locationY, sizeX, sizeY));
					if (border)
						grp.DrawRectangle(borderColor, new Rectangle(locationX, locationY, sizeX - 1, sizeY - 1));

					stringSize = grp.MeasureString(jogValues[jogRaster - i].ToString(), stringFont);
					grp.DrawString(jogValues[jogRaster - i].ToString(), stringFont, Brushes.Black, new RectangleF(locationX + stepX / 8, locationY + 1, stringSize.Width, stepY));
				}
				stringFont = new Font(stringFont, FontStyle.Bold);
				stringSize = grp.MeasureString(jogText, stringFont);
				grp.DrawString(jogText, stringFont, Brushes.Black, new RectangleF(Width - stringSize.Width - 3, 1, stringSize.Width, stepY));
			}
			SetEnabledApperance();

            this.Refresh();
        }


        private void JogDisable()
        {
			jogPosX = Width / 2;
			jogPosY = Height / 2;
			jogBrush = jogBrushStandby;
            jogStart = false;
            jogTimer.Stop();
            this.Refresh();
        }


        private int JogSetlimit(int jogPos, int limit)
        {
            int jogLimit = limit - jogRadius;
            if (jogPos > jogLimit) { jogPos = jogLimit; }
            if (jogPos < jogRadius) { jogPos = jogRadius; }
            return jogPos;
        }


        private int GetValue(int max, int pos)
        {
            int center = max / 2;
            int distance = pos - center;
            int value = Math.Abs(distance);
            int sign = Math.Sign(distance);
            int step = max / (2 * jogRaster);
            if (value < step / 2)
                return 0;
            int index = value / step + 1;
            if (index > jogRaster)
                index = jogRaster;
            if (index < 0)
                index = 0;
            return sign * index;
        }

		
		private void SetEnabledApperance()
        {
            if (!useClassicButtons)	//jogRaster > 1)
            {
                if (this.Enabled)
                { this.BackgroundImage = jogBackground; }
                else
                {
                    this.EnabledChanged -= VirtualJoystick_EnabledChanged;
                    this.Enabled = true;
                    this.BackgroundImage = BitmapSetToGray((Image)jogBackground.Clone());
                    this.Invalidate();
                    this.Enabled = false;
                    this.EnabledChanged += VirtualJoystick_EnabledChanged;
                }
            }
            else
            { SetButtonImages(); }
        }

        private void SetButtonImages()
		{
			Image tmp_r = (Image)arrow_r.Clone();
            Image tmp_d = (Image)arrow_d.Clone();
            bool ControlEnabled = this.Enabled;
            if (!ControlEnabled)
            {
                this.EnabledChanged -= VirtualJoystick_EnabledChanged;
                this.Enabled = true;
                tmp_r = BitmapReplaceColor(tmp_r, CBtnDisabled);
                tmp_d = BitmapReplaceColor(tmp_d, CBtnDisabled);
            }

            Btn6.BackgroundImage = (Image)tmp_r.Clone();
            Btn8.BackgroundImage = (Image)tmp_r.Clone(); Btn8.BackgroundImage.RotateFlip((RotateFlipType.Rotate90FlipNone));
            Btn4.BackgroundImage = (Image)tmp_r.Clone(); Btn4.BackgroundImage.RotateFlip((RotateFlipType.Rotate180FlipNone));
            Btn2.BackgroundImage = (Image)tmp_r.Clone(); Btn2.BackgroundImage.RotateFlip((RotateFlipType.Rotate270FlipNone));

            Btn3.BackgroundImage = (Image)tmp_d.Clone();
            Btn9.BackgroundImage = (Image)tmp_d.Clone(); Btn9.BackgroundImage.RotateFlip((RotateFlipType.Rotate90FlipNone));
            Btn7.BackgroundImage = (Image)tmp_d.Clone(); Btn7.BackgroundImage.RotateFlip((RotateFlipType.Rotate180FlipNone));
            Btn1.BackgroundImage = (Image)tmp_d.Clone(); Btn1.BackgroundImage.RotateFlip((RotateFlipType.Rotate270FlipNone));

            tmp_r = Properties.Resources.stop;
        //    if (!this.Enabled)
        //    { tmp_r = BitmapReplaceColor(tmp_r, Cdisabled); }
            Btn5.BackgroundImage = tmp_r;   // Properties.Resources.stop;
                    this.Invalidate();

            if (!ControlEnabled)
            {
                this.Enabled = false;
                this.EnabledChanged += VirtualJoystick_EnabledChanged;
            }
        }

        private void FindButtonSetStep(object sender)
        {
            bool btnPressed=false;
            if (sender == Btn1) { BtnPosX = -BtnIndex; BtnPosY = BtnIndex; btnPressed = true; }     // OnJogTimer(new JogEventArgs(-BtnIndex, BtnIndex));
            if (sender == Btn2) { BtnPosX = 0; BtnPosY = BtnIndex; btnPressed = true; }     //OnJogTimer(new JogEventArgs(0, BtnIndex));
            if (sender == Btn3) { BtnPosX = BtnIndex; BtnPosY = BtnIndex; btnPressed = true; }     //OnJogTimer(new JogEventArgs(BtnIndex, BtnIndex));
            if (sender == Btn4) { BtnPosX = -BtnIndex; BtnPosY = 0; btnPressed = true; }     //OnJogTimer(new JogEventArgs(-BtnIndex, 0));
            if (sender == Btn5) { BtnPosX = 0; BtnPosY = 0; btnPressed = true; }     //OnJogTimer(new JogEventArgs(0, 0));
            if (sender == Btn6) { BtnPosX = BtnIndex; BtnPosY = 0; btnPressed = true; }     //OnJogTimer(new JogEventArgs(BtnIndex, 0));
            if (sender == Btn7) { BtnPosX = -BtnIndex; BtnPosY = -BtnIndex; btnPressed = true; }     //OnJogTimer(new JogEventArgs(-BtnIndex, -BtnIndex));
            if (sender == Btn8) { BtnPosX = 0; BtnPosY = -BtnIndex; btnPressed = true; }     //OnJogTimer(new JogEventArgs(0, -BtnIndex));
            if (sender == Btn9) { BtnPosX = BtnIndex; BtnPosY = -BtnIndex; btnPressed = true; }     // OnJogTimer(new JogEventArgs(BtnIndex, -BtnIndex));

            if (btnPressed)
                OnJogTimer(new JogEventArgs(BtnPosX, BtnPosY));
        }

        private void EnableButton(bool enable)
        {
            Btn2.Visible = Btn5.Visible = Btn8.Visible = enable;
            if (!showStop)
                Btn5.Visible = false;
            if (!is2d)
                enable = false;
            Btn1.Visible = Btn4.Visible = Btn7.Visible = enable;
            Btn3.Visible = Btn6.Visible = Btn9.Visible = enable;
        }

        private void HighlightButton(object sender, bool highlight)
        {
            if (highlight)
            {   ((Button)sender).BackColor = CBtnHighlight;}
            else
            {   ((Button)sender).ResetBackColor();		//BackColor = CBtnNormal;
				((Button)sender).UseVisualStyleBackColor = true;
			}
        }

        private void SetToolStripText()
        {
            Tsmi1.Text = string.Format("{0,3:###.##}", jogValues[1]);
            Tsmi2.Text = string.Format("{0,3:###.##}", jogValues[2]);
            Tsmi3.Text = string.Format("{0,3:###.##}", jogValues[3]);
            Tsmi4.Text = string.Format("{0,3:###.##}", jogValues[4]);
            Tsmi5.Text = string.Format("{0,3:###.##}", jogValues[5]);
        }
		
		public Image BitmapReplaceColor(Image BmpI, Color cnew)
		{
            Bitmap Bmp = new Bitmap(BmpI);
			int centerX=Bmp.Width/2;
			int centerY=Bmp.Height/2;
			Color cold = Bmp.GetPixel(centerX, centerY);
			
			for (int y = 0; y < Bmp.Height; y++)
			for (int x = 0; x < Bmp.Width; x++)
			{
				if (Bmp.GetPixel(x, y) == cold)
				{	Bmp.SetPixel(x, y, cnew);}
			}
            return Bmp;
		}

        public Image BitmapSetToGray(Image BmpI)
		{
            Bitmap Bmp = new Bitmap(BmpI);
            int rgb;
			Color c;
			
			for (int y = 0; y < Bmp.Height; y++)
			for (int x = 0; x < Bmp.Width; x++)
			{
				c = Bmp.GetPixel(x, y);
				rgb = (int)Math.Round(.299 * c.R + .587 * c.G + .114 * c.B);
				Bmp.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));						
			}
            return Bmp;
        }
    }

    public class JogEventArgs : EventArgs
    {
        private readonly int jogPosX, jogPosY;
        public JogEventArgs(int posX, int posY)
        {
            this.jogPosX = posX;
            this.jogPosY = posY;
        }
        public int JogPosX
        { get { return jogPosX; } }
        public int JogPosY
        { get { return jogPosY; } }
    }
}
