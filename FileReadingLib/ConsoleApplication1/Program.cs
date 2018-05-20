using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\File Repository\Assessment-V2\FileReadingLib\ConsoleApplication1\test.txt";
            FilesReading.ReadTextFile(path);
        }
    }
}
