namespace WindowsFormsApplication1
{
    partial class UserControl_upload_ex
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.textBox_rate = new System.Windows.Forms.TextBox();
            this.textBox_speed = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_fileId = new System.Windows.Forms.TextBox();
            this.textBox_sha = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_name
            // 
            this.textBox_name.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_name.Location = new System.Drawing.Point(-1, 3);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 21);
            this.textBox_name.TabIndex = 0;
            // 
            // textBox_path
            // 
            this.textBox_path.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_path.Location = new System.Drawing.Point(105, 3);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(183, 21);
            this.textBox_path.TabIndex = 1;
            // 
            // textBox_rate
            // 
            this.textBox_rate.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_rate.Location = new System.Drawing.Point(294, 3);
            this.textBox_rate.Name = "textBox_rate";
            this.textBox_rate.Size = new System.Drawing.Size(49, 21);
            this.textBox_rate.TabIndex = 2;
            // 
            // textBox_speed
            // 
            this.textBox_speed.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_speed.Location = new System.Drawing.Point(352, 3);
            this.textBox_speed.Name = "textBox_speed";
            this.textBox_speed.Size = new System.Drawing.Size(41, 21);
            this.textBox_speed.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(767, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox_fileId
            // 
            this.textBox_fileId.Cursor = System.Windows.Forms.Cursors.No;
            this.textBox_fileId.Location = new System.Drawing.Point(399, 3);
            this.textBox_fileId.Name = "textBox_fileId";
            this.textBox_fileId.Size = new System.Drawing.Size(100, 21);
            this.textBox_fileId.TabIndex = 5;
            // 
            // textBox_sha
            // 
            this.textBox_sha.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_sha.Location = new System.Drawing.Point(505, 3);
            this.textBox_sha.Name = "textBox_sha";
            this.textBox_sha.Size = new System.Drawing.Size(256, 21);
            this.textBox_sha.TabIndex = 6;
            // 
            // UserControl_upload_ex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_sha);
            this.Controls.Add(this.textBox_fileId);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_speed);
            this.Controls.Add(this.textBox_rate);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.textBox_name);
            this.Name = "UserControl_upload_ex";
            this.Size = new System.Drawing.Size(839, 27);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.TextBox textBox_rate;
        private System.Windows.Forms.TextBox textBox_speed;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_fileId;
        private System.Windows.Forms.TextBox textBox_sha;
    }
}
