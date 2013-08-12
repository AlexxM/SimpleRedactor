using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
namespace ImageManipulation
{
    class GrayScaleTransform : PixelTransform
    {

        public GrayScaleTransform(Bitmap b): base(b)
        { 
        
        }

        public override void AcceptTransormation()
        {

            Parallel.For(0, _width, new ParallelOptions() { MaxDegreeOfParallelism = Environment.ProcessorCount }, (i) => { columnsTransform(i); });


        }


        public void columnsTransform(int i)
        {


            for (int j = 0; j < _height; j++)
            {
                Color c = _imageMatrix[i, j];
                int gray = (int)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                _modifiedMatrix[i, j] = Color.FromArgb(gray, gray, gray);

            }
        
       }

    
    }
}
