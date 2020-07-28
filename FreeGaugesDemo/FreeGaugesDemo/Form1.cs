using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FreeGaugesDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }

    public partial class CircularGauge : Control
    {

        public int MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                _MinValue = value;
                Invalidate();
            }
        }
        public int MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                _MaxValue = value;
                Invalidate();
            }
        }
        public int Value
        {
            get
            {
                return _Value;
            }
            set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new Exception("Value must be between minimum and maximum.");
                }
                _Value = value;
                Invalidate();
            }
        }
        public Color IncrementColor
        {
            get
            {
                return _IncrementColor;
            }
            set
            {
                _IncrementColor = value;
                Invalidate();
            }
        }
        public int Increment
        {
            get
            {
                return _Increment;
            }
            set
            {
                _Increment = value;
                Invalidate();
            }
        }
        public int IncrementWidth
        {
            get
            {
                return _IncrementWidth;
            }
            set
            {
                _IncrementWidth = value;
                Invalidate();
            }
        }
        public Color NeedleColor
        {
            get
            {
                return _NeedleColor;
            }
            set
            {
                _NeedleColor = value;
                Invalidate();
            }
        }
        public int NeedleLength
        {
            get
            {
                return _NeedleLength;
            }
            set
            {
                _NeedleLength = value;
                Invalidate();
            }
        }
        public int NeedleWidth
        {
            get
            {
                return _NeedleWidth;
            }
            set
            {
                _NeedleWidth = value;
                Invalidate();
            }
        }
        public int NeedleOffset
        {
            get
            {
                return _NeedleOffset;
            }
            set
            {
                _NeedleOffset = value;
                Invalidate();
            }
        }
        public Color NeedleBaseColor
        {
            get
            {
                return _NeedleBaseColor;
            }
            set
            {
                _NeedleBaseColor = value;
                Invalidate();
            }
        }
        public int NeedleBaseWidth
        {
            get
            {
                return _NeedleBaseWidth;
            }
            set
            {
                _NeedleBaseWidth = value;
                Invalidate();
            }
        }
        public bool NeedleBaseVisible
        {
            get
            {
                return _NeedleBaseVisible;
            }
            set
            {
                _NeedleBaseVisible = value;
                Invalidate();
            }
        }
        public Color ArcColor
        {
            get
            {
                return _ArcColor;
            }
            set
            {
                _ArcColor = value;
                Invalidate();
            }
        }
        public int ArcWidth
        {
            get
            {
                return _ArcWidth;
            }
            set
            {
                _ArcWidth = value;
                Invalidate();
            }
        }
        public int ArcStartAngle
        {
            get
            {
                return _ArcStartAngle;
            }
            set
            {
                _ArcStartAngle = value;
                Invalidate();
            }
        }
        public int ArcSweepAngle
        {
            get
            {
                return _ArcSweepAngle;
            }
            set
            {
                _ArcSweepAngle = value;
                Invalidate();
            }
        }
        public Font NumberFont
        {
            get
            {
                return _NumberFont;
            }
            set
            {
                _NumberFont = value;
                Invalidate();
            }
        }
        public Color NumberColor
        {
            get
            {
                return _NumberColor;
            }
            set
            {
                _NumberColor = value;
                Invalidate();
            }
        }
        public int NumberOffset
        {
            get
            {
                return _NumberOffset;
            }
            set
            {
                _NumberOffset = value;
                Invalidate();
            }
        }


        int _MinValue = 0;
        int _MaxValue = 100;
        int _Value = 50;
        Color _IncrementColor = Color.WhiteSmoke;
        int _Increment = 5;
        int _IncrementWidth = 1;
        Color _NeedleColor = Color.MediumAquamarine;
        int _NeedleBaseWidth = 30;
        int _NeedleLength = 150;
        int _NeedleWidth = 2;
        int _NeedleOffset = -50;
        Color _NeedleBaseColor = Color.MediumAquamarine;
        bool _NeedleBaseVisible = true;
        Color _ArcColor = Color.DimGray;
        int _ArcWidth = 40;
        int _ArcStartAngle = 180;
        int _ArcSweepAngle = 180;
        Font _NumberFont = new Font("Segoe UI", 10);
        Color _NumberColor = Color.DimGray;
        int _NumberOffset = 20;


        public CircularGauge()
        {
            DoubleBuffered = true;
        }

        // Graphics
        private void DrawArc(Graphics g)
        {
            try
            {
                Rectangle arcRect = new Rectangle(ArcWidth, ArcWidth, Width - 2 * ArcWidth, Height - 2 * ArcWidth);

                g.DrawArc(new Pen(ArcColor, ArcWidth), arcRect, ArcStartAngle, ArcSweepAngle);
            }
            catch
            {

            }
        }

        private void DrawIncrementLines(Graphics g)
        {
            try
            {
                for (double i = 0; i <= MaxValue - MinValue; i += Increment)
                {
                    Rectangle arcRect = new Rectangle(ArcWidth, ArcWidth, Width - 2 * ArcWidth, Height - 2 * ArcWidth);

                    double incPercent = i / (MaxValue - MinValue);
                    double incMarkSweep = incPercent * (ArcSweepAngle);
                    double incMarkOffset = incMarkSweep + (ArcStartAngle);
                    g.DrawArc(new Pen(IncrementColor, ArcWidth), arcRect, (int)incMarkOffset - IncrementWidth / 2, IncrementWidth);
                }
            }
            catch
            {

            }
        }

        private void DrawNumbers(Graphics g)
        {
            try
            {
                for (double i = 0; i <= MaxValue - MinValue; i += Increment)
                {
                    double numPercent = i / ((double)MaxValue - (double)MinValue);
                    double angle = numPercent * ArcSweepAngle + ArcStartAngle;
                    double cosY = Math.Cos(angle * Math.PI / 180);
                    double sinY = Math.Sin(angle * Math.PI / 180);
                    double numX = cosY * (Width - ArcWidth + NumberOffset) / 2 + Width / 2;
                    double numY = sinY * (Height - ArcWidth + NumberOffset) / 2 + Height / 2;

                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    g.DrawString((i + MinValue).ToString(), NumberFont, new SolidBrush(NumberColor), (int)numX, (int)numY, stringFormat);
                }
            }
            catch
            {

            }
        }

        private void DrawNeedle(Graphics g)
        {
            try
            {
                Rectangle needleRect = new Rectangle(Width / 4 - NeedleOffset / 2, Height / 4 - NeedleOffset / 2, Width / 2 + NeedleOffset, Height / 2 + NeedleOffset);

                int midX = Width / 2;
                int midY = Height / 2;
                double needlePercent = (double)Value / ((double)MaxValue - (double)MinValue);
                double needleSweep = needlePercent * ArcSweepAngle;
                double needleOffset = needleSweep + ArcStartAngle;
                g.DrawArc(new Pen(NeedleColor, NeedleLength), needleRect, (int)needleOffset - NeedleWidth / 2, NeedleWidth);
            }
            catch
            {

            }
        }

        private void DrawNeedleBase(Graphics g)
        {
            try
            {
                Rectangle needleBaseRect = new Rectangle(Width / 2 - NeedleBaseWidth / 2, Height / 2 - NeedleBaseWidth / 2, NeedleBaseWidth, NeedleBaseWidth);
                g.FillEllipse(new SolidBrush(NeedleBaseColor), needleBaseRect.X, needleBaseRect.Y, needleBaseRect.Width, needleBaseRect.Height);
            }
            catch
            {

            }
        }

        protected override void OnPaint(PaintEventArgs p)
        {
            base.OnPaint(p);
            p.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            DrawArc(p.Graphics);
            DrawIncrementLines(p.Graphics);
            DrawNumbers(p.Graphics);
            if (NeedleBaseVisible) { DrawNeedleBase(p.Graphics); }
            DrawNeedle(p.Graphics);
        }
    }
}
