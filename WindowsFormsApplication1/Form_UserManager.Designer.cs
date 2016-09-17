namespace VodUpload
{
    partial class Form_UserManager
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
            this.button_front = new System.Windows.Forms.Button();
            this.label_pagenum = new System.Windows.Forms.Label();
            this.button_next = new System.Windows.Forms.Button();
            this.flowLayoutPanel_contain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // button_front
            // 
            this.button_front.Location = new System.Drawing.Point(317, 380);
            this.button_front.Name = "button_front";
            this.button_front.Size = new System.Drawing.Size(75, 23);
            this.button_front.TabIndex = 1;
            this.button_front.Text = "上一页";
            this.button_front.UseVisualStyleBackColor = true;
            // 
            // label_pagenum
            // 
            this.label_pagenum.AutoSize = true;
            this.label_pagenum.Location = new System.Drawing.Point(415, 385);
            this.label_pagenum.Name = "label_pagenum";
            this.label_pagenum.Size = new System.Drawing.Size(41, 12);
            this.label_pagenum.TabIndex = 2;
            this.label_pagenum.Text = "label1";
            // 
            // button_next
            // 
            this.button_next.Location = new System.Drawing.Point(482, 380);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(75, 23);
            this.button_next.TabIndex = 3;
            this.button_next.Text = "下一页";
            this.button_next.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_contain
            // 
            this.flowLayoutPanel_contain.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel_contain.Name = "flowLayoutPanel_contain";
            this.flowLayoutPanel_contain.Size = new System.Drawing.Size(868, 362);
            this.flowLayoutPanel_contain.TabIndex = 4;
            // 
            // Form_UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 418);
            this.Controls.Add(this.flowLayoutPanel_contain);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.label_pagenum);
            this.Controls.Add(this.button_front);
            this.Name = "Form_UserManager";
            this.Text = "Form_UserManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_front;
        private System.Windows.Forms.Label label_pagenum;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_contain;
    }
}