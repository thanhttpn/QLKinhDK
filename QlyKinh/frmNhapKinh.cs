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
    using QLBV.Common.Controls;   

    public class frmNhapKinh : frmUpdateForm_Multi
    {
        private ArrayList arrMaLiDo;
        private ArrayList arrNCC;
        private ComboBox cboLidoNhap;
        private ComboBox cboNhaCC;
        private Button cmdCapNhatDMThuoc;
        private Button cmdCapNhatNCC;
        private Button cmdThemvaoPNK;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private IContainer components;
        private DateTimePicker dtpNgayNhap;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label1;
        private Label label13;
        private Label label18;
        private Label label2;
        private Label label20;
        private Label label28;
        private Label label3;
        private Label label36;
        private Label label5;
        private Label lblMaNCC;
        private Label lblMaPNK;
        private int m_MaNVDN;
        private int m_MaNVNT;
        private string m_MaPXNTra;
        private string m_TenBNTra;
        private ToolBarButton tlbLamPhieuBanMoi;
        private ToolBarButton tlbXemLaiHDCu;
        private double tongtien;
        private ToolBar toolBar1;
        private ToolBarButton toolBarButton1;
        private TextBox txtGhiChu;
        private TextBox txtGiaNhap;
        private TextBox txtIndex;
        private TextBox txtMaVTKinh;
        private TextBox txtSoLuong;
        private LookupBox txtTenVTKinh;

        public frmNhapKinh()
        {
            this.components = null;
            this.m_MaNVDN = 0;
            this.m_MaNVNT = 0;
            this.m_MaPXNTra = "";
            this.m_TenBNTra = "";
            this.InitializeComponent();
        }

        public frmNhapKinh(int maNhanVienDN)
        {
            this.components = null;
            this.m_MaNVDN = 0;
            this.m_MaNVNT = 0;
            this.m_MaPXNTra = "";
            this.m_TenBNTra = "";
            this.InitializeComponent();
            this.m_MaNVDN = maNhanVienDN;
        }

        public frmNhapKinh(int maNhanVienDN, string TenBNTra, string MaPXNTra, int maNhanVienNT)
        {
            this.components = null;
            this.m_MaNVDN = 0;
            this.m_MaNVNT = 0;
            this.m_MaPXNTra = "";
            this.m_TenBNTra = "";
            this.InitializeComponent();
            this.m_MaNVDN = maNhanVienDN;
            this.m_TenBNTra = TenBNTra;
            this.m_MaPXNTra = MaPXNTra;
            this.m_MaNVNT = maNhanVienNT;
        }

        protected override int checkFrom()
        {
            return 0;
        }

        protected override void clearControls()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if ((base.Controls[i].GetType() == typeof(TextBox)) && (i != 20))
                {
                    ((TextBox) base.Controls[i]).Text = "";
                }
                if (base.Controls[i].GetType() == typeof(LookupBox))
                {
                    ((LookupBox) base.Controls[i]).Text = "";
                }
            }
            this.txtTenVTKinh.Focus();
        }

        private void cmdCapNhatDMThuoc_Click(object sender, EventArgs e)
        {
            new CapNhatVatTu().ShowDialog();
            this.txtTenVTKinh.Data = new DataAccess().GetData("select MAVATTU, TENVATTU from KINH_VATTUKINH where DAXOA = 0");
        }

        private void cmdCapNhatNCC_Click(object sender, EventArgs e)
        {
            new NhaCungCap().ShowDialog();
            string sql = "select MANCC, TENNCC from KINH_NHACUNGCAP order by TENNCC";
            CommonClass.load_cboBox(this.cboNhaCC, out this.arrNCC, sql);
        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
        }

        private void cmdThemvaoPNK_Click(object sender, EventArgs e)
        {
            if (((this.txtTenVTKinh.Text == "") || (this.txtSoLuong.Text == "")) || (this.txtGiaNhap.Text == ""))
            {
                MessageBox.Show("Y\x00eau cầu điền đầy đủ th\x00f4ng tin cho Chi Tiết Phiếu Nhập", "Th\x00f4ng B\x00e1o");
                if (this.txtTenVTKinh.Text == "")
                {
                    base.ActiveControl = this.txtTenVTKinh;
                }
                else if (this.txtSoLuong.Text == "")
                {
                    base.ActiveControl = this.txtSoLuong;
                }
                else
                {
                    if (!(this.txtGiaNhap.Text == ""))
                    {
                        goto Label_03E9;
                    }
                    base.ActiveControl = this.txtGiaNhap;
                }
                return;
            }
            if (!base.isModify)
            {
                if (this.txtIndex.Text.Trim() != "")
                {
                    int num = Convert.ToInt32(this.txtIndex.Text);
                    base.listItems.Items[num].SubItems[1].Text = this.txtMaVTKinh.Text;
                    base.listItems.Items[num].SubItems[2].Text = this.txtTenVTKinh.Text;
                    base.listItems.Items[num].SubItems[3].Text = this.txtSoLuong.Text;
                    base.listItems.Items[num].SubItems[4].Text = this.txtGiaNhap.Text;
                    base.listItems.Items[num].SubItems[5].Text = (Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaNhap.Text)).ToString();
                    this.txtIndex.Text = "";
                }
                else
                {
                    double num3 = Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaNhap.Text);
                    ListViewItem item = new ListViewItem(new string[] { "0", this.txtMaVTKinh.Text.Trim(), this.txtTenVTKinh.Text.Trim(), this.txtSoLuong.Text.Trim(), this.txtGiaNhap.Text.Trim(), num3.ToString() });
                    base.listItems.Items.Add(item);
                }
            }
            else if (base.isModify)
            {
                int num4 = Convert.ToInt32(this.txtIndex.Text);
                base.listItems.Items[num4].SubItems[1].Text = this.txtMaVTKinh.Text;
                base.listItems.Items[num4].SubItems[2].Text = this.txtTenVTKinh.Text;
                base.listItems.Items[num4].SubItems[3].Text = this.txtSoLuong.Text;
                base.listItems.Items[num4].SubItems[4].Text = this.txtGiaNhap.Text;
                base.listItems.Items[num4].SubItems[5].Text = (Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaNhap.Text)).ToString();
            }
        Label_03E9:
            this.clearControls();
            this.tongtien = 0.0;
            for (int i = 0; i < base.listItems.Items.Count; i++)
            {
                this.tongtien += Convert.ToDouble(base.listItems.Items[i].SubItems[5].Text);
            }
            base.txtTongTien.Text = this.tongtien.ToString("#,##0");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
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
        }

        private void frmNhapKinh_Load(object sender, EventArgs e)
        {
            frmUpdateForm_Multi multi = new frmUpdateForm_Multi();
            multi.m_checkInStock = 0;
            this.enableControls(false);
            this.txtTenVTKinh.Data = new DataAccess().GetData("select MAVATTU, TENVATTU from KINH_VATTUKINH where DAXOA = 0");
            this.load_allcboBoxInForm();
        }

        protected override DataType[] getDataTypeDetail()
        {
            return new DataType[] { DataType.Int, DataType.VarChar, DataType.Int, DataType.Double };
        }

        protected override string getDeleteQueryDetail()
        {
            return "Delete from KINH_CHITIETNHAP where MAPHIEUNHAP = '";
        }

        protected override string getDeleteQueryMain()
        {
            return "Delete from Kinh_PhieuNhap where MAPHIEUNHAP = '";
        }

        protected override string getDetailTable()
        {
            return "KINH_CHITIETNHAP";
        }

        protected override string getInsertQueryDetail()
        {
            return "insert into KINH_CHITIETNHAP values(:MAPHIEUNHAP, :MAVATTU, :SOLUONG, :DONGIA)";
        }

        protected override string getInsertQueryMain()
        {
            return string.Concat(new object[] { 
                "Insert into KINH_PHIEUNHAP values( '", this.arrMaLiDo[this.cboLidoNhap.SelectedIndex].ToString(), "', '", this.dtpNgayNhap.Value.ToString("MM/dd/yyyy"), "', N'", this.txtGhiChu.Text.Trim(), "', '", this.m_MaNVDN, "', '", this.arrNCC[this.cboNhaCC.SelectedIndex], "', N'", this.m_TenBNTra, "', '", this.m_MaPXNTra, "', '", this.m_MaPXNTra, 
                "')"
             });
        }

        protected override string getMainTable()
        {
            return "KINH_PHIEUNHAP";
        }

        protected override ArrayList getParameterNameDetail()
        {
            ArrayList list = new ArrayList();
            list.Add(":MAPHIEUNHAP");
            list.Add(":MAVATTU");
            list.Add(":SOLUONG");
            list.Add(":DONGIA");
            return list;
        }

        protected override string getPrintQuery()
        {
            return "select * from viewInPhieuNhap where dbo.viewInPhieuNhap.MaPhieuNhap = '";
        }

        protected override ReportDocument getReportDocument()
        {
            ReportDocument re = new ReportDocument();
            re.Load(ConfigurationSettings.AppSettings.Get("ReportPath") + "rptInPhieuNhap.rpt");
            return re;
            //return new rptInPhieuNhap();
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
            return "viewInPhieuNhap";
        }

        protected override string getStr_ReportDocument()
        {
            return (Environment.CurrentDirectory + @"\Reports\rptInPhieuNhap.rpt");
        }

        protected override string getUpdateQueryDetail()
        {
            return "Update KINH_CHITIETNHAP set MAVATTU = :MAVATTU, SOLUONG = :SOLUONG, DONGIA = :DONGIA where MAPHIEUNHAP = :MAPHIEUNHAP ";
        }

        protected override string getUpdateQueryMain()
        {
            return string.Concat(new object[] { 
                "Update KINH_PHIEUNHAP set MALYDONHAPKINH = '", this.arrMaLiDo[this.cboLidoNhap.SelectedIndex].ToString(), "', NGAYNHAP = ", this.dtpNgayNhap.Value.ToShortDateString(), ", GHICHU = N'", this.txtGhiChu.Text.Trim(), "', MANVNHAP = '", this.m_MaNVDN, "', MANCC = '", this.arrNCC[this.cboNhaCC.SelectedIndex], "', TENBN = N'", this.m_TenBNTra, "', MAPXNHAPTRA = '", this.m_MaPXNTra, "' where MAPHIEUNHAP = '", base.listItems.Items[0].SubItems[0].Text, 
                "'"
             });
        }

        protected override string getViewInStock()
        {
            return "select soluong from viewTonKhoKinh where MAVATTU = ";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhapKinh));
            this.label13 = new System.Windows.Forms.Label();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tlbXemLaiHDCu = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tlbLamPhieuBanMoi = new System.Windows.Forms.ToolBarButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmdCapNhatNCC = new System.Windows.Forms.Button();
            this.lblMaPNK = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.cboNhaCC = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmdCapNhatDMThuoc = new System.Windows.Forms.Button();
            this.cmdThemvaoPNK = new System.Windows.Forms.Button();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaVTKinh = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.cboLidoNhap = new System.Windows.Forms.ComboBox();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTenVTKinh = new QLBV.Common.Controls.LookupBox();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpNgayNhap = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // cmdInPhieu
            // 
            this.cmdInPhieu.BackColor = System.Drawing.SystemColors.Control;
            this.cmdInPhieu.Location = new System.Drawing.Point(504, 512);
            this.cmdInPhieu.UseVisualStyleBackColor = false;
            this.cmdInPhieu.Click += new System.EventHandler(this.cmdInPhieu_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(520, 464);
            this.txtTongTien.Size = new System.Drawing.Size(192, 22);
            this.txtTongTien.TabIndex = 100;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(632, 512);
            this.btnExit.TabIndex = 100;
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.Location = new System.Drawing.Point(-16, 496);
            this.grpBtnLine.Size = new System.Drawing.Size(768, 4);
            // 
            // listItems
            // 
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader7});
            this.listItems.Location = new System.Drawing.Point(24, 248);
            this.listItems.Size = new System.Drawing.Size(688, 208);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(232, 504);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(48, 504);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(722, 32);
            this.label13.TabIndex = 242;
            this.label13.Text = "NHẬP KÍNH";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tlbXemLaiHDCu,
            this.toolBarButton1,
            this.tlbLamPhieuBanMoi});
            this.toolBar1.Divider = false;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBar1.Location = new System.Drawing.Point(0, 32);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(722, 43);
            this.toolBar1.TabIndex = 243;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // tlbXemLaiHDCu
            // 
            this.tlbXemLaiHDCu.Name = "tlbXemLaiHDCu";
            this.tlbXemLaiHDCu.Text = "Xem Lại Hóa Đơn Cũ";
            this.tlbXemLaiHDCu.ToolTipText = "Tim kiem lai cac hoa don ban kinh truoc do";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbLamPhieuBanMoi
            // 
            this.tlbLamPhieuBanMoi.Name = "tlbLamPhieuBanMoi";
            this.tlbLamPhieuBanMoi.Text = "Làm Phiếu Nhập Kính Mới";
            this.tlbLamPhieuBanMoi.ToolTipText = "Thuc hien viec them vao mot Phieu Ban Kinh moi cho Khach hang";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-35, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 4);
            this.groupBox2.TabIndex = 244;
            this.groupBox2.TabStop = false;
            // 
            // cmdCapNhatNCC
            // 
            this.cmdCapNhatNCC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCapNhatNCC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapNhatNCC.Location = new System.Drawing.Point(617, 128);
            this.cmdCapNhatNCC.Name = "cmdCapNhatNCC";
            this.cmdCapNhatNCC.Size = new System.Drawing.Size(104, 23);
            this.cmdCapNhatNCC.TabIndex = 248;
            this.cmdCapNhatNCC.Text = "Cập Nhật NCC";
            this.cmdCapNhatNCC.Click += new System.EventHandler(this.cmdCapNhatNCC_Click);
            // 
            // lblMaPNK
            // 
            this.lblMaPNK.Location = new System.Drawing.Point(264, 96);
            this.lblMaPNK.Name = "lblMaPNK";
            this.lblMaPNK.Size = new System.Drawing.Size(8, 23);
            this.lblMaPNK.TabIndex = 253;
            this.lblMaPNK.Visible = false;
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.Location = new System.Drawing.Point(256, 88);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(8, 23);
            this.lblMaNCC.TabIndex = 252;
            this.lblMaNCC.Visible = false;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(329, 88);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(392, 40);
            this.txtGhiChu.TabIndex = 2;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(264, 88);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(56, 23);
            this.label36.TabIndex = 251;
            this.label36.Text = "Ghi Chú";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(229, 136);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(91, 16);
            this.label28.TabIndex = 250;
            this.label28.Text = "Nhà cung cấp";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboNhaCC
            // 
            this.cboNhaCC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhaCC.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhaCC.ItemHeight = 16;
            this.cboNhaCC.Location = new System.Drawing.Point(329, 128);
            this.cboNhaCC.Name = "cboNhaCC";
            this.cboNhaCC.Size = new System.Drawing.Size(288, 24);
            this.cboNhaCC.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(-35, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(792, 4);
            this.groupBox3.TabIndex = 254;
            this.groupBox3.TabStop = false;
            // 
            // cmdCapNhatDMThuoc
            // 
            this.cmdCapNhatDMThuoc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdCapNhatDMThuoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCapNhatDMThuoc.Location = new System.Drawing.Point(512, 168);
            this.cmdCapNhatDMThuoc.Name = "cmdCapNhatDMThuoc";
            this.cmdCapNhatDMThuoc.Size = new System.Drawing.Size(132, 23);
            this.cmdCapNhatDMThuoc.TabIndex = 266;
            this.cmdCapNhatDMThuoc.Text = "Cập Nhật DM_Kính";
            this.cmdCapNhatDMThuoc.Click += new System.EventHandler(this.cmdCapNhatDMThuoc_Click);
            // 
            // cmdThemvaoPNK
            // 
            this.cmdThemvaoPNK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThemvaoPNK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThemvaoPNK.Location = new System.Drawing.Point(256, 216);
            this.cmdThemvaoPNK.Name = "cmdThemvaoPNK";
            this.cmdThemvaoPNK.Size = new System.Drawing.Size(88, 23);
            this.cmdThemvaoPNK.TabIndex = 259;
            this.cmdThemvaoPNK.Text = "Thêm vào PN";
            this.cmdThemvaoPNK.Click += new System.EventHandler(this.cmdThemvaoPNK_Click);
            // 
            // txtIndex
            // 
            this.txtIndex.BackColor = System.Drawing.Color.White;
            this.txtIndex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndex.Location = new System.Drawing.Point(672, 168);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(8, 22);
            this.txtIndex.TabIndex = 265;
            this.txtIndex.Visible = false;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGiaNhap.Location = new System.Drawing.Point(96, 192);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(152, 20);
            this.txtGiaNhap.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 264;
            this.label1.Text = "Giá nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaVTKinh
            // 
            this.txtMaVTKinh.BackColor = System.Drawing.Color.White;
            this.txtMaVTKinh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVTKinh.Location = new System.Drawing.Point(680, 168);
            this.txtMaVTKinh.Name = "txtMaVTKinh";
            this.txtMaVTKinh.Size = new System.Drawing.Size(8, 22);
            this.txtMaVTKinh.TabIndex = 263;
            this.txtMaVTKinh.Visible = false;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 168);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 23);
            this.label18.TabIndex = 261;
            this.label18.Text = "Tên VT Kính";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSoLuong.Location = new System.Drawing.Point(96, 216);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(152, 20);
            this.txtSoLuong.TabIndex = 6;
            this.txtSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoLuong_KeyDown);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(0, 216);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 23);
            this.label20.TabIndex = 262;
            this.label20.Text = "Số lượng nhập";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Mã Vật Tư";
            this.columnHeader11.Width = 90;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tên Vật Tư";
            this.columnHeader12.Width = 350;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mã VT Kính";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên VT Kính";
            this.columnHeader8.Width = 350;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(24, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(680, 4);
            this.groupBox4.TabIndex = 268;
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(416, 464);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 269;
            this.label5.Text = "Tổng Tiền (VNĐ)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(24, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 249;
            this.label2.Text = "Ngày nhập";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MaPN";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MaVTK";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên VT Kính";
            this.columnHeader4.Width = 350;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Giá nhập";
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Số lượng";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Thành tiền";
            this.columnHeader7.Width = 100;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(16, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 270;
            this.label3.Text = "Lí Do Nhập";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboLidoNhap
            // 
            this.cboLidoNhap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLidoNhap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLidoNhap.ItemHeight = 16;
            this.cboLidoNhap.Location = new System.Drawing.Point(96, 128);
            this.cboLidoNhap.Name = "cboLidoNhap";
            this.cboLidoNhap.Size = new System.Drawing.Size(136, 24);
            this.cboLidoNhap.TabIndex = 1;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mã Vật Tư";
            this.columnHeader9.Width = 90;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tên Vật Tư";
            this.columnHeader10.Width = 350;
            // 
            // txtTenVTKinh
            // 
            this.txtTenVTKinh.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14});
            this.txtTenVTKinh.Data = null;
            this.txtTenVTKinh.KiemTraTonTai = false;
            this.txtTenVTKinh.ListHeight = 0;
            this.txtTenVTKinh.Location = new System.Drawing.Point(96, 168);
            this.txtTenVTKinh.MultiLine = false;
            this.txtTenVTKinh.Name = "txtTenVTKinh";
            this.txtTenVTKinh.OtherColumn = 0;
            this.txtTenVTKinh.OtherValue = "";
            this.txtTenVTKinh.ReadOnly = false;
            this.txtTenVTKinh.RightAligh = false;
            this.txtTenVTKinh.SearchColumn = 1;
            this.txtTenVTKinh.SearchFromBegin = false;
            this.txtTenVTKinh.ShowHeader = true;
            this.txtTenVTKinh.Size = new System.Drawing.Size(408, 20);
            this.txtTenVTKinh.TabIndex = 4;
            this.txtTenVTKinh.ItemSelected += new System.EventHandler(this.txtTenVTKinh_ItemSelected);
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Mã vật tư";
            this.columnHeader13.Width = 100;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Tên vật tư";
            this.columnHeader14.Width = 350;
            // 
            // dtpNgayNhap
            // 
            this.dtpNgayNhap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayNhap.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayNhap.Location = new System.Drawing.Point(96, 88);
            this.dtpNgayNhap.Name = "dtpNgayNhap";
            this.dtpNgayNhap.Size = new System.Drawing.Size(136, 22);
            this.dtpNgayNhap.TabIndex = 271;
            // 
            // frmNhapKinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(722, 546);
            this.Controls.Add(this.dtpNgayNhap);
            this.Controls.Add(this.txtTenVTKinh);
            this.Controls.Add(this.cboLidoNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmdCapNhatDMThuoc);
            this.Controls.Add(this.cmdThemvaoPNK);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.txtGiaNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaVTKinh);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.cmdCapNhatNCC);
            this.Controls.Add(this.lblMaPNK);
            this.Controls.Add(this.lblMaNCC);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.cboNhaCC);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNhapKinh";
            this.Load += new System.EventHandler(this.frmNhapKinh_Load);
            this.Controls.SetChildIndex(this.cmdInPhieu, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTongTien, 0);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.toolBar1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.cboNhaCC, 0);
            this.Controls.SetChildIndex(this.label28, 0);
            this.Controls.SetChildIndex(this.label36, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.lblMaNCC, 0);
            this.Controls.SetChildIndex(this.lblMaPNK, 0);
            this.Controls.SetChildIndex(this.cmdCapNhatNCC, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.txtSoLuong, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtMaVTKinh, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtGiaNhap, 0);
            this.Controls.SetChildIndex(this.txtIndex, 0);
            this.Controls.SetChildIndex(this.cmdThemvaoPNK, 0);
            this.Controls.SetChildIndex(this.cmdCapNhatDMThuoc, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboLidoNhap, 0);
            this.Controls.SetChildIndex(this.txtTenVTKinh, 0);
            this.Controls.SetChildIndex(this.dtpNgayNhap, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void load_allcboBoxInForm()
        {
            string sql = "select MANCC, TENNCC from KINH_NHACUNGCAP order by TENNCC";
            string str2 = "select MALYDO, TENLYDO from KINH_LYDONX WHERE TENLYDO LIKE N'%Nhập%' order by TENLYDO";
            CommonClass.load_cboBox(this.cboNhaCC, out this.arrNCC, sql);
            CommonClass.load_cboBox(this.cboLidoNhap, out this.arrMaLiDo, str2);
        }

        private void load_ChiTietPNKCu(int iMaPNK)
        {
            try
            {
                base.listItems.Items.Clear();
                DataAccess access = new DataAccess();
                foreach (DataRow row in access.GetData("SELECT * from view_XemPNCu where dbo.view_XemPNCu.MAPHIEUNHAP = " + iMaPNK).Rows)
                {
                    ListViewItem item = new ListViewItem(new string[] { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[4].ToString(), row[3].ToString(), "" });
                    base.listItems.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void load_PhieuNhapCu(int iMaPNK)
        {
            try
            {
                DataAccess access = new DataAccess();
                foreach (DataRow row in access.GetData("SELECT dbo.KINH_PHIEUNHAP.NGAYNHAP, dbo.KINH_PHIEUNHAP.GHICHU, dbo.KINH_PHIEUNHAP.MALYDONHAPKINH, dbo.KINH_PHIEUNHAP.MANCC FROM dbo.KINH_NHACUNGCAP INNER JOIN dbo.KINH_PHIEUNHAP ON dbo.KINH_NHACUNGCAP.MANCC = dbo.KINH_PHIEUNHAP.MANCC where dbo.KINH_PHIEUNHAP.MAPHIEUNHAP = " + iMaPNK).Rows)
                {
                    this.dtpNgayNhap.Text = row[0].ToString();
                    this.txtGhiChu.Text = row[1].ToString();
                    this.cboLidoNhap.Text = row[2].ToString();
                    this.cboNhaCC.Text = row[3].ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        protected override void selectRecord()
        {
            if (base.listItems.SelectedIndices.Count >= 1)
            {
                ListViewItem item = base.listItems.SelectedItems[0];
                this.lblMaPNK.Text = item.SubItems[0].Text;
                this.txtMaVTKinh.Text = item.SubItems[1].Text;
                this.txtTenVTKinh.Text = item.SubItems[2].Text;
                this.txtGiaNhap.Text = item.SubItems[4].Text;
                this.txtSoLuong.Text = item.SubItems[3].Text;
                this.txtIndex.Text = base.listItems.SelectedItems[0].Index.ToString();
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == this.tlbXemLaiHDCu)
            {
                frmChonPhieuNhap nhap = new frmChonPhieuNhap();
                nhap.ShowDialog();
                if (nhap.iSuccess == 1)
                {
                    this.load_PhieuNhapCu(nhap.iMaPNK);
                    this.load_ChiTietPNKCu(nhap.iMaPNK);
                    double num = 0.0;
                    for (int i = 0; i < base.listItems.Items.Count; i++)
                    {
                        base.listItems.Items[i].SubItems[5].Text = (Convert.ToDouble(base.listItems.Items[i].SubItems[3].Text) * Convert.ToDouble(base.listItems.Items[i].SubItems[4].Text)).ToString();
                    }
                    for (int j = 0; j < base.listItems.Items.Count; j++)
                    {
                        num += Convert.ToDouble(base.listItems.Items[j].SubItems[5].Text);
                    }
                    base.txtTongTien.Text = num.ToString("#,##0");
                    this.enableControls(false);
                }
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Return)
            {
                return;
            }
            if ((this.txtMaVTKinh.Text == "") || (this.txtSoLuong.Text == ""))
            {
                MessageBox.Show("Y\x00eau cầu điền đầy đủ th\x00f4ng tin cho Chi Tiết Phiếu Nhập", "Th\x00f4ng B\x00e1o");
                if (this.txtMaVTKinh.Text == "")
                {
                    base.ActiveControl = this.txtTenVTKinh;
                }
                else
                {
                    if (!(this.txtSoLuong.Text == ""))
                    {
                        goto Label_03DB;
                    }
                    base.ActiveControl = this.txtSoLuong;
                }
                return;
            }
            if (this.txtGiaNhap.Text == "")
            {
                this.txtGiaNhap.Text = "0";
            }
            if (!base.isModify)
            {
                if (this.txtIndex.Text.Trim() != "")
                {
                    int num = Convert.ToInt32(this.txtIndex.Text);
                    base.listItems.Items[num].SubItems[1].Text = this.txtMaVTKinh.Text;
                    base.listItems.Items[num].SubItems[2].Text = this.txtTenVTKinh.Text;
                    base.listItems.Items[num].SubItems[3].Text = this.txtSoLuong.Text;
                    base.listItems.Items[num].SubItems[4].Text = this.txtGiaNhap.Text;
                    base.listItems.Items[num].SubItems[5].Text = (Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaNhap.Text)).ToString();
                    this.txtIndex.Text = "";
                }
                else
                {
                    double num3 = Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaNhap.Text);
                    ListViewItem item = new ListViewItem(new string[] { "0", this.txtMaVTKinh.Text.Trim(), this.txtTenVTKinh.Text.Trim(), this.txtSoLuong.Text.Trim(), this.txtGiaNhap.Text.Trim(), num3.ToString() });
                    base.listItems.Items.Add(item);
                }
            }
            else if (base.isModify)
            {
                int num4 = Convert.ToInt32(this.txtIndex.Text);
                base.listItems.Items[num4].SubItems[1].Text = this.txtMaVTKinh.Text;
                base.listItems.Items[num4].SubItems[2].Text = this.txtTenVTKinh.Text;
                base.listItems.Items[num4].SubItems[3].Text = this.txtSoLuong.Text;
                base.listItems.Items[num4].SubItems[4].Text = this.txtGiaNhap.Text;
                base.listItems.Items[num4].SubItems[5].Text = (Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaNhap.Text)).ToString();
            }
        Label_03DB:
            this.clearControls();
            this.tongtien = 0.0;
            for (int i = 0; i < base.listItems.Items.Count; i++)
            {
                this.tongtien += Convert.ToDouble(base.listItems.Items[i].SubItems[5].Text);
            }
            base.txtTongTien.Text = this.tongtien.ToString("#,##0");
        }

        private void txtTenVTKinh_ItemSelected(object sender, EventArgs e)
        {
            this.txtMaVTKinh.Text = this.txtTenVTKinh.SelectedItem.SubItems[0].Text;
            this.txtTenVTKinh.Text = this.txtTenVTKinh.SelectedItem.SubItems[1].Text;
            base.ActiveControl = this.txtGiaNhap;
        }

        private void txtTenVTKinh_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.txtMaVTKinh.Text = this.txtTenVTKinh.OtherValue;
            }
        }

        private void txtTenVTKinh_Leave(object sender, EventArgs e)
        {
            this.txtMaVTKinh.Text = this.txtTenVTKinh.OtherValue;
        }

        protected override bool validateData()
        {
            return true;
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}

