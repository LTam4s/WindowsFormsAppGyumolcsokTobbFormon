using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppGyumolcsok
{
    internal static class Program
    {
        static public GyumolcsokInsert gyumolcsokInsert = null;
        static public GyumolcsokUpdate gyumolcsokUpdate = null;
        static public GyumolcsokDelete gyumolcsokDelete = null;
        static public Form1 gyumolcsok = null;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            gyumolcsok = new Form1();
            gyumolcsokInsert = new GyumolcsokInsert();
            gyumolcsokUpdate = new GyumolcsokUpdate();
            gyumolcsokDelete = new GyumolcsokDelete();
            Application.Run(gyumolcsok);
        }
    }
}
