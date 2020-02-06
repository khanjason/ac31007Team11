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
			this.lstHospitalDetails = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
			this.groupBox2.Controls.Add(this.lstHospitalDetails);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.Location = new System.Drawing.Point(12, 153);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(411, 666);
			this.groupBox2.TabIndex = 13;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Option";
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
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Back_page3;
        private System.Windows.Forms.Button Close_page3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstHospitalDetails;
        private System.Windows.Forms.Button button1;
    }
}