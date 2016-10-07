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
        public const int MAX_RUNNING_TASK = 6;
        string m_strNotifyUrl = "";
        class TransPara{
            private int isTranscode;
            private int isScreenshort;
            private int isWatermark;
            private string notifyUrl;
            public long createTime = 0;

            public int IsTranscode
            {
                get
                {
                    return isTranscode;
                }

                set
                {
                    isTranscode = value;
                }
            }

            public int IsScreenshort
            {
                get
                {
                    return isScreenshort;
                }

                set
                {
                    isScreenshort = value;
                }
            }

            public int IsWatermark
            {
                get
                {
                    return isWatermark;
                }

                set
                {
                    isWatermark = value;
                }
            }

            public string NotifyUrl
            {
                get
                {
                    return notifyUrl;
                }

                set
                {
                    notifyUrl = value;
                }
            }
        };
        private int GetUser()
        {
            List<Dictionary<string, string>> arrUser = new List<Dictionary<string, string>>();
            m_dbManager.GetUser(ref arrUser, 1);
            if (arrUser.Count > 0 )
            {
                textBox_secId.Text = arrUser[0]["secId"];
                textBox_secKey.Text = arrUser[0]["secKey"];
                m_strAppId = arrUser[0]["appid"];
                if (arrUser[0]["isTranscode"] == "1")
                {
                    checkBox_isTranscode.Checked = true;
                }
                if (arrUser[0]["isScreenshort"] == "1")
                {
                    checkBox_isScreenShort.Checked = true;
                }
                if (arrUser[0]["isWatermark"] == "1")
                {
                    checkBox_isWm.Checked = true;
                }
                m_strNotifyUrl = arrUser[0]["notifyUrl"];
            }
            else
            {
                m_strAppId = "0";
            }
            return 0;
        }
        private int GetDicIntVal(Dictionary<string, string> dic, string strKey)
        {
            int val = 0;
            try
            {
                val = int.Parse(dic[strKey]);
            }
            catch
            {
                val = 0;
            }
            return val;
        }
        private int ReLoadFile()
        {
            List<Dictionary<string, string>> arrFile = new List<Dictionary<string, string>>();
            m_dbManager.GetFileInfo(ulong.Parse(m_strAppId), ref arrFile, MultiPartUpload.FILE_WAIT);
            m_dbManager.GetFileInfo(ulong.Parse(m_strAppId), ref arrFile, MultiPartUpload.FILE_RUNNING);
            foreach (Dictionary<string, string> file in arrFile)
            {
                TransPara para = new TransPara();
                para.IsTranscode = GetDicIntVal(file, "isTranscode");
                para.IsScreenshort = GetDicIntVal(file, "isScreenshort");
                para.IsWatermark = GetDicIntVal(file, "isWatermark");
                para.createTime = GetDicIntVal(file, "createTime");
                para.NotifyUrl = file["notifyUrl"];
                UploadFile(file["filePath"], file["fileName"], para, long.Parse(file["id"]));
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
            checkBox_isTranscode.Checked = true;
            checkBox_isScreenShort.Checked = true;

            ReLoadFile();
        }
        ~Form_Main()
        {

        }
        private int UploadFile(string strFilePath, string strFileName, TransPara para, long id =0)
        {
            UserControl_upload_ex upload = new UserControl_upload_ex();
            upload.SetScreenShot(para.IsScreenshort);
            upload.SetTransCode(para.IsTranscode);
            upload.SetWatermark(para.IsWatermark);
            upload.SetNotifyUrl(para.NotifyUrl);

            //upload.Init("AKIDywHSpWDragT7ESvCtqUrEg8Weuz8ibWj", "wLuplid8L7LsgENlaB2FtyKgUaYsBuqR");
            upload.Init(textBox_secId.Text, textBox_secKey.Text);
            //upload.SetFileInfo("J:\\download\\太子妃升职记.全集.EP01-36.2015.HD1080P.X264.AAC.Mandarin.CHS.Mp4Ba\\太子妃升职记.EP01.2015.HD1080P.X264.AAC.Mandarin.CHS.mp4", "little_prince");
            if (upload.SetFileInfo(strFilePath, strFileName, para.createTime) < 0)
            {
                return -1;
            }
            if (id == 0)
            {
                long qwFileId = 0;
                m_dbManager.AddFile(ulong.Parse(m_strAppId), 
                    strFilePath, 
                    strFileName, 
                    0, 
                    0,
                    para.IsTranscode,                   
                    para.IsScreenshort,
                    para.IsWatermark,
                    para.NotifyUrl,
                    ref qwFileId);
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
            int num = m_dbManager.GetFileCount(ulong.Parse(m_strAppId), MultiPartUpload.FILE_RUNNING);
            if (num < MAX_RUNNING_TASK)
            {
                upload.Upload();
            }
            return 0;
        }
        private void but_test_Click(object sender, EventArgs e)
        {
            DoUpload(textBox_filePath.Text);
        }
        private void DoUpload(string strFilePath)
        { 
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

            TransPara para = new TransPara();
            if (checkBox_isTranscode.Checked)
                para.IsTranscode = 1;
            if (checkBox_isScreenShort.Checked)
                para.IsScreenshort = 1;
            if (checkBox_isWm.Checked)
                para.IsWatermark = 1;
            para.NotifyUrl = m_strNotifyUrl;
            para.createTime = PubFunc.ConvertDateTimeInt(DateTime.Now);
            UploadFile(strFilePath, strFileName, para);
            //Thread.Sleep(5000);
            //m_upload.Test = "fuck";
            //m_upload.UploadSpeed = (float)0.23;
            //int ret = m_upload.UploadFile("J:\\download\\太子妃升职记.全集.EP01-36.2015.HD1080P.X264.AAC.Mandarin.CHS.Mp4Ba\\太子妃升职记.EP01.2015.HD1080P.X264.AAC.Mandarin.CHS.mp4", "little_prince", ref qwFileId);
        }
        private void TryWakeUp()
        {
            int num = m_dbManager.GetFileCount(ulong.Parse(m_strAppId), MultiPartUpload.FILE_RUNNING);
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
                if (ret == UserControl_upload_ex.REFRESH_RET_RUNNING)
                {
                    continue;
                }
                if (ret == UserControl_upload_ex.REFRESH_RET_CANCLED)
                {
                    flowLayoutPanel_contain.Controls.Remove(uploadex);
                    m_arrUploadCtrl.Remove(uploadex);
                    break;
                }
                TryWakeUp();
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
            if (textBox_secId.Text == "" || textBox_secKey.Text == "")
            {
                MessageBox.Show("secId/secKey 未填写");
                return;
            }
            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = true;
            if (open.ShowDialog() == DialogResult.OK)
            {
                textBox_filePath.Text = open.FileName;
            }
            for (int i = 0; i < open.FileNames.Length; i++)
            {
                DoUpload(open.FileNames[i]);
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

        private void checkBox_isWm_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_isWm.Checked)
            {
                checkBox_isTranscode.Checked = true;
            }
        }

        private void checkBox_isScreenShort_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_isScreenShort.Checked)
            {
                checkBox_isTranscode.Checked = true;
            }
        }
    }
}
