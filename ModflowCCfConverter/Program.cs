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
using ModflowCCfConverter;
using System.Diagnostics;

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
            string inputAddress = @"F:\DSModel_09.ccf";
            //string inputAddress = @"D:\ReModel3.ccf";
            string targetAddress = @"F:\resultDS.xml";
            //string targetAddress = @"D:\resultUS.xml";

            string targetParentDir = @"F:\resultDS";

            // WriteToXml writer = new WriteToXml();
            // writer.Writer(inputAddress, targetAddress);

            int ncolsDS = 217;
            int nrowsDS = 102;
            float xllcorner = 705984f;
            float yllcorner = 4211006f;
            float cellsize = 250f;
            float nodatavalue = -999f;

            WriteToAsciiDir(inputAddress, targetParentDir, ncolsDS, nrowsDS, xllcorner, yllcorner, cellsize, nodatavalue);

            //EricMethod(inputAddress);

            Console.ReadLine();

        }

        private void WriteToAsciiDir(string inputAddress, string targetParentDir, int ncolsDS, int nrowsDS, float xllcorner, float yllcorner, float cellsize, float nodatalue)
        {
            // check the directory. if does not exist, create. if exists, delete
            // in order to delete data from previous run, if any
            DirectoryInfo di = new DirectoryInfo(targetParentDir);
            if (Directory.Exists(targetParentDir)) Directory.Delete(targetParentDir, true);
            di.Create();

            // start stopwatch
            Stopwatch watch = new Stopwatch();
            watch.Start();

            // log pathname
            FileInfo log = new FileInfo(Path.Combine(di.FullName, "log.txt"));
            if (log.Exists == false)
            {
                using (FileStream fslog = new FileStream(log.FullName, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fslog))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + "\t" + "Process started.");
                    }
                }
            }

            // read and write data
            using (FileStream fs = new FileStream(inputAddress, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    while (fs.Position < fs.Length)
                    {
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

                        DirectoryInfo di1 = new DirectoryInfo(Path.Combine(di.FullName, fText));
                        if (di1.Exists == false) di1.Create();

                        for (int i = 1; i <= nValsPerCell - 1; i++)
                        {
                            string text = (new string(br.ReadChars(16))).Replace(" ", string.Empty);
                        }

                        int nList = 0;
                        if (iType == 2 || iType == 5) nList = br.ReadInt32();

                        string caseType = string.Empty;


                        StringBuilder sb = new StringBuilder();

                        // append ascii headers
                        sb.AppendLine("ncols         " + ncolsDS.ToString());
                        sb.AppendLine("nrows         " + nrowsDS.ToString());
                        sb.AppendLine("xllcorner     " + xllcorner.ToString());
                        sb.AppendLine("yllcorner     " + yllcorner.ToString());
                        sb.AppendLine("cellsize      " + cellsize.ToString());
                        sb.AppendLine("NODATA_value  " + nodatalue.ToString());

                        switch (iType)
                        {
                            case 0:
                            case 1:
                                caseType = "3D array of values";
                                for (int lay = 1; lay <= nLay; lay++)
                                {
                                    // create subdir for each layer
                                    DirectoryInfo di2 = new DirectoryInfo(Path.Combine(di1.FullName, nameof(lay) + lay.ToString()));
                                    if (di2.Exists == false) di2.Create();

                                    using (FileStream fs1 = new FileStream(Path.Combine(di2.FullName, stressPeriod.ToString() + ".asc"), FileMode.CreateNew))
                                    {
                                        using (StreamWriter sw = new StreamWriter(fs1))
                                        {
                                            for (int row = 1; row <= nRow; row++)
                                            {
                                                for (int col = 1; col <= nCol; col++)
                                                {
                                                    float val = br.ReadSingle();
                                                    sb.Append(val.ToString() + " ");
                                                }
                                                sb.AppendLine();
                                            }
                                            sw.Write(sb.ToString());
                                        }
                                    }
                                }
                                break;
                            case 2:
                            case 5:
                                caseType = "list of cells and associated values";

                                // initiate valueholder array
                                float[,,] valueholder = new float[nValsPerCell, nRow, nCol];
                                for (int val = 0; val < nValsPerCell; val++)
                                {
                                    for (int row = 0; row < nRow; row++)
                                    {
                                        for (int col = 0; col < nCol; col++)
                                        {
                                            valueholder[val, row, col] = 0f;
                                        }
                                    }
                                }

                                // reading from binary file into dictionary
                                Dictionary<int, List<float>> dicto = new Dictionary<int, List<float>>(nList);

                                for (int i = 0; i < nList; i++)
                                {
                                    int cellID = br.ReadInt32();
                                    List<float> values = new List<float>(nValsPerCell);
                                    for (int j = 0; j < nValsPerCell; j++)
                                    {
                                        values.Add(br.ReadSingle());
                                    }
                                    try
                                    {
                                        dicto.Add(cellID, values);
                                    }
                                    catch { }
                                }

                                // assign values
                                foreach (var item in dicto)
                                {
                                    int row = (int)Math.Ceiling(((double)item.Key / (double)nCol));
                                    if (row > nRow)
                                        row = row - nRow;
                                    int col = item.Key % row;

                                    for (int val = 0; val < nValsPerCell; val++)
                                    {
                                        valueholder[val, row, col] = item.Value[val];
                                    }
                                }

                                // write ascii
                                for (int val = 0; val < nValsPerCell; val++)
                                {
                                    // create subdir for each value
                                    DirectoryInfo di2 = new DirectoryInfo(Path.Combine(di1.FullName, nameof(val) + (val + 1).ToString()));
                                    if (di2.Exists == false) di2.Create();

                                    using (FileStream fs1 = new FileStream(Path.Combine(di2.FullName, stressPeriod.ToString() + ".asc"), FileMode.CreateNew))
                                    {
                                        using (StreamWriter sw = new StreamWriter(fs1))
                                        {
                                            for (int row = 0; row < nRow; row++)
                                            {
                                                for (int col = 0; col < nCol; col++)
                                                {
                                                    sb.Append(valueholder[val, row, col].ToString() + " ");
                                                }
                                                sb.AppendLine();
                                            }
                                            sw.Write(sb.ToString());
                                        }
                                    }
                                }
                                break;
                            case 3:
                                caseType = "2D layer indicator array followed by a 2D array of values";
                                //int[] layerIDs = new int[nCol * nRow];
                                // layer indicator

                                for (int row = 1; row <= nRow; row++)
                                {

                                    for (int col = 1; col <= nCol; col++)
                                    {
                                        int val = br.ReadInt32();
                                        XElement xCol = new XElement(nameof(col), new XAttribute("colid", col), val);

                                    }

                                }

                                for (int row = 1; row <= nRow; row++)
                                {

                                    for (int col = 1; col <= nCol; col++)
                                    {
                                        float val = br.ReadSingle();

                                    }

                                }

                                break;
                            case 4:
                            default:

                                caseType = "2D array of values associated with layer 1";
                                for (int row = 1; row <= nRow; row++)
                                {
                                    for (int col = 1; col <= nCol; col++)
                                    {
                                        float val = br.ReadSingle();

                                    }

                                }

                                break;
                        }

                        using (FileStream fslog = new FileStream(Path.Combine(di.FullName, "log.txt"), FileMode.Append))
                        {
                            using (StreamWriter sw = new StreamWriter(fslog))
                            {
                                sw.WriteLine(DateTime.Now.ToString() + "\t" + "Done writing " + fText + " as " + caseType + " at stressperiod " + stressPeriod.ToString());
                            }
                        }

                    }
                }
            }

            // stop stopwatch
            watch.Stop();
            var elapsed = watch.Elapsed;

            using (FileStream fslog = new FileStream(Path.Combine(di.FullName, "log.txt"), FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fslog))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "\t" + "Process finished for " + elapsed.ToString());
                }
            }

            Console.WriteLine("Process finished for " + elapsed.ToString() + " , press enter to exit");
        }


    }
}
