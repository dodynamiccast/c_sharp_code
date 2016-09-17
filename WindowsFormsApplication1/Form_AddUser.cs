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
    public partial class Form_AddUser : Form
    {
        DbManager m_dbManager;
        Int64 m_qwUserId = 0;
        public Form_AddUser()
        {
            InitializeComponent();
        }
        public int Init(DbManager dbManager)
        {
            m_dbManager = dbManager;
            return 0;
        }
        private void button_comit_Click(object sender, EventArgs e)
        {
            if (textBox_appid.Text == "" ||
                textBox_secId.Text == "" ||
                textBox_secKey.Text == "")
            {
                MessageBox.Show("参数错误");
            }
            UInt64 qwAppId = 0;
            try
            {
                qwAppId = UInt64.Parse(textBox_appid.Text);
                m_dbManager.AddUsr(qwAppId, textBox_secId.Text, textBox_secKey.Text, ref m_qwUserId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加用户失败");
            }
            this.Close();
        }
    }
}
