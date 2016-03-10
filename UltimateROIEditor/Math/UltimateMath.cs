using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using MathNet.Numerics.LinearAlgebra;
using System.Drawing;

namespace UltimateROIEditor.Math
{
    //Geometry algorithms taked from: http://e-maxx.ru/algo/
    
    public class UltimateMath
    {
        const double EPS = 1E-9;
     
        public static float DistBetweenLineAndPoint()
        {
            return 0;
        }
    
        //Determinant for 2D matrix
        public static float Det (float a, float b, float c, float d)
        {
	        return a * d - b * c;
        }
 
        public static bool IsBetween (float a, float b, float c)
        {
	        return System.Math.Min(a,b) <= c + EPS && c <= System.Math.Max(a,b) + EPS;
        }

        public static void Swap(ref double a, ref double b)  //ref - ???
        {
            double temp = a;
            a = b;
            b = temp;
        }

        public static void Swap(ref float a, ref float b)  //ref - ???
        {
            float temp = a;
            a = b;
            b = temp;
        }
        public static void Swap(ref int a, ref int b) //ref - ???
        {
            int temp = a;
            a = b;
            b = temp;
        }
 
        public static bool Intersect_1 (float a, float b, float c, float d)
        {
	        if (a > b)  Swap (ref a, ref b);
	        if (c > d)  Swap (ref c, ref d);
            return System.Math.Max(a, c) <= System.Math.Min(b, d);
        }
 
        //пересечение двух отрезков
        public static bool IntersectTwoLines (Vector2 a, Vector2 b, Vector2 c, Vector2 d) 
        {
	        float A1 = a.y-b.y,  B1 = b.x-a.x,  C1 = -A1*a.x - B1*a.y;
	        float A2 = c.y-d.y,  B2 = d.x-c.x,  C2 = -A2*c.x - B2*c.y;
	        float zn = Det (A1, B1, A2, B2);
            if (zn != 0)
            {
                float x = -Det(C1, B1, C2, B2) * 1.0f / zn;
                float y = -Det(A1, C1, A2, C2) * 1.0f / zn;
                return IsBetween(a.x, b.x, x) && IsBetween(a.y, b.y, y)
                    && IsBetween(c.x, d.x, x) && IsBetween(c.y, d.y, y);
            }
            else
            {
                return Det(A1, C1, A2, C2) == 0 && Det(B1, C1, B2, C2) == 0
                    && Intersect_1(a.x, b.x, c.x, d.x)
                    && Intersect_1(a.y, b.y, c.y, d.y);
            }
        }

        public static bool Contains(Point[] polygon, Point p)
        {
            Rectangle R = CalcBoundingBox(polygon);
            Vector2 a = new Vector2(R.X - 1, p.Y);
            Vector2 b = new Vector2(p.X, p.Y);

            //считаем количество пересечений луча с фигурой
            //нечетное - точка принадлежит фигуре
            //четное - точка не принадлежит фигуре
            int count = CalcIntersections(a, b, polygon);

            return (count % 2 != 0);
        }

        public static Rectangle CalcBoundingBox(Point[] polygon)
        {
            Rectangle R = new Rectangle(0,0,0,0);
            if (polygon.Length < 1)
                return R;
            
            int left, top, right, bottom;
            left = polygon[0].X;
            top = polygon[0].Y;
            right = polygon[0].X;
            bottom = polygon[0].Y;

            for (int i = 1; i < polygon.Length; ++i )
            {
                left = System.Math.Min(left, polygon[i].X);
                top = System.Math.Min(top, polygon[i].Y);
                right = System.Math.Max(right, polygon[i].X);
                bottom = System.Math.Max(bottom, polygon[i].Y);
            }

            R = new Rectangle(left, top, right - left, bottom - top);
            return R;
        }

        public static int CalcIntersections(Vector2 a, Vector2 b, Point[] polygon)
        {
            int count = 0;
            bool IsIntersect = false;
            
            List<Point> extendedPoly = new List<Point>();
            for (int i = 0; i < polygon.Length; ++i)
                extendedPoly.Add(polygon[i]);
            extendedPoly.Add(polygon[0]);
            //предположим, что многоугольник состоит хотя бы из 3 граней
            for (int i = 1; i < extendedPoly.Count; ++i)
            {
                Vector2 c = Vector2.FromPoint(extendedPoly[i - 1]);
                Vector2 d = Vector2.FromPoint(extendedPoly[i]);
                //Vector2 side = new Vector2();
                IsIntersect = IntersectTwoLines (a, b, c, d);
                if (IsIntersect)
                    ++count;
            }
            return count;
        }

        //ортогональность двух векторов
        public static bool IsOrtho(Vector2 a, Vector2 b)
        {
            return (Vector2.Dot(a, b) == 0);
        }

        //получить единичный вектор, перпендикулярный к данному
        public static Vector2 GetNormalVector(Vector2 a) 
        {
            Vector2 N = new Vector2();
            float x = N.x;
            float y = N.y;
            if (x == 0) //вектор вертикальный
            {
                N = Vector2.left;
            }
            else if (y == 0) //вектор горизонтальный
            {
                N = Vector2.up;
            }
            else //общий случай
            {
                float k = y / x;
                N = new Vector2(1.0f, -1/k);
                N.Normalize();
            }
            return N;
        }

        //получить направляющий вектор прямой
        public static Vector2 GetDirectionVector(Point A, Point B)
        {
            Vector2 D = new Vector2();
            float dx1 = B.X - A.X;
            float dy1 = B.Y - A.Y;
            if (dy1 == 0) //горизонтальная прямая
            {
                D = Vector2.left;
            }
            else if (dx1 == 0) //вертикальная прямая 
            {
                D = Vector2.up;
            }
            else //не горизонтальная и не вертикальная
            {
                float k = dy1 / dx1;
                D = new Vector2(1.0f, k);
                D.Normalize();
            }
            return D;
        }

        public static float DistanceFromPointToLine(Point p, Point A, Point B)
        {
            float dx1 = B.X - A.X;
            float dy1 = B.Y - A.Y;
            Vector2 L = GetDirectionVector(A, B); //направляющий вектор прямой
            Vector2 N = GetNormalVector(L); //нормаль к прямой
            return 0;        
        }
    }
}
