namespace QlyKinh
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using QLBV.DataAccess;    

    public class CommonClass
    {
        public static ArrayList load_cboBox(ComboBox cbo, out ArrayList arr, string sql)
        {
            arr = new ArrayList();
            arr.Clear();
            cbo.Items.Clear();
            DataAccess access = new DataAccess();
            foreach (DataRow row in access.GetData(sql).Rows)
            {
                cbo.Items.Add(row[1].ToString().Trim());
                arr.Add(row[0].ToString().Trim());
            }
            return arr;
        }

        public static bool Not(bool b)
        {
            return !b;
        }

        public static bool testTextNumber(string text)
        {
            try
            {
                double num = Convert.ToDouble(text);
                return false;
            }
            catch
            {
                return true;
            }
        }

        public static void testTextNumber(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < '0') || (e.KeyChar > '9')) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        public static string textRepair(string text)
        {
            return text.Replace("'", "''");
        }
    }
}

