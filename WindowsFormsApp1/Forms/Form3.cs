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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SelectedBook = File.ReadAllText(@"C:/Temp/SelectedBook.txt");
            int urlnumb = 0;
            int Book = 0;

            if (SelectedBook == "FM")
            {
                int FM = 704;
                int FM2 = 1;

                Book = FM;
                urlnumb = FM2;

            }
            if (SelectedBook == "TD")
            {
                int TD = 259;
                int TD2 = 14830;
                Book = TD;
                urlnumb = TD2;

            }
            if (SelectedBook == "RM")
            {

                int RM = 331;
                int RM2 = 11264;
                Book = RM;
                urlnumb = RM2;

            }
            if (SelectedBook == "NA")
            {

                int NA = 532;
                int NA2 = 7491;

                Book = NA;
                urlnumb = NA2;
            }
            if (SelectedBook == "MW")
            {
                int MW = 366;
                int MW2 = 4749;
                Book = MW;
                urlnumb = MW2;
                
            }
            if (SelectedBook == "CUSTOM")
            {
                string[] lines = File.ReadAllLines(@"C:/Temp/custom.txt");

                int Sites = Int32.Parse(lines[1]);
                int Start = Int32.Parse(lines[2]);

                Book = Sites;
                urlnumb = Start;
            }



            progressBar1.Maximum = Book * 2;
            progressBar1.Minimum = 1;
            progressBar1.Visible = true;
            progressBar1.Step = 1;

            
            

            int i = 0;
            string htmldefiner = "html";
            try
            {
                while (i < Book)
                {
                    using var client = new WebClient();
                    client.Headers.Add("User-Agent", "C# console program");
                    client.Encoding = System.Text.Encoding.UTF8;
                    
                    if (SelectedBook == "TD")
                    {
                        if (urlnumb == 14853)
                        {
                            urlnumb++;
                        }
                    }

                    string url = "http://localhost:7211/database/resource/pk/" + urlnumb;
                    string content = client.DownloadString(url);

                    
                    string[] blocks = File.ReadAllLines(@"C:/Temp/blocked.txt");
                    


                    foreach (string forbidden in blocks)
                    {
                        if (content.Contains(forbidden))
                        {
                            urlnumb++;
                            break;
                        }else if (content.Contains(htmldefiner))
                        {
                            string savedirectory = @"C:/Temp/original/" + i + ".html";
                            System.IO.File.WriteAllText(savedirectory, content);
                            i++;
                            urlnumb++;
                            progressBar1.PerformStep();
                            break;
                        }
                        else
                        {
                            urlnumb++;
                            break;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Beim herunterladen des Buches ist ein Fehler eingetreten. Das bedeutet, dass das Endergebniss vielleicht nicht perfekt sein wird.", "Error", MessageBoxButtons.OK);
            }
            
            int FileCount = Directory.GetFiles(@"C:/Temp/original/").Length;
            i = 0;

            string[] fix = File.ReadAllLines(@"C:/Temp/fix.txt");

            while (i < FileCount)
            {
                string text = File.ReadAllText(@"C:/Temp/original/" + i + ".html");
                foreach (string forbidden in fix)
                {
                    string[] words = forbidden.Split(' ');
                    text = text.Replace(words[0], words[1]);
                }
                File.WriteAllText("C:/Temp/fixed/fixed" + i + ".html", text);
                i++;
                progressBar1.PerformStep();
            }

            MessageBox.Show("Der Download ist abgeschlossen, du kannst nun fortfahren.", "Download Abgeschlossen", MessageBoxButtons.OK);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 fm = new Form5();
            fm.Show();
            this.Hide();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            string SelectedBook = File.ReadAllText(@"C:/Temp/SelectedBook.txt");
            int urlnumb = 0;
            int Book = 0;

            if (SelectedBook == "FM")
            {
                int FM = 704;
                int FM2 = 1;

                Book = FM;
                urlnumb = FM2;

            }
            if (SelectedBook == "TD")
            {
                int TD = 260;
                int TD2 = 14830;
                Book = TD;
                urlnumb = TD2;

            }
            if (SelectedBook == "RM")
            {

                int RM = 333;
                int RM2 = 11264;
                Book = RM;
                urlnumb = RM2;

            }
            if (SelectedBook == "NA")
            {

                int NA = 532;
                int NA2 = 7491;

                Book = NA;
                urlnumb = NA2;
            }
            if (SelectedBook == "MW")
            {
                int MW = 366;
                int MW2 = 4749;
                Book = MW;
                urlnumb = MW2;

            }
            progressBar1.Maximum = Book * 2;
            progressBar1.Minimum = 1;
            progressBar1.Visible = true;
            progressBar1.Step = 1;


        }
    }
}

