using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;


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
        }
    }
}

namespace Downloader
{
    class Program
    {
        static void Main(string[] args)
        {
            int FM = 749;
            int MW = 366;
            int NA = 532;
            int RM = 333;
            int TD = 267;
            int i = 0;
            int urlnumb = 1;
            string htmldefiner = "html";

            while (i < FM+1)
            {
                using var client = new WebClient();
                client.Headers.Add("User-Agent", "C# console program");

                string url = "http://localhost:7211/database/resource/pk/" + urlnumb;
                string content = client.DownloadString(url);

                if (content.Contains(htmldefiner))
                {
                    string savedirectory = @"C:/Temp/" + i + ".html";
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
            int FM = 749;
            int MW = 366;
            int NA = 532;
            int RM = 333;
            int TD = 267;
            int i = 0;
            while(i < FM+1)
            {
                if (File.Exists(@"C:/Temp/" + i + ".html"))
                {
                    string text = File.ReadAllText(@"C:/Temp/" + i + ".html");
                    text = text.Replace("localhost/", "localhost:7211/");
                    File.WriteAllText("C:/Temp/fixed" + i + ".html", text);
                    i++;
                }
            }
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


            int i = 0;

            while(i < 5)
            {
                string filepath = "file:///C:/Temp/fixed" + i + ".html\"";
                string cmd = "cd C:/Temp\nRUNDLL32.EXE MSHTML.DLL,PrintHTML \"" + filepath;
                File.WriteAllText(@"C:/Temp/Printer.bat", cmd);
                Process.Start(@"C:/Temp/Printer.bat");
                System.Threading.Thread.Sleep(5000); 
                SendKeys.SendWait("{Enter}");
                System.Threading.Thread.Sleep(1000);
                SendKeys.SendWait("{Enter}");
                System.Threading.Thread.Sleep(1000);
                SendKeys.SendWait(i.ToString());
                SendKeys.SendWait("{Enter}");
                i++;
            }
        }
    }
}

namespace combiner
{

}

namespace delete
{
    class deleteTemp
    {
        static void Main(string[] args)
        {
            System.IO.Directory.Delete("C:/Temp", true);
        }
    }
}

