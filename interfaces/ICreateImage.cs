using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace ImageManipulation
{
    interface ICreateImage
    {

         event Action<Size> createFixedImage;
    }
}
