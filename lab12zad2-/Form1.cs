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

namespace lab12zad2_
{
    struct ZNAK
    {
        public string fam;
        public string znak;
        public int[] bdate;
        public ZNAK(string fam, string znak, int day, int month, int year)
        {
            this.fam = fam;
            this.znak = znak;
            this.bdate = new int[3];
            this.bdate[0] = day;
            this.bdate[1] = month;
            this.bdate[2] = year;
        }

        public string GetData()
        {
            return fam + " " + znak + " " + Convert.ToString(bdate[0]) + " " + Convert.ToString(bdate[1]) + " " + Convert.ToString(bdate[2]);
        }
        public string GetDataTXT()
        {
            return fam + " " + znak + " " + Convert.ToString(bdate[0]) + "" + Convert.ToString(bdate[1]) + "" + Convert.ToString(bdate[2]);
        }

    };

    public partial class Form1 : Form
    {
        public string find;
        List<ZNAK> znak = new List<ZNAK>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 2;
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.MaxLength = 2;
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.MaxLength = 4;
        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            find = textBox13.Text;
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void lbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                znak.Add(new ZNAK(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text)));
                MessageBox.Show("Данные успешно записаны!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked && radioButton4.Checked)
                    znak.Sort((ZNAK a, ZNAK b) => { return a.fam.CompareTo(b.fam); });

                else if (radioButton1.Checked && radioButton5.Checked)
                    znak.Sort((ZNAK a, ZNAK b) => { return b.fam.CompareTo(a.fam); });

                else if (radioButton2.Checked && radioButton4.Checked)
                    znak.Sort((ZNAK a, ZNAK b) => { return a.znak.CompareTo(b.znak); });

                else if (radioButton2.Checked && radioButton5.Checked)
                    znak.Sort((ZNAK a, ZNAK b) => { return b.znak.CompareTo(a.znak); });

                else if (radioButton3.Checked && radioButton4.Checked)
                {
                    znak.Sort((ZNAK a, ZNAK b) =>
                    {
                        if (a.bdate[0] > b.bdate[0]) return 1;
                        if (a.bdate[0] < b.bdate[0]) return -1;
                        return 0;
                    });
                }
                else if (radioButton3.Checked && radioButton5.Checked)
                {
                    znak.Sort((ZNAK a, ZNAK b) =>
                    {
                        if (a.bdate[0] > b.bdate[0]) return -1;
                        if (a.bdate[0] < b.bdate[0]) return 1;
                        return 0;
                    });
                }
                else throw new Exception("Вы не выбрали критерий/и для сортировки");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ZNAK elem in znak)
                {
                    if (textBox11.Text == elem.fam &&
                        textBox10.Text == elem.znak &&
                        textBox9.Text == Convert.ToString(elem.bdate[0]) &&
                        textBox8.Text == Convert.ToString(elem.bdate[1]) &&
                        textBox7.Text == Convert.ToString(elem.bdate[2]))
                    {
                        znak.Remove(elem);
                        MessageBox.Show("Данные успешно удалены!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton6.Checked)
                {
                    if (MessageBox.Show("Очистить контейнер перед считыванием из файла?", "question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) znak.Clear();
                    int BdateTXT = 0;
                    ZNAK elem = new ZNAK();
                    StreamReader streamReader = new StreamReader(textBox12.Text);
                    while (!streamReader.EndOfStream)
                    {
                        elem.fam = "";
                        elem.znak = "";

                        while (streamReader.Peek() != ' ') elem.fam += Convert.ToChar(streamReader.Read());
                        elem.fam += Convert.ToChar(streamReader.Read()); // фио
                        while (streamReader.Peek() != ' ') elem.fam += Convert.ToChar(streamReader.Read());
                        streamReader.Read();
                        
                        while (streamReader.Peek() != ' ')
                            elem.znak += Convert.ToChar(streamReader.Read()); // знак
                        streamReader.Read();
                        
                        BdateTXT = Convert.ToInt32(streamReader.ReadLine());
                        elem.bdate = new int[3];
                        elem.bdate[2] = BdateTXT % 10000; // год
                        BdateTXT = BdateTXT / 10000;
                        elem.bdate[0] = BdateTXT / 100; // день
                        elem.bdate[1] = BdateTXT % 100; // месяц
                        znak.Add(elem);
                    }
                    streamReader.Close();
                    MessageBox.Show("Данные успешно считаны!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (radioButton7.Checked)
                {
                    StreamWriter streamWriter = new StreamWriter(textBox12.Text);
                    foreach (ZNAK elem in znak) streamWriter.WriteLine(elem.GetDataTXT());
                    streamWriter.Close();
                    MessageBox.Show("Данные успешно записаны!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else throw new Exception("Выберите действие");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lbFind.Items.Clear();
            if (radioButton8.Checked)
            {
                foreach (ZNAK elem in znak)
                {
                    if (find == elem.fam)
                    {
                        lbFind.Items.Add(elem.GetData());
                    }
                }
            }
            if (radioButton9.Checked)
            {
                foreach (ZNAK elem in znak)
                {
                    if (find == elem.znak)
                    {
                        lbFind.Items.Add(elem.GetData());
                    }
                }
            }
            if (radioButton10.Checked)
            {
                foreach (ZNAK elem in znak)
                {
                    if (find == Convert.ToString(elem.bdate[0]))
                    {
                        lbFind.Items.Add(elem.GetData());
                    }
                }
            }
            if (radioButton12.Checked)
            {
                foreach (ZNAK elem in znak)
                {
                    if (find == Convert.ToString(elem.bdate[1]))
                    {
                        lbFind.Items.Add(elem.GetData());
                    }
                }
            }
            if (radioButton13.Checked)
            {
                foreach (ZNAK elem in znak)
                {
                    if (find == Convert.ToString(elem.bdate[2]))
                    {
                        lbFind.Items.Add(elem.GetData());
                    }
                }
            }
            if (radioButton11.Checked)
            {
                foreach (ZNAK elem in znak)
                {
                    lbFind.Items.Add(elem.GetData());
                }
            }
        }

        private void lbFind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
