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
            string inputAddress2 = @"D:\ReModel3.ccf";
            string targetAddress = @"D:\DSModel_09.txt";

            EricMethod(inputAddress2);

            // MyMethod(inputAddress);
            // FailedMethod(inputAddress);

            Console.ReadLine();

        }

        private static void FailedMethod(string inputAddress)
        {
            string r = "r";
            string c;

            using (FileStream fs = new FileStream(inputAddress, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    for (int pos = 0; pos < fs.Length; pos++)
                    {
                        c = new string(br.ReadChars(1));
                        if (r.CompareTo(c) == 0)
                        {
                            Console.WriteLine((fs.Position - (long)1).ToString() + "\t" + c.ToString());
                        }
                    }
                }
            }
        }

        private static void MyMethod(string inputAddress)
        {
            using (FileStream fs = new FileStream(inputAddress, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    // File lengths
                    Console.WriteLine("File stream length: " + fs.Length);
                    Console.WriteLine();

                    // timestep, and description
                    Console.Write(fs.Position.ToString() + "\t");
                    int timeStep = br.ReadInt32();
                    Console.WriteLine("timeStep\t\t: " + timeStep.ToString());

                    // stress period
                    Console.Write(fs.Position.ToString() + "\t");
                    int stressPeriod = br.ReadInt32();
                    Console.WriteLine("stressPeriod\t\t: " + stressPeriod.ToString());

                    Console.Write(fs.Position.ToString() + "\t");
                    char[] fText = br.ReadChars(16);
                    Console.WriteLine("description\t\t: " + new string(fText));



                    // Number of columns
                    Console.Write(fs.Position.ToString() + "\t");
                    int nCol = br.ReadInt32();
                    Console.WriteLine("nCol\t\t\t: " + nCol.ToString());

                    // Number of rows
                    Console.Write(fs.Position.ToString() + "\t");
                    int nRow = br.ReadInt32();
                    Console.WriteLine("nRow\t\t\t: " + nRow.ToString());

                    // Number of layers
                    Console.Write(fs.Position.ToString() + "\t");
                    int nLay = Math.Abs(br.ReadInt32());
                    Console.WriteLine("nLays\t\t\t: " + nLay.ToString());


                    // type of data
                    Console.Write(fs.Position.ToString() + "\t");
                    int iType = br.ReadInt32();
                    Console.WriteLine("iType\t\t\t: " + iType.ToString());

                    // number of values per cell
                    int nvalsPerCell = 1;
                    Console.Write(fs.Position.ToString() + "\t");
                    if (iType == 5)
                    {
                        nvalsPerCell = br.ReadInt32();
                    }
                    Console.WriteLine("nvalsPerCell\t\t: " + nvalsPerCell.ToString());

                    // conditional, depending on the nvalsPerCell
                    for (int y = 1; y <= nvalsPerCell - 1; y++)
                    {
                        Console.Write(fs.Position.ToString() + "\t");
                        char[] tmpText = br.ReadChars(16);
                        Console.WriteLine("tmpText\t\t: " + new string(tmpText));
                    }

                    // conditional, depending on nlist
                    int nList = 0;
                    if (iType == 2 || iType == 5)
                    {
                        Console.Write(fs.Position.ToString() + "\t");
                        nList = br.ReadInt32();
                        Console.WriteLine("nList\t\t\t: " + nList.ToString());
                    }

                    // skip if true
                    bool SkipValues = false;


                }
            }
        }

        private static void EricMethod(string inputAddress)
        {
            int timeStepCount = 0;
            using (FileStream fs = new FileStream(inputAddress, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    long streamLength = fs.Length;

                    int timeStep/*, stressPeriod*/;
                    char[] fText, tmpText;

                    int nCol, nRow, nLay;
                    int iType, nvalsPerCell;

                    float trashSingle;

                    bool skipValues;

                    int beginningTS, endingTS;

                    object[] layerFlux = null;

                    int cellID, layerID;

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
                        //Console.Read();

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

                        for (int y = 1; y <= nvalsPerCell - 1; y++)
                        {
                            tmpText = br.ReadChars(16);
                            Console.WriteLine("tmpText\t\t\t: " + new string(tmpText));
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
                            case "         STORAGE":
                                //case "           WELLS":
                                skipValues = true;
                                break;
                            default:
                                break;
                        }
                        Console.WriteLine("skipValues\t\t: " + skipValues.ToString());

                        if (!skipValues)
                        {
                            // Initialize output arrays
                            layerFlux = null;
                            layerFlux = new object[nLay];

                            for (int i = 0; i < nLay; i++)
                            {
                                layerFlux[i] = new float[nCol * nRow];

                            }
                        }

                        // read the values from the files
                        switch (iType)
                        {
                            case 0:
                            case 1:
                                Console.WriteLine("3D array of values");
                                if (skipValues)
                                {
                                    fs.Position += nLay * nRow * nCol * 4;
                                    Console.WriteLine("[Values skipped]");
                                }
                                else
                                {
                                    for (int layer = 1; layer <= nLay; layer++)
                                    {
                                        for (int row = 1; row <= nRow; row++)
                                        {
                                            for (int col = 1; col <= nCol; col++)
                                            {
                                                Console.WriteLine(br.ReadSingle().ToString() + "\t");
                                            }
                                        }
                                    }
                                }
                                break;
                            case 2:
                            case 5:
                                Console.WriteLine("list of cells and associated values");
                                if (skipValues)
                                {
                                    fs.Position += nList * (4 + nvalsPerCell * 4);
                                    Console.WriteLine("[Values skipped]");
                                }
                                else
                                {
                                    Console.Write("layerID" + "\t" + "cellID");
                                    for (int i = 1; i <= nvalsPerCell; i++) Console.Write("\t" + "val");
                                    Console.WriteLine();

                                    for (int y = 1; y <= nList; y++)
                                    {
                                        cellID = br.ReadInt32();
                                        layerID = ((cellID - ((cellID - 1) % (nCol * nRow) + 1)) / (nCol * nRow) + 1); //layerid starts at one
                                        Console.Write(layerID + "\t" + cellID);
                                        for (int i = 1; i <= nvalsPerCell; i++)
                                        {
                                            Console.Write("\t" + br.ReadSingle().ToString());
                                        }
                                        Console.WriteLine();
                                    }
                                }
                                break;
                            case 3:
                                Console.WriteLine("2D layer indicator array followed by a 2D array of values");
                                if (skipValues)
                                {
                                    fs.Position += nRow * nCol * 4 * 2;
                                    Console.WriteLine("[Values skipped]");
                                }
                                else
                                {
                                    int[] layerIDs = new int[nCol * nRow];
                                    for (int row = 1; row <= nRow; row++)
                                    {
                                        for (int col = 1; col <= nCol; col++)
                                        {
                                            layerIDs[(row - 1) * nCol + col] = br.ReadInt32();
                                            Console.WriteLine("layerIDs: " + layerIDs.ToString());
                                        }
                                    }
                                    for (int row = 1; row <= nRow; row++)
                                    {
                                        for (int col = 1; col <= nCol; col++)
                                        {
                                            cellID = (row - 1) * nCol + col;
                                            Console.WriteLine(layerIDs[cellID].ToString() + br.ReadSingle().ToString());
                                        }
                                    }
                                }
                                break;
                            case 4:
                            default:
                                Console.WriteLine("'2D array of values associated with layer 1");
                                if (skipValues)
                                {
                                    fs.Position += nRow * nCol * 4;
                                    Console.WriteLine("[Values skipped]");
                                }
                                else
                                {
                                    for (int row = 1; row <= nRow; row++)
                                    {
                                        for (int col = 1; col <= nCol; col++)
                                        {
                                            cellID = (row - 1) * nCol + col;
                                            Console.WriteLine("cellID: " + cellID + "\t" + br.ReadSingle());
                                        }
                                    }
                                }
                                break;
                        }

                        Console.WriteLine("----------------------------------------");
                        Console.WriteLine();
                        //Console.ReadLine();
                    } while (fs.Position < fs.Length);
                }
            }
            Console.WriteLine(timeStepCount);
        }
    }
}
