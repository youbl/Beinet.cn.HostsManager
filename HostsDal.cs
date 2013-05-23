using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Beinet.cn.HostsManager
{
    public abstract class HostsDal
    {
        #region 字段
        /// <summary>
        /// 返回Hosts文件所在的系统目录
        /// </summary>
        public static readonly string SysDir = Environment.SystemDirectory + @"\drivers\etc\";
        /// <summary>
        /// 指定Hosts文件路径
        /// </summary>
        public static readonly string HostsPath = SysDir + @"hosts";

        /// <summary>
        /// 返回应用程序所在的目录，因为Environment.CurrentDirectory指向的路径会被OpenFileDialog()修改，所以不用
        /// </summary>
        public static readonly string AppDir = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 指定配置文件路径
        /// </summary>
        public static readonly string ConfigPath = AppDir + @"\Config.xml";

        /// <summary>
        /// 保存快捷行的文件路径
        /// </summary>
        public static readonly string QuickLinePath = AppDir + @"\QuickLine.txt";

        /// <summary>
        /// 原始的微软Hosts注释
        /// </summary>
        public static readonly string HostsDesc = @"# Copyright (c) 1993-1999 Microsoft Corp.
#
# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.
#
# This file contains the mappings of IP addresses to host names. Each
# entry should be kept on an individual line. The IP address should
# be placed in the first column followed by the corresponding host name.
# The IP address and the host name should be separated by at least one
# space.
#
# Additionally, comments (such as these) may be inserted on individual
# lines or following the machine name denoted by a '#' symbol.
#
# For example:
#
#      102.54.94.97     rhino.acme.com          # source server
#       38.25.63.10     x.acme.com              # x client host
";

        ///// <summary>
        ///// 匹配使用中的Hosts记录的正则
        ///// </summary>
        //public static readonly Regex RegItemUse = 
        //    new Regex(@"^\s*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\s+([^\s]+)\s*#?(.*)$", RegexOptions.Compiled);

        ///// <summary>
        ///// 匹配被注释的Hosts记录的正则
        ///// </summary>
        //public static readonly Regex RegItemComment =
        //    new Regex(@"^\s*#\s*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\s+([^\s]+)\s*#?(.*)$", RegexOptions.Compiled);

        /// <summary>
        /// 匹配被注释的Hosts记录的正则
        /// 分组1是ip，分组2是域名，分组3是注释
        /// </summary>
        public static readonly Regex RegItem =
            new Regex(@"^\s*#?\s*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\s+([^\s#]+\s*)(#.*)?$", RegexOptions.Compiled);
        /// <summary>
        /// 从注释里匹配出分组的正则
        /// </summary>
        static readonly Regex RegDescGroup= new Regex(@"\s+\d+$", RegexOptions.Compiled);

        // 匹配单个host的正则：^\s*#?\s*(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\s+([^\s]+)\s*#?(.*)$
        #endregion

        /// <summary>
        /// 从指定的路径获取host记录
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<HostItem> GetHosts(string path)
        {
            path = GetFileName(path);

            //if(!File.Exists(path))
            //{
            //    MessageBox.Show("Hosts文件不存在，请手动选择文件路径");
            //    OpenFileDialog diag = new OpenFileDialog();
            //    diag.FileName = path;
            //    DialogResult result = diag.ShowDialog();
            //    if (result == DialogResult.OK || result == DialogResult.Yes)
            //    {
            //        path = diag.FileName;
            //    }
            //}
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path, Encode))
                {
                    List<HostItem> ret = new List<HostItem>();
                    while (!reader.EndOfStream)
                    {
                        string str = reader.ReadLine();
                        if (str == null)
                            continue;
                        str = str.Trim();

                        // 属于微软的2个注释时，跳过
                        if (str == "#      102.54.94.97     rhino.acme.com          # source server" ||
                            str == "#       38.25.63.10     x.acme.com              # x client host")
                            continue;

                        if (string.IsNullOrEmpty(str))
                        {
                            continue;
                        }

                        Match match = RegItem.Match(str);
                        if (match.Success)
                        {
                            string ip = match.Result("$1").Trim();
                            string name = match.Result("$2").Trim();
                            string desc = match.Result("$3").Trim();
                            int group = 0;
                            if (desc.StartsWith("#"))
                            {
                                desc = desc.Substring(1);
                                Match mGroup = RegDescGroup.Match(desc);
                                if(mGroup.Success)
                                {
                                    string tmp = mGroup.Value;
                                    group = int.Parse(tmp.Trim());
                                    desc = desc.Substring(0, mGroup.Index);
                                }
                            }
                            bool use = !str.StartsWith("#");
                            HostItem item = new HostItem(ip, name, desc, use, group);
                            ret.Add(item);
                        }
                    }
                    // 如果没有分组，则不排序
                    if (ret.Find(item => item.Group != 0) != null)
                    {
                        // 有进行分组时，按分组、是否使用、ip、域名排序
                        ret.Sort((x, y) =>
                        {
                            int retCompare = x.Group.CompareTo(y.Group);
                            if (retCompare == 0)
                            {
                                retCompare = -x.IsUsing.CompareTo(y.IsUsing);
                                if (retCompare == 0)
                                {
                                    retCompare = x.IP.CompareTo(y.IP);
                                    if (retCompare == 0)
                                    {
                                        retCompare = x.Name.CompareTo(y.Name);
                                    }
                                    else if (x.IP.StartsWith("127")) // 127的排前面
                                        retCompare = -1;
                                    else if (y.IP.StartsWith("127")) // 127的排前面
                                        retCompare = 1;
                                }
                            }
                            return retCompare;
                        });
                    }
                    return ret;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取历史备份文件
        /// </summary>
        /// <returns></returns>
        public static List<string> GetHostHistory()
        {
            string dir = SaveToSysDir ? SysDir : AppDir;
            List<string> ret = new List<string>();
            foreach (string s in Directory.GetFiles(dir, "hosts.*"))
            {
                string ext = Path.GetFileName(s).Substring(5);//Path.GetExtension(s);)
                if (!string.IsNullOrEmpty(ext) && ext.Length > 1)
                    ret.Add(ext.Substring(1));// 去掉第一个点
            }
            return ret;
        }

        /// <summary>
        /// 保存到系统目录，文件名为指定的name。
        /// name为空时，表示保存Hosts文件；
        /// 不为空时表示保存备份文件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arr">要保存的记录</param>
        public static void SaveHosts(string name, List<HostItem> arr)
        {
            string realName = GetFileName(name);
            if (File.Exists(realName))
            {
                // 文件是只读或隐藏时，修改它的属性
                FileAttributes att = File.GetAttributes(realName);
                if ((att & FileAttributes.ReadOnly) == FileAttributes.ReadOnly ||
                    (att & FileAttributes.Hidden) == FileAttributes.Hidden ||
                    (att & FileAttributes.System) == FileAttributes.System)
                {
                    File.SetAttributes(realName, FileAttributes.Archive);
                }
            }
            using (StreamWriter sw = new StreamWriter(realName, false, Encode))
            {
                // 添加微软注释
                if (AddMicroComment)
                    sw.WriteLine(HostsDesc);

                foreach (HostItem item in arr)
                {
                    if (item.IsUsing || SaveComment)
                        sw.WriteLine(item.ToString());
                }
            }
        }

        /// <summary>
        /// 获取历史文件命名方式,文件为空，表示保存并应用到hosts，否则保存到历史文件
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetFileName(string name)
        {
            if (string.IsNullOrEmpty(name))
                name = HostsPath;
            else
            {
                string dir = SaveToSysDir ? SysDir : AppDir;
                name = dir + "\\hosts." + name;
            }
            return name;
        }

        /// <summary>
        /// 备份Hosts文件
        /// </summary>
        public static void BackupHosts()
        {
            if (!File.Exists(HostsPath))
                return;
            string name = GetFileName("系统备份");
            if (File.Exists(name))
                return;
            File.Copy(HostsPath, name);
        }

        #region 配置文件相关
        /// <summary>
        /// 返回hosts的内容编码格式
        /// </summary>
        public static Encoding Encode
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("Encoding");
                    if (en != null)
                    {
                        try
                        {
                            return Encoding.GetEncoding(en.InnerText);
                        }
                        catch
                        {
                            MessageBox.Show("配置文件里编码配置有误，请修改！");
                        }
                    }
                }
                return Encoding.GetEncoding("GB2312");
            }
        }

        /// <summary>
        /// 选择快捷方式时，是否立即保存
        /// </summary>
        public static bool LinkQuickUse
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("LinkQuickUse");
                    if (en != null)
                    {
                        return (en.InnerText == "1");
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 保存时，是否添加微软的注释
        /// </summary>
        public static bool AddMicroComment
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("AddMicroComment");
                    if (en != null)
                    {
                        return (en.InnerText == "1");
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// 是否保存注释的host记录
        /// </summary>
        public static bool SaveComment
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("SaveComment");
                    if (en != null)
                    {
                        return (en.InnerText == "1");
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// 是否保存快捷方式到系统目录
        /// </summary>
        public static bool SaveToSysDir
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("SaveToSysDir");
                    if (en != null)
                    {
                        return (en.InnerText == "1");
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// 提示信息显示的时间（秒，到时后关闭）
        /// </summary>
        public static int MessageShowSecond
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("MessageShowSecond");
                    if (en != null)
                    {
                        int ret;
                        if (int.TryParse(en.InnerText, out ret))
                            return ret;
                    }
                }
                return 2;
            }
        }

        /// <summary>
        /// 启动时是否窗口置顶
        /// </summary>
        public static bool StartFront
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("StartFront");
                    if (en != null)
                    {
                        return (en.InnerText == "1");
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// 电信DNS
        /// </summary>
        public static string TelecomDns
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("TelecomDns");
                    if (en != null)
                    {
                        return en.InnerText;
                    }
                }
                return "8.8.8.8";
            }
        }

        /// <summary>
        /// 网通DNS
        /// </summary>
        public static string UnicomDns
        {
            get
            {
                XmlNode l_root = GetConfigRoot();
                if (l_root != null)
                {
                    XmlNode en = l_root.SelectSingleNode("UnicomDns");
                    if (en != null)
                    {
                        return en.InnerText;
                    }
                }
                return "202.106.0.20";
            }
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="encode"></param>
        /// <param name="linkQuickUse"></param>
        /// <param name="addMicroComment"></param>
        /// <param name="saveComment"></param>
        /// <param name="saveToSysDir"></param>
        /// <param name="messageShowSecond"></param>
        /// <param name="isFront"></param>
        /// <param name="telecomDns">电信dns</param>
        /// <param name="unicomDns">联通dns</param>
        public static void SaveConfig(string encode, string linkQuickUse,
            string addMicroComment, string saveComment, string saveToSysDir, int messageShowSecond, string isFront,
            string telecomDns, string unicomDns)
        {
            using (StreamWriter sw = new StreamWriter(ConfigPath, false))
            {
                sw.Write(@"<?xml version=""1.0"" encoding=""utf-8"" ?>
<Config>
  <Encoding>{0}</Encoding>
  <LinkQuickUse>{1}</LinkQuickUse>
  <AddMicroComment>{2}</AddMicroComment>
  <SaveComment>{3}</SaveComment>
  <SaveToSysDir>{4}</SaveToSysDir>
  <MessageShowSecond>{5}</MessageShowSecond>
  <StartFront>{6}</StartFront>
  <TelecomDns>{7}</TelecomDns>
  <UnicomDns>{8}</UnicomDns>
</Config>", encode, linkQuickUse, addMicroComment, saveComment, saveToSysDir, messageShowSecond, isFront, telecomDns, unicomDns);
            }
        }

        /// <summary>
        /// 取得配置文件的根结点
        /// </summary>
        /// <returns></returns>
        private static XmlNode GetConfigRoot()
        {
            if (!File.Exists(ConfigPath))
            {
                //return null;
                // 配置文件不存在，创建一个
                SaveConfig("GB2312", "0", "1", "1", "0", 2, "1", "8.8.8.8", "202.106.0.20");
            }

            XmlDocument l_xml = new XmlDocument();
            l_xml.Load(ConfigPath);

            XmlNode l_root = l_xml.DocumentElement;//.SelectSingleNode("Config");
            if (l_root != null)
                return l_root;

            return null;
        }
        #endregion

        #region 快捷行操作相关
        /// <summary>
        /// 从快捷行配置里读取有效行数据返回
        /// </summary>
        /// <returns></returns>
        public static List<string> GetQuickLineData()
        {
            List<string> ret = new List<string>();
            if (File.Exists(QuickLinePath))
            {
                using (StreamReader sr = new StreamReader(QuickLinePath, Encode))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        if (line != null && line.Trim().Length > 0)
                        {
                            ret.Add(line.Trim());
                        }
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 获取快捷行配置内容，用于配置修改
        /// </summary>
        /// <returns></returns>
        public static string GetQuickLines()
        {
            if (!File.Exists(QuickLinePath))
            {
                return string.Empty;
            }
            using (StreamReader sr = new StreamReader(QuickLinePath, Encode))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// 保存快捷行配置数据
        /// </summary>
        /// <param name="str"></param>
        public static void SaveQuickLines(string str)
        {
            using (StreamWriter sw = new StreamWriter(QuickLinePath, false, Encode))
            {
                sw.Write(str);
            }
        }
        #endregion
    }
}