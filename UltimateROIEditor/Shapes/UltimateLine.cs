using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateROIEditor.Shapes
{
    //отрезок
    
    class UltimateLine : UltimateShape
    {
        public Point A;
        public Point B;

        protected MouseEventHandler h1 = null, h2 = null, h3 = null;
        protected PaintEventHandler h4 = null;

        int index = -1;

        bool isMovingVertices = false;

        public UltimateLine(Point A, Point B)
        {
            CreateEventHandlers();
            this.A = A;
            this.B = B;
        }
        public override bool Contains(Point p)
        {
            const float EPS = 1.0f;
            return false;
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

        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.Black), A, B);
            
            int a = 4;
            Rectangle VertexRect = new Rectangle(A.X - a / 2, A.Y - a / 2, a, a);
            g.FillEllipse(new SolidBrush(Color.White), VertexRect);
            g.DrawEllipse(new Pen(Color.Black), VertexRect);

            VertexRect = new Rectangle(B.X - a / 2, B.Y - a / 2, a, a);
            g.FillEllipse(new SolidBrush(Color.White), VertexRect);
            g.DrawEllipse(new Pen(Color.Black), VertexRect);
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

        private void mPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            //mIsClick = true;

            //nodeSelected = PosSizableRect.None;
            //nodeSelected = GetNodeSelectable(e.Location);

            //if (rect.Contains(new Point(e.X, e.Y)))
            //{
            //  mMove = true;
            //}

            int i = 0;
            int a = 8;
            Rectangle CatchRectangle = new Rectangle(e.X - a / 2, e.Y - a / 2, a, a);
            
            if (CatchRectangle.Contains(A))
            {
                isMovingVertices = true;
                index = 0;
            }
            if (CatchRectangle.Contains(B))
            {
                isMovingVertices = true;
                index = 1;
            }
             

            oldX = e.X;
            oldY = e.Y;
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
           // mIsClick = false;
            mMove = false;

            isMovingVertices = false;

            if (e.Button == MouseButtons.Right)
                myContextMenu.Show((System.Windows.Forms.Control)sender, new Point(e.X, e.Y));
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            //ChangeCursor(e.Location);
            //if (mIsClick == false)
            //{
           //     return;
           // }

            if (isMovingVertices)
            {
                if (index == 0)
                    A = new Point(e.X, e.Y);
                if (index == 1)
                    B = new Point(e.X, e.Y);
            }

            //int a = points.Count();

            oldX = e.X;
            oldY = e.Y;

            mPictureBox.Invalidate();
        }
    
    }
}
