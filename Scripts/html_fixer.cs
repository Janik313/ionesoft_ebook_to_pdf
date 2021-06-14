using System;
using System.IO;
using System.Text;

namespace fix
{
    class FixHtml
    {
        static void Main(string[] args)
        {
            string text = File.ReadAllText("C:/Temp/export.html");
            text = text.Replace("localhost/", "localhost:7211/");
            File.WriteAllText("C:/Temp/fixed.html", text);
        }
    }
}
