﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            static void Main(string[] args)
            {
                int FileCount = Directory.GetFiles(@"C:/Temp/fixed/").Length;
                int i = 0;
                int filename = 001;

                while (i < FileCount + 1)
                {
                    string filepath = "C:/Temp/fixed/fixed" + i + ".html";
                    string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                    string cmd = "C:\ncd C:/Program Files/wkhtmltopdf/bin";
                    string cmd2 = "\nstart wkhtmltopdf.exe --page-size A6 --margin-bottom 0 --margin-left 0 --margin-right 0 --margin-top 0 " + filepath + " " + exportpath;
                    File.WriteAllText(@"C:/Temp/bat/" + i + ".bat", cmd + cmd2);
                    Process.Start(@"C:/Temp/bat/" + i + ".bat");
                    i++;
                    filename++;
                }


                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            string[] pdfs = Directory.GetFiles(@"C:/Temp/pdf/", "*.pdf*", SearchOption.AllDirectories);

            string targetPath = @"C:/Temp/combined.pdf";
            using (var targetDoc = new PdfDocument())
            {
                foreach (var pdf in pdfs)
                {
                    using (var pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (var i = 0; i < pdfDoc.PageCount; i++)
                            targetDoc.AddPage(pdfDoc.Pages[i]);
                    }
                }
                targetDoc.Save(targetPath);
            }
            System.Threading.Thread.Sleep(15000);
            System.Windows.Forms.Application.ExitThread();
        }
    }
}
