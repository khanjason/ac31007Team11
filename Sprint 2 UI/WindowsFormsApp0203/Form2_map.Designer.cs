namespace WindowsFormsApp0203
{
    partial class Form2_map
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2_map));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lstHospitalDetails = new System.Windows.Forms.ListBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnBack = new System.Windows.Forms.Button();
			this.btnContinue = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.mapWindow = new GMap.NET.WindowsForms.GMapControl();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lstHospitalDetails);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 153);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(411, 666);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Option";
			// 
			// lstHospitalDetails
			// 
			this.lstHospitalDetails.FormattingEnabled = true;
			this.lstHospitalDetails.ItemHeight = 31;
			this.lstHospitalDetails.Location = new System.Drawing.Point(6, 41);
			this.lstHospitalDetails.Name = "lstHospitalDetails";
			this.lstHospitalDetails.Size = new System.Drawing.Size(399, 593);
			this.lstHospitalDetails.TabIndex = 0;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(12, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(411, 145);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// btnBack
			// 
			this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.btnBack.Location = new System.Drawing.Point(34, 843);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new System.Drawing.Size(147, 67);
			this.btnBack.TabIndex = 7;
			this.btnBack.Text = "Back";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new System.EventHandler(this.Back_page2_Click);
			// 
			// btnContinue
			// 
			this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.btnContinue.Location = new System.Drawing.Point(243, 843);
			this.btnContinue.Name = "btnContinue";
			this.btnContinue.Size = new System.Drawing.Size(147, 67);
			this.btnContinue.TabIndex = 12;
			this.btnContinue.Text = "Continue";
			this.btnContinue.UseVisualStyleBackColor = true;
			this.btnContinue.Click += new System.EventHandler(this.Continue_page1_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.mapWindow);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(429, 1);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(1130, 909);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Map";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// mapWindow
			// 
			this.mapWindow.Bearing = 0F;
			this.mapWindow.CanDragMap = true;
			this.mapWindow.EmptyTileColor = System.Drawing.Color.Navy;
			this.mapWindow.GrayScaleMode = false;
			this.mapWindow.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
			this.mapWindow.LevelsKeepInMemory = 5;
			this.mapWindow.Location = new System.Drawing.Point(6, 37);
			this.mapWindow.MarkersEnabled = true;
			this.mapWindow.MaxZoom = 18;
			this.mapWindow.MinZoom = 1;
			this.mapWindow.MouseWheelZoomEnabled = true;
			this.mapWindow.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
			this.mapWindow.Name = "mapWindow";
			this.mapWindow.NegativeMode = false;
			this.mapWindow.PolygonsEnabled = true;
			this.mapWindow.RetryLoadTile = 0;
			this.mapWindow.RoutesEnabled = true;
			this.mapWindow.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
			this.mapWindow.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
			this.mapWindow.ShowTileGridLines = false;
			this.mapWindow.Size = new System.Drawing.Size(1118, 866);
			this.mapWindow.TabIndex = 0;
			this.mapWindow.Zoom = 5D;
			// 
			// Form2_map
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1571, 960);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnContinue);
			this.Controls.Add(this.btnBack);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.Name = "Form2_map";
			this.Text = "Map";
			this.Load += new System.EventHandler(this.Form2_map_Load);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.GroupBox groupBox2;
		public GMap.NET.WindowsForms.GMapControl mapWindow;
		public System.Windows.Forms.ListBox lstHospitalDetails;
	}
}