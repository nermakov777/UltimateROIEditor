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
    
    public partial class SetIDForm : Form
    {
        public int ID;
        public SetIDForm()
        {
            InitializeComponent();
        }

        private void SetIDForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = ID.ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ID = Convert.ToInt32(textBox1.Text);
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
