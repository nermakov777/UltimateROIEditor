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
        Point[] points;
        
        public UltimateRomb(Rectangle rect)
        {
            CreateEventHandlers();
            this.rect = rect;
            points = new Point[4];
            RecalcParams();
        }

        public override void RecalcParams()
        {
            base.RecalcParams();

            points[0] = new Point((rect.Left + rect.Right) / 2, rect.Top);
            points[1] = new Point(rect.Left, (rect.Top + rect.Bottom) / 2);
            points[2] = new Point((rect.Left + rect.Right) / 2, rect.Bottom);
            points[3] = new Point(rect.Right, (rect.Top + rect.Bottom) / 2);
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
