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

            int lengthOfSubArray;

            Console.Write("Please input length of sub array: ");
            try
            {
                lengthOfSubArray = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                return;
            }

            using (FileStream fs = new FileStream(inputAddress, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    int length = Convert.ToInt32(fs.Length);
                    Console.WriteLine(length.ToString());

                    lengthOfSubArray = Math.Min(lengthOfSubArray, length);

                    byte[] bin = br.ReadBytes(length).SubArray(0, lengthOfSubArray);
                    Console.WriteLine("Length: " + bin.Length.ToString());



                    string a = Convert.ToBase64String(bin);


                    using (FileStream fs2 = new FileStream(targetAddress, FileMode.Create))
                    {
                        using (StreamWriter sw = new StreamWriter(fs2))
                        {
                            sw.Write(a);
                        }
                    }
                }
            }

            Console.ReadLine();
        }

        

    }

    public static class Ext
    {
        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }

    
}
