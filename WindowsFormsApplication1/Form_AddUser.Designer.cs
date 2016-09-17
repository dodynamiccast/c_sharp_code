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
            this.textBox_appid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_secId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_secKey = new System.Windows.Forms.TextBox();
            this.button_comit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_appid
            // 
            this.textBox_appid.Location = new System.Drawing.Point(57, 38);
            this.textBox_appid.Name = "textBox_appid";
            this.textBox_appid.Size = new System.Drawing.Size(100, 21);
            this.textBox_appid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(181, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "appid";
            // 
            // textBox_secId
            // 
            this.textBox_secId.Location = new System.Drawing.Point(57, 77);
            this.textBox_secId.Name = "textBox_secId";
            this.textBox_secId.Size = new System.Drawing.Size(100, 21);
            this.textBox_secId.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "secId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "secKey";
            // 
            // textBox_secKey
            // 
            this.textBox_secKey.Location = new System.Drawing.Point(57, 115);
            this.textBox_secKey.Name = "textBox_secKey";
            this.textBox_secKey.Size = new System.Drawing.Size(100, 21);
            this.textBox_secKey.TabIndex = 4;
            this.textBox_secKey.UseSystemPasswordChar = true;
            // 
            // button_comit
            // 
            this.button_comit.Location = new System.Drawing.Point(95, 169);
            this.button_comit.Name = "button_comit";
            this.button_comit.Size = new System.Drawing.Size(75, 23);
            this.button_comit.TabIndex = 6;
            this.button_comit.Text = "提交";
            this.button_comit.UseVisualStyleBackColor = true;
            this.button_comit.Click += new System.EventHandler(this.button_comit_Click);
            // 
            // Form_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 226);
            this.Controls.Add(this.button_comit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_secKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_secId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_appid);
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
    }
}