namespace QlyKinh
{
    using CrystalDecisions.CrystalReports.Engine;    
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using QLBV.DataAccess;
    using System.Configuration;
    using System.IO;
    using QLBV.Common.Controls;
    using DHospital;

    public class frmXuatKinh : frmUpdateForm_Multi
    {
        private ArrayList arrMaPXK;
        private ArrayList arrNV;
        private ComboBox cboNhaVien;
        private ColumnHeader columnHeaderMAPX;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeaderMG;
        private ColumnHeader columnHeaderMVT;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeaderTVT;
        private ColumnHeader columnHeaderGB;
        private ColumnHeader columnHeaderSL;
        private ColumnHeader columnHeaderTT;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private IContainer components;
        private DateTimePicker dtpNgayBanCu;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label15;
        private Label label19;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label7;
        private Label label8;
        private Label lblNgayBan;
        private Label lblNguoiDung;
        private ListBox lstDS_BNLayThuocCu;
        private ListView lswDS_BNLayThuocCu;
        private int m_MaNVDN;
        private Label Nh;
        private ColumnHeader STT;
        private ColumnHeader TenBN;
        private double tongtien;
        private TextBox txtDVT;
        private TextBox txtGiaBan;
        private TextBox txtIndex;
        private LookupBox txtMaBA;
        private TextBox txtMaGong;
        private TextBox txtMaPX;
        private LookupBox txtMaVT;
        private TextBox txtNhanVienTN;
        private TextBox txtSLBan;
        private TextBox txtSLT;
        private LookupBox txtTenVT;
        private ColumnHeader columnHeaderGG;
        private Label label6;
        private TextBox txtGiam;
        private Label label9;
        private TextBox txtSoThe;
        private QLBV.Common.Controls.LookupBox txtHoTenBN;
        private Button btnReload;
        private Button btnDonKinh;
        private ColumnHeader ColIDDoThiLuc;
        private ColumnHeader ColTenBenhNhan;
        private TextBox txtTongTienTrongNgay;
        private string m_TenDangNhap="";

        public frmXuatKinh()
        {
            this.components = null;
            this.m_MaNVDN = 0;
            this.InitializeComponent();
        }

        public frmXuatKinh(int MaNVDN, string TenDangNhap)
        {
            this.components = null;
            this.m_MaNVDN = 0;
            this.InitializeComponent();
            this.m_MaNVDN = MaNVDN;
            if (TenDangNhap.ToLower() != "admin")
            {
                NotDelete = true;
            }
        }

        private void cboNhaVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtNhanVienTN.Text = this.cboNhaVien.Text;
        }

        protected override int checkFrom()
        {
            return 1;
        }

        protected override void clearControls()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (((base.Controls[i].GetType() == typeof(TextBox)) && (i != 5)) && (i != 0x15))
                {
                    ((TextBox) base.Controls[i]).Text = "";
                }
                if (base.Controls[i].GetType() == typeof(LookupBox) )
                {
                    ((LookupBox) base.Controls[i]).Text = "";
                }
            }
            this.txtHoTenBN.Focus();
        }

        private void clearControls1()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (((((base.Controls[i].GetType() == typeof(TextBox)) && (i != 4)) && ((i != 5) && (i != 0x11))) && (((i != 0x15) && (i != 0x25)) && ((base.Controls[i].Name != "txtHoTenBN") && (base.Controls[i].Name != "txtNhanVienTN")))) && ((base.Controls[i].Name != "txtTongTien") && (base.Controls[i].Name != "txtTongTienTrongNgay")))
                {
                    ((TextBox) base.Controls[i]).Text = "";
                }
                if (base.Controls[i].GetType() == typeof(LookupBox) && base.Controls[i].Name != "txtHoTenBN")
                {
                    ((LookupBox) base.Controls[i]).Text = "";
                }
            }
            this.txtMaVT.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void dtpNgayBanCu_ValueChanged(object sender, EventArgs e)
        {
            this.load_lswDS_BNLayKinhCu(this.dtpNgayBanCu.Value.ToString("MM/dd/yyyy"));
        }

        protected override void enableControls(bool val)
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (base.Controls[i].GetType() == typeof(TextBox))
                {
                    ((TextBox) base.Controls[i]).Enabled = val;
                }
                if (base.Controls[i].GetType() == typeof(LookupBox))
                {
                    ((LookupBox) base.Controls[i]).Enabled = val;
                }
                if (base.Controls[i].GetType() == typeof(ComboBox))
                {
                    ((ComboBox) base.Controls[i]).Enabled = val;
                }
            }

            if (ConfigurationSettings.AppSettings.Get("ThuTienThuoc_Kinh").ToString() == "true")
            {
                cboNhaVien.Enabled = false;
            }
        }

        private void frmXuatKinh_Load(object sender, EventArgs e)
        {
			
            this.enableControls(false);
            DataAccess access = new DataAccess();
            this.txtMaVT.Data = access.GetData("select MAVATTU, TENVATTU from viewTonKhoKinh");
            this.txtTenVT.Data = access.GetData("select MAVATTU, TENVATTU from viewTonKhoKinh");
            txtHoTenBN.Data = access.GetData("exec proc_LayDanhSachDoThiLuc '" + dtpNgayBanCu.Value.ToString("yyyy-MM-dd") + "'");
            this.load_allcboBoxInForm();
            this.lblNgayBan.Text = DateTime.Now.ToShortDateString();
            this.load_lswDS_BNLayKinhCu(DateTime.Now.ToString("MM/dd/yyyy"));
            if (ConfigurationSettings.AppSettings.Get("ThuTienThuoc_Kinh").ToString() == "true")
            {
                cboNhaVien.Enabled = false;
            }
            
        }

        protected override DataType[] getDataTypeDetail()
        {
            return new DataType[] { DataType.Int, DataType.VarChar, DataType.Int, DataType.Double, DataType.NVarChar, DataType.Double };
        }

        protected override string getDeleteQueryDetail()
        {
            return "Delete from KINH_CHITIETXUAT where MAPHIEUXUAT = '";
        }

        protected override string getDeleteQueryMain()
        {
            return "Delete from Kinh_PhieuXuat where MAPHIEUXUAT = '";
        }

        protected override string getDetailTable()
        {
            return "KINH_CHITIETXUAT";
        }

        protected override string getInsertQueryDetail()
        {
            return "insert into KINH_CHITIETXUAT(MAPHIEUXUAT, MAVATTU, SOLUONG, DONGIA, MAGONG, GIAM) values(:MAPHIEUXUAT, :MAVATTU, :SOLUONG, :DONGIA,:MAGONG,:GIAM)";
        }

        protected override string getInsertQueryMain()
        {
            if (ConfigurationSettings.AppSettings.Get("ThuTienThuoc_Kinh").ToString() == "true")
            {
                return "Insert into KINH_PHIEUXUAT(MALYDOXUATKINH,NGAYXUAT,GhiChu,MANVXUAT,TENKHACHHANG,MAYC,MANVTHU,IDDoThiLuc) values( 'XB ', '" + DateTime.Now.ToString("MM/dd/yyyy") + "', N'', '" + this.m_MaNVDN + "', N'" + this.txtHoTenBN.Text.Trim().ToUpper() + "', '','" + NhanVienThuNgan + "','" + txtMaBA.Text +"')";
            }
            else
            {
                return "Insert into KINH_PHIEUXUAT(MALYDOXUATKINH,NGAYXUAT,GhiChu,MANVXUAT,TENKHACHHANG,MAYC,MANVTHU,IDDoThiLuc) values( 'XB ', '" + DateTime.Now.ToString("MM/dd/yyyy") + "', N'', '" + this.m_MaNVDN + "', N'" + this.txtHoTenBN.Text.Trim().ToUpper() + "', '','" + arrNV[cboNhaVien.SelectedIndex].ToString()+ "','" + txtMaBA.Text + "')";
            }
        }

        protected override string getMainTable()
        {
            return "KINH_PHIEUXUAT";
        }

        protected override ArrayList getParameterNameDetail()
        {
            ArrayList list = new ArrayList();
            list.Add(":MAPHIEUXUAT");
            list.Add(":MAVATTU");
            list.Add(":SOLUONG");
            list.Add(":DONGIA");
            list.Add(":MAGONG");
            list.Add(":GIAM");

            return list;
        }

        protected override string getPrintQuery()
        {
            return "select * from viewInPhieuXuat where  MALYDOXUATKINH = 'XB' and dbo.viewInPhieuXuat.MaPhieuXuat = '";
        }

        protected override ReportDocument getReportDocument()
        {
            ReportDocument re = new ReportDocument();
            re.Load(ConfigurationSettings.AppSettings.Get("ReportPath") + "rptInPhieuXuatBan.rpt");
            return re;
            //return new rptInPhieuXuatBan();
        }

        protected override string getSelectQueryDetail()
        {
            return "";
        }

        protected override string getSelectQueryMain()
        {
            return "";
        }

        protected override string getSrcTable()
        {
            return "viewInPhieuXuat";
        }

        protected override string getStr_ReportDocument()
        {
            return (ConfigurationSettings.AppSettings.Get("ReportPath") + "rptInPhieuXuatBan.rpt");
        }

        protected override string getUpdateQueryDetail()
        {
            return "Update KINH_CHITIETXUAT set MAVATTU = :MAVATTU, SOLUONG = :SOLUONG, DONGIA = :DONGIA where MAPHIEUNHAP = :MAPHIEUNHAP ";
        }

        protected override string getUpdateQueryMain()
        {
            return "Update KINH_CHITIETXUAT set MALYDOXUATKINH = 'XB ', NGAYXUAT = "+ DateTime.Now.ToShortDateString()+ ", GHICHU = N'', MANVXUAT = '"+ this.m_MaNVDN+ "', TENKHACHHANG = N'"+ this.txtHoTenBN.Text.Trim()+ "', MAYC = '', IDDoThiLuc='" + txtMaBA.Text + "' where MAPHIEUXUAT = '"+ base.listItems.Items[0].SubItems[0].Text+ "'";
        }

        protected override string getViewInStock()
        {
            return "select soluong from viewTonKhoKinh where MAVATTU = ";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatKinh));
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lswDS_BNLayThuocCu = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpNgayBanCu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lstDS_BNLayThuocCu = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblNgayBan = new System.Windows.Forms.Label();
            this.txtNhanVienTN = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboNhaVien = new System.Windows.Forms.ComboBox();
            this.txtMaPX = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.Nh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtSLBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSLT = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTongTienTrongNgay = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtMaBA = new QLBV.Common.Controls.LookupBox();
            this.txtMaVT = new QLBV.Common.Controls.LookupBox();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTenVT = new QLBV.Common.Controls.LookupBox();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMAPX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMVT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTVT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMaGong = new System.Windows.Forms.TextBox();
            this.columnHeaderMG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderGG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.txtGiam = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoThe = new System.Windows.Forms.TextBox();
            this.txtHoTenBN = new QLBV.Common.Controls.LookupBox();
            this.ColIDDoThiLuc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColTenBenhNhan = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnReload = new System.Windows.Forms.Button();
            this.btnDonKinh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdInPhieu
            // 
            this.cmdInPhieu.BackColor = System.Drawing.SystemColors.Control;
            this.cmdInPhieu.Location = new System.Drawing.Point(632, 520);
            this.cmdInPhieu.UseVisualStyleBackColor = false;
            this.cmdInPhieu.Click += new System.EventHandler(this.cmdInPhieu_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(600, 480);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(712, 520);
            this.btnExit.TabIndex = 6;
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.Location = new System.Drawing.Point(208, 504);
            // 
            // listItems
            // 
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderMAPX,
            this.columnHeaderMVT,
            this.columnHeaderTVT,
            this.columnHeaderSL,
            this.columnHeaderGB,
            this.columnHeaderMG,
            this.columnHeaderGG,
            this.columnHeaderTT});
            this.listItems.Location = new System.Drawing.Point(211, 250);
            this.listItems.Size = new System.Drawing.Size(571, 198);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(376, 512);
            this.panCommand.VisibleChanged += new System.EventHandler(this.panCommand_VisibleChanged);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(208, 512);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(794, 32);
            this.label13.TabIndex = 11;
            this.label13.Text = "BÁN KÍNH";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 4);
            this.groupBox1.TabIndex = 241;
            this.groupBox1.TabStop = false;
            // 
            // lswDS_BNLayThuocCu
            // 
            this.lswDS_BNLayThuocCu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.TenBN});
            this.lswDS_BNLayThuocCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lswDS_BNLayThuocCu.FullRowSelect = true;
            this.lswDS_BNLayThuocCu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lswDS_BNLayThuocCu.Location = new System.Drawing.Point(0, 152);
            this.lswDS_BNLayThuocCu.Name = "lswDS_BNLayThuocCu";
            this.lswDS_BNLayThuocCu.Size = new System.Drawing.Size(200, 408);
            this.lswDS_BNLayThuocCu.TabIndex = 246;
            this.lswDS_BNLayThuocCu.UseCompatibleStateImageBehavior = false;
            this.lswDS_BNLayThuocCu.View = System.Windows.Forms.View.Details;
            this.lswDS_BNLayThuocCu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lswDS_BNLayThuocCu_KeyDown);
            this.lswDS_BNLayThuocCu.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lswDS_BNLayThuocCu_MouseUp);
            // 
            // STT
            // 
            this.STT.Text = "STT";
            this.STT.Width = 30;
            // 
            // TenBN
            // 
            this.TenBN.Text = "Tên Bệnh Nhân";
            this.TenBN.Width = 147;
            // 
            // dtpNgayBanCu
            // 
            this.dtpNgayBanCu.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBanCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBanCu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBanCu.Location = new System.Drawing.Point(8, 88);
            this.dtpNgayBanCu.Name = "dtpNgayBanCu";
            this.dtpNgayBanCu.Size = new System.Drawing.Size(184, 20);
            this.dtpNgayBanCu.TabIndex = 244;
            this.dtpNgayBanCu.ValueChanged += new System.EventHandler(this.dtpNgayBanCu_ValueChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(8, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 23);
            this.label3.TabIndex = 243;
            this.label3.Text = "Bệnh Nhân Lấy Kính Trong Ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstDS_BNLayThuocCu
            // 
            this.lstDS_BNLayThuocCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDS_BNLayThuocCu.Location = new System.Drawing.Point(0, 152);
            this.lstDS_BNLayThuocCu.Name = "lstDS_BNLayThuocCu";
            this.lstDS_BNLayThuocCu.Size = new System.Drawing.Size(200, 407);
            this.lstDS_BNLayThuocCu.TabIndex = 242;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(202, 88);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(2, 488);
            this.groupBox4.TabIndex = 247;
            this.groupBox4.TabStop = false;
            // 
            // lblNgayBan
            // 
            this.lblNgayBan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBan.ForeColor = System.Drawing.Color.Blue;
            this.lblNgayBan.Location = new System.Drawing.Point(320, 96);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new System.Drawing.Size(184, 23);
            this.lblNgayBan.TabIndex = 257;
            this.lblNgayBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNhanVienTN
            // 
            this.txtNhanVienTN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVienTN.Location = new System.Drawing.Point(600, 120);
            this.txtNhanVienTN.Name = "txtNhanVienTN";
            this.txtNhanVienTN.ReadOnly = true;
            this.txtNhanVienTN.Size = new System.Drawing.Size(184, 22);
            this.txtNhanVienTN.TabIndex = 256;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Location = new System.Drawing.Point(520, 120);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 23);
            this.label15.TabIndex = 255;
            this.label15.Text = "Thu Ngân";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(216, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 254;
            this.label10.Text = "NV Thu Ngân";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboNhaVien
            // 
            this.cboNhaVien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhaVien.Location = new System.Drawing.Point(320, 120);
            this.cboNhaVien.Name = "cboNhaVien";
            this.cboNhaVien.Size = new System.Drawing.Size(184, 24);
            this.cboNhaVien.TabIndex = 253;
            this.cboNhaVien.SelectedIndexChanged += new System.EventHandler(this.cboNhaVien_SelectedIndexChanged);
            // 
            // txtMaPX
            // 
            this.txtMaPX.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPX.Location = new System.Drawing.Point(384, 120);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(88, 22);
            this.txtMaPX.TabIndex = 252;
            this.txtMaPX.TabStop = false;
            this.txtMaPX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaPX.Visible = false;
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndex.Location = new System.Drawing.Point(384, 120);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(88, 22);
            this.txtIndex.TabIndex = 251;
            this.txtIndex.TabStop = false;
            this.txtIndex.Visible = false;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDung.ForeColor = System.Drawing.Color.Blue;
            this.lblNguoiDung.Location = new System.Drawing.Point(600, 96);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(184, 23);
            this.lblNguoiDung.TabIndex = 250;
            this.lblNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Nh
            // 
            this.Nh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nh.Location = new System.Drawing.Point(504, 96);
            this.Nh.Name = "Nh";
            this.Nh.Size = new System.Drawing.Size(88, 23);
            this.Nh.TabIndex = 249;
            this.Nh.Text = "NV Bán Kính";
            this.Nh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(208, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 248;
            this.label2.Text = "Ngày Bán";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            this.groupBox5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(208, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(576, 4);
            this.groupBox5.TabIndex = 258;
            this.groupBox5.TabStop = false;
            // 
            // txtSLBan
            // 
            this.txtSLBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSLBan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSLBan.Location = new System.Drawing.Point(712, 184);
            this.txtSLBan.Name = "txtSLBan";
            this.txtSLBan.Size = new System.Drawing.Size(72, 22);
            this.txtSLBan.TabIndex = 5;
            this.txtSLBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSLBan.Enter += new System.EventHandler(this.txtSLBan_Enter);
            this.txtSLBan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSLBan_KeyDown);
            this.txtSLBan.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSLBan_MouseDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(656, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 267;
            this.label1.Text = "SL Bán";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(208, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 23);
            this.label4.TabIndex = 265;
            this.label4.Text = "Số Lượng Tồn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSLT
            // 
            this.txtSLT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLT.Location = new System.Drawing.Point(320, 208);
            this.txtSLT.Name = "txtSLT";
            this.txtSLT.ReadOnly = true;
            this.txtSLT.Size = new System.Drawing.Size(55, 22);
            this.txtSLT.TabIndex = 270;
            this.txtSLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDVT
            // 
            this.txtDVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Location = new System.Drawing.Point(440, 210);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.ReadOnly = true;
            this.txtDVT.Size = new System.Drawing.Size(75, 22);
            this.txtDVT.TabIndex = 269;
            this.txtDVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDVT.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(376, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 268;
            this.label7.Text = "Mã Gọng";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(656, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 264;
            this.label11.Text = "Giá Bán";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBan.Location = new System.Drawing.Point(712, 208);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.ReadOnly = true;
            this.txtGiaBan.Size = new System.Drawing.Size(72, 22);
            this.txtGiaBan.TabIndex = 271;
            this.txtGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(208, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 23);
            this.label12.TabIndex = 263;
            this.label12.Text = "Họ Tên BN";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(216, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 266;
            this.label8.Text = "Vật Tư Kính";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(496, 480);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 273;
            this.label5.Text = "Tổng Tiền (VNĐ)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTongTienTrongNgay
            // 
            this.txtTongTienTrongNgay.BackColor = System.Drawing.SystemColors.Control;
            this.txtTongTienTrongNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienTrongNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTongTienTrongNgay.Location = new System.Drawing.Point(344, 480);
            this.txtTongTienTrongNgay.Name = "txtTongTienTrongNgay";
            this.txtTongTienTrongNgay.ReadOnly = true;
            this.txtTongTienTrongNgay.Size = new System.Drawing.Size(140, 20);
            this.txtTongTienTrongNgay.TabIndex = 275;
            this.txtTongTienTrongNgay.TabStop = false;
            this.txtTongTienTrongNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(202, 479);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(136, 23);
            this.label19.TabIndex = 274;
            this.label19.Text = "Tổng Tiền Trong Ngày";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaBA
            // 
            this.txtMaBA.Data = null;
            this.txtMaBA.KiemTraTonTai = false;
            this.txtMaBA.ListHeight = 0;
            this.txtMaBA.Location = new System.Drawing.Point(320, 160);
            this.txtMaBA.MultiLine = false;
            this.txtMaBA.Name = "txtMaBA";
            this.txtMaBA.OtherColumn = 1;
            this.txtMaBA.OtherValue = "";
            this.txtMaBA.ReadOnly = false;
            this.txtMaBA.RightAligh = false;
            this.txtMaBA.SearchColumn = 0;
            this.txtMaBA.SearchFromBegin = true;
            this.txtMaBA.ShowHeader = true;
            this.txtMaBA.Size = new System.Drawing.Size(120, 20);
            this.txtMaBA.TabIndex = 0;
            // 
            // txtMaVT
            // 
            this.txtMaVT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader8});
            this.txtMaVT.Data = null;
            this.txtMaVT.KiemTraTonTai = false;
            this.txtMaVT.ListHeight = 0;
            this.txtMaVT.Location = new System.Drawing.Point(320, 184);
            this.txtMaVT.MultiLine = false;
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.OtherColumn = 1;
            this.txtMaVT.OtherValue = "";
            this.txtMaVT.ReadOnly = false;
            this.txtMaVT.RightAligh = false;
            this.txtMaVT.SearchColumn = 0;
            this.txtMaVT.SearchFromBegin = false;
            this.txtMaVT.ShowHeader = true;
            this.txtMaVT.Size = new System.Drawing.Size(120, 20);
            this.txtMaVT.TabIndex = 2;
            this.txtMaVT.ItemSelected += new System.EventHandler(this.txtMaVT_ItemSelected);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã vật tư";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên vật tư";
            this.columnHeader8.Width = 350;
            // 
            // txtTenVT
            // 
            this.txtTenVT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.txtTenVT.Data = null;
            this.txtTenVT.KiemTraTonTai = false;
            this.txtTenVT.ListHeight = 0;
            this.txtTenVT.Location = new System.Drawing.Point(440, 184);
            this.txtTenVT.MultiLine = false;
            this.txtTenVT.Name = "txtTenVT";
            this.txtTenVT.OtherColumn = 0;
            this.txtTenVT.OtherValue = "";
            this.txtTenVT.ReadOnly = false;
            this.txtTenVT.RightAligh = false;
            this.txtTenVT.SearchColumn = 1;
            this.txtTenVT.SearchFromBegin = false;
            this.txtTenVT.ShowHeader = true;
            this.txtTenVT.Size = new System.Drawing.Size(216, 20);
            this.txtTenVT.TabIndex = 3;
            this.txtTenVT.ItemSelected += new System.EventHandler(this.txtTenVT_ItemSelected);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mã vật tư";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tên vật tư";
            this.columnHeader10.Width = 350;
            // 
            // columnHeaderMAPX
            // 
            this.columnHeaderMAPX.Text = "MaPX";
            this.columnHeaderMAPX.Width = 0;
            // 
            // columnHeaderMVT
            // 
            this.columnHeaderMVT.Text = "Mã vật tư";
            this.columnHeaderMVT.Width = 0;
            // 
            // columnHeaderTVT
            // 
            this.columnHeaderTVT.Text = "Tên vật tư";
            this.columnHeaderTVT.Width = 300;
            // 
            // columnHeaderGB
            // 
            this.columnHeaderGB.Text = "Giá bán";
            this.columnHeaderGB.Width = 80;
            // 
            // columnHeaderSL
            // 
            this.columnHeaderSL.Text = "Số lượng";
            this.columnHeaderSL.Width = 80;
            // 
            // columnHeaderTT
            // 
            this.columnHeaderTT.Text = "Thành tiền";
            this.columnHeaderTT.Width = 100;
            // 
            // txtMaGong
            // 
            this.txtMaGong.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaGong.Location = new System.Drawing.Point(440, 209);
            this.txtMaGong.Name = "txtMaGong";
            this.txtMaGong.Size = new System.Drawing.Size(75, 22);
            this.txtMaGong.TabIndex = 4;
            this.txtMaGong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeaderMG
            // 
            this.columnHeaderMG.Text = "Mã Gọng";
            this.columnHeaderMG.Width = 0;
            // 
            // columnHeaderGG
            // 
            this.columnHeaderGG.Text = "Giảm %";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(521, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 276;
            this.label6.Text = "Giảm %";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGiam
            // 
            this.txtGiam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtGiam.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGiam.Location = new System.Drawing.Point(584, 208);
            this.txtGiam.Name = "txtGiam";
            this.txtGiam.Size = new System.Drawing.Size(72, 22);
            this.txtGiam.TabIndex = 277;
            this.txtGiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(217, 451);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 23);
            this.label9.TabIndex = 278;
            this.label9.Text = "Nhập số thẻ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoThe
            // 
            this.txtSoThe.Location = new System.Drawing.Point(344, 452);
            this.txtSoThe.Name = "txtSoThe";
            this.txtSoThe.Size = new System.Drawing.Size(140, 22);
            this.txtSoThe.TabIndex = 279;
            this.txtSoThe.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSoThe_KeyUp);
            this.txtSoThe.Leave += new System.EventHandler(this.txtSoThe_Leave);
            // 
            // txtHoTenBN
            // 
            this.txtHoTenBN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColIDDoThiLuc,
            this.ColTenBenhNhan});
            this.txtHoTenBN.Data = null;
            this.txtHoTenBN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTenBN.KiemTraTonTai = false;
            this.txtHoTenBN.ListHeight = 0;
            this.txtHoTenBN.Location = new System.Drawing.Point(443, 159);
            this.txtHoTenBN.MultiLine = false;
            this.txtHoTenBN.Name = "txtHoTenBN";
            this.txtHoTenBN.OtherColumn = 0;
            this.txtHoTenBN.OtherValue = "";
            this.txtHoTenBN.ReadOnly = false;
            this.txtHoTenBN.RightAligh = false;
            this.txtHoTenBN.SearchColumn = 1;
            this.txtHoTenBN.SearchFromBegin = true;
            this.txtHoTenBN.ShowHeader = false;
            this.txtHoTenBN.Size = new System.Drawing.Size(269, 22);
            this.txtHoTenBN.TabIndex = 280;
            this.txtHoTenBN.ItemSelected += new System.EventHandler(this.txtHoTenBN_ItemSelected);
            // 
            // ColIDDoThiLuc
            // 
            this.ColIDDoThiLuc.Width = 0;
            // 
            // ColTenBenhNhan
            // 
            this.ColTenBenhNhan.Width = 200;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(716, 158);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(27, 23);
            this.btnReload.TabIndex = 281;
            this.btnReload.Text = "R";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnDonKinh
            // 
            this.btnDonKinh.Location = new System.Drawing.Point(746, 158);
            this.btnDonKinh.Name = "btnDonKinh";
            this.btnDonKinh.Size = new System.Drawing.Size(37, 23);
            this.btnDonKinh.TabIndex = 282;
            this.btnDonKinh.Text = "ĐK";
            this.btnDonKinh.UseVisualStyleBackColor = true;
            this.btnDonKinh.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmXuatKinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(794, 570);
            this.Controls.Add(this.btnDonKinh);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.txtHoTenBN);
            this.Controls.Add(this.txtSoThe);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGiam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaGong);
            this.Controls.Add(this.txtTenVT);
            this.Controls.Add(this.txtMaVT);
            this.Controls.Add(this.txtMaBA);
            this.Controls.Add(this.txtTongTienTrongNgay);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSLBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSLT);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lblNgayBan);
            this.Controls.Add(this.txtNhanVienTN);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboNhaVien);
            this.Controls.Add(this.txtMaPX);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.Nh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lswDS_BNLayThuocCu);
            this.Controls.Add(this.dtpNgayBanCu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstDS_BNLayThuocCu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXuatKinh";
            this.Text = "Bán Kính cho Khách Hàng";
            this.Load += new System.EventHandler(this.frmXuatKinh_Load);
            this.Controls.SetChildIndex(this.cmdInPhieu, 0);
            this.Controls.SetChildIndex(this.txtTongTien, 0);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lstDS_BNLayThuocCu, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpNgayBanCu, 0);
            this.Controls.SetChildIndex(this.lswDS_BNLayThuocCu, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.Nh, 0);
            this.Controls.SetChildIndex(this.lblNguoiDung, 0);
            this.Controls.SetChildIndex(this.txtIndex, 0);
            this.Controls.SetChildIndex(this.txtMaPX, 0);
            this.Controls.SetChildIndex(this.cboNhaVien, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtNhanVienTN, 0);
            this.Controls.SetChildIndex(this.lblNgayBan, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtGiaBan, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDVT, 0);
            this.Controls.SetChildIndex(this.txtSLT, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtSLBan, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtTongTienTrongNgay, 0);
            this.Controls.SetChildIndex(this.txtMaBA, 0);
            this.Controls.SetChildIndex(this.txtMaVT, 0);
            this.Controls.SetChildIndex(this.txtTenVT, 0);
            this.Controls.SetChildIndex(this.txtMaGong, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtGiam, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtSoThe, 0);
            this.Controls.SetChildIndex(this.txtHoTenBN, 0);
            this.Controls.SetChildIndex(this.btnReload, 0);
            this.Controls.SetChildIndex(this.btnDonKinh, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        protected override void listItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
				if (base.NotDelete && base.panCommand.Visible)
				{
					MessageBox.Show("Bạn không được xóa!");
					return;
				}
                if ((base.listItems.SelectedItems[0].Index >= 0) && (MessageBox.Show(this, "Bạn c\x00f3 chắc muốn x\x00f3a d\x00f2ng dữ liệu n\x00e0y kh\x00f4ng?", "Th\x00f4ng b\x00e1o", MessageBoxButtons.YesNo) != DialogResult.No))
                {
                    if (Convert.ToInt32(base.listItems.SelectedItems[0].SubItems[0].Text) == 0)
                    {
                        base.listItems.SelectedItems[0].Remove();
                        this.clearControls1();
                    }
                    else
                    {
                        DataAccess access = new DataAccess();
                        try
                        {
                            access.BeginTransaction();
                            access.CommandText = this.getDeleteQueryDetail() + base.listItems.SelectedItems[0].SubItems[0].Text + "' and MAVATTU = '" + base.listItems.SelectedItems[0].SubItems[1].Text + "'";
                            access.ExecuteNonQuery();
                            this.enableControls(false);
                            this.clearControls1();
                        }
                        catch (Exception exception)
                        {
                            access.Rollback();
                            MessageBox.Show("C\x00f3 lỗi khi x\x00f3a. Th\x00f4ng tin lỗi như sau:\n" + exception.Message, "Th\x00f4ng B\x00e1o");
                        }
                        finally
                        {
                            access.EndTransaction();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn một d\x00f2ng n\x00e0o cần x\x00f3a", "Th\x00f4ng B\x00e1o");
            }
        }

        private void load_allcboBoxInForm()
        {
            string sql = "select MANV, TENNHANVIEN from NhanVien where MaphongBan = " + 5;
            CommonClass.load_cboBox(this.cboNhaVien, out this.arrNV, sql);
        }

        private void load_ChiTietPXKCu(int iMaPXK)
        {
            try
            {
                base.listItems.Items.Clear();
                DataAccess access = new DataAccess();
                foreach (DataRow row in access.GetData("SELECT [MAPHIEUXUAT],[MAVATTU],[TENVATTU],[DONGIA],[SOLUONG],[MAGONG],[GIAM] from view_XemPXCu where dbo.view_XemPXCu.MAPHIEUXUAT = " + iMaPXK).Rows)
                {
                    double num = Convert.ToDouble(row["SOLUONG"].ToString()) * Convert.ToDouble(row["DONGIA"].ToString());
                    num = num - (num * Convert.ToDouble(row["Giam"].ToString() == "" ? "0" : row["Giam"].ToString())/100);

                    ListViewItem item = new ListViewItem(new string[] { row["MAPHIEUXUAT"].ToString(), row["MAVATTU"].ToString(), row["TENVATTU"].ToString(), row["SOLUONG"].ToString(), row["DONGIA"].ToString(), row["MAGONG"].ToString(),row["Giam"].ToString(), num.ToString() });
                    base.listItems.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        public void load_lswDS_BNLayKinhCu(string ngay)
        {
            this.lswDS_BNLayThuocCu.Items.Clear();
            this.arrMaPXK = new ArrayList();
            this.arrMaPXK.Clear();
            string query = "select MAPHIEUXUAT, TENKHACHHANG from Kinh_PhieuXuat where NGAYXUAT = '" + ngay + "'";
            DataTable data = new DataAccess().GetData(query);
            int num = 0;
            foreach (DataRow row in data.Rows)
            {
                num++;
                this.arrMaPXK.Add(row[0].ToString());
                ListViewItem item = new ListViewItem(new string[] { num.ToString(), row[1].ToString() });
                this.lswDS_BNLayThuocCu.Items.Add(item);
            }
        }

        private void load_PhieuXuatCu(int iMaPXK)
        {
            try
            {
                DataAccess access = new DataAccess();
                foreach (DataRow row in access.GetData("SELECT TENKHACHHANG,TenNhanVien,IDDoThiLuc from KINH_PHIEUXUAT inner join NhanVien on KINH_PHIEUXUAT.MANVTHU = NhanVien.MaNV where dbo.KINH_PHIEUXUAT.MAPHIEUXUAT = " + iMaPXK).Rows)
                {
                    this.txtHoTenBN.Text = row[0].ToString();
                    cboNhaVien.Text = row["TenNhanVien"].ToString();
                    txtNhanVienTN.Text = row["TenNhanVien"].ToString();
                    txtMaBA.Text = row["IDDoThiLuc"].ToString();
                }
                foreach (DataRow row in access.GetData("exec Proc_LaySoThe " +iMaPXK).Rows)
                {
                    txtSoThe.Text = row["SoThe"].ToString();
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void load_ThongtinVatTuChiTiet()
        {
            try
            {
                DataTable data = new DataAccess().GetData("SELECT *  from view_ThongtinVatTuChiTiet where dbo.view_ThongtinVatTuChiTiet.MAVATTU = '" + this.txtMaVT.Text.Trim() + "'");
                if (data.Rows.Count <= 0)
                {
                    MessageBox.Show("Vật tư được chọn, hiện tại kh\x00f4ng c\x00f2n tồn trong kho nữa", "Th\x00f4ng B\x00e1o");
                    this.clearControls1();
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        this.txtGiaBan.Text = row[0].ToString();
                        this.txtDVT.Text = row[3].ToString();
                        this.txtSLT.Text = row[1].ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void lswDS_BNLayThuocCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return && this.lswDS_BNLayThuocCu.SelectedItems.Count>0)
            {
                int iMaPXK = Convert.ToInt32(this.arrMaPXK[this.lswDS_BNLayThuocCu.SelectedItems[0].Index].ToString());
                this.clearControls();
                this.load_PhieuXuatCu(iMaPXK);
                this.load_ChiTietPXKCu(iMaPXK);                
                this.tongtien = 0.0;
                for (int i = 0; i < base.listItems.Items.Count; i++)
                {
                    this.tongtien += Convert.ToDouble(base.listItems.Items[i].SubItems[7].Text);
                }
                base.txtTongTien.Text = this.tongtien.ToString("#,##0");
                base.panCommand.Visible = true;
                base.panSaveCancel.Visible = false;
                this.enableControls(false);
                base.listItems.Enabled = true;
            }
        }

        private void lswDS_BNLayThuocCu_MouseUp(object sender, MouseEventArgs e)
        {
            if (lswDS_BNLayThuocCu.SelectedItems.Count > 0)
            {
                int iMaPXK = Convert.ToInt32(this.arrMaPXK[this.lswDS_BNLayThuocCu.SelectedItems[0].Index].ToString());
                this.clearControls();
                this.load_PhieuXuatCu(iMaPXK);
                this.load_ChiTietPXKCu(iMaPXK);                
                this.tongtien = 0.0;
                for (int i = 0; i < base.listItems.Items.Count; i++)
                {
                    this.tongtien += Convert.ToDouble(base.listItems.Items[i].SubItems[7].Text);
                }
                base.txtTongTien.Text = this.tongtien.ToString("#,##0");
                base.panCommand.Visible = true;
                base.panSaveCancel.Visible = false;
                this.enableControls(false);
                base.listItems.Enabled = true;
            }
        }

        private void panCommand_VisibleChanged(object sender, EventArgs e)
        {
            if (base.panCommand.Visible)
            {
                this.load_lswDS_BNLayKinhCu(this.dtpNgayBanCu.Value.ToString("MM/dd/yyyy"));
            }
        }

        protected override void selectRecord()
        {
            if (base.listItems.SelectedIndices.Count >= 1)
            {
                ListViewItem item = base.listItems.SelectedItems[0];
                this.txtMaVT.Text = item.SubItems[1].Text;
                this.txtTenVT.Text = item.SubItems[2].Text;
                this.txtGiaBan.Text = item.SubItems[4].Text;
                this.txtSLBan.Text = item.SubItems[3].Text;                
                this.txtMaGong.Text = item.SubItems[5].Text;                
                this.txtGiam.Text = item.SubItems[6].Text;
                this.txtSLBan.Focus();
                this.txtIndex.Text = base.listItems.SelectedItems[0].Index.ToString();
            }
        }
        private void txtMaVT_ItemSelected(object sender, EventArgs e)
        {
            this.txtMaVT.Text = this.txtMaVT.SelectedItem.SubItems[0].Text;
            this.txtTenVT.Text = this.txtMaVT.SelectedItem.SubItems[1].Text;
            base.ActiveControl = this.txtMaGong;
        }

        private void txtSLBan_Enter(object sender, EventArgs e)
        {
            this.load_ThongtinVatTuChiTiet();
        }

        private void txtSLBan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Return)
            {
                return;
            }
            if (Convert.ToInt32(this.txtSLBan.Text) == 0)
            {
                MessageBox.Show("Số Lượng B\x00e1n Kh\x00f4ng bằng 0", "Th\x00f4ng B\x00e1o");
                this.txtSLBan.Text = "";
                this.txtSLBan.Focus();
            }
            if (Convert.ToInt32(this.txtSLBan.Text) > Convert.ToInt32(this.txtSLT.Text))
            {
                MessageBox.Show("Số lượng tồn th\x00ec kh\x00f4ng đủ đ\x00e1p ứng cho việc xuất", "Th\x00f4ng B\x00e1o");
                this.txtSLBan.Text = "";
                this.txtSLBan.Focus();
                return;
            }
            if ((this.txtTenVT.Text == "") || (this.txtSLBan.Text == ""))
            {
                MessageBox.Show("Y\x00eau cầu điền đầy đủ th\x00f4ng tin cho Chi Tiết Phiếu Nhập", "Th\x00f4ng B\x00e1o");
                if (this.txtTenVT.Text == "")
                {
                    base.ActiveControl = this.txtTenVT;
                }
                else
                {
                    if (!(this.txtSLBan.Text == ""))
                    {
                        goto Label_033A;
                    }
                    base.ActiveControl = this.txtSLBan;
                }
                return;
            }
            if (!base.isModify)
            {
                double num = Convert.ToDouble(this.txtSLBan.Text) * Convert.ToDouble(this.txtGiaBan.Text);
                double Giam = Convert.ToDouble(txtGiam.Text.Trim() == "" ? "0" : txtGiam.Text.Trim()) * num / 100;
                num = num - Giam;

                ListViewItem item = new ListViewItem(new string[] { "0", this.txtMaVT.Text.Trim(), this.txtTenVT.Text.Trim(), this.txtSLBan.Text.Trim(), this.txtGiaBan.Text.Trim(), this.txtMaGong.Text, txtGiam.Text.Trim() == "" ? "0" : txtGiam.Text.Trim(), num.ToString() });
                base.listItems.Items.Add(item);
            }
            else if (base.isModify)
            {
                int num2 = Convert.ToInt32(this.txtIndex.Text);
                base.listItems.Items[num2].SubItems[1].Text = this.txtMaVT.Text;
                base.listItems.Items[num2].SubItems[2].Text = this.txtTenVT.Text;
                base.listItems.Items[num2].SubItems[4].Text = this.txtGiaBan.Text;
                base.listItems.Items[num2].SubItems[3].Text = this.txtSLBan.Text;
                base.listItems.Items[num2].SubItems[5].Text = this.txtMaGong.Text;
 
                double num = Convert.ToDouble(this.txtSLBan.Text) * Convert.ToDouble(this.txtGiaBan.Text);
                double Giam = Convert.ToDouble(txtGiam.Text.Trim() == "" ? "0" : txtGiam.Text.Trim()) * num / 100;
                num = num - Giam;

                base.listItems.Items[num2].SubItems[6].Text = (txtGiam.Text.Trim() == "" ? "0" : txtGiam.Text.Trim());
                base.listItems.Items[num2].SubItems[7].Text = num.ToString();

            }
        Label_033A:
            this.clearControls1();
            double num4 = 0.0;
            for (int i = 0; i < base.listItems.Items.Count; i++)
            {
                num4 += Convert.ToDouble(base.listItems.Items[i].SubItems[7].Text);
            }
            base.txtTongTien.Text = num4.ToString("#,##0");
        }

        private void txtSLBan_MouseDown(object sender, MouseEventArgs e)
        {
            this.load_ThongtinVatTuChiTiet();
        }

        private void txtTenVT_ItemSelected(object sender, EventArgs e)
        {
            this.txtMaVT.Text = this.txtTenVT.SelectedItem.SubItems[0].Text;
            this.txtTenVT.Text = this.txtTenVT.SelectedItem.SubItems[1].Text;
            base.ActiveControl = this.txtMaGong;
        }

        int NhanVienThuNgan = 0;
        protected override bool validateData()
        {
            if (ConfigurationSettings.AppSettings.Get("ThuTienThuoc_Kinh").ToString() == "true")
            {
                NhanVienThuNgan = 0;
                DataAccess dba = new DataAccess(ConfigurationSettings.AppSettings.Get("ConnectThuoc"));
                foreach (DataRow row in dba.GetData("Select MaNV from NhanVienThuTienThuoc").Rows)
                {
                    if (row["MaNV"].ToString() != "" && row["MaNV"].ToString() != "0")
                    {
                        NhanVienThuNgan = int.Parse(row["MaNV"].ToString());
                        return true;
                    }                    
                }
                MessageBox.Show("Vui long thong bao thu ngan chua chon thu tien!");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtSoThe_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (KiemTraTheTonTai())
                {
                    ThemGiamGia();
                }
            }
        }

        bool TheTonTai = true;
        private void txtSoThe_Leave(object sender, EventArgs e)
        {
            if (txtSoThe.Text.Trim() == "")
            {
                TheTonTai = false;
            }
            else
            {
                if (KiemTraTheTonTai())
                {
                    ThemGiamGia();
                }
                else
                {
                    txtSoThe.Focus();
                }
            }
        }

        private void ThemGiamGia()
        {
            tongtien = 0;
            foreach (ListViewItem item in listItems.Items)
            {
                item.SubItems[6].Text = "10";
                item.SubItems[7].Text = ""+ (double.Parse(item.SubItems[3].Text) * double.Parse(item.SubItems[4].Text)
                            - Math.Round(double.Parse(item.SubItems[3].Text) * double.Parse(item.SubItems[4].Text) * double.Parse(item.SubItems[6].Text) / 100));
                tongtien += int.Parse(item.SubItems[7].Text);
            }
            txtTongTien.Text = this.tongtien.ToString("###,#");
        }

        private bool KiemTraTheTonTai()
        {            
            DataAccess dba = new DataAccess(ConfigurationSettings.AppSettings.Get("ConnectThuoc"));
            bool result = dba.GetData("select * from TheSuDung Where SoThe='" + txtSoThe.Text.Trim() + "'").Rows.Count > 0;
            if (!result)
            {
                MessageBox.Show("Số thẻ " + txtSoThe.Text + " không có, vui lòng xóa hoặc điền lại số thẻ khác!");
            }
            TheTonTai = result;
            return result;
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            base.btnSave_Click(sender, e);
            LuuTheSuDung();
        }

        private void LuuTheSuDung()
        {
            DataAccess dba= new DataAccess();
            dba.CommandText = "Exec proc_SaveChiTietTheSuDung " + Convert.ToInt32(base.listItems.Items[0].SubItems[0].Text)+",'" + txtSoThe.Text.Trim() +"'";
            dba.ExecuteNonQuery();
        }

        private void txtHoTenBN_ItemSelected(object sender, EventArgs e)
        {
            txtMaBA.Text = txtHoTenBN.OtherValue;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            DataAccess access = new DataAccess();
            txtHoTenBN.Data = access.GetData("exec proc_LayDanhSachDoThiLuc '" + dtpNgayBanCu.Value.ToString("yyyy-MM-dd") + "'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMaBA.Text.Trim() != "")
            {
                try
                {
                    DataAccess dba = new DataAccess();
                    string sql = "exec procLayToaKinh '" + txtMaBA.Text.Substring(0, 11) + "'";
                    if (dba.GetData(sql).Rows.Count > 0)
                    {
                        //dba.CommandText = "select * from viewDTL where MaBenhAn='" + txtMaBA.Text.Substring(0, 11) + "'";
                        DataSet ds = new DataSet();
                        dba.Fill(ds, "viewDTL");
                        string path = ds.Tables["viewDTL"].Rows[0]["CHUKY"].ToString().Trim();
                        if (File.Exists(path))
                        {
                            FileStream fs = new FileStream(ds.Tables["viewDTL"].Rows[0]["CHUKY"].ToString().Trim(), FileMode.Open, FileAccess.Read);
                            byte[] buff = new byte[fs.Length];
                            fs.Read(buff, 0, (int)fs.Length);
                            ds.Tables[0].Columns.Add("HCHUKY", buff.GetType());
                            ds.Tables[0].Rows[0]["HCHUKY"] = buff;
                        }
                        else
                        {
                            ds.Tables[0].Columns.Add("HCHUKY");
                            ds.Tables[0].Rows[0]["HCHUKY"] = "";
                        }
                        ReportViewer rpt = new ReportViewer(ConfigurationSettings.AppSettings.Get("ReportPath") + @"rptKQDTL.rpt", ds);
                        rpt.WindowState = FormWindowState.Maximized;
                        rpt.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bệnh nh\x00e2n chưa thực hiện có toa kính");

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRemove_Click_1(object sender, EventArgs e)
        {

        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {

        }
    }
}

