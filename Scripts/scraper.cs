using System;
using System.Net;

namespace DownloadPageWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using var client = new WebClient();
            client.Headers.Add("User-Agent", "C# console program");

            string url = "http://localhost:7211/database/resource/pk/11440";
            string content = client.DownloadString(url);


            System.IO.File.WriteAllText(@"C:/Temp/export.html", content);
            //Console.WriteLine(content);
        }
    }
}