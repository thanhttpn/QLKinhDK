namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using QLBV.DataAccess;    

    public class frmChonPhieuXuat : Form
    {
        private int check;
        private Button cmdChon;
        private Button cmdThoat;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Container components = null;
        public int iMaPXK;
        public int iSuccess;
        private Label label1;
        private Label label2;
        private ListView lswPXKCu;
        private TextBox txtMAPXK;

        public frmChonPhieuXuat()
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

        private void frmChonPhieuXuat_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonPhieuXuat));
            this.cmdChon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtMAPXK = new System.Windows.Forms.TextBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lswPXKCu = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // cmdChon
            // 
            this.cmdChon.BackColor = System.Drawing.SystemColors.Control;
            this.cmdChon.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdChon.Location = new System.Drawing.Point(97, 171);
            this.cmdChon.Name = "cmdChon";
            this.cmdChon.Size = new System.Drawing.Size(48, 23);
            this.cmdChon.TabIndex = 26;
            this.cmdChon.Text = "Chọn";
            this.cmdChon.UseVisualStyleBackColor = false;
            this.cmdChon.Click += new System.EventHandler(this.cmdChon_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Brown;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(9, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 4);
            this.label2.TabIndex = 28;
            // 
            // cmdThoat
            // 
            this.cmdThoat.BackColor = System.Drawing.SystemColors.Control;
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThoat.Location = new System.Drawing.Point(153, 171);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(48, 23);
            this.cmdThoat.TabIndex = 27;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.UseVisualStyleBackColor = false;
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày Xuất Kho";
            this.columnHeader2.Width = 180;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 29;
            this.label1.Text = "Chọn Mã Phiếu Xuất Kho";
            // 
            // txtMAPXK
            // 
            this.txtMAPXK.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMAPXK.Location = new System.Drawing.Point(9, 35);
            this.txtMAPXK.Name = "txtMAPXK";
            this.txtMAPXK.Size = new System.Drawing.Size(312, 22);
            this.txtMAPXK.TabIndex = 24;
            this.txtMAPXK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMAPXK_KeyDown);
            this.txtMAPXK.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMAPXK_KeyUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã PXK";
            this.columnHeader1.Width = 100;
            // 
            // lswPXKCu
            // 
            this.lswPXKCu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lswPXKCu.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lswPXKCu.FullRowSelect = true;
            this.lswPXKCu.GridLines = true;
            this.lswPXKCu.Location = new System.Drawing.Point(9, 59);
            this.lswPXKCu.Name = "lswPXKCu";
            this.lswPXKCu.Size = new System.Drawing.Size(311, 97);
            this.lswPXKCu.TabIndex = 25;
            this.lswPXKCu.UseCompatibleStateImageBehavior = false;
            this.lswPXKCu.View = System.Windows.Forms.View.Details;
            this.lswPXKCu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lswPXKCu_KeyDown);
            // 
            // frmChonPhieuXuat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(328, 198);
            this.Controls.Add(this.cmdChon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMAPXK);
            this.Controls.Add(this.lswPXKCu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmChonPhieuXuat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chon Phieu Xuat";
            this.Load += new System.EventHandler(this.frmChonPhieuXuat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void load_lswPXKCu()
        {
            this.lswPXKCu.Items.Clear();
            try
            {
                if (this.txtMAPXK.Text.Trim() != "")
                {
                    DataAccess access = new DataAccess();
                    foreach (DataRow row in access.GetData("SELECT * FROM view_ChonPhieuXuat where dbo.view_ChonPhieuXuat.MAPHIEUXUAT like '%" + this.txtMAPXK.Text + "%'").Rows)
                    {
                        ListViewItem item = new ListViewItem(new string[] { row[0].ToString(), row[1].ToString() });
                        this.lswPXKCu.Items.Add(item);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void lswPXKCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                this.iMaPXK = Convert.ToInt32(this.lswPXKCu.SelectedItems[0].SubItems[0].Text);
                this.txtMAPXK.Text = this.lswPXKCu.SelectedItems[0].SubItems[0].Text;
                base.Close();
                this.iSuccess = 1;
            }
        }

        private void txtMAPXK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                this.check = 1;
                this.lswPXKCu.Focus();
                this.lswPXKCu.Items[0].Selected = true;
            }
            if (e.KeyValue == 0x26)
            {
                this.check = 1;
                this.lswPXKCu.Focus();
                this.lswPXKCu.Items[0].Selected = true;
            }
            if (e.KeyValue == 13)
            {
                this.check = 1;
                try
                {
                    if (this.txtMAPXK.Text.Trim() != "")
                    {
                        DataAccess access = new DataAccess();
                        foreach (DataRow row in access.GetData("SELECT dbo.KINH_PHIEUXUAT.MAPHIEUXUAT FROM dbo.KINH_PHIEUXUAT where dbo.KINH_PHIEUXUAT.MAPHIEUXUAT like '%" + this.txtMAPXK.Text + "%'").Rows)
                        {
                            this.txtMAPXK.Text = row[0].ToString();
                            this.iMaPXK = Convert.ToInt32(row[0].ToString());
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

        private void txtMAPXK_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.check == 0)
            {
                try
                {
                    this.load_lswPXKCu();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
            }
        }
    }
}

