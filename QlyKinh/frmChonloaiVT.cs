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

    public class frmChonloaiVT : Form
    {
        private ArrayList arrMaLoaiVT;
        private ComboBox cboLoaiVT;
        private Button cmdThoat;
        private Button cmdXem;
        private Container components = null;
        private GroupBox groupBox1;
        private Label label1;

        public frmChonloaiVT()
        {
            this.InitializeComponent();
        }

        private void cmdThoat_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void cmdXem_Click(object sender, EventArgs e)
        {
            if (this.cboLoaiVT.SelectedIndex > -1)
            {
                DataAccess access = new DataAccess();
                DataSet dataSet = new DataSet();
                try
                {
                    access.CommandText = "PRC_TONKHO";
                    access.CommandType = CommandType.StoredProcedure;
                    access.AddParameter("@MaLoaiVT", DataType.VarChar, this.arrMaLoaiVT[this.cboLoaiVT.SelectedIndex].ToString());
                    access.Fill(dataSet, "PRC_TONKHO");

                    ReportViewer viewer = new ReportViewer(ConfigurationSettings.AppSettings.Get("ReportPath") + "rptTonKho.rpt", dataSet);
                    viewer.WindowState = FormWindowState.Maximized;
                    viewer.ShowDialog(this);
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Bạn phải chọn một loại vật tư để kiểm tra tồn kho", "Th\x00f4ng B\x00e1o");
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

        private void frmChonloaiVT_Load(object sender, EventArgs e)
        {
            this.load_allcboBoxInForm();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChonloaiVT));
            this.cboLoaiVT = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.cmdXem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboLoaiVT
            // 
            this.cboLoaiVT.Location = new System.Drawing.Point(32, 32);
            this.cboLoaiVT.Name = "cboLoaiVT";
            this.cboLoaiVT.Size = new System.Drawing.Size(232, 21);
            this.cboLoaiVT.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn Loại Vật Tư cần kiểm tra tồn kho :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdThoat);
            this.groupBox1.Controls.Add(this.cmdXem);
            this.groupBox1.Location = new System.Drawing.Point(0, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 100);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // cmdThoat
            // 
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdThoat.Location = new System.Drawing.Point(232, 16);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(56, 23);
            this.cmdThoat.TabIndex = 5;
            this.cmdThoat.Text = "Thoát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdXem
            // 
            this.cmdXem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdXem.Location = new System.Drawing.Point(88, 16);
            this.cmdXem.Name = "cmdXem";
            this.cmdXem.Size = new System.Drawing.Size(88, 23);
            this.cmdXem.TabIndex = 4;
            this.cmdXem.Text = "Xem Tồn Kho";
            this.cmdXem.Click += new System.EventHandler(this.cmdXem_Click);
            // 
            // frmChonloaiVT
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(296, 110);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLoaiVT);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmChonloaiVT";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loai vat tu";
            this.Load += new System.EventHandler(this.frmChonloaiVT_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        private void load_allcboBoxInForm()
        {
            string sql = "select * from KINH_LOAIVATTU  where DAXOA = 0";
            CommonClass.load_cboBox(this.cboLoaiVT, out this.arrMaLoaiVT, sql);
        }
    }
}

