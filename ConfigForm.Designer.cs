namespace Beinet.cn.HostsManager
{
    partial class ConfigForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radUTF8 = new System.Windows.Forms.RadioButton();
            this.radGB2312 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radNoQuick = new System.Windows.Forms.RadioButton();
            this.radQuickUse = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radNoComment = new System.Windows.Forms.RadioButton();
            this.radAddComment = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCanel = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radDelComment = new System.Windows.Forms.RadioButton();
            this.radSaveComment = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radSysDir = new System.Windows.Forms.RadioButton();
            this.radAppDir = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.txtSecond = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radNoFront = new System.Windows.Forms.RadioButton();
            this.radFront = new System.Windows.Forms.RadioButton();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.txtTelecomDns = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnicomDns = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radUTF8);
            this.groupBox1.Controls.Add(this.radGB2312);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 47);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "hosts文件编码";
            // 
            // radUTF8
            // 
            this.radUTF8.AutoSize = true;
            this.radUTF8.Location = new System.Drawing.Point(109, 20);
            this.radUTF8.Name = "radUTF8";
            this.radUTF8.Size = new System.Drawing.Size(53, 16);
            this.radUTF8.TabIndex = 1;
            this.radUTF8.Text = "UTF-8";
            this.radUTF8.UseVisualStyleBackColor = true;
            // 
            // radGB2312
            // 
            this.radGB2312.AutoSize = true;
            this.radGB2312.Checked = true;
            this.radGB2312.Location = new System.Drawing.Point(6, 20);
            this.radGB2312.Name = "radGB2312";
            this.radGB2312.Size = new System.Drawing.Size(59, 16);
            this.radGB2312.TabIndex = 0;
            this.radGB2312.TabStop = true;
            this.radGB2312.Text = "GB2312";
            this.radGB2312.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radNoQuick);
            this.groupBox2.Controls.Add(this.radQuickUse);
            this.groupBox2.Location = new System.Drawing.Point(12, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 47);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择快捷方式时，是否立即应用到hosts";
            // 
            // radNoQuick
            // 
            this.radNoQuick.AutoSize = true;
            this.radNoQuick.Location = new System.Drawing.Point(109, 20);
            this.radNoQuick.Name = "radNoQuick";
            this.radNoQuick.Size = new System.Drawing.Size(155, 16);
            this.radNoQuick.TabIndex = 5;
            this.radNoQuick.Text = "通过点击菜单的立即保存";
            this.radNoQuick.UseVisualStyleBackColor = true;
            // 
            // radQuickUse
            // 
            this.radQuickUse.AutoSize = true;
            this.radQuickUse.Checked = true;
            this.radQuickUse.Location = new System.Drawing.Point(6, 20);
            this.radQuickUse.Name = "radQuickUse";
            this.radQuickUse.Size = new System.Drawing.Size(71, 16);
            this.radQuickUse.TabIndex = 4;
            this.radQuickUse.TabStop = true;
            this.radQuickUse.Text = "立即应用";
            this.radQuickUse.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radNoComment);
            this.groupBox3.Controls.Add(this.radAddComment);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 47);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "保存时，是否添加微软标准注释";
            // 
            // radNoComment
            // 
            this.radNoComment.AutoSize = true;
            this.radNoComment.Location = new System.Drawing.Point(109, 20);
            this.radNoComment.Name = "radNoComment";
            this.radNoComment.Size = new System.Drawing.Size(59, 16);
            this.radNoComment.TabIndex = 9;
            this.radNoComment.Text = "不添加";
            this.radNoComment.UseVisualStyleBackColor = true;
            // 
            // radAddComment
            // 
            this.radAddComment.AutoSize = true;
            this.radAddComment.Checked = true;
            this.radAddComment.Location = new System.Drawing.Point(6, 20);
            this.radAddComment.Name = "radAddComment";
            this.radAddComment.Size = new System.Drawing.Size(47, 16);
            this.radAddComment.TabIndex = 8;
            this.radAddComment.TabStop = true;
            this.radAddComment.Text = "添加";
            this.radAddComment.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(38, 446);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(184, 446);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(75, 23);
            this.btnCanel.TabIndex = 16;
            this.btnCanel.Text = "取消";
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radDelComment);
            this.groupBox4.Controls.Add(this.radSaveComment);
            this.groupBox4.Location = new System.Drawing.Point(12, 171);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(276, 47);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "是否保存注释的host记录";
            // 
            // radDelComment
            // 
            this.radDelComment.AutoSize = true;
            this.radDelComment.Location = new System.Drawing.Point(109, 20);
            this.radDelComment.Name = "radDelComment";
            this.radDelComment.Size = new System.Drawing.Size(47, 16);
            this.radDelComment.TabIndex = 7;
            this.radDelComment.Text = "删除";
            this.radDelComment.UseVisualStyleBackColor = true;
            // 
            // radSaveComment
            // 
            this.radSaveComment.AutoSize = true;
            this.radSaveComment.Checked = true;
            this.radSaveComment.Location = new System.Drawing.Point(6, 20);
            this.radSaveComment.Name = "radSaveComment";
            this.radSaveComment.Size = new System.Drawing.Size(47, 16);
            this.radSaveComment.TabIndex = 6;
            this.radSaveComment.TabStop = true;
            this.radSaveComment.Text = "保存";
            this.radSaveComment.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radSysDir);
            this.groupBox5.Controls.Add(this.radAppDir);
            this.groupBox5.Location = new System.Drawing.Point(12, 65);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(276, 47);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "快捷方式保存到的目录";
            // 
            // radSysDir
            // 
            this.radSysDir.AutoSize = true;
            this.radSysDir.Location = new System.Drawing.Point(109, 20);
            this.radSysDir.Name = "radSysDir";
            this.radSysDir.Size = new System.Drawing.Size(101, 16);
            this.radSysDir.TabIndex = 3;
            this.radSysDir.Text = "hosts所在目录";
            this.radSysDir.UseVisualStyleBackColor = true;
            // 
            // radAppDir
            // 
            this.radAppDir.AutoSize = true;
            this.radAppDir.Checked = true;
            this.radAppDir.Location = new System.Drawing.Point(6, 20);
            this.radAppDir.Name = "radAppDir";
            this.radAppDir.Size = new System.Drawing.Size(95, 16);
            this.radAppDir.TabIndex = 2;
            this.radAppDir.TabStop = true;
            this.radAppDir.Text = "程序所在目录";
            this.radAppDir.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label1);
            this.groupBox6.Controls.Add(this.labTitle);
            this.groupBox6.Controls.Add(this.txtSecond);
            this.groupBox6.Location = new System.Drawing.Point(12, 277);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(276, 47);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "提示显示时间设置";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "秒后关闭";
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(6, 23);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(77, 12);
            this.labTitle.TabIndex = 5;
            this.labTitle.Text = "提示信息显示";
            // 
            // txtSecond
            // 
            this.txtSecond.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecond.Location = new System.Drawing.Point(89, 20);
            this.txtSecond.Name = "txtSecond";
            this.txtSecond.Size = new System.Drawing.Size(48, 21);
            this.txtSecond.TabIndex = 10;
            this.txtSecond.Text = "2";
            this.txtSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.radNoFront);
            this.groupBox7.Controls.Add(this.radFront);
            this.groupBox7.Location = new System.Drawing.Point(12, 330);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(276, 47);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "窗口最前";
            // 
            // radNoFront
            // 
            this.radNoFront.AutoSize = true;
            this.radNoFront.Location = new System.Drawing.Point(111, 20);
            this.radNoFront.Name = "radNoFront";
            this.radNoFront.Size = new System.Drawing.Size(95, 16);
            this.radNoFront.TabIndex = 12;
            this.radNoFront.Text = "启动时不最前";
            this.radNoFront.UseVisualStyleBackColor = true;
            // 
            // radFront
            // 
            this.radFront.AutoSize = true;
            this.radFront.Checked = true;
            this.radFront.Location = new System.Drawing.Point(8, 20);
            this.radFront.Name = "radFront";
            this.radFront.Size = new System.Drawing.Size(83, 16);
            this.radFront.TabIndex = 11;
            this.radFront.TabStop = true;
            this.radFront.Text = "启动时最前";
            this.radFront.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.txtUnicomDns);
            this.groupBox8.Controls.Add(this.label3);
            this.groupBox8.Controls.Add(this.txtTelecomDns);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Location = new System.Drawing.Point(12, 383);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(276, 47);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "DNS设置";
            // 
            // txtTelecomDns
            // 
            this.txtTelecomDns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelecomDns.Location = new System.Drawing.Point(38, 20);
            this.txtTelecomDns.Name = "txtTelecomDns";
            this.txtTelecomDns.Size = new System.Drawing.Size(99, 21);
            this.txtTelecomDns.TabIndex = 13;
            this.txtTelecomDns.Text = "8.8.8.8";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "电信";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "网通";
            // 
            // txtUnicomDns
            // 
            this.txtUnicomDns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnicomDns.Location = new System.Drawing.Point(172, 20);
            this.txtUnicomDns.Name = "txtUnicomDns";
            this.txtUnicomDns.Size = new System.Drawing.Size(99, 21);
            this.txtUnicomDns.TabIndex = 14;
            this.txtUnicomDns.Text = "202.106.0.20";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 478);
            this.Controls.Add(this.btnCanel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.Text = "配置-beinet.cn";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radUTF8;
        private System.Windows.Forms.RadioButton radGB2312;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radNoQuick;
        private System.Windows.Forms.RadioButton radQuickUse;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radNoComment;
        private System.Windows.Forms.RadioButton radAddComment;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton radDelComment;
        private System.Windows.Forms.RadioButton radSaveComment;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radSysDir;
        private System.Windows.Forms.RadioButton radAppDir;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtSecond;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton radNoFront;
        private System.Windows.Forms.RadioButton radFront;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtTelecomDns;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUnicomDns;
        private System.Windows.Forms.Label label3;
    }
}