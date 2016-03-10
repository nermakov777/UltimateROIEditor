using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nini.Config;

using UltimateROIEditor.Shapes;
using UltimateROIEditor.Math;

namespace UltimateROIEditor
{
    public enum FileFormat
    { 
        INI, XML
    }
    public enum IniFormat
    { 
        Default, ZoneLS
    }
    public enum MouseMode 
    { 
        None,
        RectEditMove,
        RectEditResize,
        RectAdd
    }
    public enum RectEditMode
    { 
        None,
        LeftTop,
        Top,
        RightTop,
        Right,
        RightBottom,
        Bottom,
        LeftBottom,
        Left
    }

    public enum RectangleFormat
    { 
        LTRB,  //left top right bottom
        XYWH  //x y width height
    }

    //в каком виде записаны координаты точек в текстовом файле
    //и как их нужно оттуда читать
    public enum CoordType
    { 
        Unknown,   //неизвестно 
        Absolute,   //в пикселях
        RelativeFloat,  //в долях ширины и высоты
        RelativeInt   //в долях, но с умножением на 10000
    }
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int mode = 0;

        ShapeCreator Creator = new ShapeCreator();

        List<UltimateShape> figures = new List<UltimateShape>();

        public List<UltimateSet> SetList = new List<UltimateSet>();

        const int norm = 10000;

        string fullPathToIni = "";
        string pathToExeFromCmd = "";
		string fullPathToExe = "";
		string pathToExeDir = "";

        bool IsIniFounded = false;

        string pictureFileName = "example\\zones\\image.jpg";
        string zonesFileName = "example\\zones\\zones.txt";
        CoordType CoordType = CoordType.Absolute;
        RectangleFormat RectangleFormat = RectangleFormat.LTRB;

        MouseMode mouseMode = MouseMode.None;
        RectEditMode rectEditMode = RectEditMode.None;

        int IndexOfCapturedRect = -1;
        RectEditMode CapturedNode = RectEditMode.None;

        PictureBox pictureBox;
        Image image;
        
        public int WidthOfImage = 0;
        public int HeightOfImage = 0;
        public int WidthOfBox = 0;
        public int HeightOfBox = 0;

        float ratioX = 0;
        float ratioY = 0;
        float ratio = 0;
        int scale = 0;

        int x0 = 0, y0 = 0;
        int dx = 100, dy = 100;

        int dleft = 0, dtop = 0;

        //public List<UltimateRect> Rects = new List<UltimateRect>();

        //public List<Point> Points = new List<Point>();

        private void btnOpenPicture_Click(object sender, EventArgs e)
        {
            if (openPictureFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureFileName = openPictureFileDialog.FileName;

               // try
               // {
                LoadImage(pictureFileName);
               // }
               // catch (System.IO.FileNotFoundException)
               // {
                //    MessageBox.Show("There was an error opening the bitmap." + "Please check the path.");
               // }
            }
        }

        private void LoadImage(string path)
        {
            image = (Bitmap)Image.FromFile(path, true);
            Update();
        }
        private void LoadImage(Bitmap bitmap)
        {
            image = bitmap;
            Update();
        }

        private void Update()
        {
            WidthOfImage = image.Width;
            HeightOfImage = image.Height;

            labelSize.Text = WidthOfImage + "x" + HeightOfImage;

            pictureBox.Image = image;
            pictureBox.Refresh();

            CalcRatio();
            ShowScale();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox = pictureBoxMain;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            WidthOfBox = pictureBoxMain.Width;
            HeightOfBox = pictureBoxMain.Height;

            //Points = new List<Point>();

            SetGroupBox.Visible = false;

            //btnOpenPicture.Text = "Open picture";

            //Данное приложение можно запустить:
            //1) без командных аргументов
            //2) с одним командным аргументом - путь до файла инициализации

            //В первом случае файл инициализации должен называться CamPrepare.ini и лежать рядом с CamPrepare.exe.
            //Если в момент запуска приложения CamPrepare.ini не будет обнаружен,
            //то мы просто позволяем загрузить произвольное изображение и произвольный файл с зонами

            IsIniFounded = TryToFindMainIni();

            if (IsIniFounded)
            {
                ReadMainIniFile();
            }
            else
            {
                SetDefaultImage();
            }   

            //Далее читаем файл камер, а также делаем поиск изображений в указанных директориях
            //ReadCamerasIni();
            //SearchImageDirectories();

            //regionSelect->SelectedIndex = 0;
            //camSelect->SelectedIndex = 0;
            //HandleRegionSelect();
            
            //ReadMainIniFile();
            
            
          
        }

        private bool TryToFindMainIni()
        { 
            //сначала получаем полный путь до exe-файла, который запущен
	        string[] args = Environment.GetCommandLineArgs();

	        int argsCount = args.Length; //сколько всего аргументов

	        if (argsCount > 1) //если есть какие-то аргументы
	        {
		        //сразу определяем путь до ini-файла
		        fullPathToIni = args[1];
	        }
	        else  //если запуск произошел без аргументов
	        {
		        pathToExeFromCmd = args[0];
		        fullPathToExe = System.IO.Path.GetFullPath(pathToExeFromCmd);

		        //директория запуска exe
		        pathToExeDir = System.IO.Path.GetDirectoryName(fullPathToExe);
		        //System::Console::WriteLine(">> Executable directory: {0}", AppConfig->pathToExeDir);
		        //System::Console::WriteLine(">> Searching ini-file in executable directory...");

		        //путь до ini-файла
		        fullPathToIni = pathToExeDir + "\\UltimateROIEditor.ini";
	        }

	        //проверяем существование файла
	        bool IsFileExists = System.IO.File.Exists(fullPathToIni);
	        return IsFileExists;
        }

        private void ReadMainIniFile()
        { 
            //пытаемся прочитать ini-файл, который должен лежать рядом с EXE
            //если не получается - показываем просто белую картинку и позволяем загрузить/сохранить зоны

            try
            {
                //загружаем сеты из файла
                if (SetList == null)
                    SetList = new List<UltimateSet>();
                else if (SetList.Count > 0)
                    SetList.Clear();
                
                string label, pathToImage, pathToZones;
                IConfigSource source = new IniConfigSource(fullPathToIni);
                int SetCount = source.Configs["GENERAL"].GetInt("SetCount", 0);

                for (int i = 0; i < SetCount; ++i)
                {
                    label = source.Configs["GENERAL"].Get("Set[" + i + "].label", "");
                    pathToImage = source.Configs["GENERAL"].Get("Set[" + i + "].image", "");
                    pathToZones = source.Configs["GENERAL"].Get("Set[" + i + "].zones", "");
                    UltimateSet USet = new UltimateSet(label, pathToImage, pathToZones);
                    SetList.Add(USet);
                }

                //выводим сеты в комбобокс
                SetComboBox.Items.Clear();
                foreach (UltimateSet USet in SetList)
                    SetComboBox.Items.Add(USet.Label);
                SetGroupBox.Visible = true;

                //выбираем первый сет
                SetComboBox.SelectedIndex = 0;
                //ChooseSet(0);
            }
            catch (Nini.Ini.IniException ex)
            {
                MessageBox.Show("Exception with ini file. Text: " + ex.ToString(), "Exception");
            }
        }

        private void LoadSet(int index)
        {
            pictureFileName = SetList[index].ImagePath;
            zonesFileName = SetList[index].ZonesPath;

            LoadImage(pictureFileName);
            LoadZones(zonesFileName);
        }

        public void SetDefaultImage()
        { 
            //показываем белую картинку, на которой можно рисовать зоны
            Bitmap blank = GetBlank(640, 480);
            LoadImage(blank);
        }

        private Bitmap GetBlank(int width, int height)
        {
            Bitmap blank = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(blank);
            //g.DrawRectangle();
            SolidBrush brush = new SolidBrush(Color.White);
            g.FillRectangle(brush, new Rectangle(0, 0, width, height));
            return blank;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBoxMain_SizeChanged(object sender, EventArgs e)
        {
            CalcRatio();
            ShowScale();
        }

        public void ShowScale()
        {
            labelScale.Text = scale + "%";
        }

        private void CalcRatio()
        {
            WidthOfBox = pictureBox.Width;
            HeightOfBox = pictureBox.Height;
            
            ratioX = (float)WidthOfBox / (float)WidthOfImage;
            ratioY = (float)HeightOfBox / (float)HeightOfImage;

            ratio = System.Math.Min(ratioX, ratioY);

            scale = (int)System.Math.Round(ratio * 100.0f);
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            int a = 8;
            CalcRatio();

            //e.Graphics.DrawEllipse();
            /*foreach (Point p in Points)
            {
                
                PointF center = new PointF(0, 0);
                PointF src = new PointF(p.X, p.Y);
                PointF dst = CvtCoord_ImageToWindow(src, center, ratio, image.Size, pictureBox.Size);
                int x = (int)dst.X;
                int y = (int)dst.Y;

                e.Graphics.DrawEllipse(new Pen(Color.Black, 2.0f), new Rectangle(x - a/2, y - a/2, a, a));
                e.Graphics.FillEllipse(new SolidBrush(Color.Red), new Rectangle(x - a / 2, y - a / 2, a, a));
            }*/

            DrawRects(sender, e);
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            /*
            //обрабатываем сообщения только от контейнера с изображением
            //PictureBox pic = (PictureBox)sender;
            //if (pic != pictureBox) return;
            CalcRatio();
            PointF p = new PointF(e.X, e.Y);
            PointF q = CvtCoord_WindowToImage(p, new PointF(0,0), ratio, image.Size, pictureBox.Size);

            //labelPointP.Text = p.X + "; " + p.Y;
            //labelPointQ.Text = q.X + "; " + q.Y;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //CalcRatio();
                
                //PointF center = new PointF(pictureBox.Width/2, pictureBox.Height/2);
                PointF center = new PointF(0, 0);
                PointF src = new PointF(e.X, e.Y);
                PointF dst = CvtCoord_WindowToImage(src, center, ratio, image.Size, pictureBox.Size);

                //Points.Add(new Point(e.X, e.Y));
                //Points.Add(new Point((int)dst.X, (int)dst.Y));
                //pictureBox.Refresh();

                if (mouseMode == MouseMode.RectAdd)
                {
                    Rectangle coords = new Rectangle((int)q.X, (int)q.Y, 1, 1);
                    UltimateRect ulr = new UltimateRect(coords);
                    figures.Add(ulr);

                    //сразу же запускаем редактирование этого прямоугольника
                    mouseMode = MouseMode.RectEditResize;
                    IndexOfCapturedRect = figures.Count - 1;
                    CapturedNode = RectEditMode.RightBottom;

                    pictureBox.Refresh();
                }
                if (mouseMode == MouseMode.None)
                {
                    if (CheckRectCapture(p, q) == false)
                    {
                        mouseMode = MouseMode.None;
                        IndexOfCapturedRect = -1;
                    }
                }

            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                //Points.Clear();
                //Rects.Clear();
                //mouseMode = MouseMode.None;
                //IndexOfCapturedRect = -1;
                //pictureBox.Refresh();
            }  */

            if (mode == 1)
            {
                mode = 0;
                Creator.CreateInThisPoint(e.X, e.Y, pictureBox, figures);
            }
        }
        //=============================================================================
        // Из координат окна в реальные координаты изображения
        //=============================================================================
        public PointF CvtCoord_WindowToImage(PointF src, PointF center, float scale, Size imageSize, Size windowSize)
        {
	        PointF p = new PointF(src.X, src.Y);
	        p.X = (int)System.Math.Round(((float)windowSize.Width / 2.0f - p.X) / scale + center.X - (float)imageSize.Width / 2.0f);
            p.Y = (int)System.Math.Round(((float)windowSize.Height / 2.0f - p.Y) / scale + center.Y - (float)imageSize.Height / 2.0f);
	        p.X = -p.X;
	        p.Y = -p.Y;
	        return p;
        }
        //=============================================================================
        // Из реальных координат изображения в координаты окна
        //=============================================================================
        public PointF CvtCoord_ImageToWindow(PointF src, PointF center, double scale, Size imageSize, Size windowSize)
        {
	        PointF p = new PointF(src.X, src.Y);
            p.X = (int)System.Math.Round(((float)p.X + center.X - imageSize.Width / 2.0f) * scale + windowSize.Width / 2.0f);
            p.Y = (int)System.Math.Round(((float)p.Y + center.Y - imageSize.Height / 2.0f) * scale + windowSize.Height / 2.0f);
	        return p;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrepareToAdd();
        }

        public void PrepareToAdd()
        {
            mouseMode = MouseMode.RectAdd;
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (image == null) return;

            //this.Cursor = Cursors.Default;
            CalcRatio();
            PointF p = new PointF(e.X, e.Y);
            PointF q = CvtCoord_WindowToImage(p, new PointF(0, 0), ratio, image.Size, pictureBox.Size);

            //labelPointP.Text = p.X + "; " + p.Y;
            //labelPointQ.Text = q.X + "; " + q.Y;

            if (mouseMode == MouseMode.RectEditMove || mouseMode == MouseMode.RectEditResize)
            { 
                HandleRectCapture(q);
            }

            pictureBox.Refresh();
        }

        private void HandleRectCapture(PointF q)
        {
            /*int i = IndexOfCapturedRect;
            if (i == -1) return;

            if (mouseMode == MouseMode.RectEditMove)
            {
                //перемещение всего прямоугольника
                Rectangle R = Rects[i].Rect;
                int width = R.Width;
                int height = R.Height;
                int left = Rects[i].Rect.X = (int)q.X - dleft;
                int top = Rects[i].Rect.Y = (int)q.Y - dtop;
                //Rects[i].Rect.right = left + width;
                //(imData->rects->at(i)).Rect.bottom = right + height;
            }

            int b = 0;

            //Все узлы работают на сжатие/растяжение
            if (mouseMode == MouseMode.RectEditResize)
            {
                //берем указатель на рект, чтобы менять его параметры
                Rectangle R = Rects[i].Rect;
                WinRECT r = new WinRECT(R.X, R.Y, R.X + R.Width, R.Y + R.Height);

                //меняем параметры ректа в зависимости от того, какой .L захвачен
                if (CapturedNode == RectEditMode.LeftTop) { r.left = (int)q.X; r.top = (int)q.Y; }
                if (CapturedNode == RectEditMode.Top) { r.top = (int)q.Y; }
                if (CapturedNode == RectEditMode.RightTop) { r.right = (int)q.X; r.top = (int)q.Y; }
                if (CapturedNode == RectEditMode.Right) { r.right = (int)q.X;  }
                if (CapturedNode == RectEditMode.RightBottom) { r.right = (int)q.X; r.bottom = (int)q.Y; }
                if (CapturedNode == RectEditMode.Bottom) { r.bottom = (int)q.Y; }
                if (CapturedNode == RectEditMode.LeftBottom) { r.left = (int)q.X; r.bottom = (int)q.Y; }
                if (CapturedNode == RectEditMode.Left) { r.left = (int)q.X; }

                //при перемещении узлов могут поменяться местами левая сторона и правая
                //или верхняя сторона и нижняя; эти ситуации нужно обрабатывать

                if (r.left > r.right) //перепутались левая и правая сторона
                {
                    //свопаем границы
                    b = r.left;
                    r.right = r.left;
                    r.left = b;

                    //переключаемся на противоположный узел
                    if (CapturedNode == RectEditMode.Left) CapturedNode = RectEditMode.Right;
                    else if (CapturedNode == RectEditMode.LeftTop) CapturedNode = RectEditMode.RightTop;
                    else if (CapturedNode == RectEditMode.LeftBottom) CapturedNode = RectEditMode.RightBottom;
                    else if (CapturedNode == RectEditMode.Right) CapturedNode = RectEditMode.Left;
                    else if (CapturedNode == RectEditMode.RightTop) CapturedNode = RectEditMode.LeftTop;
                    else if (CapturedNode == RectEditMode.RightBottom) CapturedNode = RectEditMode.LeftBottom;
                }
                if (r.top > r.bottom) //перепутались верхняя и нижняя сторона
                {
                    //свопаем границы
                    b = r.top;
                    r.bottom = r.top;
                    r.top = b;

                    //переключаемся на противоположный узел
                    if (CapturedNode == RectEditMode.Top) CapturedNode = RectEditMode.Bottom;
                    else if (CapturedNode == RectEditMode.LeftTop) CapturedNode = RectEditMode.LeftBottom;
                    else if (CapturedNode == RectEditMode.RightTop) CapturedNode = RectEditMode.RightBottom;
                    else if (CapturedNode == RectEditMode.Bottom) CapturedNode = RectEditMode.Top;
                    else if (CapturedNode == RectEditMode.LeftBottom) CapturedNode = RectEditMode.LeftTop;
                    else if (CapturedNode == RectEditMode.RightBottom) CapturedNode = RectEditMode.RightTop;
                }
                
                Rects[i].Rect = new Rectangle(r.left, r.top, r.right - r.left, r.bottom - r.top);
            }

           
            Rects[i].CalcNodes();*/
        }

        public bool CheckRectCapture(PointF p, PointF q)
        {
            //Есть понятие - рект активный и неактивный. 
            //Чтобы сделать рект активным - нужно кликнуть внутрь него.
            //Если кликнуть в свободное место - активация с любого ректа снимается.
            //Одновременно может быть только один активный рект - все остальные неактивные.
            //Редактировать можно только активный рект - тянуть за ноды (узлы) и так далее.
            //При активации ноды отрисовываются и становятся видны.
            //Неактивные ректы выглядят как обычные прямоугольники, ноды не показываются.
            //Если кликнуть ПКМ по неактивному (для вызова контекстного меню) - он 
            //активируется и появится контекстное меню.
	
            //if (imData->rects->size() == 0) return false;

            //1. Проверка захвата какого-либо узла - это будет его растягивать.
            //   Выполняется только для активного ректа. Все остальные не трогаем.

            /*const float EPS = 5.0f;
            CalcRatio();
            
            int idx = IndexOfCapturedRect;
            if (idx != -1)
            {
                UltimateRect FRect = Rects[idx];
                for (int j = 0; j < 8; ++j)
                {
                    PointF nodePointImage = FRect.Nodes[j];
                    PointF nodePointWindow = CvtCoord_ImageToWindow(nodePointImage, new PointF(0,0), ratio, image.Size, pictureBox.Size);
                    if ((Math.Abs(p.X - nodePointWindow.X) <= EPS) && 
                        (Math.Abs(p.Y - nodePointWindow.Y) <= EPS)) //захват узла
                    {
                        mouseMode = MouseMode.RectEditResize; //перемещение узла ректа
                        CapturedNode = (RectEditMode)(j + 1);
                        return true; //сразу выходим
                    }
                } //end for
            } //end if

            //2. Проверка попадания внутрь какого-либо ректа - это его активирует.
            //   При этом со всех остальных ректов активация снимается.
            for (int i = 0; i < Rects.Count; ++i) 
            {
                UltimateRect FRect = Rects[i];
    
                //пересчет в координаты окна
                Rectangle rect_wnd = CvtRectCoord_ImageToWindow(FRect.Rect, new PointF(0,0), ratio, image.Size, pictureBox.Size);
                
                //System::Drawing::Rectangle dotNetRect = CvtRect_Win32ToDotNet(rect_wnd);
                if (rect_wnd.Contains((int)(p.X), (int)(p.Y)))
                {
                    IndexOfCapturedRect = i; //делаем рект активным
                    mouseMode = MouseMode.RectEditMove; //перемещение всего ректа
                    //запоминаем куда именно кликнули
                    PointF cursor_img = q; // CvtCoord_WindowToImage(q, new PointF(0, 0), ratio, image.Size, pictureBox.Size);
                    dleft = (int)cursor_img.X - FRect.Rect.Left;
                    dtop = (int)cursor_img.Y - FRect.Rect.Top;
                    return true; //сразу выходим
                }
            } //end for
             */
            return false;
            
        }
        Rectangle CvtRectCoord_ImageToWindow(Rectangle src, PointF center, float scale, Size imageSize, Size windowSize)
        {
            PointF LT = new PointF(src.Left, src.Top);
	        PointF RB = new PointF(src.Right, src.Bottom);
	        PointF LT2 = CvtCoord_ImageToWindow(LT, center, scale, imageSize, windowSize);
	        PointF RB2 = CvtCoord_ImageToWindow(RB, center, scale, imageSize, windowSize);
            Rectangle dst = new Rectangle((int)LT2.X, (int)LT2.Y, (int)(RB2.X - LT2.X), (int)(RB2.Y - LT2.Y));
	        return dst;
        }
        Rectangle CvtRectCoord_WindowToImage(Rectangle src, PointF center, float scale, Size imageSize, Size windowSize)
        {
            PointF LT = new PointF(src.Left, src.Top);
            PointF RB = new PointF(src.Right, src.Bottom);
            PointF LT2 = CvtCoord_WindowToImage(LT, center, scale, imageSize, windowSize);
            PointF RB2 = CvtCoord_WindowToImage(RB, center, scale, imageSize, windowSize);
            Rectangle dst = new Rectangle((int)LT2.X, (int)LT2.Y, (int)(RB2.X - LT2.X), (int)(RB2.Y - LT2.Y));
            return dst;
        }

        public void DrawRects(object sender, PaintEventArgs  e)
        {
            /*if (image == null)
                return;

            Pen  redPen = new Pen(Color.Red, 2.0f); 
	        Pen  blackPen = new Pen(Color.Black, 2.0f);
	        Pen  whitePen = new Pen(Color.White, 2.0f); 
	        SolidBrush drawBrush = new SolidBrush(Color.Yellow);
            Font font = new Font("Arial", 12);
        
	        //Size imageSize = SD::Size(image.cols, image.rows);
	        //Size windowSize = SD::Size(((Windows::Forms::PictureBox^)sender)->Width, ((Windows::Forms::PictureBox^)sender)->Height);

	        //проход по всем прямоугольникам
	        for (int i = 0; i < Rects.Count; i++)
	        {
		        CalcRatio();
                UltimateRect FRect = Rects[i]; //текущий объект

		        //сначала рисуем саму фигуру - прямоугольник
		        PointF left_top = new PointF(FRect.Rect.Left, FRect.Rect.Top);
		        PointF right_bottom = new PointF(FRect.Rect.Right, FRect.Rect.Bottom);
		        PointF LT = CvtCoord_ImageToWindow(left_top, new PointF(0,0), ratio, image.Size, pictureBox.Size);
		        PointF RB = CvtCoord_ImageToWindow(right_bottom,  new PointF(0,0), ratio, image.Size, pictureBox.Size);
		        Rectangle rect = new Rectangle((int)LT.X, (int)LT.Y, (int)(RB.X - LT.X), (int)(RB.Y - LT.Y));
		
		        Color color = Color.Black;
		        Pen  specificPen = new  Pen(color, 2.0f); 
		        SolidBrush  specificBrush = new SolidBrush(color); //кисть: черный
                PointF textPosition = new PointF(rect.X + rect.Width, rect.Y + rect.Height);

		        //непосредственно сам прямоугольник
		        e.Graphics.DrawRectangle(specificPen, rect);

                //подпись с числовым идентификатором зоны
                

                string IDLabel = FRect.ID.ToString();
                //string measureString = "Measure String";
                //Font stringFont = new Font("Arial", 16);

                // Set maximum width of string.
                int stringWidth = 200;

                // Measure string.
                SizeF stringSize = new SizeF();
                stringSize = e.Graphics.MeasureString(IDLabel, font, stringWidth);

                Rectangle textRect = new Rectangle(rect.X + rect.Width, rect.Y + rect.Height, 
                    (int)stringSize.Width,
                    (int)stringSize.Height);
                e.Graphics.DrawRectangle(redPen, textRect);
                e.Graphics.FillRectangle(drawBrush, textRect);

                e.Graphics.DrawString(IDLabel, font, specificBrush, textPosition);

		        //затем рисуем все узлы в цикле - только для активного ректа
		        if (i == IndexOfCapturedRect)
		        {
			        for (int j = 0; j < 8; ++j)
			        {
				        //берем текущую точку и переводим координаты
				        PointF p = FRect.Nodes[j];
				        PointF q = CvtCoord_ImageToWindow(p, new PointF(0,0), ratio, image.Size, pictureBox.Size);

				        //рисуем квадрат
				        int a = 8;
				        Rectangle node = new Rectangle((int)Math.Round(q.X) - a/2, (int)Math.Round(q.Y) - a/2, a, a);
				        e.Graphics.DrawEllipse(blackPen, node);
				        e.Graphics.FillEllipse(specificBrush, node);
			        }
		        }
	        }*/
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            /*PointF p = new PointF(e.X, e.Y);
            PointF q = CvtCoord_WindowToImage(p, new PointF(0,0), ratio, image.Size, pictureBox.Size);
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (mouseMode != MouseMode.None)
                {
                    mouseMode = MouseMode.None;
                    //IndexOfCapturedRect = -1;
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                bool IsActivated = false;
				
                //Проверяем выделение прямоугольников
				for (int i = 0; i < Rects.Count; ++i) //цикл по всем ректам
				{
					UltimateRect FRect = Rects[i]; //текущий рект
					//if (IsRectOff(FRect)) continue; //данный тип ректов может быть выключен
					//System::Drawing::Rectangle dotNetRect = CvtRect_Win32ToDotNet(FRect.Rect); //преобразуем в модный тип
					if (FRect.Rect.Contains((int)Math.Round(q.X), (int)Math.Round(q.Y))) //попадание точки в прямоугольник
					{
						contextMenuStrip2.Show((Control)sender, e.X, e.Y);
						IndexOfCapturedRect = i; //делаем рект активным
                        pictureBox.Refresh();
						IsActivated = true;
						break;
					}
				} //end for

				if (IsActivated == false) //если ни один рект не выбрался
				{
					//Добавление нового прямоугольника
					contextMenuStrip1.Show((Control)sender, e.X, e.Y);
				}
            }*/
        }

        private void addZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrepareToAdd();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //removeSelectedZone
            //ImageData^ imData = compToImage[mapImage]; //get form sender?
	        
            /*int i = IndexOfCapturedRect;
	        if (i == -1) return;

            UltimateRect FRect = Rects[i];
	        //int Type = FRect.Type;
            Rects.RemoveAt(i);
            //imData->rects->erase(imData->rects->begin() + i); //удаляем из массива

	        //удаляем из таблицы
	        //DGrid_RemoveRect(dataGridView2, imData, i);

	        //сбрасываем активность
	        IndexOfCapturedRect = -1;*/
        }

        private void setIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*int i = IndexOfCapturedRect;
            if (i == -1) return;

            UltimateRect FRect = Rects[i];
            
            SetIDForm F = new SetIDForm();
            F.ID = FRect.ID;
            DialogResult result = F.ShowDialog();
            if (result == DialogResult.OK)
            {
                FRect.ID = F.ID;
            }*/
        }

        //формат файла: 
        
        //CoordsType = Absolute
        //ID1 left top right bottom
        //ID2 left top right bottom
        //ID3 left top right bottom
        //...

        /*public void WriteToFile(string path)
        {
            StreamWriter Writer = new StreamWriter(path);
            
            //в первой строке пишем тип координат
            //if (CoordType == CoordType.Absolute) Writer.WriteLine("CoordsType = Absolute");
            //if (CoordType == CoordType.RelativeFloat) Writer.WriteLine("CoordsType = RelativeFloat");
            //if (CoordType == CoordType.RelativeInt) Writer.WriteLine("CoordsType = RelativeInt10000");

            //в последующих строках ID зоны и координаты её точек
            foreach (UltimateRect URect in Rects)
            {
                if (CoordType == CoordType.Absolute)
                {
                    Writer.WriteLine(URect.ID + " " + URect.Rect.Left + " " + URect.Rect.Top + 
                        " " + URect.Rect.Right + " " + URect.Rect.Bottom);
                }
                else
                {
                    int left = (int)Math.Round((float)URect.Rect.Left / (float)image.Size.Width * (float)norm);
                    int top = (int)Math.Round((float)URect.Rect.Top / (float)image.Size.Height * (float)norm );
                    int right = (int)Math.Round((float)URect.Rect.Right / (float)image.Size.Width * (float)norm);
                    int bottom = (int)Math.Round((float)URect.Rect.Bottom / (float)image.Size.Height * (float)norm);

                    Writer.WriteLine(URect.ID + " " + left + " " + top +
                       " " + right + " " + bottom);
                }
            }

            MessageBox.Show(Rects.Count + " zones saved", "Info");
            Writer.Close();
        }*/

        public void WriteToFile(string path)
        {
            StreamWriter Writer = new StreamWriter(path);

            //в первой строке пишем тип координат
            //if (CoordType == CoordType.Absolute) Writer.WriteLine("CoordsType = Absolute");
            //if (CoordType == CoordType.RelativeFloat) Writer.WriteLine("CoordsType = RelativeFloat");
            //if (CoordType == CoordType.RelativeInt) Writer.WriteLine("CoordsType = RelativeInt10000");

            //в последующих строках ID зоны и координаты её точек
            /*foreach (UltimateRect URect in Rects)
            {     
                int left = (int)Math.Round((float)URect.Rect.Left / (float)image.Size.Width * (float)norm);
                int top = (int)Math.Round((float)URect.Rect.Top / (float)image.Size.Height * (float)norm);
                int right = (int)Math.Round((float)URect.Rect.Right / (float)image.Size.Width * (float)norm);
                int bottom = (int)Math.Round((float)URect.Rect.Bottom / (float)image.Size.Height * (float)norm);

                int x = left;
                int y = top;
                int width = right - left;
                int height = bottom - top;

                //Writer.WriteLine(URect.ID + " " + left + " " + top + " " + right + " " + bottom);
                Writer.WriteLine(URect.ID + " " + x + " " + y + " " + width + " " + height);
            }

            MessageBox.Show(Rects.Count + " zones saved", "Info");
            Writer.Close();*/
        }

        public void ReadFromFileINI(string path)
        {
            /*try
            {
                IConfigSource source = new IniConfigSource(path);
                //int w = source.Configs["HEADER"].GetInt("Image.Width");
                //int h = source.Configs["HEADER"].GetInt("Image.Height");
                string CoordsType = source.Configs["HEADER"].Get("CoordsType", "Absolute");
                string RectangleFormat = source.Configs["HEADER"].Get("RectangleFormat", "LTRB");
                int Norm = source.Configs["HEADER"].GetInt("Norm", 100);
                int ZonesCount = source.Configs["HEADER"].GetInt("ZonesCount", 0);

                if (CoordsType.Contains("Absolute")) CoordType = CoordType.Absolute;
                else if (CoordsType.Contains("RelativeFloat")) CoordType = CoordType.RelativeFloat;
                else if (CoordsType.Contains("RelativeInt")) CoordType = CoordType.RelativeInt;
                else CoordType = CoordType.Unknown;

                ReadZonesCoords(ZonesCount, source);

                string line = "";
                StreamReader Reader = new StreamReader(path);
                int N = 0;

                //читаем построчно
                Rects.Clear();
                while ((line = Reader.ReadLine()) != null)
                {
                    N++;
                    if (N == 1) //первая строка
                    {
                        if (line.Contains("Absolute")) CoordType = CoordType.Absolute;
                        else if (line.Contains("RelativeFloat")) CoordType = CoordType.RelativeFloat;
                        else if (line.Contains("RelativeInt")) CoordType = CoordType.RelativeInt;
                        else CoordType = CoordType.Unknown;

                        //if (CoordType == CoordType.Absolute) CoordType.SelectedIndex = 0;
                        //if (CoordType == CoordType.RelativeInt) CoordType.SelectedIndex = 1;

                        if (CoordType == CoordType.Unknown)
                            return;
                    }
                    else
                    {
                        
                    }

                }

                //MessageBox.Show(Rects.Count + " zones loaded", "Info");
                Reader.Close();
            }
            catch (Nini.Ini.IniException ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
            finally
            {
                //Reader.Close();
            }   */
        }

        public void ReadFromFile(string path)
        {
            /*string line = "";
            StreamReader Reader = new StreamReader(path);
            //int N = 0;

            //читаем построчно
            Rects.Clear();
            while ((line = Reader.ReadLine()) != null)
            {
       
                UltimateRect URect = ParseString(line);

                //наша цель - получить координаты просто в пикселях 
                Size imageSize = image.Size;
                URect.ID = Rects.Count();
                URect.Rect.X = (int)Math.Round((float)URect.Rect.X / (float)norm * (float)image.Size.Width);
                URect.Rect.Y = (int)Math.Round((float)URect.Rect.Y / (float)norm * (float)image.Size.Height);
                URect.Rect.Width = (int)Math.Round((float)URect.Rect.Width / (float)norm * (float)image.Size.Width);
                URect.Rect.Height = (int)Math.Round((float)URect.Rect.Height / (float)norm * (float)image.Size.Height);
                   
                Rects.Add(URect);
            }

            Reader.Close();*/
        }

        public void ReadZonesCoords(int ZonesCount, IConfigSource source)
        {
            /*for (int i = 0; i < ZonesCount; ++i)
            {
                string ZoneKey = "Zone" + i;
                string ZoneValue = source.Configs["Zones"].Get("ZoneKey", "");
                if (ZoneValue.Length == 0) continue;

                RectangleF ZoneRectangle = ParseStringToRectangle(ZoneValue, CoordType);
                UltimateRect URect = RectangleToUltimateRect(ZoneRectangle);
                Rects.Add(URect);
            }*/
        }
        public RectangleF ParseStringToRectangle(string line, CoordType type)
        {
            char[] separators = { ' ' };
            string[] splitted = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //int ID = Convert.ToInt32(splitted[0]);
            float left = (float)Convert.ToDouble(splitted[1]);
            float top = (float)Convert.ToInt32(splitted[2]);
            float right = (float)Convert.ToInt32(splitted[3]);
            float bottom = (float)Convert.ToInt32(splitted[4]);
            float width = right - top;
            float height = bottom - top;
            RectangleF R = new RectangleF(left, top, width, height);
            return R;
        }

        public UltimateRect RectangleToUltimateRect(RectangleF R)
        {
            return null;
        }

        public UltimateRect ParseString(string line)
        {
            char[] separators = { ' '};
            string[] splitted = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            if (splitted.Length < 5)
                return null;
            int ID = Convert.ToInt32(splitted[0]);
            int x = Convert.ToInt32(splitted[1]);
            int y = Convert.ToInt32(splitted[2]);
            int width = Convert.ToInt32(splitted[3]);
            int height = Convert.ToInt32(splitted[4]);
            Rectangle R = new Rectangle(x, y, width, height);

            UltimateRect URect = new UltimateRect(R);
            return URect;
        }

        private void btnOpenZones_Click(object sender, EventArgs e)
        {
            if (openZonesFileDialog.ShowDialog() == DialogResult.OK)
            {
                zonesFileName = openZonesFileDialog.FileName;
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadZones(zonesFileName);
        }

        private void LoadZones(string path)
        {
            ReadFromFile(zonesFileName);
            pictureBox.Refresh();
            //MessageBox.Show(Rects.Count + " zones loaded", "Info");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //SaveToFileForm SaveForm = new SaveToFileForm();
            //SaveForm.parent = this;
            //SaveForm.ShowDialog();

            WriteToFile(zonesFileName);
        }

        private void comboBoxCoordsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBoxCoordsType.SelectedIndex == 0) typeOfCoords = CoordType.Absolute;
            //if (comboBoxCoordsType.SelectedIndex == 1) typeOfCoords = CoordType.RelativeInt;

            
        }

        

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (IsIniFounded)
            {
                //ReadMainIniFile();
                MessageBox.Show("Ini-file founded", "Info");
            }
            else
            {
                //SetDefaultImage();
                MessageBox.Show("Ini-file not founded. This file should be placed near EXE", "Warning");
            }  
        }

        private void SetComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSet(SetComboBox.SelectedIndex);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (UltimateShape figure in figures)
                figure.ReleasePictureBox();
            figures.Clear();
            pictureBox.Refresh();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
        
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UltimatePolygon u = new UltimatePolygon();
            u.SetPictureBox(pictureBox);
            figures.Add(u);

            pictureBox.Invalidate();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            UltimatePoint u = new UltimatePoint(100, 100);
            u.SetPictureBox(pictureBox);
            figures.Add(u);
            pictureBox.Invalidate();
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            UltimateLine u = new UltimateLine(new Point(100,100), new Point(200,200));
            u.SetPictureBox(pictureBox);
            figures.Add(u);
            pictureBox.Invalidate();
        }

        private void btnAddRomb_Click(object sender, EventArgs e)
        {
            //UltimateRomb u = new UltimateRomb(new Rectangle(100,100,300,300));
            //u.SetPictureBox(pictureBox);
            //figures.Add(u);
            //pictureBox.Invalidate();

            mode = 1;
            Creator = new ShapeCreatorRomb();
        }

        private void btnAddTriangle2Side_Click(object sender, EventArgs e)
        {
            //UltimateTriangle2Side u = new UltimateTriangle2Side(new Rectangle(100, 100, 300, 300));
            //u.SetPictureBox(pictureBox);
            //figures.Add(u);
            //pictureBox.Invalidate();

            mode = 1;
            Creator = new ShapeCreatorTriangle2Side();
        }

        private void bntAddTriangleRect_Click(object sender, EventArgs e)
        {
            //UltimateTriangleRectangular u = new UltimateTriangleRectangular(new Rectangle(100, 100, 300, 300));
            //u.SetPictureBox(pictureBox);
            //figures.Add(u);
            //pictureBox.Invalidate();

            mode = 1;
            Creator = new ShapeCreatorTriangleRectangular();
        }

        private void btnAddRectangle_Click(object sender, EventArgs e)
        {
            mode = 1;
            Creator = new ShapeCreatorRectangle();

            /*UltimateRectangle urect = new UltimateRectangle(new Rectangle(100, 100, 200, 200));
            urect.SetPictureBox(pictureBox);
            figures.Add(urect);
            pictureBox.Invalidate();*/

            
        }

        private void btnAddEllipse_Click(object sender, EventArgs e)
        {
            //UltimateCircle u = new UltimateCircle();
            //u.SetPictureBox(pictureBox);
            //figures.Add(u);
            //pictureBox.Invalidate();

            mode = 1;
            Creator = new ShapeCreatorCircle();
        }

        private void btnAddLomania_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxMain_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LogClear();
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {

        }

        private void Form1_MouseHover(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddParallel_Click(object sender, EventArgs e)
        {
            UltimateParallel u = new UltimateParallel(new Rectangle(100, 100, 300, 100));
            u.SetPictureBox(pictureBox);
            figures.Add(u);
            pictureBox.Invalidate();
        }

        private void btnAddTrapecia_Click(object sender, EventArgs e)
        {
            //UltimateTrapecia u = new UltimateTrapecia(new Rectangle(100, 100, 300, 100));
            //u.SetPictureBox(pictureBox);
            //figures.Add(u);
            //pictureBox.Invalidate();

            mode = 1;
            Creator = new ShapeCreatorTrapecia();
        }
    }
}
