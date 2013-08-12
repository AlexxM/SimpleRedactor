using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageManipulation
{

    public enum DrawMode
    {
        Line,
        Point,
        Rectangle,
        Ellipse,
        CropImage

    }

    abstract class DrawPrimitive
    {
        public Pen setPen;

        public Point startPoint;

        public Point endPoint;
        
        public abstract void Render(Graphics g);

        public virtual void Scale(double scale)
        {

            startPoint.X = (int)(Math.Round(startPoint.X * scale));
            startPoint.Y = (int)(Math.Round(startPoint.Y * scale));

            endPoint.X = (int)(Math.Round(endPoint.X * scale));
            endPoint.Y = (int)(Math.Round(endPoint.Y * scale));
        
        }

        protected void DefDescribedRectangle(out int x, out int y, out int width, out int height)
        {
            if (startPoint.X > endPoint.X)
            {
                x = endPoint.X;
                width = startPoint.X - endPoint.X;
            }
            else
            {
                x = startPoint.X;
                width = endPoint.X - startPoint.X;

            }

            if (startPoint.Y > endPoint.Y)
            {
                y = endPoint.Y;
                height = startPoint.Y - endPoint.Y;

            }
            else
            {
                y = startPoint.Y;
                height = endPoint.Y - startPoint.Y;

            }
        
        
        }

    }
}
