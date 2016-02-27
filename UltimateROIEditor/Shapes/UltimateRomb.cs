using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateROIEditor.Shapes
{
    //ромб
    
    public class UltimateRomb : UltimateRectangle
    {
        public UltimateRomb(Rectangle rect)
        {
            CreateEventHandlers();
            this.rect = rect;  
        }
        
        public override void Draw(Graphics g)
        {

            //Pen redPen = new Pen(Color.Red);
            Point[] temp = new Point[4];
            temp[0] = new Point((rect.Left + rect.Right)/2, rect.Top);
            temp[1] = new Point(rect.Left, (rect.Top + rect.Bottom) / 2);
            temp[2] = new Point((rect.Left + rect.Right) / 2, rect.Bottom);
            temp[3] = new Point(rect.Right, (rect.Top + rect.Bottom) / 2);

            g.DrawPolygon(new Pen(Color.Black), temp);

            DrawNodes(g);
        }
    }
}
