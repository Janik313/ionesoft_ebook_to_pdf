﻿using System;
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
            if (SelectedBook == "CUSTOM")
            {
                string[] lines = File.ReadAllLines(@"C:/Temp/custom/custom.txt");

                int Sites = Int16.Parse(lines[1]);
                int Start = Int16.Parse(lines[2]);

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

                    string url = "http://localhost:7211/database/resource/pk/" + urlnumb;
                    string content = client.DownloadString(url);

                    if (content.Contains("Adobe Systems Incorporated"))
                    {
                        urlnumb++;
                    }
                    else if (content.Contains("http://www.monotype.com/html"))
                    {
                        urlnumb++;
                    }
                    else if (content.Contains("VeriSign Commercial Software Publishers"))
                    {
                        urlnumb++;
                    }
                    else if (content.Contains(htmldefiner))
                    {
                        string savedirectory = @"C:/Temp/original/" + i + ".html";
                        System.IO.File.WriteAllText(savedirectory, content);
                        i++;
                        urlnumb++;
                        progressBar1.PerformStep();
                    }
                    else
                    {
                        urlnumb++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Beim herunterladen des Buches ist ein Fehler eingetreten. Das bedeutet, dass das Endergebniss vielleicht nicht perfekt sein wird.", "Error", MessageBoxButtons.OK);
            }
            
            int FileCount = Directory.GetFiles(@"C:/Temp/original/").Length;
            i = 0;

            while (i < FileCount)
            {
                string text = File.ReadAllText(@"C:/Temp/original/" + i + ".html");
                text = text.Replace("localhost/", "localhost:7211/");
                text = text.Replace("Ã¼", "ü");
                text = text.Replace("Ã¤", "ä");
                text = text.Replace("Ã¶", "ö");
                text = text.Replace("Ãœ", "Ü");
                text = text.Replace("ÃŸ", "ß");
                text = text.Replace("â€¢", "•");
                text = text.Replace("â€¦", "...");
                text = text.Replace("â€ž", "„");
                text = text.Replace("â€œ", "“");
                text = text.Replace("Â", "");
                text = text.Replace("â€“", "-");
                text = text.Replace("Ã—", "×");
                text = text.Replace("Ã©", "é");
                text = text.Replace("â€™", "’");
                text = text.Replace("Î±", "α");
                text = text.Replace("ï¬", "f");
                text = text.Replace(@"width=""100%""", @"width=""1000%""");
                text = text.Replace(@"align=""left""", @"align=""right""");
                text = text.Replace(@"<img class=""_idGenObjectAttribute-1 _idGenObjectAttribute-2"" src=""http://localhost:7211/database/resource/pk/564"" data-original=""image/Kap1rechts.png"" alt="""" />", "");


                //text = text.Replace("", "Ö");
                //text = text.Replace("", "Ä");
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

