using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Timers;
namespace ImageManipulation
{
    class DrawingPresenter : IPresenter
    {

        private DrawPrimitive _drawPrimitive;

        private IDrawing _detailForm;

        private DetailPresenter _detailPresenter;

        private System.Timers.Timer ttimer = new System.Timers.Timer() {AutoReset=true,Interval=1500,Enabled=false };

        public DrawingPresenter(IDrawing detailForm,DetailPresenter dp)
        {
            this._detailForm = detailForm;
            this._detailPresenter = dp;
            this._detailForm.drawMode += new Action<DrawMode>(changeDrawMode);
            this._detailForm.setPen += new Action<Pen>(setPen);
            this._detailForm.renderVisualHelpers+=new Action<PaintEventArgs>(OnRenderVisualHelpers);
         
        }

        void setPen(Pen obj)
        {
            if (_drawPrimitive != null)
            {
                _drawPrimitive.setPen = (Pen)obj.Clone();


                if (_drawPrimitive.GetType() == typeof(CropImage))
                {
                    _drawPrimitive.setPen.Width = 4;
                }
            }
        }

        void OnRenderVisualHelpers(PaintEventArgs obj)
        {
            if (_drawPrimitive != null)
            {
                if (_detailForm.drawingEnable == true && _drawPrimitive.GetType() != typeof(DrawPoint) || _drawPrimitive.GetType() == typeof(DrawPoint) && _detailForm.drawingEnable == false)//&& (_detailForm.drawingEnable==true || (_drawPrimitive.GetType()==typeof(DrawPoint) && _detailForm.drawingEnable==false)))
                {

                    ttimer.Stop();
                    if (_drawPrimitive.GetType() == typeof(DrawPoint))
                    {
                       
                        ttimer.Start();

                        ttimer.Elapsed += (o, e) => { _drawPrimitive.startPoint = new Point(0, 0); _drawPrimitive.endPoint = new Point(0, 0); _detailForm.invalidateImage(); };
                    }
                    Pen temp = this._drawPrimitive.setPen;

                    float widthCorrection = (float)_detailPresenter._actualSize.Height / (float)_detailPresenter.img.Height * temp.Width;
                   
                    this._drawPrimitive.setPen = new Pen(Color.FromArgb(30, Color.Blue), widthCorrection);
                    this._drawPrimitive.Render(obj.Graphics);
                    this._drawPrimitive.setPen = temp;

                }
            }
        }

        
    

        void endDrawing(Point obj)
        {
                _drawPrimitive.endPoint = obj;

                if (_detailForm.drawingEnable == true)
                {
                    double dx = (double)_detailPresenter.img.Height / (double)_detailPresenter._actualSize.Height;
                    _drawPrimitive.Scale(dx);

                    _drawPrimitive.Render(Graphics.FromImage(_detailPresenter.img));
                    _drawPrimitive.Render(Graphics.FromImage(PixelTransform.savedBitmap));
                }
                
                //_detailForm.showDetailImage(_detailPresenter.img, _detailPresenter._actualSize);
        }

        void saveCropImage(Point p)
        {
            _drawPrimitive.endPoint = p;
            double dx = (double)_detailPresenter.img.Height / (double)_detailPresenter._actualSize.Height;
            _drawPrimitive.Scale(dx);
            Bitmap b = ((CropImage)_drawPrimitive).getCropImage(_detailPresenter.img);
            _detailForm.drawingEnable = false;
       
            string path = (_detailForm as IDetailView).showSaveFileDialog();

            

            if (path != null)
            {
                b.Save(path);
                Program.currentProgram.updateMiniature(path);
            }
        }


        void beginDrawing(Point obj)
        {
                _drawPrimitive.startPoint = obj; 
        }

        void continueDrawing(Point obj)
        {
            _drawPrimitive.endPoint = obj;    
        
        }

        void changeDrawMode(DrawMode obj)
        {
            
            this._detailForm.resetDrawingHandlers();
            
            switch(obj)
            {
                case DrawMode.Line: _drawPrimitive = new DrawLine(); attachDefaultDrawingHandler(); break;

                case DrawMode.Rectangle: _drawPrimitive = new DrawRect(); attachDefaultDrawingHandler(); break;

                case DrawMode.Ellipse: _drawPrimitive = new DrawEllipse(); attachDefaultDrawingHandler(); break;
                
                case DrawMode.Point:  _drawPrimitive = new DrawPoint();  this._detailForm.beginDrawing += new Action<Point>(beginDrawing); this._detailForm.beginDrawing += new Action<Point>(endDrawing); this._detailForm.continueDrawing += new Action<Point>(beginDrawing); this._detailForm.continueDrawing += new Action<Point>(endDrawing); break;

                case DrawMode.CropImage: _drawPrimitive = new CropImage(); this._detailForm.continueDrawing += new Action<Point>(continueDrawing); this._detailForm.beginDrawing += new Action<Point>(beginDrawing); this._detailForm.endDrawing += new Action<Point>(saveCropImage); break;
            }

        }

        void attachDefaultDrawingHandler()
        {
            this._detailForm.continueDrawing += new Action<Point>(continueDrawing);
            this._detailForm.beginDrawing += new Action<Point>(beginDrawing);
            this._detailForm.endDrawing += new Action<Point>(endDrawing);
        
        }
    }
}
