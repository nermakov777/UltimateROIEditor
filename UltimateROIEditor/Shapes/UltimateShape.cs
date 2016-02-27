using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace UltimateROIEditor.Shapes
{
    //basic class for all other shapes
    
    public abstract class UltimateShape
    {

        public Guid guid;
        public static int count = 0; //количество созданных объектов
        public int InternalID;

        //Mouse events
        //public event MouseEventHandler MouseDown;
        //public event MouseEventHandler MouseMove;
        //public event MouseEventHandler MouseUp;
        public bool IsMouseHover = false;
        public event EventHandler MouseEnter;
        public event EventHandler MouseHover;
        public event EventHandler MouseLeave;
        
        //Move events
        public bool IsMove = false;
        public event EventHandler MoveEnter; //put object
        public event EventHandler MoveHover;  //dragging
        public event EventHandler MoveLeave; //drop object

        //Stretch events
        public bool IsStretch = false;
        public event EventHandler StretchEnter; //begin stretching
        public event EventHandler StretchHover;  //stretching
        public event EventHandler StretchLeave; //end stretching

        //Rotate events
        public bool IsRotate = false;
        public event EventHandler RotateEnter; //begin rotation
        public event EventHandler RotateHover;  //rotation
        public event EventHandler RotateLeave; //end rotation

        //Reshape events (by vertex)
        public bool IsReshape = false;
        public event EventHandler ReshapeEnter; //begin reshaping
        public event EventHandler ReshapeHover;  //reshaping
        public event EventHandler ReshapeLeave; //end reshaping
        
        //Activation events
        public bool IsActive = false;
        public event EventHandler Activated;
        public event EventHandler Deactivated;
        public event EventHandler ActivationChanged;

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

        //Methods for generate events
        protected virtual void OnMouseEnter()
        {
            MouseEnter((object)this, new EventArgs());
        }
        protected virtual void OnMouseHover()
        {
            MouseHover((object)this, new EventArgs());
        }
        protected virtual void OnMouseLeave()
        {
            MouseLeave((object)this, new EventArgs());
        }
        protected virtual void OnDragAndDropEnter()
        {
            /*EventHandler handler = SomeEvent;
            if (handler != null)
                handler(this, someArgs);*/
            
            DragAndDropEnter((object)this, new EventArgs()); //на самом деле MouseEnter
        }
        protected virtual void OnDragAndDropHover()
        {
            DragAndDropHover((object)this, new EventArgs());
        }
        protected virtual void OnDragAndDropLeave()
        {
            DragAndDropLeave((object)this, new EventArgs()); 
        }
        protected virtual void OnActivated()
        {
            Activated((object)this, new EventArgs());
        }
        protected virtual void OnDeactivated()
        {
            Deactivated((object)this, new EventArgs());
        }
        protected virtual void OnActivationChanged()
        {
            ActivationChanged((object)this, new EventArgs());
        }

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
    }
}
