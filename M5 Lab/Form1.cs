using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M5_Lab
{
    public partial class Form1 : Form
    {
        private static Form1 form = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form = this;
            try
            {
                string[] lines = File.ReadAllLines("C:/Users/Alex/source/repos/M5 Lab/M5 Lab/modules.txt");
                Array.Sort(lines);
                foreach (string line in lines)
                {
                    comboBox1.Items.Add(line);
                }
            } catch (Exception)
            {
                Console.WriteLine("File not found");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            COMP comp = new COMP(comboBox1.Text);
            
        }

        public double getTextBoxNumber()
        {
            return double.Parse(textBox1.Text);
        }

        public void setTextBoxNumber(double d)
        {
            textBox1.Text = d.ToString();
        }
        public void setTextBox(double d)
        {
            textBox1.Text = d.ToString();
        }

        public static Form1 getForm()
        {
            return form;
        }

        public void turnFormOff()
        {
            this.Close();
        }
    }
}
