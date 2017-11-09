using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CourseWork_VladFedchenko
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            label1.Text = Form1.name;
            label2.Text = Form1.number;
            label3.Text = Form1.email;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3.ActiveForm.Close();
        }
    }
}
