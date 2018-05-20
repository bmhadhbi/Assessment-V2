using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileParser
{
    /// <summary>
    /// Class for readinf Files Content
    /// </summary>
    public static class FilesReading
    {
        /// <summary>
        /// Reading a text file content and writing in console window
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadTextFile(string filePath)
        {
            String line;
            try
            {

                StreamReader sr = new StreamReader(filePath);
              
                //First line
                line = sr.ReadLine();
                            
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }

                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
