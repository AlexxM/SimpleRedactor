using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageManipulation
{
    interface IImageTransform
    {
         event Action<int[,], int, int> forceMatrixTransform;

         event Action<PixelTransformation,int> forceTransform;
    }
}
