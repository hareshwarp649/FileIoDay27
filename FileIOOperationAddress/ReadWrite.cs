using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIOOperationAddress
{
    internal class ReadWrite
    {
        public static void ReadFromStreamReader()
        {
            string path = @"C:\Users\ADMIN\source\repos\FileIOperation\FileIOOperationAddress\TextFile1.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    String fileData = "";
                    while ((fileData = sr.ReadLine()) != null)
                        Console.WriteLine((fileData));
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No file");
            }
        }
    }
}
