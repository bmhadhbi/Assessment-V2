using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileParser
{
    /// <summary>
    /// Class for readinf Files Content
    /// </summary>
    /// 
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

        [PrincipalPermissionAttribute(SecurityAction.Demand, Role = "Admin")]
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
        public static void ReadEncryptedFile(string filePath)
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


        public static void ReadEncryptedXMLFile(string filePath)
        {
            try
            {
                FileInfo info = new FileInfo(filePath);
                FileStream input = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();
               
                DES DESAlgorithm = new DESCryptoServiceProvider();
                CryptoStream cs = new CryptoStream(input, DESAlgorithm.CreateDecryptor(), CryptoStreamMode.Read);

                BinaryReader rdr = new BinaryReader(cs);
                byte[] dta = new byte[info.Length];
                rdr.Read(dta, 0, (int)info.Length);
                rdr.Close();
                cs.Close();
                input.Close();


                // Writing the result of reading the encrypted XML file in to Console Window                
                Console.Write(Encoding.ASCII.GetString(dta));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}

