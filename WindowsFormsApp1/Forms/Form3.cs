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
            string SelectedBook = File.ReadAllText(@"C:/Temp/SelectedBook.txt");
            int FileCount = Directory.GetFiles(@"C:/Temp/original/").Length;
            int i = 0;

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
                    text = text.Replace(@"<img class=""_idGenObjectAttribute-1 _idGenObjectAttribute-2"" src=""http://localhost:7211/database/resource/pk/564"" data-original=""image/Kap1rechts.png"" alt="""" />", "");


                    //text = text.Replace("", "Ö");
                    //text = text.Replace("", "Ä");
                    File.WriteAllText("C:/Temp/fixed/fixed" + i + ".html", text);
                    i++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SelectedBook = File.ReadAllText(@"C:/Temp/SelectedBook.txt");


            if (SelectedBook == "FM")
            {
                int FM = 704;
                int i = 0;
                int urlnumb = 1;
                string htmldefiner = "html";

                while (i < FM)
                {
                    using var client = new WebClient();
                    client.Headers.Add("User-Agent", "C# console program");

                    string url = "http://localhost:7211/database/resource/pk/" + urlnumb;
                    string content = client.DownloadString(url);

                    if (content.Contains("Adobe Systems Incorporated"))
                    {
                        urlnumb++;
                    }else if (content.Contains("http://www.monotype.com/html"))
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
                    }
                    else
                    {
                        urlnumb++;
                    }
                }



            }
            if (SelectedBook == "TD")
            {
                int TD = 259;
                int i = 0;
                int urlnumb = 14830;
                string htmldefiner = "html";

                while (i < TD)
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
                    }else if(content.Contains("Adobe XMP Core"))
                    {
                        urlnumb++;
                    }
                    else if (content.Contains(htmldefiner))
                    {
                        string savedirectory = @"C:/Temp/original/" + i + ".html";
                        System.IO.File.WriteAllText(savedirectory, content);
                        i++;
                        urlnumb++;
                    }
                    else
                    {
                        urlnumb++;
                    }
                }
            }
            if (SelectedBook == "RM")
            {

                int RM = 340;
                int i = 0;
                int urlnumb = 11264;
                string htmldefiner = "html";

                while (i < RM)
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
                    }
                    else
                    {
                        urlnumb++;
                    }
                }
            }
            if (SelectedBook == "NA")
            {

                int NA = 524;
                int i = 0;
                int urlnumb = 7491;
                string htmldefiner = "html";

                while (i < NA)
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
                    }
                    else
                    {
                        urlnumb++;
                    }
                }
            }
            if (SelectedBook == "MW")
            {
                int MW = 373;
                int i = 0;
                int urlnumb = 4749;
                string htmldefiner = "html";

                while (i < MW)
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
                    }
                    else
                    {
                        urlnumb++;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 fm = new Form4();
            fm.Show();
            this.Hide();
        }
    }
}

