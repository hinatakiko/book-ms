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
    public partial class admin3 : Form
    {
        public admin3()
        {
            InitializeComponent();
        }

        private void admin3_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString() ;//获取姓名

        }
        public void Table()//从数据库读取数据显示在表格控件中
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from t_user";
            IDataReader dc = dao.read(sql);
            string a0, a1, a2, a3;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                string[] table = { a0, a1, a2, a3};
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取姓名
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string authority = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            admin31 admin = new admin31(id,authority);
            admin.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();//刷新数据
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 检查是否至少选中了一个行
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // 获取选中行的第一个单元格的值作为 ID
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                // 创建 Dao 实例并检查是否有数据
                Dao dao = new Dao();
                string sql = $"select no, uid, bid, bname, datetime from t_lend where uid = '{id}'";
                bool hasData = dao.HasData(sql);

                if (hasData)
                {
                    // 如果有数据，显示 admin32 窗口
                    admin32 admin = new admin32(id);
                    admin.ShowDialog();
                }
                else
                {
                    // 如果没有数据，提示用户
                    MessageBox.Show("无数据");
                }

                dao.DaoClose();
            }
            else
            {
                // 如果没有选中任何行，提示用户
                MessageBox.Show("请先选中一行。");
            }
        }
    }
}
