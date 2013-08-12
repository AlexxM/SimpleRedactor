using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace ImageManipulation
{
    interface IDrawing
    {
         event Action<DrawMode> drawMode;
         event Action<Pen> setPen;

         event Action<Point> beginDrawing;
         event Action<Point> endDrawing;
         event Action<Point> continueDrawing;
         event Action<PaintEventArgs> renderVisualHelpers;

         bool drawingEnable { get; set; }
         void resetDrawingHandlers();
         void  invalidateImage();
    }
}
