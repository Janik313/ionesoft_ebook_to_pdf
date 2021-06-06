using System.IO;
using OpenHtmlToPdf;

namespace Converter
{
    class Html_to_Pdf
    {
        static void Main(string[] args)
        {
            var html = Pdf.From(@"C:/Temp/fixed.html").OfSize(PaperSize.A4);
            byte[] content = html.Content();
            File.WriteAllBytes(@"C:/Temp/output.pdf", content);
        }
    }
}