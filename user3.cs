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
    public partial class user3 : Form
    {
        public user3()
        {
            InitializeComponent();
            Table();
        }
        public void Table()//从数据库读取数据显示在表格控件中
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select no,bid,bname,datetime from t_lend where uid = '{Data.UID}'";
            IDataReader dc = dao.read(sql);
            while (dc.Read())
            {
                dataGridView1.Rows.Add(dc[0].ToString(),dc[1].ToString(), dc[2].ToString(), dc[3].ToString());
            }
            dc.Close();
            dao.DaoClose();
        }
        private void user3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = dataGridView1.Rows[0].Cells[0].Value.ToString();//记录编号
            string id = dataGridView1.Rows[0].Cells[1].Value.ToString();//记录书号
            string bname = dataGridView1.Rows[0].Cells[2].Value.ToString();//记录编号
            string sql = $"delete from t_lend where no = {no};update t_book set number = number+1 where id='{id}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 1)
            {
                MessageBox.Show("归还成功");
                Table();
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string bookId = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            ReviewForm reviewForm = new ReviewForm(Data.UID, bookId);
            reviewForm.ShowDialog();
        }
    }
}
