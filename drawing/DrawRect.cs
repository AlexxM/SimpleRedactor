using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageManipulation
{
    class DrawRect : DrawPrimitive
    {
        
        public override void Render(Graphics g)
        {
            
            int x,y,width,height;

            base.DefDescribedRectangle(out x,out y,out width,out height);

            g.DrawRectangle(base.setPen, new Rectangle(x, y,width, height));
            
        }

    }
}
