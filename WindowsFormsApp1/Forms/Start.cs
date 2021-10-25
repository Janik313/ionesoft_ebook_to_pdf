using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;


namespace WindowsFormsApp1.Forms
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
            System.IO.Directory.CreateDirectory("C:/Temp");
            WebClient wc = new WebClient();
            wc.DownloadFile("https://janik313.github.io/SwissmemBlocked.txt", @"C:/Temp/blocked.txt");
            wc.DownloadFile("https://janik313.github.io/SwissmemFix.txt", @"C:/Temp/fix.txt");

            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string FolderToDelete = Path.Combine(AppDataFolder, "Ionesoft/Swissmem");

            Process[] ps = Process.GetProcessesByName("Swissmem");

            foreach (Process p in ps)
                p.Kill();

            System.IO.File.Delete(@"C:/Temp/Backup.zip");
            System.Threading.Thread.Sleep(1000);
            System.IO.Compression.ZipFile.CreateFromDirectory(FolderToDelete, @"C:/Temp/Backup.zip");
            Directory.Delete(FolderToDelete, true); //Setting "recursive" to true will remove every subfile/-folder.
                                                    //ZipFile.ExtractToDirectory(@"C:/Temp/Backup.zip", FolderToDelete);

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About about = new About();
            about.Show();
            this.Hide();
        }
    }
}
