using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

        public static void ReadXmlFile(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                Console.WriteLine(node.InnerText);
            }
        }

        /// <summary>
        /// Read an encrypted File
        /// </summary>
        /// <param name="filePath"></param>
        public static void ReadDecryptedFile(string filePath)
        {           
            try
            {
                byte[] encryptedBytes = File.ReadAllBytes(filePath);
                DES DESAlgorithm = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(encryptedBytes);
                CryptoStream cs = new CryptoStream(ms, DESAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);

                cs.Read(encryptedBytes, 0, encryptedBytes.Length);
                byte[] resultBytes = ms.ToArray();
                cs.Close();
                ms.Close();


                // Writing the result of reading the encrypted file in to Console Window                
                Console.Write(Encoding.ASCII.GetString(resultBytes));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
