using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateROIEditor.Shapes
{
    //прямоугольный треугольник
    
    public class UltimateTriangleRectangular : UltimateRectangle
    {
        public UltimateTriangleRectangular(Rectangle rect)
        {
            CreateEventHandlers();
            this.rect = rect;  
        }
        
        public override void Draw(Graphics g)
        {

            //Pen redPen = new Pen(Color.Red);
            Point[] temp = new Point[3];
            //if (IsInvertedX == false)
            temp[0] = new Point(rect.Left, rect.Top);
            temp[1] = new Point(rect.Left, rect.Bottom);
            temp[2] = new Point(rect.Right, rect.Bottom);

            if (IsInvertedX)
                temp[0].X = rect.Right;
            if (IsInvertedY)
            {
                temp[0].Y = rect.Bottom;
                temp[1].Y = rect.Top;
                temp[2].Y = rect.Top;
            }
            //temp[3] = new Point(rect.Right, (rect.Top + rect.Bottom) / 2);

            g.DrawPolygon(new Pen(Color.Black), temp);

            /*foreach (Point p in temp)
            {
                int a = 4;
                Rectangle VertexRect = new Rectangle(p.X - a / 2, p.Y - a / 2, a, a);
                g.FillEllipse(new SolidBrush(Color.White), VertexRect);
                g.DrawEllipse(new Pen(Color.Black), VertexRect);
            }*/

            DrawNodes(g);
        }
    }
}
