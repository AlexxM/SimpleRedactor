using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
namespace ImageManipulation
{
    class DetailPresenter : IPresenter
    {

        public Bitmap img;

        private IDetailView _detailForm;

        private GetImage _getImage;

        public Size _actualSize;

        private Size _defaultMiniatureSize;

        private int _stepCount;

        private double _step;

        public int _stepPosition=0;
        
        public DetailPresenter(IDetailView form,string imagePath) : this(form)
        {
            safeLoad(imagePath);
            showDetailImage();
        }

        public DetailPresenter(IDetailView form, Bitmap bitmap) : this(form)
        {
            img = bitmap;
            showDetailImage();
           
          
        }

        protected DetailPresenter(IDetailView form)
        {
            _detailForm = form;
            form.closeImage += new Action(onCloseForm);
            form.saveImage += new Action<string>(onSave);
            form.zoomIn += new Action(onZoomIn);
            form.zoomOut += new Action(onZoomOut);
            _getImage = new GetImage(470, 470);
        
        }

        private void showDetailImage()
        {
            Size s = _getImage.defineMiniatureSize(new Size(img.Width,img.Height));

            this._actualSize = s;

            this._defaultMiniatureSize = s;

            var t =((float)this.img.Width  / this._actualSize.Width );

            if (t <= 1.5 && t > 1)
            {
                this._step = t - 1;
                this._stepCount = 1;
            }
            else if (t > 1.5 && t <= 2.5)
            {
                this._step = (t -1)/ 3;
                this._stepCount = 3;
            }
            else if (t > 2.5)
            {
                this._step = (t - 1) / 5;
                this._stepCount = 5;
            }
            _detailForm.showDetailImage(img,s);
        }

        private void onZoomIn()
        {
            if(this._stepCount>this._stepPosition)
            {
                this._actualSize.Width = (int)(this._defaultMiniatureSize.Width * this._step + this._actualSize.Width);
                this._actualSize.Height = (int)(this._defaultMiniatureSize.Height * this._step + this._actualSize.Height);
                _detailForm.showDetailImage(img, this._actualSize);
                this._stepPosition += 1;
            }
        
        }

        private void onZoomOut()
        {
            if (this._stepPosition > 0)
            {
                if (this._stepPosition == 1)
                {
                    this._actualSize = this._defaultMiniatureSize;
                }
                else
                {
                    this._actualSize.Width = (int)(this._actualSize.Width - this._defaultMiniatureSize.Width * this._step);
                    this._actualSize.Height = (int)(this._actualSize.Height - this._defaultMiniatureSize.Height * this._step);
                }
                _detailForm.showDetailImage(img, this._actualSize);
                this._stepPosition -= 1;
            }
        
        }

        private void onCloseForm()
        {
            img.Dispose();
            GC.Collect();
           
        }

        private void safeLoad(string imagePath)
        {
            Bitmap image = new Bitmap(imagePath);
            Bitmap copy = new Bitmap(image);

            img = copy;
            img.Tag = imagePath;

            image.Dispose();
        
        }

        private void onSave(string e)
        {
            this.img.Save(e);

            if (img.Tag!=null && e.ToLower() == ((string)img.Tag).ToLower())
            {
                safeLoad(e);
                _detailForm.showDetailImage(this.img, this._actualSize);
            }
            Program.currentProgram.updateMiniature(e);
        }


    }
}
