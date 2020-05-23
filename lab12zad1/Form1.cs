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

namespace lab12zad1
{
    public partial class Form1 : Form
    {
        public string text = "";
        public string word = "";
        public Form1()
        {
        InitializeComponent();
        
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void авToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void выфвToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);
                text = streamReader.ReadToEnd();
                streamReader.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void количествоСловToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CountAllWordInText = 0;
            try
            {
                if (text == "") throw new Exception("Вы не открыли файл"); ;
               
                for (int i = 0; i < text.Length; i++)
                {
                    if ((i < (text.Length - 1)))
                    {
                        if ((text[i] == ' ') && (text[i + 1] != ' ')) CountAllWordInText++;
                    }
                }
                MessageBox.Show(Convert.ToString(CountAllWordInText), "Количество слов в тексте", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void повторяемостьБуквToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (word == "" || text == "" ) throw new Exception("Вы не ввели букву/не открыли файл"); ;
                int CountNeedWord = 0;
                int startIndex = text.IndexOf(word);
                while (startIndex != -1)
                {
                    CountNeedWord++;
                    startIndex = text.IndexOf(word, startIndex + word.Length);
                }

                MessageBox.Show(Convert.ToString(CountNeedWord), "Повторяемость букв", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.MaxLength = 1;
            word = textBox1.Text;
        }

        private void папToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}