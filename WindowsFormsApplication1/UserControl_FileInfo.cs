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
    public partial class UserControl_FileInfo : UserControl
    {
        public static System.DateTime ConvertIntDateTime(long d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }

        public UserControl_FileInfo()
        {
            InitializeComponent();
        }
        public int SetFileInfo(Dictionary<string, string> fileInfo)
        {
            textBox_fileName.Text = fileInfo["fileName"];
            textBox_fileId.Text = fileInfo["fileId"];
            textBox_fileSha.Text = fileInfo["fileSha"];
            textBox_status.Text = fileInfo["status"];
            textBox_errCode.Text = fileInfo["errCode"];
            DateTime time_t = ConvertIntDateTime(long.Parse(fileInfo["createTime"]));
            textBox_createtime.Text = time_t.ToString();
            return 0;
        }
    }
}
