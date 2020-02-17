using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team2_RealTimeMonitor
{
    public partial class CircleProgressBar : Control
    {

        public enum _ProgressShape
        {
            Round,
            Flat
        }

        #region 전역변수    
        private long _Value;
        private long _Maximum = 100;
        private Color _ProgressColor1 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor2 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor3 = Color.FromArgb(92, 92, 92);
        private Color _ProgressColor4 = Color.FromArgb(92, 92, 92);


        private _ProgressShape ProgressShapeVal;
        #endregion

        #region 프로퍼티
        public long Value
        {
            get { return _Value; }
            set
            {
                if (value > _Maximum)
                    value = _Maximum;
                _Value = value;
                Invalidate();
            }
        }

        public long Maximum
        {
            get { return _Maximum; }
            set
            {
                if (value < 1)
                    value = 1;
                _Maximum = value;
                Invalidate();
            }
        }

        public Color ProgressColor1
        {
            get { return _ProgressColor1; }
            set
            {
                _ProgressColor1 = value;
                Invalidate();
            }
        }

        public Color ProgressColor2
        {
            get { return _ProgressColor2; }
            set
            {
                _ProgressColor2 = value;
                Invalidate();
            }
        }

        public Color ProgressColor3
        {
            get { return _ProgressColor3; }
            set
            {
                _ProgressColor3 = value;
                Invalidate();
            }
        }

        public Color ProgressColor4
        {
            get { return _ProgressColor4; }
            set
            {
                _ProgressColor4 = value;
                Invalidate();
            }
        }

        public _ProgressShape ProgressShape
        {
            get { return ProgressShapeVal; }
            set
            {
                ProgressShapeVal = value;
                Invalidate();
            }
        }
        #endregion

        #region 이벤트
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            SetStandardSize();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            SetStandardSize();
        }

        protected override void OnPaintBackground(PaintEventArgs p)
        {
            base.OnPaintBackground(p);
        }
        #endregion


        public CircleProgressBar()
        {
            InitializeComponent();
        }

        private void SetStandardSize()
        {
            int _Size = Math.Max(Width, Height);
            Size = new Size(_Size, _Size);
        }

        public void Increment(int Val)
        {
            this._Value = Val;
            Invalidate();
        }

        public void Decrement(int Val)
        {
            this._Value -= Val;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.Clear(this.BackColor);
                    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor3, this._ProgressColor4, LinearGradientMode.ForwardDiagonal))
                    {
                        using (Pen pen = new Pen(brush, 14f))
                        {
                            switch (this.ProgressShapeVal)
                            {
                                case _ProgressShape.Round:
                                    pen.StartCap = LineCap.Round;
                                    pen.EndCap = LineCap.Round;
                                    break;

                                case _ProgressShape.Flat:
                                    pen.StartCap = LineCap.Flat;
                                    pen.EndCap = LineCap.Flat;
                                    break;
                            }
                            graphics.DrawArc(pen, 0x12, 0x12, (this.Width - 0x23) - 2, (this.Height - 0x23) - 2, -90, (int)Math.Round((double)((360.0 / ((double)this._Maximum)) * this._Value)));
                        }
                    }
                    using (LinearGradientBrush brush2 = new LinearGradientBrush(this.ClientRectangle, this._ProgressColor1, this._ProgressColor2, LinearGradientMode.Vertical))
                    {
                        graphics.FillEllipse(brush2, 0x18, 0x18, (this.Width - 0x30) - 1, (this.Height - 0x30) - 1);
                    }
                    SizeF MS = graphics.MeasureString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font);
                    graphics.DrawString(Convert.ToString(Convert.ToInt32((100 / _Maximum) * _Value)), Font, Brushes.White, Convert.ToInt32(Width / 2 - MS.Width / 2), Convert.ToInt32(Height / 2 - MS.Height / 2));
                    e.Graphics.DrawImage(bitmap, 0, 0);
                    graphics.Dispose();
                    bitmap.Dispose();
                }
            }
        }
    }
}