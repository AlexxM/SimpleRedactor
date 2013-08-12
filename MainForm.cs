using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;

namespace ImageManipulation
{
    public partial class MainForm : Form,IMainView
    {

        public event Action<string[],RotateFlipType> rotate;

        public event Action<string> showImages;

        public event Action<string> editImage;

        public event Action<string[]> deleteFiles;

        public event Action createImage;

        public bool _isProcessing = false;

        public bool isProcessing { get { return _isProcessing; } set { _isProcessing = value; processing(value); } }

        private int _tableColumns = 4;

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.CellContentDoubleClick+=new DataGridViewCellEventHandler(doubleClicked);
        }

        private void doubleClicked(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string path = (string)((Bitmap)(dataGridView1.SelectedCells[0].FormattedValue)).Tag;
                editImage(path);
            }
            catch (ArgumentNullException ex)
            {
                warningMessage("Выберите изображение");
            }
            catch (ArgumentException ex)
            {
                warningMessage("Файл не найден");
                deleteFiles(selectedImages());
            }
        }

        public void warningMessage(string str)
        {
            MessageBox.Show(str, "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
                if (isProcessing == false)
                {

                    string[] imagesPaths = selectedImages();
                    Button b = (Button)sender;

                    if (imagesPaths.Length != 0)
                    {
                        if (b.Text == "Повернуть <-")
                            rotate(imagesPaths, RotateFlipType.Rotate270FlipNone);
                        else if (b.Text == "Повернуть ->")
                            rotate(imagesPaths, RotateFlipType.Rotate90FlipNone);
                        else if (b.Text == "Удалить")
                        {

                            if (DialogResult.Yes == MessageBox.Show("Удалить изображения?", "", MessageBoxButtons.YesNo))
                            {
                                deleteFiles(selectedImages());
                            }
                        }
                    }
                    else
                    {
                        warningMessage("Выберите один или несколько файлов");
                    }
                }
          
       
        }

        private string[] definePaths(DataGridViewSelectedCellCollection collection)
        {
            
            Bitmap bitmap;
            string[] changedFiles = new string[collection.Count];
            for (int i = 0; i < changedFiles.Length; i++)
            {
                bitmap = (Bitmap)collection[i].FormattedValue;
                changedFiles[i] = (string)bitmap.Tag;
            }

            return changedFiles;
        
        }

        public void refreshMiniatures(Bitmap[] bitmap)
        {
            this.BeginInvoke(new Action(() =>
            {
                dataGridView1.Rows.Clear();


                addMiniatures(bitmap);

            }));
            
        }

        public void fillOldPathHelper(LinkedList<string> paths)
        {
           
            ToolStripMenuItem[] mItem = paths.Select((e) => { ToolStripMenuItem item = new ToolStripMenuItem(e); item.Click +=openDirectory; return item; }).ToArray();

            ToolStripMenuItem menuItem = (ToolStripMenuItem)((ToolStripMenuItem)menuStrip1.Items["изображенияToolStripMenuItem"]).DropDownItems["недвноОткрытыеПапкиToolStripMenuItem"];
            
           
            this.BeginInvoke(new Action(() =>
            {
                menuItem.Enabled = true;
                menuItem.DropDownItems.Clear();
                menuItem.DropDownItems.AddRange(mItem);
                lblPathInfo.Text = paths.First.Value;
            }));
        }

        public void addMiniatures(Bitmap[] bitmap)
        {
            int counter = 0;

            if (bitmap.Length == 0)
                return;

            int rowIndex;
            if (dataGridView1.Rows.Count == 0)
            {
                rowIndex = dataGridView1.Rows.Add();
            }
            else
            {

                rowIndex = dataGridView1.Rows.Count - 1;
            }

            var col = ((DataGridViewCellCollection)(dataGridView1.Rows[rowIndex].Cells)).OfType<DataGridViewImageCell>().Where((o) => { return o.Value != null; }).Count();

            while (counter < bitmap.Length)
            {

                while (counter < bitmap.Length && col < this._tableColumns)
                {
                    dataGridView1.Rows[rowIndex].Cells[col].Value = bitmap[counter];
                    counter++;
                    col++;
                }

                if (counter < bitmap.Length)
                {
                    rowIndex = dataGridView1.Rows.Add();
                    col = 0;
                }

            }
        }
        public void updateMiniatures(Bitmap[] bitmaps)
        {
                DataGridViewRowCollection temp = dataGridView1.Rows;
                   
                int[,] indexArr=new int[bitmaps.Length,2];
                for (int i = 0; i < bitmaps.Length; i++)
                {


                    foreach (DataGridViewRow t in dataGridView1.Rows)
                    {
                       
                        DataGridViewCellCollection cells = t.Cells;
                        foreach (DataGridViewImageCell cell in cells)
                        {
                            if ((string)(((Bitmap)cell.FormattedValue).Tag) == (string)(bitmaps[i].Tag))
                            {
                                indexArr[i, 0] = cell.RowIndex;
                                indexArr[i, 1] = cell.ColumnIndex;
                            }
                        }
                    }
   
                }

        
                
                for (int i = 0; i < bitmaps.Length; i++)
                {
                    //DataGridViewCell c = dataGridView1.SelectedCells[i];
                    //c.Value = bitmaps[i];

                    dataGridView1[indexArr[i, 1], indexArr[i, 0]].Value = bitmaps[i];
                }
        }

        private string[] selectedImages()
        {

            DataGridViewImageCell[] collection = (this.dataGridView1.SelectedCells.OfType<DataGridViewImageCell>().Where((o) => {return o.Value != null; })).ToArray();

            string[] indexes = new string[collection.Length];

            if (indexes.Length == 0)
            { 
                return indexes;
            }

            
            
            
            
            for (int i = 0; i < collection.Length; i++)
            {
                Bitmap b = (Bitmap)collection[i].Value;
               
                indexes[i] = (string)b.Tag;
            
            }

            return indexes;
        }

        public void processing(bool showPreloader)
        {

            this.BeginInvoke(new Action(() => {
                                                pictureBox1.Visible = (showPreloader==true) ? true : false;
            }));
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
                if (DialogResult.OK == folderBrowserDialog1.ShowDialog())
                {
                    EventArgs a = new EventArgs();

                    openDirectory(folderBrowserDialog1.SelectedPath, EventArgs.Empty);

                }
            
            
        }

        private void openDirectory(object obj,EventArgs e)
        {
            if (isProcessing == false)
            {
                isProcessing = true;

                string dir = String.Empty;
                if (obj is ToolStripDropDownItem)
                {
                    dir = ((ToolStripDropDownItem)obj).Text;
                }
                else if (obj is string)
                {
                    dir = (string)obj;
                }

                //processing(true);
                showImages.BeginInvoke(dir, null, null);
            }
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createImage();
        }

    }

    //public class ImagesEventArgs : EventArgs
    //{
    //   public string[] selectedItems{get;set;}
    
    //}

}
