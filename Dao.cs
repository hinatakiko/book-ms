using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace BookMS
{
    internal class Dao//对数据库进行连接与操作
    {
        MySqlConnection conn = new MySqlConnection();
        public MySqlConnection connect()
        {
            //string str = "server=localhost;user id=user;password=123456;database=BookDB";//数据库连接字符串
            string str = "server=10.195.36.95;user id=user;password=123456;database=BookDB";//数据库连接字符串
            conn = new MySqlConnection(str);//创建数据库连接对象
            conn.Open();//打开数据库
            return conn;//返回数据库对象
        }
        public MySqlCommand command(string sql)//数据库操作对象
        {
            MySqlCommand cmd = new MySqlCommand(sql, connect());
            return cmd;
        }
        public int Execute(string sql)//更新操作
        {
            return command(sql).ExecuteNonQuery();
        }
        public MySqlDataReader read(string sql)//读取操作
        {
            return command(sql).ExecuteReader();
        }
        public object ReadOne(string sql)
        {
            return command(sql).ExecuteScalar();
        }
        public bool HasData(string sql) // 检查是否有数据
        {
            using (MySqlDataReader reader = read(sql))
            {
                return reader.Read(); // 如果有数据返回 true，否则返回 false
            }
        }
        public void DaoClose()
        {
            conn.Close();//关闭数据库连接
        }
    }
}
