﻿using System;
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
            System.IO.Directory.CreateDirectory("C:/Temp/pdf");
            System.IO.Directory.CreateDirectory("C:/Temp/original");
            System.IO.Directory.CreateDirectory("C:/Temp/fixed");
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
            int FM = 749;
            int MW = 366;
            int NA = 532;
            int RM = 333;
            int TD = 267;
            int i = 0;

            while(i < FM+1)
            {
                if (File.Exists(@"C:/Temp/original/" + i + ".html"))
                {
                    string text = File.ReadAllText(@"C:/Temp/original/" + i + ".html");
                    text = text.Replace("localhost/", "localhost:7211/");
                    File.WriteAllText("C:/Temp/fixed/fixed" + i + ".html", text);
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

            int FM = 749;
            int MW = 366;
            int NA = 532;
            int RM = 333;
            int TD = 267;

            int i = 0;

            while(i < FM + 1)
            {
                string filepath = "file:///C:/Temp/fixed/fixed" + i + ".html\"";
                string cmd = "taskkill /f /im msedge.exe\nstart msedge " + filepath;
                File.WriteAllText(@"C:/Temp/Printer.bat", cmd);
                Process.Start(@"C:/Temp/Printer.bat");
                System.Threading.Thread.Sleep(1500);
                SendKeys.SendWait("^{P}");
                System.Threading.Thread.Sleep(500); 
                SendKeys.SendWait("{Enter}");
                System.Threading.Thread.Sleep(2000);
                SendKeys.SendWait(i.ToString());
                System.Threading.Thread.Sleep(500);
                SendKeys.SendWait("{Enter}");
                System.Threading.Thread.Sleep(2000);
                i++;
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

        }
    }
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

