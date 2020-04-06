using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KG1
{
    public partial class Instarument : Form
    {
        public Button[,] Pixels;

        int SizeX = Mask.SizeX;
        int SizeY = Mask.SizeY;

        public Instarument()
        {
            InitializeComponent();

            textSizeX.Text = Mask.SizeX.ToString();
            textSizeY.Text = Mask.SizeY.ToString();

            GridInit();
        }

        public void GridInit()
        {
            Palette.Controls.Clear();

            SizeX = Mask.SizeX;
            SizeY = Mask.SizeY;

            int Offset = 10;
            int Width = (Palette.Width - Offset * (SizeX - 1)) / SizeX;
            int Height = (Palette.Height - Offset * (SizeY - 1)) / SizeY;

            Pixels = new Button[SizeX, SizeY];

            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    Pixels[i, j] = new Button();
                    Pixels[i, j].Text = "";
                    Pixels[i, j].Size = new Size(Width, Height);
                    Pixels[i, j].Location = new Point(i * (Width + Offset), j * (Height + Offset));
                    Pixels[i, j].BackColor = Mask.map[i, j] ? Color.Black : Color.White;
                    Pixels[i, j].Click += DetectChanges;

                    this.Palette.Controls.Add(Pixels[i, j]);
                }
            }
        }

        public void DetectChanges(object sender, EventArgs e)
        {
            for (int i = 0; i < SizeX; i++)
            {
                for (int j = 0; j < SizeY; j++)
                {
                    if (Pixels[i, j] == ((Button)sender))
                    {
                        Mask.map[i, j] = !Mask.map[i, j];
                        Pixels[i, j].BackColor = Mask.map[i, j] ? Color.Black : Color.White;
                        break;
                    }
                }
            }
        }

        private void buttonLockSize_Click(object sender, EventArgs e)
        {
            Mask.SizeX = Convert.ToInt32(textSizeX.Text) | 0;
            Mask.SizeY = Convert.ToInt32(textSizeY.Text) | 0;

            Mask.Reload();

            GridInit();
        }
    }
}
