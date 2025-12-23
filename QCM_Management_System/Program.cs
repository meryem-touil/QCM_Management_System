using System;
using System.Windows.Forms;

namespace QCM_Management_System
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm()); // <-- Changed this
        }
    }
}