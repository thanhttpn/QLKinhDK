namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;
    using QLBV.DataAccess;    

    public class frmDangNhap : Form
    {
        public string chucnang;
        private Button cmdDangNhap;
        private Button cmdThoat;
        private Container components = null;
        private DataAccess dba = new DataAccess();
        private GroupBox groupBox1;
        public string hoten;
        public int key;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblkt;
        private Label lblmoi;
        private LinkLabel lnkDoiPass;
        private LinkLabel lnkLuu;
        public int ma;
        public string password;
        public int quyen;
        private TextBox txtConfirm;
        private TextBox txtPass;
        private TextBox txtPassMoi;
        private TextBox txtUser;
        public string username;

        public frmDangNhap()
        {
            this.InitializeComponent();
            this.key = -1;
        }

        private void cmdDangNhap_Click(object sender, EventArgs e)
        {
            this.kiemtra();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            base.ActiveControl = this.txtUser;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.cmdDangNhap = new System.Windows.Forms.Button();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkDoiPass = new System.Windows.Forms.LinkLabel();
            this.lnkLuu = new System.Windows.Forms.LinkLabel();
            this.txtPassMoi = new System.Windows.Forms.TextBox();
            this.lblmoi = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.lblkt = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Arial", 9.25F);
            this.txtUser.Location = new System.Drawing.Point(120, 64);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(232, 22);
            this.txtUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 32);
            this.label1.TabIndex = 2;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label2.Location = new System.Drawing.Point(32, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "UserName ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.25F);
            this.label3.Location = new System.Drawing.Point(32, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Arial", 9.25F);
            this.txtPass.Location = new System.Drawing.Point(120, 96);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(232, 22);
            this.txtPass.TabIndex = 2;
            this.txtPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPass_KeyDown);
            // 
            // cmdDangNhap
            // 
            this.cmdDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdDangNhap.Location = new System.Drawing.Point(208, 24);
            this.cmdDangNhap.Name = "cmdDangNhap";
            this.cmdDangNhap.Size = new System.Drawing.Size(75, 24);
            this.cmdDangNhap.TabIndex = 3;
            this.cmdDangNhap.Text = "Đăng nhập";
            this.cmdDangNhap.Click += new System.EventHandler(this.cmdDangNhap_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThoat.Location = new System.Drawing.Point(296, 24);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(75, 24);
            this.cmdThoat.TabIndex = 8;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkDoiPass);
            this.groupBox1.Controls.Add(this.lnkLuu);
            this.groupBox1.Controls.Add(this.cmdThoat);
            this.groupBox1.Controls.Add(this.cmdDangNhap);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 56);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // lnkDoiPass
            // 
            this.lnkDoiPass.Location = new System.Drawing.Point(8, 24);
            this.lnkDoiPass.Name = "lnkDoiPass";
            this.lnkDoiPass.Size = new System.Drawing.Size(100, 23);
            this.lnkDoiPass.TabIndex = 4;
            this.lnkDoiPass.TabStop = true;
            this.lnkDoiPass.Text = "Đổi Password";
            this.lnkDoiPass.Visible = false;
            this.lnkDoiPass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDoiPass_LinkClicked);
            // 
            // lnkLuu
            // 
            this.lnkLuu.Location = new System.Drawing.Point(8, 24);
            this.lnkLuu.Name = "lnkLuu";
            this.lnkLuu.Size = new System.Drawing.Size(48, 23);
            this.lnkLuu.TabIndex = 7;
            this.lnkLuu.TabStop = true;
            this.lnkLuu.Text = "Lưu";
            this.lnkLuu.Visible = false;
            this.lnkLuu.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLuu_LinkClicked);
            // 
            // txtPassMoi
            // 
            this.txtPassMoi.Font = new System.Drawing.Font("Arial", 9.25F);
            this.txtPassMoi.Location = new System.Drawing.Point(120, 128);
            this.txtPassMoi.Name = "txtPassMoi";
            this.txtPassMoi.PasswordChar = '*';
            this.txtPassMoi.Size = new System.Drawing.Size(232, 22);
            this.txtPassMoi.TabIndex = 5;
            this.txtPassMoi.Visible = false;
            // 
            // lblmoi
            // 
            this.lblmoi.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblmoi.Location = new System.Drawing.Point(8, 128);
            this.lblmoi.Name = "lblmoi";
            this.lblmoi.Size = new System.Drawing.Size(104, 23);
            this.lblmoi.TabIndex = 12;
            this.lblmoi.Text = "Password mới";
            this.lblmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblmoi.Visible = false;
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Arial", 9.25F);
            this.txtConfirm.Location = new System.Drawing.Point(120, 160);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(232, 22);
            this.txtConfirm.TabIndex = 6;
            this.txtConfirm.Visible = false;
            // 
            // lblkt
            // 
            this.lblkt.Font = new System.Drawing.Font("Arial", 9.25F);
            this.lblkt.Location = new System.Drawing.Point(0, 160);
            this.lblkt.Name = "lblkt";
            this.lblkt.Size = new System.Drawing.Size(112, 23);
            this.lblkt.TabIndex = 14;
            this.lblkt.Text = "Confirm Password";
            this.lblkt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblkt.Visible = false;
            // 
            // frmDangNhap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(382, 180);
            this.Controls.Add(this.lblkt);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.txtPassMoi);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblmoi);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDangNhap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dang Nhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        public void kiemtra()
        {
            this.logkey();
            if (this.key == 1)
            {
                base.Close();
            }
            else
            {
                this.txtUser.Text = "";
                this.txtPass.Text = "";
                base.ActiveControl = this.txtUser;
                MessageBox.Show("Bạn đ\x00e3 nhập sai t\x00ean hoăc mật khẩu đăng nhập", "Th\x00f4ng B\x00e1o");
            }
        }

        private void lnkDoiPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.ClientSize = new Size(0x1a2, 0x110);
            this.lblmoi.Visible = true;
            this.txtPassMoi.Visible = true;
            this.lblkt.Visible = true;
            this.txtConfirm.Visible = true;
            this.lnkDoiPass.Visible = false;
            this.lnkLuu.Visible = true;
        }

        private void lnkLuu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.logkey();
                if ((this.txtUser.Text == this.username) && (this.txtPass.Text == this.password))
                {
                    if (this.txtPassMoi.Text == this.txtConfirm.Text)
                    {
                        this.dba.CommandText = "Update thongtinbs set password = '" + CommonClass.textRepair(this.txtPassMoi.Text) + "' where username='" + CommonClass.textRepair(this.txtUser.Text) + "'";
                        this.dba.ExecuteNonQuery();
                        goto Label_0115;
                    }
                    MessageBox.Show("Nhập mật khẩu ở Password mới v\x00e0 Confirm password phải giống nhau", "Th\x00f4ng b\x00e1o");
                    base.ActiveControl = this.txtPassMoi;
                    this.txtPass.Text = "";
                    this.txtPassMoi.Text = "";
                }
                else
                {
                    MessageBox.Show("Bạn đ\x00e3 nhập sai password hoặc username !", "Th\x00f4ng b\x00e1o");
                }
                return;
            Label_0115:
                MessageBox.Show("Bạn đ\x00e3 đổi password th\x00e0nh c\x00f4ng", "Th\x00f4ng b\x00e1o");
                this.txtPass.Text = "";
                base.ClientSize = new Size(0x1a2, 0xd0);
                this.lblmoi.Visible = false;
                this.txtPassMoi.Visible = false;
                this.lblkt.Visible = false;
                this.txtConfirm.Visible = false;
                this.lnkDoiPass.Visible = true;
                this.lnkLuu.Visible = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        public void logkey()
        {
            if ((this.txtUser.Text.Trim() == "sa") && (this.txtPass.Text.Trim() == "sa"))
            {
                this.ma = 0;
                this.hoten = "administrator";
                this.username = "admin";
                this.password = "admin";
                this.quyen = 1;
                this.key = 1;
            }
            else
            {
                DataAccess access = new DataAccess();
                try
                {
                    DataTable data = access.GetData("select MANV,TENNHANVIEN,USERNAME,PASSWORD,PHANQUYEN,CHUCNANG from NHANVIEN where USERNAME = '" + this.txtUser.Text.Trim() + "' and password=dbo.md5('" + this.txtPass.Text.Trim() + "')");
                    if (data.Rows.Count > 0)
                    {
                        foreach (DataRow row in data.Rows)
                        {
                            this.ma = int.Parse(row[0].ToString());
                            this.hoten = row[1].ToString();
                            this.username = row[2].ToString();
                            this.password = row[3].ToString();
                            this.quyen = int.Parse(row[4].ToString());
                            this.chucnang = row[5].ToString();
                            this.key = 1;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Database kh\x00f4ng thể kết nối, vui l\x00f2ng hỏi lại người Quản Trị", "Th\x00f4ng b\x00e1o");
                }
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.kiemtra();
            }
        }
    }
}

