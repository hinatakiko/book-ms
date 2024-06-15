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
    public partial class ReviewDisplayForm : Form
    {
        private string bookId;
        public ReviewDisplayForm()
        {
            InitializeComponent();
        }
        public ReviewDisplayForm(string bookId)
        {
            InitializeComponent();
            this.bookId = bookId;
            // 在构造函数中进行评价检查
            if (!CheckAndLoadReviews())
            {
                MessageBox.Show("该书籍暂无评价。");
                this.Close();
            }
            else
            {
                InitializeComponent(); // 初始化组件在有评价时才进行
            }
        }
        private void InitializeListView()
        {
            // 设置 ListView 为详细视图
            listView1.View = View.Details;

            // 添加列标题
            listView1.Columns.Add("用户ID", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("评分", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("评价", 300, HorizontalAlignment.Left);
            listView1.Columns.Add("日期", 150, HorizontalAlignment.Left);
        }
        private bool CheckAndLoadReviews()
        {
            listView1.Items.Clear();
            Dao dao = new Dao();
            string sql = $"SELECT user_id, rating, review_text, review_date FROM t_reviews WHERE book_id = '{bookId}'";
            IDataReader dc = dao.read(sql);

            bool hasReviews = false;
            while (dc.Read())
            {
                if (!hasReviews)
                {
                    hasReviews = true;
                    InitializeListView(); // 延迟初始化 ListView 以避免空窗体显示
                }
                // 创建 ListViewItem 并添加到 ListView
                ListViewItem item = new ListViewItem(dc["user_id"].ToString());
                item.SubItems.Add(dc["rating"].ToString());
                item.SubItems.Add(dc["review_text"].ToString());
                item.SubItems.Add(dc["review_date"].ToString());
                listView1.Items.Add(item);
            }
            dc.Close();
            dao.DaoClose();

            return hasReviews;
        }
        private void ReviewDisplayForm_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
