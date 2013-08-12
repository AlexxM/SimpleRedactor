using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace ImageManipulation
{
    class MatrixTransform : PixelTransform
    {
        private int[,] _transformation;

        private int _factor;

        private int _offset;
        
        public MatrixTransform(Bitmap source,int[,] matrix,int factor,int offset) : base(source)
        {

            this._transformation=matrix;
            this._factor=factor;
            this._offset=offset;
        }

       

        public override void AcceptTransormation()
        {
  
            ParallelOptions po = new ParallelOptions();
            po.MaxDegreeOfParallelism = Environment.ProcessorCount;
            Parallel.For(2, _width-2, po,(i) => { ColumnFilter(i); });   

        }


        private Color[,] GetColorMatrix(int i,int j)
        {
            Color[,] c = new Color[5,5];

            for(int ii=-2;ii<3;ii++)
            {
                for (int jj = -2; jj < 3;jj++)
                {
                    c[ii + 2, jj + 2] = _imageMatrix[ii + i, jj + j];
                }
            
            }

            return c;
        
        }

        private Color MulMatrix(Color[,] imgColor)
        {

            double red=0, green=0, blue=0;
            for (int i = 0; i < 5; i++)
            { 
                for(int j=0;j<5;j++)
                {
                    red += imgColor[i, j].R * _transformation[i, j];
                    green += imgColor[i, j].G * _transformation[i, j];
                    blue += imgColor[i, j].B * _transformation[i, j];
                }
            }

            red /= _factor;
            green /= _factor;
            blue /= _factor;

            red += _offset;
            green += _offset;
            blue += _offset;


            NormalizeRGBVal(ref red);
            NormalizeRGBVal(ref green);
            NormalizeRGBVal(ref blue);

            return Color.FromArgb((int)red,(int)green,(int)blue);
        
        
        }


        private void ColumnFilter(int i)
        {

            for (int j = 2; j < _height-2;j++)
            {
                Color c = MulMatrix(GetColorMatrix(i, j));
                _modifiedMatrix[i, j] = c;
            }
        
        
        }
    
    }
}
