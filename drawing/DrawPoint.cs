using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
namespace ImageManipulation
{
    class DrawPoint : DrawPrimitive
    {

        public DrawPoint()
            : base()
        {
            
           
        
        }

        public override void Render(Graphics g)
        {
           
            
            g.FillEllipse(setPen.Brush, startPoint.X - (int)setPen.Width, startPoint.Y - (int)setPen.Width, (int)setPen.Width, (int)setPen.Width);
           // g.Dispose();
        }

        public override void Scale(double scale)
        {
            if (startPoint == null)
                throw new Exception("Точка не определена");
            
            this.startPoint.X = (int)Math.Round(scale*this.startPoint.X);
            this.startPoint.Y = (int)Math.Round(scale*this.startPoint.Y);
        }
    }
}
