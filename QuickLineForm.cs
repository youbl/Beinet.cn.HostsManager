using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    public partial class QuickLineForm : Form
    {
        public QuickLineForm()
        {
            InitializeComponent();
            ShowInTaskbar = false;// 不能放到OnLoad里，会导致窗体消失
            
            label1.Text += @"
每行记录可以包含多个配置，以;分隔(注意注释不能有分号)，例如：
192.168.1.123 beinet.cn;192.168.2.234 www.beinet.cn
多行之间以物理换行分隔，自然换行不算新行

快捷方式与快捷行的区别：
  快捷方式类似于备份，是清除当前hosts的全部内容，用快捷方式里的内容替换
  快捷行则只是把行里的内容追加到当前hosts的内容最后，并不修改当前hosts的旧内容";

            textBox1.Text = HostsDal.GetQuickLines();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text.Trim();
            string[] arr = str.Split('\n');
            #region 检查输入
            for (int i = 0; i < arr.Length; i++)
            {
                SortedDictionary<string, string> hosts = new SortedDictionary<string, string>();
                string[] quickLines = arr[i].Split(';');
                foreach (string line in quickLines)
                {
                    Match match = HostsDal.RegItem.Match(line);
                    if (!match.Success)
                    {
                        MessageBox.Show(string.Format("第{1}行的配置 {0} 不符合要求(注释不能有分号哦)", line, i + 1));
                        return;
                    }
                    string ip = match.Result("$1");
                    string name = match.Result("$2");
                    if(hosts.ContainsKey(name.ToLower()))
                    {
                        MessageBox.Show(string.Format("第{1}行的域名 {0} 重复定义", name, i + 1));
                        return;
                    }
                    hosts.Add(name.ToLower(), ip);
                }

            }
            #endregion

            HostsDal.SaveQuickLines(str);
            btnCanel_Click(null, null);
        }
    }
}
