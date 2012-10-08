using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
            ShowInTaskbar = false;// 不能放到OnLoad里，会导致窗体消失
            
            labHelp.Text = @"
新　　增：在最下方的空行里输入，即可新增行
修　　改：点击需要修改的单元格并修改，然后选择“保存到hosts”或“保存为快捷方式”
删　　除：点击右边的“删除”或选择右键菜单的“删除行”，然后保存
是否应用：选中时表示应用，不选时表示这行是注释(#开头的)
　加空行：保存时在该条记录下方添加一个空行

快捷方式与快捷行的区别：
    快捷方式类似于备份，是清除当前hosts的全部内容，用快捷方式里的内容替换
    快捷行则只是把行里的内容追加到当前hosts的内容最后，并不修改当前hosts的旧内容
快捷行应用时，如果当前列表存在与快捷行相同的配置，将会跳过，不会重复添加";

            textBox1.Text = @"注：这些功能相当于把下方的相应信息导入注册表，你也可以直接把信息文字保存为reg文件，然后双击导入：

修改注册表使hosts修改立即生效 相当于下方的信息：
Windows Registry Editor Version 5.00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings]
""DnsCacheEnabled""=dword:00000000
""DnsCacheTimeout""=dword:00000000
""ServerInfoTimeOut""=dword:00000000

修改注册表修正IE8新建选项卡报js错误问题 相当于下方的信息：
Windows Registry Editor Version 5.00
[HKEY_CLASSES_ROOT\TypeLib\{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}\1.1\0\win32]
@=""C:\\WINDOWS\\system32\\ieframe.dll""

修改注册表为VisualStudio2008添加代码分隔线 相当于下方的信息：
Windows Registry Editor Version 5.00
[HKEY_CURRENT_USER\Software\Microsoft\VisualStudio\9.0\Text Editor]
""Guides""=""RGB(128,0,0) 80, 120""
";

            this.labTitle.Text = "Hosts修改工具" + MainForm.version + "-beinet.cn";
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://beinet.cn");
        }
    }
}
