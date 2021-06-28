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
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}


namespace ProgramStart
{
    class Start
{
    static void Main(string[] args)
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
}
}

namespace create
{
    class createTemp
    {
        static void Main(string[] args)
        {
            System.IO.Directory.CreateDirectory("C:/Temp");
            System.IO.Directory.CreateDirectory("C:/Temp/pdf");
            System.IO.Directory.CreateDirectory("C:/Temp/original");
            System.IO.Directory.CreateDirectory("C:/Temp/fixed");
            System.IO.Directory.CreateDirectory("C:/Temp/bat");
        }
    }
}

namespace Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            int FM = 703;
            int MW = 366;
            int NA = 532;
            int RM = 333;
            int TD = 267;
            int i = 0;
            int urlnumb = 1;
            string htmldefiner = "html";

            while (i < FM + 1)
            {
                using var client = new WebClient();
                client.Headers.Add("User-Agent", "C# console program");

                string url = "http://localhost:7211/database/resource/pk/" + urlnumb;
                string content = client.DownloadString(url);

                if (content.Contains("Adobe Systems Incorporated"))
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
}

namespace fix
{
    class FixHtml
    {
        static void Main(string[] args)
        {
            int FM = 703;
            int MW = 366;
            int NA = 532;
            int RM = 333;
            int TD = 267;
            int i = 0;

            while (i < FM + 1)
            {
                if (File.Exists(@"C:/Temp/original/" + i + ".html"))
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
                    text = text.Replace(@"<img class=""_idGenObjectAttribute-1 _idGenObjectAttribute-2"" src=""http://localhost:7211/database/resource/pk/564"" data-original=""image/Kap1rechts.png"" alt="""" />", "");


                    //text = text.Replace("", "Ö");
                    //text = text.Replace("", "Ä");
                    File.WriteAllText("C:/Temp/fixed/fixed" + i + ".html", text);
                    i++;
                }
            }
        }
    }
}

namespace wkhtmlinstaller
{
    class install
    {
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile("https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox-0.12.6-1.msvc2015-win64.exe", @"C:/Temp/wkhtmltopdf.exe");
            System.Threading.Thread.Sleep(1000);
            Process.Start(@"C:/Temp/wkhtmltopdf.exe");
        }
    }
}

namespace Converter
{
    class Html_to_Pdf
    {
        public static class PrinterClass
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Printer);
        }
        static void Main(string[] args)
        {

            PrinterClass.SetDefaultPrinter("Microsoft Print to PDF");

            int FM = 703;
            int MW = 366;
            int NA = 532;
            int RM = 333;
            int TD = 267;

            int i = 0;
            int filename = 001;

            while (i < FM + 1)
            {
                string filepath = "C:/Temp/fixed/fixed" + i + ".html";
                string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                string cmd = "C:\ncd C:/Program Files/wkhtmltopdf/bin";
                string cmd2 = "\nstart wkhtmltopdf.exe --page-size A6 --margin-bottom 0 --margin-left 0 --margin-right 0 --margin-top 0 " + filepath + " " + exportpath;
                File.WriteAllText(@"C:/Temp/bat/" + i + ".bat", cmd + cmd2);
                Process.Start(@"C:/Temp/bat/" + i + ".bat");
                i++;
                filename++;

                //Alter Code, welcher vielleicht wiederverwendet wird.
                //System.Threading.Thread.Sleep(1500);
                //SendKeys.SendWait("^{P}");
                //System.Threading.Thread.Sleep(500);
                //SendKeys.SendWait("{Enter}");
                //System.Threading.Thread.Sleep(2000);
                //SendKeys.SendWait(i.ToString());
                //System.Threading.Thread.Sleep(500);
                //SendKeys.SendWait("{Enter}");
                //System.Threading.Thread.Sleep(2000);
            }
        }
    }
}

namespace combiner
{
    class combine
    {
        static void Main(string[] args)
        {
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
        }
    }
}

namespace delete
{
    class deleteTemp
    {
        static void Main(string[] args)
        {
            System.IO.Directory.Delete("C:/Temp/bat", true);
            System.IO.Directory.Delete("C:/Temp/fixed", true);
            System.IO.Directory.Delete("C:/Temp/original", true);
            System.IO.Directory.Delete("C:/Temp/pdf", true);
        }
    }
}
