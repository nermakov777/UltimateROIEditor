using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UltimateROIEditor
{
    public partial class SaveToFileForm : Form
    {
        public Form1 parent;  //ссылка на родителя

        //параметры сохранения
        FileFormat FileFormat;
        IniFormat IniFormat;
        CoordType CoordType;
        int Norm;
        RectangleFormat RectangleFormat;
        
        public SaveToFileForm()
        {
            InitializeComponent();
        }

        private void SaveToFileForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //скачиваем все параметры из котролов


            //сохраняем в файл
            
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool visible = comboBox1.SelectedItem.ToString().Contains("INI");
            label1a.Visible = comboBox1a.Visible = visible;
        }
    }
}
