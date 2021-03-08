using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PersonalFolder {
    [DefaultEvent("Click")]
    class SystemIconButton : Control {
        private Image icon;
        public SystemIconButton () {
            Width = 20;
            Height = 20;
            BackColor = Color.White;
        }

        private bool isHovered = false;
        protected override void OnMouseEnter (EventArgs e) {
            isHovered = true;
            Refresh();

            if (Text.Length > 0) {
                new ToolTip().Show(Text, Form.ActiveForm, 8 + Location.X, 32 + Location.Y + Size.Height, 1200);
            }
        }

        protected override void OnMouseLeave (EventArgs e) {
            isHovered = false;
            Refresh();
        }

        private bool isPressed = false;
        protected override void OnMouseDown (MouseEventArgs e) {
            isPressed = true;
            Refresh();
        }

        public new event EventHandler Click = (sender, e) => { };
        protected override void OnMouseUp (MouseEventArgs e) {
            if (isPressed) {
                Click(this, e);
            }

            isPressed = false;
            Refresh();
        }

        private static Pen BORDER_HOVER_PEN = new Pen(Color.FromArgb(64, 0, 64, 160));
        private static Brush BACK_HOVER_BRUSH = new SolidBrush(Color.FromArgb(32, 0, 64, 160));
        private static Pen BORDER_PRESSED_PEN = new Pen(Color.FromArgb(72, 0, 64, 160));
        private static Brush BACK_PRESSED_BRUSH = new SolidBrush(Color.FromArgb(46, 0, 64, 160));
        protected override void OnPaint (PaintEventArgs e) {
            if (isPressed) {
                e.Graphics.FillRectangle(BACK_PRESSED_BRUSH, e.ClipRectangle);
                e.Graphics.DrawLine(BORDER_PRESSED_PEN, e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Right - 1, e.ClipRectangle.Top);
                e.Graphics.DrawLine(BORDER_PRESSED_PEN, e.ClipRectangle.Right - 1, e.ClipRectangle.Top, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1);
                e.Graphics.DrawLine(BORDER_PRESSED_PEN, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1, e.ClipRectangle.Left, e.ClipRectangle.Bottom - 1);
                e.Graphics.DrawLine(BORDER_PRESSED_PEN, e.ClipRectangle.Left, e.ClipRectangle.Bottom - 1, e.ClipRectangle.Left, e.ClipRectangle.Top);
            } else if (isHovered) {
                e.Graphics.FillRectangle(BACK_HOVER_BRUSH, e.ClipRectangle);
                e.Graphics.DrawLine(BORDER_HOVER_PEN, e.ClipRectangle.Left,      e.ClipRectangle.Top,        e.ClipRectangle.Right - 1, e.ClipRectangle.Top);
                e.Graphics.DrawLine(BORDER_HOVER_PEN, e.ClipRectangle.Right - 1, e.ClipRectangle.Top,        e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1);
                e.Graphics.DrawLine(BORDER_HOVER_PEN, e.ClipRectangle.Right - 1, e.ClipRectangle.Bottom - 1, e.ClipRectangle.Left,      e.ClipRectangle.Bottom - 1);
                e.Graphics.DrawLine(BORDER_HOVER_PEN, e.ClipRectangle.Left,      e.ClipRectangle.Bottom - 1, e.ClipRectangle.Left,      e.ClipRectangle.Top);
            }

            var tmpIcon = Enabled ? icon : Utils.GrayscaleImage(icon, 1.5f);
            e.Graphics.DrawImage(tmpIcon, e.ClipRectangle.X + 2, e.ClipRectangle.Y + (isPressed ? 3 : 2));
        }

        [Category("Параметры"), Description("Изображение кнопки")]
        public Image Icon {
            get { return icon; }
            set { icon = (Image) value.Clone(); UpdateIcon(); }
        }

        private RotateFlipType rotation;
        [Category("Параметры"), Description("Изменить изображение"), DefaultValue(RotateFlipType.RotateNoneFlipNone)]
        public RotateFlipType Rotation {
            get { return rotation; }
            set { rotation = value; UpdateIcon(); }
        }

        public void UpdateIcon () {
            if (icon == null) return;
            icon.RotateFlip(rotation);
        }

        protected override void OnEnabledChanged (EventArgs e) {
            base.OnEnabledChanged(e);
            Refresh();
        }
    }
}
