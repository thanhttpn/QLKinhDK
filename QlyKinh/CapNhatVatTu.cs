namespace QlyKinh
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using QLBV.Common.Barcode;
    using QLBV.DataAccess;   

    public class CapNhatVatTu : UpdateForm
    {
        private ArrayList arrCL;
        private ArrayList arrLK;
        private ArrayList arrLVT;
        private ArrayList arrNK;
        private Code128 Barcode;
        private ComboBox cboCL;
        private ComboBox cboLK;
        private ComboBox cboLVT;
        private ComboBox cboNK;
        private ComboBox cboQuiCach;
        private Button cmdNhanKinh;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private IContainer components = null;
        private Label label1;
        private Label label10;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private string m_Chatlieu = "";
        private string m_GiaBan = "";
        private string m_Loaikinh = "";
        private string m_LoaiVT = "";
        private string m_Nhankinh = "";
        private string m_MaVatTu="";
        private TextBox txtDoKinh;
        private TextBox txtGiaBan;
        private TextBox txtMaVT;
        private TextBox txtQuiCach;
        private TextBox txtTenVT;

        public CapNhatVatTu()
        {
            this.InitializeComponent();
            this.enableControls(false);
            this.populateList();
        }

        private void CapNhatVatTu_Load(object sender, EventArgs e)
        {
            this.load_allcboBoxInForm();
        }

        private void cboCL_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboLK_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cboLVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboLVT.Text.Trim() != "")
            {
                this.m_LoaiVT = UpdateForm.sqlEncode(this.arrLVT[this.cboLVT.SelectedIndex].ToString());
            }
            //if (!this.isModify)
            {
                this.generateProductCode();
            }
        }

        private void cboNK_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboNK.Text.Trim() != "")
            {
                this.m_Nhankinh = UpdateForm.sqlEncode(this.arrNK[this.cboNK.SelectedIndex].ToString());
            }
            //if (!this.isModify)
            {
                this.generateProductCode();
            }
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
            this.cboLK.Focus();
        }

        private void cmdNhanKinh_Click(object sender, EventArgs e)
        {
            new frmCapNhatNhanKinh().ShowDialog();
            this.load_allcboBoxInForm();
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
            this.txtMaVT.ReadOnly = true;
        }

        private void generateProductCode()
        {
            this.txtMaVT.Text = "";
            this.txtMaVT.Text = this.m_LoaiVT + this.m_Nhankinh + this.m_GiaBan;
        }

        protected override string getDeleteQuery()
        {
            return ("UPDATE KINH_VATTUKINH SET DAXOA = 1 WHERE MAVATTU='" + this.txtMaVT.Text + "'");
        }

        protected override string getInsertQuery()
        {
            this.Barcode.CodeString = this.txtMaVT.Text.Trim();
            return string.Concat(new object[] { 
                "INSERT INTO KINH_VATTUKINH(MAVATTU,MALOAIVATTU,MALOAIKINH,MACHATLIEU,MANHAN,TENVATTU,QUICACH,GIABAN,DOKINH,BARCODE,DAXOA) VALUES('", UpdateForm.sqlEncode(this.txtMaVT.Text), "','", this.m_LoaiVT, "','", this.m_Loaikinh, "','", this.m_Chatlieu, "','", this.m_Nhankinh, "',N'", UpdateForm.sqlEncode(this.txtTenVT.Text), "',N'", UpdateForm.sqlEncode(this.cboQuiCach.Text.Trim()), "', ", Convert.ToDouble(this.txtGiaBan.Text), 
                ",N'", UpdateForm.sqlEncode(this.txtDoKinh.Text), "','", UpdateForm.sqlEncode(this.Barcode.EncodedText), "', ", 0, ")"
             });
        }

        private string getNumCode()
        {
            DateTime now = DateTime.Now;
            string ngay = "";
            if (now.Day < 10)
            {
                ngay = ngay + "0" + now.Day.ToString();
            }
            else
            {
                ngay = ngay + now.Day.ToString();
            }
            if (now.Month < 10)
            {
                ngay = ngay + "0" + now.Month.ToString();
            }
            else
            {
                ngay = ngay + now.Month.ToString();
            }
            ngay = ngay + now.Year.ToString().Substring(2, 2);
            return this.maxMaVT(ngay);
        }

        protected override string getSelectQuery()
        {
            return "SELECT MAVATTU, TENVATTU, MALOAIVATTU, MALOAIKINH, MACHATLIEU, MANHAN, QUICACH, GIABAN, DOKINH, BARCODE FROM KINH_VATTUKINH where daxoa = 0";
        }

        protected override string getUpdateQuery()
        {
            return string.Concat(new object[] { "UPDATE KINH_VATTUKINH SET MAVATTU='"+ UpdateForm.sqlEncode(this.txtMaVT.Text)+"', MALOAIVATTU ='" + this.m_LoaiVT + "' , TENVATTU=N'", UpdateForm.sqlEncode(this.txtTenVT.Text), "', QUICACH=N'", UpdateForm.sqlEncode(this.cboQuiCach.Text.Trim()), "', GIABAN=", Convert.ToDouble(this.txtGiaBan.Text), ", DOKINH=N'", UpdateForm.sqlEncode(this.txtDoKinh.Text), "' WHERE MAVATTU= '",m_MaVatTu, "'" });
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CapNhatVatTu));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaVT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboLK = new System.Windows.Forms.ComboBox();
            this.cboLVT = new System.Windows.Forms.ComboBox();
            this.cboCL = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboNK = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenVT = new System.Windows.Forms.TextBox();
            this.txtQuiCach = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDoKinh = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label10 = new System.Windows.Forms.Label();
            this.cmdNhanKinh = new System.Windows.Forms.Button();
            this.cboQuiCach = new System.Windows.Forms.ComboBox();
            this.Barcode = new QLBV.Common.Barcode.Code128();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(472, 504);
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.BackColor = System.Drawing.SystemColors.Desktop;
            this.grpBtnLine.Location = new System.Drawing.Point(16, 488);
            this.grpBtnLine.Size = new System.Drawing.Size(528, 3);
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
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listItems.Location = new System.Drawing.Point(12, 176);
            this.listItems.Size = new System.Drawing.Size(540, 304);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(176, 496);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(16, 496);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mã vật tư";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMaVT
            // 
            this.txtMaVT.BackColor = System.Drawing.Color.White;
            this.txtMaVT.Location = new System.Drawing.Point(80, 72);
            this.txtMaVT.Name = "txtMaVT";
            this.txtMaVT.ReadOnly = true;
            this.txtMaVT.Size = new System.Drawing.Size(160, 22);
            this.txtMaVT.TabIndex = 4;
            this.txtMaVT.Leave += new System.EventHandler(this.txtMaVT_Leave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Loại vật tư";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Loại kính";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Chất liệu";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // cboLK
            // 
            this.cboLK.Location = new System.Drawing.Point(80, 272);
            this.cboLK.Name = "cboLK";
            this.cboLK.Size = new System.Drawing.Size(164, 24);
            this.cboLK.TabIndex = 0;
            this.cboLK.Visible = false;
            this.cboLK.SelectedIndexChanged += new System.EventHandler(this.cboLK_SelectedIndexChanged);
            // 
            // cboLVT
            // 
            this.cboLVT.Location = new System.Drawing.Point(80, 40);
            this.cboLVT.Name = "cboLVT";
            this.cboLVT.Size = new System.Drawing.Size(160, 24);
            this.cboLVT.TabIndex = 0;
            this.cboLVT.SelectedIndexChanged += new System.EventHandler(this.cboLVT_SelectedIndexChanged);
            // 
            // cboCL
            // 
            this.cboCL.Location = new System.Drawing.Point(80, 272);
            this.cboCL.Name = "cboCL";
            this.cboCL.Size = new System.Drawing.Size(160, 24);
            this.cboCL.TabIndex = 1;
            this.cboCL.Visible = false;
            this.cboCL.SelectedIndexChanged += new System.EventHandler(this.cboCL_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tên vật tư";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboNK
            // 
            this.cboNK.Location = new System.Drawing.Point(352, 40);
            this.cboNK.Name = "cboNK";
            this.cboNK.Size = new System.Drawing.Size(164, 24);
            this.cboNK.TabIndex = 1;
            this.cboNK.SelectedIndexChanged += new System.EventHandler(this.cboNK_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(280, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Nhãn Kính:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenVT
            // 
            this.txtTenVT.Location = new System.Drawing.Point(80, 96);
            this.txtTenVT.Name = "txtTenVT";
            this.txtTenVT.Size = new System.Drawing.Size(432, 22);
            this.txtTenVT.TabIndex = 3;
            // 
            // txtQuiCach
            // 
            this.txtQuiCach.Location = new System.Drawing.Point(240, 272);
            this.txtQuiCach.Name = "txtQuiCach";
            this.txtQuiCach.Size = new System.Drawing.Size(25, 22);
            this.txtQuiCach.TabIndex = 6;
            this.txtQuiCach.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 16);
            this.label7.TabIndex = 21;
            this.label7.Text = "Qui cách";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(400, 72);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(112, 22);
            this.txtGiaBan.TabIndex = 2;
            this.txtGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiaBan_KeyPress);
            this.txtGiaBan.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtGiaBan_KeyUp);
            this.txtGiaBan.Leave += new System.EventHandler(this.txtGiaBan_Leave);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(344, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Giá bán";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDoKinh
            // 
            this.txtDoKinh.Location = new System.Drawing.Point(400, 120);
            this.txtDoKinh.Name = "txtDoKinh";
            this.txtDoKinh.Size = new System.Drawing.Size(112, 22);
            this.txtDoKinh.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(344, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 25;
            this.label9.Text = "Độ kính";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(568, 32);
            this.label13.TabIndex = 26;
            this.label13.Text = "CẬP NHẬT VẬT TƯ KÍNH";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã vật tư";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên vật tư kính";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Lọai vật tư";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Loại kính";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Chất liệu";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nhãn";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Qui cách";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Giá bán";
            this.columnHeader8.Width = 90;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Độ kính";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Số Seri";
            this.columnHeader10.Width = 0;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Highlight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(12, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(540, 16);
            this.label10.TabIndex = 27;
            this.label10.Text = "DANH SÁCH VẬT TƯ KÍNH HIỆN CÓ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmdNhanKinh
            // 
            this.cmdNhanKinh.BackColor = System.Drawing.SystemColors.Control;
            this.cmdNhanKinh.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdNhanKinh.Location = new System.Drawing.Point(520, 40);
            this.cmdNhanKinh.Name = "cmdNhanKinh";
            this.cmdNhanKinh.Size = new System.Drawing.Size(32, 23);
            this.cmdNhanKinh.TabIndex = 28;
            this.cmdNhanKinh.Text = "---";
            this.cmdNhanKinh.UseVisualStyleBackColor = false;
            this.cmdNhanKinh.Click += new System.EventHandler(this.cmdNhanKinh_Click);
            // 
            // cboQuiCach
            // 
            this.cboQuiCach.Items.AddRange(new object[] {
            "Cái",
            "Cây",
            "Miếng",
            "Chai",
            "Lọ",
            "Hộp"});
            this.cboQuiCach.Location = new System.Drawing.Point(80, 120);
            this.cboQuiCach.Name = "cboQuiCach";
            this.cboQuiCach.Size = new System.Drawing.Size(160, 24);
            this.cboQuiCach.TabIndex = 4;
            // 
            // Barcode
            // 
            this.Barcode.BackColor = System.Drawing.SystemColors.Control;
            this.Barcode.BarCodeHeight = 30;
            this.Barcode.CodeString = "1234567890";
            this.Barcode.Location = new System.Drawing.Point(0, 0);
            this.Barcode.Name = "Barcode";
            this.Barcode.ShowText = true;
            this.Barcode.Size = new System.Drawing.Size(130, 50);
            this.Barcode.TabIndex = 0;
            this.Barcode.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            // 
            // CapNhatVatTu
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(560, 538);
            this.Controls.Add(this.cboQuiCach);
            this.Controls.Add(this.cmdNhanKinh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDoKinh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtQuiCach);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTenVT);
            this.Controls.Add(this.cboNK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboCL);
            this.Controls.Add(this.cboLVT);
            this.Controls.Add(this.cboLK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaVT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CapNhatVatTu";
            this.Text = "Cập nhật vật tư";
            this.Load += new System.EventHandler(this.CapNhatVatTu_Load);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtMaVT, 0);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.cboLK, 0);
            this.Controls.SetChildIndex(this.cboLVT, 0);
            this.Controls.SetChildIndex(this.cboCL, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.cboNK, 0);
            this.Controls.SetChildIndex(this.txtTenVT, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.txtQuiCach, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.txtGiaBan, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.txtDoKinh, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.cmdNhanKinh, 0);
            this.Controls.SetChildIndex(this.cboQuiCach, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void load_allcboBoxInForm()
        {
            string sql = "select MALOAIKINH, TENLOAIKINH from KINH_LOAIKINH where DAXOA = 0 order by TENLOAIKINH";
            string str2 = "select MACHATLIEU, TENCHATLIEU from KINH_CHATLIEU where DAXOA = 0 order by TENCHATLIEU";
            string str3 = "select MANHAN, TENNHAN from KINH_NHAN order by TENNHAN";
            string str4 = "select MALOAIVATTU, TENLOAIVATTU from KINH_LOAIVATTU where DAXOA = 0 order by TENLOAIVATTU";
            CommonClass.load_cboBox(this.cboLK, out this.arrLK, sql);
            CommonClass.load_cboBox(this.cboCL, out this.arrCL, str2);
            CommonClass.load_cboBox(this.cboNK, out this.arrNK, str3);
            CommonClass.load_cboBox(this.cboLVT, out this.arrLVT, str4);
        }

        private string maxMaVT(string ngay)
        {
            DataAccess access = new DataAccess();
            int num = 0;
            DataTable data = access.GetData("select MAVATTU from KINH_VATTUKINH where MAVATTU like '%" + ngay + "%' order by MAVATTU ASC");
            if (data.Rows.Count > 0)
            {
                num = Convert.ToInt32(data.Rows[0][0].ToString().Substring(data.Rows[0][0].ToString().Length - 1));
            }
            string str = "000" + num++;
            return (ngay + str);
        }

        protected override void selectRecord()
        {
            if (base.listItems.SelectedIndices.Count >= 1)
            {
                ListViewItem item = base.listItems.SelectedItems[0];
                this.txtMaVT.Text = item.SubItems[0].Text;
                this.txtTenVT.Text = item.SubItems[1].Text;
                this.cboLVT.Text = item.SubItems[2].Text;
                this.cboLK.Text = item.SubItems[3].Text;
                this.cboCL.Text = item.SubItems[4].Text;
                this.cboNK.Text = item.SubItems[5].Text;
                this.cboQuiCach.Text = item.SubItems[6].Text;
                this.txtGiaBan.Text = item.SubItems[7].Text;
                this.txtDoKinh.Text = item.SubItems[8].Text;
            }
        }

        private void txtGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommonClass.testTextNumber(sender, e);
        }

        private void txtGiaBan_KeyUp(object sender, KeyEventArgs e)
        {
            if ((this.txtGiaBan.Text.Trim() != "") && ((int.Parse(this.txtGiaBan.Text.Trim()) / 0x3e8) > 0))
            {
                this.m_GiaBan = (int.Parse(this.txtGiaBan.Text.Trim()) / 0x3e8) + "";
                
                this.generateProductCode();              
                                    
            }
        }

        private void txtGiaBan_Leave(object sender, EventArgs e)
        {
        }

        private void txtMaVT_Leave(object sender, EventArgs e)
        {
            this.Barcode.CodeString = this.txtMaVT.Text;
        }

        protected override bool validateData()
        {
            if (m_MaVatTu != txtMaVT.Text)
            {
                DataAccess dba = new DataAccess();
                if (dba.GetData("select MaVatTu from KINH_VATTUKINH where MaVatTu='"+ UpdateForm.sqlEncode(txtMaVT.Text)+"'").Rows.Count>=1)
                {
                    MessageBox.Show("Mã kính này đã có, vui lòng điền mã khác!");
                    return false;
                }
            }
            return true;
        }

        protected override void btnModify_Click(object sender, EventArgs e)
        {
            base.btnModify_Click(sender, e);
            m_MaVatTu = txtMaVT.Text;
            
            if (this.cboLVT.Text.Trim() != "")
            {
                this.m_LoaiVT = UpdateForm.sqlEncode(cboLVT.Text);
            }
            if (this.cboNK.Text.Trim() != "")
            {
                this.m_Nhankinh = UpdateForm.sqlEncode(cboNK.Text);
            }

        }
        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            base.btnAdd_Click(sender, e);
            m_MaVatTu = "";
        }
    }
}

