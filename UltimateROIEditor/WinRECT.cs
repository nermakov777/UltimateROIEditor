using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UltimateROIEditor
{
    public class WinRECT
    {
        public int left, top, right, bottom;
        public WinRECT()
        {
            left = top = right = bottom = 0;
        }
        public WinRECT(int left, int top, int right, int bottom)
        {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }

        public WinRECT(Rectangle Rect)
        {
            this.left = Rect.Left;
            this.top = Rect.Top;
            this.right = Rect.Right;
            this.bottom = Rect.Bottom;
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(left, top, right - left, bottom - top);
        }

        /*public WinRECT(int x, int y, int width, int height)
        {
            left = x;
            top = y;
            right = x + width;
            bottom = y + height;
        }*/
    }
}
