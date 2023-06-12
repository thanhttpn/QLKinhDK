namespace QlyKinh
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;
    using QLBV.DataAccess;    

    public class frmBanKinh : frmUpdateForm_Multi
    {
        private ArrayList arrMaNV;
        private ArrayList arrMaPXK;
        private ComboBox cboNhaVien;
        private Button cmdXem;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader9;
        private IContainer components = null;
        private DateTimePicker dtpNgayBanCu;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private ImageList imageList;
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
        private ListBox lsTenKinh;
        private ListView lswDS_BNLayKinhCu;
        private ListView lswTenThuoc;
        private ListView lswToaThuocCu;
        private Label Nh;
        private ColumnHeader STT;
        private ToolBarButton tblLamPhieuNhapLaiKinh;
        private ColumnHeader TenBN;
        private ToolBarButton tlbLamPhieuBanMoi;
        private ToolBarButton tlbXemLaiHDCu;
        private ToolBar toolBar1;
        private ToolBarButton toolBarButton1;
        private ToolBarButton toolBarButton2;
        private TextBox txtDVT;
        private TextBox txtGiaBan;
        private TextBox txtHoTenBN;
        private TextBox txtIndex;
        private TextBox txtMaBA;
        private TextBox txtMaKinh;
        private TextBox txtMaPX;
        private TextBox txtNhanVienTN;
        private TextBox txtSLBan;
        private TextBox txtSLT;
        private TextBox txtTenKinh;
        private TextBox txtTongTien;
        private TextBox txtTongTienTrongNgay;

        public frmBanKinh()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        protected override void clearControls()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (base.Controls[i].GetType() == typeof(TextBox))
                {
                    ((TextBox) base.Controls[i]).Text = "";
                }
                if (base.Controls[i].GetType() == typeof(ComboBox))
                {
                    ((ComboBox) base.Controls[i]).Text = "";
                }
            }
        }

        private void cmdXem_Click(object sender, EventArgs e)
        {
            this.load_lswDS_BNLayKinhCu(this.dtpNgayBanCu.Value.ToString("MM/dd/yyyy"));
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
                    ((TextBox) base.Controls[i]).ReadOnly = CommonClass.Not(val);
                }
                if (base.Controls[i].GetType() == typeof(ComboBox))
                {
                    ((ComboBox) base.Controls[i]).Enabled = val;
                }
            }
        }

        private void frmBanKinh_Load(object sender, EventArgs e)
        {
            this.lblNgayBan.Text = DateTime.Now.ToShortDateString();
            this.load_lswDS_BNLayKinhCu(DateTime.Now.ToString("MM/dd/yyyy"));            
        }

        protected override string getDeleteQuery()
        {
            return "";
        }

        protected override string getInsertQuery()
        {
            return "";
        }

        protected override string getSelectQuery()
        {
            return "SELECT * FROM KINH_VATTUKINH";
        }

        protected override string getUpdateQuery()
        {
            return "";
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanKinh));
            this.label13 = new System.Windows.Forms.Label();
            this.lswDS_BNLayKinhCu = new System.Windows.Forms.ListView();
            this.STT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenBN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdXem = new System.Windows.Forms.Button();
            this.dtpNgayBanCu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNhanVienTN = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboNhaVien = new System.Windows.Forms.ComboBox();
            this.lsTenKinh = new System.Windows.Forms.ListBox();
            this.txtMaPX = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.Nh = new System.Windows.Forms.Label();
            this.txtTenKinh = new System.Windows.Forms.TextBox();
            this.txtSLBan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSLT = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHoTenBN = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaKinh = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lswToaThuocCu = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lswTenThuoc = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTongTienTrongNgay = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMaBA = new System.Windows.Forms.TextBox();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.tlbXemLaiHDCu = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.tlbLamPhieuBanMoi = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.tblLamPhieuNhapLaiKinh = new System.Windows.Forms.ToolBarButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNgayBan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdInPhieu
            // 
            this.cmdInPhieu.Location = new System.Drawing.Point(632, 536);
            this.cmdInPhieu.Click += new System.EventHandler(this.cmdInPhieu_Click);
            // 
            // txtTongTien
            // 
            this.txtTongTien.BackColor = System.Drawing.SystemColors.Control;
            this.txtTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.Location = new System.Drawing.Point(624, 488);
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(152, 20);
            this.txtTongTien.TabIndex = 235;
            this.txtTongTien.TabStop = false;
            this.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(704, 536);
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.BackColor = System.Drawing.SystemColors.Desktop;
            this.grpBtnLine.Location = new System.Drawing.Point(232, 520);
            this.grpBtnLine.Size = new System.Drawing.Size(544, 4);
            // 
            // listItems
            // 
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listItems.Location = new System.Drawing.Point(216, 256);
            this.listItems.Size = new System.Drawing.Size(568, 224);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(392, 528);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(224, 528);
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
            this.label13.TabIndex = 10;
            this.label13.Text = "BÁN KÍNH";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lswDS_BNLayKinhCu
            // 
            this.lswDS_BNLayKinhCu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.STT,
            this.TenBN});
            this.lswDS_BNLayKinhCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lswDS_BNLayKinhCu.FullRowSelect = true;
            this.lswDS_BNLayKinhCu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lswDS_BNLayKinhCu.Location = new System.Drawing.Point(0, 152);
            this.lswDS_BNLayKinhCu.Name = "lswDS_BNLayKinhCu";
            this.lswDS_BNLayKinhCu.Size = new System.Drawing.Size(200, 408);
            this.lswDS_BNLayKinhCu.TabIndex = 200;
            this.lswDS_BNLayKinhCu.UseCompatibleStateImageBehavior = false;
            this.lswDS_BNLayKinhCu.View = System.Windows.Forms.View.Details;
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
            // cmdXem
            // 
            this.cmdXem.BackColor = System.Drawing.SystemColors.Control;
            this.cmdXem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXem.Location = new System.Drawing.Point(144, 88);
            this.cmdXem.Name = "cmdXem";
            this.cmdXem.Size = new System.Drawing.Size(56, 20);
            this.cmdXem.TabIndex = 199;
            this.cmdXem.Text = "Xem";
            this.cmdXem.UseVisualStyleBackColor = false;
            this.cmdXem.Click += new System.EventHandler(this.cmdXem_Click);
            // 
            // dtpNgayBanCu
            // 
            this.dtpNgayBanCu.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBanCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBanCu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBanCu.Location = new System.Drawing.Point(8, 88);
            this.dtpNgayBanCu.Name = "dtpNgayBanCu";
            this.dtpNgayBanCu.Size = new System.Drawing.Size(136, 20);
            this.dtpNgayBanCu.TabIndex = 198;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(8, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(192, 23);
            this.label3.TabIndex = 197;
            this.label3.Text = "Bệnh Nhân Lấy Kính Trong Ngày";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(208, 80);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(2, 488);
            this.groupBox4.TabIndex = 201;
            this.groupBox4.TabStop = false;
            // 
            // txtNhanVienTN
            // 
            this.txtNhanVienTN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNhanVienTN.Location = new System.Drawing.Point(608, 112);
            this.txtNhanVienTN.Name = "txtNhanVienTN";
            this.txtNhanVienTN.ReadOnly = true;
            this.txtNhanVienTN.Size = new System.Drawing.Size(184, 22);
            this.txtNhanVienTN.TabIndex = 228;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label15.Location = new System.Drawing.Point(528, 112);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 23);
            this.label15.TabIndex = 227;
            this.label15.Text = "Thu Ngân";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.Location = new System.Drawing.Point(224, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 23);
            this.label10.TabIndex = 226;
            this.label10.Text = "NV Thu Ngân";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboNhaVien
            // 
            this.cboNhaVien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNhaVien.Location = new System.Drawing.Point(328, 112);
            this.cboNhaVien.Name = "cboNhaVien";
            this.cboNhaVien.Size = new System.Drawing.Size(152, 24);
            this.cboNhaVien.TabIndex = 225;
            // 
            // lsTenKinh
            // 
            this.lsTenKinh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsTenKinh.ItemHeight = 16;
            this.lsTenKinh.Location = new System.Drawing.Point(448, 200);
            this.lsTenKinh.Name = "lsTenKinh";
            this.lsTenKinh.Size = new System.Drawing.Size(224, 68);
            this.lsTenKinh.TabIndex = 224;
            this.lsTenKinh.Visible = false;
            // 
            // txtMaPX
            // 
            this.txtMaPX.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaPX.Location = new System.Drawing.Point(392, 112);
            this.txtMaPX.Name = "txtMaPX";
            this.txtMaPX.Size = new System.Drawing.Size(88, 22);
            this.txtMaPX.TabIndex = 223;
            this.txtMaPX.TabStop = false;
            this.txtMaPX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaPX.Visible = false;
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndex.Location = new System.Drawing.Point(392, 112);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(88, 22);
            this.txtIndex.TabIndex = 222;
            this.txtIndex.TabStop = false;
            this.txtIndex.Visible = false;
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDung.ForeColor = System.Drawing.Color.Blue;
            this.lblNguoiDung.Location = new System.Drawing.Point(608, 88);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(184, 23);
            this.lblNguoiDung.TabIndex = 221;
            this.lblNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Nh
            // 
            this.Nh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Nh.Location = new System.Drawing.Point(512, 88);
            this.Nh.Name = "Nh";
            this.Nh.Size = new System.Drawing.Size(88, 23);
            this.Nh.TabIndex = 220;
            this.Nh.Text = "NV Bán Kính";
            this.Nh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenKinh
            // 
            this.txtTenKinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTenKinh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKinh.Location = new System.Drawing.Point(448, 176);
            this.txtTenKinh.Name = "txtTenKinh";
            this.txtTenKinh.Size = new System.Drawing.Size(200, 22);
            this.txtTenKinh.TabIndex = 205;
            // 
            // txtSLBan
            // 
            this.txtSLBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtSLBan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLBan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtSLBan.Location = new System.Drawing.Point(720, 176);
            this.txtSLBan.Name = "txtSLBan";
            this.txtSLBan.Size = new System.Drawing.Size(72, 22);
            this.txtSLBan.TabIndex = 204;
            this.txtSLBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(664, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 212;
            this.label1.Text = "SL Bán";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(216, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 23);
            this.label4.TabIndex = 210;
            this.label4.Text = "Số Lượng Tồn";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSLT
            // 
            this.txtSLT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSLT.Location = new System.Drawing.Point(328, 200);
            this.txtSLT.Name = "txtSLT";
            this.txtSLT.ReadOnly = true;
            this.txtSLT.Size = new System.Drawing.Size(120, 22);
            this.txtSLT.TabIndex = 217;
            this.txtSLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDVT
            // 
            this.txtDVT.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDVT.Location = new System.Drawing.Point(536, 200);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.ReadOnly = true;
            this.txtDVT.Size = new System.Drawing.Size(112, 22);
            this.txtDVT.TabIndex = 216;
            this.txtDVT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(464, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 23);
            this.label7.TabIndex = 213;
            this.label7.Text = "Độ Kính";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(664, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 23);
            this.label11.TabIndex = 209;
            this.label11.Text = "Giá Bán";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBan.Location = new System.Drawing.Point(720, 200);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.ReadOnly = true;
            this.txtGiaBan.Size = new System.Drawing.Size(72, 22);
            this.txtGiaBan.TabIndex = 218;
            this.txtGiaBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(216, 152);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 23);
            this.label12.TabIndex = 207;
            this.label12.Text = "Họ Tên BN";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHoTenBN
            // 
            this.txtHoTenBN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtHoTenBN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTenBN.ForeColor = System.Drawing.Color.Blue;
            this.txtHoTenBN.Location = new System.Drawing.Point(448, 152);
            this.txtHoTenBN.Name = "txtHoTenBN";
            this.txtHoTenBN.Size = new System.Drawing.Size(344, 22);
            this.txtHoTenBN.TabIndex = 202;
            // 
            // groupBox5
            // 
            this.groupBox5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(216, 144);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(576, 4);
            this.groupBox5.TabIndex = 219;
            this.groupBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 23);
            this.label2.TabIndex = 208;
            this.label2.Text = "Ngày Bán";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaKinh
            // 
            this.txtMaKinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaKinh.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaKinh.Location = new System.Drawing.Point(328, 176);
            this.txtMaKinh.Name = "txtMaKinh";
            this.txtMaKinh.Size = new System.Drawing.Size(120, 22);
            this.txtMaKinh.TabIndex = 203;
            this.txtMaKinh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.Location = new System.Drawing.Point(224, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 23);
            this.label8.TabIndex = 211;
            this.label8.Text = "Mã vật tư";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lswToaThuocCu
            // 
            this.lswToaThuocCu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lswToaThuocCu.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lswToaThuocCu.FullRowSelect = true;
            this.lswToaThuocCu.GridLines = true;
            this.lswToaThuocCu.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lswToaThuocCu.Location = new System.Drawing.Point(328, 176);
            this.lswToaThuocCu.Name = "lswToaThuocCu";
            this.lswToaThuocCu.Size = new System.Drawing.Size(451, 88);
            this.lswToaThuocCu.TabIndex = 230;
            this.lswToaThuocCu.UseCompatibleStateImageBehavior = false;
            this.lswToaThuocCu.View = System.Windows.Forms.View.Details;
            this.lswToaThuocCu.Visible = false;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Mã HĐ";
            this.columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Tên Bệnh Nhân";
            this.columnHeader12.Width = 220;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Ngày Lập";
            this.columnHeader13.Width = 100;
            // 
            // lswTenThuoc
            // 
            this.lswTenThuoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.lswTenThuoc.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lswTenThuoc.FullRowSelect = true;
            this.lswTenThuoc.GridLines = true;
            this.lswTenThuoc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lswTenThuoc.Location = new System.Drawing.Point(328, 200);
            this.lswTenThuoc.Name = "lswTenThuoc";
            this.lswTenThuoc.Size = new System.Drawing.Size(344, 92);
            this.lswTenThuoc.TabIndex = 229;
            this.lswTenThuoc.UseCompatibleStateImageBehavior = false;
            this.lswTenThuoc.View = System.Windows.Forms.View.Details;
            this.lswTenThuoc.Visible = false;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mã Kính";
            this.columnHeader9.Width = 80;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tên Kính";
            this.columnHeader10.Width = 220;
            // 
            // txtTongTienTrongNgay
            // 
            this.txtTongTienTrongNgay.BackColor = System.Drawing.SystemColors.Control;
            this.txtTongTienTrongNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTienTrongNgay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.txtTongTienTrongNgay.Location = new System.Drawing.Point(352, 488);
            this.txtTongTienTrongNgay.Name = "txtTongTienTrongNgay";
            this.txtTongTienTrongNgay.ReadOnly = true;
            this.txtTongTienTrongNgay.Size = new System.Drawing.Size(140, 20);
            this.txtTongTienTrongNgay.TabIndex = 237;
            this.txtTongTienTrongNgay.TabStop = false;
            this.txtTongTienTrongNgay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(216, 488);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 23);
            this.label19.TabIndex = 236;
            this.label19.Text = "Tổng Tiền Trong Ngày";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(520, 488);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 234;
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
            this.columnHeader2.Text = "Mã VT";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên Vật Tư";
            this.columnHeader3.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giá Bán";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Số lượng";
            this.columnHeader5.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Thành tiền";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Index";
            this.columnHeader7.Width = 0;
            // 
            // txtMaBA
            // 
            this.txtMaBA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaBA.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaBA.Location = new System.Drawing.Point(328, 152);
            this.txtMaBA.Name = "txtMaBA";
            this.txtMaBA.Size = new System.Drawing.Size(120, 22);
            this.txtMaBA.TabIndex = 238;
            this.txtMaBA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tlbXemLaiHDCu,
            this.toolBarButton1,
            this.tlbLamPhieuBanMoi,
            this.toolBarButton2,
            this.tblLamPhieuNhapLaiKinh});
            this.toolBar1.Divider = false;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBar1.Location = new System.Drawing.Point(0, 32);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(794, 43);
            this.toolBar1.TabIndex = 239;
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
            this.tlbLamPhieuBanMoi.Text = "Làm Phiếu Bán Mới";
            this.tlbLamPhieuBanMoi.ToolTipText = "Thuc hien viec them vao mot Phieu Ban Kinh moi cho Khach hang";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tblLamPhieuNhapLaiKinh
            // 
            this.tblLamPhieuNhapLaiKinh.Name = "tblLamPhieuNhapLaiKinh";
            this.tblLamPhieuNhapLaiKinh.Text = "Làm Phiếu Nhập Lại Kính";
            this.tblLamPhieuNhapLaiKinh.ToolTipText = "Thuc hien viec nhap lai kinh do Khach Hang tra lai";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 4);
            this.groupBox1.TabIndex = 240;
            this.groupBox1.TabStop = false;
            // 
            // lblNgayBan
            // 
            this.lblNgayBan.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayBan.ForeColor = System.Drawing.Color.Blue;
            this.lblNgayBan.Location = new System.Drawing.Point(328, 88);
            this.lblNgayBan.Name = "lblNgayBan";
            this.lblNgayBan.Size = new System.Drawing.Size(184, 23);
            this.lblNgayBan.TabIndex = 241;
            this.lblNgayBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBanKinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(794, 570);
            this.Controls.Add(this.lblNgayBan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.txtMaBA);
            this.Controls.Add(this.txtTongTienTrongNgay);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lswToaThuocCu);
            this.Controls.Add(this.lswTenThuoc);
            this.Controls.Add(this.txtNhanVienTN);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboNhaVien);
            this.Controls.Add(this.lsTenKinh);
            this.Controls.Add(this.txtMaPX);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.Nh);
            this.Controls.Add(this.txtTenKinh);
            this.Controls.Add(this.txtSLBan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSLT);
            this.Controls.Add(this.txtDVT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtHoTenBN);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaKinh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.lswDS_BNLayKinhCu);
            this.Controls.Add(this.cmdXem);
            this.Controls.Add(this.dtpNgayBanCu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label13);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBanKinh";
            this.ShowInTaskbar = false;
            this.Text = "Ban Kinh Cho Khach Hang";
            this.Load += new System.EventHandler(this.frmBanKinh_Load);
            this.Controls.SetChildIndex(this.cmdInPhieu, 0);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpNgayBanCu, 0);
            this.Controls.SetChildIndex(this.cmdXem, 0);
            this.Controls.SetChildIndex(this.lswDS_BNLayKinhCu, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtMaKinh, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.groupBox5, 0);
            this.Controls.SetChildIndex(this.txtHoTenBN, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.txtGiaBan, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtDVT, 0);
            this.Controls.SetChildIndex(this.txtSLT, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtSLBan, 0);
            this.Controls.SetChildIndex(this.txtTenKinh, 0);
            this.Controls.SetChildIndex(this.Nh, 0);
            this.Controls.SetChildIndex(this.lblNguoiDung, 0);
            this.Controls.SetChildIndex(this.txtIndex, 0);
            this.Controls.SetChildIndex(this.txtMaPX, 0);
            this.Controls.SetChildIndex(this.lsTenKinh, 0);
            this.Controls.SetChildIndex(this.cboNhaVien, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.txtNhanVienTN, 0);
            this.Controls.SetChildIndex(this.lswTenThuoc, 0);
            this.Controls.SetChildIndex(this.lswToaThuocCu, 0);
            this.Controls.SetChildIndex(this.txtTongTien, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.txtTongTienTrongNgay, 0);
            this.Controls.SetChildIndex(this.txtMaBA, 0);
            this.Controls.SetChildIndex(this.toolBar1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.lblNgayBan, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void load_allcboBoxInForm()
        {
            string sql = "select MANV, TENNHANVIEN from NhanVien where MaphongBan = " + 5;
            CommonClass.load_cboBox(this.cboNhaVien, out this.arrMaNV, sql);
        }

        public void load_lswDS_BNLayKinhCu(string ngay)
        {
            this.lswDS_BNLayKinhCu.Items.Clear();
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
                this.lswDS_BNLayKinhCu.Items.Add(item);
            }
        }

        private void load_TTKinh()
        {
            try
            {
                string str = "select DOKINH, GIABAN from KINH_VATTUKINH where MAVATTU = " + Convert.ToInt32(this.txtMaKinh.Text);
                DataAccess access = new DataAccess();
                access.CommandText = str;
                DataTable data = access.GetData();
                if ((data != null) && (data.Rows.Count > 0))
                {
                }
                this.selectRecord();
            }
            catch (Exception exception)
            {
                MessageBox.Show("C\x00f3 lỗi khi load dữ liệu, vui l\x00f2ng li\x00ean hệ với quản trị hệ thống.\n\n" + exception.Message, "Th\x00f4ng B\x00e1o");
            }
        }

        protected override void selectRecord()
        {
            if (base.listItems.SelectedIndices.Count >= 1)
            {
                ListViewItem item = base.listItems.SelectedItems[0];
                this.txtMaPX.Text = item.SubItems[0].Text;
                this.txtMaKinh.Text = item.SubItems[1].Text;
                this.txtTenKinh.Text = item.SubItems[2].Text;
                this.txtSLBan.Text = item.SubItems[4].Text;
                this.txtIndex.Text = item.SubItems[6].Text;
            }
        }

        protected override bool validateData()
        {
            return true;
        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {

        }
    }
}

