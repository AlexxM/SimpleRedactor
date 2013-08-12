using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageManipulation
{
    class DrawEllipse : DrawPrimitive
    {
        public override void Render(Graphics g)
        {
            //Graphics g = Graphics.FromImage(b);

            int x, y, width, height;

            base.DefDescribedRectangle(out x,out y,out width, out height);

            g.DrawEllipse(base.setPen,x,y,width,height);

        }
    }
}
