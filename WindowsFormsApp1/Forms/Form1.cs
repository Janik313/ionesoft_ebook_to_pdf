﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                try
                {
                    System.Diagnostics.Process.Start("D:/Apps/Swissmem/Swissmem.exe");
                }
                catch (Exception)
                {
                    System.Diagnostics.Process.Start("C:/Apps/Swissmem/Swissmem.exe");
                }
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                System.IO.Directory.CreateDirectory("C:/Temp");
                System.IO.Directory.CreateDirectory("C:/Temp/pdf");
                System.IO.Directory.CreateDirectory("C:/Temp/original");
                System.IO.Directory.CreateDirectory("C:/Temp/fixed");
            }

            Form2 fm = new Form2();
            fm.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }

}
