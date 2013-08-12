using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
namespace ImageManipulation
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 
        
        public static Program currentProgram;

        private MainPresenter _mainPresenter;

        private DetailPresenter _detailPresenter;

        private DrawingPresenter _drawingPresenter;

        private TransformPresenter _transformPresenter;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += ThreadExceptionHandler;
          
            currentProgram = new Program();
          
            MainForm form1 = new MainForm();
            MainPresenter presenter = new MainPresenter(form1);
            currentProgram._mainPresenter = presenter;

            Application.Run(form1);
        }

        static void ThreadExceptionHandler(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            
        }

        public void editImage(string imagePath)
        {

            DetailForm form2 = new DetailForm();
            this._detailPresenter = new DetailPresenter(form2, imagePath);
           
         
            attachPresenters(form2);
            form2.ShowDialog();
        }

        public void createImage()
        {
            CreateNewImageForm newImageForm = new CreateNewImageForm();
          
            newImageForm.createFixedImage += new Action<Size>((s) =>
            {
                DetailForm df = new DetailForm();
              
                Bitmap b = new Bitmap(s.Width, s.Height);
                Graphics.FromImage(b).FillRectangle(Brushes.White, 0, 0, s.Width, s.Height);
                this._detailPresenter = new DetailPresenter(df, b);
                
                df.textBox1.Visible=false;
                ((ToolStripMenuItem)(((ToolStripMenuItem)df.menuStrip1.Items[0]).DropDownItems[0])).Enabled = false;
                newImageForm.Visible = false;
                attachPresenters(df);
           
                df.ShowDialog();
        
            });
            newImageForm.ShowDialog();
        
        }

        private void attachPresenters(DetailForm df)
        {

            
            DrawingPresenter drawingPresenter = new DrawingPresenter(df, this._detailPresenter);
            this._drawingPresenter = drawingPresenter;

            TransformPresenter transformPresenter = new TransformPresenter(df, this._detailPresenter);
            this._transformPresenter = transformPresenter;
            
        
        }

        public void updateMiniature(string imgPath)
        {
            PixelTransform.savedBitmap = null;
            _mainPresenter.prepeareUpdateMiniature(new string[] { imgPath } );
        
        }
    }
}
