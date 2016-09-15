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
        private MultiPartUpload m_upload;
        Thread m_uploadThread;
        public UserControl_upload_ex()
        {
            m_upload = new MultiPartUpload();
            InitializeComponent();
        }
        public int Init(string strSecId, string strSecKey)
        {
            m_upload.Init(strSecId, strSecKey);
            return 0;
        }
        public int SetFileInfo(string strFilePath, string strFileName)
        {
            if (m_upload.SetFileInfo(strFilePath, strFileName) < 0)
                return -1;
            textBox_name.Text = strFileName;
            textBox_path.Text = strFilePath;
            textBox_rate.Text = "0";
            textBox_speed.Text = "0";
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
            textBox_rate.Text = m_upload.UploadRate.ToString();
            textBox_speed.Text = m_upload.UploadSpeed.ToString();
            textBox_sha.Text = m_upload.FileSha;
            if (m_upload.IsFinished == 1)
            {
                textBox_fileId.Text = m_upload.FileId;
            }
            return 0;
        }
        public int StopThread()
        {
            m_uploadThread.Abort();
            return 0;
        }
    }
}
