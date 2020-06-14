using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BPSTool
{
    public partial class MainForm : Form
    {
        private const string STR_COMM_ERR = "通信错误";
        private const string STR_NEWEST_VERSION = "已经是最新版本";
        private const string STR_NEW_VERSION_CHECK = "检测到新版：";
        private const string STR_TT_DEBUG_SEND = "仅支持16进制发送，例如“BB CC 00 01 00 01 00 02”";
        private const string STR_TT_DEBUG_ENABLE = "使能串口发送/接收调试";

        public const uint BPSTOOL_VERSION_MAIN = 1;
        public const uint BPSTOOL_VERSION_SUB = 0;
        public const uint BPSTOOL_VERSION_PATCH = 1;

        public delegate void DelUpdateUI_VV();

        private DelUpdateUI_VV DelUpdateChecker;

        private Updater UpdateChecker;

        

        public MainForm()
        {
            InitializeComponent();

            UpdateChecker = new Updater(this);
            DelUpdateChecker = new DelUpdateUI_VV(UpdateLabelCallback);

            if (UpdateChecker.EndFlag)
            {
                UpdateChecker.StartWebRequest(DelUpdateChecker);
            }
            linkLabelVersionUpdate.Text = "";

            /** append version info to title */
            this.Text += "-V" + BPSTOOL_VERSION_MAIN + "." + BPSTOOL_VERSION_SUB + "." + BPSTOOL_VERSION_PATCH;
        }

        public void BpsToolCallback(DelUpdateUI_VV del_vv)
        {
            try
            {
                BeginInvoke(del_vv);
            }
            catch
            {

            }
        }

        private void UpdateLabelCallback()
        {
            if(0 == UpdateChecker.LastestVersion.Trim().Length)
            {
                /** Communication error*/
                if (!UpdateChecker.LaunchCheckFlag)
                {
                    linkLabelVersionUpdate.LinkColor = Color.Red;
                    linkLabelVersionUpdate.Text = STR_COMM_ERR;
                    linkLabelVersionUpdate.Enabled = false;
                }
            }
            else
            {
                string lastestVersion = UpdateChecker.LastestVersion.Trim();
                Regex regex = new Regex(@"([0-9]+)\.([0-9]+)\.([0-9]+)");
                GroupCollection groups = regex.Match(lastestVersion).Groups;
                bool newVersionProbed = false;

                try
                {
                    do
                    {
                        uint verTemp = uint.Parse(groups[1].Value);
                        if (BPSTOOL_VERSION_MAIN < verTemp)
                        {
                            newVersionProbed = true;
                            break;
                        }
                        else if(BPSTOOL_VERSION_MAIN > verTemp)
                        {
                            break;
                        }

                        verTemp = uint.Parse(groups[2].Value);
                        if (BPSTOOL_VERSION_SUB < verTemp)
                        {
                            newVersionProbed = true;
                            break;
                        }
                        else if(BPSTOOL_VERSION_SUB > verTemp)
                        {
                            break;
                        }

                        verTemp = uint.Parse(groups[3].Value);
                        if (BPSTOOL_VERSION_PATCH < verTemp)
                        {
                            newVersionProbed = true;
                            break;
                        }
                        else if(BPSTOOL_VERSION_PATCH > verTemp)
                        {
                            break;
                        }

                    } while (false);
                }
                catch
                {
                    newVersionProbed = false;
                }

                if(newVersionProbed)
                {
                    linkLabelVersionUpdate.Text = STR_NEW_VERSION_CHECK + UpdateChecker.LastestVersion;
                    linkLabelVersionUpdate.LinkColor = Color.Blue;
                    linkLabelVersionUpdate.Enabled = true;
                }
                else
                {
                    if (!UpdateChecker.LaunchCheckFlag)
                    {
                        linkLabelVersionUpdate.Enabled = true;
                        linkLabelVersionUpdate.LinkColor = Color.Green;
                        linkLabelVersionUpdate.Text = STR_NEWEST_VERSION;
                    }
                }
            }

            if (UpdateChecker.LaunchCheckFlag)
            {
                UpdateChecker.LaunchCheckFlag = false;
                return;
            }

        }

        private void ButtonCheckVersion_Click(object sender, EventArgs e)
        {
            linkLabelVersionUpdate.Text = "";
            linkLabelVersionUpdate.Enabled = false;
            if (UpdateChecker.EndFlag)
            {
                UpdateChecker.StartWebRequest(DelUpdateChecker);
            }
        }

        private void LinkLabelVersionUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(UpdateChecker.DownloadLinkUrl);
            }
            catch
            {

            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDebugSend_MouseHover(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.buttonDebugSend, STR_TT_DEBUG_SEND);
        }

        private void textBoxDebugSend_MouseHover(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.textBoxDebugSend, STR_TT_DEBUG_SEND);
        }

        private void comboBoxBaudrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxBaudrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxDebugSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != ' ' && !Char.IsDigit(e.KeyChar) && !(e.KeyChar <= 'f' && e.KeyChar >= 'a') && !(e.KeyChar <= 'F' && e.KeyChar >= 'A'))
            {
                e.Handled = true;
            }
        }

        private void checkBoxDebugEnable_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxDebugEnable.Checked)
            {
                buttonDebugSend.Enabled = true;
            }
            else
            {
                buttonDebugSend.Enabled = false;
            }
        }

        private void checkBoxDebugEnable_MouseHover(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this.checkBoxDebugEnable, STR_TT_DEBUG_ENABLE);
        }

        private void tabPageBC1110_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonNameSet_Click(object sender, EventArgs e)
        {

        }

        private void buttonNameRead_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
