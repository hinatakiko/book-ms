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
    public partial class register1 : Form
    {
        public register1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//清空文本框
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Text = "";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 检查id和name是否为空
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                // 检查学号是否已经存在
                string sql = $"select count(*) from t_user where id = '{textBox1.Text}'";
                Dao dao = new Dao();
                int count = Convert.ToInt32(dao.ReadOne(sql));
                dao.DaoClose();

                if (count > 0)
                {
                    MessageBox.Show("该账号已被注册，请重新输入");
                }
                else
                {
                    // 注册用户
                    string Sql = $"insert into t_user (id, name,psw, authority) values ('{textBox1.Text}', '{textBox2.Text}','{textBox3.Text}', 1)";
                    Dao dao1 = new Dao();
                    int n = dao1.Execute(Sql);
                    if (n > 0)
                    {
                        MessageBox.Show("注册成功");
                        dao.DaoClose();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("注册失败");
                    }
                }
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        private void register1_Load(object sender, EventArgs e)
        {

        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    // 检查id和name是否为空
        //    if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
        //    {

        //        // 注册用户
        //        string Sql = $"insert into t_user (id, name,psw, authority) values ('{textBox1.Text}', '{textBox2.Text}','{textBox2.Text}', 1)";
        //        Dao dao = new Dao();
        //        int n = dao.Execute(Sql);
        //        if (n > 0)
        //        {
        //            MessageBox.Show("注册成功");
        //            dao.DaoClose();
        //            this.Close();
        //        }
        //        else
        //        {
        //            MessageBox.Show("注册失败");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("输入有空项，请重新输入");
        //    }
        //}
    }
}
