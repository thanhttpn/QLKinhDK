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

    public class frmXuatKinhLido : frmUpdateForm_Multi
    {
        private ArrayList arrMaLido;
        private ComboBox cboLidoXuat;
        private Button cmdThemvaoPNK;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private IContainer components;
        private DateTimePicker dtpNgayXuat;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label1;
        private Label label13;
        private Label label18;
        private Label label2;
        private Label label20;
        private Label label3;
        private Label label36;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblMaNCC;
        private Label lblMaPNK;
        private int m_MaNVDN;
        private ToolBarButton tlbLamPhieuXuatMoi;
        private ToolBarButton tlbXemLaiHDCu;
        private double tongtien;
        private ToolBar toolBar1;
        private ToolBarButton toolBarButton1;
        private TextBox txtDVT;
        private TextBox txtGhiChu;
        private TextBox txtGiaXuat;
        private TextBox txtIndex;
        private TextBox txtMaVTKinh;
        private TextBox txtSLT;
        private TextBox txtSoLuong;
        private LookupBox txtTenVTKinh;

        public frmXuatKinhLido()
        {
            this.components = null;
            this.m_MaNVDN = 0;
            this.InitializeComponent();
        }

        public frmXuatKinhLido(int MaNVDN)
        {
            this.components = null;
            this.m_MaNVDN = 0;
            this.InitializeComponent();
            this.m_MaNVDN = MaNVDN;
        }

        protected override int checkFrom()
        {
            return 1;
        }

        private void clearControls1()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (((base.Controls[i].GetType() == typeof(TextBox)) && (base.Controls[i].Name != "txtGhiChu")) && (base.Controls[i].Name != "txtTongTien"))
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

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
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

        private void frmXuatKinhLido_Load(object sender, EventArgs e)
        {
            this.enableControls(false);
            this.txtTenVTKinh.Data = new DataAccess().GetData("select MAVATTU, TENVATTU from viewTonKhoKinh");
            this.load_allcboBoxInForm();
        }

        protected override DataType[] getDataTypeDetail()
        {
            return new DataType[] { DataType.Int, DataType.VarChar, DataType.Int, DataType.Double, DataType.NVarChar };
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
            return "insert into KINH_CHITIETXUAT (MAPHIEUXUAT,MAVATTU,SOLUONG,DONGIA,MAGONG) values(:MAPHIEUXUAT, :MAVATTU, :SOLUONG, :DONGIA,:MAGONG)";
        }

        protected override string getInsertQueryMain()
        {
            try
            {
                return "Insert into KINH_PHIEUXUAT (MALYDOXUATKINH,NGAYXUAT,GhiChu,MANVXUAT)values( '" + this.arrMaLido[this.cboLidoXuat.SelectedIndex].ToString()+ "', '" + DateTime.Now.ToString("MM/dd/yyyy") + "', N'" + this.txtGhiChu.Text + "', " + this.m_MaNVDN +")";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
            return "";
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
            return list;
        }

        protected override string getPrintQuery()
        {
            return "select * from viewInPhieuXuat where dbo.viewInPhieuXuat.MaPhieuXuat = '";
        }

        protected override ReportDocument getReportDocument()
        {
            ReportDocument re = new ReportDocument();
            re.Load(ConfigurationSettings.AppSettings.Get("ReportPath")+"rptPhieuXuatKhoKinh.rpt");
            return re;
            //return new rptPhieuXuatKhoKinh();
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
            return (Environment.CurrentDirectory + @"\Reports\rptPhieuXuatKhoKinh.rpt");
        }

        protected override string getViewInStock()
        {
            return "select soluong from viewTonKhoKinh where MAVATTU = ";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmXuatKinhLido));
            this.label13 = new System.Windows.Forms.Label();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tlbXemLaiHDCu = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tlbLamPhieuXuatMoi = new System.Windows.Forms.ToolBarButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpNgayXuat = new System.Windows.Forms.DateTimePicker();
            this.cboLidoXuat = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblMaPNK = new System.Windows.Forms.Label();
            this.lblMaNCC = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenVTKinh = new QLBV.Common.Controls.LookupBox();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmdThemvaoPNK = new System.Windows.Forms.Button();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtGiaXuat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaVTKinh = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.txtSLT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cmdInPhieu
            // 
            this.cmdInPhieu.Location = new System.Drawing.Point(432, 512);
            this.cmdInPhieu.Click += new System.EventHandler(this.cmdInPhieu_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(424, 456);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(536, 512);
            this.btnExit.TabIndex = 8;
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.Location = new System.Drawing.Point(-8, 496);
            this.grpBtnLine.Size = new System.Drawing.Size(736, 4);
            // 
            // listItems
            // 
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6});
            this.listItems.Location = new System.Drawing.Point(8, 240);
            this.listItems.Size = new System.Drawing.Size(600, 208);
            this.listItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listItems_KeyDown);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(168, 504);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(0, 504);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(624, 32);
            this.label13.TabIndex = 243;
            this.label13.Text = "XUẤT KÍNH";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tlbXemLaiHDCu,
            this.toolBarButton1,
            this.tlbLamPhieuXuatMoi});
            this.toolBar1.Divider = false;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBar1.Location = new System.Drawing.Point(0, 32);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(624, 43);
            this.toolBar1.TabIndex = 244;
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
            // tlbLamPhieuXuatMoi
            // 
            this.tlbLamPhieuXuatMoi.Name = "tlbLamPhieuXuatMoi";
            this.tlbLamPhieuXuatMoi.Text = "Làm Phiếu Xuất TTT Mới";
            this.tlbLamPhieuXuatMoi.ToolTipText = "Thuc hien viec them vao mot Phieu Ban Kinh moi cho Khach hang";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-35, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 4);
            this.groupBox2.TabIndex = 245;
            this.groupBox2.TabStop = false;
            // 
            // dtpNgayXuat
            // 
            this.dtpNgayXuat.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayXuat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayXuat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayXuat.Location = new System.Drawing.Point(96, 80);
            this.dtpNgayXuat.Name = "dtpNgayXuat";
            this.dtpNgayXuat.Size = new System.Drawing.Size(136, 22);
            this.dtpNgayXuat.TabIndex = 283;
            // 
            // cboLidoXuat
            // 
            this.cboLidoXuat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLidoXuat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLidoXuat.ItemHeight = 16;
            this.cboLidoXuat.Location = new System.Drawing.Point(96, 120);
            this.cboLidoXuat.Name = "cboLidoXuat";
            this.cboLidoXuat.Size = new System.Drawing.Size(136, 24);
            this.cboLidoXuat.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(16, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 282;
            this.label3.Text = "Lí Do Xuất";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(-40, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(792, 4);
            this.groupBox3.TabIndex = 281;
            this.groupBox3.TabStop = false;
            // 
            // lblMaPNK
            // 
            this.lblMaPNK.Location = new System.Drawing.Point(264, 88);
            this.lblMaPNK.Name = "lblMaPNK";
            this.lblMaPNK.Size = new System.Drawing.Size(8, 23);
            this.lblMaPNK.TabIndex = 280;
            this.lblMaPNK.Visible = false;
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.Location = new System.Drawing.Point(256, 80);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(8, 23);
            this.lblMaNCC.TabIndex = 279;
            this.lblMaNCC.Visible = false;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(328, 80);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGhiChu.Size = new System.Drawing.Size(272, 72);
            this.txtGhiChu.TabIndex = 1;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.Color.Red;
            this.label36.Location = new System.Drawing.Point(264, 80);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(56, 23);
            this.label36.TabIndex = 278;
            this.label36.Text = "Ghi Chú";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(24, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 276;
            this.label2.Text = "Ngày xuất";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenVTKinh
            // 
            this.txtTenVTKinh.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.txtTenVTKinh.Data = null;
            this.txtTenVTKinh.KiemTraTonTai = false;
            this.txtTenVTKinh.ListHeight = 0;
            this.txtTenVTKinh.Location = new System.Drawing.Point(96, 160);
            this.txtTenVTKinh.MultiLine = false;
            this.txtTenVTKinh.Name = "txtTenVTKinh";
            this.txtTenVTKinh.OtherColumn = 0;
            this.txtTenVTKinh.OtherValue = "";
            this.txtTenVTKinh.ReadOnly = false;
            this.txtTenVTKinh.RightAligh = false;
            this.txtTenVTKinh.SearchColumn = 1;
            this.txtTenVTKinh.SearchFromBegin = false;
            this.txtTenVTKinh.ShowHeader = true;
            this.txtTenVTKinh.Size = new System.Drawing.Size(512, 20);
            this.txtTenVTKinh.TabIndex = 2;
            this.txtTenVTKinh.ItemSelected += new System.EventHandler(this.txtTenVTKinh_ItemSelected);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mã Vật Tư";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Tên Vật Tư";
            this.columnHeader8.Width = 350;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(0, 232);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(680, 4);
            this.groupBox4.TabIndex = 294;
            this.groupBox4.TabStop = false;
            // 
            // cmdThemvaoPNK
            // 
            this.cmdThemvaoPNK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThemvaoPNK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThemvaoPNK.Location = new System.Drawing.Point(256, 208);
            this.cmdThemvaoPNK.Name = "cmdThemvaoPNK";
            this.cmdThemvaoPNK.Size = new System.Drawing.Size(88, 23);
            this.cmdThemvaoPNK.TabIndex = 5;
            this.cmdThemvaoPNK.Text = "Thêm vào PX";
            // 
            // txtIndex
            // 
            this.txtIndex.BackColor = System.Drawing.Color.White;
            this.txtIndex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndex.Location = new System.Drawing.Point(592, 128);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(8, 22);
            this.txtIndex.TabIndex = 292;
            this.txtIndex.Visible = false;
            // 
            // txtGiaXuat
            // 
            this.txtGiaXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaXuat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtGiaXuat.Location = new System.Drawing.Point(96, 184);
            this.txtGiaXuat.Name = "txtGiaXuat";
            this.txtGiaXuat.Size = new System.Drawing.Size(152, 20);
            this.txtGiaXuat.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 291;
            this.label1.Text = "Giá xuất";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaVTKinh
            // 
            this.txtMaVTKinh.BackColor = System.Drawing.Color.White;
            this.txtMaVTKinh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaVTKinh.Location = new System.Drawing.Point(600, 128);
            this.txtMaVTKinh.Name = "txtMaVTKinh";
            this.txtMaVTKinh.Size = new System.Drawing.Size(8, 22);
            this.txtMaVTKinh.TabIndex = 290;
            this.txtMaVTKinh.Visible = false;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 160);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(88, 23);
            this.label18.TabIndex = 288;
            this.label18.Text = "Tên VT Kính";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSoLuong.Location = new System.Drawing.Point(96, 208);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(152, 20);
            this.txtSoLuong.TabIndex = 4;
            this.txtSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoLuong_KeyDown);
            this.txtSoLuong.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtSoLuong_MouseDown);
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(0, 208);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 23);
            this.label20.TabIndex = 289;
            this.label20.Text = "Số lượng xuất";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(320, 456);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 295;
            this.label5.Text = "Tổng Tiền (VNĐ)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "MaPX";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "MaVT";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số Lượng ";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tên vật tư";
            this.columnHeader4.Width = 250;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Đơn Giá";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Thành tiền";
            this.columnHeader6.Width = 150;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(256, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 23);
            this.label4.TabIndex = 296;
            this.label4.Text = "Số Lượng Tồn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSLT
            // 
            this.txtSLT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLT.Location = new System.Drawing.Point(360, 184);
            this.txtSLT.Name = "txtSLT";
            this.txtSLT.ReadOnly = true;
            this.txtSLT.Size = new System.Drawing.Size(136, 22);
            this.txtSLT.TabIndex = 297;
            this.txtSLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(504, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 23);
            this.label6.TabIndex = 298;
            this.label6.Text = "ĐVT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDVT
            // 
            this.txtDVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Location = new System.Drawing.Point(536, 184);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.ReadOnly = true;
            this.txtDVT.Size = new System.Drawing.Size(72, 22);
            this.txtDVT.TabIndex = 299;
            this.txtDVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmXuatKinhLido
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(624, 546);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSLT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTenVTKinh);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmdThemvaoPNK);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.txtGiaXuat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMaVTKinh);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dtpNgayXuat);
            this.Controls.Add(this.cboLidoXuat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblMaPNK);
            this.Controls.Add(this.lblMaNCC);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.label13);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmXuatKinhLido";
            this.Load += new System.EventHandler(this.frmXuatKinhLido_Load);
            this.Controls.SetChildIndex(this.txtTongTien, 0);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.cmdInPhieu, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.toolBar1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label36, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.lblMaNCC, 0);
            this.Controls.SetChildIndex(this.lblMaPNK, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.cboLidoXuat, 0);
            this.Controls.SetChildIndex(this.dtpNgayXuat, 0);
            this.Controls.SetChildIndex(this.label20, 0);
            this.Controls.SetChildIndex(this.txtSoLuong, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.txtMaVTKinh, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtGiaXuat, 0);
            this.Controls.SetChildIndex(this.txtIndex, 0);
            this.Controls.SetChildIndex(this.cmdThemvaoPNK, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.txtTenVTKinh, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtSLT, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.txtDVT, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        protected void listItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
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
            string sql = "select MALYDO, TENLYDO from KINH_LYDONX WHERE TENLYDO LIKE N'%Xuất%' order by TENLYDO";
            CommonClass.load_cboBox(this.cboLidoXuat, out this.arrMaLido, sql);
        }

        private void load_ChiTietPXKCu(int iMaPXK)
        {
            try
            {
                base.listItems.Items.Clear();
                DataAccess access = new DataAccess();
                foreach (DataRow row in access.GetData("SELECT * from view_XemPXCu where dbo.view_XemPXCu.MAPHIEUXUAT = " + iMaPXK).Rows)
                {
                    double num = Convert.ToDouble(row[3].ToString()) * Convert.ToDouble(row[4].ToString());
                    ListViewItem item = new ListViewItem(new string[] { row[0].ToString(), row[1].ToString(), row[2].ToString(), row[4].ToString(), row[3].ToString(), row[5].ToString(), num.ToString() });
                    base.listItems.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void load_PhieuXuatCu(int iMaPXK)
        {
            try
            {
                DataAccess access = new DataAccess();
                foreach (DataRow row in access.GetData("SELECT dbo.KINH_PHIEUXUAT.NGAYXUAT, dbo.KINH_PHIEUXUAT.GHICHU, dbo.KINH_PHIEUXUAT.MALYDOXUATKINH FROM dbo.KINH_PHIEUXUAT where dbo.KINH_PHIEUXUAT.MAPHIEUXUAT = " + iMaPXK).Rows)
                {
                    this.dtpNgayXuat.Text = row[0].ToString();
                    this.txtGhiChu.Text = row[1].ToString();
                    this.cboLidoXuat.Text = row[2].ToString();
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
                DataTable data = new DataAccess().GetData("SELECT *  from view_ThongtinVatTuChiTiet where dbo.view_ThongtinVatTuChiTiet.MAVATTU = '" + this.txtMaVTKinh.Text.Trim() + "'");
                if (data.Rows.Count <= 0)
                {
                    MessageBox.Show("Vật tư được chọn, hiện tại kh\x00f4ng c\x00f2n tồn trong kho nữa", "Th\x00f4ng B\x00e1o");
                    this.clearControls1();
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        this.txtGiaXuat.Text = row[0].ToString();
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

        protected override void selectRecord()
        {
            if (base.listItems.SelectedIndices.Count >= 1)
            {
                ListViewItem item = base.listItems.SelectedItems[0];
                this.txtMaVTKinh.Text = item.SubItems[1].Text;
                this.txtTenVTKinh.Text = item.SubItems[2].Text;
                this.txtGiaXuat.Text = item.SubItems[4].Text;
                this.txtSLT.Text = item.SubItems[3].Text;
                this.txtSoLuong.Focus();
                this.txtIndex.Text = base.listItems.SelectedItems[0].Index.ToString();
            }
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button == this.tlbXemLaiHDCu)
            {
                frmChonPhieuXuat xuat = new frmChonPhieuXuat();
                xuat.ShowDialog();
                if (xuat.iSuccess == 1)
                {
                    this.load_PhieuXuatCu(xuat.iMaPXK);
                    this.load_ChiTietPXKCu(xuat.iMaPXK);
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
            if (Convert.ToInt32(this.txtSoLuong.Text) == 0)
            {
                MessageBox.Show("Số Lượng B\x00e1n Kh\x00f4ng bằng 0", "Th\x00f4ng B\x00e1o");
                this.txtSoLuong.Text = "";
                this.txtSoLuong.Focus();
            }
            if (Convert.ToInt32(this.txtSoLuong.Text) > Convert.ToInt32(this.txtSLT.Text))
            {
                MessageBox.Show("Số lượng tồn th\x00ec kh\x00f4ng đủ đ\x00e1p ứng cho việc xuất", "Th\x00f4ng B\x00e1o");
                this.txtSoLuong.Text = "";
                this.txtSoLuong.Focus();
                return;
            }
            if ((this.txtTenVTKinh.Text == "") || (this.txtSoLuong.Text == ""))
            {
                MessageBox.Show("Y\x00eau cầu điền đầy đủ th\x00f4ng tin cho Chi Tiết Phiếu Nhập", "Th\x00f4ng B\x00e1o");
                if (this.txtTenVTKinh.Text == "")
                {
                    base.ActiveControl = this.txtTenVTKinh;
                }
                else
                {
                    if (!(this.txtSoLuong.Text == ""))
                    {
                        goto Label_02FF;
                    }
                    base.ActiveControl = this.txtSoLuong;
                }
                return;
            }
            if (!base.isModify)
            {
                double num = Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaXuat.Text);
                ListViewItem item = new ListViewItem(new string[] { "0", this.txtMaVTKinh.Text.Trim(), this.txtTenVTKinh.Text.Trim(), this.txtSoLuong.Text.Trim(), this.txtGiaXuat.Text.Trim(), num.ToString() });
                base.listItems.Items.Add(item);
            }
            else if (base.isModify)
            {
                int num2 = Convert.ToInt32(this.txtIndex.Text);
                base.listItems.Items[num2].SubItems[1].Text = this.txtMaVTKinh.Text;
                base.listItems.Items[num2].SubItems[2].Text = this.txtTenVTKinh.Text;
                base.listItems.Items[num2].SubItems[4].Text = this.txtGiaXuat.Text;
                base.listItems.Items[num2].SubItems[3].Text = this.txtSoLuong.Text;
                base.listItems.Items[num2].SubItems[5].Text = (Convert.ToDouble(this.txtSoLuong.Text) * Convert.ToDouble(this.txtGiaXuat.Text)).ToString();
            }
        Label_02FF:
            this.clearControls1();
            double num4 = 0.0;
            for (int i = 0; i < base.listItems.Items.Count; i++)
            {
                num4 += Convert.ToDouble(base.listItems.Items[i].SubItems[5].Text);
            }
            base.txtTongTien.Text = num4.ToString("#,##0");
        }

        private void txtSoLuong_MouseDown(object sender, MouseEventArgs e)
        {
            this.load_ThongtinVatTuChiTiet();
        }

        private void txtTenVTKinh_ItemSelected(object sender, EventArgs e)
        {
            this.txtMaVTKinh.Text = this.txtTenVTKinh.SelectedItem.SubItems[0].Text;
            this.txtTenVTKinh.Text = this.txtTenVTKinh.SelectedItem.SubItems[1].Text;
            this.load_ThongtinVatTuChiTiet();
            base.ActiveControl = this.txtSoLuong;
        }

        private void txtTenVTKinh_Leave(object sender, EventArgs e)
        {
            if (this.txtTenVTKinh.Text.Trim() != "")
            {
                this.txtMaVTKinh.Text = this.txtTenVTKinh.OtherValue;
                this.load_ThongtinVatTuChiTiet();
                base.ActiveControl = this.txtSoLuong;
            }
        }
    }
}

