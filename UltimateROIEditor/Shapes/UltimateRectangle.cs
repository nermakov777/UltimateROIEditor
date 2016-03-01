using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UltimateROIEditor.Shapes
{
    public class UltimateRectangle : UltimateShape
    {
        //public event EventHandler DragAndDropEnter; //схватили
        //public event EventHandler DragAndDropLeave; //отпустили
        
        protected const int sizeNodeRect = 8;

        public Point[] Nodes; //ключевые точки, за которые тянем
        public Rectangle rect;

        protected MouseEventHandler h1 = null, h2 = null, h3 = null;
        protected PaintEventHandler h4 = null;

        protected PosSizableRect nodeSelected = PosSizableRect.None;

        public bool IsInvertedX; //при выворачивании наизнанку
        public bool IsInvertedY;  //при выворачивании наизнанку

        public override bool Contains(Point p)
        {
            return (p.X >= rect.Left &&
                    p.X <=  rect.Right &&
                    p.Y >= rect.Top &&
                    p.Y <= rect.Bottom);
        }

        public UltimateRectangle()
        {
            guid = Guid.NewGuid();
            internalID = count;
            count++;
            
            CreateContextMenu();
            CreateEventHandlers();

            //this.isRectangle = true;
            this.rect = new Rectangle(0, 0, 100, 100);
            //this.points = RectangleToPoints(rect);
            //this.mIsClick = false;
            IsInvertedX = false;
            IsInvertedY = false;
            IsActive = false;
            mMove = false;
            nodeSelected = PosSizableRect.None;
            isMouseHover = false;

            //подписка на собственные события
            MouseEnter += new EventHandler(HandleMouseEnter); 
            MouseLeave += new EventHandler(HandleMouseLeave); 
        }
        
        public UltimateRectangle (Rectangle rect)
        {
            guid = Guid.NewGuid();
            internalID = count;
            count++;
            
            CreateContextMenu();
            CreateEventHandlers();
            
            //this.isRectangle = true;
            this.rect = rect;  
            //this.points = RectangleToPoints(rect);
            //this.mIsClick = false;

            IsInvertedX = false;
            IsInvertedY = false;

            IsActive = false;
            mMove = false;
            nodeSelected = PosSizableRect.None;
            isMouseHover = false;

            //подписка на собственные события
            MouseEnter += new EventHandler(HandleMouseEnter);
            MouseLeave += new EventHandler(HandleMouseLeave); 
        }
        ~UltimateRectangle()
        {
            count--;
            Debug.WriteLine("Shape destructed. Count = {0}", count.ToString());
        }

        protected virtual void CreateEventHandlers()
        {
            h1 = new MouseEventHandler(mPictureBox_MouseDown);
            h2 = new MouseEventHandler(mPictureBox_MouseUp);
            h3 = new MouseEventHandler(mPictureBox_MouseMove);
            h4 = new PaintEventHandler(mPictureBox_Paint);
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

        // Пересчет положения узлов
        public void RecalcNodes()
        {
	        //у нас есть прямоугольник
	        //нужно посчитать положение девяти его ключевых узлов
	        //=============================================================
	        //
	        //    LEFT_TOP               TOP               RIGHT_TOP
	        // 			О----------------О----------------О
	        // 			|                                 |                           
	        // 			|                                 |
	        // 	  LEFT  О                                 O  RIGHT
	        // 			|                                 |
	        // 		    |                                 |
	        // 	        О----------------О----------------О
	        // LEFT_BOTTOM             BOTTOM              RIGHT_BOTTOM
	        //
	        //==============================================================

	        
	        int width = rect.Width;
	        int height = rect.Height;
	       

	        //проверка на количество узлов
	        if (Nodes == null)
		        Nodes = new Point[8];
	
	        //начинаем с left-top и дальше по часовой стрелке
	        Nodes[0] = new Point(rect.Left, rect.Top); //left-top
            Nodes[1] = new Point(rect.Left + width / 2, rect.Top); //top
	        Nodes[2] = new Point(rect.Right, rect.Top); //right-top

	        Nodes[3] = new Point(rect.Right, rect.Top + height/2); //right

	        Nodes[4] = new Point(rect.Right, rect.Bottom); //right-bottom
	        Nodes[5] = new Point(rect.Left + width/2, rect.Bottom); //bottom
	        Nodes[6] = new Point(rect.Left, rect.Bottom); //left-bottom

	        Nodes[7] = new Point(rect.Left, rect.Top + height/2); //left
        }

        protected void HandleMouseEnter(object sender, EventArgs e)
        {
            mPictureBox.Cursor = Cursors.SizeAll;
        }

        protected void HandleMouseLeave(object sender, EventArgs e)
        {
            mPictureBox.Cursor = Cursors.Default;
        }

        protected void mPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            bool IsContaintsPoint = Contains(e.Location);
            
            if (IsActive == false)  //фигура неактивна
            {
                if (IsContaintsPoint) //нажали внутри фигуры
                {
                    isReadyToMove = true; //приготовились двигать всю фигуру
                    isMoved = false;
                    OnClick();
                    IsActive = true;
                }
            }
            else  //фигура активна
            {
                nodeSelected = GetNodeSelectable(e.Location); //проверяем на клик по узлу
                if (nodeSelected != PosSizableRect.None) //кликнули по ноду
                {
                    //активируем стретчинг фигуры
                    IsStretch = true;
                }
                else //не по ноду
                {
                    //не по ноду, но внутри фигуры
                    if (IsContaintsPoint)
                    {
                        isReadyToMove = true; //приготовились двигать всю фигуру
                        isMoved = false;
                        OnClick();
                        IsActive = true;
                    }
                    else  //не по ноду и не внутри фигуры
                    {
                        //деактивируем фигуру
                        IsActive = false;
                    }
                }
            } 
            
            oldX = e.X;
            oldY = e.Y;
        }

        private void ChangeCursor(Point p)
        {
            Cursor c = GetCursor(GetNodeSelectable(p), p);
            if (IsMouseHover)
                mPictureBox.Cursor = c;
        }

        private Cursor GetCursor(PosSizableRect pos, Point p)
        {
            //если такщим какой-нибудь угол
            if (IsActive)
            {
                if (pos == PosSizableRect.LeftUp) return Cursors.SizeNWSE;
                else if (pos == PosSizableRect.LeftMiddle) return Cursors.SizeWE;
                else if (pos == PosSizableRect.LeftBottom) return Cursors.SizeNESW;
                else if (pos == PosSizableRect.BottomMiddle) return Cursors.SizeNS;
                else if (pos == PosSizableRect.RightUp) return Cursors.SizeNESW;
                else if (pos == PosSizableRect.RightBottom) return Cursors.SizeNWSE;
                else if (pos == PosSizableRect.RightMiddle) return Cursors.SizeWE;
                else if (pos == PosSizableRect.UpMiddle) return Cursors.SizeNS;
            }
            
            if (pos == PosSizableRect.None && rect.Contains(p))
            {
                return Cursors.SizeAll;
            }

            //возвращаем стандартный курсор
            return Cursors.Default;
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
           // mIsClick = false;
            if (isReadyToMove == true) //если только что двигали фигуру
            {
                isReadyToMove = false;
                //OnMoveLeave();
            }
            if (isMoved == true) //если только что двигали фигуру
            {
                isMoved = false;
                OnMoveLeave(); //TODO: встроить в свойство
            }

            nodeSelected = PosSizableRect.None;
            IsStretch = false;

            //if (e.Button == MouseButtons.Right)
             //   myContextMenu.Show((System.Windows.Forms.Control)sender, new Point(e.X, e.Y));
        }

        public virtual void RecalcParams()
        {
            RecalcNodes();
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (Contains(new Point(e.X, e.Y))) //если мышь попадает в нашу фигуру
            {
                isMouseHover = true;
                OnMouseHover();
            }
            else //если двигаем мышь вне фигуры
            {
                isMouseHover = false;
            }

            //если никакой из узлов не захвачен и фигура готова к движению
            if (nodeSelected == PosSizableRect.None && IsReadyToMove == true)
            {
                //двигаем весь прямоугольник, не меняя форму
                if (isMoved == false)
                {
                    isMoved = true;
                    OnMoveEnter();
                }
                OnMoveHover();

                int dx = e.X - oldX;
                int dy = e.Y - oldY;
                rect.X += dx;
                rect.Y += dy;
                RecalcParams();
                //RecalcNodes();
                mPictureBox.Invalidate();
                oldX = e.X;
                oldY = e.Y;
                //return;
            }
            if (nodeSelected != PosSizableRect.None) //если какой-то из узлов захвачен
            {
                Point p = new Point(e.X, e.Y);
                WinRECT R = new WinRECT(rect);
                
                //меняем параметры ректа в зависимости от того, какой угол захвачен
                StretchRectAccordingNewNodePosition(nodeSelected, ref R, p);

                //при перемещении узлов могут поменяться местами левая сторона и правая
                //или верхняя сторона и нижняя; эти ситуации нужно обрабатывать
                if (R.left > R.right) //перепутались левая и правая сторона
                {
                    UltimateROIEditor.Math.UltimateMath.Swap(ref R.left, ref R.right);
                    SwtichNodeLeftAndRight(ref nodeSelected);
                    IsInvertedX = !IsInvertedX;
                }
                if (R.top > R.bottom) //перепутались верхняя и нижняя сторона
                {
                    UltimateROIEditor.Math.UltimateMath.Swap(ref R.top, ref R.bottom);
                    SwtichNodeTopAndBottom(ref nodeSelected);
                    IsInvertedY = !IsInvertedY;
                }

                rect = R.ToRectangle();  //преобразуем прямоугольник обратно
                RecalcNodes();   //пересчет узлов
                mPictureBox.Invalidate();  //перерисовка
            }  
        }

        public void StretchRectAccordingNewNodePosition(PosSizableRect nodeSelected, ref WinRECT R, Point p)
        {
            if (nodeSelected == PosSizableRect.LeftUp) { R.left = p.X; R.top = p.Y; }
            if (nodeSelected == PosSizableRect.UpMiddle) { R.top = p.Y; }
            if (nodeSelected == PosSizableRect.RightUp) { R.right = p.X; R.top = p.Y; }
            if (nodeSelected == PosSizableRect.RightMiddle) { R.right = p.X; }
            if (nodeSelected == PosSizableRect.RightBottom) { R.right = p.X; R.bottom = p.Y; }
            if (nodeSelected == PosSizableRect.BottomMiddle) { R.bottom = p.Y; }
            if (nodeSelected == PosSizableRect.LeftBottom) { R.left = p.X; R.bottom = p.Y; }
            if (nodeSelected == PosSizableRect.LeftMiddle) { R.left = p.X; }
        }

        public void SwtichNodeLeftAndRight(ref PosSizableRect nodeSelected)
        {
            if (nodeSelected == PosSizableRect.LeftMiddle) nodeSelected = PosSizableRect.RightMiddle;
            else if (nodeSelected == PosSizableRect.LeftUp) nodeSelected = PosSizableRect.RightUp;
            else if (nodeSelected == PosSizableRect.LeftBottom) nodeSelected = PosSizableRect.RightBottom;
            else if (nodeSelected == PosSizableRect.RightMiddle) nodeSelected = PosSizableRect.LeftMiddle;
            else if (nodeSelected == PosSizableRect.RightUp) nodeSelected = PosSizableRect.LeftUp;
            else if (nodeSelected == PosSizableRect.RightBottom) nodeSelected = PosSizableRect.LeftBottom;
        }

        public void SwtichNodeTopAndBottom(ref PosSizableRect nodeSelected)
        {
            if (nodeSelected == PosSizableRect.UpMiddle) nodeSelected = PosSizableRect.BottomMiddle;
            else if (nodeSelected == PosSizableRect.LeftUp) nodeSelected = PosSizableRect.LeftBottom;
            else if (nodeSelected == PosSizableRect.RightUp) nodeSelected = PosSizableRect.RightBottom;
            else if (nodeSelected == PosSizableRect.BottomMiddle) nodeSelected = PosSizableRect.UpMiddle;
            else if (nodeSelected == PosSizableRect.LeftBottom) nodeSelected = PosSizableRect.LeftUp;
            else if (nodeSelected == PosSizableRect.RightBottom) nodeSelected = PosSizableRect.RightUp;
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

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }

        public override void Draw(Graphics g)
        {
            g.DrawRectangle(new Pen(Color.Red), rect);

            if (IsActive)
                DrawNodes(g);

            /*foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                //g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
                g.FillEllipse(new SolidBrush(Color.White), GetRect(pos));
                g.DrawEllipse(new Pen(Color.Black), GetRect(pos));
            }*/
        }

        public void DrawNodes(Graphics g)
        {
            foreach (Point p in Nodes)
            {
                Rectangle nodeRect = GetRectAroundPoint(p);
                //g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
                g.FillEllipse(new SolidBrush(Color.White), nodeRect);
                g.DrawEllipse(new Pen(Color.Black), nodeRect);
            }
        }

        public Rectangle GetRectAroundPoint(Point p)
        {
            int a = 5;
            return new Rectangle(p.X - a/2, p.Y - a/2, a, a);
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

        protected override void CreateContextMenu()
        {

        }

        protected override void conextMenu_Remove_Click(object sender, System.EventArgs e)
        {

        }

        protected override void conextMenu_SetID_Click(object sender, System.EventArgs e)
        {

        }
        protected override void conextMenu_SetLabel_Click(object sender, System.EventArgs e)
        {

        }
    }
}
