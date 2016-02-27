namespace UltimateROIEditor
{
    partial class SaveToFileForm
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
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2a = new System.Windows.Forms.TextBox();
            this.label2a = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1a = new System.Windows.Forms.Label();
            this.comboBox1a = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Left Top Right Bottom",
            "X Y Width Height"});
            this.comboBox3.Location = new System.Drawing.Point(109, 69);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Rectangle format:";
            // 
            // textBox2a
            // 
            this.textBox2a.Location = new System.Drawing.Point(287, 42);
            this.textBox2a.Name = "textBox2a";
            this.textBox2a.Size = new System.Drawing.Size(100, 20);
            this.textBox2a.TabIndex = 24;
            // 
            // label2a
            // 
            this.label2a.AutoSize = true;
            this.label2a.Location = new System.Drawing.Point(246, 46);
            this.label2a.Name = "label2a";
            this.label2a.Size = new System.Drawing.Size(35, 13);
            this.label2a.TabIndex = 23;
            this.label2a.Text = "Norm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Coordinates type:";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Absolute",
            "RelativeFloat",
            "RelativeInt"});
            this.comboBox2.Location = new System.Drawing.Point(107, 42);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 21;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(179, 125);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(102, 29);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(285, 125);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(102, 29);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "File format:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "INI",
            "XML"});
            this.comboBox1.Location = new System.Drawing.Point(107, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 30;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1a
            // 
            this.label1a.AutoSize = true;
            this.label1a.Location = new System.Drawing.Point(246, 18);
            this.label1a.Name = "label1a";
            this.label1a.Size = new System.Drawing.Size(24, 13);
            this.label1a.TabIndex = 31;
            this.label1a.Text = "INI:";
            // 
            // comboBox1a
            // 
            this.comboBox1a.FormattingEnabled = true;
            this.comboBox1a.Items.AddRange(new object[] {
            "Default",
            "ZoneLS"});
            this.comboBox1a.Location = new System.Drawing.Point(287, 15);
            this.comboBox1a.Name = "comboBox1a";
            this.comboBox1a.Size = new System.Drawing.Size(100, 21);
            this.comboBox1a.TabIndex = 32;
            // 
            // SaveToFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 164);
            this.Controls.Add(this.comboBox1a);
            this.Controls.Add(this.label1a);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2a);
            this.Controls.Add(this.label2a);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Name = "SaveToFileForm";
            this.Text = "Saving params";
            this.Load += new System.EventHandler(this.SaveToFileForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2a;
        private System.Windows.Forms.Label label2a;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1a;
        private System.Windows.Forms.ComboBox comboBox1a;
    }
}