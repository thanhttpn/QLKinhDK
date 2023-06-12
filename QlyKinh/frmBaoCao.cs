namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;

    public class frmBaoCao : Form
    {
        private Button cmdExit;
        private Button cmdThoat;
        private Container components = null;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox6;
        private GroupBox groupBox7;
        private GroupBox groupBox8;
        private Label label1;
        private Label label10;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label8;
        private LinkLabel lnkHangTonKho;
        private LinkLabel lnkTK;
        private LinkLabel lnkTKCTTBCBN;
        private LinkLabel lnkTKPN;
        private LinkLabel lnkTKPX;
        private LinkLabel lnkTKTBR;
        private LinkLabel lnkTKTN;
        private LinkLabel lnkTTTTN;
        private LinkLabel lnkXNT;

        public frmBaoCao()
        {
            this.InitializeComponent();
        }

        private void cmdExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkHangTonKho = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lnkTKPN = new System.Windows.Forms.LinkLabel();
            this.lnkTKPX = new System.Windows.Forms.LinkLabel();
            this.lnkXNT = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lnkTK = new System.Windows.Forms.LinkLabel();
            this.lnkTKTBR = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lnkTKTN = new System.Windows.Forms.LinkLabel();
            this.lnkTKCTTBCBN = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkTTTTN = new System.Windows.Forms.LinkLabel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(248, 177);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(288, 3);
            this.groupBox7.TabIndex = 96;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "groupBox7";
            // 
            // groupBox6
            // 
            this.groupBox6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(248, 96);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(280, 3);
            this.groupBox6.TabIndex = 95;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            // 
            // groupBox4
            // 
            this.groupBox4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 3);
            this.groupBox4.TabIndex = 93;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // groupBox3
            // 
            this.groupBox3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 176);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 3);
            this.groupBox3.TabIndex = 92;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // groupBox2
            // 
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 3);
            this.groupBox2.TabIndex = 91;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // cmdThoat
            // 
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThoat.Location = new System.Drawing.Point(639, 387);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(75, 23);
            this.cmdThoat.TabIndex = 89;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(241, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(3, 248);
            this.groupBox1.TabIndex = 88;
            this.groupBox1.TabStop = false;
            // 
            // lnkHangTonKho
            // 
            this.lnkHangTonKho.Location = new System.Drawing.Point(72, 69);
            this.lnkHangTonKho.Name = "lnkHangTonKho";
            this.lnkHangTonKho.Size = new System.Drawing.Size(100, 15);
            this.lnkHangTonKho.TabIndex = 73;
            this.lnkHangTonKho.TabStop = true;
            this.lnkHangTonKho.Text = "Hàng tồn kho";
            this.lnkHangTonKho.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHangTonKho_LinkClicked);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 69;
            this.label1.Text = "Hàng tồn";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Blue;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(544, 32);
            this.label13.TabIndex = 59;
            this.label13.Text = "BÁO CÁO";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(4, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 16);
            this.label2.TabIndex = 68;
            this.label2.Text = "Liệt kê nhập xuất";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkTKPN
            // 
            this.lnkTKPN.Location = new System.Drawing.Point(64, 128);
            this.lnkTKPN.Name = "lnkTKPN";
            this.lnkTKPN.Size = new System.Drawing.Size(136, 16);
            this.lnkTKPN.TabIndex = 80;
            this.lnkTKPN.TabStop = true;
            this.lnkTKPN.Text = "Liệt kê phiếu nhập";
            this.lnkTKPN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTKPN_LinkClicked);
            // 
            // lnkTKPX
            // 
            this.lnkTKPX.Location = new System.Drawing.Point(64, 152);
            this.lnkTKPX.Name = "lnkTKPX";
            this.lnkTKPX.Size = new System.Drawing.Size(136, 16);
            this.lnkTKPX.TabIndex = 81;
            this.lnkTKPX.TabStop = true;
            this.lnkTKPX.Text = "Liệt kê phiếu xuất";
            this.lnkTKPX.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTKPX_LinkClicked);
            // 
            // lnkXNT
            // 
            this.lnkXNT.Location = new System.Drawing.Point(64, 208);
            this.lnkXNT.Name = "lnkXNT";
            this.lnkXNT.Size = new System.Drawing.Size(104, 16);
            this.lnkXNT.TabIndex = 82;
            this.lnkXNT.TabStop = true;
            this.lnkXNT.Text = "Cân đối XNT ";
            this.lnkXNT.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkXNTKL_LinkClicked);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(4, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 16);
            this.label3.TabIndex = 61;
            this.label3.Text = "Cân đối xuất nhập tồn";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(8, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 16);
            this.label6.TabIndex = 63;
            this.label6.Text = "Thẻ Kho";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkTK
            // 
            this.lnkTK.Location = new System.Drawing.Point(64, 264);
            this.lnkTK.Name = "lnkTK";
            this.lnkTK.Size = new System.Drawing.Size(160, 16);
            this.lnkTK.TabIndex = 72;
            this.lnkTK.TabStop = true;
            this.lnkTK.Text = "Thẻ Kho";
            this.lnkTK.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTK_LinkClicked);
            // 
            // lnkTKTBR
            // 
            this.lnkTKTBR.Location = new System.Drawing.Point(296, 128);
            this.lnkTKTBR.Name = "lnkTKTBR";
            this.lnkTKTBR.Size = new System.Drawing.Size(212, 16);
            this.lnkTKTBR.TabIndex = 77;
            this.lnkTKTBR.TabStop = true;
            this.lnkTKTBR.Text = "Thống kê kính bán ra";
            this.lnkTKTBR.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTKTBR_LinkClicked);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(248, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(288, 16);
            this.label8.TabIndex = 67;
            this.label8.Text = "Thống kê kính bán cho bệnh nhân";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label10.Location = new System.Drawing.Point(248, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(288, 16);
            this.label10.TabIndex = 99;
            this.label10.Text = "Thống kê kính nhập";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkTKTN
            // 
            this.lnkTKTN.Location = new System.Drawing.Point(296, 72);
            this.lnkTKTN.Name = "lnkTKTN";
            this.lnkTKTN.Size = new System.Drawing.Size(176, 16);
            this.lnkTKTN.TabIndex = 100;
            this.lnkTKTN.TabStop = true;
            this.lnkTKTN.Text = "Thống kê kính nhập";
            this.lnkTKTN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTKTN_LinkClicked);
            // 
            // lnkTKCTTBCBN
            // 
            this.lnkTKCTTBCBN.Location = new System.Drawing.Point(296, 152);
            this.lnkTKCTTBCBN.Name = "lnkTKCTTBCBN";
            this.lnkTKCTTBCBN.Size = new System.Drawing.Size(272, 16);
            this.lnkTKCTTBCBN.TabIndex = 102;
            this.lnkTKCTTBCBN.TabStop = true;
            this.lnkTKCTTBCBN.Text = "Thống kê kính bán cho bệnh nhân(CT)";
            this.lnkTKCTTBCBN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTKCTTBCBN_LinkClicked);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(248, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(288, 16);
            this.label4.TabIndex = 103;
            this.label4.Text = "Tổng tiền thu trong ngày";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lnkTTTTN
            // 
            this.lnkTTTTN.BackColor = System.Drawing.Color.LightGray;
            this.lnkTTTTN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkTTTTN.Location = new System.Drawing.Point(296, 208);
            this.lnkTTTTN.Name = "lnkTTTTN";
            this.lnkTTTTN.Size = new System.Drawing.Size(176, 16);
            this.lnkTTTTN.TabIndex = 104;
            this.lnkTTTTN.TabStop = true;
            this.lnkTTTTN.Text = "Tổng tiền thu trong ngày";
            this.lnkTTTTN.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkTTTTN_LinkClicked);
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(248, 232);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(288, 3);
            this.groupBox8.TabIndex = 106;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "groupBox8";
            // 
            // cmdExit
            // 
            this.cmdExit.BackColor = System.Drawing.SystemColors.Control;
            this.cmdExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdExit.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdExit.Location = new System.Drawing.Point(464, 256);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(75, 23);
            this.cmdExit.TabIndex = 105;
            this.cmdExit.Text = "Thoát";
            this.cmdExit.UseVisualStyleBackColor = false;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(544, 286);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.lnkTTTTN);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lnkTKCTTBCBN);
            this.Controls.Add(this.lnkTKTN);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lnkHangTonKho);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lnkTKPN);
            this.Controls.Add(this.lnkTKPX);
            this.Controls.Add(this.lnkXNT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lnkTK);
            this.Controls.Add(this.lnkTKTBR);
            this.Controls.Add(this.label8);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBaoCao";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            this.ResumeLayout(false);

		}

        private void lnkHangTonKho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmChonloaiVT().ShowDialog(this);
        }

        private void lnkTK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmTheKho().ShowDialog(this);
        }

        private void lnkTKCTTBCBN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(4).ShowDialog(this);
        }

        private void lnkTKPN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(0).ShowDialog(this);
        }

        private void lnkTKPX_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(1).ShowDialog(this);
        }

        private void lnkTKTBR_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(3).ShowDialog(this);
        }

        private void lnkTKTN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(5).ShowDialog(this);
        }

        private void lnkTogntienBNMoi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(7).ShowDialog(this);
        }

        private void lnkTongtienBNCu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(8).ShowDialog(this);
        }

        private void lnkTTTTN_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(6).ShowDialog(this);
        }

        private void lnkXNTKL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new frmBCngay(2).ShowDialog(this);
        }
    }
}

