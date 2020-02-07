using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp0203
{
	class PanelManger
	{
		private Form2_map frm2;
		private Panel myPanel;

		public PanelManger(Form2_map frm2, Panel myPanel)
		{
			this.frm2 = frm2;
			this.myPanel = myPanel;
			myPanel.AutoScroll = true;
		}

		public void generateEntries(List<string> details)
		{
			int x = 3;
			int y = 3;
			int btnSpacer = 580;
			int yStep = 90;
			int btnWidth = 60;
			int btnHeight = 80;

			int index = 0;
			foreach(string entry in details)
			{
				Label nextLbl = new Label();
				nextLbl.Name = "lblEntry" + index;
				nextLbl.Font = new Font(FontFamily.GenericSansSerif, 18);
				nextLbl.Text = entry;
				nextLbl.Location = new Point(x, y);
				nextLbl.AutoSize = true;
				myPanel.Controls.Add(nextLbl);

				Button nextBtn = new Button();
				nextBtn.Name = "btnEntry" + index;
				nextBtn.Font = new Font(FontFamily.GenericSansSerif, 18);
				nextBtn.Text = "=>";
				nextBtn.Location = new Point(x+btnSpacer, y);
				nextBtn.Width = btnWidth;
				nextBtn.Height = btnHeight;
				nextBtn.Tag = index;
				nextBtn.Click += new System.EventHandler(this.btnClick);
				myPanel.Controls.Add(nextBtn);

				y += yStep;
				index++;
			}
		}

		private void btnClick(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			frm2.highlightPointer((int)btn.Tag);
		}
	}
}
