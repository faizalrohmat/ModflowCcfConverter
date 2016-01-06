using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModflowCcfConverter
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

            using (FileStream fs = new FileStream(inputAddress, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    long streamLength = fs.Length;

                    int timeStepCount, timeStep/*, stressPeriod*/;
                    char[] fText, tmpText;

                    int nCol, nRow, nLay;
                    int iType, nvalsPerCell;

                    float trashSingle;

                    bool skipValues;

                    int beginningTS, endingTS;

                    object[] layerFlux;

                    beginningTS = 1;
                    endingTS = 292;

                    timeStepCount = 0;
                    do
                    {
                        timeStepCount++;

                        // timestep, stress period, and description
                        timeStep = br.ReadInt32();
                        Console.WriteLine("timeStep\t\t: " + timeStep.ToString());
                        timeStep = br.ReadInt32();
                        Console.WriteLine("stressPeriod\t\t: " + timeStep.ToString());
                        fText = br.ReadChars(16);
                        Console.WriteLine("description\t\t: " + new string(fText));

                        // Number of columns, rows, and layers
                        nCol = br.ReadInt32();
                        Console.WriteLine("nCol\t\t\t: " + nCol.ToString());
                        nRow = br.ReadInt32();
                        Console.WriteLine("nRow\t\t\t: " + nRow.ToString());
                        nLay = Math.Abs(br.ReadInt32());
                        Console.WriteLine("nLays\t\t\t: " + nLay.ToString());

                        // type of data
                        iType = br.ReadInt32();
                        Console.WriteLine("iType\t\t\t: " + iType.ToString());
                        for (int i = 0; i < 3; i++)
                        {
                            trashSingle = br.ReadSingle();
                            Console.WriteLine("trashSingle\t\t: " + trashSingle);
                        }
                        nvalsPerCell = 1;
                        if (iType == 5)
                        {
                            nvalsPerCell = br.ReadInt32();
                        }
                        Console.WriteLine("nvalsPerCell\t\t: " + nvalsPerCell.ToString());

                        for (int y = 1; y < nvalsPerCell - 1; y++)
                        {
                            tmpText = br.ReadChars(16);
                            Console.WriteLine("tmpText\t\t: " + new string(tmpText));
                        }

                        int nList = 0;
                        if (iType == 2 || iType == 5)
                        {
                            nList = br.ReadInt32();
                            Console.WriteLine("nList\t\t\t: " + nList.ToString());
                        }

                        // Make sure just to skip the values that aren't of interest
                        skipValues = false;

                        if (beginningTS <= timeStep && (endingTS == -1 || timeStep <= endingTS))
                        {
                            timeStep = timeStep - beginningTS + 1;
                            Console.WriteLine("Updated timeStep\t: " + timeStep.ToString());
                        }
                        else
                        {
                            skipValues = true;
                        }

                        switch (new string(fText))
                        {
                            case "   CONSTANT HEAD":
                            case "FLOW RIGHT FACE ":
                            case "FLOW FRONT FACE ":
                            case "FLOW LOWER FACE ":
                                skipValues = true;
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("skipValues\t\t: "+ skipValues.ToString());

                        if (!skipValues)
                        {
                            // Initialize output arrays
                            layerFlux = null;
                            layerFlux = new object[nLay];

                            for (int i = 0; i < nLay; i++)
                            {
                                layerFlux[i] = new float[nCol, nRow];

                            }
                        }

                    } while (/*fs.Position < fs.Length*/false);


                }
            }
            Console.ReadLine();

        }
    }
}
