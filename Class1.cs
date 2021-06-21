using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Diagnostics;


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
            int i = 0;
            int urlnumb = 1;
            while (i < 5)
            {
                using var client = new WebClient();
                client.Headers.Add("User-Agent", "C# console program");

                string url = "http://localhost:7211/database/resource/pk/" + urlnumb;
                string content = client.DownloadString(url);
                string htmldefiner = "html";

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
            int i = 0;
            while(i < 5)
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
        static void Main(string[] args)
        {
            string cmd = @"RUNDLL32.EXE MSHTML.DLL,PrintHTML ""C:/Temp/fixed.html""";
            File.WriteAllText(@"C:/Temp/Printer.bat", cmd);
            Process.Start(@"C:/Temp/Printer.bat");
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