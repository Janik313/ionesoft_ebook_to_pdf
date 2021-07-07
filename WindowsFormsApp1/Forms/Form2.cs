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
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:/Temp/SelectedBook.txt", "FM");
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:/Temp/SelectedBook.txt", "RM");
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:/Temp/SelectedBook.txt", "MW");
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:/Temp/SelectedBook.txt", "NA");
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"C:/Temp/SelectedBook.txt", "TD");
            Form3 fm = new Form3();
            fm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.Directory.CreateDirectory("C:/Temp/custom");
            File.WriteAllText(@"C:/Temp/SelectedBook.txt", "CUSTOM");
            WindowsFormsApp1.Forms.Custom fm2 = new Forms.Custom();
            fm2.Show();
            this.Hide();
        }
    }
}
