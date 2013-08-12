using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace ImageManipulation
{
    class GetImages : GetImage
    {
        private string _path;

        public List<string> files { private set { _files = value; } get { return _files; } }

        private List<string> _files=new List<string>();

        public string path { private set { _path = value; } get { return _path; } }

        public GetImages(string path,string pattern,Size miniatureSize) : base(miniatureSize.Width,miniatureSize.Height)
        {
            string[] fileArr = Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly);
            foreach (string str in fileArr)
                _files.Add(str);

            this._path = path;
        }

        public GetImages(string path,Size miniatureSize) : base(miniatureSize.Width,miniatureSize.Height)
        {
           
            string[] fileArr = Directory.GetFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(str => str.ToLower().EndsWith(".jpg") || str.ToLower().EndsWith(".png") || str.ToLower().EndsWith(".gif") || str.ToLower().EndsWith(".bmp")).ToArray();
            foreach (string str in fileArr)
                _files.Add(str);
            
            this._path = path;
        }
        
        public Bitmap[] getMiniatures()
        {
            Bitmap[] bitArr=new Bitmap[this._files.Count<string>()];
            for (int i = 0; i < this._files.Count<string>();i++)
            {
                bitArr[i] = base.getMiniature(this._files[i]);

            }
            return bitArr;
        
        }

        public void addImagePaths(string[] paths)
        {
            foreach(string s in paths)
            {
                if (Path.GetDirectoryName(s) == _path)
                _files.Add(s);
        
            }
        }

        public void deleteImagePaths(string[] paths)
        {
            foreach (string s in paths)
            {
                if (Path.GetDirectoryName(s) == _path)
                {
       
                    _files.Remove(s);
                
                }   
                                   
            }
        
        }
       

    }
}
