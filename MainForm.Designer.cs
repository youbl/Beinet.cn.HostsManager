using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReloadHosts = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuDel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveas = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuMoveTop = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.moveEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSelectAllUse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUnSelectAllUse = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LinksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChkUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsHostsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenAppDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenSysDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditHostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aaaToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.EditRegToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IE8JsErrFixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddLineForVisualStudio2008ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowComputerInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lnkLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.lnkLineConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadhostsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFindStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.mnuTopMost = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenNetworkAttr = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenIpSet = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.labTitle = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.colCollapse = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colIP = new Beinet.cn.HostsManager.DataGridViewComboEditBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUse = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colOperation = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colIeOpen = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colAddToQuickLine = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colPing = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colNslookup = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(245)))), ((int)(((byte)(178)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCollapse,
            this.colIP,
            this.colName,
            this.colDesc,
            this.colGroup,
            this.colUse,
            this.colOperation,
            this.colIeOpen,
            this.colAddToQuickLine,
            this.colPing,
            this.colNslookup});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 24);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1055, 695);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellMouseEnter);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave,
            this.menuReloadHosts,
            this.toolStripSeparator4,
            this.menuDel,
            this.menuAdd,
            this.toolStripSeparator1,
            this.menuSaveas,
            this.toolStripSeparator2,
            this.menuConfig,
            this.toolStripSeparator3,
            this.menuMoveTop,
            this.moveUp,
            this.moveDown,
            this.moveEnd,
            this.toolStripSeparator5,
            this.menuSelectAllUse,
            this.menuUnSelectAllUse});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(250, 298);
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuSave.Size = new System.Drawing.Size(249, 22);
            this.menuSave.Text = "立即保存全部到hosts";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuReloadHosts
            // 
            this.menuReloadHosts.Name = "menuReloadHosts";
            this.menuReloadHosts.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menuReloadHosts.Size = new System.Drawing.Size(249, 22);
            this.menuReloadHosts.Text = "重新加载hosts";
            this.menuReloadHosts.Click += new System.EventHandler(this.menuReloadHosts_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(246, 6);
            // 
            // menuDel
            // 
            this.menuDel.Name = "menuDel";
            this.menuDel.ShortcutKeyDisplayString = "";
            this.menuDel.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.menuDel.Size = new System.Drawing.Size(249, 22);
            this.menuDel.Text = "删除光标所在行";
            this.menuDel.Click += new System.EventHandler(this.menuDel_Click);
            // 
            // menuAdd
            // 
            this.menuAdd.Name = "menuAdd";
            this.menuAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.menuAdd.Size = new System.Drawing.Size(249, 22);
            this.menuAdd.Text = "新增行";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(246, 6);
            // 
            // menuSaveas
            // 
            this.menuSaveas.Name = "menuSaveas";
            this.menuSaveas.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.menuSaveas.Size = new System.Drawing.Size(249, 22);
            this.menuSaveas.Text = "另存为快捷方式...";
            this.menuSaveas.Click += new System.EventHandler(this.menuSaveas_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(246, 6);
            // 
            // menuConfig
            // 
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.menuConfig.Size = new System.Drawing.Size(249, 22);
            this.menuConfig.Text = "配置...";
            this.menuConfig.Click += new System.EventHandler(this.menuConfig_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(246, 6);
            // 
            // menuMoveTop
            // 
            this.menuMoveTop.Name = "menuMoveTop";
            this.menuMoveTop.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Up)));
            this.menuMoveTop.Size = new System.Drawing.Size(249, 22);
            this.menuMoveTop.Text = "上移到顶部";
            this.menuMoveTop.Click += new System.EventHandler(this.menuMoveTop_Click);
            // 
            // moveUp
            // 
            this.moveUp.Name = "moveUp";
            this.moveUp.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Up)));
            this.moveUp.Size = new System.Drawing.Size(249, 22);
            this.moveUp.Text = "上移一行";
            this.moveUp.Click += new System.EventHandler(this.moveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.Name = "moveDown";
            this.moveDown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Down)));
            this.moveDown.Size = new System.Drawing.Size(249, 22);
            this.moveDown.Text = "下移一行";
            this.moveDown.Click += new System.EventHandler(this.moveDown_Click);
            // 
            // moveEnd
            // 
            this.moveEnd.Name = "moveEnd";
            this.moveEnd.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Down)));
            this.moveEnd.Size = new System.Drawing.Size(249, 22);
            this.moveEnd.Text = "下移到底部";
            this.moveEnd.Click += new System.EventHandler(this.moveEnd_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(246, 6);
            // 
            // menuSelectAllUse
            // 
            this.menuSelectAllUse.Name = "menuSelectAllUse";
            this.menuSelectAllUse.Size = new System.Drawing.Size(249, 22);
            this.menuSelectAllUse.Text = "选择全部 是否应用";
            this.menuSelectAllUse.Click += new System.EventHandler(this.menuSelectAllUse_Click);
            // 
            // menuUnSelectAllUse
            // 
            this.menuUnSelectAllUse.Name = "menuUnSelectAllUse";
            this.menuUnSelectAllUse.Size = new System.Drawing.Size(249, 22);
            this.menuUnSelectAllUse.Text = "取消全部 是否应用";
            this.menuUnSelectAllUse.Click += new System.EventHandler(this.menuUnSelectAllUse_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.LinksToolStripMenuItem,
            this.HelpToolStripMenuItem,
            this.ToolsHostsToolStripMenuItem1,
            this.lnkLineToolStripMenuItem,
            this.toolStripMenuItem3,
            this.reloadhostsToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.txtFindStripTextBox1,
            this.mnuTopMost,
            this.mnuIpAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1055, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveHistoryToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.ConfigToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.FileToolStripMenuItem.Text = "文件";
            // 
            // SaveHistoryToolStripMenuItem
            // 
            this.SaveHistoryToolStripMenuItem.Name = "SaveHistoryToolStripMenuItem";
            this.SaveHistoryToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.SaveHistoryToolStripMenuItem.Text = "保存 请输入快捷方式名";
            this.SaveHistoryToolStripMenuItem.Visible = false;
            this.SaveHistoryToolStripMenuItem.Click += new System.EventHandler(this.SaveHistoryToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.SaveAsToolStripMenuItem.Text = "另存为快捷方式...";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // ConfigToolStripMenuItem
            // 
            this.ConfigToolStripMenuItem.Name = "ConfigToolStripMenuItem";
            this.ConfigToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ConfigToolStripMenuItem.Text = "配置...";
            this.ConfigToolStripMenuItem.Click += new System.EventHandler(this.ConfigToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.ExitToolStripMenuItem.Text = "退出";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // LinksToolStripMenuItem
            // 
            this.LinksToolStripMenuItem.Name = "LinksToolStripMenuItem";
            this.LinksToolStripMenuItem.Size = new System.Drawing.Size(89, 21);
            this.LinksToolStripMenuItem.Text = "快捷方式列表";
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChkUpdateToolStripMenuItem,
            this.AboutHostsToolStripMenuItem});
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(41, 21);
            this.HelpToolStripMenuItem.Text = "帮助";
            // 
            // ChkUpdateToolStripMenuItem
            // 
            this.ChkUpdateToolStripMenuItem.Name = "ChkUpdateToolStripMenuItem";
            this.ChkUpdateToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.ChkUpdateToolStripMenuItem.Text = "去beinet.cn查看更新";
            this.ChkUpdateToolStripMenuItem.Click += new System.EventHandler(this.ChkUpdateToolStripMenuItem_Click);
            // 
            // AboutHostsToolStripMenuItem
            // 
            this.AboutHostsToolStripMenuItem.Name = "AboutHostsToolStripMenuItem";
            this.AboutHostsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.AboutHostsToolStripMenuItem.Text = "关于Hosts修改工具";
            this.AboutHostsToolStripMenuItem.Click += new System.EventHandler(this.AboutHostsToolStripMenuItem_Click);
            // 
            // ToolsHostsToolStripMenuItem1
            // 
            this.ToolsHostsToolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ToolsHostsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenAppDirToolStripMenuItem,
            this.OpenSysDirToolStripMenuItem,
            this.EditHostsToolStripMenuItem,
            this.aaaToolStripMenuItem,
            this.EditRegToolStripMenuItem,
            this.IE8JsErrFixToolStripMenuItem,
            this.AddLineForVisualStudio2008ToolStripMenuItem,
            this.toolStripSeparator7,
            this.CloseScreenToolStripMenuItem,
            this.ShowComputerInfoToolStripMenuItem});
            this.ToolsHostsToolStripMenuItem1.Name = "ToolsHostsToolStripMenuItem1";
            this.ToolsHostsToolStripMenuItem1.Size = new System.Drawing.Size(41, 21);
            this.ToolsHostsToolStripMenuItem1.Text = "工具";
            // 
            // OpenAppDirToolStripMenuItem
            // 
            this.OpenAppDirToolStripMenuItem.Name = "OpenAppDirToolStripMenuItem";
            this.OpenAppDirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
            this.OpenAppDirToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.OpenAppDirToolStripMenuItem.Text = "打开程序目录";
            this.OpenAppDirToolStripMenuItem.Click += new System.EventHandler(this.OpenAppDirToolStripMenuItem_Click);
            // 
            // OpenSysDirToolStripMenuItem
            // 
            this.OpenSysDirToolStripMenuItem.Name = "OpenSysDirToolStripMenuItem";
            this.OpenSysDirToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.OpenSysDirToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.OpenSysDirToolStripMenuItem.Text = "打开Hosts所在目录";
            this.OpenSysDirToolStripMenuItem.Click += new System.EventHandler(this.OpenSysDirToolStripMenuItem_Click);
            // 
            // EditHostsToolStripMenuItem
            // 
            this.EditHostsToolStripMenuItem.Name = "EditHostsToolStripMenuItem";
            this.EditHostsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.EditHostsToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.EditHostsToolStripMenuItem.Text = "记事本打开Hosts";
            this.EditHostsToolStripMenuItem.Click += new System.EventHandler(this.EditHostsToolStripMenuItem_Click);
            // 
            // aaaToolStripMenuItem
            // 
            this.aaaToolStripMenuItem.Name = "aaaToolStripMenuItem";
            this.aaaToolStripMenuItem.Size = new System.Drawing.Size(319, 6);
            // 
            // EditRegToolStripMenuItem
            // 
            this.EditRegToolStripMenuItem.Name = "EditRegToolStripMenuItem";
            this.EditRegToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.EditRegToolStripMenuItem.Text = "修改注册表使hosts立即生效";
            this.EditRegToolStripMenuItem.Click += new System.EventHandler(this.EditRegToolStripMenuItem_Click);
            // 
            // IE8JsErrFixToolStripMenuItem
            // 
            this.IE8JsErrFixToolStripMenuItem.Name = "IE8JsErrFixToolStripMenuItem";
            this.IE8JsErrFixToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.IE8JsErrFixToolStripMenuItem.Text = "修改注册表修正IE8新建选项卡报js错误问题";
            this.IE8JsErrFixToolStripMenuItem.Click += new System.EventHandler(this.IE8JsErrFixToolStripMenuItem_Click);
            // 
            // AddLineForVisualStudio2008ToolStripMenuItem
            // 
            this.AddLineForVisualStudio2008ToolStripMenuItem.Name = "AddLineForVisualStudio2008ToolStripMenuItem";
            this.AddLineForVisualStudio2008ToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.AddLineForVisualStudio2008ToolStripMenuItem.Text = "修改注册表为VisualStudio2008添加代码分隔线";
            this.AddLineForVisualStudio2008ToolStripMenuItem.Click += new System.EventHandler(this.AddLineForVisualStudio2008ToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(319, 6);
            // 
            // CloseScreenToolStripMenuItem
            // 
            this.CloseScreenToolStripMenuItem.Name = "CloseScreenToolStripMenuItem";
            this.CloseScreenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Z)));
            this.CloseScreenToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.CloseScreenToolStripMenuItem.Text = "显示器黑屏（午休用）";
            this.CloseScreenToolStripMenuItem.Click += new System.EventHandler(this.CloseScreenToolStripMenuItem_Click);
            // 
            // ShowComputerInfoToolStripMenuItem
            // 
            this.ShowComputerInfoToolStripMenuItem.Name = "ShowComputerInfoToolStripMenuItem";
            this.ShowComputerInfoToolStripMenuItem.Size = new System.Drawing.Size(322, 22);
            this.ShowComputerInfoToolStripMenuItem.Text = "显示计算机信息";
            this.ShowComputerInfoToolStripMenuItem.Click += new System.EventHandler(this.ShowComputerInfoToolStripMenuItem_Click);
            // 
            // lnkLineToolStripMenuItem
            // 
            this.lnkLineToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator6,
            this.lnkLineConfigToolStripMenuItem});
            this.lnkLineToolStripMenuItem.Name = "lnkLineToolStripMenuItem";
            this.lnkLineToolStripMenuItem.Size = new System.Drawing.Size(77, 21);
            this.lnkLineToolStripMenuItem.Text = "快捷行列表";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // lnkLineConfigToolStripMenuItem
            // 
            this.lnkLineConfigToolStripMenuItem.Name = "lnkLineConfigToolStripMenuItem";
            this.lnkLineConfigToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lnkLineConfigToolStripMenuItem.Text = "快捷行配置...";
            this.lnkLineConfigToolStripMenuItem.Click += new System.EventHandler(this.lnkLineConfigToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.toolStripMenuItem3.Enabled = false;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(12, 21);
            // 
            // reloadhostsToolStripMenuItem
            // 
            this.reloadhostsToolStripMenuItem.Name = "reloadhostsToolStripMenuItem";
            this.reloadhostsToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.reloadhostsToolStripMenuItem.Text = "重新加载hosts";
            this.reloadhostsToolStripMenuItem.Click += new System.EventHandler(this.reloadhostsToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(155, 21);
            this.SaveToolStripMenuItem.Text = "立即保存到hosts(Ctrl+S)";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // txtFindStripTextBox1
            // 
            this.txtFindStripTextBox1.Name = "txtFindStripTextBox1";
            this.txtFindStripTextBox1.Size = new System.Drawing.Size(110, 21);
            this.txtFindStripTextBox1.Text = "请输入查找关键字";
            this.txtFindStripTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFindStripTextBox1_KeyUp);
            this.txtFindStripTextBox1.Click += new System.EventHandler(this.txtFindStripTextBox1_Click);
            this.txtFindStripTextBox1.DoubleClick += new System.EventHandler(this.txtFindStripTextBox1_DoubleClick);
            // 
            // mnuTopMost
            // 
            this.mnuTopMost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuTopMost.Name = "mnuTopMost";
            this.mnuTopMost.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.mnuTopMost.Size = new System.Drawing.Size(89, 21);
            this.mnuTopMost.Text = "保持窗口最前";
            this.mnuTopMost.Click += new System.EventHandler(this.mnuTopMost_Click);
            // 
            // mnuIpAbout
            // 
            this.mnuIpAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuIpAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenNetworkAttr,
            this.mnuOpenIpSet,
            this.toolStripSeparator8});
            this.mnuIpAbout.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.mnuIpAbout.Name = "mnuIpAbout";
            this.mnuIpAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.H)));
            this.mnuIpAbout.Size = new System.Drawing.Size(53, 21);
            this.mnuIpAbout.Text = "IP工具";
            // 
            // mnuOpenNetworkAttr
            // 
            this.mnuOpenNetworkAttr.Name = "mnuOpenNetworkAttr";
            this.mnuOpenNetworkAttr.Size = new System.Drawing.Size(166, 22);
            this.mnuOpenNetworkAttr.Text = "打开网络连接窗口";
            this.mnuOpenNetworkAttr.Click += new System.EventHandler(this.mnuOpenNetworkAttr_Click);
            // 
            // mnuOpenIpSet
            // 
            this.mnuOpenIpSet.Name = "mnuOpenIpSet";
            this.mnuOpenIpSet.Size = new System.Drawing.Size(166, 22);
            this.mnuOpenIpSet.Text = "IP设置";
            this.mnuOpenIpSet.Click += new System.EventHandler(this.mnuOpenIpSet_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(163, 6);
            // 
            // labTitle
            // 
            this.labTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labTitle.AutoSize = true;
            this.labTitle.Font = new System.Drawing.Font("宋体", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labTitle.ForeColor = System.Drawing.Color.Red;
            this.labTitle.Location = new System.Drawing.Point(198, 209);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(177, 40);
            this.labTitle.TabIndex = 5;
            this.labTitle.Text = "保存成功";
            this.labTitle.Visible = false;
            this.labTitle.Click += new System.EventHandler(this.labTitle_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // colCollapse
            // 
            this.colCollapse.Frozen = true;
            this.colCollapse.HeaderText = "";
            this.colCollapse.Name = "colCollapse";
            this.colCollapse.ReadOnly = true;
            this.colCollapse.Width = 30;
            // 
            // colIP
            // 
            this.colIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colIP.Frozen = true;
            this.colIP.HeaderText = "IP";
            this.colIP.MaxDropDownItems = 80;
            this.colIP.Name = "colIP";
            this.colIP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIP.Sorted = true;
            this.colIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIP.Width = 140;
            // 
            // colName
            // 
            this.colName.HeaderText = "对应域名";
            this.colName.Name = "colName";
            this.colName.Width = 220;
            // 
            // colDesc
            // 
            this.colDesc.HeaderText = "说明";
            this.colDesc.Name = "colDesc";
            this.colDesc.Width = 270;
            // 
            // colGroup
            // 
            this.colGroup.FillWeight = 30F;
            this.colGroup.HeaderText = "分组";
            this.colGroup.MaxInputLength = 3;
            this.colGroup.Name = "colGroup";
            this.colGroup.Width = 55;
            // 
            // colUse
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.NullValue = false;
            this.colUse.DefaultCellStyle = dataGridViewCellStyle2;
            this.colUse.FalseValue = "false";
            this.colUse.FillWeight = 30F;
            this.colUse.HeaderText = "应用";
            this.colUse.Name = "colUse";
            this.colUse.ReadOnly = true;
            this.colUse.ToolTipText = "取消表示用#注释该行";
            this.colUse.TrueValue = "true";
            this.colUse.Width = 35;
            // 
            // colOperation
            // 
            this.colOperation.HeaderText = "";
            this.colOperation.Name = "colOperation";
            this.colOperation.ReadOnly = true;
            this.colOperation.Text = "删除";
            this.colOperation.TrackVisitedState = false;
            this.colOperation.Width = 36;
            // 
            // colIeOpen
            // 
            this.colIeOpen.HeaderText = "";
            this.colIeOpen.Name = "colIeOpen";
            this.colIeOpen.ReadOnly = true;
            this.colIeOpen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIeOpen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIeOpen.Width = 45;
            // 
            // colAddToQuickLine
            // 
            this.colAddToQuickLine.HeaderText = "";
            this.colAddToQuickLine.Name = "colAddToQuickLine";
            this.colAddToQuickLine.ReadOnly = true;
            this.colAddToQuickLine.Width = 70;
            // 
            // colPing
            // 
            this.colPing.HeaderText = "";
            this.colPing.Name = "colPing";
            this.colPing.ReadOnly = true;
            this.colPing.Width = 36;
            // 
            // colNslookup
            // 
            this.colNslookup.HeaderText = "";
            this.colNslookup.Name = "colNslookup";
            this.colNslookup.ReadOnly = true;
            this.colNslookup.Width = 58;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 718);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolsHostsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OpenSysDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LinksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditRegToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuDel;
        private System.Windows.Forms.ToolStripMenuItem menuAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuSaveas;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem menuConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem menuMoveTop;
        private System.Windows.Forms.ToolStripMenuItem moveUp;
        private System.Windows.Forms.ToolStripMenuItem moveDown;
        private System.Windows.Forms.ToolStripMenuItem moveEnd;
        private System.Windows.Forms.ToolStripMenuItem ChkUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutHostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenAppDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem menuSelectAllUse;
        private System.Windows.Forms.ToolStripMenuItem menuUnSelectAllUse;
        private System.Windows.Forms.ToolStripMenuItem menuReloadHosts;
        private System.Windows.Forms.ToolStripMenuItem reloadhostsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lnkLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem lnkLineConfigToolStripMenuItem;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.ToolStripSeparator aaaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem IE8JsErrFixToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem CloseScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowComputerInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox txtFindStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem AddLineForVisualStudio2008ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem mnuTopMost;
        private ToolStripMenuItem mnuIpAbout;
        private ToolStripMenuItem mnuOpenNetworkAttr;
        private ToolStripMenuItem mnuOpenIpSet;
        private ToolStripSeparator toolStripSeparator8;
        private DataGridViewLinkColumn colCollapse;
        private DataGridViewComboEditBoxColumn colIP;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colDesc;
        private DataGridViewTextBoxColumn colGroup;
        private DataGridViewCheckBoxColumn colUse;
        private DataGridViewLinkColumn colOperation;
        private DataGridViewLinkColumn colIeOpen;
        private DataGridViewLinkColumn colAddToQuickLine;
        private DataGridViewLinkColumn colPing;
        private DataGridViewLinkColumn colNslookup;
    }
}

