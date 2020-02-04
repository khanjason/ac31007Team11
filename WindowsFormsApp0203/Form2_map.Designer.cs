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
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Gpsmap = new System.Windows.Forms.WebBrowser();
            this.Continue_page2 = new System.Windows.Forms.Button();
            this.Back_page2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 572);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option";
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
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(411, 134);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Gpsmap
            // 
            this.Gpsmap.Location = new System.Drawing.Point(429, 1);
            this.Gpsmap.MinimumSize = new System.Drawing.Size(20, 20);
            this.Gpsmap.Name = "Gpsmap";
            this.Gpsmap.Size = new System.Drawing.Size(1130, 873);
            this.Gpsmap.TabIndex = 2;
            // 
            // Continue_page2
            // 
            this.Continue_page2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Continue_page2.Location = new System.Drawing.Point(243, 778);
            this.Continue_page2.Name = "Continue_page2";
            this.Continue_page2.Size = new System.Drawing.Size(147, 62);
            this.Continue_page2.TabIndex = 6;
            this.Continue_page2.Text = "Continue";
            this.Continue_page2.UseVisualStyleBackColor = true;
            this.Continue_page2.Click += new System.EventHandler(this.Continue_page2_Click);
            // 
            // Back_page2
            // 
            this.Back_page2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Back_page2.Location = new System.Drawing.Point(34, 778);
            this.Back_page2.Name = "Back_page2";
            this.Back_page2.Size = new System.Drawing.Size(147, 62);
            this.Back_page2.TabIndex = 7;
            this.Back_page2.Text = "Back";
            this.Back_page2.UseVisualStyleBackColor = true;
            this.Back_page2.Click += new System.EventHandler(this.Back_page2_Click);
            // 
            // Form2_map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 886);
            this.Controls.Add(this.Back_page2);
            this.Controls.Add(this.Continue_page2);
            this.Controls.Add(this.Gpsmap);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2_map";
            this.Text = "Map";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.WebBrowser Gpsmap;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Continue_page2;
        private System.Windows.Forms.Button Back_page2;
    }
}