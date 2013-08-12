using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageManipulation
{
    class DrawLine : DrawPrimitive
    {

        public override void Render(Graphics g)
        {
            //Graphics g = Graphics.FromImage(b);
            g.DrawLine(setPen, startPoint, endPoint);
 
        }
        
    }
}
