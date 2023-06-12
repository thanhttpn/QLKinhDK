namespace QlyKinh
{
    using CrystalDecisions.CrystalReports.Engine;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using QLBV.DataAccess;
    using UI;


    public class frmUpdateForm_Multi : UpdateForm
    {
        protected Button cmdInPhieu;
        private IContainer components = null;
        private int m_checkDelete = 0;
        public int m_checkInStock;
        protected TextBox txtTongTien;

        public frmUpdateForm_Multi()
        {
            this.InitializeComponent();
        }

        protected override void btnAdd_Click(object sender, EventArgs e)
        {
            this.enableControls(true);
            base.panCommand.Visible = false;
            base.panSaveCancel.Visible = true;
            base.listItems.Enabled = true;
            this.clearControls();
            base.isModify = false;
            base.listItems.Items.Clear();
        }

        protected override void btnModify_Click(object sender, EventArgs e)
        {
            this.enableControls(true);
            base.panCommand.Visible = false;
            base.panSaveCancel.Visible = true;
            base.listItems.Enabled = true;
            base.isModify = true;
        }

        protected override void btnRemove_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Bạn c\x00f3 chắc muốn x\x00f3a?", "Th\x00f4ng b\x00e1o", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                DataAccess access = new DataAccess();
                try
                {
                    access.BeginTransaction();
                    if (this.m_checkInStock == 0)
                    {
                        for (int i = 0; i < base.listItems.Items.Count; i++)
                        {
                            this.Check_InStock(base.listItems.Items[i].SubItems[1].Text, base.listItems.Items[i].SubItems[2].Text, Convert.ToInt32(base.listItems.Items[i].SubItems[3].Text));
                        }
                    }
                    if (this.m_checkDelete != 1)
                    {
                        access.CommandText = this.getDeleteQueryMain() + base.listItems.Items[0].SubItems[0].Text + "'";
                        access.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Chỉ c\x00f3 thể x\x00f3a được c\x00e1c Vật Tư kh\x00f4ng c\x00f3 b\x00e1o lỗi", "Th\x00f4ng B\x00e1o");
                    }
                }
                catch (Exception exception)
                {
                    access.Rollback();
                    MessageBox.Show("C\x00f3 lỗi khi x\x00f3a. Th\x00f4ng tin lỗi như sau:\n" + exception.Message, "Th\x00f4ng B\x00e1o");
                }
                finally
                {
                    access.EndTransaction();
                    base.panCommand.Visible = false;
                    base.panCommand.Visible = true;
                    base.panSaveCancel.Visible = false;
                    this.enableControls(false);
                    this.clearControls();
                    base.listItems.Enabled = false;
                    base.listItems.Items.Clear();
                }
            }
        }

        protected override void btnSave_Click(object sender, EventArgs e)
        {
            if (this.validateData())
            {
                DataAccess access = new DataAccess();
                try
                {
                    access.BeginTransaction();
                    if (!base.isModify)
                    {
                        if (base.listItems.Items.Count > 0)
                        {
                            access.CommandText = this.getInsertQueryMain();
                            access.ExecuteNonQuery();
                            string str = "";
                            foreach (DataRow row in access.GetData("SELECT distinct ident_current('" + this.getMainTable() + "') from " + this.getMainTable()).Rows)
                            {
                                str = row[0].ToString();
                            }
                            for (int k = 0; k < base.listItems.Items.Count; k++)
                            {
                                base.listItems.Items[k].SubItems[0].Text = str;
                            }
                            ArrayList list = this.getParameterNameDetail();
                            DataType[] typeArray = this.getDataTypeDetail();
                            for (int m = 0; m < list.Count; m++)
                            {
                                access.AddParameter(list[m].ToString(), typeArray[m]);
                            }
                            for (int n = 0; n < base.listItems.Items.Count; n++)
                            {
                                access.CommandText = this.getInsertQueryDetail();
                                for (int num4 = 0; num4 < list.Count; num4++)
                                {
                                    if (num4 < 2)
                                    {
                                        access.SetParameterValue(list[num4].ToString(), this.getValue(typeArray[num4], base.listItems.Items[n].SubItems[num4].Text));
                                    }
                                    else
                                    {
                                        access.SetParameterValue(list[num4].ToString(), this.getValue(typeArray[num4], base.listItems.Items[n].SubItems[num4 + 1].Text));
                                    }
                                }
                                access.ExecuteNonQuery();
                            }
                            MessageBox.Show("Phiếu  đ\x00e3 lưu mới th\x00e0nh c\x00f4ng", "Th\x00f4ng b\x00e1o");
                        }
                        else
                        {
                            MessageBox.Show("Phải c\x00f3 \x00edt nhất một chi tiết của phiếu", "Th\x00f4ng B\x00e1o");
                        }
                    }
                    else
                    {
                        access.CommandText = this.getDeleteQueryDetail() + base.listItems.Items[0].SubItems[0].Text + "'";
                        access.ExecuteNonQuery();
                        ArrayList list2 = this.getParameterNameDetail();
                        DataType[] typeArray2 = this.getDataTypeDetail();
                        for (int num5 = 0; num5 < list2.Count; num5++)
                        {
                            access.AddParameter(list2[num5].ToString(), typeArray2[num5]);
                        }
                        for (int num6 = 0; num6 < base.listItems.Items.Count; num6++)
                        {
                            access.CommandText = this.getInsertQueryDetail();
                            for (int num7 = 0; num7 < list2.Count; num7++)
                            {
                                if (num7 < 2)
                                {
                                    access.SetParameterValue(list2[num7].ToString(), this.getValue(typeArray2[num7], base.listItems.Items[num6].SubItems[num7].Text));
                                }
                                else
                                {
                                    access.SetParameterValue(list2[num7].ToString(), this.getValue(typeArray2[num7], base.listItems.Items[num6].SubItems[num7 + 1].Text));
                                }
                            }
                            access.ExecuteNonQuery();
                        }
                        MessageBox.Show("Phiếu  đ\x00e3 sửa th\x00e0nh c\x00f4ng", "Th\x00f4ng b\x00e1o");
                    }
                    double num8 = 0.0;
                    int num9 = 0;
                    for (int i = 0; i < base.listItems.Items.Count; i++)
                    {
                        double num11 = Convert.ToDouble(base.listItems.Items[i].SubItems[3].Text) * Convert.ToDouble(base.listItems.Items[i].SubItems[4].Text);
                        num9 = base.listItems.Columns.Count - 1;
                        base.listItems.Items[i].SubItems[num9].Text = num11.ToString();
                    }
                    for (int j = 0; j < base.listItems.Items.Count; j++)
                    {
                        num8 += Convert.ToDouble(base.listItems.Items[j].SubItems[num9].Text);
                    }
                    this.txtTongTien.Text = num8.ToString("#,##0");
                }
                catch (Exception exception)
                {
                    access.Rollback();
                    MessageBox.Show(exception.Message.ToString());
                }
                finally
                {
                    access.EndTransaction();
                    base.panCommand.Visible = true;
                    base.panSaveCancel.Visible = false;
                    this.enableControls(false);
                    base.listItems.Enabled = false;
                }
            }
        }

        private void Check_InStock(string ProductCode, string ProductName, int AmountDelete)
        {
            string str = "0";
            string query = this.getViewInStock() + " '" + ProductCode + "'";
            DataRow row = new DataAccess().GetRow(query);
            if (!row.IsNull(0))
            {
                str = row[0].ToString();
            }
            if (AmountDelete > Convert.ToInt32(str))
            {
                MessageBox.Show("Kh\x00f4ng thể x\x00f3a Vật Tư " + ProductName + " v\x00ec n\x00f3 chỉ c\x00f2n " + str, "Th\x00f4ng B\x00e1o");
                this.m_checkDelete = 1;
            }
        }

        protected virtual int checkFrom()
        {
            return 0;
        }

        private void cmdInPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(base.listItems.Items[0].SubItems[0].Text) > 0)
                {
                    DataAccess access = new DataAccess();
                    access.CommandText = this.getPrintQuery() + Convert.ToInt32(base.listItems.Items[0].SubItems[0].Text) + "'";
                    DataSet dataSet = new DataSet();
                    access.Fill(dataSet, this.getSrcTable());
                    ReportViewer viewer = new ReportViewer(this.getStr_ReportDocument(), dataSet);
                    viewer.WindowState = FormWindowState.Maximized;
                    viewer.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("Vui l\x00f2ng lưu Phiếu  trước khi in", "Th\x00f4ng B\x00e1o");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui l\x00f2ng chọn Phiếu  trước khi in\n" + ex.Message.ToString(), "Th\x00f4ng B\x00e1o");
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

        private void frmUpdateForm_Multi_Load(object sender, EventArgs e)
        {
            this.m_checkInStock = this.checkFrom();
        }

        protected virtual DataType[] getDataTypeDetail()
        {
            return null;
        }

        protected virtual DataType[] getDataTypeMain()
        {
            return null;
        }

        protected virtual string getDeleteQueryDetail()
        {
            return "";
        }

        protected virtual string getDeleteQueryMain()
        {
            return "";
        }

        protected virtual string getDetailTable()
        {
            return "";
        }

        protected virtual string getInsertQueryDetail()
        {
            return "";
        }

        protected virtual string getInsertQueryMain()
        {
            return "";
        }

        protected virtual string getMainTable()
        {
            return "";
        }

        protected virtual ArrayList getParameterNameDetail()
        {
            return null;
        }

        protected virtual ArrayList getParameterNameMain()
        {
            return null;
        }

        protected virtual ArrayList getParameterValueDetail()
        {
            return null;
        }

        protected virtual ArrayList getParameterValueMain()
        {
            return null;
        }

        protected virtual string getPrintQuery()
        {
            return "";
        }

        protected virtual ReportDocument getReportDocument()
        {
            return null;
        }

        protected virtual string getSelectQueryDetail()
        {
            return "";
        }

        protected virtual string getSelectQueryMain()
        {
            return "";
        }

        protected virtual string getSrcTable()
        {
            return "";
        }

        protected virtual string getStr_ReportDocument()
        {
            return "";
        }

        protected virtual string getUpdateQueryDetail()
        {
            return "";
        }

        protected virtual string getUpdateQueryMain()
        {
            return "";
        }

        private object getValue(DataType dbtype, string values)
        {
            switch (dbtype)
            {
                case DataType.Date:
                    return Convert.ToDateTime(values);

                case DataType.Double:
                    return Convert.ToDouble(values);

                case DataType.Int:
                    return Convert.ToInt32(values);

                case DataType.NVarChar:
                    return Convert.ToString(values);

                case DataType.VarChar:
                    return Convert.ToString(values);
            }
            return null;
        }

        protected virtual string getViewInStock()
        {
            return "";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdateForm_Multi));
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.cmdInPhieu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(536, 480);
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.Location = new System.Drawing.Point(32, 464);
            // 
            // listItems
            // 
            this.listItems.Location = new System.Drawing.Point(32, 224);
            this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
            this.listItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listItems_KeyDown);
            // 
            // panCommand
            // 
            this.panCommand.Location = new System.Drawing.Point(192, 472);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Location = new System.Drawing.Point(32, 472);
            // 
            // txtTongTien
            // 
            this.txtTongTien.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.Red;
            this.txtTongTien.Location = new System.Drawing.Point(428, 440);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(184, 22);
            this.txtTongTien.TabIndex = 5;
            // 
            // cmdInPhieu
            // 
            this.cmdInPhieu.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdInPhieu.Location = new System.Drawing.Point(448, 480);
            this.cmdInPhieu.Name = "cmdInPhieu";
            this.cmdInPhieu.Size = new System.Drawing.Size(75, 23);
            this.cmdInPhieu.TabIndex = 7;
            this.cmdInPhieu.Text = "In Phiếu";
            this.cmdInPhieu.Click += new System.EventHandler(this.cmdInPhieu_Click);
            // 
            // frmUpdateForm_Multi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(722, 530);
            this.Controls.Add(this.cmdInPhieu);
            this.Controls.Add(this.txtTongTien);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUpdateForm_Multi";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmUpdateForm_Multi_Load);
            this.Controls.SetChildIndex(this.txtTongTien, 0);
            this.Controls.SetChildIndex(this.listItems, 0);
            this.Controls.SetChildIndex(this.grpBtnLine, 0);
            this.Controls.SetChildIndex(this.panCommand, 0);
            this.Controls.SetChildIndex(this.panSaveCancel, 0);
            this.Controls.SetChildIndex(this.btnExit, 0);
            this.Controls.SetChildIndex(this.cmdInPhieu, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        protected virtual void listItems_KeyDown(object sender, KeyEventArgs e)
        {			
            if (e.KeyData == Keys.Delete)
            {
				if (NotDelete && !DesignMode)
				{
					MessageBox.Show("Bạn không được phép xóa!");
					return;
				}
                if ((base.listItems.SelectedItems[0].Index >= 0) && (MessageBox.Show(this, "Bạn c\x00f3 chắc muốn x\x00f3a d\x00f2ng dữ liệu n\x00e0y kh\x00f4ng?", "Th\x00f4ng b\x00e1o", MessageBoxButtons.YesNo) != DialogResult.No))
                {
                    if (Convert.ToInt32(base.listItems.SelectedItems[0].SubItems[0].Text) == 0)
                    {
                        base.listItems.SelectedItems[0].Remove();
                        this.clearControls();
                    }
                    else
                    {
                        DataAccess access = new DataAccess();
                        try
                        {
                            access.BeginTransaction();
                            if (this.m_checkInStock == 0)
                            {
                                for (int i = 0; i < base.listItems.Items.Count; i++)
                                {
                                    this.Check_InStock(base.listItems.Items[i].SubItems[1].Text, base.listItems.Items[i].SubItems[2].Text, Convert.ToInt32(base.listItems.Items[i].SubItems[3].Text));
                                }
                            }
                            if (this.m_checkDelete != 1)
                            {
                                access.CommandText = this.getDeleteQueryDetail() + base.listItems.SelectedItems[0].SubItems[0].Text + "' and MAVATTU = '" + base.listItems.SelectedItems[0].SubItems[1].Text + "'";
                                access.ExecuteNonQuery();
                            }
                            else
                            {
                                MessageBox.Show("Chỉ c\x00f3 thể x\x00f3a được c\x00e1c Vật Tư kh\x00f4ng c\x00f3 b\x00e1o lỗi", "Th\x00f4ng B\x00e1o");
                            }
                            this.enableControls(false);
                            this.clearControls();
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show("C\x00f3 lỗi khi x\x00f3a. Th\x00f4ng tin lỗi như sau:\n" + exception.Message, "Th\x00f4ng B\x00e1o");
                        }
                        finally
                        {
                            access.EndTransaction();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn một d\x00f2ng n\x00e0o cần x\x00f3a", "Th\x00f4ng B\x00e1o");
            }
        }

        protected override void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectRecord();
        }

        protected override void populateList()
        {
            try
            {
                DataAccess access = new DataAccess();
                access.CommandText = this.getSelectQueryDetail();
                DataTable data = access.GetData();
                if ((data != null) && (data.Rows.Count > 0))
                {
                    int num = 0;
                    if (base.listItems.SelectedIndices.Count > 0)
                    {
                        num = base.listItems.SelectedIndices[0];
                    }
                    if (num >= data.Rows.Count)
                    {
                        num = data.Rows.Count - 1;
                    }
                    base.listItems.Items.Clear();
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        string[] items = new string[data.Rows[i].ItemArray.Length];
                        for (int j = 0; j < data.Rows[i].ItemArray.Length; j++)
                        {
                            items[j] = "" + data.Rows[i].ItemArray[j];
                        }
                        ListViewItem item = new ListViewItem(items);
                        if (i == num)
                        {
                            item.Selected = true;
                        }
                        base.listItems.Items.Add(item);
                    }
                }
                this.selectRecord();
            }
            catch (Exception exception)
            {
                MessageBox.Show("C\x00f3 lỗi khi load dữ liệu, vui l\x00f2ng li\x00ean hệ với quản trị hệ thống.\n\n" + exception.Message, "Th\x00f4ng B\x00e1o");
            }
        }
    }
}

