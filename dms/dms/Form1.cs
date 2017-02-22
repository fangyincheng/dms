using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dms
{
    public partial class Form1 : Form
    {
        private Point offset;//鼠标拖动的位移量
        public static int power = 0;//登陆的权限
        public static int admin_id = 0;//登陆的用户
        public static string admin_name = "";//登陆的用户
        private DataTable dat;//记录查询到的结果表

        public Form1()
        {
            InitializeComponent();
        }
        /*
         * 标题栏鼠标点下事件
         */
        private void main_top_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        /*
         * 标题栏鼠标移动事件
         */
        private void main_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        /*
         * 最小化按钮点击事件
         */
        private void small_Click(object sender, EventArgs e)
        {
            small.BackColor = System.Drawing.Color.Blue;
            this.WindowState = FormWindowState.Minimized;
        }
        /*
         * 最小化按钮鼠标移进事件
         */
        private void small_MouseEnter(object sender, EventArgs e)
        {
            small.BackColor = System.Drawing.Color.DeepSkyBlue;
        }
        /*
         * 最小化按钮鼠标移出事件
         */
        private void small_MouseLeave(object sender, EventArgs e)
        {
            small.BackColor = System.Drawing.Color.SkyBlue;
        }
        /*
         * 关闭按钮点击事件
         */
        private void close_Click(object sender, EventArgs e)
        {
            small.BackColor = System.Drawing.Color.Blue;
            this.Close();
            this.Dispose();
        }
        /*
         * 最小化按钮鼠标移进事件
         */
        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.BackColor = System.Drawing.Color.DeepSkyBlue;
        }
        /*
         * 最小化按钮鼠标移出事件
         */
        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.BackColor = System.Drawing.Color.SkyBlue;
        }
        /*
         * 注销按钮鼠标移进事件
         */
        private void down_MouseEnter(object sender, EventArgs e)
        {
            down.BackColor = System.Drawing.Color.DeepSkyBlue;
        }
        /*
         * 注销按钮鼠标移出事件
         */
        private void down_MouseLeave(object sender, EventArgs e)
        {
            down.BackColor = System.Drawing.Color.SkyBlue;
        }
        /*
         * 注销按钮点击事件
         */
        private void down_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Login l = new Login();
            l.ShowDialog();
            if (l.DialogResult == DialogResult.OK)
            {
                if (power == 2)
                    high.Visible = true;
                else
                    high.Visible = false;
                this.Visible = true;
            }
            n.Text = admin_name;
            d_m.BackColor = System.Drawing.Color.DeepSkyBlue;
            s_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_o.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_c.BackColor = System.Drawing.Color.PaleGoldenrod;
            about.BackColor = System.Drawing.Color.PaleGoldenrod;
            high.BackColor = System.Drawing.Color.PaleGoldenrod;

            D_m(true);
            S_m(false);
            I_o(false);
            I_c(false);
            About(false);
            High(false);
        }
        /*
         * 宿舍管理按钮点击事件
         */
        private void d_m_Click(object sender, EventArgs e)
        {
            dat = null;

            d_m.BackColor = System.Drawing.Color.DeepSkyBlue;
            s_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_o.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_c.BackColor = System.Drawing.Color.PaleGoldenrod;
            about.BackColor = System.Drawing.Color.PaleGoldenrod;
            high.BackColor = System.Drawing.Color.PaleGoldenrod;

            D_m(true);
            S_m(false);
            I_o(false);
            I_c(false);
            About(false);
            High(false);

            SetDormitory(lou,"select ch+cast(num as varchar(2)) d_id from dormitory");
            dataGridView0.DataSource = null;
            dataGridView0.Visible = true;
        }
        /*
         * 学生管理按钮点击事件
         */
        private void s_m_Click(object sender, EventArgs e)
        {
            dat = null;

            d_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            s_m.BackColor = System.Drawing.Color.DeepSkyBlue;
            i_o.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_c.BackColor = System.Drawing.Color.PaleGoldenrod;
            about.BackColor = System.Drawing.Color.PaleGoldenrod;
            high.BackColor = System.Drawing.Color.PaleGoldenrod;

            D_m(false);
            S_m(true);
            I_o(false);
            I_c(false);
            About(false);
            High(false);

            SetDormitory(do_c,"select ch+cast(num as varchar(2)) d_id from dormitory");
            dataGridView0.DataSource = null;
            dataGridView0.Visible = true;
        }
        /*
         * 出入登记按钮点击事件
         */
        private void i_o_Click(object sender, EventArgs e)
        {
            dat = null;

            d_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            s_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_o.BackColor = System.Drawing.Color.DeepSkyBlue;
            i_c.BackColor = System.Drawing.Color.PaleGoldenrod;
            about.BackColor = System.Drawing.Color.PaleGoldenrod;
            high.BackColor = System.Drawing.Color.PaleGoldenrod;

            D_m(false);
            S_m(false);
            I_o(true);
            I_c(false);
            About(false);
            High(false);
            
            if (power == 0)
            {
                SetDormitory(d, "select ch+cast(num as varchar(2)) d_id from dormitory where a_id="+admin_id);

                string sqlStr = "select student.sname name from in_out left join student on in_out.s_id=student.id where in_date is null";
                try
                {
                    DataTable dt =  ConnectDB.getInstance().GetData(sqlStr).Tables[0];
                    s_name_c.ValueMember = "name";
                    DataRow dr = dt.NewRow();
                    dr["name"] = " ";
                    dt.Rows.InsertAt(dr, 0);
                    s_name_c.DataSource = dt;
                }
                catch (Exception a)
                {
                    s_name_c.DataSource = null;
                }
            }
            else
            {
                SetDormitory(d, "select ch+cast(num as varchar(2)) d_id from dormitory");
            }
            dataGridView0.DataSource = null;
            dataGridView0.Visible = true;
        }
        /*
         * 来访登记按钮点击事件
         */
        private void i_c_Click(object sender, EventArgs e)
        {
            dat = null;

            d_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            s_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_o.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_c.BackColor = System.Drawing.Color.DeepSkyBlue;
            about.BackColor = System.Drawing.Color.PaleGoldenrod;
            high.BackColor = System.Drawing.Color.PaleGoldenrod;

            D_m(false);
            S_m(false);
            I_o(false);
            I_c(true);
            About(false);
            High(false);

            if (power == 0)
            {
                SetDormitory(v_d, "select ch+cast(num as varchar(2)) d_id from dormitory where a_id=" + admin_id);

                string sqlStr = "select name from visit where out_date is null";
                try
                {
                    DataTable dt = ConnectDB.getInstance().GetData(sqlStr).Tables[0];
                    v_name_c.ValueMember = "name";
                    DataRow dr = dt.NewRow();
                    dr["name"] = " ";
                    dt.Rows.InsertAt(dr, 0);
                    v_name_c.DataSource = dt;
                }
                catch (Exception a)
                {
                    v_name_c.DataSource = null;
                }
            }
            else
            {
                SetDormitory(v_d, "select ch+cast(num as varchar(2)) d_id from dormitory");
            }
            dataGridView0.DataSource = null;
            dataGridView0.Visible = true;
        }
        /*
         * 关于我们按钮点击事件
         */
        private void about_Click(object sender, EventArgs e)
        {
            dat = null;

            d_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            s_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_o.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_c.BackColor = System.Drawing.Color.PaleGoldenrod;
            about.BackColor = System.Drawing.Color.DeepSkyBlue;
            high.BackColor = System.Drawing.Color.PaleGoldenrod;

            D_m(false);
            S_m(false);
            I_o(false);
            I_c(false);
            About(true);
            High(false);
            dataGridView0.DataSource = null;
            dataGridView0.Visible = false;
        }
        /*
         * 高级管理按钮点击事件
         */
        private void high_Click(object sender, EventArgs e)
        {
            dat = null;

            d_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            s_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_o.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_c.BackColor = System.Drawing.Color.PaleGoldenrod;
            about.BackColor = System.Drawing.Color.PaleGoldenrod;
            high.BackColor = System.Drawing.Color.DeepSkyBlue;

            D_m(false);
            S_m(false);
            I_o(false);
            I_c(false);
            About(false);
            High(true);

            CheckAllAdmin();
        }
        /*
         * 宿舍管理页面的显示与隐藏
         */
        private void D_m(bool b)
        {
            sushe.Visible = b;
            lou.Visible = b;
            label7.Visible = b;
            fanghao.Visible = b;
            last.Visible = b;
            last_sum.Visible = b;
            select.Visible = b;
            hasempty.Visible = b;
            if (b == true && (power == 1 || power == 2))
            {
                clean.Visible = b;
            }
            else
            {
                clean.Visible = false;
            }
        }
        /*
         * 宿舍管理页面查询按钮点击事件
         */
        private void select_Click(object sender, EventArgs e)
        {
            string s1 = lou.Text.ToString().Trim();
            string s2 = fanghao.Text.ToString().Trim();
            string s3 = last_sum.Text.ToString().Trim();
            try
            {
                if (s2 != "")
                    Int32.Parse(s2);
                if (s3 != "")
                    Int32.Parse(s3);
            }
            catch (Exception a)
            {
                MessageBox.Show("请输入数字房间号或者剩余床位！", "提示");
                return;
            }
            DataSet ds;
            s1 = s1 != "全部" ? " dormitory.ch='" + s1[0] + "' and dormitory.num=" + s1.Substring(1, s1.Length - 1) : null;
            s2 = s2 != "" ? " room.num=" + s2 : null;
            s3 = s3 != "" ? " room.margin=" + s3 : null;
            if (s1 == null && s2 == null && s3 == null)
                ds = ConnectDB.getInstance().GetData("select room.id, dormitory.ch+cast(dormitory.num as varchar(2)) 楼号,dormitory.s_gender 性别,room.num 房号,room.margin 剩余床位,room.price 价格 from room left join dormitory on room.d_id = dormitory.id");
            else
            {
                if (s1 != null && s2 != null && s3 != null)
                {
                    s2 = " and" + s2;
                    s3 = " and" + s3;
                }
                else if (s1 != null && s2 != null && s3 == null)
                    s2 = " and" + s2;
                else if ((s1 != null || s2 != null) && s3 != null)
                    s3 = " and" + s3;
                ds = ConnectDB.getInstance().GetData("select room.id, dormitory.ch+cast(dormitory.num as varchar(2)) 楼号,dormitory.s_gender 性别,room.num 房号,room.margin 剩余床位,room.price 价格 from room left join dormitory on room.d_id = dormitory.id where" + s1 + s2 + s3);
            }
            dat = ds != null ? ds.Tables[0] : null;
            dataGridView0.DataSource = dat;
        }
        /*
         * 宿舍管理页面找空床位按钮点击事件
         */
        private void hasempty_Click(object sender, EventArgs e)
        {
            string s1 = lou.Text.ToString().Trim();
            string s2 = fanghao.Text.ToString().Trim();
            string s3 = last_sum.Text.ToString().Trim();
            try
            {
                if (s2 != "")
                    Int32.Parse(s2);
                if (s3 != "")
                    Int32.Parse(s3);
            }
            catch (Exception a)
            {
                MessageBox.Show("请输入数字房间号或者剩余床位！", "提示");
                return;
            }
            DataSet ds;
            s1 = s1 != "全部" ? " dormitory.ch='" + s1[0] + "' and dormitory.num=" + s1.Substring(1, s1.Length - 1) : null;
            s2 = s2 != "" ? " room.num=" + s2 : null;
            s3 = s3 != "" ? " room.margin=" + s3 : " room.margin>0";
            if (s1 != null && s2 != null)
            {
                s2 = " and" + s2; 
                s3 = " and" + s3;
            }
            else if (s1 != null || s2 != null)
                s3 = " and" + s3;
            ds = ConnectDB.getInstance().GetData("select room.id, dormitory.ch+cast(dormitory.num as varchar(2)) 楼号,dormitory.s_gender 性别,room.num 房号,room.margin 剩余床位,room.price 价格 from room left join dormitory on room.d_id = dormitory.id where" + s1 + s2 + s3);
            dat = ds!=null?ds.Tables[0]:null;
            dataGridView0.DataSource = dat;
        }
        /*
         * 宿舍管理页面清空按钮点击事件
         */
        private void clean_Click(object sender, EventArgs e)
        {
            if (dat == null)
            {
                MessageBox.Show("没有选中的内容！", "提示");
                return;
            }
            string sqlStr = "update room set margin=4 where id=";
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                ConnectDB.getInstance().Change(sqlStr+dat.Rows[i]["id"]);
            }
            sqlStr = "update student set d_id=0,r_id=0 where r_id=";
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                ConnectDB.getInstance().Change(sqlStr + dat.Rows[i]["id"]);
            }
            select_Click(sender, e);
        }
        /*
         * 学生管理页面的显示与隐藏
         */
        private void S_m(bool b)
        {
            num_label.Visible = b;
            num.Visible = b;
            name_label.Visible = b;
            name.Visible = b;
            gender_label.Visible = b;
            gender.Visible = b;
            class_label.Visible = b;
            class_t.Visible = b;
            tel_label.Visible = b;
            tel.Visible = b;
            age_label.Visible = b;
            age.Visible = b;
            school_label.Visible = b;
            school.Visible = b;
            major_label.Visible = b;
            major.Visible = b;
            do_label.Visible = b;
            do_c.Visible = b;
            label5.Visible = b;
            room.Visible = b;
            check.Visible = b;
            if (b == true && (power == 1 || power == 2))
            {
                insert.Visible = b;
                delete.Visible = b;
                update.Visible = b;
                label6.Visible = b;
            }
            else
            {
                insert.Visible = false;
                delete.Visible = false;
                update.Visible = false;
                label6.Visible = false;
            }
        }
        /*
         * 学生管理页面查询按钮的点击事件
         */
        private void check_Click(object sender, EventArgs e)
        {
            string s1 = num.Text.ToString().Trim();
            string s2 = name.Text.ToString().Trim();
            string s3 = gender.Text.ToString().Trim();
            string s4 = class_t.Text.ToString().Trim();
            string s5 = tel.Text.ToString().Trim();
            string s6 = age.Text.ToString().Trim();
            string s7 = school.Text.ToString().Trim();
            string s8 = major.Text.ToString().Trim();
            string s9 = do_c.Text.ToString().Trim();
            string s10 = room.Text.ToString().Trim();
            try
            {
                if (s4 != "")
                    Int32.Parse(s4);
                if (s6 != "")
                    Int32.Parse(s6);
                if (s10 != "")
                    Int32.Parse(s10);
            }
            catch (Exception a)
            {
                MessageBox.Show("请输入正确格式的数据！", "提示");
                return;
            }
            DataSet ds;
            s1 = s1 != "" ? " student.sno='"+s1+"'" : " student.sno!='null'";
            s2 = s2 != "" ? " and student.sname='" + s2 + "'" : " and student.sname!='null'";
            s3 = s3 != "" ? " and student.gender='" + s3 + "'" : " and student.gender!='null'";
            s4 = s4 != "" ? " and student.class=" + s4 : " and student.class!=0";
            s5 = s5 != "" ? " and student.tel='" + s5 +"'" : " and student.tel!='null'";
            s6 = s6 != "" ? " and student.age=" + s6 : " and student.age!=0";
            s7 = s7 != "" ? " and A.name='" + s7 + "'" : " and A.name!='null'";
            s8 = s8 != "" ? " and B.name='" + s8 + "'" : " and B.name!='null'";
            s9 = s9 != "全部" ? " and dormitory.ch='" + s9[0] + "' and dormitory.num=" + s9.Substring(1, s9.Length - 1) : "";
            s10 = s10 != "" ? " and room.num=" + s10 : "";
            ds = ConnectDB.getInstance().GetData("select student.id, student.sno 学号,student.sname 姓名,student.gender 性别,student.age 年龄,student.tel 联系方式,student.class 年级,A.name 学院,B.name 专业,dormitory.ch+cast(dormitory.num as varchar(2)) 楼号,student.r_id 房间id,room.num 房间" +
                                            " from (((student left join major A on student.u_id=A.id) left join major B on student.m_id=B.id) left join dormitory on student.d_id=dormitory.id) left join room on student.r_id=room.id" +
                                            " where"+s1+s2+s3+s4+s5+s6+s7+s8+s9+s10);
            dat = ds != null ? ds.Tables[0] : null;
            dataGridView0.DataSource = dat;
        }
        /*
         * 学生管理页面删除按钮的点击事件
         */
        private void delete_Click(object sender, EventArgs e)
        {
            if (dat == null)
            {
                MessageBox.Show("没有选中的内容！", "提示");
                return;
            }
            string sqlStr = "delete from student where id=";
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                ConnectDB.getInstance().Change(sqlStr + dat.Rows[i]["id"]);
            }
            sqlStr = "update room set margin=margin+1 where id=";
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                ConnectDB.getInstance().Change(sqlStr + dat.Rows[i]["房间id"]);
            }
            check_Click(sender, e);
        }
        /*
         * 学生管理页面插入按钮的点击事件
         */
        private void insert_Click(object sender, EventArgs e)
        {
            string s1 = num.Text.ToString().Trim();
            string s2 = name.Text.ToString().Trim();
            string s3 = gender.Text.ToString().Trim();
            string s4 = class_t.Text.ToString().Trim();
            string s5 = tel.Text.ToString().Trim();
            string s6 = age.Text.ToString().Trim();
            string s7 = school.Text.ToString().Trim();
            string s8 = major.Text.ToString().Trim();
            string s9 = do_c.Text.ToString().Trim();
            string s10 = room.Text.ToString().Trim();
            try
            {
                if (s4 != "")
                    Int32.Parse(s4);
                if (s6 != "")
                    Int32.Parse(s6);
                if (s10 != "")
                    Int32.Parse(s10);
            }
            catch (Exception a)
            {
                MessageBox.Show("请输入正确格式的数据！", "提示");
                return;
            }
            if (s1 == "" || s2 == "" || s3 == "" || s4 == "" || s5 == "" || s6 == "" || s7 == "" || s8 == "" || s10 == "")
            {
                MessageBox.Show("插入时不能为空！", "提示");
                return;
            }
            if (s9 == "全部")
            {
                MessageBox.Show("宿舍必须选中！", "提示");
                return;
            }
            s7 = ConnectDB.getInstance().GetMaId(s7);
            if (s7 == "0")
            {
                MessageBox.Show("不存在该学院！", "提示");
                return;
            }
            s8 = ConnectDB.getInstance().GetMaId(s8);
            if (s8 == "0")
            {
                MessageBox.Show("不存在该专业！", "提示");
                return;
            }
            s9 = ConnectDB.getInstance().GetDorId(s9);
            if (ConnectDB.getInstance().GetSex(s9) != s3)
            {
                MessageBox.Show("该宿舍不是"+s3+"生宿舍！", "提示");
                return;
            }
            s10 = ConnectDB.getInstance().GetRoomId(s10);
            if (s10 == "0")
            {
                MessageBox.Show("不存在该房间！", "提示");
                return;
            }
            int sum = ConnectDB.getInstance().GetSum(s10);
            if (sum == 0)
            {
                MessageBox.Show("该房间已满！", "提示");
                return;
            }
            else if (sum == -1)
            {
                MessageBox.Show("不存在该房间！", "提示");
                return;
            }
            string sqlStr = "insert into student (sno,sname,gender,age,tel,u_id,m_id,class,d_id,r_id) values('" +s1+"','"+s2+"','"+s3+"',"+s6+",'"+s5+"',"+s7+","+s8+","+s4+","+s9+","+s10+ ")";
            int c = ConnectDB.getInstance().Change(sqlStr);
            ConnectDB.getInstance().Change("update room set margin="+(sum-1)+" where id="+s10);
            if (c == 0)
            {
                MessageBox.Show("插入失败！", "提示");
                return;
            }
            check_Click(sender, e);
        }
        /*
         * 学生管理页面修改按钮的点击事件
         */
        private void update_Click(object sender, EventArgs e)
        {
            string s1 = num.Text.ToString().Trim();
            if (ConnectDB.getInstance().IsExit(s1))
            {
                string s2 = name.Text.ToString().Trim();
                string s3 = gender.Text.ToString().Trim();
                string s4 = class_t.Text.ToString().Trim();
                string s5 = tel.Text.ToString().Trim();
                string s6 = age.Text.ToString().Trim();
                string s7 = school.Text.ToString().Trim();
                string s8 = major.Text.ToString().Trim();
                string s9 = do_c.Text.ToString().Trim();
                string s10 = room.Text.ToString().Trim();
                string r_id = ConnectDB.getInstance().GetStuRoomId(s1);
                string str = " ";
                if (s2 != "")
                {
                    str = str + "sname='" + s2 + "', ";
                }
                if (s3 != "")
                {
                    str = str + "gender='" + s3 + "', ";
                }
                else
                {
                    s3 = ConnectDB.getInstance().GetStuSex(s1);
                }
                if (s4 != "")
                {
                    str = str + "class=" + s4 + ", ";
                }
                if (s5 != "")
                {
                    str = str + "tel='" + s5 + "', ";
                }
                if (s6 != "")
                {
                    str = str + "age=" + s6 + ", ";
                }
                if (s7 != "")
                {
                    s7 = ConnectDB.getInstance().GetMaId(s7);
                    if (s7 == "0")
                    {
                        MessageBox.Show("不存在该学院！", "提示");
                        return;
                    }
                    else
                    {
                        str = str + "u_id=" + s7 + ", ";
                    }
                }
                if (s8 != "")
                {
                    s8 = ConnectDB.getInstance().GetMaId(s8);
                    if (s8 == "0")
                    {
                        MessageBox.Show("不存在该专业！", "提示");
                        return;
                    }
                    else
                    {
                        str = str + "m_id=" + s8 + ", ";
                    }
                }
                
                if (s9 != "全部")
                {
                    s9 = ConnectDB.getInstance().GetDorId(s9);
                    if (ConnectDB.getInstance().GetSex(s9) != s3 )
                    {
                        MessageBox.Show("该宿舍不是" + s3 + "生宿舍！", "提示");
                        return;
                    }
                    else
                    {
                        str = str + "d_id=" + s9 + ", ";
                    }
                }
                else
                {
                    s9 = ConnectDB.getInstance().GetStuDorId(s1);
                }
                if (s10 != "")
                {
                    s10 = ConnectDB.getInstance().GetRoomId(s10);
                    if (s10 == "0")
                    {
                        MessageBox.Show("不存在该房间！", "提示");
                        return;
                    }
                    if (ConnectDB.getInstance().GetRoomDorId(s10) != s9)
                    {
                        MessageBox.Show("该宿舍楼不存在该房间！", "提示");
                        return;
                    }
                    int sum = ConnectDB.getInstance().GetSum(s10);
                    if (sum == 0)
                    {
                        MessageBox.Show("该房间已满！", "提示");
                        return;
                    }
                    else if (sum == -1)
                    {
                        MessageBox.Show("不存在该房间！", "提示");
                        return;
                    }
                    else
                    {
                        str = str + "r_id=" + s10 + " ";
                    }
                }
                string sqlStr = "update student set"+str+"where sno='"+s1+"'";
                ConnectDB.getInstance().Change(sqlStr);
                if (r_id != null && r_id!=s10)
                {
                    int m = ConnectDB.getInstance().GetSum(r_id)+1;
                    int k = ConnectDB.getInstance().GetSum(s10)-1;
                    ConnectDB.getInstance().Change("update room set margin="+m+" where id=" + r_id);
                    ConnectDB.getInstance().Change("update room set margin="+k+" where id=" + s10);
                }
                check_Click(sender, e);
            }
            else
            {
                MessageBox.Show("要修改的学生学号不存在！", "提示");
            }
        }
        /*
         * 出入登记页面的显示与隐藏
         */
        private void I_o(bool b)
        {
            d_label.Visible = b;
            d.Visible = b;
            s_name_label1.Visible = b;
            s_name.Visible = b;
            chaxun.Visible = b;
            if (b == true && power == 0)
            {
                s_name_label2.Visible = b;
                s_name_c.Visible = b;
                chuqu.Visible = b;
                fanhui.Visible = b;
            }
            else
            {
                s_name_label2.Visible = false;
                s_name_c.Visible = false;
                chuqu.Visible = false;
                fanhui.Visible = false;
            }
        }
        /*
         * 出入登记页面出去按钮的点击事件
         */
        private void chuqu_Click(object sender, EventArgs e)
        {
            string s1 = d.Text.ToString().Trim();
            string s2 = s_name.Text.ToString().Trim();
            DateTime t = DateTime.Now;
            if (s2 == "")
            {
                MessageBox.Show("插入时内容不能为空！", "提示");
                return;
            }
            s1 = ConnectDB.getInstance().GetDorId(s1);
            if (ConnectDB.getInstance().GetDorIdByStu(s2) != s1)
            {
                MessageBox.Show("该宿舍不存在该学生！", "提示");
                return;
            }
            s2 = ConnectDB.getInstance().GetStuId(s2);
            string sqlStr = "insert into in_out (d_id,s_id,out_date) values(" + s1 + "," + s2 + ",'" + t.ToString() + "')";
            int c = ConnectDB.getInstance().Change(sqlStr);
            if (c == 0)
            {
                MessageBox.Show("插入失败！", "提示");
                return;
            }
            chaxun_Click(sender, e);
        }
        /*
         * 出入登记页面查询按钮的点击事件
         */
        private void chaxun_Click(object sender, EventArgs e)
        {
            string s1 = d.Text.ToString().Trim();
            string s2 = s_name.Text.ToString().Trim();

            DataSet ds;
            s1 = s1 != "全部" ? " dormitory.ch='" + s1[0] + "' and dormitory.num=" + s1.Substring(1, s1.Length - 1) : " dormitory.ch!='null' and dormitory.num!=0";
            s2 = s2 != "" ? " and student.sname='" + s2 + "'" : " and student.sname!='null'";
            ds = ConnectDB.getInstance().GetData("select student.sno 学号,student.sname 姓名,student.tel 联系方式,student.class 年级,A.name 学院,B.name 专业,room.num 房间,in_out.out_date 出去时间,in_out.in_date 返回时间" +
                                            " from ((((in_out left join student on in_out.s_id=student.id) left join major A on student.u_id=A.id) left join major B on student.m_id=B.id) left join dormitory on student.d_id=dormitory.id) left join room on student.r_id=room.id" +
                                            " where" + s1 + s2);
            dataGridView0.DataSource = ds != null ? ds.Tables[0] : null;
        }
        /*
         * 出入登记页面返回按钮的点击事件
         */
        private void fanhui_Click(object sender, EventArgs e)
        {
            string s1 = d.Text.ToString().Trim();
            string s2 = s_name_c.Text.ToString().Trim();
            if(s2 == "") 
            {
                MessageBox.Show("请输入姓名！", "提示");
                return;
            }
            s1 = ConnectDB.getInstance().GetDorId(s1);
            s2 = ConnectDB.getInstance().GetStuId(s2);
            DateTime t = DateTime.Now;
            string sqlStr = "update in_out set in_date='"+t.ToString()+"' where d_id="+s1+" and s_id="+s2;
            ConnectDB.getInstance().Change(sqlStr);
            chaxun_Click(sender, e);
        }
        /*
         * 来访登记页面的显示与隐藏
         */
        private void I_c(bool b)
        {
            v_d.Visible = b;
            v_d_label.Visible = b;
            v_name_label4.Visible = b;
            v_name3.Visible = b;
            check_bt.Visible = b;
            if (b == true && power == 0)
            {
                v_name_label1.Visible = b;
                v_name1.Visible = b;
                v_name_label2.Visible = b;
                v_name_c.Visible = b;
                v_name_label3.Visible = b;
                v_name2.Visible = b;
                in_bt.Visible = b;
                out_bt.Visible = b;
            }
            else
            {
                v_name_label1.Visible = false;
                v_name1.Visible = false;
                v_name_label2.Visible = false;
                v_name_c.Visible = false;
                v_name_label3.Visible = false;
                v_name2.Visible = false;
                in_bt.Visible = false;
                out_bt.Visible = false;
            }
        }
        /*
         * 来访登记页面进入按钮的点击事件
         */
        private void in_bt_Click(object sender, EventArgs e)
        {
            string s1 = v_d.Text.ToString().Trim();
            string s2 = v_name1.Text.ToString().Trim();
            string s3 = v_name2.Text.ToString().Trim();
            DateTime d = DateTime.Now;
            if (s2 == "" || s3 == "")
            {
                MessageBox.Show("插入时内容不能为空！", "提示");
                return;
            }
            string sqlStr = "insert into visit (d_id,s_id,name,in_date) values(" +ConnectDB.getInstance().GetDorId(s1)+","+ConnectDB.getInstance().GetStuId(s2)+",'"+s3+"','"+d.ToString()+"')";
            int c = ConnectDB.getInstance().Change(sqlStr);
            if (c == 0)
            {
                MessageBox.Show("插入失败！", "提示");
                return;
            }
            check_bt_Click(sender, e);
        }
        /*
         * 来访登记页面出去按钮的点击事件
         */
        private void out_bt_Click(object sender, EventArgs e)
        {
            string s1 = v_d.Text.ToString().Trim();
            string s2 = v_name_c.Text.ToString().Trim();
            if (s2 == "")
            {
                MessageBox.Show("请输入姓名！", "提示");
                return;
            }
            s1 = ConnectDB.getInstance().GetDorId(s1);
            DateTime t = DateTime.Now;
            string sqlStr = "update visit set out_date='" + t.ToString() + "' where d_id=" + s1 + " and name='" + s2 + "'";
            ConnectDB.getInstance().Change(sqlStr);
            check_bt_Click(sender, e);
        }
        /*
         * 来访登记页面查询按钮的点击事件
         */
        private void check_bt_Click(object sender, EventArgs e)
        {
            string s1 = v_d.Text.ToString().Trim();
            string s2 = v_name3.Text.ToString().Trim();

            DataSet ds;
            s1 = s1 != "全部" ? " dormitory.ch='" + s1[0] + "' and dormitory.num=" + s1.Substring(1, s1.Length - 1) : " dormitory.ch!='null' and dormitory.num!=0";
            s2 = s2 != "" ? " and student.sname='" + s2 + "'" : " and student.sname!='null'";
            ds = ConnectDB.getInstance().GetData("select visit.name 来访人,student.sno 学号,student.sname 姓名,student.tel 联系方式,student.class 年级,A.name 学院,B.name 专业,room.num 房间,visit.in_date 访问时间,visit.out_date 出去时间" +
                                            " from ((((visit left join student on visit.s_id=student.id) left join major A on student.u_id=A.id) left join major B on student.m_id=B.id) left join dormitory on student.d_id=dormitory.id) left join room on student.r_id=room.id" +
                                            " where" + s1 + s2);
            dataGridView0.DataSource = ds != null ? ds.Tables[0] : null;
        }
        /*
         * 关于我们页面的显示与隐藏
         */
        private void About(bool b)
        {
            pictureBox1.Visible = b;
            pictureBox2.Visible = b;
            pictureBox3.Visible = b;
            pictureBox4.Visible = b;
            pictureBox5.Visible = b;
            label1.Visible = b;
            label2.Visible = b;
            label3.Visible = b;
            label4.Visible = b;
            label9.Visible = b;
        }
        /*
         * 高级管理页面的显示与隐藏
         */
        private void High(bool b)
        {
            old_label.Visible = b;
            old_password.Visible = b;
            new_label.Visible = b;
            new_password.Visible = b;
            change_password.Visible = b;
            admin_label.Visible = b;
            user_admin.Visible = b;
            password_label.Visible = b;
            password.Visible = b;
            power_label.Visible = b;
            power_c.Visible = b;
            add_admin.Visible = b;
            label8.Visible = b;
            admin_tel_label.Visible = b;
            admin_tel.Visible = b;
            del_admin.Visible = b;
            select_admin.Visible = b;
        }
        /*
         * 高级管理页面修改密码按钮的点击事件
         */
        private void change_password_Click(object sender, EventArgs e)
        {
            string s1 = old_password.Text.ToString().Trim();
            string s2 = new_password.Text.ToString().Trim();
            if (ConnectDB.getInstance().ISTrue(admin_id.ToString(), s1))
            {
                ConnectDB.getInstance().Change("update admin set password='"+s2+"' where id="+admin_id.ToString());
            }
            CheckAllAdmin();
        }
        /*
         * 高级管理页面增加管理员按钮的点击事件
         */
        private void add_admin_Click(object sender, EventArgs e)
        {
            string s1 = user_admin.Text.ToString().Trim();
            string s2 = password.Text.ToString().Trim();
            string s3 = power_c.Text.ToString().Trim();
            string s4 = admin_tel.Text.ToString().Trim();

            if (s1 == "" || s2 == "" || s4 == "")
            {
                MessageBox.Show("请填写内容！", "提示");
                return;
            }
            ConnectDB.getInstance().Change("insert into admin (aname,password,tel,power) values ('"+s1+"','"+s2+"','"+s4+"',"+s3+")");
            CheckAllAdmin();
        }
        /*
         * 高级管理页面删除按钮的点击事件
         */
        private void del_admin_Click(object sender, EventArgs e)
        {
            if (dat == null)
            {
                MessageBox.Show("没有选中的内容！", "提示");
                return;
            }
            string sqlStr = "delete from admin where id=";
            for (int i = 0; i < dat.Rows.Count; i++)
            {
                ConnectDB.getInstance().Change(sqlStr + dat.Rows[i]["id"]+" and id!="+admin_id);
            }
            CheckAllAdmin();
        }
        /*
         * 高级管理页面查询按钮的点击事件
         */
        private void select_admin_Click(object sender, EventArgs e)
        {
            string s1 = user_admin.Text.ToString().Trim();
            string s2 = password.Text.ToString().Trim();
            string s3 = power_c.Text.ToString().Trim();
            string s4 = admin_tel.Text.ToString().Trim();

            if (s1 != "")
            {
                s1 = " and aname='" + s1 + "'";
            }
            else
            {
                s1 = null;
            }
            if (s2 != "")
            {
                s2 = " and password='" + s2 + "'";
            }
            else
            {
                s2 = null;
            }
            if (s4 != "")
            {
                s4 = " and tel='" + s4 + "'";
            }
            else
            {
                s4 = null;
            }
            DataSet ds;
            ds = ConnectDB.getInstance().GetData("select id, aname 名字,tel 联系方式,power 权限 from admin where power="+s3 + s1 + s2 + s4);
            dat = ds != null ? ds.Tables[0] : null;
            dataGridView0.DataSource = dat;
        }

        /*
         * 查询所有管理员
         */
        private void CheckAllAdmin()
        {
            DataSet ds = ConnectDB.getInstance().GetData("select id, aname 名字,tel 联系方式,power 权限 from admin");
            dat = ds != null ? ds.Tables[0] : null;
            dataGridView0.DataSource = dat;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            n.Text = admin_name;
            if (power == 2)
                high.Visible = true;

            d_m.BackColor = System.Drawing.Color.DeepSkyBlue;
            s_m.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_o.BackColor = System.Drawing.Color.PaleGoldenrod;
            i_c.BackColor = System.Drawing.Color.PaleGoldenrod;
            about.BackColor = System.Drawing.Color.PaleGoldenrod;
            high.BackColor = System.Drawing.Color.PaleGoldenrod;

            D_m(true);
            S_m(false);
            I_o(false);
            I_c(false);
            About(false);
            High(false);

            SetDormitory(lou,"select ch+cast(num as varchar(2)) d_id from dormitory");
        }
        /*
         * 为宿舍楼赋值选项
         */
        private void SetDormitory(ComboBox cb,string sqlStr)
        {
            cb.ValueMember = "d_id";
            try
            {
                DataTable dt = ConnectDB.getInstance().GetData(sqlStr).Tables[0];
                
                if (power != 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["d_id"] = "全部";
                    dt.Rows.InsertAt(dr, 0);
                }
                cb.DataSource = dt;
            }
            catch (Exception a)
            {
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void s_name_label1_Click(object sender, EventArgs e)
        {

        }
    }
}
