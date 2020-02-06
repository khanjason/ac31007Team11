namespace WindowsFormsApp0203
{
    partial class Form1_searchandhistory
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1_searchandhistory));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserPosition = new System.Windows.Forms.TextBox();
            this.btnYourPosition = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcedure = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPlaceB = new System.Windows.Forms.CheckBox();
            this.chkPlaceA = new System.Windows.Forms.CheckBox();
            this.btnClosePage1 = new System.Windows.Forms.Button();
            this.btnContPage1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDistance = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.trbPrice = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSpecificProcedure = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(472, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // txtUserPosition
            // 
            this.txtUserPosition.Font = new System.Drawing.Font("SimSun", 20F);
            this.txtUserPosition.Location = new System.Drawing.Point(691, 206);
            this.txtUserPosition.Name = "txtUserPosition";
            this.txtUserPosition.Size = new System.Drawing.Size(385, 38);
            this.txtUserPosition.TabIndex = 1;
            // 
            // btnYourPosition
            // 
            this.btnYourPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnYourPosition.Location = new System.Drawing.Point(691, 277);
            this.btnYourPosition.Name = "btnYourPosition";
            this.btnYourPosition.Size = new System.Drawing.Size(385, 67);
            this.btnYourPosition.TabIndex = 2;
            this.btnYourPosition.Text = "Your position";
            this.btnYourPosition.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(472, 494);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 39);
            this.label2.TabIndex = 3;
            this.label2.Text = "Procedure";
            // 
            // txtProcedure
            // 
            this.txtProcedure.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedure.Location = new System.Drawing.Point(691, 496);
            this.txtProcedure.Name = "txtProcedure";
            this.txtProcedure.Size = new System.Drawing.Size(385, 38);
            this.txtProcedure.TabIndex = 4;
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnGo.Location = new System.Drawing.Point(691, 665);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(385, 67);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.Go_page1_Click);
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
            this.groupBox1.Controls.Add(this.chkPlaceB);
            this.groupBox1.Controls.Add(this.chkPlaceA);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 631);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 192);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            // 
            // chkPlaceB
            // 
            this.chkPlaceB.AutoSize = true;
            this.chkPlaceB.Location = new System.Drawing.Point(222, 74);
            this.chkPlaceB.Name = "chkPlaceB";
            this.chkPlaceB.Size = new System.Drawing.Size(126, 35);
            this.chkPlaceB.TabIndex = 1;
            this.chkPlaceB.Text = "Place B";
            this.chkPlaceB.UseVisualStyleBackColor = true;
            // 
            // chkPlaceA
            // 
            this.chkPlaceA.AutoSize = true;
            this.chkPlaceA.Location = new System.Drawing.Point(22, 74);
            this.chkPlaceA.Name = "chkPlaceA";
            this.chkPlaceA.Size = new System.Drawing.Size(126, 35);
            this.chkPlaceA.TabIndex = 0;
            this.chkPlaceA.Text = "Place A";
            this.chkPlaceA.UseVisualStyleBackColor = true;
            // 
            // btnClosePage1
            // 
            this.btnClosePage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnClosePage1.Location = new System.Drawing.Point(34, 843);
            this.btnClosePage1.Name = "btnClosePage1";
            this.btnClosePage1.Size = new System.Drawing.Size(147, 67);
            this.btnClosePage1.TabIndex = 12;
            this.btnClosePage1.Text = "Close";
            this.btnClosePage1.UseVisualStyleBackColor = true;
            this.btnClosePage1.Click += new System.EventHandler(this.Close_page1_Click);
            // 
            // btnContPage1
            // 
            this.btnContPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnContPage1.Location = new System.Drawing.Point(243, 843);
            this.btnContPage1.Name = "btnContPage1";
            this.btnContPage1.Size = new System.Drawing.Size(147, 67);
            this.btnContPage1.TabIndex = 11;
            this.btnContPage1.Text = "Continue";
            this.btnContPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(686, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 29);
            this.label4.TabIndex = 15;
            this.label4.Text = "Choose Procedure";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbDistance);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPrice);
            this.groupBox2.Controls.Add(this.trbPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 462);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // cmbDistance
            // 
            this.cmbDistance.FormattingEnabled = true;
            this.cmbDistance.Items.AddRange(new object[] {
            "Within 1 Mile",
            "Within 5 Miles",
            "Within 10 Miles",
            "Within 20 Miles",
            "Within 40 Miles",
            "Within 80 Miles",
            "Within 120 Miles",
            "Within 150 Miles",
            "Over 150 Miles"});
            this.cmbDistance.Location = new System.Drawing.Point(143, 159);
            this.cmbDistance.Name = "cmbDistance";
            this.cmbDistance.Size = new System.Drawing.Size(235, 39);
            this.cmbDistance.TabIndex = 23;
            this.cmbDistance.SelectedIndexChanged += new System.EventHandler(this.cmbDistance_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 31);
            this.label6.TabIndex = 22;
            this.label6.Text = "Distance";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(153, 115);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(29, 31);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "0";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trbPrice
            // 
            this.trbPrice.Location = new System.Drawing.Point(143, 73);
            this.trbPrice.Maximum = 40;
            this.trbPrice.Name = "trbPrice";
            this.trbPrice.Size = new System.Drawing.Size(235, 45);
            this.trbPrice.TabIndex = 20;
            this.trbPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbPrice.Scroll += new System.EventHandler(this.trbPrice_Scroll_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 31);
            this.label5.TabIndex = 19;
            this.label5.Text = "Price";
            // 
            // cmbSpecificProcedure
            // 
            this.cmbSpecificProcedure.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpecificProcedure.FormattingEnabled = true;
            this.cmbSpecificProcedure.Location = new System.Drawing.Point(691, 583);
            this.cmbSpecificProcedure.Name = "cmbSpecificProcedure";
            this.cmbSpecificProcedure.Size = new System.Drawing.Size(385, 37);
            this.cmbSpecificProcedure.TabIndex = 17;
            // 
            // Form1_searchandhistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 960);
            this.Controls.Add(this.cmbSpecificProcedure);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClosePage1);
            this.Controls.Add(this.btnContPage1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtProcedure);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnYourPosition);
            this.Controls.Add(this.txtUserPosition);
            this.Controls.Add(this.label1);
            this.Name = "Form1_searchandhistory";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYourPosition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPlaceA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkPlaceB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox txtUserPosition;
		public System.Windows.Forms.TextBox txtProcedure;
		public System.Windows.Forms.Button btnGo;
		public System.Windows.Forms.TrackBar trbPrice;
		public System.Windows.Forms.ComboBox cmbSpecificProcedure;
		public System.Windows.Forms.Button btnClosePage1;
		public System.Windows.Forms.Button btnContPage1;
		public System.Windows.Forms.ComboBox cmbDistance;
	}
}

