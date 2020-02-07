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
            this.txtUserZip = new System.Windows.Forms.TextBox();
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
            this.txtUserState = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rbtPrice = new System.Windows.Forms.RadioButton();
            this.rbtDistance = new System.Windows.Forms.RadioButton();
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
            this.label1.Location = new System.Drawing.Point(629, 254);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            // 
            // txtUserZip
            // 
            this.txtUserZip.Font = new System.Drawing.Font("SimSun", 20F);
            this.txtUserZip.Location = new System.Drawing.Point(921, 290);
            this.txtUserZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserZip.Name = "txtUserZip";
            this.txtUserZip.Size = new System.Drawing.Size(512, 46);
            this.txtUserZip.TabIndex = 1;
            this.txtUserZip.Text = "90210";
            // 
            // btnYourPosition
            // 
            this.btnYourPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnYourPosition.Location = new System.Drawing.Point(921, 428);
            this.btnYourPosition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnYourPosition.Name = "btnYourPosition";
            this.btnYourPosition.Size = new System.Drawing.Size(513, 82);
            this.btnYourPosition.TabIndex = 2;
            this.btnYourPosition.Text = "Your position";
            this.btnYourPosition.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(629, 608);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 52);
            this.label2.TabIndex = 3;
            this.label2.Text = "Procedure";
            // 
            // txtProcedure
            // 
            this.txtProcedure.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProcedure.Location = new System.Drawing.Point(921, 610);
            this.txtProcedure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProcedure.Name = "txtProcedure";
            this.txtProcedure.Size = new System.Drawing.Size(512, 46);
            this.txtProcedure.TabIndex = 4;
            this.txtProcedure.Text = "501";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnGo.Location = new System.Drawing.Point(921, 818);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(513, 82);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.Go_page1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(548, 178);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkPlaceB);
            this.groupBox1.Controls.Add(this.chkPlaceA);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 777);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(548, 236);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            // 
            // chkPlaceB
            // 
            this.chkPlaceB.AutoSize = true;
            this.chkPlaceB.Location = new System.Drawing.Point(296, 91);
            this.chkPlaceB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPlaceB.Name = "chkPlaceB";
            this.chkPlaceB.Size = new System.Drawing.Size(157, 43);
            this.chkPlaceB.TabIndex = 1;
            this.chkPlaceB.Text = "Place B";
            this.chkPlaceB.UseVisualStyleBackColor = true;
            // 
            // chkPlaceA
            // 
            this.chkPlaceA.AutoSize = true;
            this.chkPlaceA.Location = new System.Drawing.Point(29, 91);
            this.chkPlaceA.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkPlaceA.Name = "chkPlaceA";
            this.chkPlaceA.Size = new System.Drawing.Size(157, 43);
            this.chkPlaceA.TabIndex = 0;
            this.chkPlaceA.Text = "Place A";
            this.chkPlaceA.UseVisualStyleBackColor = true;
            // 
            // btnClosePage1
            // 
            this.btnClosePage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnClosePage1.Location = new System.Drawing.Point(45, 1038);
            this.btnClosePage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClosePage1.Name = "btnClosePage1";
            this.btnClosePage1.Size = new System.Drawing.Size(196, 82);
            this.btnClosePage1.TabIndex = 12;
            this.btnClosePage1.Text = "Close";
            this.btnClosePage1.UseVisualStyleBackColor = true;
            this.btnClosePage1.Click += new System.EventHandler(this.Close_page1_Click);
            // 
            // btnContPage1
            // 
            this.btnContPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.btnContPage1.Location = new System.Drawing.Point(324, 1038);
            this.btnContPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnContPage1.Name = "btnContPage1";
            this.btnContPage1.Size = new System.Drawing.Size(196, 82);
            this.btnContPage1.TabIndex = 11;
            this.btnContPage1.Text = "Continue";
            this.btnContPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(915, 677);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(264, 36);
            this.label4.TabIndex = 15;
            this.label4.Text = "Choose Procedure";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtDistance);
            this.groupBox2.Controls.Add(this.rbtPrice);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbDistance);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblPrice);
            this.groupBox2.Controls.Add(this.trbPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 201);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(548, 569);
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
            this.cmbDistance.Location = new System.Drawing.Point(191, 196);
            this.cmbDistance.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDistance.Name = "cmbDistance";
            this.cmbDistance.Size = new System.Drawing.Size(312, 47);
            this.cmbDistance.TabIndex = 23;
            this.cmbDistance.Text = "Over 150 Miles";
            this.cmbDistance.SelectedIndexChanged += new System.EventHandler(this.cmbDistance_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 39);
            this.label6.TabIndex = 22;
            this.label6.Text = "Distance";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(204, 142);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(112, 39);
            this.lblPrice.TabIndex = 21;
            this.lblPrice.Text = "10000";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trbPrice
            // 
            this.trbPrice.Location = new System.Drawing.Point(191, 90);
            this.trbPrice.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.trbPrice.Maximum = 40;
            this.trbPrice.Name = "trbPrice";
            this.trbPrice.Size = new System.Drawing.Size(313, 56);
            this.trbPrice.TabIndex = 20;
            this.trbPrice.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trbPrice.Value = 2;
            this.trbPrice.Scroll += new System.EventHandler(this.trbPrice_Scroll_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 39);
            this.label5.TabIndex = 19;
            this.label5.Text = "Price";
            // 
            // cmbSpecificProcedure
            // 
            this.cmbSpecificProcedure.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSpecificProcedure.FormattingEnabled = true;
            this.cmbSpecificProcedure.Location = new System.Drawing.Point(921, 718);
            this.cmbSpecificProcedure.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSpecificProcedure.Name = "cmbSpecificProcedure";
            this.cmbSpecificProcedure.Size = new System.Drawing.Size(512, 44);
            this.cmbSpecificProcedure.TabIndex = 17;
            // 
            // txtUserState
            // 
            this.txtUserState.Font = new System.Drawing.Font("SimSun", 20F);
            this.txtUserState.Location = new System.Drawing.Point(921, 374);
            this.txtUserState.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserState.Name = "txtUserState";
            this.txtUserState.Size = new System.Drawing.Size(512, 46);
            this.txtUserState.TabIndex = 18;
            this.txtUserState.Text = "CA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(915, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 31);
            this.label3.TabIndex = 19;
            this.label3.Text = "Zip Code";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(915, 342);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 31);
            this.label7.TabIndex = 20;
            this.label7.Text = "State";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 296);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 39);
            this.label8.TabIndex = 24;
            this.label8.Text = "Sort By";
            // 
            // rbtPrice
            // 
            this.rbtPrice.AutoSize = true;
            this.rbtPrice.Checked = true;
            this.rbtPrice.Location = new System.Drawing.Point(70, 338);
            this.rbtPrice.Name = "rbtPrice";
            this.rbtPrice.Size = new System.Drawing.Size(116, 43);
            this.rbtPrice.TabIndex = 26;
            this.rbtPrice.TabStop = true;
            this.rbtPrice.Text = "Price";
            this.rbtPrice.UseVisualStyleBackColor = true;
            // 
            // rbtDistance
            // 
            this.rbtDistance.AutoSize = true;
            this.rbtDistance.Location = new System.Drawing.Point(70, 387);
            this.rbtDistance.Name = "rbtDistance";
            this.rbtDistance.Size = new System.Drawing.Size(171, 43);
            this.rbtDistance.TabIndex = 27;
            this.rbtDistance.TabStop = true;
            this.rbtDistance.Text = "Distance";
            this.rbtDistance.UseVisualStyleBackColor = true;
            // 
            // Form1_searchandhistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUserState);
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
            this.Controls.Add(this.txtUserZip);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1_searchandhistory";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Form1_searchandhistory_Load);
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
		public System.Windows.Forms.TextBox txtUserZip;
		public System.Windows.Forms.TextBox txtProcedure;
		public System.Windows.Forms.Button btnGo;
		public System.Windows.Forms.TrackBar trbPrice;
		public System.Windows.Forms.ComboBox cmbSpecificProcedure;
		public System.Windows.Forms.Button btnClosePage1;
		public System.Windows.Forms.Button btnContPage1;
		public System.Windows.Forms.ComboBox cmbDistance;
		public System.Windows.Forms.TextBox txtUserState;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbtPrice;
        private System.Windows.Forms.RadioButton rbtDistance;
    }
}

