using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BPSTool
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();

            try
            {
                comboBoxMasterAddr.SelectedIndex = BpsUtils.HostAddress;
                comboBoxSlaveAddr.SelectedIndex = BpsUtils.ModuleAddress;
            }
            catch(Exception e)
            {
                comboBoxMasterAddr.SelectedIndex = BpsUtils.DEFAULT_MASTER_ADDR;
                comboBoxSlaveAddr.SelectedIndex = BpsUtils.DEFAULT_MODULE_ADDR;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if(comboBoxMasterAddr.SelectedIndex == comboBoxSlaveAddr.SelectedIndex)
            {
                DialogResult dr = MessageBox.Show(UITools.GetString("StrAddrNotSameWarning"), UITools.GetString("StrWarning"));
                return;
            }
            BpsUtils.updateBpsAddr(comboBoxMasterAddr.SelectedIndex, comboBoxSlaveAddr.SelectedIndex);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
