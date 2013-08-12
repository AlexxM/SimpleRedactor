using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
namespace ImageManipulation
{
    interface IDetailView
    {
        event Action closeImage;

        event Action<string> saveImage;

        event Action zoomIn;
        event Action zoomOut;

        bool isImageProcessing{get;set;}

        void showDetailImage(Image img, Size actualSize);

        string showSaveFileDialog();

        void showMessage(string message);
    }
}
