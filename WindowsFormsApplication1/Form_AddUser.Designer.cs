namespace VodUpload
{
    partial class Form_AddUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddUser));
            this.textBox_appid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_secId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_secKey = new System.Windows.Forms.TextBox();
            this.button_comit = new System.Windows.Forms.Button();
            this.checkBox_isTranscode = new System.Windows.Forms.CheckBox();
            this.checkBox_isScreenshort = new System.Windows.Forms.CheckBox();
            this.checkBox_isWartermark = new System.Windows.Forms.CheckBox();
            this.textBox_notifyUrl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_appid
            // 
            this.textBox_appid.Location = new System.Drawing.Point(57, 16);
            this.textBox_appid.Name = "textBox_appid";
            this.textBox_appid.Size = new System.Drawing.Size(100, 21);
            this.textBox_appid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "appid";
            // 
            // textBox_secId
            // 
            this.textBox_secId.Location = new System.Drawing.Point(57, 45);
            this.textBox_secId.Name = "textBox_secId";
            this.textBox_secId.Size = new System.Drawing.Size(100, 21);
            this.textBox_secId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "secId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "secKey";
            // 
            // textBox_secKey
            // 
            this.textBox_secKey.Location = new System.Drawing.Point(57, 78);
            this.textBox_secKey.Name = "textBox_secKey";
            this.textBox_secKey.Size = new System.Drawing.Size(100, 21);
            this.textBox_secKey.TabIndex = 4;
            this.textBox_secKey.UseSystemPasswordChar = true;
            // 
            // button_comit
            // 
            this.button_comit.Location = new System.Drawing.Point(92, 178);
            this.button_comit.Name = "button_comit";
            this.button_comit.Size = new System.Drawing.Size(75, 23);
            this.button_comit.TabIndex = 6;
            this.button_comit.Text = "提交";
            this.button_comit.UseVisualStyleBackColor = true;
            this.button_comit.Click += new System.EventHandler(this.button_comit_Click);
            // 
            // checkBox_isTranscode
            // 
            this.checkBox_isTranscode.AutoSize = true;
            this.checkBox_isTranscode.Location = new System.Drawing.Point(22, 112);
            this.checkBox_isTranscode.Name = "checkBox_isTranscode";
            this.checkBox_isTranscode.Size = new System.Drawing.Size(72, 16);
            this.checkBox_isTranscode.TabIndex = 7;
            this.checkBox_isTranscode.Text = "是否转码";
            this.checkBox_isTranscode.UseVisualStyleBackColor = true;
            // 
            // checkBox_isScreenshort
            // 
            this.checkBox_isScreenshort.AutoSize = true;
            this.checkBox_isScreenshort.Location = new System.Drawing.Point(100, 112);
            this.checkBox_isScreenshort.Name = "checkBox_isScreenshort";
            this.checkBox_isScreenshort.Size = new System.Drawing.Size(72, 16);
            this.checkBox_isScreenshort.TabIndex = 8;
            this.checkBox_isScreenshort.Text = "是否截图";
            this.checkBox_isScreenshort.UseVisualStyleBackColor = true;
            // 
            // checkBox_isWartermark
            // 
            this.checkBox_isWartermark.AutoSize = true;
            this.checkBox_isWartermark.Location = new System.Drawing.Point(178, 112);
            this.checkBox_isWartermark.Name = "checkBox_isWartermark";
            this.checkBox_isWartermark.Size = new System.Drawing.Size(72, 16);
            this.checkBox_isWartermark.TabIndex = 9;
            this.checkBox_isWartermark.Text = "是否截图";
            this.checkBox_isWartermark.UseVisualStyleBackColor = true;
            // 
            // textBox_notifyUrl
            // 
            this.textBox_notifyUrl.Location = new System.Drawing.Point(12, 141);
            this.textBox_notifyUrl.Name = "textBox_notifyUrl";
            this.textBox_notifyUrl.Size = new System.Drawing.Size(145, 21);
            this.textBox_notifyUrl.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "回调url";
            // 
            // Form_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 226);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_notifyUrl);
            this.Controls.Add(this.checkBox_isWartermark);
            this.Controls.Add(this.checkBox_isScreenshort);
            this.Controls.Add(this.checkBox_isTranscode);
            this.Controls.Add(this.button_comit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_secKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_secId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_appid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_AddUser";
            this.Text = "Form_AddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_secId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_secKey;
        private System.Windows.Forms.Button button_comit;
        internal System.Windows.Forms.TextBox textBox_appid;
        private System.Windows.Forms.CheckBox checkBox_isTranscode;
        private System.Windows.Forms.CheckBox checkBox_isScreenshort;
        private System.Windows.Forms.CheckBox checkBox_isWartermark;
        private System.Windows.Forms.TextBox textBox_notifyUrl;
        private System.Windows.Forms.Label label4;
    }
}