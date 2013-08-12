using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ImageManipulation
{
    class CropImage : DrawRect
    {
     
        
        public Bitmap getCropImage(Bitmap source)
        {
            int x,y,width,height;
            base.DefDescribedRectangle(out x,out y,out width,out height);
            Bitmap b = new Bitmap(width, height);
            Graphics.FromImage(b).DrawImage(source, 0,0, new Rectangle(new Point(x, y), new Size(width, height)),GraphicsUnit.Pixel);

            return b;
        }
    }
}
