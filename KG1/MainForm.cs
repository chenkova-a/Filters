using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace KG1 {
    public partial class MainForm : Form
    {
        Bitmap image;//создание объекта
        RunWorkerCompletedEventHandler TFunc;
        RunWorkerCompletedEventHandler TFunc2;
        public MainForm()
        {
            InitializeComponent();
            for (int i = 0; i < Mask.map.GetLength(0); i++)
            {
                for (int j = 0; j < Mask.map.GetLength(1); j++)
                {
                    Mask.map[i,j] = false;
                }
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //создание диалога для открытия файла
            OpenFileDialog dialog = new OpenFileDialog();

            //фильтр для открытия только изображений
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";

            //проверяем выбрал ли пользователь файл
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);//инициализируем наш объект выбранным изображением
                pictureBox1.Image = image;//визуализируем изобр на форму
                pictureBox1.Refresh();//обновляем 
            }
        }


        //BackgroundWorker не относится к польз-ому интерфейсу, нужен для создания и управления работой потоков
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(new QBitmap(image), backgroundWorker1).Export();
            if (backgroundWorker1.CancellationPending == false)
            {
                image = newImage;
            }
        }

        //изменяет цвет полосы прогресса
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = Math.Min(Math.Max(0, e.ProgressPercentage), 100);
        }

        //визуализирует обработанное изобр-е на форме и обнуляет полосу прогресса
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        //остановить выполнение фильтра 
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new BlurFilter());
        }

        private void размытиеПоГауссуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new GaussianFilter());
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new InvertFilter());
        }

        private void градацияСерогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new GrayScaleFilter());
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new SepiaFilter());
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new BrightnessFilter());
        }
        private void фильтрСобеляOXToolStripMenuItem_Click(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync(new SobelXFilter());
        }
        private void фильтрСобеляOYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new SobelYFilter());
        }
        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new SobelFilter());
        }

        private void фильтрЩарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new SharaFilter());
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new SharpnessFilter());
        }

        private void cерыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new GrayWorldFilter());
        }

        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new DilationFilter());
        }

        private void сужениеErosiumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new ErosionFilter());
        }

        private void boxFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new MedianaFilter());
        }

        private void замыканиеClosingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new ClosingFilter());
        }

        private void размыканиеOpeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new OpeningFilter());
        }

        private void инструментToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KG1.Instarument dialog = new Instarument();
            dialog.Owner = this;
            dialog.ShowDialog();
        }
        private void topHatToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new TopHat());
        }
    }
}
