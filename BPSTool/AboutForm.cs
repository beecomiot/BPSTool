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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();

            this.labelVersionAbout.Text = "V" + MainForm.BPSTOOL_VERSION_MAIN + "." + MainForm.BPSTOOL_VERSION_SUB + "." + MainForm.BPSTOOL_VERSION_PATCH;
        }

        private void labelVersionAbout_Click(object sender, EventArgs e)
        {

        }
    }
}
