using System;
using System.Drawing;
using System.Windows.Forms;

namespace virtualJoystick
{
    public delegate void JogEventHandler(object sender, JogEventArgs e);

    public partial class virtualJoystick: UserControl
    {
        private bool is2d = true;
        private int jogRaster = 5;
        private int jogRasterMark = 0;
        private string jogText = "";
        private double[] jogValues = new double[] { 0,0.1, 0.5, 1, 5, 10, 50 };
        private Color jogColorStandby= Color.Orange;
        private Color jogColorActive= Color.Red;
        SolidBrush jogBrush;
        private SolidBrush jogBrushStandby = new SolidBrush(Color.Orange);
        private SolidBrush jogBrushActive = new SolidBrush(Color.Red);
        int jogRadius = 10;
        int jogPosX, jogPosY;
        bool jogStart = false;

        public double[] JoystickLabel
        {   get
            {   return jogValues; }
            set
            {   jogValues = value;
                makeBackgroundPicture();
            }
        }
        public bool Joystick2Dimension
        {
            get
            { return is2d; }
            set
            {
                is2d = value;
                makeBackgroundPicture();
            }
        }
        public int JoystickRaster
        {
            get
            { return jogRaster; }
            set
            {   jogRaster = value;
                makeBackgroundPicture();
            }
        }
        public int JoystickRasterMark
        {
            get
            { return jogRasterMark; }
            set
            {
                jogRasterMark = value;
                makeBackgroundPicture();
            }
        }
        public string JoystickText
        {
            get
            { return jogText; }
            set
            {
                jogText = value;
                makeBackgroundPicture();
            }
        }

        public Color JoystickActive
        {
            get
            { return jogColorActive; }
            set
            {   jogColorActive = value;
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

        private void virtualJoystick_Paint(object sender, PaintEventArgs e)
        {
            int stepX = Width / (2 * jogRaster);
            int stepY = Height/ (2 * jogRaster);
            jogRadius = stepY/2;
            if (is2d)
                e.Graphics.FillEllipse(jogBrush, new Rectangle(jogPosX - jogRadius, jogPosY - jogRadius, 2 * jogRadius, 2 * jogRadius));
            else
                e.Graphics.FillEllipse(jogBrush, new Rectangle(0, jogPosY - jogRadius, Width-2, 2 * jogRadius));
        }

        System.Drawing.Bitmap jogBackground;
        private void makeBackgroundPicture(bool border = true)                  // create background picture for control
        {
            jogBackground = new System.Drawing.Bitmap(Width,Height);
            int stepX = Width / (2 * jogRaster);
            int stepY = Height / (2 * jogRaster);
            Font stringFont = new Font("Microsoft Sans Serif", stepY - 5, GraphicsUnit.Pixel);
            SizeF stringSize = new SizeF();

            jogRadius = stepX / 2;
            Pen borderColor = new Pen(Color.Black,1);
            using (Graphics grp = Graphics.FromImage(jogBackground))
            {
                for (int i = 0; i < jogRaster; i++)
                {
                    SolidBrush bkgrColor = new SolidBrush(Color.FromArgb(255, 255, 255, i * (255 / jogRaster)));
                    if (i == (jogRaster-jogRasterMark))
                        bkgrColor = new SolidBrush(Color.FromArgb(255, 0, 255, 0));
                    int locationX = i * stepX;
                    int locationY = i * stepY;
                    int sizeX = Width - 2 * locationX;
                    int sizeY = Height -2 * locationY;
                    if (!is2d)
                    {
                        locationX = 0;
                        sizeX = Width;
                    }
                    grp.FillRectangle(bkgrColor, new Rectangle(locationX, locationY, sizeX, sizeY));
                    if (border)
                        grp.DrawRectangle(borderColor, new Rectangle(locationX, locationY, sizeX-1, sizeY-1));

                    stringSize = grp.MeasureString(jogValues[jogRaster - i].ToString(), stringFont);
                    grp.DrawString(jogValues[jogRaster-i].ToString(), stringFont, Brushes.Black, new RectangleF(locationX+ stepX / 8, locationY+ 1 , stringSize.Width, stepY));
                }
                stringFont = new Font(stringFont, FontStyle.Bold);
                stringSize = grp.MeasureString(jogText, stringFont);
                grp.DrawString(jogText, stringFont, Brushes.Black, new RectangleF(Width - stringSize.Width-3, 1, stringSize.Width, stepY));
            }
            this.BackgroundImage = jogBackground;
            this.Refresh();
        }

        private void virtualJoystick_Load(object sender, EventArgs e)
        {
            jogPosX = Width / 2;
            jogPosY = Height/ 2;
            jogBrush = jogBrushStandby;
            makeBackgroundPicture();
        }

        private void virtualJoystick_MouseDown(object sender, MouseEventArgs e)
        {
            jogPosX = jogSetlimit(e.X,Width);
            jogPosY = jogSetlimit(e.Y,Height);
            jogBrush = jogBrushActive;
            jogStart = true;
            jogTimer.Start();
            sendPositions();
            this.Refresh();
        }
        private void jogDisable()
        {   
            jogPosX = Width / 2;
            jogPosY = Height/2;
            jogBrush = jogBrushStandby;
            jogStart = false;
            jogTimer.Stop();
            this.Refresh();
        }

        private void virtualJoystick_MouseLeave(object sender, EventArgs e)
        {
            jogDisable();
        }


        private void virtualJoystick_MouseUp(object sender, MouseEventArgs e)
        {
            jogDisable();
        }

        private void virtualJoystick_MouseMove(object sender, MouseEventArgs e)
        {
            if (jogStart)
            {
                jogPosX = jogSetlimit(e.X,Width);
                jogPosY = jogSetlimit(e.Y,Height);
            }
            Refresh();
        }

        private int jogSetlimit(int jogPos,int limit)
        {
            int jogLimit = limit - jogRadius;
            if (jogPos > jogLimit) { jogPos = jogLimit; }
            if (jogPos < jogRadius) { jogPos = jogRadius; }
            return jogPos;
        }

        protected virtual void jogTimer_Tick(object sender, EventArgs e)
        {
            if (jogStart)
                sendPositions();
        }

        private void sendPositions()
        {
            OnJogTimer(new JogEventArgs(getValue(Width, jogPosX), -1*getValue(Height, jogPosY)));    // new Point(distanceX, distanceY));
        }

        private int getValue(int max,int pos)
        {
            int center = max / 2;
            int distance = pos - center;
            int value = Math.Abs(distance);
            int sign = Math.Sign(distance);
            int step = max / (2 * jogRaster);
            if (value < step / 2)
                return 0;
            int index = value / step+1;
            if (index > jogRaster)
                index = jogRaster;
            if (index < 0)
                index = 0;
            return sign * index;
        }

        public event JogEventHandler JoyStickEvent;
        private void OnJogTimer(JogEventArgs e)
        {
            if (JoyStickEvent != null)
                JoyStickEvent(this, e);
        }

        private void virtualJoystick_SizeChanged(object sender, EventArgs e)
        {
            jogPosX = Width / 2;
            jogPosY = Height / 2;
            jogBrush = jogBrushStandby;
            makeBackgroundPicture();
            this.Refresh();
        }

        public virtualJoystick()
        {
            InitializeComponent();
        }
    }

    public class JogEventArgs : EventArgs
    {
        private int jogPosX,jogPosY;
        public JogEventArgs(int posX, int posY)
        {
            this.jogPosX = posX;
            this.jogPosY = posY;
        }
        public int JogPosX
        {   get { return jogPosX; } }
        public int JogPosY
        { get { return jogPosY; } }
    }
}
