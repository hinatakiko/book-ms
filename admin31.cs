using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace $safeprojectname$
{
    public partial class admin31 : Form
    {
        string ID = "";
        public admin31()
        {
            InitializeComponent();
        }
        public admin31(string id, string authority)
        {
            InitializeComponent();
            ID = id;
            textBox1.Text = authority;

        }

        private void admin31_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = $"update t_user set authority = '{textBox1.Text}' where id = '{ID}'";
            Dao dao = new Dao();
            if (dao.Execute(sql) > 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}
