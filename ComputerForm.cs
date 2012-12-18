using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    public partial class ComputerForm : Form
    {
        public ComputerForm()
        {
            InitializeComponent();
            ShowInTaskbar = false;// 不能放到OnLoad里，会导致窗体消失

            ComputerInfo computer = ComputerInfo.Instance();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Computer Name:{0}\r\n", computer.ComputerName);
            sb.AppendFormat("Cpu ID:{0}\r\n", computer.CpuID);
            sb.AppendFormat("Cpu频率:{0}\r\n", computer.CpuFrequency);
            sb.AppendFormat("Disk ID:{0}\r\n", computer.DiskID);
            sb.AppendFormat("{0}\r\n", computer.DiskSpace);
            sb.AppendFormat("Physical Memory:{0}\r\n", computer.TotalPhysicalMemory);
            sb.AppendFormat("Login User:{0}\r\n", computer.LoginUserName);
            sb.AppendFormat("System Type:{0}\r\n", computer.SystemType);
            sb.AppendFormat("{0}\r\n", computer.IpAddress);


            #region 显示环境变量集
            sb.Append("\r\n环境变量集：\r\n");
            foreach (DictionaryEntry variable in Environment.GetEnvironmentVariables())
            {
                sb.AppendFormat("{0}:{1}\r\n", variable.Key, variable.Value);
            }
            sb.Append("\r\n其它属性：\r\n");
            sb.AppendFormat("CommandLine:{0}\r\n", Environment.CommandLine);                  //获取该进程的命令行。
            sb.AppendFormat("CurrentDirectory:{0}\r\n", Environment.CurrentDirectory);        //获取或设置当前工作目录的完全限定路径。
            sb.AppendFormat("ExitCode:{0}\r\n", Environment.ExitCode);                        //获取或设置进程的退出代码。
            sb.AppendFormat("HasShutdownStarted:{0}\r\n", Environment.HasShutdownStarted);    //获取一个值，该值指示是否公共语言运行库正在关闭或者当前的应用程序域正在卸载。
            sb.AppendFormat("MachineName:{0}\r\n", Environment.MachineName);                  //获取此本地计算机的NetBIOS名称。
            sb.AppendFormat("NewLine:{0}\r\n", Environment.NewLine);                          //获取为此环境定义的换行字符串。
            sb.AppendFormat("OSVersion:{0}\r\n", Environment.OSVersion);                      //获取包含当前平台标识符和版本号的OperatingSystem对象。
            sb.AppendFormat("ProcessorCount:{0}\r\n", Environment.ProcessorCount);            //获取当前计算机上的处理器数。
            sb.AppendFormat("StackTrace:{0}\r\n", Environment.StackTrace);                    //获取当前的堆栈跟踪信息。
            sb.AppendFormat("SystemDirectory:{0}\r\n", Environment.SystemDirectory);          //获取系统目录的完全限定路径。
            sb.AppendFormat("TickCount:{0}\r\n", Environment.TickCount);                      //获取系统启动后经过的毫秒数。
            sb.AppendFormat("UserDomainName:{0}\r\n", Environment.UserDomainName);            //获取与当前用户关联的网络域名。
            sb.AppendFormat("UserInteractive:{0}\r\n", Environment.UserInteractive);          //获取一个值，用以指示当前进程是否在用户交互模式中运行。
            sb.AppendFormat("UserName:{0}\r\n", Environment.UserName);                        //获取当前已登录到Windows操作系统的人员的用户名。
            sb.AppendFormat("Version:{0}\r\n", Environment.Version);                          //获取一个Version对象，该对象描述公共语言运行库的主版本、次版本、内部版本和修订号。
            sb.AppendFormat("WorkingSet:{0}\r\n", Environment.WorkingSet);                    //获取映射到进程上下文的物理内存量。
            #endregion

            textBox1.Text = sb.ToString();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Owner != null)
            {
                Left = Owner.Left + 20;
                Top = Owner.Top + 20;
                if (Top < 0)
                    Top = 0;
            }
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }
    }
}
