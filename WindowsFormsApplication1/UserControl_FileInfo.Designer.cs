namespace VodUpload
{
    partial class UserControl_FileInfo
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
            this.textBox_fileId = new System.Windows.Forms.TextBox();
            this.textBox_fileSha = new System.Windows.Forms.TextBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.textBox_errCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_fileId
            // 
            this.textBox_fileId.Location = new System.Drawing.Point(4, 4);
            this.textBox_fileId.Name = "textBox_fileId";
            this.textBox_fileId.Size = new System.Drawing.Size(125, 21);
            this.textBox_fileId.TabIndex = 0;
            // 
            // textBox_fileSha
            // 
            this.textBox_fileSha.Location = new System.Drawing.Point(134, 4);
            this.textBox_fileSha.Name = "textBox_fileSha";
            this.textBox_fileSha.Size = new System.Drawing.Size(149, 21);
            this.textBox_fileSha.TabIndex = 1;
            // 
            // textBox_status
            // 
            this.textBox_status.Location = new System.Drawing.Point(292, 4);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.Size = new System.Drawing.Size(71, 21);
            this.textBox_status.TabIndex = 2;
            // 
            // textBox_errCode
            // 
            this.textBox_errCode.Location = new System.Drawing.Point(387, 4);
            this.textBox_errCode.Name = "textBox_errCode";
            this.textBox_errCode.Size = new System.Drawing.Size(103, 21);
            this.textBox_errCode.TabIndex = 3;
            // 
            // UserControl_FileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_errCode);
            this.Controls.Add(this.textBox_status);
            this.Controls.Add(this.textBox_fileSha);
            this.Controls.Add(this.textBox_fileId);
            this.Name = "UserControl_FileInfo";
            this.Size = new System.Drawing.Size(517, 32);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_fileId;
        private System.Windows.Forms.TextBox textBox_fileSha;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.TextBox textBox_errCode;
    }
}
