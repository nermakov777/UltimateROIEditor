using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateROIEditor.Shapes
{
    public class UltimateCircle : UltimateRectangle
    {
        int RX; //Radius in x axis
        int RY; //Radius in y axis
        Point C; //Center point

        public UltimateCircle()
        {
            base.CreateEventHandlers();
            
            RX = RY = 100;
            C = new Point(200, 200);
            rect = new Rectangle(C.X - RX, C.Y - RY, C.X + RY, C.Y + RY);
        }

        public UltimateCircle(Point Center, int Radius)
        {
            base.CreateEventHandlers();

            RX = RY = Radius;
            C = Center;
            rect = new Rectangle(C.X - RX, C.Y - RX, C.X + RX, C.Y + RX);
        }

        public UltimateCircle(Point Center, int RadiusX, int RadiusY)
        {
            base.CreateEventHandlers();

            RX = RadiusX;
            RY = RadiusY;
            C = Center;
            rect = new Rectangle(C.X - RX, C.Y - RY, C.X + RX, C.Y + RY);
        }

        public UltimateCircle(Rectangle R)
        {
            base.CreateEventHandlers();

            rect = R;
            RX = R.Width / 2;
            RY = R.Height / 2;
            C = new Point(R.X + RX, R.Y + RY);   
        }

        /*public UltimateCircle(Rectangle R)
        {
            base.CreateEventHandlers();

            rect = R;
            R = Radius;
            C = Center;
            //rect = new Rectangle(C.X - R / 2, C.Y - R / 2, C.X + R / 2, C.Y + R / 2);
        }*/

        public override void Draw(Graphics g)
        {
            g.DrawEllipse(new Pen(Color.Green), rect);

            DrawNodes(g);
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
            base.SetPictureBox(p);
        }
        public override void ReleasePictureBox()
        {
            base.ReleasePictureBox();
        }

        /*private void CreateEventHandlers() //общая для все
        {
            //h1 = new MouseEventHandler(mPictureBox_MouseDown);
            //h2 = new MouseEventHandler(mPictureBox_MouseUp);
            //h3 = new MouseEventHandler(mPictureBox_MouseMove);
            h4 = new PaintEventHandler(mPictureBox_Paint);
        }*/

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
    }
}
