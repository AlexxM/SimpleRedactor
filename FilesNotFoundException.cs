using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageManipulation
{
    class FilesNotFoundException : Exception
    {

        public string[] paths;
        private string p;
        private string[] p_2;
        
        public FilesNotFoundException(string message ,string[] paths) : base(message)
        {
            this.paths = paths;
        }

        public FilesNotFoundException(string[] paths) : this("Не удалось получить доступ к одному или нескольким файлам",paths)
        { 
        
        
        }

    }
}
