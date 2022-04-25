using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace DemoFileIOOper
{
    [Serializable]
    public class Demo
    {
        public string Name { get; set; }
        public int Age { get; set; }

       
    }
        public class FileIO
        {
            //File Path
            const string FilePath = @"C:\Users\ADMIN\source\repos\FileIOperation\DemoFileIOOpeation\DemoFileIOOper\file1.txt";
            const string FilePath_Serializeddata = @"C:\Users\ADMIN\source\repos\FileIOperation\DemoFileIOOpeation\DemoFileIOOper\File2.txt";
            const string FilePath_XmlSerializeddata = @"C:\Users\ADMIN\source\repos\FileIOperation\DemoFileIOOpeation\DemoFileIOOper\File3.txt";
            /// <summary>
            /// Serialization-object to binary
            /// </summary>
            public static void BinarySerialization()
            {
                List<Demo> data = new List<Demo>()
            {
                new Demo {Age = 25, Name = "Deva" },
                new Demo {Age = 24, Name = "Shree" },
                new Demo {Age = 23, Name = "Vande" },
            };
                FileStream streamdata = new FileStream(FilePath_Serializeddata, FileMode.Create);
                BinaryFormatter bn = new BinaryFormatter();
                bn.Serialize(streamdata, data);
                streamdata.Close();
                streamdata.Dispose();
                Console.WriteLine("*** Convert Object To Binary ***");
                string binaryTxt = File.ReadAllText(FilePath_Serializeddata);
                Console.WriteLine(binaryTxt);
                Console.WriteLine("\n=====================================================\n");
            }
           
            public static void BinaryDeserialization()
            {
                FileStream streamdata = new FileStream(FilePath_Serializeddata, FileMode.Open);
                BinaryFormatter bn = new BinaryFormatter();
                List<Demo> data = (List<Demo>)bn.Deserialize(streamdata);
                streamdata.Close();
                Console.WriteLine("*** Convert List Of Binary Data To Object***");
                foreach (var contact in data)
                {
                    Console.WriteLine(contact.Name);
                    Console.WriteLine(contact.Age);
                }
                Console.WriteLine("\n=====================================================\n");
            }

        internal static void XmlSerialization()
        {
            throw new NotImplementedException();
        }

      
        public static void ReadData()
            {
                if (File.Exists(FilePath))
                {
                    var data = File.ReadAllText(FilePath);
                    Console.WriteLine(data);
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File is not exist");
                }
            }
           
            public static void ReadDataUsingStreamReader()
            {
                if (File.Exists(FilePath))
                {
                    // Create an instance of StreamReader to read from a file.
                    // The using statement also closes the StreamReader
                    using (StreamReader sr = new StreamReader(FilePath))
                    {
                        while (!sr.EndOfStream)
                        {
                            Console.WriteLine(sr.ReadLine());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File is not exist");
                }
            }
            /// <summary>
            /// Overwrite the existing data
            /// </summary>
            /// <param name="newline"></param>
            public static void OverWriteData(string newline = "")
            {
                File.WriteAllText(FilePath, newline);
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
           
            public static void AppendData(string newline = "", bool append = true)
            {
                File.AppendAllText(FilePath, newline);
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    while (!sr.EndOfStream)
                    {
                        Console.WriteLine(sr.ReadLine());
                    }
                }
            }
        }
}
