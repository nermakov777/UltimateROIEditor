using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateROIEditor.Math
{
    //прямая в виде Ax + By + C = 0;
    public class ULine
    {
        float A, B, C; 

        public ULine()
        {
            this.A = 1;
            this.B = -1;
            this.C = 0;
        }
        public ULine(float A, float B, float C)
        {
            this.A = A;
            this.B = B;
            this.C = C;
        }
    }
    
        
}
