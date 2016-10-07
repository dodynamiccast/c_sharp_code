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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_UserManager));
            this.flowLayoutPanel_contain = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_contain
            // 
            this.flowLayoutPanel_contain.AutoScroll = true;
            this.flowLayoutPanel_contain.AutoSize = true;
            this.flowLayoutPanel_contain.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel_contain.Name = "flowLayoutPanel_contain";
            this.flowLayoutPanel_contain.Size = new System.Drawing.Size(868, 394);
            this.flowLayoutPanel_contain.TabIndex = 4;
            // 
            // Form_UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 418);
            this.Controls.Add(this.flowLayoutPanel_contain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_UserManager";
            this.Text = "Form_UserManager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_contain;
    }
}