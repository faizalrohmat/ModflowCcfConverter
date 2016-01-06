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
            string inputAddress = @"D:\DSModel_09.ccf";
            string targetAddress = @"D:\DSModel_09.txt";


            byte[] collection = File.ReadAllBytes(inputAddress);

            File.WriteAllBytes(targetAddress, collection);

            Console.ReadLine();
        }
    }    
}
