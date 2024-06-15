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
    public partial class user1 : Form
    {
        private login loginForm;  // 引用登录窗体
        public user1(login loginForm)
        {
            InitializeComponent();
            label1.Text = $"欢迎{Data.UName}登录系统";
            this.loginForm = loginForm;  // 初始化
        }

        private void 图书查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user2 user = new user2();
            user.ShowDialog();
        }

        private void user1_Load(object sender, EventArgs e)
        {

        }

        private void 和ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            user3 user = new user3();
            user.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("联系邮箱：3280779681@qq.com");
        }

        // 处理窗体关闭事件
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            loginForm.ClearTextBoxes();  // 调用 login 窗体的清空方法
            loginForm.Show();             // 显示登录窗体
        }
    }
}
