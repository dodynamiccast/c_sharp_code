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
            this.SuspendLayout();
            // 
            // comboBox_status
            // 
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Items.AddRange(new object[] {
            "已完成",
            "上传中",
            "等待中",
            "出错"});
            this.comboBox_status.Location = new System.Drawing.Point(59, 3);
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
            this.comboBox_page.Location = new System.Drawing.Point(172, 3);
            this.comboBox_page.Name = "comboBox_page";
            this.comboBox_page.Size = new System.Drawing.Size(46, 20);
            this.comboBox_page.TabIndex = 2;
            // 
            // flowLayoutPanel_contain
            // 
            this.flowLayoutPanel_contain.Location = new System.Drawing.Point(14, 29);
            this.flowLayoutPanel_contain.Name = "flowLayoutPanel_contain";
            this.flowLayoutPanel_contain.Size = new System.Drawing.Size(685, 316);
            this.flowLayoutPanel_contain.TabIndex = 4;
            // 
            // Form_FileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 347);
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
    }
}