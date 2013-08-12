using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
namespace ImageManipulation
{
    class SetContrast : PixelTransform
    {
        //private int _modify;
        private double _contrast;
        public SetContrast(Bitmap b, int modify)
            : base(b)
        {
            //_modify = modify;
            
            if (modify < -100) modify = -100;
            if (modify > 100) modify = 100;

         
            _contrast = (100.0 + modify) / 100.0;
            _contrast *= _contrast;
        }


        public override void AcceptTransormation()
        {

            
           Parallel.For(0, _width, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (j) => { columnsTransform(j); });
            

            //return base.setBitmapPixels(dist);
        }

        public void columnsTransform(int i)
        {
            double r, g, b;
            for (int j = 0; j < _height; j++)
            {
                r = _imageMatrix[i, j].R / 255.0;
                r -= 0.5;
                r *= _contrast;
                r += 0.5;
                r *= 255;
                NormalizeRGBVal(ref r);

                g = _imageMatrix[i, j].G / 255.0;
                g -= 0.5;
                g *= _contrast;
                g += 0.5;
                g *= 255;
        
                NormalizeRGBVal(ref g);

                b = _imageMatrix[i, j].B / 255.0;
                b -= 0.5;
                b *= _contrast;
                b += 0.5;
                b *= 255;
             
                NormalizeRGBVal(ref b);

                _modifiedMatrix[i, j] = Color.FromArgb((int)r, (int)g, (int)b);
            }

        }
    }
}