using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ImageManipulation
{
   
    class RotateManipulation : IManipulate
    {

        private RotateFlipType rotateType;

        private string[] _imagesPath;
        
        public RotateManipulation(string[] imagesPath,RotateFlipType rotateType)
        {
            this._imagesPath = imagesPath;
            this.rotateType = rotateType;
        }

        public void accept()
        {
            try
            {
                ParallelOptions po = new ParallelOptions();
                po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
                Parallel.ForEach(this._imagesPath, po, new Action<string>(rotate));
            }
            catch (AggregateException ioEx)
            {
                List<string> filesNotFound = new List<string>();
                
                foreach(string s in _imagesPath)
                {
                    if (!File.Exists(s))
                    {
                        filesNotFound.Add(s);
                    }

                }

                throw new FilesNotFoundException(filesNotFound.ToArray<string>());
            }
        }

        private void rotate(string imgPath)
        {

            Bitmap b = new Bitmap(imgPath);
            b.RotateFlip(this.rotateType);
            b.Save(imgPath);
        }


    }
}
