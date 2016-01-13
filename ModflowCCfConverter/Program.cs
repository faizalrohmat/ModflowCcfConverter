using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Linq.Expressions;
using System.Xml.Linq;
using System.Xml.XPath;

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
            //string inputAddress2 = @"D:\ReModel3.ccf";
            string targetAddress = @"D:\resultDS.xml";
            //string targetAddress2 = @"D:\resultUS.xml";

            WriteToXml(inputAddress, targetAddress);

            //EricMethod(inputAddress);

            Console.ReadLine();

        }

        private static void WriteToXml(string inputAddress, string targetAddress)
        {
            Action<string, object> writeLine = (_name, _content) => Console.WriteLine(_name + " = {0}", _content.ToString());
            Action<string, object> write = (_name, _content) => Console.Write(_name + " = {0}\t", _content.ToString());

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("MODFLOW Result, parsed from " + inputAddress),
                new XElement("Results"));

            doc.Save(targetAddress);

            using (FileStream fs = new FileStream(inputAddress, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    int timeStepCount = 0;

                    while (fs.Position < fs.Length)
                    {
                        var xd = XDocument.Load(targetAddress);

                        XElement root = xd.XPathSelectElement("//Results");

                        // read result header first
                        int timeStep = br.ReadInt32();
                        int stressPeriod = br.ReadInt32();
                        string fText = (new string(br.ReadChars(16))).Replace(" ", string.Empty);

                        int nCol = br.ReadInt32();
                        int nRow = br.ReadInt32();
                        int nLay = Math.Abs(br.ReadInt32());
                        int iType = br.ReadInt32();

                        for (int i = 0; i < 3; i++) br.ReadSingle();

                        int nValsPerCell;
                        if (iType == 5) nValsPerCell = br.ReadInt32();
                        else nValsPerCell = 1;
                        //writeLine(nameof(nValsPerCell), nValsPerCell);

                        // create header XElement of it with a lot of attributes, lol
                        XElement header = new XElement(fText,
                            new XAttribute(nameof(timeStep), timeStep),
                            new XAttribute(nameof(stressPeriod), stressPeriod),
                            new XAttribute(nameof(nCol), nCol),
                            new XAttribute(nameof(nRow), nRow),
                            new XAttribute(nameof(nLay), nLay),
                            new XAttribute(nameof(iType), iType)
                            );

                        XElement tempText = new XElement(nameof(tempText));
                        for (int i = 1; i <= nValsPerCell - 1; i++)
                        {
                            string text = (new string(br.ReadChars(16))).Replace(" ", string.Empty);
                            tempText.Add(new XElement(nameof(text), text, new XAttribute("id", i)));
                        }

                        header.Add(tempText);

                        int nList;
                        if (iType == 2 || iType == 5)
                        {
                            nList = br.ReadInt32();
                            //writeLine(nameof(nList), nList);
                        }
                        else nList = 0;
                        header.Add(new XAttribute(nameof(nList), nList));

                        string caseType = string.Empty;
                        XElement data = new XElement(nameof(data));
                        switch (iType)
                        {
                            case 0:
                            case 1:
                                caseType = "3D array of values";

                                for (int lay = 1; lay <= nLay; lay++)
                                {
                                    XElement xLay = new XElement(nameof(lay), new XAttribute("layid", lay));

                                    for (int row = 1; row <= nRow; row++)
                                    {
                                        XElement xRow = new XElement(nameof(row), new XAttribute("rowid", row));
                                        for (int col = 1; col <= nCol; col++)
                                        {
                                            float val = br.ReadSingle();
                                            XElement xCol = new XElement(nameof(col), new XAttribute("colid", col), val);
                                            xRow.Add(xCol);
                                        }
                                        xLay.Add(xRow);
                                    }
                                    data.Add(xLay);
                                }
                                break;
                            case 2:
                            case 5:
                                caseType = "list of cells and associated values";
                                for (int i = 0; i < nList; i++)
                                {
                                    int cellID = br.ReadInt32();
                                    XElement xCel = new XElement("cell", new XAttribute(nameof(cellID), cellID));
                                    for (int j = 0; j < nValsPerCell; j++)
                                    {
                                        float val = br.ReadSingle();
                                        xCel.Add(new XElement(nameof(val), new XAttribute("id", j), val));
                                    }
                                    data.Add(xCel);
                                }
                                break;
                            case 3:
                                caseType = "2D layer indicator array followed by a 2D array of values";
                                //int[] layerIDs = new int[nCol * nRow];
                                // layer indicator
                                XElement layerID = new XElement(nameof(layerID));
                                for (int row = 1; row <= nRow; row++)
                                {
                                    XElement xRow = new XElement(nameof(row), new XAttribute("rowid", row));
                                    for (int col = 1; col <= nCol; col++)
                                    {
                                        int val = br.ReadInt32();
                                        XElement xCol = new XElement(nameof(col), new XAttribute("colid", col), val);
                                        xRow.Add(xCol);
                                    }
                                    layerID.Add(xRow);
                                }
                                XElement value = new XElement(nameof(value));
                                for (int row = 1; row <= nRow; row++)
                                {
                                    XElement xRow = new XElement(nameof(row), new XAttribute("rowid", row));
                                    for (int col = 1; col <= nCol; col++)
                                    {
                                        float val = br.ReadSingle();
                                        XElement xCol = new XElement(nameof(col), new XAttribute("colid", col), val);
                                        xRow.Add(xCol);
                                    }
                                    value.Add(xRow);
                                }
                                data.Add(layerID);
                                data.Add(value);
                                break;
                            case 4:
                            default:
                                XElement firstLayerValue = new XElement(nameof(firstLayerValue));
                                caseType = "2D array of values associated with layer 1";
                                for (int row = 1; row <= nRow; row++)
                                {
                                    XElement xRow = new XElement(nameof(row), new XAttribute("rowid", row));
                                    for (int col = 1; col <= nCol; col++)
                                    {
                                        float val = br.ReadSingle();
                                        XElement xCol = new XElement(nameof(col), new XAttribute("colid", col), val);
                                        xRow.Add(xCol);
                                    }
                                    firstLayerValue.Add(xRow);
                                }
                                data.Add(firstLayerValue);
                                break;
                        }

                        header.Add(new XAttribute(nameof(caseType), caseType));

                        header.Add(data);
                        root.Add(header);

                        for (int i = 0; i < 20; i++)
                        {
                            Console.Write("-");
                        }


                        Console.WriteLine();
                        Console.WriteLine("Done writing " + fText + " as \"" + caseType + "\" at " + nameof(stressPeriod) + " " + stressPeriod);
                        Console.WriteLine();
                        /*
                        Console.Write("Continue? (y/n) ");
                        object c = null;
                        try { c = Console.ReadLine(); }
                        catch { }

                        if (!(c.ToString() == "y" || c.ToString() == "Y"))
                        {
                            break;
                        }*/
                        Console.WriteLine();


                        xd.Save(targetAddress);

                    }



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
                                Console.WriteLine("2D array of values associated with layer 1");
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
