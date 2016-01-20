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
                        string str;
                        while ((str = sr.ReadLine()) != null)
                        {
                            try
                            {
                                _cellIDs.Add(int.Parse(str));
                            }
                            catch
                            {

                            }
                        }
                    }
                }
                _cellIDs.Sort();
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
                    sb.AppendLine("ncols         " + _ncols.ToString());
                    sb.AppendLine("nrows         " + _nrows.ToString());
                    sb.AppendLine("xllcorner     " + _xllcorner.ToString());
                    sb.AppendLine("yllcorner     " + _yllcorner.ToString());
                    sb.AppendLine("cellsize      " + _cellsize.ToString());
                    sb.AppendLine("NODATA_value  " + _nodatavalue.ToString());

                    int thisCellID = 0;

                    for (int row = 1; row <= _nrows; row++)
                    {
                        for (int col = 1; col <= _ncols; col++)
                        {
                            thisCellID = (row - 1) * _ncols + col;

                            if (_cellIDs.Contains(thisCellID))
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
