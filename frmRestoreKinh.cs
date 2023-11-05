using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using QLBV.DataAccess;
using QLBV.Common;

namespace RestoreKinh
{
    public partial class frmRestoreKinh : Form
    {
        public frmRestoreKinh()
        {
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtfileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string path = "";
            CommonFunctionsDhospital.Instance.UnzipFile(txtfileName.Text, path);
            string FileXMLSource = path + "\\" + Path.GetFileName(txtfileName.Text).Substring(0, Path.GetFileName(txtfileName.Text).Length - 5) + ".XML";
            ds.Tables.Clear();
            if (System.IO.File.Exists(FileXMLSource + ".dts"))
            {
                ds.ReadXmlSchema(FileXMLSource + ".dts");
            }
            ds.ReadXml(FileXMLSource);

            string file = Path.GetFileName(txtfileName.Text);
            //Tach Ngay
            string TuNgay = file.Substring(file.IndexOf("_") + 1, 8);
            file = file.Substring(file.IndexOf("_") + 1);
            TuNgay = TuNgay.Substring(0, 4) + "-" + TuNgay.Substring(4, 2) + "-" + TuNgay.Substring(6, 2);
            string DenNgay = file.Substring(file.IndexOf("_") + 1, 8);
            DenNgay = DenNgay.Substring(0, 4) + "-" + DenNgay.Substring(4, 2) + "-" + DenNgay.Substring(6, 2);
            DataAccess dba = new DataAccess();
            try
            {
                dba.BeginTransaction();

                // Luu NhanVien
                if (ds.Tables["NhanVien"] != null)
                {
                    foreach (DataRow row in ds.Tables["NhanVien"].Rows)
                    {
                        dba.CommandText = " exec proc_NhanVienSaveBK "
                                            + row["MANV"].ToString()
                                            + ", N'" + row["TENNHANVIEN"].ToString() + "'"
                                            + "," + row["MAPHONGBAN"].ToString()
                                            + ",N'" + row["USERNAME"].ToString() + "'"
                                            + ",N'" + row["PASSWORD"].ToString() + "'"
                                            + ",N'" + row["CHUCNANG"].ToString() + "'"
                                            + ",N'" + row["PHANQUYEN"].ToString() + "'";
                        dba.ExecuteNonQuery();
                    }
                }

                if (ds.Tables["KINH_LOAIVATTU"] != null)
                {
                    QLBV.Biz.UpdateDataBiz.Instance.SaveTable("KINH_LOAIVATTU", "MALOAIVATTU");
                }
                if (ds.Tables["KINH_NHACUNGCAP"] != null)
                {
                    QLBV.Biz.UpdateDataBiz.Instance.SaveTable("KINH_NHACUNGCAP", "MANCC");
                }
                if (ds.Tables["KINH_LYDONX"] != null)
                {
                    QLBV.Biz.UpdateDataBiz.Instance.SaveTable("KINH_LYDONX", "MALYDO");
                }
                
                if (ds.Tables["KINH_VATTUKINH"] != null)
                {
                    try
                    {
                        foreach (DataRow row in ds.Tables["KINH_VATTUKINH"].Rows)
                        {
                            dba.CommandText = "exec proc_KINH_VATTUKINHSaveBK "
                                            + "'" + row["MAVATTU"].ToString() + "'"
                            + ",N'" + row["TENVATTU"].ToString().Replace("'","''") + "'"
                            + ",N'" + row["QUICACH"].ToString() + "'"
                            + "," + row["GIABAN"].ToString()
                            + ",'" + row["DOKINH"].ToString() + "'"
                            + "," + (row["DAXOA"].ToString() == "" ? "NULL" : row["DAXOA"].ToString());
                            dba.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {                        
                        throw (ex);
                    }  
                }                

                if (ds.Tables["KINH_PHIEUNHAP"] != null)
                {
                    try
                    {
                        dba.CommandText = " delete KINH_PHIEUNHAP where NGAYNHAP >= '" + TuNgay + "' and NGAYNHAP<='" + DenNgay + " 23:59:59'";
                        dba.ExecuteNonQuery();
                        dba.CommandText = " SET IDENTITY_INSERT KINH_PHIEUNHAP ON ";
                        dba.ExecuteNonQuery();
                        foreach (DataRow row in ds.Tables["KINH_PHIEUNHAP"].Rows)
                        {
                            dba.CommandText = "SET IDENTITY_INSERT KINH_PHIEUNHAP ON "
                                              + " INSERT INTO KINH_PHIEUNHAP "
                                              + " ([MAPHIEUNHAP]"
                                              + " ,[MALYDONHAPKINH]"
                                              + " ,[NGAYNHAP]"
                                              + " ,[GHICHU]"
                                              + " ,[MANVNHAP]"
                                              + " ,[MANCC]"
                                              + " ,[TENBN]"
                                              + " ,[MAPXNHAPTRA]"
                                              + " ,[MANVTRA])"
                                              + " values "
                                              + "(" + row["MAPHIEUNHAP"].ToString()
                                              + ",'" + row["MALYDONHAPKINH"].ToString() + "'"
                                              + ",'" + DateTime.Parse(row["NGAYNHAP"].ToString()).ToString("yyyy-MM-dd") + "'"
                                              + ",N'" + row["GHICHU"].ToString() + "'"
                                              + ",'" + row["MANVNHAP"].ToString() + "'"
                                              + "," + row["MANCC"].ToString()
                                              + ",N'" + row["TENBN"].ToString() + "'"
                                              + ",'" + row["MAPXNHAPTRA"].ToString() + "'"
                                              + ",'" + row["MANVTRA"].ToString() + "')";
                            dba.ExecuteNonQuery();
                        }
                        dba.CommandText = " SET IDENTITY_INSERT KINH_PHIEUNHAP OFF";
                        dba.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        dba.CommandText = " SET IDENTITY_INSERT KINH_PHIEUNHAP OFF";
                        dba.ExecuteNonQuery();
                        throw (ex);
                    }  
                }

                if (ds.Tables["KINH_PHIEUXUAT"] != null)
                {
                    try
                    {
                        dba.CommandText = " delete KINH_PHIEUXUAT where NGAYXUAT >= '" + TuNgay + "' and NGAYXUAT<='" + DenNgay + " 23:59:59'";
                        dba.ExecuteNonQuery();
                        dba.CommandText = " SET IDENTITY_INSERT KINH_PHIEUXUAT ON ";
                        dba.ExecuteNonQuery();
                        foreach (DataRow row in ds.Tables["KINH_PHIEUXUAT"].Rows)
                        {
                            dba.CommandText = "SET IDENTITY_INSERT KINH_PHIEUXUAT ON "
                                              + " INSERT INTO KINH_PHIEUXUAT "
                                              + " ([MAPHIEUXUAT]"
                                              + " ,[MALYDOXUATKINH]"
                                              + " ,[NGAYXUAT]"
                                              + " ,[GHICHU]"
                                              + " ,[MANVXUAT]"
                                              + " ,[TENKHACHHANG]"
                                              + " ,[MAYC]"
                                              + " ,[MANVTHU])"
                                              + " values "
                                              + "(" + row["MAPHIEUXUAT"].ToString()
                                              + ",'" + row["MALYDOXUATKINH"].ToString() + "'"
                                              + ",'" + DateTime.Parse(row["NGAYXUAT"].ToString()).ToString("yyyy-MM-dd") + "'"
                                              + ",N'" + row["GHICHU"].ToString() + "'"
                                              + ",'" + row["MANVXUAT"].ToString() + "'"
                                              + ",N'" + row["TENKHACHHANG"].ToString() + "'"
                                              + ",N'" + row["MAYC"].ToString() + "'"
                                              + ",'" + row["MANVTHU"].ToString() + "')";
                            dba.ExecuteNonQuery();
                        }
                        dba.CommandText = " SET IDENTITY_INSERT KINH_PHIEUXUAT OFF";
                        dba.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        dba.CommandText = " SET IDENTITY_INSERT KINH_PHIEUXUAT OFF";
                        dba.ExecuteNonQuery();
                        throw (ex);
                    }  

                }
                if (ds.Tables["KINH_CHITIETNHAP"] != null)
                {
                    try
                    {
                        foreach (DataRow row in ds.Tables["KINH_CHITIETNHAP"].Rows)
                        {
                            dba.CommandText = " INSERT INTO KINH_CHITIETNHAP "
                                              + " ([MAPHIEUNHAP]"
                                              + " ,[MAVATTU]"
                                              + " ,[SOLUONG]"
                                              + " ,[DONGIA])"
                                              + " values "
                                              + "(" + row["MAPHIEUNHAP"].ToString()
                                              + ",'" + row["MAVATTU"].ToString() + "'"
                                              + "," + row["SOLUONG"].ToString()
                                              + "," + row["DONGIA"].ToString() + ")";
                            dba.ExecuteNonQuery();
                        }                       
                    }
                    catch (Exception ex)
                    {  
                        throw (ex);
                    }
                }
                if (ds.Tables["KINH_CHITIETXUAT"] != null)
                {
                    try
                    {
                        foreach (DataRow row in ds.Tables["KINH_CHITIETXUAT"].Rows)
                        {
                            dba.CommandText = " INSERT INTO KINH_CHITIETXUAT "
                                              + " ([MAPHIEUXUAT]"
                                              + " ,[MAVATTU]"
                                              + " ,[SOLUONG]"
                                              + " ,[DONGIA]"
                                              + " ,[MAGONG]"
                                              + " ,[GIAM])"
                                              + " values "
                                              + "(" + row["MAPHIEUXUAT"].ToString()
                                              + ",'" + row["MAVATTU"].ToString() + "'"
                                              + "," + row["SOLUONG"].ToString()
                                              + "," + row["DONGIA"].ToString() 
                                              + ",'" + row["MAGONG"].ToString() + "'"
                                              + "," + row["GIAM"].ToString()
                                              + ")";
                            dba.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    } 
                } 
            }
            catch (Exception ex)
            {
                dba.Rollback();
                MessageBox.Show(ex.Message);
                return;
            }
            dba.EndTransaction();
            MessageBox.Show("Restore thành công!");
        }
    }
}