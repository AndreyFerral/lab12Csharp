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

namespace Lab12_2_
{
	struct Worker
	{
		public string fam;
		public string post;
		public int year;

		public Worker(string fam, string post, int year)
		{
			this.fam = fam;
			this.post = post;
			this.year = year;
		}

		public string GetData()
		{
			return fam + " " + post + " " + Convert.ToString(year);
		}
	};


	public partial class Form1 : Form
	{
		List<Worker> workers = new List<Worker>();

		public Form1()
		{
			InitializeComponent();
		}
		private void bAdd_Click(object sender, EventArgs e)
		{
			try
			{
				workers.Add(new Worker(tbFam1.Text, tbPost1.Text, Convert.ToInt32(tbYear1.Text)));
				MessageBox.Show("Данные успешно записаны!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

		}
		private void Bdelete_Click(object sender, EventArgs e)
		{
			try
			{
				foreach (Worker worker in workers)
				{
					if (tbFam3.Text == worker.fam &&
						tbPost3.Text == worker.post &&
						tbYear3.Text == Convert.ToString(worker.year))
					{
						workers.Remove(worker);
						MessageBox.Show("Данные успешно удалены!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						break;
					}
				}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void bExecuteFile_Click(object sender, EventArgs e)
		{
			try
			{
				if (rbRead.Checked)
				{
					if (MessageBox.Show("Очистить контейнер перед считыванием из файла?", "question",
						MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) workers.Clear();

					Worker worker = new Worker();
					StreamReader streamReader = new StreamReader(tbPath.Text);
					while (!streamReader.EndOfStream)
					{
						worker.fam = "";
						worker.post = "";
						// фамилия инциалы
						while (streamReader.Peek() != ' ') worker.fam += Convert.ToChar(streamReader.Read());
						worker.fam += Convert.ToChar(streamReader.Read());
						while (streamReader.Peek() != ' ') worker.fam += Convert.ToChar(streamReader.Read());
						streamReader.Read();
						// должность
						while (streamReader.Peek() != ' ')
							worker.post += Convert.ToChar(streamReader.Read());
						streamReader.Read();
						// год
						worker.year = Convert.ToInt32(streamReader.ReadLine());
						workers.Add(worker);
					}
					streamReader.Close();
					MessageBox.Show("Данные успешно считаны!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					StreamWriter streamWriter = new StreamWriter(tbPath.Text);
					foreach (Worker worker in workers) streamWriter.WriteLine(worker.GetData());
					streamWriter.Close();
					MessageBox.Show("Данные успешно записаны!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void bOutput_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbValue.Checked)
				{
					int workExperience;
					workExperience = Convert.ToInt32(tbValue.Text);
					lbOutput.Items.Clear();
					bool not_found = false;
					foreach (Worker worker in workers)
					{
						if ((DateTime.Today.Year - worker.year) > workExperience)
						{
							lbOutput.Items.Add(worker.GetData());
							not_found = true;
						}
					}
					if (not_found == false)
						MessageBox.Show("Таких работников нет!", "fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}
		private void bFind_Click(object sender, EventArgs e)
		{
			lbFind.Items.Clear();
			if (cbOutputAll.Checked)
			{
				foreach (Worker worker in workers) lbFind.Items.Add(worker.GetData());
			}
			if (cbFam.Checked)
			{
				foreach (Worker worker in workers)
				{
					if (tbFam2.Text == worker.fam)
					{
						lbFind.Items.Add(worker.GetData());
					}
				}
			}
			if (cbPost.Checked)
			{
				foreach (Worker worker in workers)
				{
					if (tbPost2.Text == worker.post)
					{
						lbFind.Items.Add(worker.GetData());
					}
				}
			}
			if (cbYear.Checked)
			{
				foreach (Worker worker in workers)
				{
					if (tbYear2.Text == Convert.ToString(worker.year))
					{
						lbFind.Items.Add(worker.GetData());
					}
				}
			}

		}

		private void bSort_Click(object sender, EventArgs e)
		{
			if (rbFam.Checked && rbIncrease.Checked)
				workers.Sort((Worker a, Worker b) => { return a.fam.CompareTo(b.fam); });

			if (rbFam.Checked && rbDecrease.Checked)
				workers.Sort((Worker a, Worker b) => { return b.fam.CompareTo(a.fam); });

			if (rbPost.Checked && rbIncrease.Checked)
				workers.Sort((Worker a, Worker b) => { return a.post.CompareTo(b.post); });

			if (rbPost.Checked && rbDecrease.Checked)
				workers.Sort((Worker a, Worker b) => { return b.post.CompareTo(a.post); });

			if (rbYear.Checked && rbIncrease.Checked)
			{
				workers.Sort((Worker a, Worker b) => {
					if (a.year > b.year) return 1;
					if (a.year < b.year) return -1;
					return 0;
				});
			}
			if (rbYear.Checked && rbDecrease.Checked)
			{
				workers.Sort((Worker a, Worker b) => {
					if (a.year > b.year) return -1;
					if (a.year < b.year) return 1;
					return 0;
				});
			}
		}
		private void cbValue_CheckedChanged(object sender, EventArgs e)
		{
			if (cbValue.Checked) tbValue.Enabled = true;
			else tbValue.Enabled = false;
		}
		private void cbOutputAll_CheckedChanged(object sender, EventArgs e)
		{
			if (cbOutputAll.Checked)
			{
				cbFam.Enabled = false;
				cbPost.Enabled = false;
				cbYear.Enabled = false;
				cbFam.Checked = false;
				cbPost.Checked = false;
				cbYear.Checked = false;
			}
			else
			{
				cbFam.Enabled = true;
				cbPost.Enabled = true;
				cbYear.Enabled = true;
			}
		}

		private void cbFam_CheckedChanged(object sender, EventArgs e)
		{
			if (cbFam.Checked) tbFam2.Enabled = true;
			else tbFam2.Enabled = false;
		}

		private void cbPost_CheckedChanged(object sender, EventArgs e)
		{
			if (cbPost.Checked) tbPost2.Enabled = true;
			else tbPost2.Enabled = false;
		}

		private void cbYear_CheckedChanged(object sender, EventArgs e)
		{
			if (cbYear.Checked) tbYear2.Enabled = true;
			else tbYear2.Enabled = false;
		}

		private void lbOutput_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void rbIncrease_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void tbPath_TextChanged(object sender, EventArgs e)
		{

		}
	}
}