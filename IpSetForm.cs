using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    public partial class IpSetForm : Form
    {
        //private ManagementClass mc;
        private ManagementObjectSearcher query;
        private ManagementObjectCollection moc;
        public static string Filename = Path.Combine(HostsDal.AppDir, "ipset.txt");
        private MainForm main;
        public IpSetForm(MainForm main)
        {
            InitializeComponent();
            ShowInTaskbar = false;// 不能放到OnLoad里，会导致窗体消失

            query = new ManagementObjectSearcher("Select * from Win32_NetWorkAdapterConfiguration where IPEnabled= 'TRUE'");
            moc = query.Get();

            //mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            //moc = mc.GetInstances();
            foreach (ManagementObject network in moc)
            {
                //if (!(bool)network["IPEnabled"])
                //    continue;
                lstNetworks.Items.Add(Convert.ToString(network["Caption"]));
            }
            if (lstNetworks.Items.Count == 0)
            {
                MessageBox.Show("没有找到网卡");
                Close();
            }
            lstNetworks.SelectedIndex = 0;

            this.main = main;
        }

        private void IpSetForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //mc.Dispose();
            if (moc != null)
                moc.Dispose();
            if (query != null)
                query.Dispose();
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control ctl = ((Control)sender);
            ctl.Enabled = false;
            ctl.Text = "请稍候...";

            string ip = txtIp.Text;
            string mask = txtMask.Text;
            string gateway = txtGateway.Text;
            string dns1 = txtDns1.Text;
            string dns2 = txtDns2.Text;

            if (radDhcp.Checked)
                ip = null;
            string msg;
            if (SetIP(lstNetworks.Text, ip, mask, gateway, dns1, dns2, out msg))
                MessageBox.Show("设置成功");
            else
                MessageBox.Show(msg);
            ctl.Enabled = true;
            ctl.Text = "设置";
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string filename = Filename;
            string newbk;
            if (radDhcp.Checked)
                newbk = "dhcp";
            else
            {
                string ip = txtIp.Text;
                string mask = txtMask.Text;
                string gateway = txtGateway.Text;
                string dns1 = txtDns1.Text;
                string dns2 = txtDns2.Text;
                newbk = string.Format("{0}_{1}_{2}_{3}_{4}", ip, mask, gateway, dns1, dns2);
            }
            List<string> iplist = GetIpBack();
            if(iplist.Contains(newbk))
            {
                MessageBox.Show("当前设置备份已经存在");
                return;
            }
            using (StreamWriter sw = new StreamWriter(filename, true, Encoding.UTF8))
            {
                sw.WriteLine(newbk + " " + lstNetworks.Text);
            }
            main.BindIpAbout();
            MessageBox.Show("当前设置备份成功");
        }

        private void radDhcp_CheckedChanged(object sender, EventArgs e)
        {
            bool isstatic = radStatic.Checked;
            txtIp.Enabled = isstatic;
            txtMask.Enabled = isstatic;
            txtGateway.Enabled = isstatic;
            txtDns1.Enabled = isstatic;
            txtDns2.Enabled = isstatic;
        }

        /// <summary>
        /// 网卡变更时，获取变更的网卡的ip信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstNetworks_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ManagementObject network in moc)
            {
                //string f = Path.Combine(HostsDal.AppDir, "netwrok");
                //if(!File.Exists(f))
                //    using(var aaa = new StreamWriter(f, false, Encoding.UTF8))
                //    {
                //        foreach (PropertyData property in network.Properties)
                //        {
                //            aaa.WriteLine("{0} {1}",property.Name,property.Value);
                //        }
                //    }

                if (lstNetworks.Text != Convert.ToString(network["Caption"]))
                {
                    continue;
                }
                txtMac.Text = lstNetworks.Text+Environment.NewLine + "MAC地址 " + Convert.ToString(network["MACAddress"]);

                string[] tmp = (network["IPAddress"] as String[]);
                if (tmp != null && tmp.Length > 0)
                {
                    txtIp.Text = tmp[0];
                }
                tmp = (network["IPSubnet"] as String[]);
                if (tmp != null && tmp.Length > 0)
                {
                    txtMask.Text = tmp[0];
                }
                tmp = (network["DefaultIPGateway"] as String[]);
                if (tmp != null && tmp.Length > 0)
                {
                    txtGateway.Text = tmp[0];
                }
                tmp = (network["DNSServerSearchOrder"] as String[]);
                if (tmp != null && tmp.Length > 0)
                {
                    txtDns1.Text = tmp[0];
                    if (tmp.Length > 1)
                        txtDns2.Text = tmp[1];
                }
                if ((bool)network["DHCPEnabled"])
                    radDhcp.Checked = true;
                else
                    radStatic.Checked = true;
                break;
            }
        }

        private void IpSetForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// 判断是否ip的正则
        /// </summary>
        static readonly Regex RegIsIp = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$", RegexOptions.Compiled);
        static bool IsValidIp(string ip)
        {
            return RegIsIp.IsMatch(ip);
        }

        public static bool SetIP(string sets, out string msg)
        {
            if (string.IsNullOrEmpty(sets))
            {
                msg = "设置为空";
                return false;
            }
            int idx = sets.IndexOf(' ');
            if (idx < 0 || idx == sets.Length - 1)
            {
                msg = "设置信息有误，网卡信息为空";
                return false;
            }
            string ips = sets.Substring(0, idx);
            string[] paras = ips.Split('_');
            if(paras.Length != 5)
            {
                msg = "设置信息有误，IP组长度不为5";
                return false;
            }
            string network = sets.Substring(idx + 1);
            return SetIP(network, paras[0], paras[1], paras[2], paras[3], paras[4], out msg);
        }
        /// <summary>
        /// networkname为空，表示设置第一个网卡;
        /// ip为空，表示使用dhcp方式
        /// </summary>
        /// <param name="networkname"></param>
        /// <param name="ip"></param>
        /// <param name="mask"></param>
        /// <param name="gateway"></param>
        /// <param name="dns1"></param>
        /// <param name="dns2"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SetIP(string networkname, string ip, string mask, string gateway, string dns1, string dns2, out string msg)
        {
            bool isDhcp;
            if (string.IsNullOrEmpty(ip))
                isDhcp = true;
            else
            {
                isDhcp = false;
                if (!IsValidIp(ip))
                {
                    msg = ("IP不正确");
                    return false;
                }
                if (!IsValidIp(mask))
                {
                    msg = ("子网掩码不正确");
                    return false;
                }
                if (!IsValidIp(gateway))
                {
                    msg = ("网关不正确");
                    return false;
                }
                if (!IsValidIp(dns1))
                {
                    msg = ("输入的DNS不正确");
                    return false;
                }
                if (!IsValidIp(dns2))
                {
                    dns2 = string.Empty;
                }
            }

            ManagementBaseObject inPar;
            //ManagementBaseObject outPar = null;
            bool setOk = false;
            var query = new ManagementObjectSearcher("Select * from Win32_NetWorkAdapterConfiguration where IPEnabled= 'TRUE'");
            foreach (ManagementObject network in query.Get())
            {
                if (!string.IsNullOrEmpty(networkname) && networkname != Convert.ToString(network["Caption"]))
                {
                    continue;
                }
                setOk = true;
                if (isDhcp && !(bool)network["DHCPEnabled"])
                {
                    inPar = network.GetMethodParameters("EnableDHCP");
                    network.InvokeMethod("EnableDHCP", inPar, null);
                }
                else
                {
                    //设置ip地址和子网掩码 
                    inPar = network.GetMethodParameters("EnableStatic");
                    inPar["IPAddress"] = new[] { ip };        // 主ip，第2个ip
                    inPar["SubnetMask"] = new[] { mask };     // 主ip的掩码，第2个ip的掩码
                    network.InvokeMethod("EnableStatic", inPar, null);

                    //设置网关地址 
                    inPar = network.GetMethodParameters("SetGateways");
                    inPar["DefaultIPGateway"] = new[] { gateway };     // 1.网关;2.备用网关
                    network.InvokeMethod("SetGateways", inPar, null);

                    //设置DNS 
                    inPar = network.GetMethodParameters("SetDNSServerSearchOrder");
                    if (string.IsNullOrEmpty(dns2))
                        inPar["DNSServerSearchOrder"] = new[] { dns1 };     // 1.DNS 2.备用DNS
                    else
                        inPar["DNSServerSearchOrder"] = new[] { dns1, dns2 };     // 1.DNS 2.备用DNS
                    network.InvokeMethod("SetDNSServerSearchOrder", inPar, null);
                }
                break;
            }
            msg = !setOk ? "未找到网卡" : string.Empty;
            return setOk;
        }

        public static List<string> GetIpBack()
        {
            List<string> ret = new List<string>();
            string filename = Filename;
            if (File.Exists(filename))
            {
                using (StreamReader sr = new StreamReader(filename, Encoding.UTF8))
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

    }
}
