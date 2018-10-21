using System;
using System.Collections.Generic;
using System.IO;

namespace GetLast
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string ARG = args[0].ToUpper();
                string[] AllFiles;
                if (args.Length == 2)
                {
                    AllFiles = Directory.GetFiles(args[1]);
                }
                else
                {
                    AllFiles = Directory.GetFiles("./");
                }
                List<string> Validfiles = new List<string>();
                foreach(var file in AllFiles)
                {
                    if (file.ToUpper().EndsWith(ARG))
                    {
                        Validfiles.Add(file);
                    }
                }
                string MostRecentFile="No File Found.";
                DateTime modifiedscratch = DateTime.MinValue;
                foreach(var file in Validfiles)
                {
                    if (File.GetLastWriteTime(file) > modifiedscratch)
                    {
                        MostRecentFile = file;
                        modifiedscratch = File.GetLastWriteTime(file);
                    }
                }
                
                Console.WriteLine(Path.GetFullPath(MostRecentFile));
            }
            catch
            {
                Console.WriteLine("Usage:");
                Console.WriteLine("GetLast <file extention>");
                Console.WriteLine("You can also optinally specify a path, EG:");
                Console.WriteLine("GetLast <file extension> </path/that/exists>");
            }
        }
    }
}
