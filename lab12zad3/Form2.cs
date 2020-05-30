using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab12zad3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            listBox1.Items.Add("Red");
            listBox1.Items.Add("Green");
            listBox1.Items.Add("Blue");
        }

        public bool Line
        {
            get { return radioButton1.Checked; }
        }
        public bool Bar
        {
            get { return radioButton2.Checked; }
        }
        public int Color
        {
            get { return listBox1.SelectedIndex; }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bOutput_Click(object sender, EventArgs e)
        {
            try
            {
                if ((radioButton1.Checked || radioButton2.Checked) && listBox1.SelectedIndex != -1) { this.Close(); }
                else throw new Exception("Вы не выбрали цвет/тип графика");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
