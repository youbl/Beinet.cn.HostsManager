using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Beinet.cn.HostsManager
{
    /// <summary>
    /// Host记录类
    /// </summary>
    [Serializable]
    public class HostItem
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <param name="use"></param>
        /// <param name="group">分组</param>
        public HostItem(string ip, string name, string desc, bool use, int group)
        {
            IP = ip;
            Name = name;
            Description = desc;
            IsUsing = use;
            Group = group;
        }
        /// <summary>
        /// 记录对应的IP
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 记录对应的域名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 记录的说明性文字
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 记录是否使用中
        /// </summary>
        public bool IsUsing { get; set; }

        /// <summary>
        /// 记录所属分组，方便折叠
        /// </summary>
        public int Group { get; set; }

        static Regex regDelHttp = new Regex(@"https?://([^/]+)/?", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        /// <summary>
        /// 返回记录类的文本表示
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Match m = regDelHttp.Match(Name);
            string name;
            if (m.Success)
                name = m.Result("$1");
            else
                name = Name;
            if (string.IsNullOrEmpty(IP) || string.IsNullOrEmpty(name))
            {
                //if (!string.IsNullOrEmpty(Description))
                //{
                //   return string.Format("#{0}", Description.Trim());
                //}
                return string.Empty;
            }
            name = name.Trim().TrimEnd('/');
            string ret = string.Format("{2}{0} {1}",
                IP.Trim().PadRight(17),
                name.Trim().PadRight(40),
                IsUsing ? " " : "#");
            if (!string.IsNullOrEmpty(Description))
            {
                ret = string.Format("{0} #{1}{2}", ret, Description.Trim(), Group > 0 ? " " + Group : "");
            }
            else if(Group > 0)
                ret = string.Format("{0} # {1}", ret, Group);
            return ret;
        }

        /// <summary>
        /// 拆分域名，即一个ip对应多个域名的情况
        /// </summary>
        public List<string> Names
        { get; private set; }
    }
}
