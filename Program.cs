﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAP_Filler
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
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            Application.Run(new Form1());

            }

        private static void CurrentDomain_ProcessExit(object sender, EventArgs e)
            {
            Console.WriteLine("Program exit");
            }

        private static void Application_ApplicationExit(object sender, EventArgs e)
            {
            }
        }
}
