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
    public partial class SearchListForm : Form
    {
        private Dictionary<string, int> portsMap;
        private MainForm parentForm;
        public SearchListForm(MainForm mainForm)
        {
            InitializeComponent();
            parentForm = mainForm;
            parentForm.searchPortSelected = null;

            if (null != parentForm.searchSerialPortMap)
            {
                portsMap = parentForm.searchSerialPortMap;
                foreach(string key in portsMap.Keys)
                {
                    listBoxSerialPorts.Items.Add(portsMap[key] + "@" + key);
                }
                listBoxSerialPorts.SelectedIndex = 0;
            }
        }

        private void SearchListForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            parentForm.searchPortSelected = null;
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            foreach(string key in portsMap.Keys)
            {
                if ((portsMap[key] + "@" + key) == listBoxSerialPorts.SelectedItem.ToString())
                {
                    parentForm.searchPortSelected = key;
                }
            }
            this.Close();
        }
    }
}
