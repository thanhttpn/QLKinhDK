namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Drawing;
    using System.IO;
    using System.Resources;
    using System.Windows.Forms;

    public class frmMain : Form
    {
        public string chucnang;
        private Button cmdBanThuoc;
        private Button cmdBaoCao;
        private Button cmdCapNhatVatTu;
        private Button cmdLogOut;
        private Button cmdNhapThuoc;
        private Button cmdThayDoiMatKhau;
        private Button cmdThoat;
        private Button cmdXuatThuoc;
        private Container components = null;
        private GroupBox groupBox1;
        private Label label1;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private int maNV;
        public string password;
        private int phanquyen;
        public string tenNV;
        private Button btnRestore;
        private Button btnBackUp;
        public string username;

        public frmMain()
        {
            this.InitializeComponent();
        }

        private bool checkTextFile()
        {
            return true;
        }

        private void cmdBanThuoc_Click(object sender, EventArgs e)
        {
            base.ShowInTaskbar = false;
            base.Visible = false;
            new frmXuatKinh(this.maNV, username).ShowDialog();
            base.ShowInTaskbar = true;
            base.Visible = true;
        }

        private void cmdBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                base.ShowInTaskbar = false;
                base.Visible = false;
                new frmBaoCao().ShowDialog();
                base.ShowInTaskbar = true;
                base.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void cmdCapNhatVatTu_Click(object sender, EventArgs e)
        {
            base.ShowInTaskbar = false;
            base.Visible = false;
            new CapNhatVatTu().ShowDialog();
            base.ShowInTaskbar = true;
            base.Visible = true;
        }

        private void cmdLogOut_Click(object sender, EventArgs e)
        {
            this.Login();
        }

        private void cmdNhapThuoc_Click(object sender, EventArgs e)
        {
            base.ShowInTaskbar = false;
            base.Visible = false;
            new frmNhapKinh(this.maNV).ShowDialog();
            base.ShowInTaskbar = true;
            base.Visible = true;
        }

        private void cmdThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            new frmDoiMatKhau().ShowDialog();
            new frmDangNhap().ShowDialog();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void cmdXuatThuoc_Click(object sender, EventArgs e)
        {
            base.ShowInTaskbar = false;
            base.Visible = false;
            new frmXuatKinhLido(this.maNV).ShowDialog();
            base.ShowInTaskbar = true;
            base.Visible = true;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Login();            
            base.ActiveControl = this.cmdCapNhatVatTu;
        }

        [STAThread]
        private string GetConfigConnectionString()
        {
            string str = ConfigurationSettings.AppSettings.Get("Server");
            string str2 = ConfigurationSettings.AppSettings.Get("ISecurity");
            string str3 = ConfigurationSettings.AppSettings.Get("Database");
            string str4 = ConfigurationSettings.AppSettings.Get("uid");
            string str5 = ConfigurationSettings.AppSettings.Get("pwd");
            return ("Server=" + str + ";uid=" + str4 + ";pwd=" + str5 + ";Integrated Security=" + str2 + ";Database=" + str3);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdLogOut = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackUp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdCapNhatVatTu = new System.Windows.Forms.Button();
            this.cmdNhapThuoc = new System.Windows.Forms.Button();
            this.cmdBanThuoc = new System.Windows.Forms.Button();
            this.cmdXuatThuoc = new System.Windows.Forms.Button();
            this.cmdBaoCao = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.cmdThayDoiMatKhau = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdLogOut
            // 
            this.cmdLogOut.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdLogOut.Location = new System.Drawing.Point(32, 288);
            this.cmdLogOut.Name = "cmdLogOut";
            this.cmdLogOut.Size = new System.Drawing.Size(75, 23);
            this.cmdLogOut.TabIndex = 5;
            this.cmdLogOut.Text = "&LogOut";
            this.cmdLogOut.Click += new System.EventHandler(this.cmdLogOut_Click);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(-24, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(584, 32);
            this.label13.TabIndex = 7;
            this.label13.Text = "BỆNH VIỆN QUỐC TẾ SÀI GÒN - GIA LAI";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRestore);
            this.groupBox1.Controls.Add(this.btnBackUp);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmdCapNhatVatTu);
            this.groupBox1.Controls.Add(this.cmdNhapThuoc);
            this.groupBox1.Controls.Add(this.cmdBanThuoc);
            this.groupBox1.Controls.Add(this.cmdXuatThuoc);
            this.groupBox1.Controls.Add(this.cmdBaoCao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(584, 248);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(16, 185);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(75, 23);
            this.btnRestore.TabIndex = 12;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackUp
            // 
            this.btnBackUp.Location = new System.Drawing.Point(16, 154);
            this.btnBackUp.Name = "btnBackUp";
            this.btnBackUp.Size = new System.Drawing.Size(75, 23);
            this.btnBackUp.TabIndex = 11;
            this.btnBackUp.Text = "Backup";
            this.btnBackUp.UseVisualStyleBackColor = true;
            this.btnBackUp.Click += new System.EventHandler(this.btnBackUp_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(96, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 10;
            // 
            // cmdCapNhatVatTu
            // 
            this.cmdCapNhatVatTu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCapNhatVatTu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapNhatVatTu.Location = new System.Drawing.Point(16, 100);
            this.cmdCapNhatVatTu.Name = "cmdCapNhatVatTu";
            this.cmdCapNhatVatTu.Size = new System.Drawing.Size(80, 48);
            this.cmdCapNhatVatTu.TabIndex = 0;
            this.cmdCapNhatVatTu.Text = "Cập Nhật Vật Tư Kính";
            this.cmdCapNhatVatTu.Click += new System.EventHandler(this.cmdCapNhatVatTu_Click);
            // 
            // cmdNhapThuoc
            // 
            this.cmdNhapThuoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdNhapThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNhapThuoc.Location = new System.Drawing.Point(152, 100);
            this.cmdNhapThuoc.Name = "cmdNhapThuoc";
            this.cmdNhapThuoc.Size = new System.Drawing.Size(75, 48);
            this.cmdNhapThuoc.TabIndex = 1;
            this.cmdNhapThuoc.Text = "Nhập Kính";
            this.cmdNhapThuoc.Click += new System.EventHandler(this.cmdNhapThuoc_Click);
            // 
            // cmdBanThuoc
            // 
            this.cmdBanThuoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdBanThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBanThuoc.Location = new System.Drawing.Point(272, 28);
            this.cmdBanThuoc.Name = "cmdBanThuoc";
            this.cmdBanThuoc.Size = new System.Drawing.Size(75, 48);
            this.cmdBanThuoc.TabIndex = 2;
            this.cmdBanThuoc.Text = "Bán Kính";
            this.cmdBanThuoc.Click += new System.EventHandler(this.cmdBanThuoc_Click);
            // 
            // cmdXuatThuoc
            // 
            this.cmdXuatThuoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdXuatThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXuatThuoc.Location = new System.Drawing.Point(272, 184);
            this.cmdXuatThuoc.Name = "cmdXuatThuoc";
            this.cmdXuatThuoc.Size = new System.Drawing.Size(75, 48);
            this.cmdXuatThuoc.TabIndex = 3;
            this.cmdXuatThuoc.Text = "Xuất Kính";
            this.cmdXuatThuoc.Click += new System.EventHandler(this.cmdXuatThuoc_Click);
            // 
            // cmdBaoCao
            // 
            this.cmdBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBaoCao.Location = new System.Drawing.Point(408, 104);
            this.cmdBaoCao.Name = "cmdBaoCao";
            this.cmdBaoCao.Size = new System.Drawing.Size(75, 48);
            this.cmdBaoCao.TabIndex = 4;
            this.cmdBaoCao.Text = "Báo Cáo";
            this.cmdBaoCao.Click += new System.EventHandler(this.cmdBaoCao_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(192, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 56);
            this.label2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(336, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 56);
            this.label3.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(232, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 56);
            this.label4.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(192, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 64);
            this.label5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(336, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 56);
            this.label6.TabIndex = 10;
            // 
            // cmdThoat
            // 
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThoat.Location = new System.Drawing.Point(416, 288);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(75, 23);
            this.cmdThoat.TabIndex = 7;
            this.cmdThoat.Text = "&Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdThayDoiMatKhau
            // 
            this.cmdThayDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThayDoiMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThayDoiMatKhau.Location = new System.Drawing.Point(112, 288);
            this.cmdThayDoiMatKhau.Name = "cmdThayDoiMatKhau";
            this.cmdThayDoiMatKhau.Size = new System.Drawing.Size(136, 23);
            this.cmdThayDoiMatKhau.TabIndex = 6;
            this.cmdThayDoiMatKhau.Text = "&Thay Đổi Mật Khẩu";
            this.cmdThayDoiMatKhau.Click += new System.EventHandler(this.cmdThayDoiMatKhau_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(504, 318);
            this.Controls.Add(this.cmdLogOut);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.cmdThayDoiMatKhau);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quan Li Kinh";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private void Login()
        {
            base.Visible = false;
            base.ShowInTaskbar = false;
            DateTime now = new DateTime();
            DateTime time2 = new DateTime();
            now = DateTime.Now;
            time2 = new DateTime(0x7d7, 6, 30, 0, 0, 0, 0);
            if (now >= time2)
            {
                if (this.checkTextFile())
                {
                    frmDangNhap nhap = new frmDangNhap();
                    nhap.ShowDialog();
                    if (nhap.key == -1)
                    {
                        Application.Exit();
                        return;
                    }
                    this.maNV = nhap.ma;
                    this.tenNV = nhap.hoten;
                    this.username = nhap.username;
                    this.password = nhap.password;
                    this.phanquyen = nhap.quyen;
                    if (nhap.chucnang == "B\x00e1n K\x00ednh")
                    {
                        this.cmdCapNhatVatTu.Enabled = false;
                        this.cmdNhapThuoc.Enabled = false;
                        this.cmdBanThuoc.Enabled = true;
                        this.cmdXuatThuoc.Enabled = false;
                    }
                    else if (nhap.chucnang == "Nhập K\x00ednh")
                    {
                        this.cmdCapNhatVatTu.Enabled = true;
                        this.cmdNhapThuoc.Enabled = true;
                        this.cmdBanThuoc.Enabled = false;
                        this.cmdXuatThuoc.Enabled = true;
                    }
                    else if (nhap.chucnang == "Admin")
                    {
                        this.cmdCapNhatVatTu.Enabled = true;
                        this.cmdNhapThuoc.Enabled = true;
                        this.cmdBanThuoc.Enabled = true;
                        this.cmdXuatThuoc.Enabled = true;
                    }
                    else
                    {
                        this.cmdCapNhatVatTu.Enabled = false;
                        this.cmdNhapThuoc.Enabled = false;
                        this.cmdBanThuoc.Enabled = false;
                        this.cmdXuatThuoc.Enabled = false;
                    }
                    base.Visible = true;
                    base.ShowInTaskbar = true;
                }
                else
                {
                    frmSerialNumber number = new frmSerialNumber();
                    number.ShowDialog();
                    if (number.success == 1)
                    {
                        MessageBox.Show("Thank you registered, please close Application and restart", "Thank you");
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            else
            {
                frmDangNhap nhap2 = new frmDangNhap();
                nhap2.ShowDialog();
                if (nhap2.key == -1)
                {
                    Application.Exit();
                }
                this.maNV = nhap2.ma;
                this.tenNV = nhap2.hoten;
                this.username = nhap2.username;
                this.password = nhap2.password;
                this.phanquyen = nhap2.quyen;
                if (nhap2.chucnang == "B\x00e1n K\x00ednh")
                {
                    this.cmdCapNhatVatTu.Enabled = false;
                    this.cmdNhapThuoc.Enabled = false;
                    this.cmdBanThuoc.Enabled = true;
                    this.cmdXuatThuoc.Enabled = false;
                }
                else if (nhap2.chucnang == "Nhập K\x00ednh")
                {
                    this.cmdCapNhatVatTu.Enabled = true;
                    this.cmdNhapThuoc.Enabled = true;
                    this.cmdBanThuoc.Enabled = false;
                    this.cmdXuatThuoc.Enabled = true;
                }
                else if (nhap2.chucnang == "Admin")
                {
                    this.cmdCapNhatVatTu.Enabled = true;
                    this.cmdNhapThuoc.Enabled = true;
                    this.cmdBanThuoc.Enabled = true;
                    this.cmdXuatThuoc.Enabled = true;
                }
                else
                {
                    this.cmdCapNhatVatTu.Enabled = false;
                    this.cmdNhapThuoc.Enabled = false;
                    this.cmdBanThuoc.Enabled = false;
                    this.cmdXuatThuoc.Enabled = false;
                }
                base.Visible = true;
                base.ShowInTaskbar = true;
            }
        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            BackUpKinh.frmBackupKinh frm = new BackUpKinh.frmBackupKinh();
            frm.ShowDialog();

        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreKinh.frmRestoreKinh frm = new RestoreKinh.frmRestoreKinh();
            frm.ShowDialog();
        }
    }
}

