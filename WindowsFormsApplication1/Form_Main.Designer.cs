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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
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
            this.menu_User = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem_addUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem_changeUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitem_fileInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_openManager = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_User = new System.Windows.Forms.MenuStrip();
            this.checkBox_isTranscode = new System.Windows.Forms.CheckBox();
            this.checkBox_isScreenShort = new System.Windows.Forms.CheckBox();
            this.checkBox_isWm = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip_User.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_filePath
            // 
            this.textBox_filePath.Location = new System.Drawing.Point(240, 5);
            this.textBox_filePath.Name = "textBox_filePath";
            this.textBox_filePath.Size = new System.Drawing.Size(118, 21);
            this.textBox_filePath.TabIndex = 0;
            // 
            // but_test
            // 
            this.but_test.Location = new System.Drawing.Point(363, 3);
            this.but_test.Name = "but_test";
            this.but_test.Size = new System.Drawing.Size(55, 23);
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
            this.flowLayoutPanel_contain.Location = new System.Drawing.Point(0, 92);
            this.flowLayoutPanel_contain.Name = "flowLayoutPanel_contain";
            this.flowLayoutPanel_contain.Size = new System.Drawing.Size(843, 391);
            this.flowLayoutPanel_contain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_isWm);
            this.panel1.Controls.Add(this.checkBox_isScreenShort);
            this.panel1.Controls.Add(this.checkBox_isTranscode);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox_filePath);
            this.panel1.Controls.Add(this.but_test);
            this.panel1.Location = new System.Drawing.Point(6, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(535, 33);
            this.panel1.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 23);
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
            this.panel2.Location = new System.Drawing.Point(6, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 26);
            this.panel2.TabIndex = 7;
            // 
            // textBox_secKey
            // 
            this.textBox_secKey.Location = new System.Drawing.Point(272, 1);
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
            this.panel3.Location = new System.Drawing.Point(477, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(0, 0);
            this.panel3.TabIndex = 8;
            // 
            // menu_User
            // 
            this.menu_User.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitem_addUser,
            this.menuitem_changeUser});
            this.menu_User.Name = "menu_User";
            this.menu_User.Size = new System.Drawing.Size(68, 21);
            this.menu_User.Text = "账户管理";
            // 
            // menuitem_addUser
            // 
            this.menuitem_addUser.Name = "menuitem_addUser";
            this.menuitem_addUser.Size = new System.Drawing.Size(124, 22);
            this.menuitem_addUser.Text = "添加账户";
            this.menuitem_addUser.Click += new System.EventHandler(this.menuitem_addUser_Click);
            // 
            // menuitem_changeUser
            // 
            this.menuitem_changeUser.Name = "menuitem_changeUser";
            this.menuitem_changeUser.Size = new System.Drawing.Size(124, 22);
            this.menuitem_changeUser.Text = "切换账户";
            this.menuitem_changeUser.Click += new System.EventHandler(this.menuitem_changeUser_Click);
            // 
            // menuitem_fileInfo
            // 
            this.menuitem_fileInfo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_openManager});
            this.menuitem_fileInfo.Name = "menuitem_fileInfo";
            this.menuitem_fileInfo.Size = new System.Drawing.Size(92, 21);
            this.menuitem_fileInfo.Text = "文件信息管理";
            // 
            // toolStripMenuItem_openManager
            // 
            this.toolStripMenuItem_openManager.Name = "toolStripMenuItem_openManager";
            this.toolStripMenuItem_openManager.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItem_openManager.Text = "打开窗口";
            this.toolStripMenuItem_openManager.Click += new System.EventHandler(this.toolStripMenuItem_openManager_Click);
            // 
            // menuStrip_User
            // 
            this.menuStrip_User.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip_User.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_User,
            this.menuitem_fileInfo});
            this.menuStrip_User.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_User.Name = "menuStrip_User";
            this.menuStrip_User.Size = new System.Drawing.Size(168, 25);
            this.menuStrip_User.TabIndex = 9;
            this.menuStrip_User.Text = "账户管理";
            // 
            // checkBox_isTranscode
            // 
            this.checkBox_isTranscode.AutoSize = true;
            this.checkBox_isTranscode.Location = new System.Drawing.Point(4, 8);
            this.checkBox_isTranscode.Name = "checkBox_isTranscode";
            this.checkBox_isTranscode.Size = new System.Drawing.Size(72, 16);
            this.checkBox_isTranscode.TabIndex = 3;
            this.checkBox_isTranscode.Text = "是否转码";
            this.checkBox_isTranscode.UseVisualStyleBackColor = true;
            // 
            // checkBox_isScreenShort
            // 
            this.checkBox_isScreenShort.AutoSize = true;
            this.checkBox_isScreenShort.Location = new System.Drawing.Point(76, 8);
            this.checkBox_isScreenShort.Name = "checkBox_isScreenShort";
            this.checkBox_isScreenShort.Size = new System.Drawing.Size(72, 16);
            this.checkBox_isScreenShort.TabIndex = 4;
            this.checkBox_isScreenShort.Text = "是否截图";
            this.checkBox_isScreenShort.UseVisualStyleBackColor = true;
            this.checkBox_isScreenShort.CheckedChanged += new System.EventHandler(this.checkBox_isScreenShort_CheckedChanged);
            // 
            // checkBox_isWm
            // 
            this.checkBox_isWm.AutoSize = true;
            this.checkBox_isWm.Location = new System.Drawing.Point(144, 8);
            this.checkBox_isWm.Name = "checkBox_isWm";
            this.checkBox_isWm.Size = new System.Drawing.Size(96, 16);
            this.checkBox_isWm.TabIndex = 5;
            this.checkBox_isWm.Text = "是否添加水印";
            this.checkBox_isWm.UseVisualStyleBackColor = true;
            this.checkBox_isWm.CheckedChanged += new System.EventHandler(this.checkBox_isWm_CheckedChanged);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 495);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel_contain);
            this.Controls.Add(this.menuStrip_User);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_User;
            this.Name = "Form_Main";
            this.Text = "Upload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip_User.ResumeLayout(false);
            this.menuStrip_User.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ToolStripMenuItem menu_User;
        private System.Windows.Forms.ToolStripMenuItem menuitem_addUser;
        private System.Windows.Forms.ToolStripMenuItem menuitem_changeUser;
        private System.Windows.Forms.ToolStripMenuItem menuitem_fileInfo;
        private System.Windows.Forms.MenuStrip menuStrip_User;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_openManager;
        private System.Windows.Forms.CheckBox checkBox_isTranscode;
        private System.Windows.Forms.CheckBox checkBox_isScreenShort;
        private System.Windows.Forms.CheckBox checkBox_isWm;
    }
}

