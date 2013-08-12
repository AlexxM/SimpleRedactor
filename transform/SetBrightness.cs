using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
namespace ImageManipulation{
    class SetBrightness : PixelTransform
    {

        private int _modify;
        public SetBrightness(Bitmap source,int modify)
            : base(source)
        {

          
            
            _modify = modify;
        }
        
        public override void AcceptTransormation()
        {

            Parallel.For(0, _width, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i) => { columnsTransform(i); });
            
           

            //return setBitmapPixels(dist);


        }

        public void columnsTransform(int i)
        {
            double r, g, b;
        
                for (int j = 0; j < _height; j++)
                {
                    Color c = _imageMatrix[i, j];
                    r = c.R + _modify;
                    g = c.G + _modify;
                    b = c.B + _modify;

                    base.NormalizeRGBVal(ref r);
                    base.NormalizeRGBVal(ref g);
                    base.NormalizeRGBVal(ref b);
                    _modifiedMatrix[i, j] = Color.FromArgb((int)r, (int)g, (int)b);

                }

            }
        
        
    }
}
