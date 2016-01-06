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
            DoProgram();

            //using (FileStream fs = new FileStream(binaryInputPath, FileMode.Open))
            //{
            //    Console.WriteLine(fs.Name);
            //    using (BinaryReader br = new BinaryReader(fs))
            //    {
            //        for (int i = 0; i < 10; i++)
            //        {
            //            Console.Write(br.ReadString());
            //        }
            //    }
            //}

            //

        }

        public static void DoProgram()
        {
            #region variables
            string address;
            long startingPoint;
            int charAmount;
            #endregion

            address = /*GetAddress();*/ @"D:\DSModel_09.ccf";
            startingPoint = /*GetStartingPoint();*/ 0;
            charAmount = /*GetCharAmount();*/ 8;

            if (string.IsNullOrEmpty(address))
            {
                return;
            }
            for (int i = 0; i < 4; i++)
            {
                BeginRead(address, startingPoint, charAmount);
                startingPoint += 50;
            }
            

            Console.ReadLine();
        }

        public static string GetAddress()
        {
            string address = string.Empty;
            Console.WriteLine("Enter file addess: ");
            try
            {
                address = Console.ReadLine();
                Console.WriteLine("Reading address succeeded, address set to:\n " + address);
            }
            catch (Exception)
            {
                Console.WriteLine("Reading address failed.");
            }
            return address;
        }

        public static long GetStartingPoint()
        {
            long startingPoint;
            Console.Write("Enter starting point: ");
            try
            {
                startingPoint = long.Parse(Console.ReadLine());
                Console.WriteLine("Reading value succeeded, starting point set to " + startingPoint.ToString() + ".");
            }
            catch (Exception)
            {
                startingPoint = 0;
                Console.WriteLine("Reading value failed, starting point set to 0.");
            }
            return startingPoint;
        }

        public static int GetCharAmount()
        {
            int charAmount;
            Console.Write("Enter char amount: ");
            try
            {
                charAmount = int.Parse(Console.ReadLine());
                Console.WriteLine("Reading value succeeded, char amount set to " + charAmount.ToString() + ".");
            }
            catch (Exception)
            {
                charAmount = 1;
                Console.WriteLine("Reading value failed, char amount set to 1.");
            }
            return charAmount;
        }

        public static void BeginRead(string address, long startingPoint, int charAmount)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(address));
            string text = "";
            br.BaseStream.Position = startingPoint;
            foreach (var i in br.ReadChars(charAmount))
            {
                text += i;
            }
            //Console.WriteLine("Contents of the file are:\n" + text);
        }

    }
}
