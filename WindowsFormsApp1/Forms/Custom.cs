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

namespace WindowsFormsApp1.Forms
{
    public partial class Custom : Form
    {
        public Custom()
        {
            InitializeComponent();
        }

        string unit = "";
        int SiteCount = 0;
        int StartPoint = 0;
        int width = 0;
        int height = 0;
        string path = @"C:/Temp/";

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //seiten
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //start
            SiteCount = Int16.Parse(textBox1.Text);
            StartPoint = Int16.Parse(textBox2.Text);
            width = Int16.Parse(textBox4.Text);
            height = Int16.Parse(textBox3.Text);

            string[] lines =
        {
            unit, SiteCount.ToString(), StartPoint.ToString(), width.ToString(), height.ToString()
        };
            File.WriteAllLines(path + "custom.txt", lines);

            WindowsFormsApp1.Form3 fm2 = new Form3();
            fm2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //test
            SiteCount = Int16.Parse(textBox1.Text);
            StartPoint = Int16.Parse(textBox2.Text);
            width = Int16.Parse(textBox4.Text);
            height = Int16.Parse(textBox3.Text);

            string[] lines =
        {
            unit, SiteCount.ToString(), StartPoint.ToString(), width.ToString(), height.ToString()
        };
            File.WriteAllLines(path + "custom.txt", lines);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            unit = "mm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            unit = "px";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //startpunkt
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //height
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //width
        }
    }
}
