using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateROIEditor.Shapes
{
    public abstract class UltimateShape
    {

        public Guid guid;
        public static int count = 0; //количество созданных объектов
        public int InternalID;


        //Mouse evenets
        public event MouseEventHandler MouseDown;
        public event EventHandler MouseEnter;
        public event MouseEventHandler MouseHover;
        public event MouseEventHandler MouseLeave;
        public event MouseEventHandler MouseMove;
        public event MouseEventHandler MouseUp;

        
        public event MouseEventHandler DragAndDrop;  //перетаскиваем
        
        
        public bool IsContainsMouse = false;
        
        protected int id;
        protected string label;
        public bool IsSelected;
        protected string description;
        protected PictureBox mPictureBox;

        public ContextMenu myContextMenu; //контекстное меню
        public List<MenuItem> items;

        public bool allowDeformingDuringMovement = false;
        //protected bool mIsClick = false;
        protected bool mMove = false;
        protected int oldX;
        protected int oldY;
        //protected int sizeNodeRect = 5;
        protected Bitmap mBmp = null;
        //protected PosSizableRect nodeSelected = PosSizableRect.None;
        protected int angle = 30;  //???

        public abstract void SetPictureBox(PictureBox p);
        public abstract void ReleasePictureBox();
        public abstract void Draw(Graphics g);
        protected abstract void CreateContextMenu();
        protected abstract void conextMenu_SetID_Click(object sender, System.EventArgs e);
        protected abstract void conextMenu_SetLabel_Click(object sender, System.EventArgs e);
        protected abstract void conextMenu_Remove_Click(object sender, System.EventArgs e);

        public abstract bool Contains(Point p); //содержит ли фигура заданную точку

        public void SetBitmapFile(string filename)
        {
            this.mBmp = new Bitmap(filename);
        }

        public void SetBitmap(Bitmap bmp)
        {
            this.mBmp = bmp;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Label
        {
            get { return label; }
            set { label = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        //public abstract void ContainsPoint(Point p);
        
    }
}
