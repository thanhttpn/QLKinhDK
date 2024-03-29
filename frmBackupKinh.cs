using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLBV.DataAccess;
using System.IO;
using QLBV.Common;

namespace BackUpKinh
{
    public partial class frmBackupKinh : Form
    {
        public frmBackupKinh()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            DataAccess dba = new DataAccess();
            DataSet dataset = new DataSet();

            dba.CommandText = " select distinct NHANVIEN.* from NHANVIEN";            
            dba.Fill(dataset, "NHANVIEN");

            dba.CommandText = " select * from KINH_LOAIVATTU";
            dba.Fill(dataset, "KINH_LOAIVATTU");

            dba.CommandText = " select * from KINH_NHACUNGCAP";
            dba.Fill(dataset, "KINH_NHACUNGCAP");

            dba.CommandText = " select * from KINH_LYDONX";
            dba.Fill(dataset, "KINH_LYDONX");


            dba.CommandText = " select distinct KINH_VATTUKINH.* from KINH_VATTUKINH";
            dba.Fill(dataset, "KINH_VATTUKINH");

            dba.CommandText = " select distinct KINH_PHIEUNHAP.* from KINH_PHIEUNHAP Where NGAYNHAP>='" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + "' and NGAYNHAP<='" + dtpDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            dba.Fill(dataset, "KINH_PHIEUNHAP");

            dba.CommandText = " select distinct KINH_PHIEUXUAT.* from KINH_PHIEUXUAT Where NGAYXUAT>='" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + "' and NGAYXUAT<='" + dtpDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            dba.Fill(dataset, "KINH_PHIEUXUAT");

            dba.CommandText = " select distinct KINH_CHITIETNHAP.* from KINH_CHITIETNHAP inner join KINH_PHIEUNHAP ON KINH_CHITIETNHAP.MAPHIEUNHAP = KINH_PHIEUNHAP.MAPHIEUNHAP Where NGAYNHAP>='" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + "' and NGAYNHAP<='" + dtpDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            dba.Fill(dataset, "KINH_CHITIETNHAP");

            dba.CommandText = " select distinct KINH_CHITIETXUAT.* from KINH_CHITIETXUAT inner join KINH_PHIEUXUAT ON KINH_CHITIETXUAT.MAPHIEUXUAT = KINH_PHIEUXUAT.MAPHIEUXUAT Where NGAYXUAT>='" + dtpTuNgay.Value.ToString("yyyy-MM-dd") + "' and NGAYXUAT<='" + dtpDenNgay.Value.ToString("yyyy-MM-dd 23:59:59") + "'";
            dba.Fill(dataset, "KINH_CHITIETXUAT");

            SaveToFile(dataset, dtpTuNgay.Value, dtpDenNgay.Value);
            MessageBox.Show("Lưu thành công!");
           
        }
        private bool SaveToFile(DataSet ds,DateTime m_TuNgay, DateTime m_DenNgay)
        {
            try
            {

                string FileName = QLBV.Common.DataConts.Instance.BenhVienSuDung + "_" + m_TuNgay.ToString("yyyyMMdd") + "_" + m_DenNgay.ToString("yyyyMMdd") + ".kinh";
                SaveFileDialog fileDlg = new SaveFileDialog();
                fileDlg.Filter = "File kinh (*.thuoc)|*.kinh";
                fileDlg.FileName = FileName;
                if (fileDlg.ShowDialog() == DialogResult.OK)
                {
                    FileName = fileDlg.FileName.Substring(0,fileDlg.FileName.Length - 5);

                    SaveDataSourceToXmlFile(ds, FileName+".XML");
                    CommonFunctionsDhospital.Instance.ZipFile(new string[] { FileName+".XML", FileName+".XML" + ".dts" },
                                                    FileName+".XML" + ".kinh");
                    File.Delete(FileName+".XML");
                    File.Delete(FileName+".XML" + ".dts");
                }                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Loi: " + ex.Message);
                return false;
            }
        }

        
        public bool SaveDataSourceToXmlFile(DataSet dataset, string FileName)
        {

            try
            {
                if (dataset != null && dataset.Tables.Count > 0)
                {
                    dataset.WriteXml(FileName);
                    dataset.WriteXmlSchema(FileName + ".dts");

                }
                else
                {
                    throw new Exception("Không có table trong phần Data source nên không cần lưu!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Không lưu được file : " + ex.ToString());
            }
            return true;
        }
    }
}