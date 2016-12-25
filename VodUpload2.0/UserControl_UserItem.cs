using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VodUpload
{
    public partial class UserControl_UserItem : UserControl
    {
        string m_strId;
        public string ID
        {
            get { return m_strId; }
        }
        string m_strAppId;
        string m_strSecId;
        string m_strSecKey;
        string m_strStatus;
        Form_UserManager m_formUserForm;
        public int SetStatus(string strStatus)
        {
            m_strStatus = strStatus;
            if (strStatus == "0")
            {
                label_status.Text = "未使用";
                button_change.Text = "使用";
                button_change.Enabled = true;
                button_delete.Enabled = true;
            }
            else
            {
                label_status.Text = "使用中";
                button_change.Text = "使用";
                button_change.Enabled = false;
                button_delete.Enabled = false;
            }
            return 0;
        }
        public int Init(
                        Form_UserManager formUserForm,
                        string strId, 
                        string strAppId, 
                        string strSecId,
                        string strSecKey,
                        string strStatus)
        {
            m_strId = strId;
            m_strAppId = strAppId;
            m_strSecId = strSecId;
            m_strSecKey = strSecKey;
            m_strStatus = strStatus;
            m_formUserForm = formUserForm;
            label_appid.Text = m_strAppId;
            textBox_secId.Text = m_strSecId;
            textBox_secKey.Text = m_strSecKey;
            SetStatus(strStatus);
            return 0;
        }
        public UserControl_UserItem()
        {
            InitializeComponent();
        }

        private void button_change_Click(object sender, EventArgs e)
        {
            m_formUserForm.ChangeUser(m_strId);
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            m_formUserForm.DeleteUser(this);
        }
    }
}
