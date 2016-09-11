namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.tbox_test = new System.Windows.Forms.TextBox();
            this.but_test = new System.Windows.Forms.Button();
            this.dataGridView_test = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_test)).BeginInit();
            this.SuspendLayout();
            // 
            // tbox_test
            // 
            this.tbox_test.Location = new System.Drawing.Point(30, 31);
            this.tbox_test.Name = "tbox_test";
            this.tbox_test.Size = new System.Drawing.Size(100, 21);
            this.tbox_test.TabIndex = 0;
            // 
            // but_test
            // 
            this.but_test.Location = new System.Drawing.Point(167, 28);
            this.but_test.Name = "but_test";
            this.but_test.Size = new System.Drawing.Size(75, 23);
            this.but_test.TabIndex = 1;
            this.but_test.Text = "测试";
            this.but_test.UseVisualStyleBackColor = true;
            this.but_test.Click += new System.EventHandler(this.but_test_Click);
            // 
            // dataGridView_test
            // 
            this.dataGridView_test.AllowUserToOrderColumns = true;
            this.dataGridView_test.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_test.Location = new System.Drawing.Point(30, 69);
            this.dataGridView_test.Name = "dataGridView_test";
            this.dataGridView_test.RowTemplate.Height = 23;
            this.dataGridView_test.Size = new System.Drawing.Size(240, 150);
            this.dataGridView_test.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 405);
            this.Controls.Add(this.dataGridView_test);
            this.Controls.Add(this.but_test);
            this.Controls.Add(this.tbox_test);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_test)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbox_test;
        private System.Windows.Forms.Button but_test;
        private System.Windows.Forms.DataGridView dataGridView_test;
    }
}

