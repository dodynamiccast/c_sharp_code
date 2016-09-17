using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VodUpload;


namespace WindowsFormsApplication1
{
    public partial class Form_Main : Form
    {
        //        VodUpload.MultiPartUpload m_upload;
        List<UserControl_upload_ex> m_arrUploadCtrl;
        DbManager m_dbManager;
        string m_strAppId;
        string m_strSecId;
        string m_strSecKey;
        public const int MAX_RUNNING_TASK = 10;
        private int GetUser()
        {
            List<Dictionary<string, string>> arrUser = new List<Dictionary<string, string>>();
            m_dbManager.GetUser(ref arrUser, 1);
            if (arrUser.Count > 0 )
            {
                textBox_secId.Text = arrUser[0]["secId"];
                textBox_secKey.Text = arrUser[0]["secKey"];
                m_strAppId = arrUser[0]["appid"];
            }
            return 0;
        }
        private int GetFile()
        {
            List<Dictionary<string, string>> arrFile = new List<Dictionary<string, string>>();
            m_dbManager.GetFileInfo(ulong.Parse(m_strAppId), ref arrFile, MultiPartUpload.FILE_WAIT);
            m_dbManager.GetFileInfo(ulong.Parse(m_strAppId), ref arrFile, MultiPartUpload.FILE_RUNNING);
            foreach (Dictionary<string, string> file in arrFile)
            {
                UploadFile(file["filePath"], file["fileName"], long.Parse(file["id"]));
            }
            return 0;
        }
        public Form_Main()
        {
            InitializeComponent();
            m_arrUploadCtrl = new List<UserControl_upload_ex>();
            m_dbManager = new DbManager();
            m_dbManager.Init();
            GetUser();
            GetFile();
        }
        ~Form_Main()
        {

        }
        private int UploadFile(string strFilePath, string strFileName, long id=0)
        {
            UserControl_upload_ex upload = new UserControl_upload_ex();
            //upload.Init("AKIDywHSpWDragT7ESvCtqUrEg8Weuz8ibWj", "wLuplid8L7LsgENlaB2FtyKgUaYsBuqR");
            upload.Init(textBox_secId.Text, textBox_secKey.Text);
            //upload.SetFileInfo("J:\\download\\太子妃升职记.全集.EP01-36.2015.HD1080P.X264.AAC.Mandarin.CHS.Mp4Ba\\太子妃升职记.EP01.2015.HD1080P.X264.AAC.Mandarin.CHS.mp4", "little_prince");
            if (upload.SetFileInfo(strFilePath, strFileName) < 0)
            {
                return -1;
            }
            if (id == 0)
            {
                long qwFileId = 0;
                m_dbManager.AddFile(ulong.Parse(m_strAppId), strFilePath, strFileName, 0, 0, ref qwFileId);
                upload.ID = qwFileId;
            }
            else
            {
                upload.ID = id;
            }
            upload.SetDbManager(m_dbManager);
            m_arrUploadCtrl.Add(upload);
            flowLayoutPanel_contain.Controls.Add(upload);
            flowLayoutPanel_contain.Controls.SetChildIndex(upload, 0);
            int num = m_dbManager.GetFileCount(ulong.Parse(m_strAppId));
            if (num < MAX_RUNNING_TASK)
                upload.Upload();
            return 0;
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
            UploadFile(strFilePath, strFileName);
            //Thread.Sleep(5000);
            //m_upload.Test = "fuck";
            //m_upload.UploadSpeed = (float)0.23;
            //int ret = m_upload.UploadFile("J:\\download\\太子妃升职记.全集.EP01-36.2015.HD1080P.X264.AAC.Mandarin.CHS.Mp4Ba\\太子妃升职记.EP01.2015.HD1080P.X264.AAC.Mandarin.CHS.mp4", "little_prince", ref qwFileId);
        }
        private void TryWakeUp()
        {
            int num = m_dbManager.GetFileCount(ulong.Parse(m_strAppId));
            if (num < MAX_RUNNING_TASK)
            {
                foreach (UserControl_upload_ex upload_wake in m_arrUploadCtrl)
                {
                    if (upload_wake.Status == MultiPartUpload.FILE_WAIT)
                    {
                        upload_wake.Upload();
                    }
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           foreach (UserControl_upload_ex uploadex in m_arrUploadCtrl)
            {
                int ret = uploadex.Refresh_Upload();
                if (ret == 0)
                {
                    continue;
                }
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

        private void menuitem_addUser_Click(object sender, EventArgs e)
        {
            Form_AddUser fAddUser = new Form_AddUser();
            fAddUser.Init(m_dbManager);
            fAddUser.ShowDialog();
            GetUser();
        }

        private void menuitem_changeUser_Click(object sender, EventArgs e)
        {
            Form_UserManager fUserManager = new Form_UserManager();
            fUserManager.Init(m_dbManager);
            fUserManager.ShowDialog();
            GetUser();
        }

        private void toolStripMenuItem_openManager_Click(object sender, EventArgs e)
        {
            Form_FileInfo fFileInfo = new Form_FileInfo();
            fFileInfo.Init(m_dbManager, ulong.Parse(m_strAppId));
            fFileInfo.ShowDialog();
        }
    }
}
