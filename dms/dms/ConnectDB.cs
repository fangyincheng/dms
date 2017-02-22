using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace dms
{
    class ConnectDB
    {
        string str;
        SqlConnection con;
        static ConnectDB cdb = new ConnectDB();

        private ConnectDB()
        {
            str = @"Data Source=A;Initial Catalog=dms;Persist Security Info=True;User ID=dms;Password=dms";
            con = new SqlConnection(str);
        }
        
        /*
         *登陆
         */
        public bool Login(String u,String p)
        {
            con.Open();
            string cmd = "select id,aname,password,power from admin";
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String user = reader["aname"].ToString();
                String pwd = reader["password"].ToString();
                Form1.power = Int32.Parse(reader["power"].ToString().Trim());
                Form1.admin_name = "欢迎，"+user;
                Form1.admin_id = Int32.Parse(reader["id"].ToString().Trim());
                if (user.Trim() == u && pwd.Trim() == p)
                {
                    reader.Close();
                    con.Close();
                    return true; //登陆成功为true
                }
            }
            reader.Close();
            con.Close();
            return false;
        }

        /*
         * 根据管理员id判断密码是否正确
         */
        public bool ISTrue(string s,string p)
        {
            con.Open();
            string cmd = "select password from admin where id="+s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String id = reader["password"].ToString();
                if(id == p) 
                {
                    reader.Close();
                    con.Close();
                    return true;
                }
                
            }
            reader.Close();
            con.Close();
            return false;
        }

        /*
         * 查询
         */
        public DataSet GetData(string sqlStr)
        {
            con.Open();
            SqlDataAdapter myAdapter = new SqlDataAdapter(sqlStr, con);
            DataSet myDataSet = new DataSet();
            myDataSet.Clear();
            myAdapter.Fill(myDataSet);
            con.Close();
            if (myDataSet.Tables[0].Rows.Count != 0)
            {
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        /*
         * 插入、删除、更新
         */
        public int Change(string sqlStr)
        {
            con.Open();
            SqlCommand myCmd = new SqlCommand(sqlStr, con);
            myCmd.CommandType = CommandType.Text;
            int r = myCmd.ExecuteNonQuery();
            con.Close();
            return r;
        }

        /*
         * 根据宿舍楼号获取宿舍楼id
         */
        public string GetDorId(string s)
        {
            con.Open();
            string cmd = "select id from dormitory where ch='"+s[0]+"' and num="+s.Substring(1,s.Length-1);
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String id = reader["id"].ToString();
                reader.Close();
                con.Close();
                return id;
            }
            reader.Close();
            con.Close();
            return "0";
        }

        /*
         * 根据宿舍楼id获取该宿舍楼是男的还是女的住的
         */
        public string GetSex(string s)
        {
            con.Open();
            string cmd = "select s_gender from dormitory where id=" + s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String sex = reader["s_gender"].ToString();
                reader.Close();
                con.Close();
                return sex;
            }
            reader.Close();
            con.Close();
            return null;
        }

        /*
         * 根据学号获取性别
         */
        public string GetStuSex(string s)
        {
            con.Open();
            string cmd = "select gender from student where sno=" + s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String sex = reader["gender"].ToString();
                reader.Close();
                con.Close();
                return sex;
            }
            reader.Close();
            con.Close();
            return null;
        }

        /*
         * 根据学号获取房间id
         */
        public string GetStuRoomId(string s)
        {
            con.Open();
            string cmd = "select r_id from student where sno=" + s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String r_id = reader["r_id"].ToString();
                reader.Close();
                con.Close();
                return r_id;
            }
            reader.Close();
            con.Close();
            return null;
        }

        /*
         * 根据学号获取宿舍id
         */
        public string GetStuDorId(string s)
        {
            con.Open();
            string cmd = "select d_id from student where sno=" + s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String r_id = reader["d_id"].ToString();
                reader.Close();
                con.Close();
                return r_id;
            }
            reader.Close();
            con.Close();
            return null;
        }

        /*
         * 根据房间号获取id
         */
        public string GetRoomId(string s)
        {
            con.Open();
            string cmd = "select id from room where num=" + s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String id = reader["id"].ToString();
                reader.Close();
                con.Close();
                return id;
            }
            reader.Close();
            con.Close();
            return "0";
        }

        /*
         * 根据房间id获取所属宿舍楼id
         */
        public string GetRoomDorId(string s)
        {
            con.Open();
            string cmd = "select d_id from room where id=" + s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String id = reader["d_id"].ToString();
                reader.Close();
                con.Close();
                return id;
            }
            reader.Close();
            con.Close();
            return "0";
        }

        /*
         * 根据学生名字查询id
         */
        public string GetStuId(string s)
        {
            con.Open();
            string cmd = "select id from student where sname='"+s+"'";
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String id = reader["id"].ToString();
                reader.Close();
                con.Close();
                return id;
            }
            reader.Close();
            con.Close();
            return "0";
        }

        /*
         * 根据学生名字查询宿舍id
         */
        public string GetDorIdByStu(string s)
        {
            con.Open();
            string cmd = "select d_id from student where sname='" + s + "'";
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String id = reader["d_id"].ToString();
                reader.Close();
                con.Close();
                return id;
            }
            reader.Close();
            con.Close();
            return "0";
        }

        /*
         * 根据学生学号判断学生是否存在
         */
        public bool IsExit(string s)
        {
            con.Open();
            string cmd = "select * from student where sno='" + s + "'";
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                reader.Close();
                con.Close();
                return true;
            }
            reader.Close();
            con.Close();
            return false;
        }

        /*
         * 根据院系名字查询id
         */
        public string GetMaId(string s)
        {
            con.Open();
            string cmd = "select id from major where name='" + s + "'";
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String id = reader["id"].ToString();
                reader.Close();
                con.Close();
                return id;
            }
            reader.Close();
            con.Close();
            return "0";
        }

        /*
         * 根据房间id查询剩余床位
         */
        public int GetSum(string s)
        {
            con.Open();
            string cmd = "select margin from room where id=" + s;
            SqlCommand com = new SqlCommand(cmd, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                String margin = reader["margin"].ToString();
                reader.Close();
                con.Close();
                return Int32.Parse(margin);
            }
            reader.Close();
            con.Close();
            return -1;
        }

        /*
         *获取单例对象
         */
        public static ConnectDB getInstance() 
        {
            return cdb;
        }
    }
}
