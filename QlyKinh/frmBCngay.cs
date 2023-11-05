namespace QlyKinh
{
    using CrystalDecisions.CrystalReports.Engine;    
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Resources;
    using System.Windows.Forms;
    using QLBV.DataAccess;
    using System.Configuration;
    using DHospital;

    public class frmBCngay : Form
    {
        private Button cmdthoat;
        private Button cmdxem;
        private Container components = null;
        private Label denngay;
        private DateTimePicker dtdenngay;
        private DateTimePicker dttungay;
        private Label label2;
        private int loai;
        private Panel panel1;
        private Label tungay;

        public frmBCngay(int l)
        {
            this.InitializeComponent();
            this.loai = l;
        }

        private void active_Report(string storeStr, string reportName)
        {
            base.ShowInTaskbar = false;
            base.Visible = false;
            DataAccess access = new DataAccess();
            DataSet dataSet = new DataSet();
            try
            {
                access.CommandText = storeStr;
                access.CommandType = CommandType.StoredProcedure;
                access.AddParameter("@TuNgay", DataType.Date, Convert.ToDateTime(this.dttungay.Value.ToShortDateString()));
                access.AddParameter("@DenNgay", DataType.Date, Convert.ToDateTime(this.dtdenngay.Value.ToShortDateString()));
                access.Fill(dataSet, storeStr);
                ReportViewer viewer = new ReportViewer(reportName, dataSet);
                viewer.WindowState = FormWindowState.Maximized;
                viewer.ShowDialog(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void active_Report(string strSql, string strSourceTable, ReportDocument reportName)
        {
            base.ShowInTaskbar = false;
            base.Visible = false;
            DataAccess access = new DataAccess();
            DataSet dataSet = new DataSet();
            try
            {
                access.CommandText = strSql;
                access.Fill(dataSet, strSourceTable);
                ReportViewer viewer = new ReportViewer(reportName, dataSet);
                viewer.WindowState = FormWindowState.Maximized;
                viewer.ShowDialog(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message.ToString());
            }
        }

        private void cmdthoat_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void cmdxem_Click(object sender, EventArgs e)
        {
            switch (this.loai)
            {
                case 0:
                    this.active_Report("PRC_BCNHAPKHO", ConfigurationSettings.AppSettings.Get("ReportPath") + "rptTKeNhapKho.rpt");
                    break;

                case 1:
                    this.active_Report("PRC_BCXUATKHO", ConfigurationSettings.AppSettings.Get("ReportPath") + "rptTKXuatKho.rpt");
                    break;

                case 2:
                    this.active_Report("PRC_XNTKK", ConfigurationSettings.AppSettings.Get("ReportPath") + "rptXNTK.rpt");
                    break;

                case 3:
                    this.active_Report("PRC_TKKX", ConfigurationSettings.AppSettings.Get("ReportPath") + "rptTKTX.rpt");
                    break;

                case 4:
                    this.active_Report("PRC_TKCTKBCKH", ConfigurationSettings.AppSettings.Get("ReportPath") + "rptTKTBCBNCT.rpt");
                    break;

                case 5:
                    this.active_Report("PRC_TKKN", ConfigurationSettings.AppSettings.Get("ReportPath") + "rptTKTN.rpt");
                    break;

                case 6:
                    this.active_Report("PRC_TINHTIENBANKINH", ConfigurationSettings.AppSettings.Get("ReportPath") + "rptBCTCTT_Sua1.rpt");
                    break;
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

        private void frmBCngay_Load(object sender, EventArgs e)
        {
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBCngay));
            this.dttungay = new System.Windows.Forms.DateTimePicker();
            this.dtdenngay = new System.Windows.Forms.DateTimePicker();
            this.tungay = new System.Windows.Forms.Label();
            this.denngay = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdthoat = new System.Windows.Forms.Button();
            this.cmdxem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dttungay
            // 
            this.dttungay.CustomFormat = "dd/MM/yyyy";
            this.dttungay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttungay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dttungay.Location = new System.Drawing.Point(66, 17);
            this.dttungay.Name = "dttungay";
            this.dttungay.Size = new System.Drawing.Size(88, 22);
            this.dttungay.TabIndex = 0;
            // 
            // dtdenngay
            // 
            this.dtdenngay.CustomFormat = "dd/MM/yyyy";
            this.dtdenngay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtdenngay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtdenngay.Location = new System.Drawing.Point(227, 17);
            this.dtdenngay.Name = "dtdenngay";
            this.dtdenngay.Size = new System.Drawing.Size(88, 22);
            this.dtdenngay.TabIndex = 1;
            // 
            // tungay
            // 
            this.tungay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tungay.Location = new System.Drawing.Point(6, 20);
            this.tungay.Name = "tungay";
            this.tungay.Size = new System.Drawing.Size(58, 16);
            this.tungay.TabIndex = 2;
            this.tungay.Text = "Từ ngày";
            // 
            // denngay
            // 
            this.denngay.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.denngay.Location = new System.Drawing.Point(160, 20);
            this.denngay.Name = "denngay";
            this.denngay.Size = new System.Drawing.Size(65, 16);
            this.denngay.TabIndex = 3;
            this.denngay.Text = "Đến ngày";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmdthoat);
            this.panel1.Controls.Add(this.cmdxem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 24);
            this.panel1.TabIndex = 8;
            // 
            // cmdthoat
            // 
            this.cmdthoat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdthoat.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdthoat.Location = new System.Drawing.Point(264, 0);
            this.cmdthoat.Name = "cmdthoat";
            this.cmdthoat.Size = new System.Drawing.Size(48, 23);
            this.cmdthoat.TabIndex = 8;
            this.cmdthoat.Text = "Thoát";
            this.cmdthoat.Click += new System.EventHandler(this.cmdthoat_Click);
            // 
            // cmdxem
            // 
            this.cmdxem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdxem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdxem.Location = new System.Drawing.Point(213, 0);
            this.cmdxem.Name = "cmdxem";
            this.cmdxem.Size = new System.Drawing.Size(48, 23);
            this.cmdxem.TabIndex = 7;
            this.cmdxem.Text = "Xem";
            this.cmdxem.Click += new System.EventHandler(this.cmdxem_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Brown;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(8, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(304, 4);
            this.label2.TabIndex = 10;
            // 
            // frmBCngay
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(320, 86);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.denngay);
            this.Controls.Add(this.tungay);
            this.Controls.Add(this.dtdenngay);
            this.Controls.Add(this.dttungay);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBCngay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Theo ngày";
            this.Load += new System.EventHandler(this.frmBCngay_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
    }
}

