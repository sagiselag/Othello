using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    public partial class NewButton : Button
    {
        public NewButton()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (Enabled)
            {
                base.OnPaint(pe);
            }
            else
            {
                base.OnPaint(pe);
                pe.Graphics.DrawString(Text, Font, new SolidBrush(ForeColor), (Width - pe.Graphics.MeasureString(Text, Font).Width) / 2, (Height / 2) - (pe.Graphics.MeasureString(Text, Font).Height / 2));
            }
        }
    }
}
