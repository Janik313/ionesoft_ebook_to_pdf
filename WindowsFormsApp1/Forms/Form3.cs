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
                    }else if (content.Contains(@"meta property=""dcterms: modified"">"))
                    {
                        urlnumb++;
                    }else if (content.Contains("http://purl.org/dc/elements/1.1/"))
                    {
                        urlnumb++;
                    }
                    else if (content.Contains("{line-height: 1.45; margin:0px; padding:0px; white-space: nowrap; width:22.92925em;"))
                    {
                        urlnumb++;
                    }
                    else if (content.Contains("-webkit-user-select:none"))
                    {
                        urlnumb++;
                    }
                    else if (content.Contains("nowrap; width:25.743126em; color: #000000"))
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
                text = text.Replace("î€€", ".");
                text = text.Replace("ïƒ°", "⇨");
                text = text.Replace("ïƒ", "→");
                text = text.Replace("α", "α");
                text = text.Replace("Ã¸", "ø");
                text = text.Replace("âˆ†", "∆");
                text = text.Replace("Ã–", "Ö");
                text = text.Replace("Ï‘", "ϑ");
                text = text.Replace("â‡’", "⇒");
                text = text.Replace("Ã„", "Ä");
                text = text.Replace("â†’", "→");
                text = text.Replace("ï¬‚", "fl");
                text = text.Replace("Î¨", "Ψ");
                text = text.Replace("ï£¨", "®");
                text = text.Replace("Îµ", "ε");
                text = text.Replace("Î»", "λ");
                text = text.Replace("Î·", "η");
                text = text.Replace("â‰ˆ", "≈");
                text = text.Replace("â‘", "①");
                text = text.Replace("â‘¡", "②");
                text = text.Replace("â‘¢", "③");
                text = text.Replace("â‘£", "④");
                text = text.Replace("â‘¤", "⑤");
                text = text.Replace("â‘¥", "⑥");
                text = text.Replace("â‘¦", "⑦");
                text = text.Replace("â‘§", "⑧");
                text = text.Replace("â‘¨", "⑨");
                text = text.Replace("â‘©", "⑩");
                text = text.Replace("â‘ª", "⑪");
                text = text.Replace("â‘«", "⑫");
                text = text.Replace("â‰™", "≙");

                text = text.Replace("Î„", "΄");
                text = text.Replace("Ë", "˝");
                text = text.Replace("âˆš", "√");
                text = text.Replace("â‰¥", "≥");
                text = text.Replace("â—¯", "◯");
                text = text.Replace("â€", "”");
                text = text.Replace("Î£", "Σ");
                text = text.Replace("âŒ€", "ø");
                text = text.Replace("Î”", "Δ");
                text = text.Replace("â€˜s", "‘");
                text = text.Replace("Ïƒ", "σ");
                text = text.Replace("µË†", "µˆ");
                text = text.Replace("ÏƒË†", "σˆ");
                text = text.Replace("Ëœ", "˜");



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

