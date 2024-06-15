using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class user2 : Form
    {
        public user2()
        {
            InitializeComponent();
            Table();
        }

        private void user2_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号书名
        }
        public void Table()//从数据库读取数据显示在表格控件中
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from t_book";
            IDataReader dc = dao.read(sql);
            string a0, a1, a2, a3, a4;
            while (dc.Read())
            {
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                a3 = dc[3].ToString();
                a4 = dc[4].ToString();
                string[] table = { a0, a1, a2, a3, a4 };
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取选中行的第一个单元格的值作为 ID
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            // 创建 Dao 实例并检查是否有数据
            Dao dao = new Dao();
            string Sql = $"select authority from t_user where id = '{Data.UID}'"; // 修改为正确的列名
            object permissionObj = dao.ReadOne(Sql);

            int permission;
            if (!int.TryParse(permissionObj.ToString(), out permission) || permission == 0)
            {
                MessageBox.Show("您没有借阅权限，请联系管理员！");
                return;
            }

            // 获取选中图书信息
            string bookId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); // 获取书号
            string bname = dataGridView1.SelectedRows[0].Cells[1].Value.ToString(); // 获取书名
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString()); // 获取库存

            if (number < 1)
            {
                MessageBox.Show("库存不足，借阅失败！");
            }
            else
            {
                string sql = $"insert into t_lend (uid, bid, bname, datetime) values('{Data.UID}', '{bookId}', '{bname}', now()); update t_book set number = number - 1 where id = '{bookId}';";

                if (dao.Execute(sql) > 1) // 两条 SQL 语句
                {
                    MessageBox.Show($"用户：{Data.UName}借出了图书{bookId}!");
                    Table();
                }
            }

            dao.DaoClose();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号书名
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bookId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            ReviewDisplayForm reviewDisplayForm = new ReviewDisplayForm(bookId);
            if (!reviewDisplayForm.IsDisposed) // 检查窗体是否已经被关闭
            {
                reviewDisplayForm.ShowDialog();
            }
        }
    }
}
