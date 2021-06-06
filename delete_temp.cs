using System.IO;

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