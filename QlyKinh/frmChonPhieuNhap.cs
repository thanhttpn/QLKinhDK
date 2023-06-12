namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;
    using QLBV.DataAccess;    

    public class frmChonPhieuNhap : Form
    {
        private int check;
        private Button cmdChon;
        private Button cmdThoat;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Container components = null;
        public int iMaPNK;
        public int iSuccess;
        private Label label1;
        private Label label2;
        private ListView lswPNKCu;
        private Label tungay;
        private TextBox txtMAPNK;

        public frmChonPhieuNhap()
        {
            this.InitializeComponent();
            this.check = 0;
        }

        private void cmdChon_Click(object sender, EventArgs e)
        {
            base.Close();
            this.iSuccess = 1;
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            base.Close();
            this.iSuccess = 0;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmChonPhieuNhap_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonPhieuNhap));
            this.txtMAPNK = new System.Windows.Forms.TextBox();
            this.lswPNKCu = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmdChon = new System.Windows.Forms.Button();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMAPNK
            // 
            this.txtMAPNK.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAPNK.Location = new System.Drawing.Point(8, 32);
            this.txtMAPNK.Name = "txtMAPNK";
            this.txtMAPNK.Size = new System.Drawing.Size(312, 22);
            this.txtMAPNK.TabIndex = 0;
            this.txtMAPNK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMAPNK_KeyDown);
            this.txtMAPNK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMAPNK_KeyUp);
            // 
            // lswPNKCu
            // 
            this.lswPNKCu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lswPNKCu.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lswPNKCu.FullRowSelect = true;
            this.lswPNKCu.GridLines = true;
            this.lswPNKCu.Location = new System.Drawing.Point(8, 56);
            this.lswPNKCu.Name = "lswPNKCu";
            this.lswPNKCu.Size = new System.Drawing.Size(312, 97);
            this.lswPNKCu.TabIndex = 1;
            this.lswPNKCu.UseCompatibleStateImageBehavior = false;
            this.lswPNKCu.View = System.Windows.Forms.View.Details;
            this.lswPNKCu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lswPNKCu_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã PNK";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày Nhập Kho";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nhà Cung Cấp";
            this.columnHeader3.Width = 100;
            // 
            // cmdChon
            // 
            this.cmdChon.BackColor = System.Drawing.SystemColors.Control;
            this.cmdChon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdChon.Location = new System.Drawing.Point(96, 168);
            this.cmdChon.Name = "cmdChon";
            this.cmdChon.Size = new System.Drawing.Size(48, 23);
            this.cmdChon.TabIndex = 2;
            this.cmdChon.Text = "Chọn";
            this.cmdChon.UseVisualStyleBackColor = false;
            this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
            // 
            // cmdThoat
            // 
            this.cmdThoat.BackColor = System.Drawing.SystemColors.Control;
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThoat.Location = new System.Drawing.Point(152, 168);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(48, 23);
            this.cmdThoat.TabIndex = 3;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.UseVisualStyleBackColor = false;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Brown;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 4);
            this.label2.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "Chọn Mã Phiếu Nhập Kho";
            // 
            // frmChonPhieuNhap
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(328, 198);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdChon);
            this.Controls.Add(this.txtMAPNK);
            this.Controls.Add(this.lswPNKCu);
            this.Controls.Add(this.cmdThoat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonPhieuNhap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chon Phieu Nhap";
            this.Load += new System.EventHandler(this.frmChonPhieuNhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void load_lswPNKCu()
        {
            this.lswPNKCu.Items.Clear();
            try
            {
                if (this.txtMAPNK.Text.Trim() != "")
                {
                    DataAccess access = new DataAccess();
                    foreach (DataRow row in access.GetData("SELECT * FROM view_ChonPhieuNhap where dbo.view_ChonPhieuNhap.MAPHIEUNHAP like '%" + this.txtMAPNK.Text + "%'").Rows)
                    {
                        ListViewItem item = new ListViewItem(new string[] { row[0].ToString(), row[1].ToString(), row[2].ToString() });
                        this.lswPNKCu.Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void lswPNKCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.iMaPNK = Convert.ToInt32(this.lswPNKCu.SelectedItems[0].SubItems[0].Text);
                this.txtMAPNK.Text = this.lswPNKCu.SelectedItems[0].SubItems[0].Text;
                base.Close();
                this.iSuccess = 1;
            }
        }

        private void txtMAPNK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                this.check = 1;
                this.lswPNKCu.Focus();
                this.lswPNKCu.Items[0].Selected = true;
            }
            if (e.KeyValue == 0x26)
            {
                this.check = 1;
                this.lswPNKCu.Focus();
                this.lswPNKCu.Items[0].Selected = true;
            }
            if (e.KeyValue == 13)
            {
                this.check = 1;
                try
                {
                    if (this.txtMAPNK.Text.Trim() != "")
                    {
                        DataAccess access = new DataAccess();
                        foreach (DataRow row in access.GetData("SELECT dbo.KINH_PHIEUNHAP.MAPHIEUNHAP FROM dbo.KINH_NHACUNGCAP INNER JOIN dbo.KINH_PHIEUNHAP ON dbo.KINH_NHACUNGCAP.MANCC = dbo.KINH_PHIEUNHAP.MANCC where dbo.KINH_PHIEUNHAP.MAPHIEUNHAP like '%" + this.txtMAPNK.Text + "%'").Rows)
                        {
                            this.txtMAPNK.Text = row[0].ToString();
                            this.iMaPNK = Convert.ToInt32(row[0].ToString());
                        }
                    }
                    base.Close();
                    this.iSuccess = 1;
                }
                catch
                {
                    MessageBox.Show("M\x00e3 h\x00f3a đơn n\x00e0y kh\x00f4ng tồn tại. Mời nhập lại", "Th\x00f4ng b\x00e1o");
                }
            }
            else if (((e.KeyValue != 0x26) && (e.KeyValue != 40)) && (e.KeyValue != 13))
            {
                this.check = 0;
            }
        }

        private void txtMAPNK_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.check == 0)
            {
                try
                {
                    this.load_lswPNKCu();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
            }
        }
    }
}

