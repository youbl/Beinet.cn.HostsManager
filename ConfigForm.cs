using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            ShowInTaskbar = false;// 不能放到OnLoad里，会导致窗体消失
            
            if (Equals(HostsDal.Encode, Encoding.UTF8))
                radUTF8.Checked = true;
            if (!HostsDal.LinkQuickUse)
                radNoQuick.Checked = true;
            if (!HostsDal.AddMicroComment)
                radNoComment.Checked = true;
            if (!HostsDal.SaveComment)
                radDelComment.Checked = true;
            if (HostsDal.SaveToSysDir)
                radSysDir.Checked = true;
            if (!HostsDal.StartFront)
                radNoFront.Checked = true;
            txtSecond.Text = HostsDal.MessageShowSecond.ToString();
            txtUnicomDns.Text = HostsDal.UnicomDns;
            txtTelecomDns.Text = HostsDal.TelecomDns;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int messageShowSecond;
            if(!int.TryParse(txtSecond.Text, out messageShowSecond))
            {
                MessageBox.Show("你输入的整数是错误的");
                return;
            }
            Regex reg = new Regex(@"^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$", RegexOptions.Compiled);
            if(!reg.IsMatch(txtTelecomDns.Text))
            {
                MessageBox.Show("你输入的电信DNS IP格式不对");
                return;
            }
            if (!reg.IsMatch(txtUnicomDns.Text))
            {
                MessageBox.Show("你输入的网通DNS IP格式不对");
                return;
            }
            string encode = radUTF8.Checked ? "UTF-8" : "GB2312";
            string linkQuickUse = radNoQuick.Checked ? "0" : "1";
            string addMicroComment = radNoComment.Checked ? "0" : "1";
            string saveComment = radDelComment.Checked ? "0" : "1";
            string saveToSysDir = radSysDir.Checked ? "1" : "0";
            string isFront = radFront.Checked ? "1" : "0";
            HostsDal.SaveConfig(encode, linkQuickUse, addMicroComment, saveComment, saveToSysDir,
                messageShowSecond, isFront, txtTelecomDns.Text, txtUnicomDns.Text);
            this.Close();
        }

        private void ConfigForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
