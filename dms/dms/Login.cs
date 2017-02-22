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
    public partial class Login : Form
    {
        private Point offset;

        public Login()
        {
            InitializeComponent();
        }
        /*
         * 标题栏鼠标点下事件
         */
        private void login_top_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        /*
         * 标题栏鼠标移动事件
         */
        private void login_top_MouseMove(object sender, MouseEventArgs e)
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
         * 登陆按钮点击事件
         */
        private void login_bt_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || password.Text == "")
            {
                MessageBox.Show("用户名和密码不能为空！", "提示");
                return;
            }
            if (ConnectDB.getInstance().Login(user.Text, password.Text))
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            else
            {
                MessageBox.Show("用户不存在或密码错误！", "提示");
            }
        }

    }
}
