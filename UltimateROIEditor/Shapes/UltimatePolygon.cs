using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateROIEditor.Shapes
{
    //произвольный многоугольник

    public class UltimatePolygon : UltimateRectangle
    {        
        private List<Point> points;

        private bool isRectangle;  //является ли зона прямоугольной
        private bool isFitted;  //true - зону можно редактировать только как единое целое,

        //private PaintEventHandler h4 = null;

        public bool isMovingVertices; //есть ли в данный момент перетаскиваемые вершины
        private int index; //какая вершина в данный момент перетаскавается

        public UltimatePolygon()
        {
            CreateEventHandlers();
            points = new List<Point>();
            points.Add(new Point(100, 100));
            points.Add(new Point(200, 100));
            points.Add(new Point(100, 200));
        }
        public UltimatePolygon(Rectangle rect)
        {
            
        }
        public UltimatePolygon(int id, Rectangle rect)
        {
            
        }

        protected override void CreateEventHandlers()
        {
            h1 = new MouseEventHandler(mPictureBox_MouseDown);
            h2 = new MouseEventHandler(mPictureBox_MouseUp);
            h3 = new MouseEventHandler(mPictureBox_MouseMove);
            h4 = new PaintEventHandler(mPictureBox_Paint);
        }

        public override void Draw(Graphics g)
        {
            Pen redPen = new Pen(Color.Red);
            Point[] temp = new Point[points.Count];
            for (int i = 0; i < points.Count; ++i)
                temp[i] = points[i];

            g.DrawPolygon(redPen, temp);

            foreach (Point p in temp)
            {
                int a = 4;
                Rectangle VertexRect = new Rectangle(p.X - a/2, p.Y - a/2, a, a);
                g.FillEllipse(new SolidBrush(Color.White), VertexRect);
                g.DrawEllipse(new Pen(Color.Black), VertexRect);
            }

            //g.DrawRectangle(new Pen(Color.Red), rect);

            //foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            //{
              //  g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
            //}
        }

        

     
        protected override void CreateContextMenu()
        {
            /*myContextMenu = new ContextMenu();
            items = new List<MenuItem>();
            items.Add(new MenuItem("Set ID"));
            items.Add(new MenuItem("Set label"));
            items.Add(new MenuItem("Fit"));
            items.Add(new MenuItem("Unfit"));
            items.Add(new MenuItem("Add vertex"));
            items.Add(new MenuItem("Remove"));

            items[0].Click += new EventHandler(conextMenu_SetID_Click);
            items[1].Click += new EventHandler(conextMenu_SetLabel_Click);
            items[2].Click += new EventHandler(conextMenu_Fit_Click);
            items[3].Click += new EventHandler(conextMenu_Unfit_Click);
            items[4].Click += new EventHandler(conextMenu_AddVertex_Click);
            items[5].Click += new EventHandler(conextMenu_Remove_Click);

            for (int i = 0; i <= 6; ++i)
                myContextMenu.MenuItems.Add(items[i]);*/
        }

        protected void conextMenu_Fit_Click(object sender, System.EventArgs e)
        {

        }
        protected void conextMenu_Unfit_Click(object sender, System.EventArgs e)
        {

        }

        protected void conextMenu_AddVertex_Click(object sender, System.EventArgs e)
        {

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



        private void mPictureBox_Paint(object sender, PaintEventArgs e) //общая для всех
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
           // mIsClick = true;

            nodeSelected = PosSizableRect.None;
            //nodeSelected = GetNodeSelectable(e.Location);

            //if (rect.Contains(new Point(e.X, e.Y)))
            //{
              //  mMove = true;
            //}

            int i = 0;
            int a = 8;
            Rectangle CatchRectangle = new Rectangle(e.X - a/2, e.Y - a/2, a, a);
            foreach (Point p in points)
            {
                if (CatchRectangle.Contains(p))
                {
                    isMovingVertices = true;
                    index = i;
                }
                ++i;
            }

            oldX = e.X;
            oldY = e.Y;
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            //mIsClick = false;
            mMove = false;

            isMovingVertices = false;

            if (e.Button == MouseButtons.Right)
                myContextMenu.Show((System.Windows.Forms.Control)sender, new Point(e.X, e.Y));
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            //ChangeCursor(e.Location);
          //  if (mIsClick == false)
          //  {
           //     return;
          //  }

            if (isMovingVertices)
            {
                points[index] = new Point(e.X, e.Y);
            }

            //int a = points.Count();
           
            oldX = e.X;
            oldY = e.Y;

            mPictureBox.Invalidate();
        }
    }
}
