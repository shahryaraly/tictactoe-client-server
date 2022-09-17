using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _26_1_2015_ttt_winform_client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
