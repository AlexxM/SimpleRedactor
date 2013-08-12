using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ImageManipulation
{
    
    public enum PixelTransformation
    {
        grayScale,
        modBrightness,
        modContrast
    }
    
    
    abstract class PixelTransform
    {

        public static Bitmap savedBitmap;

        protected Color[,] _imageMatrix;
        protected Color[,] _modifiedMatrix;

  
        protected int _height;
        protected int _width;

        public PixelTransform(Bitmap source)
        {

            _height = source.Height;
            _width = source.Width;
            _imageMatrix = new Color[source.Width, source.Height];
            _modifiedMatrix = new Color[source.Width, source.Height];

            for (int col = 0; col < source.Width; col++)
            {
                for (int row = 0; row < source.Height; row++)
                {
                    _imageMatrix[col, row] = source.GetPixel(col, row);
                }

            }
        
        }

        protected void NormalizeRGBVal(ref double val)
        {
            if (val > 255)
                val = 255;
            else if (val < 0)
                val = 0;


        }


        public void setBitmapPixels(Bitmap b)
        {
            for (int col = 0; col < _width; col++)
            {
                for (int row = 0; row < _height; row++)
                {
                    b.SetPixel(col, row, _modifiedMatrix[col, row]);
                }

            }


        }

        

        abstract public void AcceptTransormation();
    
    
    
    }
}
