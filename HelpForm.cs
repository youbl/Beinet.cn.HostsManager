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
- 请务必以管理员权限启动本文件，否则保存时会报错
- 程序启动时，会自动备份系统Hosts文件到当前目录下
- 常用操作：
新　　增：在表格最下方的空行里输入ip和域名，即可新增行
修　　改：点击需要修改的单元格并修改，然后点菜单的“保存”
删　　除：点击右边的“删除”或选择右键菜单的“删除光标所在行”，然后点菜单的“保存”
          注意：如果ip下拉框里不止一个ip，需要点击多次哦
- 表格列“应用”：选中时表示该行配置生效，不选时表示这行是注释(#开头的)

- 存入快速切换 与 快捷行的区别：
    “快速切换”类似于备份，是清除当前hosts的全部内容，用“快速切换”文件里的内容替换
    “快捷行”则只是把行里的内容追加到当前hosts的内容最后，并不修改当前hosts的旧内容
      快捷行应用时，如果当前列表存在与快捷行相同的配置，将会跳过，不会重复添加
    注：按名称排序的前5个“快速保存”项以蓝色显示在主菜单栏，即程序目录下的hosts.*的那些文件
";

            textBox1.Text = @"注：这些功能相当于把下方的相应信息导入注册表，你也可以直接把信息文字保存为reg文件，然后双击导入：

修改注册表使hosts修改立即生效 相当于下方的信息：
Windows Registry Editor Version 5.00
[HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings]
""DnsCacheEnabled""=dword:00000000
""DnsCacheTimeout""=dword:00000000
""ServerInfoTimeOut""=dword:00000000";

            this.labTitle.Text = "Hosts修改工具" + MainForm.version + "-by：游北亮";
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://beinet.cn");
        }

        private void HelpForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
