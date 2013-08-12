using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace ImageManipulation
{
    public interface IMainView
    {
          event Action<string[], RotateFlipType> rotate;

          event Action<string[]> deleteFiles;

          event Action<string> showImages;

          event Action<string> editImage;

          event Action createImage;

          bool isProcessing { get; set; }

          void updateMiniatures(Bitmap[] bitmaps);

          void addMiniatures(Bitmap[] bitmap);

          void refreshMiniatures(Bitmap[] bitmap);
        
          void fillOldPathHelper(LinkedList<string> paths);

          void warningMessage(string message);
    }
}
