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
    public partial class ReviewForm : Form
    {
        private string userId;
        private string bookId;

        public ReviewForm()
        {
            InitializeComponent();
        }
        public ReviewForm(string userId, string bookId)
        {
            InitializeComponent();
            this.userId = userId;
            this.bookId = bookId;
        }


        private void ReviewForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int rating))
            {
                MessageBox.Show("请输入有效的评分（1到5）");
                return;
            }
            // 检查评分是否在1到5之间
            if (rating < 1 || rating > 5)
            {
                MessageBox.Show("评分必须在1到5之间");
                return;
            }

            string reviewText = textBox2.Text;

            // 检查用户是否已经借阅过该书
            Dao dao = new Dao();
            string sqlCheckLend = $"SELECT COUNT(*) FROM t_lend WHERE uid = '{userId}' AND bid = '{bookId}'";
            object result = dao.ReadOne(sqlCheckLend);

            if (Convert.ToInt32(result) > 0)
            {
                // 用户已经借阅过该书，可以进行评价
                string sqlInsertReview = $"INSERT INTO t_reviews (user_id, book_id, rating, review_text, review_date) VALUES ('{userId}', '{bookId}', '{rating}', '{reviewText}', NOW())";
                dao.Execute(sqlInsertReview);
                dao.DaoClose();

                MessageBox.Show("评价提交成功！");
                this.Close();
            }
            else
            {
                // 用户没有借阅过该书，不能进行评价
                MessageBox.Show("您尚未借阅此书，请在阅读后进行评价。");
            }
        }
    }
}
