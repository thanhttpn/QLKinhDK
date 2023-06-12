namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using QLBV.DataAccess;
    public class UpdateForm : Form
    {
        private Button btnAdd;
        private Button btnCancel;
        protected Button btnExit;
        private Button btnModify;
        private Button btnRemove;
        private Button btnSave;
        private Container components = null;
        protected GroupBox grpBtnLine;
        public bool isModify = false;
        protected ListView listItems;
        protected Panel panCommand;
        protected Panel panSaveCancel;

        protected UpdateForm()
        {
            this.InitializeComponent();
        }

        protected virtual void btnAdd_Click(object sender, EventArgs e)
        {
            this.enableControls(true);
            this.panCommand.Visible = false;
            this.panSaveCancel.Visible = true;
            this.listItems.Enabled = false;
            this.clearControls();
            this.isModify = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.panCommand.Visible = true;
            this.panSaveCancel.Visible = false;
            this.enableControls(false);
            this.listItems.Enabled = true;
            this.selectRecord();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        protected virtual void btnModify_Click(object sender, EventArgs e)
        {
            if (this.listItems.SelectedIndices.Count < 1)
            {
                MessageBox.Show("Bạn phải chọn \x00edt nhất một d\x00f2ng trong danh s\x00e1ch để sửa", "Th\x00f4ng b\x00e1o");
            }
            else
            {
                this.enableControls(true);
                this.panCommand.Visible = false;
                this.panSaveCancel.Visible = true;
                this.listItems.Enabled = false;
                this.isModify = true;
            }
        }

		public bool NotDelete = false;

        protected virtual void btnRemove_Click(object sender, EventArgs e)
        {
			if (NotDelete)
			{
				MessageBox.Show("Bạn không có quyền xóa!", "Th\x00f4ng b\x00e1o");
			}
            if (this.listItems.SelectedIndices.Count < 1)
            {
                MessageBox.Show("Bạn phải chọn \x00edt nhất một d\x00f2ng trong danh s\x00e1ch để X\x00f3a", "Th\x00f4ng b\x00e1o");
            }
            else if (MessageBox.Show(this, "Bạn c\x00f3 chắc muốn x\x00f3a?", "Th\x00f4ng b\x00e1o", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                this.enableControls(false);
                DataAccess access = new DataAccess();
                try
                {
                    access.CommandText = this.getDeleteQuery();
                    access.ExecuteNonQuery();
                    this.populateList();
                }
                catch (Exception exception)
                {
                    MessageBox.Show("C\x00f3 lỗi khi x\x00f3a. Th\x00f4ng tin lỗi như sau:\n" + exception.Message, "Th\x00f4ng B\x00e1o");
                }
            }
        }

        protected virtual void btnSave_Click(object sender, EventArgs e)
        {
            if (this.validateData())
            {
                DataAccess access = new DataAccess();
                try
                {
                    string str = this.isModify ? this.getUpdateQuery() : this.getInsertQuery();
                    access.CommandText = this.isModify ? this.getUpdateQuery() : this.getInsertQuery();
                    access.ExecuteNonQuery();
                    this.populateList();
                    this.panCommand.Visible = true;
                    this.panSaveCancel.Visible = false;
                    this.enableControls(false);
                    this.listItems.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("C\x00f3 lỗi khi lưu. Th\x00f4ng tin lỗi như sau:\n" + exception.Message, "Th\x00f4ng B\x00e1o");
                }
            }
        }

        protected virtual void clearControls()
        {
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected virtual void enableControls(bool val)
        {
        }

        protected virtual string getDeleteQuery()
        {
            return "";
        }

        protected virtual string getInsertQuery()
        {
            return "";
        }

        protected virtual string getSelectQuery()
        {
            return "";
        }

        protected virtual string getUpdateQuery()
        {
            return "";
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.listItems = new System.Windows.Forms.ListView();
            this.grpBtnLine = new System.Windows.Forms.GroupBox();
            this.panCommand = new System.Windows.Forms.Panel();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.panSaveCancel = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panCommand.SuspendLayout();
            this.panSaveCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // listItems
            // 
            this.listItems.FullRowSelect = true;
            this.listItems.GridLines = true;
            this.listItems.HideSelection = false;
            this.listItems.Location = new System.Drawing.Point(12, 104);
            this.listItems.Name = "listItems";
            this.listItems.Size = new System.Drawing.Size(580, 208);
            this.listItems.TabIndex = 0;
            this.listItems.UseCompatibleStateImageBehavior = false;
            this.listItems.View = System.Windows.Forms.View.Details;
            this.listItems.SelectedIndexChanged += new System.EventHandler(this.listItems_SelectedIndexChanged);
            // 
            // grpBtnLine
            // 
            this.grpBtnLine.Location = new System.Drawing.Point(8, 328);
            this.grpBtnLine.Name = "grpBtnLine";
            this.grpBtnLine.Size = new System.Drawing.Size(588, 4);
            this.grpBtnLine.TabIndex = 1;
            this.grpBtnLine.TabStop = false;
            // 
            // panCommand
            // 
            this.panCommand.Controls.Add(this.btnModify);
            this.panCommand.Controls.Add(this.btnRemove);
            this.panCommand.Controls.Add(this.btnAdd);
            this.panCommand.Location = new System.Drawing.Point(204, 340);
            this.panCommand.Name = "panCommand";
            this.panCommand.Size = new System.Drawing.Size(256, 40);
            this.panCommand.TabIndex = 2;
            // 
            // btnModify
            // 
            this.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnModify.Location = new System.Drawing.Point(92, 8);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 2;
            this.btnModify.Text = "Sửa";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemove.Location = new System.Drawing.Point(172, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Xóa";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Location = new System.Drawing.Point(12, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panSaveCancel
            // 
            this.panSaveCancel.Controls.Add(this.btnCancel);
            this.panSaveCancel.Controls.Add(this.btnSave);
            this.panSaveCancel.Location = new System.Drawing.Point(44, 340);
            this.panSaveCancel.Name = "panSaveCancel";
            this.panSaveCancel.Size = new System.Drawing.Size(176, 40);
            this.panSaveCancel.TabIndex = 3;
            this.panSaveCancel.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(92, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Bỏ Qua";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(12, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.Location = new System.Drawing.Point(516, 348);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // UpdateForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(600, 382);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panSaveCancel);
            this.Controls.Add(this.panCommand);
            this.Controls.Add(this.grpBtnLine);
            this.Controls.Add(this.listItems);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Form";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.panCommand.ResumeLayout(false);
            this.panSaveCancel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

        protected virtual void listItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selectRecord();
            this.enableControls(false);
        }

        protected virtual void populateList()
        {
            try
            {
                DataAccess access = new DataAccess();
                access.CommandText = this.getSelectQuery();
                DataTable data = access.GetData();
                if ((data != null) && (data.Rows.Count > 0))
                {
                    int num = 0;
                    if (this.listItems.SelectedIndices.Count > 0)
                    {
                        num = this.listItems.SelectedIndices[0];
                    }
                    if (num >= data.Rows.Count)
                    {
                        num = data.Rows.Count - 1;
                    }
                    this.listItems.Items.Clear();
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
                        this.listItems.Items.Add(item);
                    }
                }
                this.selectRecord();
            }
            catch (Exception exception)
            {
                MessageBox.Show("C\x00f3 lỗi khi load dữ liệu, vui l\x00f2ng li\x00ean hệ với quản trị hệ thống.\n\n" + exception.Message, "Th\x00f4ng B\x00e1o");
            }
        }

        protected virtual void selectRecord()
        {
        }

        protected static string sqlEncode(string s)
        {
            return s.Replace("'", "''");
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
			if (NotDelete && !DesignMode)
			{
				btnRemove.Visible = false;
				btnModify.Visible = false;
			}
        }

        protected virtual bool validateData()
        {
            return true;
        }
    }
}

