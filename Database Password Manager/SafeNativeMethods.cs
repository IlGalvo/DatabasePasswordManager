using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DatabasePasswordManager
{
    internal sealed class SafeNativeMethods : IMessageFilter
    {
        #region MAININSTANCE_MANAGER
        public static void ShowAndFocusMainInstance()
        {
            Process[] processes = Process.GetProcessesByName(Application.ProductName);

            foreach(Process process in processes)
            {
                IntPtr hWnd = process.MainWindowHandle;

                if (hWnd != IntPtr.Zero)
                {
                    ShowWindow(hWnd, SW_SHOW);

                    SetForegroundWindow(hWnd);
                }
            }
        }

        private const int SW_SHOW = 5;

        [DllImport("User32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
        private extern static bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("User32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        #endregion

        #region MESSAGE_FILTER

        #region GLOBAL_VARIABLE
        private int currentProcessId;
        #endregion

        #region CONSTRUCTOR
        public SafeNativeMethods()
        {
            currentProcessId = Process.GetCurrentProcess().Id;
        }
        #endregion

        #region MESSAGEFILTER_METHOD
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool PreFilterMessage(ref Message m)
        {
            GetWindowThreadProcessId(m.HWnd, out int processId);

            return (currentProcessId != processId);
        }

        [DllImport("User32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        #endregion

        #endregion

        #region IDLE_TIME
        public static uint GetLastInputTime()
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.structSize = ((uint)Marshal.SizeOf(lastInputInfo));

            GetLastInputInfo(ref lastInputInfo);

            return (((uint)Environment.TickCount - lastInputInfo.lastInputTime) / 1000);
        }

        private struct LASTINPUTINFO
        {
            public uint structSize;
            public uint lastInputTime;
        }

        [DllImport("User32.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO lastInputInfo);
        #endregion

        #region INTERNET_CHECKER
        public static bool IsInternetAvailable()
        {
            return (InternetGetConnectedState(out int description, 0));
        }

        [DllImport("Wininet.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        #endregion
    }
}
