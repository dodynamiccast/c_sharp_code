using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form_Main : Form
    {
        //        VodUpload.MultiPartUpload m_upload;
        List<UserControl_upload_ex> m_arrUploadCtrl;
        public Form_Main()
        {
            InitializeComponent();
            m_arrUploadCtrl = new List<UserControl_upload_ex>();
        }
        ~Form_Main()
        {

        }

        private void but_test_Click(object sender, EventArgs e)
        {
            string strFilePath = textBox_filePath.Text;
            //int index = dataGridView_test.Rows.Add();
            if (textBox_secId.Text == "" || textBox_secKey.Text == "")
            {
                MessageBox.Show("secId/secKey 未填写");
                return;
            }

            if (strFilePath == "")
            {
                MessageBox.Show("文件路径不正确");
                return;
            }
            string strFileName = "";
            try
            {
                strFileName = strFilePath.Substring(strFilePath.LastIndexOf("\\") + 1, (strFilePath.LastIndexOf(".") - strFilePath.LastIndexOf("\\") - 1));
            }
            catch
            {
                MessageBox.Show("文件路径非法");
                return;
            }
            UserControl_upload_ex upload = new UserControl_upload_ex();
            //upload.Init("AKIDywHSpWDragT7ESvCtqUrEg8Weuz8ibWj", "wLuplid8L7LsgENlaB2FtyKgUaYsBuqR");
            upload.Init(textBox_secId.Text, textBox_secKey.Text);
            //upload.SetFileInfo("J:\\download\\太子妃升职记.全集.EP01-36.2015.HD1080P.X264.AAC.Mandarin.CHS.Mp4Ba\\太子妃升职记.EP01.2015.HD1080P.X264.AAC.Mandarin.CHS.mp4", "little_prince");
            if (upload.SetFileInfo(strFilePath, strFileName) < 0)
            {
                return;
            }

            m_arrUploadCtrl.Add(upload);
            flowLayoutPanel_contain.Controls.Add(upload);
            upload.Upload();
                        //Thread.Sleep(5000);
            //m_upload.Test = "fuck";
            //m_upload.UploadSpeed = (float)0.23;
            //int ret = m_upload.UploadFile("J:\\download\\太子妃升职记.全集.EP01-36.2015.HD1080P.X264.AAC.Mandarin.CHS.Mp4Ba\\太子妃升职记.EP01.2015.HD1080P.X264.AAC.Mandarin.CHS.mp4", "little_prince", ref qwFileId);
        }

        private void textBox_test_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           foreach (UserControl_upload_ex uploadex in m_arrUploadCtrl)
            {
                uploadex.Refresh_Upload();
            }
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (UserControl_upload_ex uploadex in m_arrUploadCtrl)
            {
                uploadex.StopThread();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_filePath.Text = open.FileName;
            }
        }
    }
}
