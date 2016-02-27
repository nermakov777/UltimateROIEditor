using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UltimateROIEditor
{
    //параметры чтения/записи в файл/из файла
    public class UltimateIOParams
    {
        public FileFormat FileFormat;
        public IniFormat IniFormat;
        public CoordType CoordType;
        public int Norm;
        public RectangleFormat RectangleFormat;
        public Point[] ReferencePoints;

        public UltimateIOParams()
        {
            this.FileFormat = FileFormat.INI;
            this.IniFormat = IniFormat.Default;
            this.CoordType = CoordType.Absolute;
            this.Norm = 100;
            this.RectangleFormat = RectangleFormat.LTRB;
        }
        public UltimateIOParams(FileFormat fileFormat, IniFormat iniFormat, CoordType coordinatesType, int norm, RectangleFormat rectangleFormat)
        {
            this.FileFormat = fileFormat;
            this.IniFormat = iniFormat;
            this.CoordType = coordinatesType;
            this.Norm = norm;
            this.RectangleFormat = rectangleFormat;
        }
    
    }
}
