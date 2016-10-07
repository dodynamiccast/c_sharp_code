using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VodUpload;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class UserControl_upload_ex : UserControl
    {
        public const int REFRESH_RET_FINISH = 1;
        public const int REFRESH_RET_RUNNING = 0;
        public const int REFRESH_RET_CANCLED = 2;
        public const int REFRESH_RET_SVRERROR = 3;
        private MultiPartUpload m_upload;
        Thread m_uploadThread;
        long m_qwId;
        private DbManager m_dbManager;
        private int m_iIsCancled = 0;
        public int SetTransCode(int iIsTrans)
        {
            m_upload.SetTranscode(iIsTrans);
            return 0;
        }
        public int SetScreenShot(int iIsScreenShot)
        {
            m_upload.SetScreenShort(iIsScreenShot);
            return 0;
        }
        public int SetWatermark(int iIsWaterMark)
        {
            m_upload.SetWatermark(iIsWaterMark);
            return 0;
        }
        public int SetNotifyUrl(string url)
        {
            m_upload.SetNotifyUrl(url);
            return 0;
        }
        public int Status
        {
            get { return m_upload.Status; }
        }
        public int SetDbManager(DbManager dbManager)
        {
            m_dbManager = dbManager;
            return 0;
        }
        public long ID
        {
            get { return m_qwId; }
            set { m_qwId = value; }
        } 
        public UserControl_upload_ex()
        {
            InitializeComponent();
            m_upload = new MultiPartUpload();
        }
        public int Init(string strSecId, string strSecKey)
        {
            m_upload.Init(strSecId, strSecKey);
            return 0;
        }
        public int SetFileInfo(string strFilePath, string strFileName, long createTime)
        {
            if (m_upload.SetFileInfo(strFilePath, strFileName) < 0)
                return -1;
            textBox_name.Text = strFileName;
            textBox_path.Text = strFilePath;
            textBox_rate.Text = "0";
            textBox_speed.Text = "0";
            label_status.Text = "等待中";
            label_createTime.Text = PubFunc.ConvertIntDateTime(createTime).ToString();
            return 0;
        }
       
        public void Upload()
        {
            ThreadStart threadStart = new ThreadStart(m_upload.Upload);
            m_uploadThread = new Thread(threadStart);
            m_uploadThread.Start();
        }
        public int Refresh_Upload()
        {
            if (m_iIsCancled == 1)
            {
                m_dbManager.UpdateFileInfo(m_qwId, m_upload.FileId, m_upload.FileSha,
                    MultiPartUpload.FILE_CANCLED, m_upload.ErrCode, m_upload.ErrDesc);
                return REFRESH_RET_CANCLED;
            }
            textBox_rate.Text = Math.Floor((m_upload.UploadRate)*100.0).ToString() + "%";
            textBox_speed.Text = Math.Floor((m_upload.UploadSpeed/1000.0)).ToString() + "KB/s";
            textBox_sha.Text = m_upload.FileSha;
            m_dbManager.UpdateFileInfo(m_qwId, m_upload.FileId, m_upload.FileSha, 
                            m_upload.Status, m_upload.ErrCode, m_upload.ErrDesc);
            if (m_upload.Status == MultiPartUpload.FILE_FINISH)
            {
                textBox_fileId.Text = m_upload.FileId;
                label_status.Text = "完成";
                return REFRESH_RET_FINISH;
            }
            if (m_upload.Status == MultiPartUpload.FILE_SVR_ERROR)
            {
                label_status.Text = "出错";
                return REFRESH_RET_SVRERROR;
            }
            if (m_upload.Status == MultiPartUpload.FILE_RUNNING)
            {
                label_status.Text = "运行中";
            }
            if (m_upload.Status == MultiPartUpload.FILE_WAIT)
            {
                label_status.Text = "等待中";
            }
            return REFRESH_RET_RUNNING;
        }
        public int StopThread()
        {
            m_uploadThread.Abort();
            return 0;
        }

        private void button_cancle_Click(object sender, EventArgs e)
        {
            m_uploadThread.Abort();
            m_iIsCancled = 1;
        }
    }
}
