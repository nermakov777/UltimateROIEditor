namespace UltimateROIEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.btnOpenPicture = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.btnOpenZones = new System.Windows.Forms.Button();
            this.openPictureFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openZonesFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.labelScale = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSize = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SetComboBox = new System.Windows.Forms.ComboBox();
            this.SetGroupBox = new System.Windows.Forms.GroupBox();
            this.btnAddPoint = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.setIDToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fitToBoundingBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unfitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFigureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.triangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadrangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button10 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.форматToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.помощьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.btnAddRectangle = new System.Windows.Forms.Button();
            this.btnAddEllipse = new System.Windows.Forms.Button();
            this.btnAddTriangle2Side = new System.Windows.Forms.Button();
            this.bntAddTriangleRect = new System.Windows.Forms.Button();
            this.btnAddRomb = new System.Windows.Forms.Button();
            this.btnAddTrapecia = new System.Windows.Forms.Button();
            this.btnAddParallel = new System.Windows.Forms.Button();
            this.btnAddPoly5 = new System.Windows.Forms.Button();
            this.btnAddPoly6 = new System.Windows.Forms.Button();
            this.btnAddLomania = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SetGroupBox.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.contextMenuStrip4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxMain.Location = new System.Drawing.Point(136, 91);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(740, 483);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.SizeChanged += new System.EventHandler(this.pictureBoxMain_SizeChanged);
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseEnter += new System.EventHandler(this.pictureBoxMain_MouseEnter);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // btnOpenPicture
            // 
            this.btnOpenPicture.Location = new System.Drawing.Point(12, 31);
            this.btnOpenPicture.Name = "btnOpenPicture";
            this.btnOpenPicture.Size = new System.Drawing.Size(118, 23);
            this.btnOpenPicture.TabIndex = 2;
            this.btnOpenPicture.Text = "Open picture";
            this.btnOpenPicture.UseVisualStyleBackColor = true;
            this.btnOpenPicture.Click += new System.EventHandler(this.btnOpenPicture_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(324, 31);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // btnOpenZones
            // 
            this.btnOpenZones.Location = new System.Drawing.Point(136, 31);
            this.btnOpenZones.Name = "btnOpenZones";
            this.btnOpenZones.Size = new System.Drawing.Size(101, 23);
            this.btnOpenZones.TabIndex = 7;
            this.btnOpenZones.Text = "Open zones";
            this.btnOpenZones.UseVisualStyleBackColor = true;
            this.btnOpenZones.Click += new System.EventHandler(this.btnOpenZones_Click);
            // 
            // openPictureFileDialog
            // 
            this.openPictureFileDialog.FileName = "openFileDialog1";
            // 
            // openZonesFileDialog
            // 
            this.openZonesFileDialog.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Scale:";
            // 
            // labelScale
            // 
            this.labelScale.AutoSize = true;
            this.labelScale.Location = new System.Drawing.Point(193, 61);
            this.labelScale.Name = "labelScale";
            this.labelScale.Size = new System.Drawing.Size(33, 13);
            this.labelScale.TabIndex = 9;
            this.labelScale.Text = "100%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Size:";
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(48, 61);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(54, 13);
            this.labelSize.TabIndex = 11;
            this.labelSize.Text = "1600x900";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addZoneToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 26);
            // 
            // addZoneToolStripMenuItem
            // 
            this.addZoneToolStripMenuItem.Name = "addZoneToolStripMenuItem";
            this.addZoneToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.addZoneToolStripMenuItem.Text = "Add Zone";
            this.addZoneToolStripMenuItem.Click += new System.EventHandler(this.addZoneToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setIDToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(118, 48);
            // 
            // setIDToolStripMenuItem
            // 
            this.setIDToolStripMenuItem.Enabled = false;
            this.setIDToolStripMenuItem.Name = "setIDToolStripMenuItem";
            this.setIDToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.setIDToolStripMenuItem.Text = "Set ID";
            this.setIDToolStripMenuItem.Click += new System.EventHandler(this.setIDToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(243, 31);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 14;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Set:";
            // 
            // SetComboBox
            // 
            this.SetComboBox.FormattingEnabled = true;
            this.SetComboBox.Location = new System.Drawing.Point(38, 13);
            this.SetComboBox.Name = "SetComboBox";
            this.SetComboBox.Size = new System.Drawing.Size(121, 21);
            this.SetComboBox.TabIndex = 16;
            this.SetComboBox.SelectedIndexChanged += new System.EventHandler(this.SetComboBox_SelectedIndexChanged);
            // 
            // SetGroupBox
            // 
            this.SetGroupBox.Controls.Add(this.SetComboBox);
            this.SetGroupBox.Controls.Add(this.label1);
            this.SetGroupBox.Location = new System.Drawing.Point(405, 20);
            this.SetGroupBox.Name = "SetGroupBox";
            this.SetGroupBox.Size = new System.Drawing.Size(189, 47);
            this.SetGroupBox.TabIndex = 17;
            this.SetGroupBox.TabStop = false;
            // 
            // btnAddPoint
            // 
            this.btnAddPoint.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPoint.Image")));
            this.btnAddPoint.Location = new System.Drawing.Point(15, 126);
            this.btnAddPoint.Name = "btnAddPoint";
            this.btnAddPoint.Size = new System.Drawing.Size(32, 32);
            this.btnAddPoint.TabIndex = 22;
            this.btnAddPoint.UseVisualStyleBackColor = true;
            this.btnAddPoint.Click += new System.EventHandler(this.btnAddPoint_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(15, 392);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 38);
            this.button9.TabIndex = 26;
            this.button9.Text = "Clear";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setIDToolStripMenuItem1,
            this.fitToBoundingBoxToolStripMenuItem,
            this.unfitToolStripMenuItem,
            this.removeToolStripMenuItem1,
            this.removeToolStripMenuItem2,
            this.removeToolStripMenuItem3,
            this.removeToolStripMenuItem4});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(165, 158);
            // 
            // setIDToolStripMenuItem1
            // 
            this.setIDToolStripMenuItem1.Name = "setIDToolStripMenuItem1";
            this.setIDToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.setIDToolStripMenuItem1.Text = "Set ID";
            // 
            // fitToBoundingBoxToolStripMenuItem
            // 
            this.fitToBoundingBoxToolStripMenuItem.Name = "fitToBoundingBoxToolStripMenuItem";
            this.fitToBoundingBoxToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.fitToBoundingBoxToolStripMenuItem.Text = "Set label";
            // 
            // unfitToolStripMenuItem
            // 
            this.unfitToolStripMenuItem.Name = "unfitToolStripMenuItem";
            this.unfitToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.unfitToolStripMenuItem.Text = "Fit";
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(164, 22);
            this.removeToolStripMenuItem1.Text = "Unfit";
            // 
            // removeToolStripMenuItem2
            // 
            this.removeToolStripMenuItem2.Name = "removeToolStripMenuItem2";
            this.removeToolStripMenuItem2.Size = new System.Drawing.Size(164, 22);
            this.removeToolStripMenuItem2.Text = "To bounding box";
            // 
            // removeToolStripMenuItem3
            // 
            this.removeToolStripMenuItem3.Name = "removeToolStripMenuItem3";
            this.removeToolStripMenuItem3.Size = new System.Drawing.Size(164, 22);
            this.removeToolStripMenuItem3.Text = "Add vertex";
            // 
            // removeToolStripMenuItem4
            // 
            this.removeToolStripMenuItem4.Name = "removeToolStripMenuItem4";
            this.removeToolStripMenuItem4.Size = new System.Drawing.Size(164, 22);
            this.removeToolStripMenuItem4.Text = "Remove";
            // 
            // contextMenuStrip4
            // 
            this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFigureToolStripMenuItem});
            this.contextMenuStrip4.Name = "contextMenuStrip4";
            this.contextMenuStrip4.Size = new System.Drawing.Size(131, 26);
            // 
            // addFigureToolStripMenuItem
            // 
            this.addFigureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.triangleToolStripMenuItem,
            this.quadrangleToolStripMenuItem,
            this.rectangleToolStripMenuItem,
            this.nPolygonToolStripMenuItem});
            this.addFigureToolStripMenuItem.Name = "addFigureToolStripMenuItem";
            this.addFigureToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.addFigureToolStripMenuItem.Text = "Add figure";
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.pointToolStripMenuItem.Text = "Point";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.lineToolStripMenuItem.Text = "Line";
            // 
            // triangleToolStripMenuItem
            // 
            this.triangleToolStripMenuItem.Name = "triangleToolStripMenuItem";
            this.triangleToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.triangleToolStripMenuItem.Text = "Triangle";
            // 
            // quadrangleToolStripMenuItem
            // 
            this.quadrangleToolStripMenuItem.Name = "quadrangleToolStripMenuItem";
            this.quadrangleToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.quadrangleToolStripMenuItem.Text = "Quadrangle";
            // 
            // rectangleToolStripMenuItem
            // 
            this.rectangleToolStripMenuItem.Name = "rectangleToolStripMenuItem";
            this.rectangleToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.rectangleToolStripMenuItem.Text = "Rectangle";
            // 
            // nPolygonToolStripMenuItem
            // 
            this.nPolygonToolStripMenuItem.Name = "nPolygonToolStripMenuItem";
            this.nPolygonToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.nPolygonToolStripMenuItem.Text = "N-Polygon";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(55, 164);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(47, 32);
            this.button10.TabIndex = 27;
            this.button10.Text = "Poly";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem,
            this.вставкаToolStripMenuItem,
            this.форматToolStripMenuItem,
            this.помощьToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 24);
            this.menuStrip1.TabIndex = 29;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "Правка";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "Вид";
            // 
            // вставкаToolStripMenuItem
            // 
            this.вставкаToolStripMenuItem.Name = "вставкаToolStripMenuItem";
            this.вставкаToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.вставкаToolStripMenuItem.Text = "Вставка";
            // 
            // форматToolStripMenuItem
            // 
            this.форматToolStripMenuItem.Name = "форматToolStripMenuItem";
            this.форматToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.форматToolStripMenuItem.Text = "Формат";
            // 
            // помощьToolStripMenuItem
            // 
            this.помощьToolStripMenuItem.Name = "помощьToolStripMenuItem";
            this.помощьToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.помощьToolStripMenuItem.Text = "Помощь";
            // 
            // btnAddLine
            // 
            this.btnAddLine.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLine.Image")));
            this.btnAddLine.Location = new System.Drawing.Point(51, 126);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(32, 32);
            this.btnAddLine.TabIndex = 30;
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // btnAddRectangle
            // 
            this.btnAddRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRectangle.Image")));
            this.btnAddRectangle.Location = new System.Drawing.Point(15, 240);
            this.btnAddRectangle.Name = "btnAddRectangle";
            this.btnAddRectangle.Size = new System.Drawing.Size(32, 32);
            this.btnAddRectangle.TabIndex = 31;
            this.btnAddRectangle.UseVisualStyleBackColor = true;
            this.btnAddRectangle.Click += new System.EventHandler(this.btnAddRectangle_Click);
            // 
            // btnAddEllipse
            // 
            this.btnAddEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEllipse.Image")));
            this.btnAddEllipse.Location = new System.Drawing.Point(53, 240);
            this.btnAddEllipse.Name = "btnAddEllipse";
            this.btnAddEllipse.Size = new System.Drawing.Size(32, 32);
            this.btnAddEllipse.TabIndex = 32;
            this.btnAddEllipse.UseVisualStyleBackColor = true;
            this.btnAddEllipse.Click += new System.EventHandler(this.btnAddEllipse_Click);
            // 
            // btnAddTriangle2Side
            // 
            this.btnAddTriangle2Side.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTriangle2Side.Image")));
            this.btnAddTriangle2Side.Location = new System.Drawing.Point(15, 202);
            this.btnAddTriangle2Side.Name = "btnAddTriangle2Side";
            this.btnAddTriangle2Side.Size = new System.Drawing.Size(32, 32);
            this.btnAddTriangle2Side.TabIndex = 33;
            this.btnAddTriangle2Side.UseVisualStyleBackColor = true;
            this.btnAddTriangle2Side.Click += new System.EventHandler(this.btnAddTriangle2Side_Click);
            // 
            // bntAddTriangleRect
            // 
            this.bntAddTriangleRect.Image = ((System.Drawing.Image)(resources.GetObject("bntAddTriangleRect.Image")));
            this.bntAddTriangleRect.Location = new System.Drawing.Point(53, 202);
            this.bntAddTriangleRect.Name = "bntAddTriangleRect";
            this.bntAddTriangleRect.Size = new System.Drawing.Size(32, 32);
            this.bntAddTriangleRect.TabIndex = 34;
            this.bntAddTriangleRect.UseVisualStyleBackColor = true;
            this.bntAddTriangleRect.Click += new System.EventHandler(this.bntAddTriangleRect_Click);
            // 
            // btnAddRomb
            // 
            this.btnAddRomb.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRomb.Image")));
            this.btnAddRomb.Location = new System.Drawing.Point(15, 278);
            this.btnAddRomb.Name = "btnAddRomb";
            this.btnAddRomb.Size = new System.Drawing.Size(32, 32);
            this.btnAddRomb.TabIndex = 35;
            this.btnAddRomb.UseVisualStyleBackColor = true;
            this.btnAddRomb.Click += new System.EventHandler(this.btnAddRomb_Click);
            // 
            // btnAddTrapecia
            // 
            this.btnAddTrapecia.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTrapecia.Image")));
            this.btnAddTrapecia.Location = new System.Drawing.Point(53, 278);
            this.btnAddTrapecia.Name = "btnAddTrapecia";
            this.btnAddTrapecia.Size = new System.Drawing.Size(32, 32);
            this.btnAddTrapecia.TabIndex = 36;
            this.btnAddTrapecia.UseVisualStyleBackColor = true;
            this.btnAddTrapecia.Click += new System.EventHandler(this.btnAddTrapecia_Click);
            // 
            // btnAddParallel
            // 
            this.btnAddParallel.Image = ((System.Drawing.Image)(resources.GetObject("btnAddParallel.Image")));
            this.btnAddParallel.Location = new System.Drawing.Point(15, 316);
            this.btnAddParallel.Name = "btnAddParallel";
            this.btnAddParallel.Size = new System.Drawing.Size(32, 32);
            this.btnAddParallel.TabIndex = 37;
            this.btnAddParallel.UseVisualStyleBackColor = true;
            this.btnAddParallel.Click += new System.EventHandler(this.btnAddParallel_Click);
            // 
            // btnAddPoly5
            // 
            this.btnAddPoly5.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPoly5.Image")));
            this.btnAddPoly5.Location = new System.Drawing.Point(53, 316);
            this.btnAddPoly5.Name = "btnAddPoly5";
            this.btnAddPoly5.Size = new System.Drawing.Size(32, 32);
            this.btnAddPoly5.TabIndex = 38;
            this.btnAddPoly5.UseVisualStyleBackColor = true;
            // 
            // btnAddPoly6
            // 
            this.btnAddPoly6.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPoly6.Image")));
            this.btnAddPoly6.Location = new System.Drawing.Point(15, 354);
            this.btnAddPoly6.Name = "btnAddPoly6";
            this.btnAddPoly6.Size = new System.Drawing.Size(32, 32);
            this.btnAddPoly6.TabIndex = 39;
            this.btnAddPoly6.UseVisualStyleBackColor = true;
            // 
            // btnAddLomania
            // 
            this.btnAddLomania.Image = ((System.Drawing.Image)(resources.GetObject("btnAddLomania.Image")));
            this.btnAddLomania.Location = new System.Drawing.Point(15, 164);
            this.btnAddLomania.Name = "btnAddLomania";
            this.btnAddLomania.Size = new System.Drawing.Size(32, 32);
            this.btnAddLomania.TabIndex = 40;
            this.btnAddLomania.UseVisualStyleBackColor = true;
            this.btnAddLomania.Click += new System.EventHandler(this.btnAddLomania_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 586);
            this.Controls.Add(this.btnAddLomania);
            this.Controls.Add(this.btnAddPoly6);
            this.Controls.Add(this.btnAddPoly5);
            this.Controls.Add(this.btnAddParallel);
            this.Controls.Add(this.btnAddTrapecia);
            this.Controls.Add(this.btnAddRomb);
            this.Controls.Add(this.bntAddTriangleRect);
            this.Controls.Add(this.btnAddTriangle2Side);
            this.Controls.Add(this.btnAddEllipse);
            this.Controls.Add(this.btnAddRectangle);
            this.Controls.Add(this.btnAddLine);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btnAddPoint);
            this.Controls.Add(this.SetGroupBox);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOpenZones);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.btnOpenPicture);
            this.Controls.Add(this.pictureBoxMain);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Ultimate ROI Editor - редактор зон на изображении (v 1.1)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseHover += new System.EventHandler(this.Form1_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.SetGroupBox.ResumeLayout(false);
            this.SetGroupBox.PerformLayout();
            this.contextMenuStrip3.ResumeLayout(false);
            this.contextMenuStrip4.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.Button btnOpenPicture;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button btnOpenZones;
        private System.Windows.Forms.OpenFileDialog openPictureFileDialog;
        private System.Windows.Forms.OpenFileDialog openZonesFileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelScale;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addZoneToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem setIDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SetComboBox;
        private System.Windows.Forms.GroupBox SetGroupBox;
        private System.Windows.Forms.Button btnAddPoint;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem setIDToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fitToBoundingBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unfitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
        private System.Windows.Forms.ToolStripMenuItem addFigureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem triangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadrangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem4;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вставкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem форматToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem помощьToolStripMenuItem;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Button btnAddRectangle;
        private System.Windows.Forms.Button btnAddEllipse;
        private System.Windows.Forms.Button btnAddTriangle2Side;
        private System.Windows.Forms.Button bntAddTriangleRect;
        private System.Windows.Forms.Button btnAddRomb;
        private System.Windows.Forms.Button btnAddTrapecia;
        private System.Windows.Forms.Button btnAddParallel;
        private System.Windows.Forms.Button btnAddPoly5;
        private System.Windows.Forms.Button btnAddPoly6;
        private System.Windows.Forms.Button btnAddLomania;
    }
}

