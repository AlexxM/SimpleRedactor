namespace ImageManipulation
{
    partial class DetailForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фильтрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размытиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.негативToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.резкостьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.тиснениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.серыеТонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(156, 549);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(319, 33);
            this.textBox1.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(156, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 477);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Location = new System.Drawing.Point(16, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(121, 219);
            this.panel2.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 22);
            this.button1.TabIndex = 7;
            this.button1.Text = "Обрезать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.changeDrawMode);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(13, 105);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(100, 23);
            this.button6.TabIndex = 6;
            this.button6.Text = "Эллипс";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.changeDrawMode);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(13, 75);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Прямоугольник";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.changeDrawMode);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(79, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Кисть";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.changeDrawMode);
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "8",
            "11",
            "14",
            "17",
            "20",
            "25",
            "30"});
            this.comboBox2.Location = new System.Drawing.Point(56, 177);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(45, 24);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.Text = "3";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(13, 177);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(27, 27);
            this.panel3.TabIndex = 1;
            this.panel3.Click += new System.EventHandler(this.panel3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Линия";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.changeDrawMode);
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(12, 42);
            this.trackBar1.Maximum = 8;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(84, 45);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.Tag = 4;
            this.trackBar1.Value = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.LargeChange = 2;
            this.trackBar2.Location = new System.Drawing.Point(12, 115);
            this.trackBar2.Maximum = 6;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(84, 45);
            this.trackBar2.TabIndex = 12;
            this.trackBar2.Tag = 3;
            this.trackBar2.Value = 3;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.фильтрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(645, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как...";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // фильтрыToolStripMenuItem
            // 
            this.фильтрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.размытиеToolStripMenuItem,
            this.негативToolStripMenuItem,
            this.резкостьToolStripMenuItem,
            this.тиснениеToolStripMenuItem,
            this.серыеТонаToolStripMenuItem});
            this.фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            this.фильтрыToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // размытиеToolStripMenuItem
            // 
            this.размытиеToolStripMenuItem.Name = "размытиеToolStripMenuItem";
            this.размытиеToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.размытиеToolStripMenuItem.Text = "Размытие";
            this.размытиеToolStripMenuItem.Click += new System.EventHandler(this.acceptFilter);
            // 
            // негативToolStripMenuItem
            // 
            this.негативToolStripMenuItem.Name = "негативToolStripMenuItem";
            this.негативToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.негативToolStripMenuItem.Text = "Негатив";
            this.негативToolStripMenuItem.Click += new System.EventHandler(this.acceptFilter);
            // 
            // резкостьToolStripMenuItem
            // 
            this.резкостьToolStripMenuItem.Name = "резкостьToolStripMenuItem";
            this.резкостьToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.резкостьToolStripMenuItem.Text = "Резкость";
            this.резкостьToolStripMenuItem.Click += new System.EventHandler(this.acceptFilter);
            // 
            // тиснениеToolStripMenuItem
            // 
            this.тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            this.тиснениеToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.тиснениеToolStripMenuItem.Text = "Тиснение";
            this.тиснениеToolStripMenuItem.Click += new System.EventHandler(this.acceptFilter);
            // 
            // серыеТонаToolStripMenuItem
            // 
            this.серыеТонаToolStripMenuItem.Name = "серыеТонаToolStripMenuItem";
            this.серыеТонаToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.серыеТонаToolStripMenuItem.Text = "Серые тона";
            this.серыеТонаToolStripMenuItem.Click += new System.EventHandler(this.acceptFilter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(19, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Яркость:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(19, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Контраст:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "All files|*.*|Jpeg| *.jpg|Png|*.png|Gif|*.gif|Bmp|*.bmp";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.trackBar1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.trackBar2);
            this.panel4.Location = new System.Drawing.Point(16, 357);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(121, 163);
            this.panel4.TabIndex = 18;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SimpleRedactor.Properties.Resources.animation;
            this.pictureBox2.Location = new System.Drawing.Point(61, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 33);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 471);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // DetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 599);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "DetailForm";
            this.Text = "Simple redactor - редактирование изображения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.scrollEnabled);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.ToolStripMenuItem фильтрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размытиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem негативToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem резкостьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem тиснениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem серыеТонаToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;

    }
}