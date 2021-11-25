using gyakorlat007.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyakorlat007.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }

        //ctor
        public Ball(Color color)
        {
            BallColor = new SolidBrush(color);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }

        //protected override void DrawImage(Graphics g)
        //{
        //    g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        //}

        //public SolidBrush WrapColor { get; private set; }
        //public SolidBrush RibbonColor { get; private set; }
        //public Present(Color color1, Color color2)
        //{
        //    WrapColor = new SolidBrush(color1);
        //    RibbonColor = new SolidBrush(color2);

        //}
        //protected override void DrawImage(Graphics g)
        //{
        //    g.FillRectangle(WrapColor, 0, 0, Width, Height);
        //    g.FillRectangle(RibbonColor, 0, Height / 5 * 2, Width, Height / 5);
        //    g.FillRectangle(RibbonColor, Width / 5 * 2, 0, Width / 5, Height);
        //}
    }
}
