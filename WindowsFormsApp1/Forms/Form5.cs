using System;
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

                string SelectedBook = File.ReadAllText(@"C:/Temp/SelectedBook.txt");
                int FileCount = Directory.GetFiles(@"C:/Temp/fixed/").Length;
                int i = 0;
                int filename = 001;
            if (SelectedBook == "FM")
            {
                while (i < FileCount + 1)
                {
                    string filepath = "C:/Temp/fixed/fixed" + i + ".html";
                    string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                    string cmd = "C:\ncd C:/Program Files/wkhtmltopdf/bin";
                    string cmd2 = "\nstart wkhtmltopdf.exe --page-width 482px --page-height 680px --margin-bottom 0 --margin-left 0 --margin-right 0 --margin-top 0 " + filepath + " " + exportpath;
                    File.WriteAllText(@"C:/Temp/bat/" + i + ".bat", cmd + cmd2);
                    Process.Start(@"C:/Temp/bat/" + i + ".bat");
                    i++;
                    filename++;
                }
            }
            else if (SelectedBook == "TD")
            {
                while (i < FileCount + 1)
                {
                    string filepath = "C:/Temp/fixed/fixed" + i + ".html";
                    string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                    string cmd = "C:\ncd C:/Program Files/wkhtmltopdf/bin";
                    string cmd2 = "\nstart wkhtmltopdf.exe --page-width 595px --page-height 842 --margin-bottom 0 --margin-left 0 --margin-right 0 --margin-top 0 " + filepath + " " + exportpath;
                    File.WriteAllText(@"C:/Temp/bat/" + i + ".bat", cmd + cmd2);
                    Process.Start(@"C:/Temp/bat/" + i + ".bat");
                    i++;
                    filename++;
                }
            }
            else if (SelectedBook == "MW")
            {
                while (i < FileCount + 1)
                {
                    string filepath = "C:/Temp/fixed/fixed" + i + ".html";
                    string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                    string cmd = "C:\ncd C:/Program Files/wkhtmltopdf/bin";
                    string cmd2 = "\nstart wkhtmltopdf.exe --page-width 595px --page-height 842 --margin-bottom 0 --margin-left 0 --margin-right 0 --margin-top 0 " + filepath + " " + exportpath;
                    File.WriteAllText(@"C:/Temp/bat/" + i + ".bat", cmd + cmd2);
                    Process.Start(@"C:/Temp/bat/" + i + ".bat");
                    i++;
                    filename++;
                }
            }
            else if (SelectedBook == "NA")
            {
                while (i < FileCount + 1)
                {
                    string filepath = "C:/Temp/fixed/fixed" + i + ".html";
                    string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                    string cmd = "C:\ncd C:/Program Files/wkhtmltopdf/bin";
                    string cmd2 = "\nstart wkhtmltopdf.exe --page-width 439px --page-height 595px --margin-bottom 0 --margin-left 0 --margin-right 0 --margin-top 0 " + filepath + " " + exportpath;
                    File.WriteAllText(@"C:/Temp/bat/" + i + ".bat", cmd + cmd2);
                    Process.Start(@"C:/Temp/bat/" + i + ".bat");
                    i++;
                    filename++;
                }
            }
            else if (SelectedBook == "RM")
            {
                while (i < FileCount + 1)
                {
                    string filepath = "C:/Temp/fixed/fixed" + i + ".html";
                    string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                    string cmd = "C:\ncd C:/Program Files/wkhtmltopdf/bin";
                    string cmd2 = "\nstart wkhtmltopdf.exe --page-width 736px --page-height 1039 --margin-bottom 0 --margin-left 0 --margin-right 0 --margin-top 0 " + filepath + " " + exportpath;
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
            System.Threading.Thread.Sleep(15000);
            System.IO.Directory.Delete("C:/Temp/bat", true);
            System.IO.Directory.Delete("C:/Temp/fixed", true);
            System.IO.Directory.Delete("C:/Temp/original", true);
            System.IO.Directory.Delete("C:/Temp/pdf", true);
            System.Windows.Forms.Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string FileName = File.ReadAllText(@"C:/Temp/SelectedBook.txt");
            string[] pdfs = Directory.GetFiles(@"C:/Temp/pdf/", "*.pdf*", SearchOption.AllDirectories);

            string targetPath = @"C:/Temp/" + FileName + ".pdf";
            using (var targetDoc = new PdfDocument())
            {
                foreach (var pdf in pdfs)
                {
                    using (var pdfDoc = PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (var y = 0; y < pdfDoc.PageCount; y++)
                            targetDoc.AddPage(pdfDoc.Pages[y]);
                    }
                }
                targetDoc.Save(targetPath);
            }
            Process.Start(@"C:/Temp/" + FileName + ".pdf");
        }
    }

}
