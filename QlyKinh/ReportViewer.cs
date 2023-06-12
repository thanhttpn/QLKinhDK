using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QLBV.DataAccess;
using System.IO;

namespace UI
{
    public class ReportViewer : Form
    {        
        private Container components;
        private int curLevel;
        public ReportDocument reportDoc;
        private static string TenBenhVien;
        private static string DiaChiBenhVien;
        private static string DienThoaiBenhVien;
        private static string EmailBenhVien;
        private static string TenCoSoKinhDoanh;
        private static string DiaChiBanHang;
        private static string LogoBenhVien;
        private Button btnPrintDirect;
        private Panel panel1;
        private CrystalReportViewer crViewer;
        private Panel panel2;
        private CheckBox chkXoay;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private int NumCopy = 1;
        
        
        public static ReportViewer instane
        {
            get
            {
                return new ReportViewer();
            }
        }
        public ReportViewer()
        {
            InitializeComponent();
        }

        public ReportViewer(ReportDocument rptDoc, DataSet dataSource)
        {
            curLevel = 3;
            components = null;
            InitializeComponent();
            reportDoc = rptDoc;            
            reportDoc.SetDataSource(dataSource);
            SetFormularValue("TenBenhVien", "Bệnh viện");
            crViewer.ReportSource = reportDoc;
            SetThongTinBenhVien(dataSource);

            DisplayStatusBar = false;
            DisplayTabBar = false;
        }
        public string RecordSelectionFormula
        {
            get
            {
                return reportDoc.RecordSelectionFormula;
            }
            set
            {
                reportDoc.RecordSelectionFormula = value;
            }
        }
        public void SetFormularValue(string paramName, string paramValue)
        {
            if (reportDoc != null)
            {
                for (int i = 0; i < reportDoc.DataDefinition.FormulaFields.Count; i++)
                {
                    if (reportDoc.DataDefinition.FormulaFields[i].FormulaName == "{@" + paramName + "}")
                        reportDoc.DataDefinition.FormulaFields[i].Text = "\"" + paramValue + "\"";
                }
            }
        }

        public ReportViewer(string rptSrc, DataSet dataSource)
        {
            if (!System.IO.File.Exists(rptSrc))
            {
                throw new Exception("Không tìm thấy file " + rptSrc);                
            }
            curLevel = 3;
            components = null;
            InitializeComponent();
            reportDoc.Load(rptSrc);            
            SetThongTinBenhVien(dataSource);
            

            if (dataSource.Tables.Count > 0)
            {
                reportDoc.SetDataSource(dataSource);
            }
            foreach (ReportDocument sub in reportDoc.Subreports)
            {
                sub.SetDataSource(dataSource);
            }
            crViewer.ReportSource = reportDoc;
            DisplayStatusBar = false;
            DisplayTabBar = false;
        }

        public ReportViewer(string rptSrc, DataSet dataSource, string formular)
		{
            if (!System.IO.File.Exists(rptSrc))
            {
                throw new Exception("Không tìm thấy file " + rptSrc);
            }
            curLevel = 3;
            components = null;
            InitializeComponent();
            reportDoc.Load(rptSrc);
            SetThongTinBenhVien(dataSource);

            if (dataSource.Tables.Count > 0)
            {
                reportDoc.SetDataSource(dataSource);
            }
            foreach (ReportDocument sub in reportDoc.Subreports)
            {
                sub.SetDataSource(dataSource);
            }
            crViewer.ReportSource = reportDoc;
            crViewer.SelectionFormula = formular;
            DisplayStatusBar = false;
            DisplayTabBar = false;

		}

        private void SetThongTinBenhVien(DataSet dataSource)
        {
            try
            {
                if (TenBenhVien == null)
                {
                    DataAccess dba = new DataAccess();
                    foreach (DataRow row in dba.GetData("Select * from BenhVien where SuDung=1").Rows)
                    {
                        TenBenhVien = row["TenBenhVien"].ToString();
                        DiaChiBenhVien = row["DiaChi"].ToString();
                        DienThoaiBenhVien = row["DienThoai"].ToString();
                        EmailBenhVien = row["Email"].ToString();
                        TenCoSoKinhDoanh = row["TenCoSoKinhDoanh"].ToString();
                        DiaChiBanHang = row["DiaChiBanHang"].ToString();
                        LogoBenhVien = row["Logo"].ToString();
                    }
                }
            }
            catch
            {

            }

            SetFormularValue("TenBenhVien", TenBenhVien);
            SetFormularValue("DiaChiBenhVien", DiaChiBenhVien);
            SetFormularValue("DienThoaiBenhVien", DienThoaiBenhVien);
            SetFormularValue("EmailBenhVien", EmailBenhVien);
            SetFormularValue("EmailBenhVien", EmailBenhVien);
            SetFormularValue("FDonVi", TenCoSoKinhDoanh);
            SetFormularValue("FDiaChi", DiaChiBanHang);
            if (File.Exists(LogoBenhVien))
            {
                SetFormularValue("LogoBenhVien", LogoBenhVien);
            }
            DataAccess dba1 = new DataAccess();
            foreach (DataRow row in dba1.GetData("select GetDate()").Rows)
            {
                SetFormularValue("NgayGioIn", row[0].ToString());
            }


        }

        private void crViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            ReportViewer_KeyPress(sender, e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private Control getPageView()
        {
            foreach (Control control in this.crViewer.Controls)
            {
                if (control is PageView)
                {
                    return control;
                }
            }
            return new Control();
        }

        private StatusBar getStatusBar()
        {
            foreach (object obj2 in this.crViewer.Controls)
            {
                if (obj2 is StatusBar)
                {
                    return (StatusBar) obj2;
                }
            }
            return new StatusBar();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportViewer));
            this.reportDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.btnPrintDirect = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.crViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkXoay = new System.Windows.Forms.CheckBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrintDirect
            // 
            this.btnPrintDirect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintDirect.Location = new System.Drawing.Point(0, 0);
            this.btnPrintDirect.Name = "btnPrintDirect";
            this.btnPrintDirect.Size = new System.Drawing.Size(656, 28);
            this.btnPrintDirect.TabIndex = 1;
            this.btnPrintDirect.Text = "In trực tiếp";
            this.btnPrintDirect.UseVisualStyleBackColor = true;
            this.btnPrintDirect.Click += new System.EventHandler(this.btnPrintDirect_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.crViewer);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(755, 533);
            this.panel1.TabIndex = 2;
            // 
            // crViewer
            // 
            this.crViewer.ActiveViewIndex = -1;
            this.crViewer.AutoSize = true;
            this.crViewer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.crViewer.BackColor = System.Drawing.SystemColors.Control;
            this.crViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crViewer.DisplayBackgroundEdge = false;
            this.crViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crViewer.Location = new System.Drawing.Point(0, 28);
            this.crViewer.Name = "crViewer";
            this.crViewer.SelectionFormula = "";
            this.crViewer.ShowCloseButton = false;
            this.crViewer.ShowGroupTreeButton = false;
            this.crViewer.ShowRefreshButton = false;
            this.crViewer.ShowTextSearchButton = false;
            this.crViewer.Size = new System.Drawing.Size(755, 505);
            this.crViewer.TabIndex = 1;
            this.crViewer.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crViewer.ViewTimeSelectionFormula = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chkXoay);
            this.panel2.Controls.Add(this.btnPrintDirect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 28);
            this.panel2.TabIndex = 2;
            // 
            // chkXoay
            // 
            this.chkXoay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkXoay.AutoSize = true;
            this.chkXoay.Location = new System.Drawing.Point(662, 5);
            this.chkXoay.Name = "chkXoay";
            this.chkXoay.Size = new System.Drawing.Size(81, 17);
            this.chkXoay.TabIndex = 3;
            this.chkXoay.Text = "Xoay 90 độ";
            this.chkXoay.UseVisualStyleBackColor = true;
            // 
            // ReportViewer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(755, 533);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ReportViewer";
            this.Text = "Report Viewer";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ReportViewer_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ReportViewer_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ReportViewer_KeyPress(object sender, KeyPressEventArgs e)
        {
            int[] numArray = new int[] { 0x19, 50, 0x4b, 100, 200, 300, 400 };           
            if (e.KeyChar == 'p')
            {
                this.crViewer.PrintReport();
            }
            else if (e.KeyChar == 'x')
            {
                this.crViewer.ExportReport();
            }
            else if (e.KeyChar == '-')
            {
                curLevel -= (this.curLevel == 0) ? 0 : 1;
                crViewer.Zoom(numArray[this.curLevel]);
            }
            else if (e.KeyChar == '+')
            {
                curLevel += (this.curLevel == 6) ? 0 : 1;
                crViewer.Zoom(numArray[this.curLevel]);
            }
            else if (e.KeyChar == '\x001b')
            {
                base.Close();
            }            
        }

        private bool DisplayStatusBar
        {
            get
            {
                return this.getStatusBar().Visible;
            }
            set
            {
                this.getStatusBar().Visible = value;
            }
        }

        public bool DisplayTabBar
        {
            set
            {
                TabControl control = (TabControl) this.getPageView().Controls[0];
                if (!value)
                {
                    control.ItemSize = new Size(0, 1);
                    control.SizeMode = TabSizeMode.Fixed;
                    control.Appearance = TabAppearance.FlatButtons;
                }
                else
                {
                    control.ItemSize = new Size(0, 20);
                    control.SizeMode = TabSizeMode.Normal;
                    control.Appearance = TabAppearance.Normal;
                }
            }
        }

        public string PrinterName
        {
            get
            {
                return reportDoc.PrintOptions.PrinterName;
            }
            set
            {
                reportDoc.PrintOptions.PrinterName = value;                
            }
        }

        private void btnPrintDirect_Click(object sender, EventArgs e)
        {
            Print();
            btnPrintDirect.Enabled = false;       
        }

        private void Print()
        {
            {
                try
                {
                    if (reportDoc.PrintOptions.PaperSource == CrystalDecisions.Shared.PaperSource.Manual)
                    {
                        reportDoc.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Auto;
                    }
                    //if (EndPage <= 1)
                    //{
                    //    crViewer.ShowLastPage();
                    //    EndPage = crViewer.GetCurrentPageNumber();
                    //}

                }
                catch
                {
                }                
                reportDoc.PrintToPrinter(NumCopy, false, 0, 0);
            }
        }

        private void exportToPDF()
        {
            reportDoc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Application.StartupPath + "\\tam.pdf");
        }

        

        private void ReportViewer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue > 96 && e.KeyValue <= 105)
            {
                NumCopy = e.KeyValue - 96;
                btnPrintDirect_Click(sender, null);
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                NumCopy = 1;
                btnPrintDirect_Click(sender, null);
            }            
        }

    }
}

