using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageManipulation
{
    class GetImage
    {
        public int maxMiniatureHeight;

        public int maxMiniatureWidth;

        public GetImage(){}

        public GetImage(int maxWidth, int maxHeight)
        {
            this.maxMiniatureHeight = maxHeight;
            this.maxMiniatureWidth = maxWidth;
        
        }
        
        public Bitmap getMiniature(string imgPath)
        {


            Bitmap b, newb;



            b = new Bitmap(imgPath);


            Size newSize = defineMiniatureSize(b.Size);


            newb = new Bitmap(b, new Size(newSize.Width, newSize.Height));
            newb.Tag = imgPath;
            b.Dispose();


            return newb;

        }

        public Size defineMiniatureSize(Size s)
        {

            float width, height;
            float k;
            if (s.Height > this.maxMiniatureHeight  && s.Height>=s.Width)
            {
                k = this.maxMiniatureHeight / (float)s.Height;
                height = this.maxMiniatureHeight;
                width = k * s.Width;
            }
            else if (s.Width > this.maxMiniatureWidth)
            {
                k = this.maxMiniatureWidth / (float)s.Width;
                width = this.maxMiniatureWidth;
                height = k * s.Height;

            }
            else
            {
                width = s.Width;
                height = s.Height;

            }

            return new Size((int)width, (int)height);


        }


    }
}
