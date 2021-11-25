using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gyakorlat007.Abstractions
{
    public abstract class Toy : Label
    {
        public Toy()
        {
            AutoSize = false;
            Width = 50;
            Height = Width;
            Paint += Toy_Paint;
        }

        private void Toy_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        protected abstract void DrawImage(Graphics g);

        public virtual void MoveToy()
        {
            Left += 1;
        }
    }
}
