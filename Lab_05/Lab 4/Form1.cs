using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> words = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog chosefile = new OpenFileDialog();
            chosefile.Filter = "текстовые файлы|*.txt";
            if (chosefile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button2.Enabled = true;
                textBox5.Enabled = true;
                button3.Enabled = true;
                string text = File.ReadAllText(chosefile.FileName);
                char[] sep = { ' ', '.', ',', '!', '?', '/', '\t', '\n' };
                string[] WordInText = text.Split(sep);
                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                foreach (string str in WordInText)
                {
                    string temp = str.Trim();
                    if (!words.Contains(temp))
                    {
                        words.Add(temp);
                        listBox1.Items.Add(temp);
                    }
                }
                listBox1.EndUpdate();
            }
            else
            {
                MessageBox.Show("Выберите файл");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string word1 = textBox2.Text.Trim();
            string word2 = textBox1.Text.Trim();
            string word = textBox2.Text.Trim();
            if (!string.IsNullOrWhiteSpace(word1) && !string.IsNullOrWhiteSpace(word2) && words.Count > 0)
            {
                Stopwatch time = new Stopwatch();
                time.Start();
                textBox3.Text = Distance.CountDistance(word1, word2).ToString();
                time.Stop();
                textBox4.Text = time.Elapsed.ToString();
             }
            else
            {
                MessageBox.Show("Введите слово для поиска");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int max = int.Parse(textBox5.Text.Trim());
            if (max >= 0 && words.Count > 0)
            {
                Stopwatch time = new Stopwatch();
                time.Start();
                listBox2.BeginUpdate();
                listBox2.Items.Clear();
                foreach (string word1 in words)
                {
                    foreach (string word2 in words)
                    {
                        if (word1 != word2)
                        {
                            int d = Distance.CountDistance(word1, word2);
                            if (d <= max)
                            {
                                string temp = word1 + " - " + word2 + " -> " + d.ToString(); 
                                listBox2.Items.Add(temp);
                            }
                        }
                    }
                }
                listBox2.EndUpdate();
                time.Stop();
                textBox6.Text = time.Elapsed.ToString();
            }
            else
            {
                MessageBox.Show("Введите максимальное значение");
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
