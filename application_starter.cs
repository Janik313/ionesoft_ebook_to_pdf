using System;

namespace Start_Program
{
    class Start
    {
        static void Main(string[] args)
        {
            try
            {
                System.Diagnostics.Process.Start("D:/Apps/Swissmem/Swissmem.exe");
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("C:/Apps/Swissmem/Swissmem.exe");
            }
        }
    }
}

//Disclaimer "Falls Swissmem nicht Startet selber starten."