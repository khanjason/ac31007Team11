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
            this.Select_page3 = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Back_page3 = new System.Windows.Forms.Button();
            this.Close_page3 = new System.Windows.Forms.Button();
            this.Information = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(411, 134);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Select_page3);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 572);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
            // 
            // Select_page3
            // 
            this.Select_page3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Select_page3.Location = new System.Drawing.Point(231, 497);
            this.Select_page3.Name = "Select_page3";
            this.Select_page3.Size = new System.Drawing.Size(147, 62);
            this.Select_page3.TabIndex = 14;
            this.Select_page3.Text = "Select";
            this.Select_page3.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(22, 216);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(133, 36);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Place B";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(22, 364);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(134, 36);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Place C";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 68);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 36);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Place A";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Back_page3
            // 
            this.Back_page3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Back_page3.Location = new System.Drawing.Point(34, 778);
            this.Back_page3.Name = "Back_page3";
            this.Back_page3.Size = new System.Drawing.Size(147, 62);
            this.Back_page3.TabIndex = 12;
            this.Back_page3.Text = "Back";
            this.Back_page3.UseVisualStyleBackColor = true;
            this.Back_page3.Click += new System.EventHandler(this.Back_page3_Click);
            // 
            // Close_page3
            // 
            this.Close_page3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Close_page3.Location = new System.Drawing.Point(243, 778);
            this.Close_page3.Name = "Close_page3";
            this.Close_page3.Size = new System.Drawing.Size(147, 62);
            this.Close_page3.TabIndex = 11;
            this.Close_page3.Text = "Close";
            this.Close_page3.UseVisualStyleBackColor = true;
            this.Close_page3.Click += new System.EventHandler(this.Close_page3_Click);
            // 
            // Information
            // 
            this.Information.Location = new System.Drawing.Point(429, 1);
            this.Information.Name = "Information";
            this.Information.Size = new System.Drawing.Size(1130, 884);
            this.Information.TabIndex = 13;
            this.Information.Text = "";
            // 
            // Form3_information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 886);
            this.Controls.Add(this.Information);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Back_page3);
            this.Controls.Add(this.Close_page3);
            this.Name = "Form3_information";
            this.Text = "Information";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Back_page3;
        private System.Windows.Forms.Button Close_page3;
        private System.Windows.Forms.RichTextBox Information;
        private System.Windows.Forms.Button Select_page3;
    }
}