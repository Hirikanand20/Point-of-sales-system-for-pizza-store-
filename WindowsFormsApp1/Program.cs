using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApplicationContext(new login()));
        }
        public static void SwitchForms(Form oldForm, Form newForm)
        {
            newForm.FormClosed += (s, args) => oldForm.Close();
            newForm.Show();
            oldForm.Hide();
        }

    }
}
