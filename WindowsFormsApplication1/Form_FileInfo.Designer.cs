namespace VodUpload
{
    partial class Form_FileInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_FileInfo));
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_page = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel_contain = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button_search = new System.Windows.Forms.Button();
            this.dateTimePicker_begin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // comboBox_status
            // 
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "已完成",
            "上传中",
            "等待中",
            "出错",
            "已取消",
            "全部"});
            this.comboBox_status.Location = new System.Drawing.Point(50, 3);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(60, 20);
            this.comboBox_status.TabIndex = 0;
            this.comboBox_status.SelectedIndexChanged += new System.EventHandler(this.comboBox_status_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "状态";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "分页";
            // 
            // comboBox_page
            // 
            this.comboBox_page.FormattingEnabled = true;
            this.comboBox_page.Location = new System.Drawing.Point(161, 3);
            this.comboBox_page.Name = "comboBox_page";
            this.comboBox_page.Size = new System.Drawing.Size(46, 20);
            this.comboBox_page.TabIndex = 2;
            this.comboBox_page.SelectedIndexChanged += new System.EventHandler(this.comboBox_page_SelectedIndexChanged);
            // 
            // flowLayoutPanel_contain
            // 
            this.flowLayoutPanel_contain.AutoScroll = true;
            this.flowLayoutPanel_contain.Location = new System.Drawing.Point(14, 29);
            this.flowLayoutPanel_contain.Name = "flowLayoutPanel_contain";
            this.flowLayoutPanel_contain.Size = new System.Drawing.Size(779, 368);
            this.flowLayoutPanel_contain.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "起始";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(402, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "终止";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(574, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "文件名";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(627, 3);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(81, 21);
            this.textBox_name.TabIndex = 10;
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(721, 3);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(58, 23);
            this.button_search.TabIndex = 11;
            this.button_search.Text = "查找";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // dateTimePicker_begin
            // 
            this.dateTimePicker_begin.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker_begin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_begin.Location = new System.Drawing.Point(259, 2);
            this.dateTimePicker_begin.Name = "dateTimePicker_begin";
            this.dateTimePicker_begin.ShowUpDown = true;
            this.dateTimePicker_begin.Size = new System.Drawing.Size(117, 21);
            this.dateTimePicker_begin.TabIndex = 12;
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dateTimePicker_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_end.Location = new System.Drawing.Point(437, 2);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.ShowUpDown = true;
            this.dateTimePicker_end.Size = new System.Drawing.Size(119, 21);
            this.dateTimePicker_end.TabIndex = 13;
            // 
            // Form_FileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 409);
            this.Controls.Add(this.dateTimePicker_end);
            this.Controls.Add(this.dateTimePicker_begin);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.flowLayoutPanel_contain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_page);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_FileInfo";
            this.Text = "Form_FileInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_page;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_contain;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.DateTimePicker dateTimePicker_begin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
    }
}