using DatabaseCoreLogic;
using DatabasePasswordManager.Main;
using DatabasePasswordManager.Startup;
using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using UpdateManagerLibrary;

namespace DatabasePasswordManager
{
    public static class MainProgram
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(false, (Application.ProductName + "_" + Assembly.GetExecutingAssembly().GetType().GUID)))
            {
                if (mutex.WaitOne(0, false))
                {
                    SafeNativeMethods safeNativeMethods = new SafeNativeMethods();
                    Application.AddMessageFilter(safeNativeMethods);

                    // Temp
                    string updateCheckUrl = ("https://onedrive.live.com/download?resid=7D7FF9DFDA23C644!2368&authkey=!AFcY04VNisbcdlE");

                    if (!UpdateManager.CheckForUpdates(updateCheckUrl))
                    {
                        using (CoreLogic coreLogic = new CoreLogic())
                        {
                            if (StartupForm.StartupDatabase(coreLogic) == DialogResult.OK)
                            {
                                Application.Run(new MainForm(coreLogic));
                            }
                        }
                    }

                    Application.RemoveMessageFilter(safeNativeMethods);
                }
                else
                {
                    SafeNativeMethods.ShowAndFocusMainInstance();
                }
            }
        }
    }
}
