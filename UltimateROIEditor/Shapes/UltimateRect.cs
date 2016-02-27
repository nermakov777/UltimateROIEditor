using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
//using System.Windows.Shapes;

namespace UltimateROIEditor.Shapes
{
    public enum PosSizableRect
    {
        UpMiddle,
        LeftMiddle,
        LeftBottom,
        LeftUp,
        RightUp,
        RightMiddle,
        RightBottom,
        BottomMiddle,
        None
    };
    
    //Базовая функциональность программы (Редактор векторной графики) основана на идее автофигур из Microsoft Word 2003.

    //Каждая фигура задается при помощи набора точек на плоскости.
    //Точек может быть любое количество: 1, 2, 3 и т.д.
    //Т.е., по сути, это просто многоугольники, но с ограничениями.
    //Рассматриваются только выпуклые многоугольники. Самопересечение ребер (граней) не допускается.
    //Абсолютно отдельным пунктом из всех фигур выделяются прямоугольники.
    //Это связано с тем, что в компьютерном зрении зона интереса практически всегда представляет собой именно
    //прямоугольник. Из-за этого удобное редактирование прямоугольников отличается от остальных фигур -
    //вершины не могут перетаскиваться отдельно друг от друга. Можно двигать либо сразу грани, т.е. по две точки,
    //либо, если тянешь за угол - то меняется положение сразу двух граней.
    //Остальные же фигуры сначала планировалось редактировать только поточечно, т.е. просто тянешь точку - и она идет точно за мышью.
    //Но потом, основываясь на функциональности программы Microsoft Word, пришла в голову идея редактировать фигуры при помощи их ограничивающего прямоугольника.
    //Т.е. это как бы второй режим, в котором мы мысленно вписываем фигуру в её описывающий прямоугольник и дальше редактируем только его.
    //Расстояния между вершинами при этом меняются не как попало, а пропорционально.

    public class UltimateRect : UltimateShape
    {
        public float RotationAngle; //угол поворота
        
        protected int sizeNodeRect = 5;
        protected PosSizableRect nodeSelected = PosSizableRect.None;
        protected Rectangle rect; //прямоугольник

        protected MouseEventHandler h1 = null, h2 = null, h3 = null;
        protected PaintEventHandler h4 = null;

        /*public bool AddContextMenu
        {
            get { return _AddContextMenu; }
            set
            {
                if (_AddContextMenu == value)
                    return;

                _AddContextMenu = value;
                HandleMenu();
            }
        }*/     
        
        /*public bool IsRectangle
        {
            get { return isRectangle;  }
        }*/
        /*public  PictureBox PictureBox
        {
            get { return pictureBox; }
            set { pictureBox = value; }
        }*/
        public Rectangle Rect
        {
            get { return rect;  }
        }

        /*public UltimateFigure(Point p)
        {
            CreateContextMenu();
            CreateEventHandlers();
            
            this.isRectangle = false;
            this.isFitted = false;
            this.points = new List<Point>(new Point[]{p});
            this.rect = CalcBoundingBox(this.points);
            //this.points.Add(p);
            this.mIsClick = false;
        }
        public UltimateFigure(Point A, Point B)
        {
            CreateContextMenu();
            CreateEventHandlers();
            
            this.isRectangle = false;
            this.isFitted = false;
            this.points = new List<Point>(new Point[]{A, B});
            this.rect = CalcBoundingBox(points);
            //this.points.Add(A);
            //this.points.Add(B);
            this.mIsClick = false;
        }
        
        public UltimateFigure(List<Point> points, bool isFitted)
        {
            CreateContextMenu();
            CreateEventHandlers();

            //нужна проверка на выпуклость и отсутствие самопересечений !!!
            
            this.isRectangle = false;
            this.isFitted = (points.Count < 3 ? false : true);
            //this.isFitted = isFitted;
            //this.rect = rect;
            this.points = points; // RectangleToPoints(rect);
            this.rect = CalcBoundingBox(this.points);
            this.mIsClick = false;
        }
        public UltimateFigure(List<Point> points)
        {
            CreateContextMenu();
            CreateEventHandlers();

            //нужна проверка на выпуклость и отсутствие самопересечений !!!
            
            this.isRectangle = false;
            this.isFitted = false;
            this.points = points; 
            this.rect = CalcBoundingBox(this.points);
            this.mIsClick = false;
        }*/

        public UltimateRect ()
        { 
        
        }

        public UltimateRect (Rectangle rect)
        {
            CreateContextMenu();
            CreateEventHandlers();
            
            //this.isRectangle = true;
            this.rect = rect;  
            //this.points = RectangleToPoints(rect);
            //this.mIsClick = false;

            
        }
        public override bool Contains(Point p)
        {
            return (p.X >= rect.Left &&
                    p.X <= rect.Right &&
                    p.Y >= rect.Top &&
                    p.Y <= rect.Bottom);
        }


        //тест на выпуклость
        public static bool CheckConvexity(List<Point> points)
        {
            //пока все очень тупо
            //TODO: написать алогоритм
            
            if (points.Count < 4)
                return true;
            else
                return false;
        }

        //тест на самопересечение граней
        public static bool CheckSelfIntersection(List<Point> points)
        {
            //пока все очень тупо
            //TODO: написать алогоритм 

            if (points.Count < 4)
                return true;
            else
                return false;
        }

        protected virtual void CreateEventHandlers()
        {
            h1 = new MouseEventHandler(mPictureBox_MouseDown);
            h2 = new MouseEventHandler(mPictureBox_MouseUp);
            h3 = new MouseEventHandler(mPictureBox_MouseMove);
            h4 = new PaintEventHandler(mPictureBox_Paint);
        }

        public static List<Point> RectangleToPoints(Rectangle R)
        {
            List<Point> Result = new List<Point>();
            Result.Add(new Point(R.Left, R.Top));
            Result.Add(new Point(R.Right, R.Top));
            Result.Add(new Point(R.Right, R.Bottom));
            Result.Add(new Point(R.Left, R.Bottom));
            return Result;
        }

        public static Rectangle CalcBoundingBox(List<Point> vertices)
        {
            //TODO: вынести в общие функции!
            
            int x1 = 0 , x2 = 0, y1 = 0, y2 = 0;
            if (vertices.Count == 0)
                return new Rectangle();
            
            x1 = x2 = vertices[0].X;
            y1 = y2 = vertices[0].Y;

            foreach (Point vertex in vertices)
            {
                x1 = System.Math.Min(x1, vertex.X);
                x2 = System.Math.Max(x1, vertex.X);

                y1 = System.Math.Min(x1, vertex.Y);
                y2 = System.Math.Max(x1, vertex.Y);
            }

            int width = x2 - x1;
            int height = y2 - y1;

            return new Rectangle(x1, y1, width, height);
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red), rect);

            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                //g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
                g.FillEllipse(new SolidBrush(Color.White), GetRect(pos));
                g.DrawEllipse(new Pen(Color.Black), GetRect(pos));
                
            }
        }
        

        public override void SetPictureBox(PictureBox p)
        {
            //отвязываемся от старого контейнера
            ReleasePictureBox();

            //привязываемся к новому
            this.mPictureBox = p;
            mPictureBox.MouseDown += h1;
            mPictureBox.MouseUp += h2;
            mPictureBox.MouseMove += h3;
            mPictureBox.Paint += h4;
        }
        public override void ReleasePictureBox()
        {
            if (this.mPictureBox != null)
            {
                mPictureBox.MouseDown -= h1;
                mPictureBox.MouseUp -= h2;
                mPictureBox.MouseMove -= h3;
                mPictureBox.Paint -= h4;

                this.mPictureBox = null;
            }
        }

        private void mPictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Draw(e.Graphics);
            }
            catch (Exception exp)
            {
                System.Console.WriteLine(exp.Message);
            }
        }

        private void mPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //mIsClick = true;

            nodeSelected = PosSizableRect.None;
            nodeSelected = GetNodeSelectable(e.Location);

            if (rect.Contains(new Point(e.X, e.Y)))
            {
                mMove = true;
            }
            oldX = e.X;
            oldY = e.Y;
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //mIsClick = false;
            mMove = false;

            if (e.Button == MouseButtons.Right)
                myContextMenu.Show((System.Windows.Forms.Control)sender, new Point(e.X, e.Y));
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeCursor(e.Location);
           // if (mIsClick == false)
           // {
                
           //     return;
          //  }

            Rectangle backupRect = rect;

            switch (nodeSelected)
            {
                case PosSizableRect.LeftUp:
                    rect.X += e.X - oldX;
                    rect.Width -= e.X - oldX;
                    rect.Y += e.Y - oldY;
                    rect.Height -= e.Y - oldY;
                    break;
                case PosSizableRect.LeftMiddle:
                    rect.X += e.X - oldX;
                    rect.Width -= e.X - oldX;
                    break;
                case PosSizableRect.LeftBottom:
                    rect.Width -= e.X - oldX;
                    rect.X += e.X - oldX;
                    rect.Height += e.Y - oldY;
                    break;
                case PosSizableRect.BottomMiddle:
                    rect.Height += e.Y - oldY;
                    break;
                case PosSizableRect.RightUp:
                    rect.Width += e.X - oldX;
                    rect.Y += e.Y - oldY;
                    rect.Height -= e.Y - oldY;
                    break;
                case PosSizableRect.RightBottom:
                    rect.Width += e.X - oldX;
                    rect.Height += e.Y - oldY;
                    break;
                case PosSizableRect.RightMiddle:
                    rect.Width += e.X - oldX;
                    break;

                case PosSizableRect.UpMiddle:
                    rect.Y += e.Y - oldY;
                    rect.Height -= e.Y - oldY;
                    break;

                default:
                    if (mMove)
                    {
                        rect.X = rect.X + e.X - oldX;
                        rect.Y = rect.Y + e.Y - oldY;
                    }
                    break;
            }
            oldX = e.X;
            oldY = e.Y;

            if (rect.Width < 5 || rect.Height < 5)
            {
                rect = backupRect;
            }

            TestIfRectInsideArea();

            mPictureBox.Invalidate();
        }

        private void TestIfRectInsideArea() //???
        {
            // Test if rectangle still inside the area.
            if (rect.X < 0) rect.X = 0;
            if (rect.Y < 0) rect.Y = 0;
            if (rect.Width <= 0) rect.Width = 1;
            if (rect.Height <= 0) rect.Height = 1;

            if (rect.X + rect.Width > mPictureBox.Width)
            {
                rect.Width = mPictureBox.Width - rect.X - 1; // -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    //mIsClick = false;
                }
            }
            if (rect.Y + rect.Height > mPictureBox.Height)
            {
                rect.Height = mPictureBox.Height - rect.Y - 1;// -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                  //  mIsClick = false;
                }
            }
        }

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }

        protected Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(rect.X, rect.Y);

                case PosSizableRect.LeftMiddle:
                    return CreateRectSizableNode(rect.X, rect.Y + +rect.Height / 2);

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode(rect.X, rect.Y + rect.Height);

                case PosSizableRect.BottomMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y + rect.Height);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y);

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height);

                case PosSizableRect.RightMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height / 2);

                case PosSizableRect.UpMiddle:
                    return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y);
                default:
                    return new Rectangle();
            }
        }

        private PosSizableRect GetNodeSelectable(Point p)
        {
            foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (GetRect(r).Contains(p))
                {
                    return r;
                }
            }
            return PosSizableRect.None;
        }

        private void ChangeCursor(Point p)
        {
            mPictureBox.Cursor = GetCursor(GetNodeSelectable(p), p);
        }

        /// <summary>
        /// Get cursor for the handle
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Cursor GetCursor(PosSizableRect pos, Point p)
        {
            //если такщим какой-нибудь угол
            if (pos == PosSizableRect.LeftUp) return Cursors.SizeNWSE;
            else if (pos == PosSizableRect.LeftMiddle) return Cursors.SizeWE;
            else if (pos == PosSizableRect.LeftBottom) return Cursors.SizeNESW;
            else if (pos == PosSizableRect.BottomMiddle) return Cursors.SizeNS;
            else if (pos == PosSizableRect.RightUp) return Cursors.SizeNESW;
            else if (pos == PosSizableRect.RightBottom) return Cursors.SizeNWSE;
            else if (pos == PosSizableRect.RightMiddle) return Cursors.SizeWE;
            else if (pos == PosSizableRect.UpMiddle) return Cursors.SizeNS;
            else if (pos == PosSizableRect.None)
            { 
                //если ничего не тащим, но курсор над нашим прямоугольником
                if (rect.Contains(p)) return Cursors.SizeAll;
            }
            
            //возвращаем стандартный курсор
            return Cursors.Default;
        }

        protected override void CreateContextMenu()
        {
            myContextMenu = new ContextMenu();
            items = new List<MenuItem>();
            items.Add(new MenuItem("Set ID"));
            items.Add(new MenuItem("Set label"));
            //items[2] = new MenuItem("Fit");
            //items[3] = new MenuItem("Unfit");
            //items[4] = new MenuItem("To bounding box");
            //items[5] = new MenuItem("Add vertex");
            items.Add(new MenuItem("Remove"));

            items[0].Click += new EventHandler(conextMenu_SetID_Click);
            items[1].Click += new EventHandler(conextMenu_SetLabel_Click);
            //items[2].Click += new EventHandler(conextMenu_Fit_Click);
            //items[3].Click += new EventHandler(conextMenu_Unfit_Click);
            //items[4].Click += new EventHandler(conextMenu_ToBoundingBox_Click);
            //items[5].Click += new EventHandler(conextMenu_AddVertex_Click);
            items[2].Click += new EventHandler(conextMenu_Remove_Click);

            for (int i = 0; i < 3; ++i)
                myContextMenu.MenuItems.Add(items[i]);
        }

        /*private void Fit()
        {
            isFitted = true;
        }
        private void Unfit()
        {
            isFitted = false;
        }*/

        protected override void conextMenu_SetID_Click(object sender, System.EventArgs e)
        {
            
        }
        protected override void conextMenu_SetLabel_Click(object sender, System.EventArgs e)
        {

        }
        
        /*private void conextMenu_ToBoundingBox_Click(object sender, System.EventArgs e)
        {

        }*/
        
        protected override void conextMenu_Remove_Click(object sender, System.EventArgs e)
        {

        }

        /*private void HandleMenu()
        {
            if (_AddContextMenu)
            {
                miDeleteTracker = new MenuItem("Delete Selection");
                if (mPictureBox.ContextMenu == null)
                {
                    cmnuPB = new ContextMenu();
                    cmnuPB.MenuItems.Add(miDeleteTracker);
                    cmnuPB.Popup += new EventHandler(cmnuPB_Popup);
                    miDeleteTracker.Click += new EventHandler(miDeleteTracker_Click);
                    mPictureBox.ContextMenu = cmnuPB;
                }
                else
                {

                    mPictureBox.ContextMenu.MenuItems.Add("-");
                    mPictureBox.ContextMenu.MenuItems.Add(miDeleteTracker);
                    mPictureBox.ContextMenu.Popup += new EventHandler(cmnuPB_Popup);
                    miDeleteTracker.Click += new EventHandler(miDeleteTracker_Click);
                }
            }
            else
            {
                if (cmnuPB != null)
                {
                    cmnuPB.Dispose();
                    cmnuPB = null;
                    mPictureBox.ContextMenu = null;

                }
                else
                {
                    int i = mPictureBox.ContextMenu.MenuItems.IndexOf(miDeleteTracker);
                    if (i > 1)
                    {
                        mPictureBox.ContextMenu.MenuItems.RemoveAt(i);
                        mPictureBox.ContextMenu.MenuItems.RemoveAt(i - 1);
                    }

                }
            }

        }*/
    }
}
