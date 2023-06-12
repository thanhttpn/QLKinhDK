namespace QlyKinh
{
    using System;
    using System.Windows.Forms;

    public class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new frmMain());
        }
    }
}

