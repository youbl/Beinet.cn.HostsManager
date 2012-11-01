using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Beinet.cn.HostsManager
{
    /*
     * 2.0  更新：1、不再支持一行多域名；2、IP列设置为Combox，一个域名只允许一行显示，避免同一域名大量配置时，很难找，
     * 1.9.0更新：增加分组和折叠功能，避免大量配置时，东西太多
     * 1.8.2更新：修正IP设置的bug，添加几个快捷键设置
     * 1.8.1更新：修改搜索方案：隐藏不包含搜索词的行（只是隐藏，并不删除，保存时，隐藏的行也能正常保存）
     * 1.8  更新：增加NsLookup域名解析功能，且可以配置电信和网通dns用于解析
     * 1.7  更新：保存时删除域名里的http前缀；删除域名前后的空格；增加ip设置工具
     * 1.6  更新：增加行号；增加右键菜单快捷键；修改bug：窗口最前时，弹出另存为窗口被挡住
     * 1.5  更新：增加窗口最前菜单
     * 1.4  更新：支持单进程模式；增加工具：添加VS2008分隔行；修改检索功能；增加帮助里的说明内容；using的行，设置为粗体显示；设置隔行颜色和当前行亮色
     * 1.3  更新：增加检索功能；增加按钮 加到快捷行
    */
    public partial class MainForm : Form
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public const string version = "2.0";

        // 总列数
        private const int COLNUM = 11;
        // 折叠标记所在列号
        private const int COL_COLLPASE = 0;       
        private const string SYM_COL = "─";
        private const string SYM_EXT = "╀";
        // ip所在列号
        private const int COL_IP = 1;
        // 对应域名所在列号
        private const int COL_NAME = 2;
        // 备注所在列号
        private const int COL_DESC = 3;
        // 分组所在列号，排序用
        private const int COL_GROUP = 4;
        // 当前行是否应用
        private const int COL_USE = 5;
        // 用于删除当前行的链接
        private const int COL_DEL = 6;
        // IE打开当前行域名的链接
        private const int COL_IE = 7;
        // 当前行加入快捷行的链接
        private const int COL_QUICK = 8;
        // 对当前行域名执行Ping命令的链接
        private const int COL_PING = 9;
        // 对当前行域名执行Nslookup命令的链接
        private const int COL_NSLOOKUP = 10;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy,
                                               long wFlags);


        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            Text = "Hosts修改工具" + version + "-beinet.cn";

            isValueChanged = false;


            // 备份系统host（已备份过不会再备份）
            HostsDal.BackupHosts();

            BindHosts(string.Empty);

            BindHistory();

            BindQuickLines();

            BindIpAbout();

            // 设置DataGridView为单击进入编辑状态，而不是普通的双击
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            // 设置复制模式为包含标题
            //dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            // 设置protected属性，此属性指示此控件是否应使用辅助缓冲区重绘其图面，以 减少或避免闪烁（CellMouseEnter里修改背景色会导致闪烁）
            typeof(DataGridView).GetProperty("DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic).SetValue(dataGridView1, true, null);

            // 窗口置顶
            if (HostsDal.StartFront)
            {
                mnuTopMost_Click(null, null);
            }

            ///todo:检查更新的代码启用
            //CheckUpdate();
        }

        private bool isValueChanged;// 标识内容是否改变了

        protected override void OnClosing(CancelEventArgs e)
        {
            // 内容改变时，不退出
            if (isValueChanged)
            {
                if (MessageBox.Show("内容未保存到hosts，是否退出？", "内容已改变", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 加载host记录
        /// </summary>
        /// <param name="name"></param>
        private void BindHosts(string name)
        {
            dataGridView1.Rows.Clear();

            // 读取记录
            List<HostItem> hosts = HostsDal.GetHosts(name);
            //dataGridView1.DataSource = hosts;
            if (hosts != null)
            {
                int lastgroup = -1;
                int rowid = -1;
                HostItem groupStatus = null;

                // 用于维持保存时的收缩状态
                Dictionary<int, int> groupMainRow = new Dictionary<int, int>();

                // 用于每个域名只显示一行记录
                Dictionary<string, DataGridViewComboBoxCell> domains = new Dictionary<string, DataGridViewComboBoxCell>();
                foreach (HostItem item in hosts)
                {
                    // 这种条件只用于存分组信息
                    if(item.IP == "1.1.1.1" && item.Name == "group")
                    {
                        groupStatus = item;
                        continue;
                    }
                    string domain = item.Name.Trim().ToLower();
                    DataGridViewComboBoxCell cell;
                    if(domains.TryGetValue(domain, out cell))
                    {
                        if (!cell.Items.Contains(item.IP))
                            cell.Items.Add(item.IP);
                        if (item.IsUsing)
                        {
                            cell.Value = item.IP;
                            cell.OwningRow.Cells[COL_USE].Value = true;
                        }
                        continue;
                    }

                    object[] rowValue = new object[COLNUM];
                    if (lastgroup != item.Group)
                        rowValue[COL_COLLPASE] = SYM_COL;

                    rowValue[COL_IP] = null;
                    rowValue[COL_NAME] = item.Name.Trim();
                    rowValue[COL_DESC] = item.Description.Trim();
                    rowValue[COL_USE] = item.IsUsing;
                    rowValue[COL_GROUP] = item.Group;
                    rowValue[COL_DEL] = "删除";
                    rowValue[COL_IE] = "IE打开";
                    rowValue[COL_QUICK] = "加到快捷行";
                    rowValue[COL_PING] = "PING";
                    rowValue[COL_NSLOOKUP] = "NsLookup";

                    int rowIndex = dataGridView1.Rows.Add(rowValue);
                    var row = dataGridView1.Rows[rowIndex];
                    //((DataGridViewComboBoxCell) row.Cells[COL_IP]).DataSource = new string[] {item.IP};
                    ((DataGridViewComboBoxCell)row.Cells[COL_IP]).Items.Add(item.IP);
                    row.Cells[COL_IP].Value = item.IP;
                    domains.Add(domain, ((DataGridViewComboBoxCell)row.Cells[COL_IP]));

                    if (lastgroup != item.Group)
                    {
                        groupMainRow[item.Group] = rowIndex;
                        rowid = rowIndex;
                        row.Tag = -1;
                    }
                    else
                        row.Tag = rowid;// 保存分组第一行的行号，用于查找时，不会误显示

                    row.Cells[COL_COLLPASE].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    ((DataGridViewLinkCell)row.Cells[COL_COLLPASE]).LinkBehavior = LinkBehavior.NeverUnderline;

                    row.Cells[COL_USE].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (item.IsUsing)
                    {
                        SetFontBold(dataGridView1.Rows[rowIndex], true);
                    }

                    lastgroup = item.Group;
                }

                // 维持保存时的收缩状态
                if(groupStatus != null)
                {
                    string[] groups = groupStatus.Description.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string grp in groups)
                    {
                        int grpInt, mrowid;
                        if (int.TryParse(grp, out grpInt) && groupMainRow.TryGetValue(grpInt, out mrowid))
                        {
                            // 收缩分组
                            //dataGridView1.Rows[mrowid].Cells[0].
                            dataGridView1_CellClick(null, new DataGridViewCellEventArgs(COL_COLLPASE, mrowid));
                        }
                    }
                }
            }

            // 重新加载hosts，内容为未改变
            if (string.IsNullOrEmpty(name))
                isValueChanged = false;
            else
                isValueChanged = true;

            //搜索框不为空时，进行检索
            if (!string.IsNullOrEmpty(txtFindStripTextBox1.Text))
                txtFindStripTextBox1_KeyUp(null, null);
        }

        /// <summary>
        /// 加载历史文件菜单
        /// </summary>
        private void BindHistory()
        {
            LinksToolStripMenuItem.DropDownItems.Clear();

            // 加载保存的历史文件到菜单
            ToolStripMenuItem history;
            foreach (string file in HostsDal.GetHostHistory())
            {
                history = new ToolStripMenuItem(file);
                history.Click += LinkItemStripMenuItem_Click;
                LinksToolStripMenuItem.DropDownItems.Add(history);
            }
        }

        /// <summary>
        /// 绑定快捷行配置
        /// </summary>
        private void BindQuickLines()
        {
            // 清除快捷行菜单
            for (int i = lnkLineToolStripMenuItem.DropDownItems.Count - 3; i >= 0; i--)
            {
                lnkLineToolStripMenuItem.DropDownItems.RemoveAt(i);
            }

            List<string> quickLines = HostsDal.GetQuickLineData();
            ToolStripMenuItem line;
            for (int i = quickLines.Count - 1; i >= 0; i--)
            {
                line = new ToolStripMenuItem(quickLines[i]);
                line.Click += QuickLineItemStripMenuItem_Click;
                lnkLineToolStripMenuItem.DropDownItems.Insert(0, line);
            }
        }

        /// <summary>
        /// 绑定快捷行配置
        /// </summary>
        public void BindIpAbout()
        {
            // 清除快捷行菜单
            for (int i = mnuIpAbout.DropDownItems.Count - 1; i >= 3; i--)
            {
                mnuIpAbout.DropDownItems.RemoveAt(i);
            }

            List<string> ipsets = IpSetForm.GetIpBack();
            ToolStripMenuItem line;
            foreach (string ip in ipsets)
            {
                line = new ToolStripMenuItem(ip);
                line.Click += IpSetItemStripMenuItem_Click;
                mnuIpAbout.DropDownItems.Add(line);
            }
        }

        #region DataGridView相关事件

        /// <summary>
        /// 从DataGridView获取修改后的数据，用于保存
        /// </summary>
        /// <returns></returns>
        private List<HostItem> GetGridHost()
        {
            // 先清空搜索条件
            if (txtFindStripTextBox1.Text != string.Empty || txtFindStripTextBox1.Text != "请输入查找关键字")
            {
                txtFindStripTextBox1.Text = string.Empty;
                txtFindStripTextBox1_KeyUp(null, null);
            }

            List<HostItem> save = new List<HostItem>();
            StringBuilder groupStatus = new StringBuilder();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string ipCurrent = Convert.ToString(row.Cells[COL_IP].EditedFormattedValue).Trim();// 不能用Value，会取得未提交的数据
                DataGridViewComboBoxCell ipcell = (DataGridViewComboBoxCell) row.Cells[COL_IP];
                bool use = Convert.ToBoolean(row.Cells[COL_USE].Value); //row.Cells[COL_USE].Selected;
                string name = Convert.ToString(row.Cells[COL_NAME].Value).Trim();
                string desc = Convert.ToString(row.Cells[COL_DESC].Value).Trim();
                int group;
                if (!int.TryParse(Convert.ToString(row.Cells[COL_GROUP].Value), out group))
                    group = 0;
                string collpase = Convert.ToString(row.Cells[COL_COLLPASE].Value).Trim();

                // 用于保存当前分组收缩展开状态
                if (!string.IsNullOrEmpty(collpase) && collpase == SYM_EXT)
                    groupStatus.AppendFormat("{0};", group);

                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(desc))
                    continue;

                bool isCurrentUsed = false;
                foreach (string ip in ipcell.Items)
                {
                    if (string.IsNullOrEmpty(ip))
                        continue;

                    if (!isCurrentUsed) 
                        isCurrentUsed = ipCurrent == ip;
                    bool currentUse = (ipCurrent == ip ? use : false);
                    // 使用中的域名，要判断是否重复了
                    if (currentUse)
                    {
                        if (save.Find(i => (i.IsUsing && i.Name.Equals(name, StringComparison.OrdinalIgnoreCase))) !=
                            null)
                        {
                            MessageBox.Show("域名：" + name + "存在重复配置，请检查后再重新保存");
                            return null;
                        }
                    }
                    HostItem item = new HostItem(ip, name, desc, currentUse, group);
                    if (!HostsDal.RegItem.IsMatch(item.ToString()))
                    {
                        MessageBox.Show("ip:" + ip + " 域名:" + name + "配置错误，请检查后再重新保存");
                        return null;
                    }
                    save.Add(item);
                }
                if(!isCurrentUsed)
                {
                    // 使用中的域名，要判断是否重复了
                    if (use)
                    {
                        if (save.Find(i => (i.IsUsing && i.Name.Equals(name, StringComparison.OrdinalIgnoreCase))) !=
                            null)
                        {
                            MessageBox.Show("域名：" + name + "存在重复配置，请检查后再重新保存");
                            return null;
                        }
                    }
                    HostItem item = new HostItem(ipCurrent, name, desc, use, group);
                    if (!HostsDal.RegItem.IsMatch(item.ToString()))
                    {
                        MessageBox.Show("ip:" + ipCurrent + " 域名:" + name + "配置错误，请检查后再重新保存");
                        return null;
                    }
                    save.Add(item);
                }
            }

            // 用于保存当前分组收缩展开状态
            if (groupStatus.Length > 0)
                save.Add(new HostItem("1.1.1.1", "group", groupStatus.ToString(), false, 0));
            return save;
        }

        /// <summary>
        /// Checkbox列ReadOnly为false时，Value经常与Checkbox状态不符
        /// 只好改成ReadOnly=true，再通过CellClick来处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewRow dgvRow = dataGridView1.Rows[e.RowIndex];

            #region 点击折叠的代码
            if (e.RowIndex < dataGridView1.Rows.Count && e.ColumnIndex == COL_COLLPASE)
            {
                if (txtFindStripTextBox1.Text == string.Empty || txtFindStripTextBox1.Text == "请输入查找关键字")
                {
                    string val = Convert.ToString(dgvRow.Cells[e.ColumnIndex].Value).Trim();
                    if (val != string.Empty)
                    {
                        bool visable;
                        if (val == SYM_COL)
                        {
                            dgvRow.Cells[e.ColumnIndex].Value = SYM_EXT;
                            visable = false;
                        }
                        else
                        {
                            dgvRow.Cells[e.ColumnIndex].Value = SYM_COL;
                            visable = true;
                        }
                        for (var i = e.RowIndex + 1; i < dataGridView1.Rows.Count; i++)
                        {
                            var row = dataGridView1.Rows[i];
                            if (row.IsNewRow)
                                break;
                            val = Convert.ToString(row.Cells[e.ColumnIndex].Value).Trim();
                            if (val != string.Empty)
                                break;
                            row.Visible = visable;
                        }
                    }
                }
            }

            #endregion

            #region 修改CheckBox的代码
            if (e.RowIndex < dataGridView1.Rows.Count && e.ColumnIndex == COL_USE)
            {
                bool isUsing = dgvRow.Cells[e.ColumnIndex].Value == null ? true : !(bool)dgvRow.Cells[e.ColumnIndex].Value;

                dgvRow.Cells[e.ColumnIndex].Value = isUsing;

                SetFontBold(dgvRow, isUsing);   // 修改粗体显示

                // 启用host记录时，检查是否存在重复项
                if (isUsing)
                {
                    string name1 = Convert.ToString(dgvRow.Cells[COL_NAME].Value); // 当前行的域名
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Index == e.RowIndex)                 // 同一行不比较
                            continue;
                        if (!Convert.ToBoolean(row.Cells[COL_USE].Value))  // 未启用，不比较
                            continue;

                        string name2 = Convert.ToString(row.Cells[COL_NAME].Value);
                        if (name2.Equals(name1, StringComparison.OrdinalIgnoreCase))
                        {
                            if (MessageBox.Show(name1 + " 域名配置已存在并启用，是否覆盖？", "配置已存在", MessageBoxButtons.YesNo)
                                != DialogResult.Yes)
                            {
                                dgvRow.Cells[e.ColumnIndex].Value = false;
                                break;
                            }
                            row.Cells[e.ColumnIndex].Value = false; // 覆盖同名的配置
                            //break;// 可能有多个重复项，所以不退出
                        }
                    }
                }
            }
            #endregion

            #region 点击删除按钮
            if (e.RowIndex < dataGridView1.Rows.Count - 1 && e.ColumnIndex == COL_DEL)//Rows.Count - 1是不让点击未提交的新行
            {
                isValueChanged = true;
                var ipcell = (DataGridViewComboBoxCell) dataGridView1.Rows[e.RowIndex].Cells[COL_IP];
                if (ipcell.Items.Count <= 1)
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    dataGridView1.ClearSelection();
                }
                else
                {
                    // 有多个ip时，只移除一个ip，必须加上下面2行，不然自定义的comboBox_Validating事件，又会把这个ip加上
                    var removeIp = ipcell.Value;
                    ipcell.Value = string.Empty;
                    ipcell.Items.Remove(removeIp);
                    if (ipcell.Items.Count > 0)
                        ipcell.Value = ipcell.Items[0];
                    dgvRow.Cells[COL_USE].Value = false;// 设置为不启用
                    SetFontBold(dgvRow, false);
                }
            }
            #endregion

            #region 点击IE打开按钮
            if (e.RowIndex < dataGridView1.Rows.Count - 1 && e.ColumnIndex == COL_IE)//Rows.Count - 1是不让点击未提交的新行
            {
                string url = Convert.ToString(dgvRow.Cells[COL_NAME].Value);
                if (!string.IsNullOrEmpty(url))
                    Process.Start("IExplore.exe", url);
                else
                    ShowMsg("请输入域名");
            }
            #endregion

            #region 点击加到快捷行按钮
            if (e.RowIndex < dataGridView1.Rows.Count - 1 && e.ColumnIndex == COL_QUICK)//Rows.Count - 1是不让点击未提交的新行
            {
                DataGridViewRow row = dgvRow;
                string ip = Convert.ToString(row.Cells[COL_IP].Value).Trim();
                string name = Convert.ToString(row.Cells[COL_NAME].Value).Trim();
                string desc = Convert.ToString(row.Cells[COL_DESC].Value).Trim();

                if (string.IsNullOrEmpty(ip) && string.IsNullOrEmpty(name) && string.IsNullOrEmpty(desc))
                {
                    ShowMsg("空行不能添加");
                    return;
                }

                HostItem item = new HostItem(ip, name, desc, true, 0);
                string rec = item.ToString();
                if (!HostsDal.RegItem.IsMatch(rec))
                {
                    ShowMsg("本行配置错误，不能添加");
                    return;
                }

                // 保存到快捷行
                string tmp = HostsDal.GetQuickLines();
                if (!string.IsNullOrEmpty(tmp))
                    tmp += "\r\n";
                HostsDal.SaveQuickLines(tmp + rec);
                ShowMsg("添加成功，请查看快捷行菜单");
                // 重新加载快捷行菜单
                BindQuickLines();
            }
            #endregion

            #region 点击PING按钮
            if (e.RowIndex < dataGridView1.Rows.Count - 1 && e.ColumnIndex == COL_PING)//Rows.Count - 1是不让点击未提交的新行
            {
                string url = Convert.ToString(dgvRow.Cells[COL_NAME].Value);
                if (!string.IsNullOrEmpty(url))
                {
                    using (Process p = new Process())
                    {
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.UseShellExecute = true; // 在当前进程中启动，不使用系统外壳程序启动
                        //p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;// 让dos窗体最大化
                        p.StartInfo.Arguments = "/C ping " + url; //设定参数，其中的“/C”表示执行完命令后马上退出
                        p.StartInfo.RedirectStandardInput = false; //设置为true，后面可以通过StandardInput输入dos命令
                        //p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = false;
                        //p.StartInfo.CreateNoWindow = true;     //不创建窗口
                        p.Start();
                        //SetWindowPos(p.Handle, 3, Left, Top, Width, Height, 8);
                        //p.StandardInput.WriteLine("ping " + url);
                        //p.WaitForExit(1000);
                        //MessageBox.Show(p.StandardOutput.ReadToEnd());
                        p.Close();
                    }
                }
                else
                    ShowMsg("请输入域名");
            }
            #endregion

            #region 点击NsLookup按钮
            if (e.RowIndex < dataGridView1.Rows.Count - 1 && e.ColumnIndex == COL_NSLOOKUP)//Rows.Count - 1是不让点击未提交的新行
            {
                string url = Convert.ToString(dgvRow.Cells[COL_NAME].Value);
                if (!string.IsNullOrEmpty(url))
                {
                    using (Process p = new Process())
                    {
                        p.StartInfo.FileName = "cmd.exe";
                        p.StartInfo.UseShellExecute = true; // 在当前进程中启动，不使用系统外壳程序启动
                        //p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;// 让dos窗体最大化

                        //设定参数，其中的“/C”表示执行完命令后马上退出
                        p.StartInfo.Arguments = string.Format("/C \"@echo =====电信结果===== && nslookup {0} {1} && " +
                            "@echo =====网通结果===== && nslookup {0} {2} && pause\"",
                            url, HostsDal.TelecomDns, HostsDal.UnicomDns); 
                        p.StartInfo.RedirectStandardInput = false; //设置为true，后面可以通过StandardInput输入dos命令
                        //p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = false;
                        //p.StartInfo.CreateNoWindow = true;     //不创建窗口
                        p.Start();
                        //SetWindowPos(p.Handle, 3, Left, Top, Width, Height, 8);
                        //p.StandardInput.WriteLine("ping " + url);
                        //p.WaitForExit(11000);
                        //MessageBox.Show(p.StandardOutput.ReadToEnd());
                        p.Close();
                    }
                }
                else
                    ShowMsg("请输入域名");
            }
            #endregion
        }

        /// <summary>
        /// 点击右键时，选中行，用于弹出菜单操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int rowIndex = 0;

                if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count - 1)
                {
                    rowIndex = e.RowIndex;
                }
                int col = e.ColumnIndex >= 0 ? e.ColumnIndex : 0;
                SelectCell(dataGridView1.Rows[rowIndex], col);
            }
        }

        /// <summary>
        /// 设置指定行为选中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="colIndex"></param>
        private void SelectCell(DataGridViewRow row, int colIndex)
        {
            //dataGridView1.CurrentCell.Selected = false;
            //dataGridView1.CurrentRow.Selected = false;
            dataGridView1.ClearSelection();
            dataGridView1.CurrentCell = row.Cells[colIndex];
            //row.Selected = true;
            row.Cells[colIndex].Selected = true;
            if (lastRowIndex > -1)
                SetBackColor(dataGridView1.Rows[lastRowIndex], false); 
            SetBackColor(row, true);
            lastRowIndex = row.Index;
        }

        private void SelectAllCell(int colIndex, bool selected)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[colIndex].Value = selected;
            }
        }

        /// <summary>
        /// 单元格内容变更时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isValueChanged = true;
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            isValueChanged = true;
        }

        /// <summary>
        /// 当Cell值改变时，立即提交改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;
            // 如果是新行，给最后一格添加删除字样
            if (dataGridView1.CurrentRow.Cells[COL_DEL].Value == null)
            {
                dataGridView1.CurrentRow.Cells[COL_GROUP].Value = "999";
                dataGridView1.CurrentRow.Cells[COL_DEL].Value = "删除";
                dataGridView1.CurrentRow.Cells[COL_IE].Value = "IE打开";
                dataGridView1.CurrentRow.Cells[COL_QUICK].Value = "加到快捷行";
                dataGridView1.CurrentRow.Cells[COL_PING].Value = "PING";
                dataGridView1.CurrentRow.Cells[COL_NSLOOKUP].Value = "NsLookup";
            }

            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private int lastRowIndex = -1;   // 记录最后改变的行号
        /// <summary>
        /// 鼠标进入时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            var cnt = dataGridView1.Rows.Count - 1;
            var currRow = e.RowIndex;
            if (currRow < cnt && currRow >= 0 && lastRowIndex != currRow)
            {
                if (lastRowIndex > -1 && lastRowIndex < cnt)
                    SetBackColor(dataGridView1.Rows[lastRowIndex], false);
                SetBackColor(dataGridView1.Rows[currRow], true);
                lastRowIndex = currRow;
            }
        }

        #endregion

        #region 菜单操作
        /// <summary>
        /// 打开Hosts所在目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSysDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(HostsDal.SysDir);
        }

        /// <summary>
        /// 用记事本打开hosts文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditHostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", HostsDal.HostsPath);
        }

        /// <summary>
        /// 保存到hosts文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<HostItem> save = GetGridHost();
            if (save == null)
                return;
            HostsDal.SaveHosts(string.Empty, save);
            BindHosts(string.Empty);
            ShowMsg("应用成功");
        }

        /// <summary>
        /// 保存到已选择的快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SaveHistoryToolStripMenuItem
            string name = ((ToolStripMenuItem)sender).Text.Split(' ')[1];
            List<HostItem> save = GetGridHost();
            if (save == null)
                return;
            HostsDal.SaveHosts(name, save);
        }

        /// <summary>
        /// 另存为新快捷方式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string defaultTxt;
            //if(SaveHistoryToolStripMenuItem.Visible)
            //{
            string defaultTxt = SaveHistoryToolStripMenuItem.Text.Split(' ')[1];
            //}

            // 窗口最前时，会导致InputBox被隐藏
            var topmost = TopMost;
            TopMost = false;
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "请输入快捷方式名", "请输入快捷方式名", defaultTxt, 100, 100);
            TopMost = topmost;
            if (!string.IsNullOrEmpty(name))
            {
                if (File.Exists(HostsDal.GetFileName(name)))
                {
                    if (MessageBox.Show("快捷方式文件已存在，是否覆盖？", "文件已存在", MessageBoxButtons.YesNo)
                        != DialogResult.Yes)
                    {
                        return;
                    }
                }
                List<HostItem> save = GetGridHost();
                if (save == null)
                    return;
                HostsDal.SaveHosts(name, save);
                BindHistory();
            }
        }

        /// <summary>
        /// 快捷方式打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkItemStripMenuItem_Click(object sender, EventArgs e)
        {
            string ext = ((ToolStripMenuItem)sender).Text;
            if (!File.Exists(HostsDal.GetFileName(ext)))
            {
                ShowMsg("快捷方式不存在");
                return;
            }

            if (!isValueChanged ||
                MessageBox.Show("内容未保存到hosts，是否继续？", "内容已改变", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SaveHistoryToolStripMenuItem.Visible = true;
                SaveHistoryToolStripMenuItem.Text = "保存 " + ext;

                bool copyed = false;
                // 立即应用
                if (HostsDal.LinkQuickUse)
                {
                    File.Copy(HostsDal.GetFileName(ext), HostsDal.HostsPath, true);
                    copyed = true;
                    ShowMsg("应用成功");
                }
                else
                {
                    ShowMsg("加载成功，未应用到hosts");
                }
                BindHosts(ext);
                isValueChanged = !copyed;
            }
        }

        /// <summary>
        /// 弹出配置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConfigForm().ShowDialog(this);
            // 因为可能修改编码格式和快捷方式保存位置,重新加载
            BindHosts(string.Empty);

            BindHistory();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 弹出帮助信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutHostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HelpForm().ShowDialog(this);
        }

        /// <summary>
        /// 显示计算机信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowComputerInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ComputerForm().ShowDialog(this);
        }

        /// <summary>
        /// 打开应用程序目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenAppDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(HostsDal.AppDir);
        }

        /// <summary>
        /// 去贝网网站
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://beinet.cn");
        }

        /// <summary>
        /// 重新加载hosts文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reloadhostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isValueChanged ||
                MessageBox.Show("内容未保存到hosts，是否继续？", "内容已改变", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                BindHosts(string.Empty);
                SaveHistoryToolStripMenuItem.Visible = false;
            }
        }

        /// <summary>
        /// 快捷行配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkLineConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuickLineForm().ShowDialog(this);
            // 重新加载快捷行菜单
            BindQuickLines();
        }

        /// <summary>
        /// 快捷行菜单点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuickLineItemStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isValueChanged || MessageBox.Show("内容未保存到hosts，是否继续？", "内容已改变", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<HostItem> gvHosts = GetGridHost();
                string[] quickLines = ((ToolStripMenuItem)sender).Text.Split(';');
                foreach (string line in quickLines)
                {
                    Match match = HostsDal.RegItem.Match(line);
                    if (match.Success)
                    {
                        string ip = match.Result("$1");
                        string name = match.Result("$2");
                        string desc = match.Result("$3");
                        bool use = !line.StartsWith("#");

                        // 存在相同项时，不添加
                        HostItem tmp = gvHosts.Find(i => i.IsUsing == use && i.IP == ip && 
                            i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (tmp == null)
                        {
                            object[] rowValue = new object[COLNUM];
                            rowValue[COL_IP] = ip;
                            rowValue[COL_NAME] = name;
                            rowValue[COL_DESC] = desc;
                            rowValue[COL_USE] = use;
                            rowValue[COL_GROUP] = 0;
                            rowValue[COL_DEL] = "删除";
                            rowValue[COL_IE] = "IE打开";
                            rowValue[COL_QUICK] = "加到快捷行";
                            rowValue[COL_PING] = "PING";
                            rowValue[COL_NSLOOKUP] = "NsLookup";
                            dataGridView1.Rows.Add(rowValue);
                        }
                    }
                }

                SaveToolStripMenuItem_Click(null, null);
            }
        }

        /// <summary>
        /// IP备份菜单点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IpSetItemStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg;
            if (IpSetForm.SetIP(((ToolStripMenuItem)sender).Text, out msg))
            {
                ShowMsg("IP设置成功");
            }
            else
            {
                ShowMsg("IP设置失败:" + msg);
            }
        }

        /// <summary>
        /// 文本框有输入时，进行检索，并只显示搜索到的行项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFindStripTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            ToolStripTextBox txtMenu = txtFindStripTextBox1;// sender as ToolStripTextBox;
            if (e != null && e.Control && e.KeyCode == Keys.A)
            {
                txtMenu.SelectAll();
                return;
            }

            if (txtMenu != null)
            {
                dataGridView1.ClearSelection();
                string search = txtMenu.Text ?? string.Empty;
                bool isempty = string.IsNullOrEmpty(search) || search == "请输入查找关键字";
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow)
                        continue;
                    if (isempty && row.Tag != null)
                    {
                        int mainrowid = (int) row.Tag;
                        if (mainrowid >= 0)
                        {
                            var mainRow = dataGridView1.Rows[mainrowid];
                            string val = Convert.ToString(mainRow.Cells[COL_COLLPASE].Value).Trim();
                            if (val == SYM_COL)
                                row.Visible = true;
                            else
                                row.Visible = false;
                        }
                        else
                            row.Visible = true;

                        continue;
                    }
                    var visible = false;
                    string txt = Convert.ToString(row.Cells[COL_IP].Value);
                    if (txt.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        visible = true;
                    txt = Convert.ToString(row.Cells[COL_NAME].Value);
                    if (txt.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        visible = true;
                    txt = Convert.ToString(row.Cells[COL_DESC].Value);
                    if (txt.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
                        visible = true;
                    row.Visible = visible;
                    //bool use = Convert.ToBoolean(row.Cells[3].Value);
                    //FindWord(row.Cells[0], search, use, lstSearchMenu.ComboBox.SelectedIndex);
                    //FindWord(row.Cells[1], search, use, lstSearchMenu.ComboBox.SelectedIndex);
                    //FindWord(row.Cells[2], search, use, lstSearchMenu.ComboBox.SelectedIndex);
                }
            }
        }

        private void txtFindStripTextBox1_DoubleClick(object sender, EventArgs e)
        {
            ToolStripTextBox txtMenu = txtFindStripTextBox1;// sender as ToolStripTextBox;
            txtMenu.SelectAll();
        }

        /// <summary>
        /// 点击检索文本框时，进行检索（没找到Focus事件）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFindStripTextBox1_Click(object sender, EventArgs e)
        {
            txtFindStripTextBox1_KeyUp(null, null);
        }

        /// <summary>
        /// 窗口最前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuTopMost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            mnuTopMost.Text = TopMost ? "取消窗口最前" : "保持窗口最前";
        }

        #region 让显示器黑屏
        // 添加SendMessage非托管方法的引用和相应常量设定
        static readonly IntPtr HWND_BROADCAST = new IntPtr(0xffff);
        const uint WM_SYSCOMMAND = 0x0112;
        const int SC_MONITORPOWER = 0xf170;
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// 让显示器黑屏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 最后一个参数等于2 为关闭显示器， -1则打开显示器 
            SendMessage(HWND_BROADCAST, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }
        #endregion


        #region 注册表相关操作
        /// <summary>
        /// 修改注册表使hosts修改立即生效
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditRegToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey regDir;
            string dir = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
            using (RegistryKey root = Registry.CurrentUser)
            using (regDir = root.OpenSubKey(dir, true))
            {
                if (regDir == null)
                {
                    root.CreateSubKey(dir);
                    regDir = root.OpenSubKey(dir, true);
                    if (regDir == null) 
                        return;
                }

                regDir.SetValue("DnsCacheEnabled", 0, RegistryValueKind.DWord);
                regDir.SetValue("DnsCacheTimeout", 0, RegistryValueKind.DWord);
                regDir.SetValue("ServerInfoTimeOut", 0, RegistryValueKind.DWord);
                regDir.Close();
            }
            ShowMsg("操作成功");
        }

        /// <summary>
        /// 修改注册表，修正IE8新建选项卡时报“找不到元素”的js错误
        /// 1.打开注册表编辑器：REGEDIT.
        /// 2.找到HKEY_CLASSES_ROOT\TypeLib\{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}\1.1\0\win32
        /// 3.点击：默认。如果其值为："C:\WINDOWS\system32\shdocvw.dll"将shdocvm.dll修改为：ieframe.dll
        /// 4.重启IE 即可。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IE8JsErrFixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistryKey root;
            RegistryKey regDir;
            string dir = @"SOFTWARE\Microsoft\Internet Explorer";
            using (root = Registry.LocalMachine)
            using (regDir = root.OpenSubKey(dir))
            {
                string ieVersion = string.Empty;
                if (regDir != null)
                {
                    ieVersion = Convert.ToString(regDir.GetValue("Version"));
                }
                if (string.IsNullOrEmpty(ieVersion))
                {
                    ShowMsg("操作失败,未查找到IE版本号");
                    return;
                }
                if (!ieVersion.StartsWith("8."))
                {
                    ShowMsg("操作失败,仅支持IE8\r\n您的IE版本:" + ieVersion);
                    return;
                }
            }

            dir = @"TypeLib\{EAB22AC0-30C1-11CF-A7EB-0000C05BAE0B}\1.1\0\win32";
            using (root = Registry.ClassesRoot)
            using (regDir = root.OpenSubKey(dir, true))
            {
                if (regDir == null)
                {
                    root.CreateSubKey(dir);
                    regDir = root.OpenSubKey(dir, true);
                    if (regDir == null)
                        return;
                }
                // 修改默认键值
                regDir.SetValue("",
                    Path.Combine(Environment.SystemDirectory, @"ieframe.dll"), //C:\WINDOWS\system32\
                    RegistryValueKind.String);
                regDir.Close();
            }
            ShowMsg("操作成功,请重启IE8");
        }

        /// <summary>
        /// 为VisualStudio2008添加代码分隔线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLineForVisualStudio2008ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string defaultTxt = "RGB(255,0,0) 80, 120";
            defaultTxt = Microsoft.VisualBasic.Interaction.InputBox(
    "RGB括号里表示分隔线的RGB颜色\r\n括号后面以逗号分隔的数字，表示要添加的分隔线位置\r\n比如默认是第80列和第120列添加红色分隔线\r\n\r\n输入空白或点击取消表示删除", "请输入分隔线颜色、位置等信息", defaultTxt, 100, 100);
            //if (!Regex.IsMatch(defaultTxt, @"^RGB\(\d+,\d+,\d+\) *\d+(, *\d+)*$", RegexOptions.IgnoreCase))
            //{
            //    ShowMsg("无效的输入");
            //    return;
            //}

            RegistryKey root;
            RegistryKey regDir;
            string dir = @"Software\Microsoft\VisualStudio\9.0\Text Editor";
            using (root = Registry.CurrentUser)
            using (regDir = root.OpenSubKey(dir, true))
            {
                if (regDir == null)
                {
                    ShowMsg("操作失败,未找到VisualStudio2008");
                    return;
                }
                if (string.IsNullOrEmpty(defaultTxt))
                {
                    regDir.DeleteValue("Guides", false);
                    ShowMsg("配置删除成功");
                }
                else
                {
                    regDir.SetValue("Guides", defaultTxt, RegistryValueKind.String);
                    ShowMsg("配置成功，请重新打开VS2008");
                }
            }
        }
        #endregion


        /// <summary>
        /// 打开网络连接窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpenNetworkAttr_Click(object sender, EventArgs e)
        {
            Process.Start("Ncpa.cpl");//或者用： rundll32.exe shell32.dll,Control_RunDLL "ncpa.cpl"
        }

        /// <summary>
        /// 打开IP设置窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuOpenIpSet_Click(object sender, EventArgs e)
        {
            new IpSetForm(this).ShowDialog(this);
        }

        #endregion

        #region 右键菜单操作
        /// <summary>
        /// 删除行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuDel_Click(object sender, EventArgs e)
        {
            if (!dataGridView1.CurrentCell.OwningRow.IsNewRow)
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentCell.OwningRow);
                isValueChanged = true;
            }
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();//.CurrentRow.Selected = false;
            dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Selected = true;
            dataGridView1.BeginEdit(true);
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(null, null);
        }

        private void menuSaveas_Click(object sender, EventArgs e)
        {
            SaveAsToolStripMenuItem_Click(null, null);
        }

        private void menuConfig_Click(object sender, EventArgs e)
        {
            ConfigToolStripMenuItem_Click(null, null);
        }

        private void menuMoveTop_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            int index = row.Index;
            if (index != 0)
            {
                // 记录当前格的列号
                int colIndex = dataGridView1.CurrentCell.ColumnIndex;

                dataGridView1.Rows.Remove(row);
                dataGridView1.Rows.Insert(0, row);
                // 重新设置这行的这列为选中
                SelectCell(row, colIndex);
                isValueChanged = true;
            }
        }

        private void moveUp_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            int index = row.Index;
            if (index != 0)
            {
                // 记录当前格的列号
                int colIndex = dataGridView1.CurrentCell.ColumnIndex;

                dataGridView1.Rows.Remove(row);
                dataGridView1.Rows.Insert(index - 1, row);
                // 重新设置这行的这列为选中
                SelectCell(row, colIndex);
                isValueChanged = true;
            }
        }

        private void moveDown_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            int index = row.Index;
            if (index != dataGridView1.Rows.Count - 1)
            {
                // 记录当前格的列号
                int colIndex = dataGridView1.CurrentCell.ColumnIndex;

                dataGridView1.Rows.Remove(row);
                dataGridView1.Rows.Insert(index + 1, row);
                // 重新设置这行的这列为选中
                SelectCell(row, colIndex);
                isValueChanged = true;
            }
        }

        private void moveEnd_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentCell.OwningRow;
            int index = row.Index;
            if (index != dataGridView1.Rows.Count - 1)
            {
                // 记录当前格的列号
                int colIndex = dataGridView1.CurrentCell.ColumnIndex;

                dataGridView1.Rows.Remove(row);
                dataGridView1.Rows.Add(row);
                // 重新设置这行的这列为选中
                SelectCell(row, colIndex);
                isValueChanged = true;
            }
        }

        private void menuSelectAllUse_Click(object sender, EventArgs e)
        {
            SelectAllCell(COL_USE, true);
        }

        private void menuUnSelectAllUse_Click(object sender, EventArgs e)
        {
            SelectAllCell(COL_USE, false);
        }

        private void menuReloadHosts_Click(object sender, EventArgs e)
        {
            reloadhostsToolStripMenuItem_Click(null, null);
        }
        #endregion

        [Conditional("DEBUG")]
        protected void Test()
        {
            //MessageBox.Show(HostsDal.AppDir);
            //testMenu.Text = HostsDal.AppDir;
        }

        /// <summary>
        /// 按下Ctrl+S时，保存到hosts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //代码注释，改用 menuSave.ShortcutKeys
            //#region Ctrl+按键
            //if (e.Control)
            //{
            //    // Ctrl+S保存
            //    if (e.KeyCode == Keys.S)
            //    {
            //        SaveToolStripMenuItem_Click(null, null);
            //    }
            //    if (e.KeyCode == Keys.V)
            //    {
            //        // 实现DataGridView的粘贴功能
            //        //DataGridView dgv = GetControl<DataGridView>(ActiveControl);
            //        //if (dgv != null)
            //        //{
            //        //    string content = Clipboard.GetText();
            //        //    if (content.StartsWith("\tIP\t对应域名\t说明\t是否应用\t加空行"))
            //        //    {
            //        //        string[] tmp = content.Split(new[] {'\r', '\n'}, StringSplitOptions.RemoveEmptyEntries);
            //        //        if (tmp.Length != 2)
            //        //            return;
            //        //        tmp = tmp[1].Split('\t');
            //        //        if (tmp.Length >= 5 && (tmp[0] != "" || tmp[0] != "" || tmp[0] != ""))
            //        //        {

            //        //        }
            //        //    }
            //        //}
            //    }
            //}
            //#endregion
        }



        /// <summary>
        /// 显示信息,几秒后关闭
        /// </summary>
        /// <param name="msg"></param>
        void ShowMsg(string msg)
        {
            new Thread(() =>
                           {
                               TimeSpan ts = new TimeSpan(0, 0, 0, 1);
                               for (int i = HostsDal.MessageShowSecond; i > 0; i--)
                               {
                                   // 如果强制不显示，则终止循环显示
                                   if (_forceVisible)
                                   {
                                       _forceVisible = false;
                                       return;
                                   }
                                   OperationLabelMethod(labTitle, msg + "\r\n" + i + "秒后关闭");
                                   Thread.Sleep(ts);
                               }
                               OperationLabelMethod(labTitle, null);
                           }).Start();
            //MessageBox.Show(msg);
        }

        delegate void OperationLabel(Label lab, string txt);
        /// <summary>
        /// 通过委托方法设置或隐藏Label
        /// </summary>
        /// <param name="lab"></param>
        /// <param name="txt"></param>
        void OperationLabelMethod(Label lab, string txt)
        {
            if (lab.InvokeRequired)
            {
                OperationLabel method = OperationLabelMethod;
                if(this != null)// 点保存，然后马上关闭窗体时，会导致this变成null了，所以这里要判断
                    Invoke(method, lab, txt);
            }
            else
            {
                if (string.IsNullOrEmpty(txt))
                {
                    lab.Text = string.Empty;
                    lab.Visible = false;
                }
                else
                {
                    lab.Text = txt;
                    lab.Visible = true;
                }
            }
        }

        private bool _forceVisible = false;
        // 强制隐藏
        private void labTitle_Click(object sender, EventArgs e)
        {
            ((Control)sender).Visible = false;
            _forceVisible = true;
        }


        /// <summary>
        /// 根据控件，查找它的父控件类型为T的控件返回
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        T GetControl<T>(Control control) where T : Control
        {
            if (control == null)
                return null;

            if (control is T)
                return (T)control;
            return GetControl<T>(control.Parent);
        }

        void CheckUpdate()
        {
            string url = "http://beinet.cn/update.ashx?f=1";
            string param = "s=hostsmanager&v=1.0";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            if (request == null)
                return;

            request.Referer = url;
            request.AllowAutoRedirect = false; //禁止自动转向
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1;)";
            //request.KeepAlive = true;
            //request.Timeout = 100000;   // 设置超时时间，默认值为 100,000 毫秒（100 秒）。 
            //request.Accept = "image/gif, image/jpeg, image/pjpeg, image/pjpeg, application/x-shockwave-flash, application/msword, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/x-ms-application, application/x-ms-xbap, application/vnd.ms-xpsdocument, application/xaml+xml, */*";

            //if (isGet)
            //{
            //    request.Method = "GET";
            //    request.ContentType = "text/html";
            //}
            //else
            //{
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            // 设置提交的数据
            if (!string.IsNullOrEmpty(param))
            {
                request.ContentLength = param.Length;
                Stream newStream = request.GetRequestStream();
                // 把数据转换为字节数组
                byte[] l_data = Encoding.UTF8.GetBytes(param);
                newStream.Write(l_data, 0, l_data.Length);
                newStream.Close();
            }
            //}
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response == null)
                return;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string ret;
                using (Stream stream = response.GetResponseStream())
                using (StreamReader sr = new StreamReader(stream))
                {
                    ret = sr.ReadToEnd();
                }
                int split = ret.IndexOf('|');
                if (split > 0)
                {
                    string ver = ret.Substring(0, split);
                    if (!ver.Equals(version, StringComparison.OrdinalIgnoreCase))
                    {
                        string updated = ret.Substring(split + 1);
                        updated = string.Format("软件最新版本为{1}，是否去网站下载？\r\n\r\n更新内容：\r\n{0}", updated, ver);
                        if (MessageBox.Show(updated, "程序有更新", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            new Thread(() => Process.Start("http://beinet.cn/")).Start();
                        }
                    }
                }
            }
        }



        /// <summary>
        /// 在指定单元格内查找单词，并设置为红色
        /// 未找到时，设置为黑色
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="search"></param>
        /// <param name="use"></param>
        /// <param name="flg"></param>
        void FindWord(DataGridViewCell cell, string search, bool use, int flg)
        {
            if (string.IsNullOrEmpty(search))
            {
                cell.Style.ForeColor = Color.Black;
                return;
            }

            switch (flg)
            {
                //case 0:
                default:
                    if (!use)
                    {
                        cell.Style.ForeColor = Color.Black;
                        return;
                    }
                    break;
                case 1:
                    if (use)
                    {
                        cell.Style.ForeColor = Color.Black;
                        return;
                    }
                    break;
                case 2:
                    break;
            }
            string txt = Convert.ToString(cell.Value);
            if (txt.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                cell.Style.ForeColor = Color.Red;
            }
            else
            {
                cell.Style.ForeColor = Color.Black;
            }
        }

        /// <summary>
        /// 设置行为粗体或非粗体
        /// </summary>
        /// <param name="row"></param>
        /// <param name="isBold"></param>
        void SetFontBold(DataGridViewRow row, bool isBold)
        {
            Font f = row.Cells[0].Style.Font ?? Font;
            int i = 0;
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.Font = new Font(f, isBold ? FontStyle.Bold : FontStyle.Regular);
                i++;
                if (i > COL_DESC)// 只对COL_DESC列以前的数据加精
                    break;
            }
        }

        /// <summary>
        /// 设置行高
        /// </summary>
        /// <param name="dataGridViewRow"></param>
        /// <param name="addLine"></param>
        private void SetHeight(DataGridViewRow dataGridViewRow, bool addLine)
        {

            //if (addLine)
            //    dataGridViewRow.Height += 20;
            //else
            //    dataGridViewRow.Height -= 20;
        }

        /// <summary>
        /// 设置焦点行的背景色
        /// </summary>
        /// <param name="row"></param>
        /// <param name="isFocus"></param>
        void SetBackColor(DataGridViewRow row, bool isFocus)
        {
            Color color;
            if (isFocus)
                color = Color.YellowGreen;
            else if (row.Index % 2 == 0)
                color = Color.White;
            else
                color = Color.FromArgb(233, 245, 178);

            row.DefaultCellStyle.BackColor = color;
            //foreach (DataGridViewCell cell in row.Cells)
            //{
            //    cell.Style.BackColor = color;
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 会导致菜单闪烁，弹出子窗口时，点击按钮老不容易点到
            //this.TopMost = true;
            //this.BringToFront(); 
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var dgv = (DataGridView)sender;
            for (int i = 0; i < e.RowCount; i++)
            {
                dgv.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
            }
            for (int i = e.RowIndex + e.RowCount; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var dgv = (DataGridView)sender;
            for (int i = 0; i < e.RowCount && i < dgv.Rows.Count; i++)
            {
                dgv.Rows[e.RowIndex + i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Rows[e.RowIndex + i].HeaderCell.Value = (e.RowIndex + i + 1).ToString();
            }
            for (int i = e.RowIndex + e.RowCount; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

    }
}