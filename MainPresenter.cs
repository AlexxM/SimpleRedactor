using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.IO;
namespace ImageManipulation
{
    class MainPresenter : IPresenter
    {

        private IMainView _mainForm;

        private GetImages _images = null;

        private LinkedList<string> dirHistory = new LinkedList<string>();

        public  MainPresenter(IMainView view)
        {
            this._mainForm = view;
            
            this._mainForm.rotate+=new Action<string[],RotateFlipType>(OnRotate);
            this._mainForm.createImage += new Action(OnCreateImage);
            this._mainForm.showImages += onShow;
            this._mainForm.editImage+=onEditImage;
            this._mainForm.deleteFiles += new Action<string[]>(OndeleteFiles);
        }

        void OnCreateImage()
        {
            Program.currentProgram.createImage();
        }

        void OndeleteFiles(string[] paths)
        {
            DeleteManipulation delete = new DeleteManipulation(paths);
            Task.Factory.StartNew(() =>
            {
                _mainForm.isProcessing = true;
                string[] tempArr = dirHistory.ToArray();

                if (tempArr.Length > 0 && paths.Length>0)
                {
                    delete.accept();
             
                    _images.deleteImagePaths(paths);
                    RefreshMiniatures(_images.getMiniatures());
                   
                }
                _mainForm.isProcessing = false;
            });
        }
        private void OnRotate(string[] paths,RotateFlipType rot)
        {

            RotateManipulation rm = new RotateManipulation(paths,rot);
            _mainForm.isProcessing = true;

            Task.Factory.StartNew(() =>
            {
                try
                {
                    rm.accept();
                    prepeareUpdateMiniature(paths);
                    _mainForm.isProcessing = false;
                }
                catch (FilesNotFoundException ex)
                {

                    _mainForm.warningMessage(ex.Message);
                    OndeleteFiles(ex.paths);


                }


            });

            
            
        
           
       }

        public void prepeareUpdateMiniature(string[] paths)
        {
          
            if (paths.Length == 0 || _images==null)
                return;

          
            if (!_images.files.Contains(paths[0]))
            {

                if (Path.GetDirectoryName(paths[0]) == _images.path)
                {
                    _images.addImagePaths(paths);
                    this._mainForm.addMiniatures(getUpdatedMiniature(paths));
                }

            }
            else
            {

                this._mainForm.updateMiniatures(getUpdatedMiniature(paths));
            }
        }

        private Bitmap[] getUpdatedMiniature(string[] paths)
        {
            Bitmap[] bitmap=new Bitmap[paths.Length];
       
            for (int i = 0; i < paths.Length;i++)
            {
                 bitmap[i]=this._images.getMiniature(paths[i]);
            }

            return bitmap;
        }

        private void RefreshMiniatures(Bitmap[] bitmaps)
        {
           
            this._mainForm.refreshMiniatures(bitmaps);
        }

        private void onShow(string path)
        {
            GetImages gi = new GetImages(path, new Size(133, 133));
            System.Drawing.Bitmap[] bitmaps = gi.getMiniatures();
            _images = gi;
           addDirToHistory(path);
           RefreshMiniatures(bitmaps);
           _mainForm.isProcessing = false;
        }

        private void addDirToHistory(string dirPath)
        {
           if(dirHistory.Count==4)
           {
              dirHistory.RemoveLast();
           }

           if(dirHistory.Contains(dirPath))
           {
                dirHistory.Remove(dirPath);
           }
           dirHistory.AddFirst(dirPath);

           _mainForm.fillOldPathHelper(dirHistory);
        }

        private void onEditImage(string imagePath)
        {
            Program.currentProgram.editImage(imagePath);

        }
       
    }
}
