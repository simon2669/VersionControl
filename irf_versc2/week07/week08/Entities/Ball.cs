using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week08.Entities
{
    class Ball : Label
    {
        public Ball()
        {
            this.AutoSize = false;
            this.Height = 50;
            this.Width = 50;
            this.Paint += Ball_Paint;
        }

        protected void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), 0, 0, Width, Height);
        }

        private void Ball_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }
        public void MoveBall()
        {
            Left += 1;
        }
    }
}
