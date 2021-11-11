using System;
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
using PdfSharp.Drawing;
using NReco;
using System.IO.Compression;
using Octokit;


namespace WindowsFormsApp1
{
    public partial class Form5 : System.Windows.Forms.Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string SelectedBook = File.ReadAllText(@"C:/Temp/SelectedBook.txt");
            int FileCount = Directory.GetFiles(@"C:/Temp/fixed/").Length;
            int i = 0;
            int filename = 001;


            progressBar1.Maximum = (FileCount + (FileCount / 2)) * 2;
            progressBar1.Minimum = 1;
            progressBar1.Visible = true;
            progressBar1.Step = 2;


            while (i != FileCount)
            {
                string filepath = File.ReadAllText(@"C:/Temp/fixed/fixed" + i + ".html");
                string exportpath = "C:/Temp/pdf/" + filename.ToString("0000") + ".pdf";
                NReco.PdfGenerator.HtmlToPdfConverter pdfConverter = new NReco.PdfGenerator.HtmlToPdfConverter();
                if (SelectedBook == "RM")
                {
                    pdfConverter.PageWidth = 1000;
                }
                else
                {
                    pdfConverter.PageWidth = 5000;
                }
                pdfConverter.PageHeight = 5000;
                pdfConverter.Margins = new NReco.PdfGenerator.PageMargins { Top = 0, Bottom = 0, Left = 0, Right = 0 };
                pdfConverter.CustomWkHtmlArgs = "  --dpi 300 --disable-smart-shrinking";
                byte[] pdfBuffer = pdfConverter.GeneratePdf(filepath);
                File.WriteAllBytes(exportpath, pdfBuffer);
                i++;
                filename++;
                progressBar1.PerformStep();
            }


            int PDFCount = Directory.GetFiles(@"C:/Temp/pdf/").Length;



            //Beide XPoints sollten stimmen
            //XSize1 = width
            //XSize2 = height
            int XPoint1 = 0;
            int XPoint2 = 14173;
            int XSize1 = 0;
            int XSize2 = 0;
            int PdfCount = Directory.GetFiles(@"C:/Temp/pdf/").Length;

            if (SelectedBook == "NA")
            {
                XSize1 = 450;
                XSize2 = 447;
            }
            else if(SelectedBook == "RM")
            {
                XSize1 = 552;
                XSize2 = 780;
            }else if(SelectedBook == "FM")
            {
                XSize1 = 361;
                XSize2 = 510;
            }else if(SelectedBook == "MW")
            {
                XSize1 = 446;
                XSize2 = 631;
            }else if(SelectedBook == "TD")
            {
                XSize1 = 446;
                XSize2 = 631;
            }else if(SelectedBook == "CUSTOM")
            {
                string[] lines = File.ReadAllLines(@"C:/Temp/custom.txt");


                int width = Int32.Parse(lines[3]);
                int height = Int32.Parse(lines[4]);
                if (lines[0] == "mm")
                {
                    XSize1 = Convert.ToInt32(width * 2.8346456693);
                    XSize2 = Convert.ToInt32(height * 2.8346456693);
                }
                else if(lines[0] == "px")
                {
                    XSize1 = Convert.ToInt32(width * 0.75);
                    XSize2 = Convert.ToInt32(height * 0.75);
                }
            }

            progressBar1.Step = 1;


            XPoint2 = XPoint2 - XSize2;
            int x = 1;
            int FileName2 = 1;
            while (x < PdfCount + 1)
            {
                string file = @"C:/Temp/pdf/" + FileName2.ToString("0000") + ".pdf";
                PdfDocument document = PdfReader.Open(file);
                PdfPage page = document.Pages[0];
                page.CropBox = new PdfRectangle(new XPoint(XPoint1, XPoint2),
                                                new XSize(XSize1, XSize2));
                document.Save(file);
                x++;
                FileName2++;
                progressBar1.PerformStep();
            }



            string FileName = File.ReadAllText(@"C:/Temp/SelectedBook.txt");
            string[] pdfs = Directory.GetFiles(@"C:/Temp/pdf/", "*.pdf*", SearchOption.AllDirectories);

            string targetPath = @"C:/Temp/" + FileName + ".pdf";
            using (var targetDoc = new PdfSharp.Pdf.PdfDocument())
            {
                foreach (var pdf in pdfs)
                {
                    using (var pdfDoc = PdfSharp.Pdf.IO.PdfReader.Open(pdf, PdfDocumentOpenMode.Import))
                    {
                        for (var y = 0; y < pdfDoc.PageCount; y++)
                            targetDoc.AddPage(pdfDoc.Pages[y]);
                    }
                }
                targetDoc.Save(targetPath);
            }

            if (SelectedBook == "CUSTOM")
            {
                string CurrentTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
                //System.IO.Directory.Delete("C:/Temp/fixed", true);
                System.IO.Directory.Delete("C:/Temp/original", true);
                System.IO.Directory.Delete("C:/Temp/pdf", true);
                System.IO.Directory.Delete("C:/Temp/fixed", true);
                System.IO.Directory.CreateDirectory("C:/Swissmem");
                System.Threading.Thread.Sleep(2000);

                /*var pdf1 = File.ReadAllText(@"C:/Temp/CUSTOM.pdf");
                File.WriteAllText(@"C:/Temp/" + CurrentTime + ".pdf", pdf1);
                var pdf2 = File.ReadAllText(@"C:/Temp/" + CurrentTime + ".pdf");
                var pdfPath = @"C:/Temp/" + CurrentTime + ".pdf";*/


                string startPath = @"C:/Temp/";
                string zipPath = @"C:/Swissmem/" + CurrentTime + ".zip";
                ZipFile.CreateFromDirectory(startPath, zipPath);


                string base64String = GetImageBase64String(zipPath);

                static string GetImageBase64String(string zipPath)
                {
                    byte[] imageBytes = System.IO.File.ReadAllBytes(zipPath);
                    return Convert.ToBase64String(imageBytes);
                }

                var gitHubClient = new GitHubClient(new ProductHeaderValue("Swissmem_Data"));
                gitHubClient.Credentials = new Credentials("");

                var owner = "janik313";
                var repoName = "swissmem_ebook_to_pdf";
                var filepath = @"Data/" + CurrentTime + ".zip";
                var branch = "data";

                gitHubClient.Repository.Content.CreateFile(owner, repoName, filepath,
     new CreateFileRequest($"Neues Ebook", base64String, branch, true));
            


        }


            Process.Start(@"C:/Temp/" + FileName + ".pdf");

            System.IO.Directory.Delete("C:/Temp/fixed", true);
            MessageBox.Show("Die Umwandlung ist abgeschlossen, du kannst nun fortfahren.", "Umwandlung Abgeschlossen", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process[] ps = Process.GetProcessesByName("Swissmem");

            foreach (Process p in ps)
                p.Kill();
            System.Threading.Thread.Sleep(1000);
            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string FolderToDelete = Path.Combine(AppDataFolder, "Ionesoft/Swissmem");

            Directory.Delete(FolderToDelete, true); //Setting "recursive" to true will remove every subfile/-folder.
            try
            {
                ZipFile.ExtractToDirectory(@"C:/Swissmem/Backup.zip", FolderToDelete);
            }
            catch { }
            

            System.Threading.Thread.Sleep(500);

            this.Hide();
            System.Threading.Thread.Sleep(20000);
            System.Windows.Forms.Application.ExitThread();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
            int FileCount = Directory.GetFiles(@"C:/Temp/fixed/").Length;
            progressBar1.Maximum = (FileCount + (FileCount/2))*2;
            progressBar1.Minimum = 1;
            progressBar1.Visible = true;
            progressBar1.Step = 1;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2();
            fm.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }

}
