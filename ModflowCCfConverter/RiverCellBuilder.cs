using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModflowCCfConverter
{
    public class RiverCellBuilder
    {
        private List<List<int>> _cells = new List<List<int>>();
        private List<int> _cellIDs = new List<int>();
        private int _ncols, _nrows;
        private float _xllcorner, _yllcorner, _cellsize, _nodatavalue;

        public RiverCellBuilder(int ncols, int nrows, float xllcorner, float yllcorner, float cellsize, float nodatavalue)
        {
            _ncols = ncols;
            _nrows = nrows;
            _xllcorner = xllcorner;
            _yllcorner = yllcorner;
            _cellsize = cellsize;
            _nodatavalue = nodatavalue;
        }

        public void ReadRowCol(string inputFilePath)
        {
            try
            {
                using (FileStream fs = new FileStream(inputFilePath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (fs.Position < fs.Length)
                        {
                            List<int> cols = new List<int>();
                            string[] strs = (sr.ReadLine()).Split(',');
                            foreach (var str in strs)
                            {
                                try
                                {
                                    cols.Add(int.Parse(str));
                                }
                                catch
                                {
                                    cols.Add(0);
                                }
                            }
                            _cells.Add(cols);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void WriteToAscii(string targetFilePath)
        {
            using (FileStream fs = new FileStream(targetFilePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("ncols         " + ncols.ToString());
                    sb.AppendLine("nrows         " + nrows.ToString());
                    sb.AppendLine("xllcorner     " + xllcorner.ToString());
                    sb.AppendLine("yllcorner     " + yllcorner.ToString());
                    sb.AppendLine("cellsize      " + cellsize.ToString());
                    sb.AppendLine("NODATA_value  " + nodatavalue.ToString());

                    for (int row = 1; row < nrows; row++)
                    {
                        for (int col = 1; col <= ncols; col++)
                        {
                            var val = _cells.Where(elm => (elm[0] == row && elm[1] == col)).FirstOrDefault();
                            if (val != null)
                            {
                                sb.Append("1 ");
                            }
                            else
                            {
                                sb.Append("0 ");
                            }
                        }
                        sb.AppendLine();
                    }

                    sw.Write(sb.ToString());
                }
            }
        }
    }
}
