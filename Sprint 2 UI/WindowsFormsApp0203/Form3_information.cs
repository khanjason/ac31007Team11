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
    public partial class Form3_information : Form
    {
        public Form3_information()
        {
            InitializeComponent();
        }

        private void Close_page3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Back_page3_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form2_map frm2 = new Form2_map();//实例化第二个窗体.
            frm2.Show();//然后显示出来.
        }

		private void Form3_information_Load(object sender, EventArgs e)
		{

		}
	}
}
