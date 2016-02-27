using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

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
        public event EventHandler Click; //Click inside shape
        public event EventHandler MouseEnter;
        public event EventHandler MouseHover;
        public event EventHandler MouseLeave;
        
        //Move events
        public bool IsReadyToMove = false;
        public bool IsMoved = false;
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
        private bool isActive = false;
        public bool IsActive
        {
            get { return isActive; }
            set 
            {
                bool oldValue = isActive;
                isActive = value;
                OnActivationChanged();
                if (oldValue == false && value == true)
                    OnActivated();
                if (oldValue == true && value == false)
                    OnDeactivated();
            }
        }
        public event EventHandler Activated;
        public event EventHandler Deactivated;
        public event EventHandler ActivationChanged;

        //public bool IsContainsMouse = false;
        
        protected int id;
        protected string label;
        //public bool IsSelected;
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

        public abstract bool Contains(Point p); //Hit test with point

        //Methods for generate events
        protected virtual void OnClick()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: Click", DateTime.Now.ToString(), InternalID.ToString()));
            if (Click != null)
                Click((object)this, new EventArgs());
        }
        protected virtual void OnMouseEnter()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MouseEnter", DateTime.Now.ToString(), InternalID.ToString()));
            if (MouseEnter != null)
                MouseEnter((object)this, new EventArgs());
        }
        protected virtual void OnMouseHover()
        {
            //Debug.WriteLine(string.Format("[{0}] Shape {1}: MouseHover", DateTime.Now.ToString(), InternalID.ToString()));
            if (MouseHover != null)
                MouseHover((object)this, new EventArgs());
        }
        protected virtual void OnMouseLeave()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MouseLeave", DateTime.Now.ToString(), InternalID.ToString()));
            if (MouseLeave != null)
                MouseLeave((object)this, new EventArgs());
        }

        protected virtual void OnMoveEnter()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MoveEnter", DateTime.Now.ToString(), InternalID.ToString()));

            if (MoveEnter != null)
                MoveEnter((object)this, new EventArgs()); //на самом деле MouseEnter
        }
        protected virtual void OnMoveHover()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MoveHover", DateTime.Now.ToString(), InternalID.ToString()));
            
            if (MoveHover != null)
                MoveHover((object)this, new EventArgs());
        }
        protected virtual void OnMoveLeave()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MoveLeave", DateTime.Now.ToString(), InternalID.ToString()));
            if (MoveLeave != null)
                MoveLeave((object)this, new EventArgs()); 
        }

        protected virtual void OnStretchEnter()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: StretchEnter", DateTime.Now.ToString(), InternalID.ToString()));
            if (StretchEnter != null)
                StretchEnter((object)this, new EventArgs());
        }
        protected virtual void OnStretchHover()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: StretchHover", DateTime.Now.ToString(), InternalID.ToString()));
            if (StretchHover != null)
                StretchHover((object)this, new EventArgs());
        }
        protected virtual void OnStretchLeave()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: StretchLeave", DateTime.Now.ToString(), InternalID.ToString()));
            if (StretchLeave != null)
                StretchLeave((object)this, new EventArgs());
        }

        protected virtual void OnRotateEnter()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: RotateEnter", DateTime.Now.ToString(), InternalID.ToString()));
            if (RotateEnter != null)
                RotateEnter((object)this, new EventArgs());
        }
        protected virtual void OnRotateHover()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: RotateHover", DateTime.Now.ToString(), InternalID.ToString()));
            if (RotateHover != null)
                RotateHover((object)this, new EventArgs());
        }
        protected virtual void OnRotateLeave()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: RotateLeave", DateTime.Now.ToString(), InternalID.ToString()));
            if (RotateLeave != null)
                RotateLeave((object)this, new EventArgs());
        }

        protected virtual void OnReshapeEnter()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ReshapeEnter", DateTime.Now.ToString(), InternalID.ToString()));
            if (ReshapeEnter != null)
                ReshapeEnter((object)this, new EventArgs());
        }
        protected virtual void OnReshapeHover()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ReshapeHover", DateTime.Now.ToString(), InternalID.ToString()));
            if (ReshapeHover != null)
                ReshapeHover((object)this, new EventArgs());
        }
        protected virtual void OnReshapeLeave()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ReshapeLeave", DateTime.Now.ToString(), InternalID.ToString()));
            if (ReshapeLeave != null)
                ReshapeLeave((object)this, new EventArgs());
        }

        protected virtual void OnActivated()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: Activated", DateTime.Now.ToString(), InternalID.ToString()));
            if (Activated != null)
                Activated((object)this, new EventArgs());
        }
        protected virtual void OnDeactivated()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: Deactivated", DateTime.Now.ToString(), InternalID.ToString()));
            if (Deactivated != null)
                Deactivated((object)this, new EventArgs());
        }
        protected virtual void OnActivationChanged()
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ActivationChanged", DateTime.Now.ToString(), InternalID.ToString()));
            if (ActivationChanged != null)
                ActivationChanged((object)this, new EventArgs());
        }

        //Handle self generated events (Debug only)
        /*protected virtual void HandleClick(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: Click", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleMouseEnter(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MouseEnter", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleMouseHover(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MouseHover", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleMouseLeave(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MouseLeave", DateTime.Now.ToString(), InternalID.ToString()));
        }

        protected virtual void HandleMoveEnter(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MoveEnter", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleMoveHover(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MoveHover", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleMoveLeave(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: MoveLeave", DateTime.Now.ToString(), InternalID.ToString()));
        }

        protected virtual void HandleStretchEnter(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: StretchEnter", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleStretchHover(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: StretchHover", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleStretchLeave(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: StretchLeave", DateTime.Now.ToString(), InternalID.ToString()));
        }

        protected virtual void HandleRotateEnter(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: RotateEnter", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleRotateHover(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: RotateHover", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleRotateLeave(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: RotateLeave", DateTime.Now.ToString(), InternalID.ToString()));
        }

        protected virtual void HandleReshapeEnter(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ReshapeEnter", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleReshapeHover(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ReshapeHover", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleReshapeLeave(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ReshapeLeave", DateTime.Now.ToString(), InternalID.ToString()));
        }

        protected virtual void HandleActivated(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: Activated", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleDeactivated(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: Deactivated", DateTime.Now.ToString(), InternalID.ToString()));
        }
        protected virtual void HandleActivationChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(string.Format("[{0}] Shape {1}: ActivationChanged", DateTime.Now.ToString(), InternalID.ToString()));
        }
        */

        public void SetBitmapFile(string filename)
        {
            this.mBmp = new Bitmap(filename);
        }

        public void SetBitmap(Bitmap bmp)
        {
            this.mBmp = bmp;
        }

        //подписать стандартные обработчики на все свои события (отладочный вывод в консоль)
        /*public void SubscribeOnAllSelfEvents()
        {
            Click += new EventHandler(HandleClick);
            MouseEnter += new EventHandler(HandleMouseEnter);
            MouseHover += new EventHandler(HandleMouseHover);
            MouseLeave += new EventHandler(HandleMouseLeave);

            MouseEnter += new EventHandler(HandleMouseEnter);
            MouseHover += new EventHandler(HandleMouseHover);
            MouseLeave += new EventHandler(HandleMouseLeave);
        }*/

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
