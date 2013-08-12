using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageManipulation
{
    public partial class DetailForm : Form,IDetailView,IDrawing,IImageTransform
    {
        private bool _isImageProcessing = false;

        public bool isImageProcessing
        { 
            get { return _isImageProcessing; } 
            set 
            { 
                _isImageProcessing = value; 
                this.BeginInvoke(new Action(() => { this.pictureBox2.Visible=(value==false) ? false : true;}));
            } 
        }
        
        public event Action closeImage;

        public event Action<string> saveImage;
    
        public event Action zoomIn;
        public event Action zoomOut;

        public event Action<DrawMode> drawMode;
        public event Action<Pen> setPen;
        
        public event Action<Point> beginDrawing;
        public event Action<Point> endDrawing;
        public event Action<Point> continueDrawing;
        public event Action<PaintEventArgs> renderVisualHelpers;


        public event Action<int[,], int,int> forceMatrixTransform;
        public event Action<PixelTransformation,int> forceTransform;


        public bool drawingEnable { get { return _drawingEnable; } set { _drawingEnable = value; } }

        public bool _drawingEnable=false;
        private Pen drawingPen;
        
       
        public DetailForm()
        {
            InitializeComponent();
            this.drawingPen = new Pen(new SolidBrush(panel3.BackColor), float.Parse(comboBox2.Text));
    
            
        }


        public void showDetailImage(Image img,Size actualSize)
        {
            /*
             * возможно возникновение исключения при доступе к img во время применения фильтра
             */
            try
            {
                pictureBox1.Image = img;
                pictureBox1.Size = actualSize;

                if (img.Tag != null && img.Tag.GetType() == typeof(string))
                {
                    FileInfo fi = new FileInfo((string)img.Tag);

                    textBox1.Text = String.Format("имя файла:{0}   расширение:{1}\r\nдата создания:{2}   размер:{3} кб", fi.Name, fi.Extension, fi.CreationTime, Math.Round((float)(fi.Length) / 1024, 2));
                }
            }
            catch { }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeImage();
            
        }

    

       
        private void scrollEnabled(object e,MouseEventArgs args)
        {

            if (args.Delta > 0)
                zoomIn();
            else if (args.Delta < 0)
                zoomOut();
        }

        private void changeDrawMode(object sender, EventArgs e)
        {

            Button b = (Button)sender;
            if (b.Text == "Линия")
            {
                drawMode(DrawMode.Line);   
            }
            else if(b.Text == "Кисть")
            {
                drawMode(DrawMode.Point); 
            }
            else if(b.Text=="Прямоугольник")
            {
                drawMode(DrawMode.Rectangle);
            }
            else if(b.Text=="Эллипс")
            {
                drawMode(DrawMode.Ellipse);
            }
            else if (b.Text == "Обрезать")
            {
                drawMode(DrawMode.CropImage);
            }

            this.pictureBox1.Cursor = new Cursor(Environment.GetFolderPath(Environment.SpecialFolder.Windows) + "\\Cursors\\pen_i.cur");
            
            setPen(this.drawingPen);
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.button2.Focus();
            //this.pictureBox2.Focus();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
          
                if (renderVisualHelpers != null)
                    renderVisualHelpers(e);
            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
           
           if(endDrawing != null)
           {
                endDrawing(new Point(e.X,e.Y));
                //imageChanged(pictureBox1.Image);
           }
           drawingEnable = false;
          
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drawingEnable = true;
            if (beginDrawing != null)
            {
                beginDrawing(new Point(e.X, e.Y));
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (continueDrawing != null) 
            {
                continueDrawing(new Point(e.X, e.Y));
                this.pictureBox1.Invalidate(true);
            }


        }



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            drawingPen.Width = float.Parse((sender as ComboBox).Text);
            //if (drawingEnable == true)
            //{
               
                setPen(drawingPen);
            
            //}
        }


        private void panel3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                panel3.BackColor = colorDialog1.Color;
                drawingPen.Color = colorDialog1.Color;
                //if (drawingEnable == true)
                //{
                    setPen(drawingPen);
                //}
            
            }
        }

       

        public void resetDrawingHandlers()
        {
            beginDrawing = null;
            endDrawing = null;
            continueDrawing = null;
        
        }

        public void invalidateImage()
        {
            this.pictureBox1.Invalidate();
        }

        private void acceptFilter(object sender, EventArgs e)
        {

            int[,] matrix;
            int factor, offset;
            ToolStripMenuItem b = (ToolStripMenuItem)sender;

            if (isImageProcessing == false)
            {
                isImageProcessing = true;
                if (b.Text == "Размытие")
                {
                    matrix = new[,] { { 1, 1, 1, 0, 0 }, { 1, 1, 1, 0, 0 }, { 1, 1, 1, 0, 0 }, { 1, 1, 1, 0, 0 }, { 1, 1, 1, 0, 0 } };
                    factor = 15;
                    offset = 0;
                    forceMatrixTransform(matrix, factor, offset);
                }
                else if (b.Text == "Негатив")
                {
                    matrix = new int[5, 5];
                    matrix[2, 2] = -1;
                    factor = 1;
                    offset = 255;
                    forceMatrixTransform(matrix, factor, offset);
                }
                else if (b.Text == "Резкость")
                {
                    matrix = new int[5, 5];
                    matrix[1, 1] = -1;
                    matrix[2, 2] = 2;
                    factor = 1;
                    offset = 0;
                    forceMatrixTransform(matrix, factor, offset);


                }
                else if (b.Text == "Тиснение")
                {
                    matrix = new int[5, 5];
                    matrix[1, 1] = 1;
                    matrix[2, 2] = 1;
                    matrix[3, 3] = -1;
                    factor = 1;
                    offset = 0;
                    forceMatrixTransform(matrix, factor, offset);

                }
                else if (b.Text == "Серые тона")
                {
                    forceTransform(PixelTransformation.grayScale,0);
                
                
                }
            
            }

        }

     

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

            if (isImageProcessing == false)
            {
                isImageProcessing = true;
                int modify;
                TrackBar tb = (TrackBar)sender;
                modify = (tb.Value - tb.Maximum / 2) * 20;



                if (tb.Name == "trackBar1")
                {
                    trackBar1.Tag = (object)trackBar1.Value;
                    forceTransform(PixelTransformation.modBrightness, modify);
                }
                else
                {
                    trackBar2.Tag = (object)trackBar2.Value;
                    forceTransform(PixelTransformation.modContrast, modify);
                }
            }
            else
            {
                trackBar1.Value = (int)trackBar1.Tag;
                trackBar2.Value = (int)trackBar2.Tag;
            }
        }

        public void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = showSaveFileDialog();
            if (path != null)
            {
                saveImage(path);
            }
        }

        public string showSaveFileDialog()
        { 
           DialogResult dr =  saveFileDialog1.ShowDialog();
           if (dr == DialogResult.OK)
           {
               return saveFileDialog1.FileName;
           }
           else
           {
               return null;
           }
        }

 
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Сохранить изображение?", "", MessageBoxButtons.YesNo);
           
            if(result == DialogResult.Yes)
            {
                saveImage((string)pictureBox1.Image.Tag);
            }
        }

        public void showMessage(string message)
        {
            MessageBox.Show(message);
        
        }

   

      

    }

}
