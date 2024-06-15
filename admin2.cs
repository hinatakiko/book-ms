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
    public partial class admin2 : Form
    {
        public admin2()
        {
            InitializeComponent();
    
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void admin2_Load(object sender, EventArgs e)
        {
            Table();
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号书名

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
                string[] table = { a0, a1, a2, a3, a4};
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }
        //public void TableName()//根据书名显示数据，模糊查询
        //{
        //    dataGridView1.Rows.Clear();//清空旧数据
        //    Dao dao = new Dao();
        //    string sql = $"select * from t_book where name like '%{textBox1.Text}%'";
        //    IDataReader dc = dao.read(sql);
        //    string a0, a1, a2, a3, a4;
        //    while (dc.Read())
        //    {
        //        a0 = dc[0].ToString();
        //        a1 = dc[1].ToString();
        //        a2 = dc[2].ToString();
        //        a3 = dc[3].ToString();
        //        a4 = dc[4].ToString();
        //        string[] table = { a0, a1, a2, a3, a4 };
        //        dataGridView1.Rows.Add(table);
        //    }
        //    dc.Close();
        //    dao.DaoClose();
        //}
        //public void TableID()//根据书号显示数据
        //{
        //    dataGridView1.Rows.Clear();//清空旧数据
        //    Dao dao = new Dao();
        //    string sql = $"select * from t_book where id = '{textBox2.Text}'";
        //    IDataReader dc = dao.read(sql);
        //    string a0, a1, a2, a3, a4;
        //    while (dc.Read())
        //    {
        //        a0 = dc[0].ToString();
        //        a1 = dc[1].ToString();
        //        a2 = dc[2].ToString();
        //        a3 = dc[3].ToString();
        //        a4 = dc[4].ToString();
        //        string[] table = { a0, a1, a2, a3, a4 };
        //        dataGridView1.Rows.Add(table);
        //    }
        //    dc.Close();
        //    dao.DaoClose();
        //}
        //public void TableAuthor()//根据作者显示数据，模糊查询
        //{
        //    dataGridView1.Rows.Clear();//清空旧数据
        //    Dao dao = new Dao();
        //    string sql = $"select * from t_book where author like '%{textBox3.Text}%'";
        //    IDataReader dc = dao.read(sql);
        //    string a0, a1, a2, a3, a4;
        //    while (dc.Read())
        //    {
        //        a0 = dc[0].ToString();
        //        a1 = dc[1].ToString();
        //        a2 = dc[2].ToString();
        //        a3 = dc[3].ToString();
        //        a4 = dc[4].ToString();
        //        string[] table = { a0, a1, a2, a3, a4 };
        //        dataGridView1.Rows.Add(table);
        //    }
        //    dc.Close();
        //    dao.DaoClose();
        //}
        public void SearchData()
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = "select * from t_book where 1=1";

            if (!string.IsNullOrEmpty(textBox1.Text))//根据书名查询
            {
                sql += $" and name like '%{textBox1.Text}%'";
            }

            if (!string.IsNullOrEmpty(textBox2.Text))//根据书号查询
            {
                sql += $" and id = '{textBox2.Text}'";
            }

            if (!string.IsNullOrEmpty(textBox3.Text))//根据作者查询
            {
                sql += $" and author like '%{textBox3.Text}%'";
            }

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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选中行的第一格的信息字符串格式，即获取书号
                label2.Text = id + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//书号+书名
                DialogResult dr = MessageBox.Show("确认删除？", "信息提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    string sql = $"delete from t_book where id ='{id}'";
                    Dao dao = new Dao();
                    if(dao.Execute(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else
                    {
                        MessageBox.Show("删除失败"+sql); 
                    }
                    dao.DaoClose();
                }
            }
            catch//未选中状态，抛出
            {
                MessageBox.Show("请选中图书", "信息提示", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取书号书名
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin21 a = new admin21();
            a.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string category = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                admin22 admin = new admin22(id,name,author,category,number);
                admin.ShowDialog();
                Table();//刷新数据
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();//刷新数据
            textBox1.Text = "";//清空
            textBox2.Text = "";
            textBox3.Text = "";

        }
        private void button5_Click(object sender, EventArgs e)
        {
            //TableName();
            SearchData();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
