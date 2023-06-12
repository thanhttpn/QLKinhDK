namespace QlyKinh
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class frmSerialNumber : Form
    {
        private Button cmdCancel;
        private Button cmdOK;
        private Container components = null;
        private Label label1;
        public int success = 0;
        private TextBox txtSerialNumber;

        public frmSerialNumber()
        {
            this.InitializeComponent();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            string str = "9f4a036734e9aa4ac32db65189c12058";
            if (this.txtSerialNumber.Text.Trim().Equals(str))
            {
                try
                {
                    FileStream stream = new FileStream(@"C:\WINDOWS\system32\Com\systems.txt", FileMode.Create);
                    for (int i = 0; i < str.Length; i++)
                    {
                        stream.WriteByte(Convert.ToByte(str[i]));
                    }
                    stream.Close();
                    this.success = 1;
                    base.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Please contact to Xuan Trang co.,ltd", "Error!");
                }
            }
            else
            {
                MessageBox.Show("Please contact to Xuan Trang co.,ltd", "Error!");
                this.txtSerialNumber.Text = "";
                this.txtSerialNumber.Focus();
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

        private void InitializeComponent()
        {
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSerialNumber));
			this.label1 = new System.Windows.Forms.Label();
			this.txtSerialNumber = new System.Windows.Forms.TextBox();
			this.cmdOK = new System.Windows.Forms.Button();
			this.cmdCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Serial Number:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSerialNumber
			// 
			this.txtSerialNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtSerialNumber.Location = new System.Drawing.Point(112, 24);
			this.txtSerialNumber.Name = "txtSerialNumber";
			this.txtSerialNumber.Size = new System.Drawing.Size(248, 21);
			this.txtSerialNumber.TabIndex = 1;
			this.txtSerialNumber.Text = "";
			// 
			// cmdOK
			// 
			this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmdOK.Location = new System.Drawing.Point(200, 64);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.TabIndex = 2;
			this.cmdOK.Text = "OK";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.cmdCancel.Location = new System.Drawing.Point(280, 64);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.TabIndex = 3;
			this.cmdCancel.Text = "Cancel";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmSerialNumber
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(366, 94);
			this.ControlBox = false;
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.txtSerialNumber);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSerialNumber";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmSerialNumber";
			this.ResumeLayout(false);

		}
    }
}

