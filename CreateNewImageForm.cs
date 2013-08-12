using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageManipulation
{
    public partial class CreateNewImageForm : Form,ICreateImage
    {
        
        public event Action<Size> createFixedImage;
        
        public CreateNewImageForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (createFixedImage != null)
                createFixedImage(new Size((int)numericUpDown1.Value,(int)numericUpDown2.Value));
        }
    }
}
