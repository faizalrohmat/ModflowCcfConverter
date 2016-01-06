using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModflowCCfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester tester = new Tester();
            tester.DoProgram();
        }
    }
    public class Tester
    {
        public Tester() { }

        public void DoProgram()
        {
            //string inputAddress = @"D:\DSModel_09.ccf";
            //string targetAddress = @"D:\DSModel_09.txt";

            char[] invalidPathChars = Path.GetInvalidPathChars();
            MemoryStream memStream = new MemoryStream();
            BinaryWriter binWriter = new BinaryWriter(memStream);

            // Write to memory.
            binWriter.Write("Invalid file path characters are: ");
            binWriter.Write(Path.GetInvalidPathChars(), 0, Path.GetInvalidPathChars().Length);

            // Create the reader using the same MemoryStream 
            // as used with the writer.
            BinaryReader binReader = new BinaryReader(memStream);

            // Set Position to the beginning of the stream.
            memStream.Position = 0;

            // Read the data from memory and write it to the console.
            Console.Write(binReader.ReadString());
            int arraySize = (int)(memStream.Length - memStream.Position);
            char[] memoryData = new char[arraySize];
            binReader.Read(memoryData, 0, arraySize);
            Console.WriteLine(memoryData);

            Console.ReadLine();
        }
    }    
}
