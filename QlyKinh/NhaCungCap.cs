namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class NhaCungCap : UpdateForm
    {
        private IContainer components = null;
        private ColumnHeader DiaChi;
        private ColumnHeader DienThoai;
        private ColumnHeader Email;
        private ColumnHeader GhiChu;
        private Label label10;
        private Label label13;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ColumnHeader MaNCC;
        private ColumnHeader TenNCC;
        private TextBox txtDiaChi;
        private TextBox txtDienThoai;
        private TextBox txtEmail;
        private TextBox txtGhiChu;
        private TextBox txtMaNCC;
        private TextBox txtTenNCC;

        public NhaCungCap()
        {
            this.InitializeComponent();
            this.enableControls(false);
            this.populateList();
        }

        protected override void clearControls()
        {
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (base.Controls[i].GetType() == typeof(TextBox))
                {
                    ((TextBox) base.Controls[i]).Text = "";
                }
            }
            this.txtTenNCC.Focus();
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
            }
            this.txtMaNCC.Enabled = false;
        }

        protected override string getDeleteQuery()
        {
            return ("DELETE KINH_NHACUNGCAP WHERE MANCC=" + this.txtMaNCC.Text);
        }

        protected override string getInsertQuery()
        {
            return ("INSERT INTO KINH_NHACUNGCAP(TENNCC,DIACHI,DIENTHOAI,EMAIL,GHICHU) VALUES(N'" + UpdateForm.sqlEncode(this.txtTenNCC.Text) + "',N'" + UpdateForm.sqlEncode(this.txtDiaChi.Text) + "',N'" + UpdateForm.sqlEncode(this.txtDienThoai.Text) + "',N'" + UpdateForm.sqlEncode(this.txtEmail.Text) + "',N'" + UpdateForm.sqlEncode(this.txtGhiChu.Text) + "')");
        }

        protected override string getSelectQuery()
        {
            return "SELECT * FROM KINH_NHACUNGCAP";
        }

        protected override string getUpdateQuery()
        {
            return ("UPDATE KINH_NHACUNGCAP SET TENNCC=N'" + UpdateForm.sqlEncode(this.txtTenNCC.Text) + "',DIACHI=N'" + UpdateForm.sqlEncode(this.txtDiaChi.Text) + "',DIENTHOAI=N'" + UpdateForm.sqlEncode(this.txtDienThoai.Text) + "',EMAIL=N'" + UpdateForm.sqlEncode(this.txtEmail.Text) + "',GHICHU=N'" + UpdateForm.sqlEncode(this.txtGhiChu.Text) + "' WHERE MANCC=" + UpdateForm.sqlEncode(this.txtMaNCC.Text));
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NhaCungCap));
            this.MaNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TenNCC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiaChi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DienThoai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.GhiChu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTenNCC = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMaNCC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(488, 488);
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.BackColor = System.Drawing.SystemColors.Desktop;
            this.grpBtnLine.Location = new System.Drawing.Point(12, 464);
            this.grpBtnLine.Size = new System.Drawing.Size(554, 5);
            // 
            // listItems
            // 
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MaNCC,
            this.TenNCC,
            this.DiaChi,
            this.DienThoai,
            this.Email,
            this.GhiChu});
            this.listItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listItems.Location = new System.Drawing.Point(4, 216);
            this.listItems.Size = new System.Drawing.Size(564, 240);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(200, 480);
            this.panCommand.Size = new System.Drawing.Size(260, 42);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(28, 480);
            this.panSaveCancel.Size = new System.Drawing.Size(180, 42);
            // 
            // MaNCC
            // 
            this.MaNCC.Text = "Mã NCC";
            this.MaNCC.Width = 0;
            // 
            // TenNCC
            // 
            this.TenNCC.Text = "Tên NCC";
            this.TenNCC.Width = 250;
            // 
            // DiaChi
            // 
            this.DiaChi.Text = "Địa Chỉ";
            this.DiaChi.Width = 200;
            // 
            // DienThoai
            // 
            this.DienThoai.Text = "Điện Thoại";
            this.DienThoai.Width = 93;
            // 
            // Email
            // 
            this.Email.Text = "Email";
            this.Email.Width = 0;
            // 
            // GhiChu
            // 
            this.GhiChu.Text = "Ghi Chú";
            this.GhiChu.Width = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tên NCC:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(29, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Địa Chỉ:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Điện Thoại:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Location = new System.Drawing.Point(216, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Location = new System.Drawing.Point(23, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ghi Chú:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(88, 40);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(480, 22);
            this.txtTenNCC.TabIndex = 12;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(88, 68);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(480, 22);
            this.txtDiaChi.TabIndex = 13;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(88, 96);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(120, 22);
            this.txtDienThoai.TabIndex = 14;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(264, 96);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(304, 22);
            this.txtEmail.TabIndex = 15;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(88, 124);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(480, 60);
            this.txtGhiChu.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(576, 32);
            this.label13.TabIndex = 27;
            this.label13.Text = "CẬP NHẬT NHÀ CUNG CẤP";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Highlight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(4, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(564, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "DANH SÁCH NHÀ CUNG CẤP";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(8, 164);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(44, 22);
            this.txtMaNCC.TabIndex = 29;
            this.txtMaNCC.Visible = false;
            // 
            // NhaCungCap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(576, 526);
            this.Controls.Add(this.txtMaNCC);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtDienThoai);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtTenNCC);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NhaCungCap";
            this.Text = "Nhà Cung Cấp";
            this.Load += new System.EventHandler(this.NhaCungCap_Load);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.txtTenNCC, 0);
            this.Controls.SetChildIndex(this.txtDiaChi, 0);
            this.Controls.SetChildIndex(this.txtDienThoai, 0);
            this.Controls.SetChildIndex(this.txtEmail, 0);
            this.Controls.SetChildIndex(this.txtGhiChu, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.txtMaNCC, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
        }

        protected override void selectRecord()
        {
            if (base.listItems.SelectedIndices.Count >= 1)
            {
                ListViewItem item = base.listItems.SelectedItems[0];
                this.txtMaNCC.Text = item.SubItems[0].Text;
                this.txtTenNCC.Text = item.SubItems[1].Text;
                this.txtDiaChi.Text = item.SubItems[2].Text;
                this.txtDienThoai.Text = item.SubItems[3].Text;
                this.txtEmail.Text = item.SubItems[4].Text;
                this.txtGhiChu.Text = item.SubItems[5].Text;
            }
        }

        protected override bool validateData()
        {
            return true;
        }
    }
}

