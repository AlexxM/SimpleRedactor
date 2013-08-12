using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ImageManipulation
{
    class DeleteManipulation : IManipulate
    {

        public string[] _imagesPath;

        public DeleteManipulation(string[] path)
        {
            _imagesPath = path;
        
        }
        
        public void accept()
        {
            try
            {
                foreach (string s in _imagesPath)
                {
                    deleteImages(s);
                }
            }
            catch(IOException ex)
            {
                
            
            }


        }


        private void deleteImages(string path)
        {
            File.Delete(path);
            //FileStream fs = new FileStream(path,FileMode.Open);
            FileInfo fi = new FileInfo(path);
            fi.Delete();
         
        }
    }
}
