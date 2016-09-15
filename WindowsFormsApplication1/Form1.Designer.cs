namespace WindowsFormsApplication1
{
    partial class Form_Main
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
            this.components = new System.ComponentModel.Container();
            this.textBox_filePath = new System.Windows.Forms.TextBox();
            this.but_test = new System.Windows.Forms.Button();
            this.timer_listen = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel_contain = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_secKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_secId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Location = new System.Drawing.Point(9, 5);
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.Size = new System.Drawing.Size(208, 21);
            this.textBox_filePath.TabIndex = 0;
            // 
            // but_test
            // 
            this.but_test.Location = new System.Drawing.Point(251, 3);
            this.but_test.Name = "but_test";
            this.but_test.Size = new System.Drawing.Size(75, 23);
            this.but_test.TabIndex = 1;
            this.but_test.Text = "上传";
            this.but_test.UseVisualStyleBackColor = true;
            this.but_test.Click += new System.EventHandler(this.but_test_Click);
            // 
            // timer_listen
            // 
            this.timer_listen.Enabled = true;
            this.timer_listen.Interval = 500;
            this.timer_listen.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flowLayoutPanel_contain
            // 
            this.flowLayoutPanel_contain.AutoScroll = true;
            this.flowLayoutPanel_contain.Location = new System.Drawing.Point(0, 87);
            this.flowLayoutPanel_contain.Name = "flowLayoutPanel_contain";
            this.flowLayoutPanel_contain.Size = new System.Drawing.Size(843, 314);
            this.flowLayoutPanel_contain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox_filePath);
            this.panel1.Controls.Add(this.but_test);
            this.panel1.Location = new System.Drawing.Point(6, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 33);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "浏览";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_secKey);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox_secId);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(6, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(448, 26);
            this.panel2.TabIndex = 7;
            // 
            // textBox_secKey
            // 
            this.textBox_secKey.Location = new System.Drawing.Point(269, 1);
            this.textBox_secKey.Name = "textBox_secKey";
            this.textBox_secKey.Size = new System.Drawing.Size(166, 21);
            this.textBox_secKey.TabIndex = 3;
            this.textBox_secKey.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(211, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "secuKey";
            // 
            // textBox_secId
            // 
            this.textBox_secId.Location = new System.Drawing.Point(60, 2);
            this.textBox_secId.Name = "textBox_secId";
            this.textBox_secId.Size = new System.Drawing.Size(137, 21);
            this.textBox_secId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "securId";
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(477, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(366, 63);
            this.panel3.TabIndex = 8;
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 405);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel_contain);
            this.Name = "Form_Main";
            this.Text = "Upload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_filePath;
        private System.Windows.Forms.Button but_test;
        private System.Windows.Forms.Timer timer_listen;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_contain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_secId;
        private System.Windows.Forms.TextBox textBox_secKey;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button1;
    }
}

