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
                var AllFiles = Directory.GetFiles("./");
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
                Console.WriteLine("Args: GetLast <file extention>");
            }
        }
    }
}
