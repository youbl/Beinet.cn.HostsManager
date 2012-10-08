using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += Application_ThreadException; 
            Run(new MainForm());
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("出错了：" + e.Exception);
        }

        
        #region 单进程模式实现需要的代码
        /// <summary>
        /// Imports 
        /// </summary>
        [DllImport("user32.Dll")]
        private static extern int EnumWindows(EnumWinCallBack callBackFunc, int lParam);

        [DllImport("User32.Dll")]
        private static extern void GetWindowText(int hWnd, StringBuilder str, int nMaxCount);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);

        private const int SW_RESTORE = 8;//9;
        private static string sTitle;
        private static IntPtr windowHandle;

        /// <summary>
        /// EnumWindowCallBack
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        private static bool EnumWindowCallBack(int hwnd, int lParam)
        {
            windowHandle = (IntPtr)hwnd;

            StringBuilder sbuilder = new StringBuilder(256);
            GetWindowText((int)windowHandle, sbuilder, sbuilder.Capacity);
            string strTitle = sbuilder.ToString();

            if (strTitle == sTitle)
            {
                ShowWindow(windowHandle, SW_RESTORE);
                SetForegroundWindow(windowHandle);
                return false;
            }
            return true;
        }//EnumWindowCallBack

        /// <summary>
        /// Execute a form base application if another instance already running on
        /// the system activate previous one
        /// </summary>
        /// <param name="frmMain">main form</param>
        /// <returns>true if no previous instance is running</returns>
        public static bool Run(Form frmMain)
        {
            sTitle = frmMain.Text;

            if (EnumWindows(EnumWindowCallBack, 0) == 0)
            {
                return false;
            }
            Application.Run(frmMain);
            return true;
        }

        public static bool Run(string frmText)
        {
            sTitle = frmText;

            if (EnumWindows(EnumWindowCallBack, 0) == 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool Run()
        {
            Process pr = Process.GetCurrentProcess();
            string strProcessName = pr.ProcessName;
            if (Process.GetProcessesByName(strProcessName).Length > 1)
            {
                return false;
            }
            return true;
        }

        private delegate bool EnumWinCallBack(int hwnd, int lParam);
        #endregion
    }
}
