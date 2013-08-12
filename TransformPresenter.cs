using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ImageManipulation
{
    class TransformPresenter : IPresenter
    {
        private IImageTransform _detailForm;

        private DetailPresenter _detailPresenter;
        
        public TransformPresenter(IImageTransform detailForm, DetailPresenter dp)
        {
            


            detailForm.forceMatrixTransform += new Action<int[,], int,int>(OnforceMatrixTransform);
        detailForm.forceTransform += new Action<PixelTransformation,int>(OnForceTransform);
            _detailForm = detailForm;
            _detailPresenter = dp;
            PixelTransform.savedBitmap = dp.img;
        
        }

        private PixelTransform getTransformObject(PixelTransformation pt,Bitmap b,int par)
        { 
            PixelTransform transform=null;
            if (pt == PixelTransformation.grayScale)
            {
                transform = new GrayScaleTransform(b);
            }
            else if (pt == PixelTransformation.modBrightness)
            {
                transform = new SetBrightness(b, par);
            }
            else if (pt == PixelTransformation.modContrast)
            {
                transform = new SetContrast(b,par);
            }
            return transform;
        
        }

        void OnForceTransform(PixelTransformation pt,int par)
        {
 
            Bitmap source = new Bitmap(PixelTransform.savedBitmap);
            Task.Factory.StartNew(() =>
            {
                PixelTransform t = this.getTransformObject(pt, source, par);
                Bitmap b = new Bitmap(source.Width, source.Height);
                Transform(t,b);

                if (PixelTransformation.grayScale == pt)
                {
             
                    PixelTransform.savedBitmap = b;
                    (_detailForm as IDetailView).showMessage("Применение фильтра завершено");
                    
                }

                (_detailForm as IDetailView).isImageProcessing = false;
            });
        }

        void OnforceMatrixTransform(int[,] m, int factor,int offset)
        {
            if (m.Length != 25)
            {
                throw new ArgumentException("Требуется массив размерностью 5 на 5");
            }


            Bitmap source = new Bitmap(_detailPresenter.img);


            Task.Factory.StartNew(() =>
            { 
                MatrixTransform mt = new MatrixTransform(source,m,factor,offset);

                Bitmap dist = new Bitmap(source.Width,source.Height);
        
                Transform(mt, dist);


                (_detailForm as IDetailView).isImageProcessing = false;
                PixelTransform.savedBitmap = dist;
                (_detailForm as IDetailView).showMessage("Применение фильтра завершено");
                
            });
        }

        private void Transform(PixelTransform pt,Bitmap dist)
        {

          
                dist.Tag = _detailPresenter.img.Tag;
                pt.AcceptTransormation();
                pt.setBitmapPixels(dist);

                
                _detailPresenter.img = dist;
               
                (_detailForm as IDetailView).showDetailImage(dist, _detailPresenter._actualSize);
                (_detailForm as IDetailView).isImageProcessing = false;
                GC.Collect();
        
        }

       
    
    }
}
