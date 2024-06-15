using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace $safeprojectname$
{
    public partial class admin32 : Form
    {
        string ID="";
        public admin32()
        {
            InitializeComponent();
        }
        public admin32(string id)
        {
            InitializeComponent();
            ID = id;
        }
        public void Table()//从数据库读取数据显示在表格控件中
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select no,uid,bid,bname,datetime from t_lend where uid = '{ID}'";
            IDataReader dc = dao.read(sql);

            bool hasData = false; // 标记是否有数据

            while (dc.Read())
            {
                hasData = true;
                dataGridView1.Rows.Add(dc[0].ToString(), dc[2].ToString(), dc[3].ToString(), dc[4].ToString());
            }
            dc.Close();
            dao.DaoClose();
            if (!hasData)
            {
                MessageBox.Show("无借阅记录");
            }
        }
        private void admin32_Load(object sender, EventArgs e)
        {
            Table();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
