using System.Configuration;

namespace BPSTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            /** read configurature */
            try
            {
                string file = System.Windows.Forms.Application.ExecutablePath;
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);

                config.AppSettings.Settings["debug_checked"].Value = checkBoxDebugEnable.Checked.ToString();
                config.AppSettings.Settings["baudrate"].Value = comboBoxBaudrate.Text.ToString();
                config.AppSettings.Settings["hex_recv"].Value = checkBoxHexRecv.Checked.ToString();
                config.AppSettings.Settings["hex_send"].Value = checkBoxHexSend.Checked.ToString();
                config.AppSettings.Settings["language"].Value = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;
                config.AppSettings.Settings["master_addr"].Value = BpsUtils.HostAddress.ToString();
                config.AppSettings.Settings["slave_addr"].Value = BpsUtils.ModuleAddress.ToString();
                config.Save();
            }
            catch
            {

            }

            /** remove BPS handler */
            if(bpsMngObj.IsUartOpen())
            {
                bpsMngObj.UartClose();
            }
            ClearBPSDelegate();
            bpsMngObj = null;

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);


        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitContainerSettingsAndDebug = new System.Windows.Forms.SplitContainer();
            this.buttonUartLink = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.comboBoxUart = new System.Windows.Forms.ComboBox();
            this.labelBaudrate = new System.Windows.Forms.Label();
            this.labelSerial = new System.Windows.Forms.Label();
            this.splitContainerDebug = new System.Windows.Forms.SplitContainer();
            this.textBoxDebugMsg = new System.Windows.Forms.TextBox();
            this.contextMenuStripDebugMsg = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerDebugSend = new System.Windows.Forms.SplitContainer();
            this.textBoxDebugSend = new System.Windows.Forms.TextBox();
            this.buttonDebugSend = new System.Windows.Forms.Button();
            this.splitContainerTop1Title = new System.Windows.Forms.SplitContainer();
            this.linkLabelVersionUpdate = new System.Windows.Forms.LinkLabel();
            this.buttonCheckVersion = new System.Windows.Forms.Button();
            this.groupBoxDebug = new System.Windows.Forms.GroupBox();
            this.checkBoxHexSend = new System.Windows.Forms.CheckBox();
            this.checkBoxHexRecv = new System.Windows.Forms.CheckBox();
            this.checkBoxDebugEnable = new System.Windows.Forms.CheckBox();
            this.splitContainerTop2DeviceAndDebug = new System.Windows.Forms.SplitContainer();
            this.tabControlDevice = new System.Windows.Forms.TabControl();
            this.tabPageBC1110 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonAddrSet = new System.Windows.Forms.Button();
            this.textBoxAddrSet = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonAdvIntervalRead = new System.Windows.Forms.Button();
            this.buttonAdvIntervalSet = new System.Windows.Forms.Button();
            this.textBoxAdvInterval = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonLinkMaintainTimeRead = new System.Windows.Forms.Button();
            this.buttonLinkMaintainTimeSet = new System.Windows.Forms.Button();
            this.textBoxLinkMaintainTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.buttonResetSet = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonFacRestoreSet = new System.Windows.Forms.Button();
            this.buttonBaudrateRead = new System.Windows.Forms.Button();
            this.buttonBaudrateSet = new System.Windows.Forms.Button();
            this.buttonNameRead = new System.Windows.Forms.Button();
            this.buttonNameSet = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBoxBaudrate = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.docToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsAndDebug)).BeginInit();
            this.splitContainerSettingsAndDebug.Panel1.SuspendLayout();
            this.splitContainerSettingsAndDebug.Panel2.SuspendLayout();
            this.splitContainerSettingsAndDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDebug)).BeginInit();
            this.splitContainerDebug.Panel1.SuspendLayout();
            this.splitContainerDebug.Panel2.SuspendLayout();
            this.splitContainerDebug.SuspendLayout();
            this.contextMenuStripDebugMsg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDebugSend)).BeginInit();
            this.splitContainerDebugSend.Panel1.SuspendLayout();
            this.splitContainerDebugSend.Panel2.SuspendLayout();
            this.splitContainerDebugSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop1Title)).BeginInit();
            this.splitContainerTop1Title.Panel1.SuspendLayout();
            this.splitContainerTop1Title.Panel2.SuspendLayout();
            this.splitContainerTop1Title.SuspendLayout();
            this.groupBoxDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop2DeviceAndDebug)).BeginInit();
            this.splitContainerTop2DeviceAndDebug.Panel1.SuspendLayout();
            this.splitContainerTop2DeviceAndDebug.Panel2.SuspendLayout();
            this.splitContainerTop2DeviceAndDebug.SuspendLayout();
            this.tabControlDevice.SuspendLayout();
            this.tabPageBC1110.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerSettingsAndDebug
            // 
            resources.ApplyResources(this.splitContainerSettingsAndDebug, "splitContainerSettingsAndDebug");
            this.splitContainerSettingsAndDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerSettingsAndDebug.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSettingsAndDebug.Name = "splitContainerSettingsAndDebug";
            // 
            // splitContainerSettingsAndDebug.Panel1
            // 
            resources.ApplyResources(this.splitContainerSettingsAndDebug.Panel1, "splitContainerSettingsAndDebug.Panel1");
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.buttonUartLink);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.buttonSearch);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.comboBoxBaudrate);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.comboBoxUart);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.labelBaudrate);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.labelSerial);
            // 
            // splitContainerSettingsAndDebug.Panel2
            // 
            resources.ApplyResources(this.splitContainerSettingsAndDebug.Panel2, "splitContainerSettingsAndDebug.Panel2");
            this.splitContainerSettingsAndDebug.Panel2.Controls.Add(this.splitContainerDebug);
            // 
            // buttonUartLink
            // 
            resources.ApplyResources(this.buttonUartLink, "buttonUartLink");
            this.buttonUartLink.Name = "buttonUartLink";
            this.buttonUartLink.UseVisualStyleBackColor = true;
            this.buttonUartLink.Click += new System.EventHandler(this.buttonUartLink_Click);
            // 
            // buttonSearch
            // 
            resources.ApplyResources(this.buttonSearch, "buttonSearch");
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            this.buttonSearch.MouseHover += new System.EventHandler(this.buttonSearch_MouseHover);
            // 
            // comboBoxBaudrate
            // 
            resources.ApplyResources(this.comboBoxBaudrate, "comboBoxBaudrate");
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            resources.GetString("comboBoxBaudrate.Items"),
            resources.GetString("comboBoxBaudrate.Items1"),
            resources.GetString("comboBoxBaudrate.Items2"),
            resources.GetString("comboBoxBaudrate.Items3"),
            resources.GetString("comboBoxBaudrate.Items4")});
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudrate_SelectedIndexChanged);
            this.comboBoxBaudrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxBaudrate_KeyPress);
            // 
            // comboBoxUart
            // 
            resources.ApplyResources(this.comboBoxUart, "comboBoxUart");
            this.comboBoxUart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUart.FormattingEnabled = true;
            this.comboBoxUart.Name = "comboBoxUart";
            this.comboBoxUart.SelectedIndexChanged += new System.EventHandler(this.comboBoxUart_SelectedIndexChanged);
            this.comboBoxUart.MouseHover += new System.EventHandler(this.comboBoxUart_MouseHover);
            // 
            // labelBaudrate
            // 
            resources.ApplyResources(this.labelBaudrate, "labelBaudrate");
            this.labelBaudrate.Name = "labelBaudrate";
            // 
            // labelSerial
            // 
            resources.ApplyResources(this.labelSerial, "labelSerial");
            this.labelSerial.Name = "labelSerial";
            // 
            // splitContainerDebug
            // 
            resources.ApplyResources(this.splitContainerDebug, "splitContainerDebug");
            this.splitContainerDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerDebug.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDebug.Name = "splitContainerDebug";
            // 
            // splitContainerDebug.Panel1
            // 
            resources.ApplyResources(this.splitContainerDebug.Panel1, "splitContainerDebug.Panel1");
            this.splitContainerDebug.Panel1.Controls.Add(this.textBoxDebugMsg);
            this.splitContainerDebug.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainerDebug.Panel2
            // 
            resources.ApplyResources(this.splitContainerDebug.Panel2, "splitContainerDebug.Panel2");
            this.splitContainerDebug.Panel2.Controls.Add(this.splitContainerDebugSend);
            // 
            // textBoxDebugMsg
            // 
            resources.ApplyResources(this.textBoxDebugMsg, "textBoxDebugMsg");
            this.textBoxDebugMsg.ContextMenuStrip = this.contextMenuStripDebugMsg;
            this.textBoxDebugMsg.Name = "textBoxDebugMsg";
            this.textBoxDebugMsg.TextChanged += new System.EventHandler(this.textBoxDebugMsg_TextChanged);
            // 
            // contextMenuStripDebugMsg
            // 
            resources.ApplyResources(this.contextMenuStripDebugMsg, "contextMenuStripDebugMsg");
            this.contextMenuStripDebugMsg.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDebugMsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemClear});
            this.contextMenuStripDebugMsg.Name = "contextMenuStripDebugMsg";
            // 
            // toolStripMenuItemCopy
            // 
            resources.ApplyResources(this.toolStripMenuItemCopy, "toolStripMenuItemCopy");
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemClear
            // 
            resources.ApplyResources(this.toolStripMenuItemClear, "toolStripMenuItemClear");
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // splitContainerDebugSend
            // 
            resources.ApplyResources(this.splitContainerDebugSend, "splitContainerDebugSend");
            this.splitContainerDebugSend.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDebugSend.Name = "splitContainerDebugSend";
            // 
            // splitContainerDebugSend.Panel1
            // 
            resources.ApplyResources(this.splitContainerDebugSend.Panel1, "splitContainerDebugSend.Panel1");
            this.splitContainerDebugSend.Panel1.Controls.Add(this.textBoxDebugSend);
            // 
            // splitContainerDebugSend.Panel2
            // 
            resources.ApplyResources(this.splitContainerDebugSend.Panel2, "splitContainerDebugSend.Panel2");
            this.splitContainerDebugSend.Panel2.Controls.Add(this.buttonDebugSend);
            // 
            // textBoxDebugSend
            // 
            resources.ApplyResources(this.textBoxDebugSend, "textBoxDebugSend");
            this.textBoxDebugSend.Name = "textBoxDebugSend";
            this.textBoxDebugSend.TextChanged += new System.EventHandler(this.textBoxDebugSend_TextChanged);
            this.textBoxDebugSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDebugSend_KeyPress);
            this.textBoxDebugSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxDebugSend_KeyUp);
            this.textBoxDebugSend.MouseHover += new System.EventHandler(this.textBoxDebugSend_MouseHover);
            // 
            // buttonDebugSend
            // 
            resources.ApplyResources(this.buttonDebugSend, "buttonDebugSend");
            this.buttonDebugSend.Name = "buttonDebugSend";
            this.buttonDebugSend.UseVisualStyleBackColor = true;
            this.buttonDebugSend.Click += new System.EventHandler(this.buttonDebugSend_Click);
            this.buttonDebugSend.MouseHover += new System.EventHandler(this.buttonDebugSend_MouseHover);
            // 
            // splitContainerTop1Title
            // 
            resources.ApplyResources(this.splitContainerTop1Title, "splitContainerTop1Title");
            this.splitContainerTop1Title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTop1Title.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerTop1Title.Name = "splitContainerTop1Title";
            // 
            // splitContainerTop1Title.Panel1
            // 
            resources.ApplyResources(this.splitContainerTop1Title.Panel1, "splitContainerTop1Title.Panel1");
            this.splitContainerTop1Title.Panel1.Controls.Add(this.linkLabelVersionUpdate);
            this.splitContainerTop1Title.Panel1.Controls.Add(this.buttonCheckVersion);
            this.splitContainerTop1Title.Panel1.Controls.Add(this.groupBoxDebug);
            this.splitContainerTop1Title.Panel1.Tag = "";
            this.splitContainerTop1Title.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainerTop1Title_Panel1_Paint);
            // 
            // splitContainerTop1Title.Panel2
            // 
            resources.ApplyResources(this.splitContainerTop1Title.Panel2, "splitContainerTop1Title.Panel2");
            this.splitContainerTop1Title.Panel2.Controls.Add(this.splitContainerTop2DeviceAndDebug);
            this.splitContainerTop1Title.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            // 
            // linkLabelVersionUpdate
            // 
            resources.ApplyResources(this.linkLabelVersionUpdate, "linkLabelVersionUpdate");
            this.linkLabelVersionUpdate.Name = "linkLabelVersionUpdate";
            this.linkLabelVersionUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelVersionUpdate_LinkClicked);
            // 
            // buttonCheckVersion
            // 
            resources.ApplyResources(this.buttonCheckVersion, "buttonCheckVersion");
            this.buttonCheckVersion.Name = "buttonCheckVersion";
            this.buttonCheckVersion.UseVisualStyleBackColor = true;
            this.buttonCheckVersion.Click += new System.EventHandler(this.ButtonCheckVersion_Click);
            // 
            // groupBoxDebug
            // 
            resources.ApplyResources(this.groupBoxDebug, "groupBoxDebug");
            this.groupBoxDebug.Controls.Add(this.checkBoxHexSend);
            this.groupBoxDebug.Controls.Add(this.checkBoxHexRecv);
            this.groupBoxDebug.Controls.Add(this.checkBoxDebugEnable);
            this.groupBoxDebug.Name = "groupBoxDebug";
            this.groupBoxDebug.TabStop = false;
            // 
            // checkBoxHexSend
            // 
            resources.ApplyResources(this.checkBoxHexSend, "checkBoxHexSend");
            this.checkBoxHexSend.Checked = true;
            this.checkBoxHexSend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHexSend.Name = "checkBoxHexSend";
            this.checkBoxHexSend.UseVisualStyleBackColor = true;
            this.checkBoxHexSend.CheckedChanged += new System.EventHandler(this.checkBoxHexSend_CheckedChanged);
            // 
            // checkBoxHexRecv
            // 
            resources.ApplyResources(this.checkBoxHexRecv, "checkBoxHexRecv");
            this.checkBoxHexRecv.Checked = true;
            this.checkBoxHexRecv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHexRecv.Name = "checkBoxHexRecv";
            this.checkBoxHexRecv.UseVisualStyleBackColor = true;
            // 
            // checkBoxDebugEnable
            // 
            resources.ApplyResources(this.checkBoxDebugEnable, "checkBoxDebugEnable");
            this.checkBoxDebugEnable.Checked = true;
            this.checkBoxDebugEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDebugEnable.Name = "checkBoxDebugEnable";
            this.checkBoxDebugEnable.UseVisualStyleBackColor = true;
            this.checkBoxDebugEnable.CheckedChanged += new System.EventHandler(this.checkBoxDebugEnable_CheckedChanged);
            this.checkBoxDebugEnable.MouseHover += new System.EventHandler(this.checkBoxDebugEnable_MouseHover);
            // 
            // splitContainerTop2DeviceAndDebug
            // 
            resources.ApplyResources(this.splitContainerTop2DeviceAndDebug, "splitContainerTop2DeviceAndDebug");
            this.splitContainerTop2DeviceAndDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerTop2DeviceAndDebug.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerTop2DeviceAndDebug.Name = "splitContainerTop2DeviceAndDebug";
            // 
            // splitContainerTop2DeviceAndDebug.Panel1
            // 
            resources.ApplyResources(this.splitContainerTop2DeviceAndDebug.Panel1, "splitContainerTop2DeviceAndDebug.Panel1");
            this.splitContainerTop2DeviceAndDebug.Panel1.Controls.Add(this.tabControlDevice);
            // 
            // splitContainerTop2DeviceAndDebug.Panel2
            // 
            resources.ApplyResources(this.splitContainerTop2DeviceAndDebug.Panel2, "splitContainerTop2DeviceAndDebug.Panel2");
            this.splitContainerTop2DeviceAndDebug.Panel2.Controls.Add(this.splitContainerSettingsAndDebug);
            // 
            // tabControlDevice
            // 
            resources.ApplyResources(this.tabControlDevice, "tabControlDevice");
            this.tabControlDevice.Controls.Add(this.tabPageBC1110);
            this.tabControlDevice.Name = "tabControlDevice";
            this.tabControlDevice.SelectedIndex = 0;
            this.tabControlDevice.Tag = "";
            // 
            // tabPageBC1110
            // 
            resources.ApplyResources(this.tabPageBC1110, "tabPageBC1110");
            this.tabPageBC1110.Controls.Add(this.button1);
            this.tabPageBC1110.Controls.Add(this.buttonAddrSet);
            this.tabPageBC1110.Controls.Add(this.textBoxAddrSet);
            this.tabPageBC1110.Controls.Add(this.label8);
            this.tabPageBC1110.Controls.Add(this.buttonAdvIntervalRead);
            this.tabPageBC1110.Controls.Add(this.buttonAdvIntervalSet);
            this.tabPageBC1110.Controls.Add(this.textBoxAdvInterval);
            this.tabPageBC1110.Controls.Add(this.label7);
            this.tabPageBC1110.Controls.Add(this.buttonLinkMaintainTimeRead);
            this.tabPageBC1110.Controls.Add(this.buttonLinkMaintainTimeSet);
            this.tabPageBC1110.Controls.Add(this.textBoxLinkMaintainTime);
            this.tabPageBC1110.Controls.Add(this.label6);
            this.tabPageBC1110.Controls.Add(this.button5);
            this.tabPageBC1110.Controls.Add(this.buttonResetSet);
            this.tabPageBC1110.Controls.Add(this.textBox1);
            this.tabPageBC1110.Controls.Add(this.label5);
            this.tabPageBC1110.Controls.Add(this.button3);
            this.tabPageBC1110.Controls.Add(this.buttonFacRestoreSet);
            this.tabPageBC1110.Controls.Add(this.buttonBaudrateRead);
            this.tabPageBC1110.Controls.Add(this.buttonBaudrateSet);
            this.tabPageBC1110.Controls.Add(this.buttonNameRead);
            this.tabPageBC1110.Controls.Add(this.buttonNameSet);
            this.tabPageBC1110.Controls.Add(this.textBox5);
            this.tabPageBC1110.Controls.Add(this.textBoxBaudrate);
            this.tabPageBC1110.Controls.Add(this.textBoxName);
            this.tabPageBC1110.Controls.Add(this.label4);
            this.tabPageBC1110.Controls.Add(this.label3);
            this.tabPageBC1110.Controls.Add(this.label2);
            this.tabPageBC1110.Controls.Add(this.label1);
            this.tabPageBC1110.Name = "tabPageBC1110";
            this.tabPageBC1110.UseVisualStyleBackColor = true;
            this.tabPageBC1110.Click += new System.EventHandler(this.tabPageBC1110_Click);
            this.tabPageBC1110.MouseHover += new System.EventHandler(this.tabPageBC1110_MouseHover);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonAddrSet
            // 
            resources.ApplyResources(this.buttonAddrSet, "buttonAddrSet");
            this.buttonAddrSet.Name = "buttonAddrSet";
            this.buttonAddrSet.UseVisualStyleBackColor = true;
            this.buttonAddrSet.Click += new System.EventHandler(this.buttonAddrSet_Click);
            // 
            // textBoxAddrSet
            // 
            resources.ApplyResources(this.textBoxAddrSet, "textBoxAddrSet");
            this.textBoxAddrSet.Name = "textBoxAddrSet";
            this.textBoxAddrSet.TextChanged += new System.EventHandler(this.textBoxAddrSet_TextChanged);
            this.textBoxAddrSet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAddrSet_KeyPress);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // buttonAdvIntervalRead
            // 
            resources.ApplyResources(this.buttonAdvIntervalRead, "buttonAdvIntervalRead");
            this.buttonAdvIntervalRead.Name = "buttonAdvIntervalRead";
            this.buttonAdvIntervalRead.UseVisualStyleBackColor = true;
            this.buttonAdvIntervalRead.Click += new System.EventHandler(this.buttonAdvIntervalRead_Click);
            // 
            // buttonAdvIntervalSet
            // 
            resources.ApplyResources(this.buttonAdvIntervalSet, "buttonAdvIntervalSet");
            this.buttonAdvIntervalSet.Name = "buttonAdvIntervalSet";
            this.buttonAdvIntervalSet.UseVisualStyleBackColor = true;
            this.buttonAdvIntervalSet.Click += new System.EventHandler(this.buttonAdvIntervalSet_Click);
            // 
            // textBoxAdvInterval
            // 
            resources.ApplyResources(this.textBoxAdvInterval, "textBoxAdvInterval");
            this.textBoxAdvInterval.Name = "textBoxAdvInterval";
            this.textBoxAdvInterval.TextChanged += new System.EventHandler(this.textBoxAdvInterval_TextChanged);
            this.textBoxAdvInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxAdvInterval_KeyPress);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // buttonLinkMaintainTimeRead
            // 
            resources.ApplyResources(this.buttonLinkMaintainTimeRead, "buttonLinkMaintainTimeRead");
            this.buttonLinkMaintainTimeRead.Name = "buttonLinkMaintainTimeRead";
            this.buttonLinkMaintainTimeRead.UseVisualStyleBackColor = true;
            this.buttonLinkMaintainTimeRead.Click += new System.EventHandler(this.buttonLinkMaintainTimeRead_Click);
            // 
            // buttonLinkMaintainTimeSet
            // 
            resources.ApplyResources(this.buttonLinkMaintainTimeSet, "buttonLinkMaintainTimeSet");
            this.buttonLinkMaintainTimeSet.Name = "buttonLinkMaintainTimeSet";
            this.buttonLinkMaintainTimeSet.UseVisualStyleBackColor = true;
            this.buttonLinkMaintainTimeSet.Click += new System.EventHandler(this.buttonLinkMaintainTimeSet_Click);
            // 
            // textBoxLinkMaintainTime
            // 
            resources.ApplyResources(this.textBoxLinkMaintainTime, "textBoxLinkMaintainTime");
            this.textBoxLinkMaintainTime.Name = "textBoxLinkMaintainTime";
            this.textBoxLinkMaintainTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxLinkMaintainTime_KeyPress);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonResetSet
            // 
            resources.ApplyResources(this.buttonResetSet, "buttonResetSet");
            this.buttonResetSet.Name = "buttonResetSet";
            this.buttonResetSet.UseVisualStyleBackColor = true;
            this.buttonResetSet.Click += new System.EventHandler(this.buttonResetSet_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonFacRestoreSet
            // 
            resources.ApplyResources(this.buttonFacRestoreSet, "buttonFacRestoreSet");
            this.buttonFacRestoreSet.Name = "buttonFacRestoreSet";
            this.buttonFacRestoreSet.UseVisualStyleBackColor = true;
            this.buttonFacRestoreSet.Click += new System.EventHandler(this.buttonFacRestoreSet_Click);
            // 
            // buttonBaudrateRead
            // 
            resources.ApplyResources(this.buttonBaudrateRead, "buttonBaudrateRead");
            this.buttonBaudrateRead.Name = "buttonBaudrateRead";
            this.buttonBaudrateRead.UseVisualStyleBackColor = true;
            this.buttonBaudrateRead.Click += new System.EventHandler(this.buttonBaudrateRead_Click);
            // 
            // buttonBaudrateSet
            // 
            resources.ApplyResources(this.buttonBaudrateSet, "buttonBaudrateSet");
            this.buttonBaudrateSet.Name = "buttonBaudrateSet";
            this.buttonBaudrateSet.UseVisualStyleBackColor = true;
            this.buttonBaudrateSet.Click += new System.EventHandler(this.buttonBaudrateSet_Click);
            // 
            // buttonNameRead
            // 
            resources.ApplyResources(this.buttonNameRead, "buttonNameRead");
            this.buttonNameRead.Name = "buttonNameRead";
            this.buttonNameRead.UseVisualStyleBackColor = true;
            this.buttonNameRead.Click += new System.EventHandler(this.buttonNameRead_Click);
            // 
            // buttonNameSet
            // 
            resources.ApplyResources(this.buttonNameSet, "buttonNameSet");
            this.buttonNameSet.Name = "buttonNameSet";
            this.buttonNameSet.UseVisualStyleBackColor = true;
            this.buttonNameSet.Click += new System.EventHandler(this.buttonNameSet_Click);
            // 
            // textBox5
            // 
            resources.ApplyResources(this.textBox5, "textBox5");
            this.textBox5.Name = "textBox5";
            // 
            // textBoxBaudrate
            // 
            resources.ApplyResources(this.textBoxBaudrate, "textBoxBaudrate");
            this.textBoxBaudrate.Name = "textBoxBaudrate";
            this.textBoxBaudrate.TextChanged += new System.EventHandler(this.textBoxBaudrate_TextChanged);
            this.textBoxBaudrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBaudrate_KeyPress);
            // 
            // textBoxName
            // 
            resources.ApplyResources(this.textBoxName, "textBoxName");
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            this.textBoxName.MouseHover += new System.EventHandler(this.textBox3_MouseHover);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuStripMain
            // 
            resources.ApplyResources(this.menuStripMain, "menuStripMain");
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStripMain_ItemClicked);
            // 
            // editToolStripMenuItem
            // 
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            // 
            // optionsToolStripMenuItem
            // 
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.docToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // docToolStripMenuItem
            // 
            resources.ApplyResources(this.docToolStripMenuItem, "docToolStripMenuItem");
            this.docToolStripMenuItem.Name = "docToolStripMenuItem";
            this.docToolStripMenuItem.Click += new System.EventHandler(this.DocToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Click += new System.EventHandler(this.LanguageToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerTop1Title);
            this.Controls.Add(this.menuStripMain);
            this.Name = "MainForm";
            this.splitContainerSettingsAndDebug.Panel1.ResumeLayout(false);
            this.splitContainerSettingsAndDebug.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSettingsAndDebug)).EndInit();
            this.splitContainerSettingsAndDebug.ResumeLayout(false);
            this.splitContainerDebug.Panel1.ResumeLayout(false);
            this.splitContainerDebug.Panel1.PerformLayout();
            this.splitContainerDebug.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDebug)).EndInit();
            this.splitContainerDebug.ResumeLayout(false);
            this.contextMenuStripDebugMsg.ResumeLayout(false);
            this.splitContainerDebugSend.Panel1.ResumeLayout(false);
            this.splitContainerDebugSend.Panel1.PerformLayout();
            this.splitContainerDebugSend.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDebugSend)).EndInit();
            this.splitContainerDebugSend.ResumeLayout(false);
            this.splitContainerTop1Title.Panel1.ResumeLayout(false);
            this.splitContainerTop1Title.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop1Title)).EndInit();
            this.splitContainerTop1Title.ResumeLayout(false);
            this.groupBoxDebug.ResumeLayout(false);
            this.groupBoxDebug.PerformLayout();
            this.splitContainerTop2DeviceAndDebug.Panel1.ResumeLayout(false);
            this.splitContainerTop2DeviceAndDebug.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop2DeviceAndDebug)).EndInit();
            this.splitContainerTop2DeviceAndDebug.ResumeLayout(false);
            this.tabControlDevice.ResumeLayout(false);
            this.tabPageBC1110.ResumeLayout(false);
            this.tabPageBC1110.PerformLayout();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCheckVersion;
        private System.Windows.Forms.LinkLabel linkLabelVersionUpdate;
        private System.Windows.Forms.SplitContainer splitContainerTop1Title;
        private System.Windows.Forms.SplitContainer splitContainerTop2DeviceAndDebug;
        private System.Windows.Forms.SplitContainer splitContainerSettingsAndDebug;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.ComboBox comboBoxUart;
        private System.Windows.Forms.Label labelBaudrate;
        private System.Windows.Forms.Label labelSerial;
        private System.Windows.Forms.SplitContainer splitContainerDebug;
        private System.Windows.Forms.SplitContainer splitContainerDebugSend;
        private System.Windows.Forms.TextBox textBoxDebugSend;
        private System.Windows.Forms.Button buttonDebugSend;
        private System.Windows.Forms.TextBox textBoxDebugMsg;
        private System.Windows.Forms.Button buttonUartLink;
        private System.Windows.Forms.TabControl tabControlDevice;
        private System.Windows.Forms.TabPage tabPageBC1110;
        private System.Windows.Forms.CheckBox checkBoxDebugEnable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNameSet;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBoxBaudrate;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonFacRestoreSet;
        private System.Windows.Forms.Button buttonBaudrateRead;
        private System.Windows.Forms.Button buttonBaudrateSet;
        private System.Windows.Forms.Button buttonNameRead;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button buttonResetSet;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDebugMsg;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.GroupBox groupBoxDebug;
        private System.Windows.Forms.CheckBox checkBoxHexSend;
        private System.Windows.Forms.CheckBox checkBoxHexRecv;
        private System.Windows.Forms.Button buttonAdvIntervalRead;
        private System.Windows.Forms.Button buttonAdvIntervalSet;
        private System.Windows.Forms.TextBox textBoxAdvInterval;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonLinkMaintainTimeRead;
        private System.Windows.Forms.Button buttonLinkMaintainTimeSet;
        private System.Windows.Forms.TextBox textBoxLinkMaintainTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem docToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonAddrSet;
        private System.Windows.Forms.TextBox textBoxAddrSet;
        private System.Windows.Forms.Label label8;
    }
}

