using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp0203
{
    public partial class Form1_searchandhistory : Form
    {
        public Form1_searchandhistory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form2_map frm2 = new Form2_map();//实例化第二个窗体.
            frm2.Show();//然后显示出来.
        }

        private void Go_page1_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form2_map frm2 = new Form2_map();//实例化第二个窗体.
            frm2.Show();//然后显示出来.
        }

        private void Close_page1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
