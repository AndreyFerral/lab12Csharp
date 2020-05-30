using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12zad3
{
    public partial class Form1 : Form
    {
        public int w;
        public int h;
        public string nametxt;
        public int[] infotxt;

        Form2 form2 = new Form2();
        public string text = "";
        public Form1()
        {
            InitializeComponent();
            lineToolStripMenuItem.Enabled = false;
            barToolStripMenuItem.Enabled = false;
            this.w = this.Size.Width;
            this.h = this.Size.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void inputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                this.nametxt = Convert.ToString(streamReader.ReadLine());
                infotxt = new int[5];
                infotxt[0] = Convert.ToInt32(streamReader.ReadLine());
                infotxt[1] = Convert.ToInt32(streamReader.ReadLine());
                infotxt[2] = Convert.ToInt32(streamReader.ReadLine());
                infotxt[3] = Convert.ToInt32(streamReader.ReadLine());
                infotxt[4] = Convert.ToInt32(streamReader.ReadLine());

                streamReader.Close();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chooseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                lineToolStripMenuItem.Enabled = false;
                barToolStripMenuItem.Enabled = false;
                if (form2.ShowDialog(this) == DialogResult.OK) { }
                if (form2.Line) lineToolStripMenuItem.Enabled = true;
                if (form2.Bar) barToolStripMenuItem.Enabled = true;
            }
            catch { MessageBox.Show("Неверный формат в окне редактирования"); }
        }


        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.w = this.Size.Width;
            this.h = this.Size.Height;
            // Объявляем объект "g" класса Graphics и предоставляем
            // ему возможность рисования на pictureBox1:
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            Pen color;
            if (form2.Color == 0) { color = new Pen(Color.Red, 2); }
            else if (form2.Color == 1) { color = new Pen(Color.Green, 2); }
            else { color = new Pen(Color.Blue, 2); }

            Pen colorblack = new Pen(Color.Black, 2);

            Font font = new Font("Arial", 10);
            Font fontword = new Font("Arial", 16);
            SolidBrush brush = new SolidBrush(Color.Black);

            // тип и название
            g.DrawString("Линейный график", fontword, brush, 50, 5);
            g.DrawString(Convert.ToString(nametxt), fontword, brush, 50, 30);

            int coefY = 100;
            // обозначения на y
            for (int i = 0; i < 5; ++i)
            {
                if ((h >= 400 && h < 425)) coefY = 60;
                else if ((h >= 425 && h < 450)) coefY = 65;
                else if ((h >= 450 && h < 500)) coefY = 75;
                else if ((h >= 500 && h < 550)) coefY = 85;
                else if ((h >= 550 && h < 600)) coefY = 95;
                else coefY = 105;

                g.DrawString((5 - i).ToString(), font, brush, 20, i * coefY);
            }

            // обозначения на X
            int coefX = 100;
            for (int i = 1; i < 6; ++i)
            {
                if ((w >= 400 && w < 450)) coefX = 65;
                else if ((w >= 450 && w < 500)) coefX = 75;
                else if ((w >= 500 && w < 550)) coefX = 85;
                else if ((w >= 550 && w < 600)) coefX = 95;
                else coefX = 105;

                g.DrawString(i.ToString(), font, brush, i * coefX + coefX / 4, h - 90);
            }

            g.DrawLine(color, 1 * coefX + coefX / 4, coefY * (5 - infotxt[0]), 2 * coefX + coefX / 4, coefY * (5 - infotxt[1]));
            g.DrawLine(color, 2 * coefX + coefX / 4, coefY * (5 - infotxt[1]), 3 * coefX + coefX / 4, coefY * (5 - infotxt[2]));
            g.DrawLine(color, 3 * coefX + coefX / 4, coefY * (5 - infotxt[2]), 4 * coefX + coefX / 4, coefY * (5 - infotxt[3]));
            g.DrawLine(color, 4 * coefX + coefX / 4, coefY * (5 - infotxt[3]), 5 * coefX + coefX / 4, coefY * (5 - infotxt[4]));

            font.Dispose();
            brush.Dispose();

            // рисуем график
            g.DrawLine(colorblack, 50, 10, 50, h - 100);
            g.DrawLine(colorblack, 50, h - 100, w, h - 100);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(w + " " + h, "ширина, высота", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/

        private void barToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.w = this.Size.Width;
            this.h = this.Size.Height;

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            SolidBrush color;
            if (form2.Color == 0) { color = new SolidBrush(Color.Red); }
            else if (form2.Color == 1) { color = new SolidBrush(Color.Green); }
            else { color = new SolidBrush(Color.Blue); }

            Pen myWind = new Pen(Color.Black, 2);

            Font font = new Font("Arial", 10);
            Font fontword = new Font("Arial", 16);
            SolidBrush brush = new SolidBrush(Color.Black);

            // тип и название
            g.DrawString("Столбчатая диаграмма", fontword, brush, 50, 5);
            g.DrawString(Convert.ToString(nametxt), fontword, brush, 50, 30);

            float coefY = 100;
            // обозначения на y
            for (int i = 0; i < 5; ++i)
            {
                if ((h >= 400 && h < 425)) coefY = 60;
                else if ((h >= 425 && h < 450)) coefY = 65;
                else if ((h >= 450 && h < 500)) coefY = 75;
                else if ((h >= 500 && h < 550)) coefY = 85;
                else if ((h >= 550 && h < 600)) coefY = 95;
                else coefY = 105;

                g.DrawString((5 - i).ToString(), font, brush, 20, i * (float)coefY);
            }

            // обозначения на X
            float coefX = 100;
            for (int i = 1; i < 6; ++i)
            {
                if ((w >= 400 && w < 450)) coefX = 65;
                else if ((w >= 450 && w < 500)) coefX = 75;
                else if ((w >= 500 && w < 550)) coefX = 85;
                else if ((w >= 550 && w < 600)) coefX = 95;
                else coefX = 105;
                g.DrawString(i.ToString(), font, brush, i * coefX + coefX / 4, h - 90);

                float prm = infotxt[i - 1] * coefY;
                g.FillRectangle(color, i * coefX, h - (prm + 100), 60 * coefX / 100, prm);

            }
            font.Dispose();
            brush.Dispose();

            // рисуем график
            g.DrawLine(myWind, 50, 10, 50, h - 100);
            g.DrawLine(myWind, 50, h - 100, w, h - 100);
        }
    }
}
