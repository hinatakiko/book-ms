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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void radioButtonUser_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("输入有空项，请重新输入");
            }
        }

        // 清空文本框内容的方法
        public void ClearTextBoxes()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        //登录方法，验证是否允许登录，允许返回真
        public void Login()
        {
            //用户
            if (radioButtonUser.Checked == true)
            {
                Dao dao = new Dao();
                //string sql = "select * from t_user where id = '"+textBox1.Text+"' and psw = '"+textBox2.Text+"'";
                //string sql2 = String.Format("select * from t_user where id = '{0}'and psw = '{1}'", textBox1.Text, textBox2.Text);
                string sql = $"select * from t_user where id = '{textBox1.Text}' and psw = '{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    //存储id与姓名
                    Data.UID = dc["id"].ToString();
                    Data.UName = dc["name"].ToString();

                    
                    MessageBox.Show("登录成功");

                    user1 user = new user1(this);
                    this.Hide();//this->login隐藏
                    user.ShowDialog();//相比于Show,需要关闭后才能对原窗体操作，好处：可对原窗体数据刷新
                    this.Show();//再显示

                    // 清空文本框内容
                    ClearTextBoxes();

                }
                else
                {
                    MessageBox.Show("登录失败,请重新输入");
                    // 清空文本框内容
                    ClearTextBoxes();
                }
                dao.DaoClose();
            }
            //管理员
            if (radioButtonAdmin.Checked == true)
            {
                Dao dao = new Dao();
                string sql = $"select * from t_admin where id = '{textBox1.Text}' and psw = '{textBox2.Text}'";
                IDataReader dc = dao.read(sql);
                if (dc.Read())
                {
                    MessageBox.Show("登录成功");
                    admin1 a = new admin1(this);
                    this.Hide();
                    a.ShowDialog();
                    //this.Show();

                    // 清空文本框内容
                    ClearTextBoxes();

                }
                else
                {
                    MessageBox.Show("登录失败,请重新输入");
                    // 清空文本框内容
                    ClearTextBoxes();
                }
                dao.DaoClose();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 清空文本框内容
            ClearTextBoxes();
            this.Close();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            register1 register = new register1();
            this.Hide();
            register.ShowDialog();
            this.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
