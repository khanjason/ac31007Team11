namespace WindowsFormsApp0203
{
    partial class Form3_information
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3_information));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Back_page3 = new System.Windows.Forms.Button();
			this.Close_page3 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button1 = new System.Windows.Forms.Button();
			this.routeWindow = new GMap.NET.WindowsForms.GMapControl();
			this.txtHopsitalDetails = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(411, 145);
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.routeWindow);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(438, 1);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(1121, 818);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Information";
			// 
			// Back_page3
			// 
			this.Back_page3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.Back_page3.Location = new System.Drawing.Point(34, 843);
			this.Back_page3.Name = "Back_page3";
			this.Back_page3.Size = new System.Drawing.Size(147, 67);
			this.Back_page3.TabIndex = 12;
			this.Back_page3.Text = "Back";
			this.Back_page3.UseVisualStyleBackColor = true;
			this.Back_page3.Click += new System.EventHandler(this.Back_page3_Click);
			// 
			// Close_page3
			// 
			this.Close_page3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.Close_page3.Location = new System.Drawing.Point(243, 843);
			this.Close_page3.Name = "Close_page3";
			this.Close_page3.Size = new System.Drawing.Size(147, 67);
			this.Close_page3.TabIndex = 11;
			this.Close_page3.Text = "Close";
			this.Close_page3.UseVisualStyleBackColor = true;
			this.Close_page3.Click += new System.EventHandler(this.Close_page3_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.txtHopsitalDetails);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(12, 153);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(411, 666);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Details";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.button1.Location = new System.Drawing.Point(1010, 843);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(449, 67);
			this.button1.TabIndex = 14;
			this.button1.Text = "Copy to clipboard";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// routeWindow
			// 
			this.routeWindow.Bearing = 0F;
			this.routeWindow.CanDragMap = true;
			this.routeWindow.EmptyTileColor = System.Drawing.Color.Navy;
			this.routeWindow.GrayScaleMode = false;
			this.routeWindow.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.routeWindow.LevelsKeepInMemory = 5;
			this.routeWindow.Location = new System.Drawing.Point(6, 37);
			this.routeWindow.MarkersEnabled = true;
			this.routeWindow.MaxZoom = 18;
			this.routeWindow.MinZoom = 1;
			this.routeWindow.MouseWheelZoomEnabled = true;
			this.routeWindow.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.routeWindow.Name = "routeWindow";
			this.routeWindow.NegativeMode = false;
			this.routeWindow.PolygonsEnabled = true;
			this.routeWindow.RetryLoadTile = 0;
			this.routeWindow.RoutesEnabled = true;
			this.routeWindow.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.routeWindow.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.routeWindow.ShowTileGridLines = false;
			this.routeWindow.Size = new System.Drawing.Size(1109, 775);
			this.routeWindow.TabIndex = 1;
			this.routeWindow.Zoom = 5D;
			// 
			// txtHopsitalDetails
			// 
			this.txtHopsitalDetails.Location = new System.Drawing.Point(7, 38);
			this.txtHopsitalDetails.Multiline = true;
			this.txtHopsitalDetails.Name = "txtHopsitalDetails";
			this.txtHopsitalDetails.ReadOnly = true;
			this.txtHopsitalDetails.Size = new System.Drawing.Size(398, 622);
			this.txtHopsitalDetails.TabIndex = 0;
			// 
			// Form3_information
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1571, 960);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.Back_page3);
			this.Controls.Add(this.Close_page3);
			this.Name = "Form3_information";
			this.Text = "Information";
			this.Load += new System.EventHandler(this.Form3_information_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Back_page3;
        private System.Windows.Forms.Button Close_page3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
		public GMap.NET.WindowsForms.GMapControl routeWindow;
		private System.Windows.Forms.TextBox txtHopsitalDetails;
	}
}