using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LabFile
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintPoem("poem.txt");
            SavePoemWithLineNumbers();
            PrintPoem("poem1.txt");
        }

        #region Print Poem
        static void PrintPoem(String FileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(FileName))
                {
                    StringBuilder sb = new StringBuilder();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sb.Append(line).Append(Environment.NewLine);
                    }
                    Console.Write(sb.ToString());
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("A problem occured opening" + FileName);
            }
        }

        #endregion

        #region Save Poem With Line Number
        static void SavePoemWithLineNumbers()
        {
            try
            {
                using(StreamReader reader = new StreamReader("poem.txt"))
                {
                    using(StreamWriter writer = new StreamWriter("poem1.txt"))
                    {
                        int count = 1;
                        string line;
                        while((line = reader.ReadLine()) != null)
                        {
                            writer.WriteLine("{0:00} {1}", count ++, line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A problem occured opening file");
            }
        }
        #endregion
    }
}
