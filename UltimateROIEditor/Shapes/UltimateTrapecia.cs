using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UltimateROIEditor.Shapes
{
    //трапеция
    
    public class UltimateTrapecia : UltimateRectangle
    {
        Point[] points;
        float a = 0.25f;

        public UltimateTrapecia(Rectangle rect)
        {
            CreateEventHandlers();
            this.rect = rect;
            points = new Point[4];
            RecalcParams();
        }

        public override void RecalcParams()
        {
            base.RecalcParams();

            int w = rect.Width, h = rect.Height;
            points[0] = new Point(rect.Left + w / 4, rect.Top);
            points[1] = new Point(rect.Right - w / 4, rect.Top);
            points[2] = new Point(rect.Right, rect.Bottom);
            points[3] = new Point(rect.Left, rect.Bottom);

            /*if (IsInvertedY)
            {
                points[0].Y = rect.Bottom;
                points[1].Y = rect.Top;
                points[2].Y = rect.Top;
            }*/
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
