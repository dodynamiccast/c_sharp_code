namespace VodUpload
{
    partial class UserControl_UserItem
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
            this.label1 = new System.Windows.Forms.Label();
            this.label_appid = new System.Windows.Forms.Label();
            this.label_noc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_secId = new System.Windows.Forms.TextBox();
            this.textBox_secKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.button_change = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "appid:";
            // 
            // label_appid
            // 
            this.label_appid.AutoSize = true;
            this.label_appid.Location = new System.Drawing.Point(51, 4);
            this.label_appid.Name = "label_appid";
            this.label_appid.Size = new System.Drawing.Size(41, 12);
            this.label_appid.TabIndex = 1;
            this.label_appid.Text = "label2";
            // 
            // label_noc
            // 
            this.label_noc.AutoSize = true;
            this.label_noc.Location = new System.Drawing.Point(133, 3);
            this.label_noc.Name = "label_noc";
            this.label_noc.Size = new System.Drawing.Size(41, 12);
            this.label_noc.TabIndex = 2;
            this.label_noc.Text = "secId:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(296, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "secKey:";
            // 
            // textBox_secId
            // 
            this.textBox_secId.Location = new System.Drawing.Point(171, 2);
            this.textBox_secId.Name = "textBox_secId";
            this.textBox_secId.Size = new System.Drawing.Size(119, 21);
            this.textBox_secId.TabIndex = 5;
            // 
            // textBox_secKey
            // 
            this.textBox_secKey.Location = new System.Drawing.Point(349, 2);
            this.textBox_secKey.Name = "textBox_secKey";
            this.textBox_secKey.Size = new System.Drawing.Size(119, 21);
            this.textBox_secKey.TabIndex = 6;
            this.textBox_secKey.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "状态：";
            // 
            // label_status
            // 
            this.label_status.AutoSize = true;
            this.label_status.Location = new System.Drawing.Point(521, 4);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(41, 12);
            this.label_status.TabIndex = 8;
            this.label_status.Text = "label2";
            // 
            // button_change
            // 
            this.button_change.Location = new System.Drawing.Point(594, 0);
            this.button_change.Name = "button_change";
            this.button_change.Size = new System.Drawing.Size(75, 23);
            this.button_change.TabIndex = 9;
            this.button_change.Text = "button1";
            this.button_change.UseVisualStyleBackColor = true;
            this.button_change.Click += new System.EventHandler(this.button_change_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(694, 0);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 10;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // UserControl_UserItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_change);
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_secKey);
            this.Controls.Add(this.textBox_secId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_noc);
            this.Controls.Add(this.label_appid);
            this.Controls.Add(this.label1);
            this.Name = "UserControl_UserItem";
            this.Size = new System.Drawing.Size(797, 25);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_appid;
        private System.Windows.Forms.Label label_noc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_secId;
        private System.Windows.Forms.TextBox textBox_secKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_change;
        private System.Windows.Forms.Button button_delete;
    }
}
