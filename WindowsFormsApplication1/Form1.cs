using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        DataTable m_dataTable;
        public Form1()
        {
            InitializeComponent();
            dataGridView_test.ColumnCount = 2;
            dataGridView_test.Columns[0].Name = "id";
            dataGridView_test.Columns[1].Name = "name";
        }

        private void but_test_Click(object sender, EventArgs e)
        {
            string strFilePath = tbox_test.Text;
            VodUpload.MultiPartUpload upload = new VodUpload.MultiPartUpload();
            upload.Init("AKIDywHSpWDragT7ESvCtqUrEg8Weuz8ibWj", "wLuplid8L7LsgENlaB2FtyKgUaYsBuqR");
            UInt64 qwFileId = 0;
            int ret = upload.UploadFile("E:\\IMG_2003.MOV", "little_prince", ref qwFileId);
        }
    }
}
