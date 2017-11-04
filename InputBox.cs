using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    public partial class InputBox : Form
    {
        public string Name { get; set; }
        public InputBox(string name)
        {
            InitializeComponent();
            textBox1.Text = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Name = textBox1.Text.Trim();
            if (Name.Length == 0)
            {
                MessageBox.Show("请输入名称");
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void InputBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                button1_Click(sender, e);
            }
        }
    }
}
