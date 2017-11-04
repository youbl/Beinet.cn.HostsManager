namespace Beinet.cn.HostsManager
{
    partial class HelpForm
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
            this.labHelp = new System.Windows.Forms.Label();
            this.labTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCanel
            // 
            this.btnCanel.Location = new System.Drawing.Point(288, 375);
            this.btnCanel.Name = "btnCanel";
            this.btnCanel.Size = new System.Drawing.Size(138, 23);
            this.btnCanel.TabIndex = 1;
            this.btnCanel.Text = "关闭";
            this.btnCanel.UseVisualStyleBackColor = true;
            this.btnCanel.Click += new System.EventHandler(this.btnCanel_Click);
            // 
            // labHelp
            // 
            this.labHelp.AutoSize = true;
            this.labHelp.Location = new System.Drawing.Point(12, 39);
            this.labHelp.Name = "labHelp";
            this.labHelp.Size = new System.Drawing.Size(23, 12);
            this.labHelp.TabIndex = 3;
            this.labHelp.Text = "111";
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(98, 9);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(0, 12);
            this.labTitle.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "工具里的“修改注册表相关菜单”说明：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 260);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(570, 102);
            this.textBox1.TabIndex = 5;
            this.textBox1.WordWrap = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 375);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "去Beinet.cn查看更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 412);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.labTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labHelp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpForm";
            this.Text = "帮助-Beinet.cn";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.HelpForm_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCanel;
        private System.Windows.Forms.Label labHelp;
        private System.Windows.Forms.Label labTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}