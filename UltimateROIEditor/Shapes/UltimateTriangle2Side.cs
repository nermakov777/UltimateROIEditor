using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UltimateROIEditor.Shapes
{
    //равнобедренный треугольник

    public class UltimateTriangle2Side : UltimateRectangle
    {
        Point[] points;

        public UltimateTriangle2Side(Rectangle rect)
        {
            CreateEventHandlers();
            this.rect = rect;
            points = new Point[3];
            RecalcParams();
        }

        public override void RecalcParams()
        {
            base.RecalcParams();

            points[0] = new Point((rect.Left + rect.Right) / 2, rect.Top);
            points[1] = new Point(rect.Left, rect.Bottom);
            points[2] = new Point(rect.Right, rect.Bottom);

            if (IsInvertedY)
            {
                points[0].Y = rect.Bottom;
                points[1].Y = rect.Top;
                points[2].Y = rect.Top;
            }
        }
        
        public override void Draw(Graphics g)
        {
            RecalcParams();
            g.DrawPolygon(new Pen(Color.Black), points);
            if (IsActive)
                DrawNodes(g);   
        }

        public override bool Contains(Point p)
        {
            RecalcParams();
            return UltimateROIEditor.Math.UltimateMath.Contains(points, p);
        }
    }
}
