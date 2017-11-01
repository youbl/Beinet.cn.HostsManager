using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Beinet.cn.HostsManager
{
    public class DataGridViewComboEditBoxColumn : DataGridViewComboBoxColumn
    {
        public DataGridViewComboEditBoxColumn()
        {
            DataGridViewComboEditBoxCell obj = new DataGridViewComboEditBoxCell();
            this.CellTemplate = obj;
        }

        public override sealed DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set { base.CellTemplate = value; }
        }
    }


    public class DataGridViewComboEditBoxCell : DataGridViewComboBoxCell
    {
        public override void InitializeEditingControl(int rowIndex, 
            object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            ComboBox comboBox = (ComboBox)DataGridView.EditingControl;

            if (comboBox != null)
            {
                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox.Validating += comboBox_Validating;
            }
        }

        protected override object GetFormattedValue(object value, int rowIndex, 
            ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, 
            TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value != null)
            {
                if (value.ToString().Trim() != string.Empty)
                {
                    if (Items.IndexOf(value) == -1)
                    {
                        Items.Add(value);
                        //DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)OwningColumn;
                        //col.Items.Add(value);
                    }
                }
            }
            return base.GetFormattedValue(value, rowIndex, ref cellStyle, 
                valueTypeConverter, formattedValueTypeConverter, context);
        }

        void comboBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DataGridViewComboBoxEditingControl currentBox = (DataGridViewComboBoxEditingControl)sender;
            string value = currentBox.Text.Trim();
            if (value == string.Empty) 
                return;
            if (!HostsDal.RegIp.IsMatch(value))
            {
                // 目前仅ip列在用，所以这里强加了，在外面用不生效
                // var ipcell = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells[COL_IP];
                // ipcell.Items.Remove(val);
                MessageBox.Show("ip:" + value + " 配置错误");
                e.Cancel = true;
                return;
            }


            DataGridView grid = currentBox.EditingControlDataGridView;

            // 如果列表不存在，加入列表
            if (currentBox.Items.IndexOf(value) == -1)
            {
                // Must add to both the current combobox as well as the template, to avoid duplicate entries
                //DataGridViewComboBoxColumn cboCol = (DataGridViewComboBoxColumn)grid.Columns[grid.CurrentCell.ColumnIndex];
                //cboCol.Items.Add(value);
                currentBox.Items.Add(value);
                grid.CurrentCell.Value = value;
            }
        }
    }
}
