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
        public const int PAGE_SIZE = 5;
        DbManager m_dbManager;
        int m_dwFileStatus;
        int m_dwPage = 1;
        long m_lastId;
        ulong m_qwAppId;
        List<DbLimitDef> m_arrLim = new List<DbLimitDef>();
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (long)(time - startTime).TotalSeconds;
        }
        private int LoadFile()
        {
            List<Dictionary<string, string>> arrFile = new List<Dictionary<string, string>>();
            m_dbManager.SearchFile(m_qwAppId, ref arrFile, ref m_arrLim, m_dwFileStatus, PAGE_SIZE, m_dwPage);
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
         * 上传中
         * 等待中
         * 出错
         * 已取消
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
                case 4:
                    m_dwFileStatus = MultiPartUpload.FILE_CANCLED;
                    break;
                case 5:
                    m_dwFileStatus = -1;
                    break;
            }
            m_arrLim.Clear();
            dateTimePicker_begin.ResetText();
            dateTimePicker_end.ResetText();
            int iFileNum = m_dbManager.GetFileCount(m_qwAppId, m_dwFileStatus);
            int page_num = iFileNum / PAGE_SIZE;
            if (page_num * PAGE_SIZE < iFileNum)
            {
                page_num++;
            }
            if (page_num == 0)
                page_num = 1;
            comboBox_page.Items.Clear();
            for (int i = 1; i < page_num + 1; i++)
            {
                comboBox_page.Items.Add(i);
            }
            comboBox_page.SelectedIndex = 0;
            //LoadFile();
        }

        private void comboBox_page_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_dwPage = comboBox_page.SelectedIndex + 1;
            LoadFile();
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            m_arrLim.Clear();
            long timeBegin = ConvertDateTimeInt(dateTimePicker_begin.Value);
            long timeEnd = ConvertDateTimeInt(dateTimePicker_end.Value);
            if (timeEnd > timeBegin)
            {
                m_arrLim.Add(new DbLimitDef("create_time", ">=", timeBegin));
                m_arrLim.Add(new DbLimitDef("create_time", "<=", timeEnd));
            }
            if (textBox_name.Text != "")
            {
                m_arrLim.Add(new DbLimitDef("fileName", " like ", "\'%"+textBox_name.Text+"%\'"));
            }
            if (comboBox_page.SelectedIndex == 0)
                LoadFile();
            comboBox_page.SelectedIndex = 0;
        }
    }
}
