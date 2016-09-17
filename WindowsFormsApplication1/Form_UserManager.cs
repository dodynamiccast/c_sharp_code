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
    public partial class Form_UserManager : Form
    {
        DbManager m_dbManager;
        List<Dictionary<string, string>> m_arrUser;
        List<UserControl_UserItem> m_arrItems;
        public int ChangeUser(string strId)
        {
            long id = long.Parse(strId);
            m_dbManager.ChangeUser(id);

            foreach (UserControl_UserItem item_arr in m_arrItems)
            {
                if (strId != item_arr.ID)
                {
                    item_arr.SetStatus("0");
                }
                else
                {
                    item_arr.SetStatus("1");
                }
            }
            return 0;
        }
        public int DeleteUser(UserControl_UserItem item)
        {
            m_dbManager.DeleteUser(long.Parse(item.ID));
            m_arrItems.Remove(item);
            flowLayoutPanel_contain.Controls.Remove(item);
            return 0;
        }

        public int Init(DbManager dbManager)
        {
            m_dbManager = dbManager;
            m_dbManager.GetUser(ref m_arrUser);
            foreach (Dictionary<string, string> user in m_arrUser)
            {
                UserControl_UserItem item = new UserControl_UserItem();
                item.Init(this,
                                  user["id"],
                                  user["appid"],
                                  user["secId"],
                                  user["secKey"],
                                  user["status"]);
                m_arrItems.Add(item);
                flowLayoutPanel_contain.Controls.Add(item);
            }
            return 0;
        }
        public Form_UserManager()
        {
            InitializeComponent();
            m_arrItems = new List<UserControl_UserItem>();
            m_arrUser = new List<Dictionary<string, string>>();
        }
    }
}
