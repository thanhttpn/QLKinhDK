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
    using System.Configuration;
    using DHospital;    

    public class frmTheKho : Form
    {
        private ArrayList arrMaThuoc;
        private int check;
        private Button cmdThoat;
        private Button cmdXemTK;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader9;
        private Container components = null;
        private DataAccess dba;
        private DateTimePicker dtpDenNgay;
        private DateTimePicker dtpTuNgay;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label13;
        private Label label30;
        private Label lable;
        private ListView lswTenThuoc;
        private TextBox txtMaThuoc;
        private TextBox txtTenThuoc;

        public frmTheKho()
        {
            this.InitializeComponent();
            this.check = 0;
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void cmdXemTK_Click(object sender, EventArgs e)
        {
            if (this.txtMaThuoc.Text.Trim() == "")
            {
                MessageBox.Show("Vui l\x00f2ng chọn một thuốc cần kiểm tra trong thẻ kho", "Th\x00f4ng B\x00e1o");
            }
            else
            {
                base.ShowInTaskbar = false;
                base.Visible = false;
                this.dba = new DataAccess();
                DataSet dataSet = new DataSet();
                try
                {
                    this.dba.CommandText = "PRC_THEKHO";
                    this.dba.CommandType = CommandType.StoredProcedure;
                    this.dba.AddParameter("@MaVatTu", DataType.VarChar, this.txtMaThuoc.Text.Trim());
                    this.dba.AddParameter("@TuNgay", DataType.Date, Convert.ToDateTime(this.dtpTuNgay.Value.ToShortDateString()));
                    this.dba.AddParameter("@DenNgay", DataType.Date, Convert.ToDateTime(this.dtpDenNgay.Value.ToShortDateString()));
                    this.dba.Fill(dataSet, "PRC_THEKHO");                    
                    ReportViewer viewer = new ReportViewer(ConfigurationSettings.AppSettings.Get("ReportPath") + "rptViewTheKho.rpt", dataSet);
                    viewer.WindowState = FormWindowState.Maximized;
                    viewer.ShowDialog(this);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmTheKho_Load(object sender, EventArgs e)
        {
            base.ActiveControl = this.txtTenThuoc;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTheKho));
            this.label13 = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.cmdXemTK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.txtTenThuoc = new System.Windows.Forms.TextBox();
            this.lable = new System.Windows.Forms.Label();
            this.lswTenThuoc = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtMaThuoc = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(518, 32);
            this.label13.TabIndex = 177;
            this.label13.Text = "LẬP THẺ KHO";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTuNgay.Location = new System.Drawing.Point(112, 96);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(136, 20);
            this.dtpTuNgay.TabIndex = 168;
            // 
            // cmdXemTK
            // 
            this.cmdXemTK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdXemTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdXemTK.Location = new System.Drawing.Point(176, 180);
            this.cmdXemTK.Name = "cmdXemTK";
            this.cmdXemTK.Size = new System.Drawing.Size(160, 23);
            this.cmdXemTK.TabIndex = 170;
            this.cmdXemTK.Text = "&Xem Thẻ Kho";
            this.cmdXemTK.Click += new System.EventHandler(this.cmdXemTK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 2);
            this.groupBox1.TabIndex = 176;
            this.groupBox1.TabStop = false;
            // 
            // label30
            // 
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.Location = new System.Drawing.Point(8, 96);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 23);
            this.label30.TabIndex = 174;
            this.label30.Text = "Từ Ngày";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 173;
            this.label1.Text = "Đến Ngày";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmdThoat
            // 
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdThoat.Location = new System.Drawing.Point(432, 180);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(75, 23);
            this.cmdThoat.TabIndex = 171;
            this.cmdThoat.Text = "&Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 4);
            this.groupBox2.TabIndex = 175;
            this.groupBox2.TabStop = false;
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dtpDenNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDenNgay.Location = new System.Drawing.Point(376, 96);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(136, 20);
            this.dtpDenNgay.TabIndex = 169;
            // 
            // txtTenThuoc
            // 
            this.txtTenThuoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTenThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenThuoc.Location = new System.Drawing.Point(112, 56);
            this.txtTenThuoc.Name = "txtTenThuoc";
            this.txtTenThuoc.Size = new System.Drawing.Size(396, 20);
            this.txtTenThuoc.TabIndex = 178;
            this.txtTenThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenThuoc_KeyDown);
            this.txtTenThuoc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtTenThuoc_KeyUp);
            // 
            // lable
            // 
            this.lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.Location = new System.Drawing.Point(4, 56);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(104, 23);
            this.lable.TabIndex = 179;
            this.lable.Text = "Tên vật tư";
            this.lable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lswTenThuoc
            // 
            this.lswTenThuoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.lswTenThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lswTenThuoc.FullRowSelect = true;
            this.lswTenThuoc.GridLines = true;
            this.lswTenThuoc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lswTenThuoc.HideSelection = false;
            this.lswTenThuoc.Location = new System.Drawing.Point(112, 80);
            this.lswTenThuoc.Name = "lswTenThuoc";
            this.lswTenThuoc.Size = new System.Drawing.Size(396, 80);
            this.lswTenThuoc.TabIndex = 180;
            this.lswTenThuoc.UseCompatibleStateImageBehavior = false;
            this.lswTenThuoc.View = System.Windows.Forms.View.Details;
            this.lswTenThuoc.Visible = false;
            this.lswTenThuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lswTenThuoc_KeyDown);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mã Kính";
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tên Kính";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 290;
            // 
            // txtMaThuoc
            // 
            this.txtMaThuoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtMaThuoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaThuoc.Location = new System.Drawing.Point(4, 184);
            this.txtMaThuoc.Name = "txtMaThuoc";
            this.txtMaThuoc.Size = new System.Drawing.Size(20, 20);
            this.txtMaThuoc.TabIndex = 181;
            this.txtMaThuoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaThuoc.Visible = false;
            // 
            // frmTheKho
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(518, 208);
            this.Controls.Add(this.txtMaThuoc);
            this.Controls.Add(this.lswTenThuoc);
            this.Controls.Add(this.lable);
            this.Controls.Add(this.txtTenThuoc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.cmdXemTK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdThoat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dtpDenNgay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTheKho";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lap The Kho";
            this.Load += new System.EventHandler(this.frmTheKho_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void load_lswTenThuoc()
        {
            this.arrMaThuoc = new ArrayList();
            this.lswTenThuoc.Items.Clear();
            this.dba = new DataAccess();
            try
            {
                foreach (DataRow row in this.dba.GetData("select MAVATTU, TENVATTU from KINH_VATTUKINH where TENVATTU like N'%" + this.txtTenThuoc.Text + "%' AND DAXOA = 0").Rows)
                {
                    this.arrMaThuoc.Add(row[0].ToString());
                    ListViewItem item = new ListViewItem(new string[] { row[0].ToString(), row[1].ToString() });
                    this.lswTenThuoc.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void lswTenThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    this.txtMaThuoc.Text = this.lswTenThuoc.SelectedItems[0].SubItems[0].Text;
                    this.txtTenThuoc.Text = this.lswTenThuoc.SelectedItems[0].SubItems[1].Text;
                    this.lswTenThuoc.Visible = false;
                    this.dtpTuNgay.Focus();
                }
                catch
                {
                    MessageBox.Show("T\x00ean Thuốc N\x00e0y Kh\x00f4ng Tồn Tại. Mời Nhập Lại", "Th\x00f4ng B\x00e1o");
                    base.ActiveControl = this.txtTenThuoc;
                    this.txtTenThuoc.Text = "";
                }
            }
        }

        private void txtTenThuoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 40)
            {
                this.check = 1;
                this.lswTenThuoc.Focus();
                this.lswTenThuoc.Items[0].Selected = true;
            }
            if (e.KeyValue == 0x26)
            {
                this.check = 1;
                this.lswTenThuoc.Focus();
                this.lswTenThuoc.Items[0].Selected = true;
            }
            if (e.KeyValue == 13)
            {
                try
                {
                    this.txtMaThuoc.Text = this.lswTenThuoc.SelectedItems[0].SubItems[0].Text;
                    this.txtTenThuoc.Text = this.lswTenThuoc.SelectedItems[0].SubItems[1].Text;
                    if (CommonClass.testTextNumber(this.txtMaThuoc.Text))
                    {
                        MessageBox.Show("T\x00ean thuốc bạn chọn kh\x00f4ng c\x00f3 trong danh mục, y\x00eau cầu cập nhập danh mục thuốc trước khi d\x00f9ng", "Th\x00f4ng B\x00e1o");
                        base.ActiveControl = this.txtTenThuoc;
                    }
                    else
                    {
                        this.lswTenThuoc.Visible = false;
                        this.dba = new DataAccess();
                        try
                        {
                            foreach (DataRow row in this.dba.GetData("select MAVATTU, TENVATTU from KINH_VATTUKINH where TENVATTU like N'%" + this.txtTenThuoc.Text + "%' AND DAXOA = 0").Rows)
                            {
                                this.txtMaThuoc.Text = row[0].ToString();
                                this.txtTenThuoc.Text = row[1].ToString();
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.Message.ToString());
                        }
                        this.dtpTuNgay.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("T\x00ean Thuốc N\x00e0y Kh\x00f4ng Tồn Tại. Mời Nhập Lại", "Th\x00f4ng B\x00e1o");
                    base.ActiveControl = this.txtTenThuoc;
                    this.txtTenThuoc.Text = "";
                }
            }
            else if (((e.KeyValue != 0x26) && (e.KeyValue != 40)) && (e.KeyValue != 13))
            {
                this.check = 0;
            }
        }

        private void txtTenThuoc_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.check == 0)
                {
                    this.load_lswTenThuoc();
                    if ((this.lswTenThuoc.Items.Count > 0) && (this.txtTenThuoc.Text != ""))
                    {
                        this.lswTenThuoc.Visible = true;
                    }
                    else
                    {
                        this.lswTenThuoc.Visible = false;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }
    }
}

