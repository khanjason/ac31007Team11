﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using PriceAndDistanceRange;

namespace WindowsFormsApp0203
{
    public partial class Form2_map : Form
    {
        public Form2_map()
        {
            InitializeComponent();
        }
		
        private void Back_page2_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form1_searchandhistory frm = new Form1_searchandhistory();//实例化第二个窗体.
            frm.Show();//然后显示出来.
        }

        private void Continue_page2_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form3_information frm3 = new Form3_information();//实例化第二个窗体.
            frm3.Show();//然后显示出来.
        }
		
        private void Continue_page1_Click(object sender, EventArgs e)
        {
            Hide();//然后关闭.
            Form3_information frm3 = new Form3_information();//实例化第二个窗体.
            frm3.Show();//然后显示出来.
        }
		
		private void Form2_map_Load(object sender, EventArgs e)
		{

		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		
	}
}
