namespace dms
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.login_top = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.small = new System.Windows.Forms.Label();
            this.user_pic = new System.Windows.Forms.PictureBox();
            this.password_pic = new System.Windows.Forms.PictureBox();
            this.user = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.login_bt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.user_pic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.password_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // login_top
            // 
            this.login_top.BackColor = System.Drawing.Color.SkyBlue;
            this.login_top.Font = new System.Drawing.Font("宋体", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_top.ForeColor = System.Drawing.Color.DarkGreen;
            this.login_top.Location = new System.Drawing.Point(-1, 0);
            this.login_top.Name = "login_top";
            this.login_top.Size = new System.Drawing.Size(545, 119);
            this.login_top.TabIndex = 0;
            this.login_top.Text = "宿舍管理系统";
            this.login_top.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.login_top.MouseDown += new System.Windows.Forms.MouseEventHandler(this.login_top_MouseDown);
            this.login_top.MouseMove += new System.Windows.Forms.MouseEventHandler(this.login_top_MouseMove);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.SkyBlue;
            this.close.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.close.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.close.Location = new System.Drawing.Point(513, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(31, 26);
            this.close.TabIndex = 1;
            this.close.Text = "×";
            this.close.Click += new System.EventHandler(this.close_Click);
            this.close.MouseEnter += new System.EventHandler(this.close_MouseEnter);
            this.close.MouseLeave += new System.EventHandler(this.close_MouseLeave);
            // 
            // small
            // 
            this.small.BackColor = System.Drawing.Color.SkyBlue;
            this.small.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.small.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.small.Location = new System.Drawing.Point(488, 0);
            this.small.Name = "small";
            this.small.Size = new System.Drawing.Size(28, 26);
            this.small.TabIndex = 2;
            this.small.Text = "▁";
            this.small.Click += new System.EventHandler(this.small_Click);
            this.small.MouseEnter += new System.EventHandler(this.small_MouseEnter);
            this.small.MouseLeave += new System.EventHandler(this.small_MouseLeave);
            // 
            // user_pic
            // 
            this.user_pic.BackColor = System.Drawing.Color.SkyBlue;
            this.user_pic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.user_pic.Image = ((System.Drawing.Image)(resources.GetObject("user_pic.Image")));
            this.user_pic.Location = new System.Drawing.Point(154, 142);
            this.user_pic.Name = "user_pic";
            this.user_pic.Size = new System.Drawing.Size(43, 31);
            this.user_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.user_pic.TabIndex = 3;
            this.user_pic.TabStop = false;
            // 
            // password_pic
            // 
            this.password_pic.BackColor = System.Drawing.Color.SkyBlue;
            this.password_pic.Image = ((System.Drawing.Image)(resources.GetObject("password_pic.Image")));
            this.password_pic.Location = new System.Drawing.Point(154, 194);
            this.password_pic.Name = "password_pic";
            this.password_pic.Size = new System.Drawing.Size(44, 31);
            this.password_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.password_pic.TabIndex = 4;
            this.password_pic.TabStop = false;
            // 
            // user
            // 
            this.user.AccessibleName = "";
            this.user.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.user.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.user.Location = new System.Drawing.Point(197, 142);
            this.user.MaxLength = 10;
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(194, 31);
            this.user.TabIndex = 5;
            // 
            // password
            // 
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.password.Location = new System.Drawing.Point(197, 194);
            this.password.MaxLength = 10;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(194, 31);
            this.password.TabIndex = 6;
            this.password.UseSystemPasswordChar = true;
            // 
            // login_bt
            // 
            this.login_bt.BackColor = System.Drawing.Color.SkyBlue;
            this.login_bt.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.login_bt.FlatAppearance.BorderSize = 0;
            this.login_bt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.RoyalBlue;
            this.login_bt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.RoyalBlue;
            this.login_bt.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.login_bt.ForeColor = System.Drawing.Color.Snow;
            this.login_bt.Location = new System.Drawing.Point(154, 243);
            this.login_bt.Margin = new System.Windows.Forms.Padding(0);
            this.login_bt.Name = "login_bt";
            this.login_bt.Size = new System.Drawing.Size(237, 34);
            this.login_bt.TabIndex = 7;
            this.login_bt.Text = "登陆";
            this.login_bt.UseVisualStyleBackColor = false;
            this.login_bt.Click += new System.EventHandler(this.login_bt_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(544, 315);
            this.Controls.Add(this.login_bt);
            this.Controls.Add(this.password);
            this.Controls.Add(this.user);
            this.Controls.Add(this.password_pic);
            this.Controls.Add(this.user_pic);
            this.Controls.Add(this.small);
            this.Controls.Add(this.close);
            this.Controls.Add(this.login_top);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宿舍管理系统";
            ((System.ComponentModel.ISupportInitialize)(this.user_pic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.password_pic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void login_top_MouseDown(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label login_top;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label small;
        private System.Windows.Forms.PictureBox user_pic;
        private System.Windows.Forms.PictureBox password_pic;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button login_bt;
    }
}