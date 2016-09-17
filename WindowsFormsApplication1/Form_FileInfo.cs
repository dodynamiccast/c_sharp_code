using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VodUpload
{
    public partial class Form_FileInfo : Form
    {
        DbManager m_dbManager;
        int m_dwFileStatus;
        ulong m_qwAppId;
        private int LoadFile()
        {
            List<Dictionary<string, string>> arrFile = new List<Dictionary<string, string>>();
            m_dbManager.GetFileInfo(m_qwAppId, ref arrFile, m_dwFileStatus);
            flowLayoutPanel_contain.Controls.Clear();
            foreach (Dictionary<string, string> file in arrFile)
            {
                UserControl_FileInfo usFile = new UserControl_FileInfo();
                usFile.SetFileInfo(file);
                flowLayoutPanel_contain.Controls.Add(usFile);
            }
            return 0;
        }
        public Form_FileInfo()
        {
            InitializeComponent();
        }
        public int Init(DbManager dbManager, ulong appid)
        {
            m_dbManager = dbManager;
            m_qwAppId = appid;
            comboBox_status.SelectedIndex = 0;
            m_dwFileStatus = MultiPartUpload.FILE_FINISH;
            return 0;
        }
        /*
         * 已完成
         *上传中
         *等待中
         *出错
         */
        private void comboBox_status_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iIndex = comboBox_status.SelectedIndex;
            switch (iIndex)
            {
                case 0:
                    m_dwFileStatus = MultiPartUpload.FILE_FINISH;
                    break;
                case 1:
                    m_dwFileStatus = MultiPartUpload.FILE_RUNNING;
                    break;
                case 2:
                    m_dwFileStatus = MultiPartUpload.FILE_WAIT;
                    break;
                case 3:
                    m_dwFileStatus = MultiPartUpload.FILE_SVR_ERROR;
                    break;
            }
            LoadFile();
        }
    }
}
