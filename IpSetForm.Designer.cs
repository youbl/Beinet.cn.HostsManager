namespace Beinet.cn.HostsManager
{
    partial class IpSetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCanel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.txtMask = new System.Windows.Forms.TextBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtDns1 = new System.Windows.Forms.TextBox();
            this.txtDns2 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lstNetworks = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radStatic = new System.Windows.Forms.RadioButton();
            this.radDhcp = new System.Windows.Forms.RadioButton();
            this.btnBackup = new System.Windows.Forms.Button();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(276, 200);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(77, 23);
            this.btnCanel.TabIndex = 10;
            this.btnCanel.Text = "取消";
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "设置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(73, 119);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(103, 21);
            this.txtIp.TabIndex = 3;
            this.txtIp.Text = "111.888.888.888";
            // 
            // txtMask
            // 
            this.txtMask.Location = new System.Drawing.Point(256, 119);
            this.txtMask.Name = "txtMask";
            this.txtMask.Size = new System.Drawing.Size(103, 21);
            this.txtMask.TabIndex = 4;
            this.txtMask.Text = "111.888.888.888";
            // 
            // txtGateway
            // 
            this.txtGateway.Location = new System.Drawing.Point(73, 146);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(103, 21);
            this.txtGateway.TabIndex = 5;
            this.txtGateway.Text = "111.888.888.888";
            // 
            // txtDns1
            // 
            this.txtDns1.Location = new System.Drawing.Point(73, 173);
            this.txtDns1.Name = "txtDns1";
            this.txtDns1.Size = new System.Drawing.Size(103, 21);
            this.txtDns1.TabIndex = 6;
            this.txtDns1.Text = "111.888.888.888";
            // 
            // txtDns2
            // 
            this.txtDns2.Location = new System.Drawing.Point(238, 173);
            this.txtDns2.Name = "txtDns2";
            this.txtDns2.Size = new System.Drawing.Size(103, 21);
            this.txtDns2.TabIndex = 7;
            this.txtDns2.Text = "111.888.888.888";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lstNetworks);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radStatic);
            this.panel1.Controls.Add(this.radDhcp);
            this.panel1.Controls.Add(this.txtMask);
            this.panel1.Controls.Add(this.txtDns2);
            this.panel1.Controls.Add(this.btnCanel);
            this.panel1.Controls.Add(this.txtDns1);
            this.panel1.Controls.Add(this.btnBackup);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtGateway);
            this.panel1.Controls.Add(this.txtMac);
            this.panel1.Controls.Add(this.txtIp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 258);
            this.panel1.TabStop = false;

            // 
            // lstNetworks
            // 
            this.lstNetworks.DropDownHeight = 1060;
            this.lstNetworks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstNetworks.FormattingEnabled = true;
            this.lstNetworks.IntegralHeight = false;
            this.lstNetworks.Location = new System.Drawing.Point(13, 13);
            this.lstNetworks.Name = "lstNetworks";
            this.lstNetworks.Size = new System.Drawing.Size(340, 20);
            this.lstNetworks.TabIndex = 0;
            this.lstNetworks.SelectedIndexChanged += new System.EventHandler(this.lstNetworks_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(191, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabStop = false;
            this.label5.Text = "DNS 2:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.Text = "DNS 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.Text = "网关:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.Text = "子网掩码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.Text = "IP:";
            // 
            // radStatic
            // 
            this.radStatic.AutoSize = true;
            this.radStatic.Location = new System.Drawing.Point(193, 97);
            this.radStatic.Name = "radStatic";
            this.radStatic.Size = new System.Drawing.Size(83, 16);
            this.radStatic.TabIndex = 2;
            this.radStatic.TabStop = true;
            this.radStatic.Text = "设置静态IP";
            this.radStatic.UseVisualStyleBackColor = true;
            this.radStatic.CheckedChanged += new System.EventHandler(this.radDhcp_CheckedChanged);
            // 
            // radDhcp
            // 
            this.radDhcp.AutoSize = true;
            this.radDhcp.Location = new System.Drawing.Point(73, 97);
            this.radDhcp.Name = "radDhcp";
            this.radDhcp.Size = new System.Drawing.Size(83, 16);
            this.radDhcp.TabIndex = 3;
            this.radDhcp.TabStop = true;
            this.radDhcp.Text = "自动获取IP";
            this.radDhcp.UseVisualStyleBackColor = true;
            this.radDhcp.CheckedChanged += new System.EventHandler(this.radDhcp_CheckedChanged);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(148, 200);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(84, 23);
            this.btnBackup.TabIndex = 9;
            this.btnBackup.Text = "保存为备份";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // txtMac
            // 
            this.txtMac.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMac.Location = new System.Drawing.Point(12, 38);
            this.txtMac.Multiline = true;
            this.txtMac.Name = "txtMac";
            this.txtMac.Size = new System.Drawing.Size(341, 35);
            this.txtMac.TabStop = false;
            this.txtMac.Text = "111.888.888.888";
            this.txtMac.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(305, 12);
            this.label6.Text = "注意：如果网络连接属性窗口打开时，此时修改不会生效";
            // 
            // IpSetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 258);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IpSetForm";
            this.Text = "帮助";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.IpSetForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IpSetForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.TextBox txtMask;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.TextBox txtDns1;
        private System.Windows.Forms.TextBox txtDns2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radStatic;
        private System.Windows.Forms.RadioButton radDhcp;
        private System.Windows.Forms.ComboBox lstNetworks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label label6;
    }
}