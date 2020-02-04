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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Yourposition = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Go_page1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Close_page1 = new System.Windows.Forms.Button();
            this.Continue_page1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(564, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "From";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 20F);
            this.textBox1.Location = new System.Drawing.Point(691, 190);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(385, 38);
            this.textBox1.TabIndex = 1;
            // 
            // Yourposition
            // 
            this.Yourposition.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Yourposition.Location = new System.Drawing.Point(691, 256);
            this.Yourposition.Name = "Yourposition";
            this.Yourposition.Size = new System.Drawing.Size(385, 62);
            this.Yourposition.TabIndex = 2;
            this.Yourposition.Text = "Your position";
            this.Yourposition.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(564, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "To";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 20F);
            this.textBox2.Location = new System.Drawing.Point(691, 458);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(385, 38);
            this.textBox2.TabIndex = 4;
            // 
            // Go_page1
            // 
            this.Go_page1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Go_page1.Location = new System.Drawing.Point(1131, 638);
            this.Go_page1.Name = "Go_page1";
            this.Go_page1.Size = new System.Drawing.Size(147, 62);
            this.Go_page1.TabIndex = 5;
            this.Go_page1.Text = "Go";
            this.Go_page1.UseVisualStyleBackColor = true;
            this.Go_page1.Click += new System.EventHandler(this.Go_page1_Click);
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
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 141);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 572);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
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
            // Close_page1
            // 
            this.Close_page1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Close_page1.Location = new System.Drawing.Point(34, 778);
            this.Close_page1.Name = "Close_page1";
            this.Close_page1.Size = new System.Drawing.Size(147, 62);
            this.Close_page1.TabIndex = 12;
            this.Close_page1.Text = "Close";
            this.Close_page1.UseVisualStyleBackColor = true;
            this.Close_page1.Click += new System.EventHandler(this.Close_page1_Click);
            // 
            // Continue_page1
            // 
            this.Continue_page1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Continue_page1.Location = new System.Drawing.Point(243, 778);
            this.Continue_page1.Name = "Continue_page1";
            this.Continue_page1.Size = new System.Drawing.Size(147, 62);
            this.Continue_page1.TabIndex = 11;
            this.Continue_page1.Text = "Continue";
            this.Continue_page1.UseVisualStyleBackColor = true;
            this.Continue_page1.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 20F);
            this.textBox3.Location = new System.Drawing.Point(691, 536);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(385, 38);
            this.textBox3.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1124, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 40);
            this.label3.TabIndex = 14;
            this.label3.Text = "(PostCode)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1124, 536);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(320, 40);
            this.label4.TabIndex = 15;
            this.label4.Text = "(Process number)";
            // 
            // Form1_searchandhistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 886);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Close_page1);
            this.Controls.Add(this.Continue_page1);
            this.Controls.Add(this.Go_page1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Yourposition);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1_searchandhistory";
            this.Text = "Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Yourposition;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Go_page1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Close_page1;
        private System.Windows.Forms.Button Continue_page1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

