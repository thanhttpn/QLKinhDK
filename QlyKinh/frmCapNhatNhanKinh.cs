namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmCapNhatNhanKinh : UpdateForm
    {
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private IContainer components = null;
        private Label label10;
        private Label label13;
        private Label label2;
        private Label label3;
        private TextBox txtMaNhanKinh;
        private TextBox txtTenNhanKinh;

        public frmCapNhatNhanKinh()
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
                if (base.Controls[i].GetType() == typeof(ComboBox))
                {
                    ((ComboBox) base.Controls[i]).Text = "";
                }
            }
            this.txtMaNhanKinh.Focus();
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

        private void frmCapNhatNhanKinh_Load(object sender, EventArgs e)
        {
        }

        protected override string getDeleteQuery()
        {
            return ("UPDATE KINH_NHAN SET DAXOA = 1 WHERE MANHAN='" + UpdateForm.sqlEncode(this.txtMaNhanKinh.Text.Trim()) + "'");
        }

        protected override string getInsertQuery()
        {
            return ("INSERT INTO KINH_NHAN(MANHAN,TENNHAN) VALUES('" + UpdateForm.sqlEncode(this.txtMaNhanKinh.Text) + "',N'" + UpdateForm.sqlEncode(this.txtTenNhanKinh.Text) + "')");
        }

        protected override string getSelectQuery()
        {
            return "SELECT * FROM KINH_NHAN where daxoa = 0";
        }

        protected override string getUpdateQuery()
        {
            return ("UPDATE KINH_NHAN SET TENNHAN=N'" + UpdateForm.sqlEncode(this.txtTenNhanKinh.Text) + "' WHERE MANHAN = '" + UpdateForm.sqlEncode(this.txtMaNhanKinh.Text) + "'");
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCapNhatNhanKinh));
            this.label13 = new System.Windows.Forms.Label();
            this.txtTenNhanKinh = new System.Windows.Forms.TextBox();
            this.txtMaNhanKinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(432, 360);
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.BackColor = System.Drawing.SystemColors.Desktop;
            this.grpBtnLine.Location = new System.Drawing.Point(8, 344);
            this.grpBtnLine.Size = new System.Drawing.Size(496, 4);
            // 
            // listItems
            // 
            this.listItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listItems.Location = new System.Drawing.Point(16, 112);
            this.listItems.Size = new System.Drawing.Size(488, 216);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(168, 352);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(8, 352);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Highlight;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(0, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(608, 32);
            this.label13.TabIndex = 28;
            this.label13.Text = "CẬP NHẬT NHÃN KÍNH";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTenNhanKinh
            // 
            this.txtTenNhanKinh.Location = new System.Drawing.Point(104, 64);
            this.txtTenNhanKinh.Name = "txtTenNhanKinh";
            this.txtTenNhanKinh.Size = new System.Drawing.Size(400, 22);
            this.txtTenNhanKinh.TabIndex = 32;
            // 
            // txtMaNhanKinh
            // 
            this.txtMaNhanKinh.Location = new System.Drawing.Point(104, 40);
            this.txtMaNhanKinh.Name = "txtMaNhanKinh";
            this.txtMaNhanKinh.Size = new System.Drawing.Size(152, 22);
            this.txtMaNhanKinh.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Tên Nhãn Kính:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Mã Nhãn Kính:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Highlight;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(16, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(488, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "DANH SÁCH NHÃN KÍNH ĐANG CÓ";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã Kính";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nhãn Kính";
            this.columnHeader2.Width = 350;
            // 
            // frmCapNhatNhanKinh
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(512, 390);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTenNhanKinh);
            this.Controls.Add(this.txtMaNhanKinh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label13);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCapNhatNhanKinh";
            this.Text = "Cap Nhat Nhan Kinh";
            this.Load += new System.EventHandler(this.frmCapNhatNhanKinh_Load);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtMaNhanKinh, 0);
            this.Controls.SetChildIndex(this.txtTenNhanKinh, 0);
            this.Controls.SetChildIndex(this.label10, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        protected override void selectRecord()
        {
            if (base.listItems.SelectedIndices.Count >= 1)
            {
                ListViewItem item = base.listItems.SelectedItems[0];
                this.txtMaNhanKinh.Text = item.SubItems[0].Text;
                this.txtTenNhanKinh.Text = item.SubItems[1].Text;
            }
        }

        protected override bool validateData()
        {
            return true;
        }
    }
}

