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
                config.Save();
            }
            catch
            {

            }

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
            this.buttonCheckVersion = new System.Windows.Forms.Button();
            this.linkLabelVersionUpdate = new System.Windows.Forms.LinkLabel();
            this.splitContainerTop1Title = new System.Windows.Forms.SplitContainer();
            this.checkBoxDebugEnable = new System.Windows.Forms.CheckBox();
            this.splitContainerTop2DeviceAndDebug = new System.Windows.Forms.SplitContainer();
            this.tabControlDevice = new System.Windows.Forms.TabControl();
            this.tabPageBC1110 = new System.Windows.Forms.TabPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop1Title)).BeginInit();
            this.splitContainerTop1Title.Panel1.SuspendLayout();
            this.splitContainerTop1Title.Panel2.SuspendLayout();
            this.splitContainerTop1Title.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop2DeviceAndDebug)).BeginInit();
            this.splitContainerTop2DeviceAndDebug.Panel1.SuspendLayout();
            this.splitContainerTop2DeviceAndDebug.Panel2.SuspendLayout();
            this.splitContainerTop2DeviceAndDebug.SuspendLayout();
            this.tabControlDevice.SuspendLayout();
            this.tabPageBC1110.SuspendLayout();
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
            this.SuspendLayout();
            // 
            // buttonCheckVersion
            // 
            this.buttonCheckVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCheckVersion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCheckVersion.Location = new System.Drawing.Point(930, 18);
            this.buttonCheckVersion.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCheckVersion.Name = "buttonCheckVersion";
            this.buttonCheckVersion.Size = new System.Drawing.Size(120, 29);
            this.buttonCheckVersion.TabIndex = 0;
            this.buttonCheckVersion.Text = "检查版本";
            this.buttonCheckVersion.UseVisualStyleBackColor = true;
            this.buttonCheckVersion.Click += new System.EventHandler(this.ButtonCheckVersion_Click);
            // 
            // linkLabelVersionUpdate
            // 
            this.linkLabelVersionUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelVersionUpdate.Enabled = false;
            this.linkLabelVersionUpdate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabelVersionUpdate.Location = new System.Drawing.Point(578, 19);
            this.linkLabelVersionUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelVersionUpdate.Name = "linkLabelVersionUpdate";
            this.linkLabelVersionUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.linkLabelVersionUpdate.Size = new System.Drawing.Size(344, 25);
            this.linkLabelVersionUpdate.TabIndex = 1;
            this.linkLabelVersionUpdate.TabStop = true;
            this.linkLabelVersionUpdate.Text = "Version";
            this.linkLabelVersionUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelVersionUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelVersionUpdate_LinkClicked);
            // 
            // splitContainerTop1Title
            // 
            this.splitContainerTop1Title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerTop1Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop1Title.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerTop1Title.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop1Title.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerTop1Title.Name = "splitContainerTop1Title";
            this.splitContainerTop1Title.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTop1Title.Panel1
            // 
            this.splitContainerTop1Title.Panel1.Controls.Add(this.checkBoxDebugEnable);
            this.splitContainerTop1Title.Panel1.Controls.Add(this.linkLabelVersionUpdate);
            this.splitContainerTop1Title.Panel1.Controls.Add(this.buttonCheckVersion);
            this.splitContainerTop1Title.Panel1.Tag = "";
            // 
            // splitContainerTop1Title.Panel2
            // 
            this.splitContainerTop1Title.Panel2.Controls.Add(this.splitContainerTop2DeviceAndDebug);
            this.splitContainerTop1Title.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainerTop1Title.Size = new System.Drawing.Size(1067, 562);
            this.splitContainerTop1Title.SplitterDistance = 58;
            this.splitContainerTop1Title.TabIndex = 2;
            // 
            // checkBoxDebugEnable
            // 
            this.checkBoxDebugEnable.AutoSize = true;
            this.checkBoxDebugEnable.Checked = true;
            this.checkBoxDebugEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDebugEnable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxDebugEnable.Location = new System.Drawing.Point(25, 19);
            this.checkBoxDebugEnable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBoxDebugEnable.Name = "checkBoxDebugEnable";
            this.checkBoxDebugEnable.Size = new System.Drawing.Size(121, 24);
            this.checkBoxDebugEnable.TabIndex = 2;
            this.checkBoxDebugEnable.Text = "使能Debug";
            this.checkBoxDebugEnable.UseVisualStyleBackColor = true;
            this.checkBoxDebugEnable.CheckedChanged += new System.EventHandler(this.checkBoxDebugEnable_CheckedChanged);
            this.checkBoxDebugEnable.MouseHover += new System.EventHandler(this.checkBoxDebugEnable_MouseHover);
            // 
            // splitContainerTop2DeviceAndDebug
            // 
            this.splitContainerTop2DeviceAndDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerTop2DeviceAndDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerTop2DeviceAndDebug.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerTop2DeviceAndDebug.Location = new System.Drawing.Point(0, 0);
            this.splitContainerTop2DeviceAndDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerTop2DeviceAndDebug.Name = "splitContainerTop2DeviceAndDebug";
            this.splitContainerTop2DeviceAndDebug.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerTop2DeviceAndDebug.Panel1
            // 
            this.splitContainerTop2DeviceAndDebug.Panel1.Controls.Add(this.tabControlDevice);
            // 
            // splitContainerTop2DeviceAndDebug.Panel2
            // 
            this.splitContainerTop2DeviceAndDebug.Panel2.Controls.Add(this.splitContainerSettingsAndDebug);
            this.splitContainerTop2DeviceAndDebug.Size = new System.Drawing.Size(1063, 496);
            this.splitContainerTop2DeviceAndDebug.SplitterDistance = 308;
            this.splitContainerTop2DeviceAndDebug.TabIndex = 0;
            // 
            // tabControlDevice
            // 
            this.tabControlDevice.Controls.Add(this.tabPageBC1110);
            this.tabControlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDevice.Location = new System.Drawing.Point(0, 0);
            this.tabControlDevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControlDevice.Name = "tabControlDevice";
            this.tabControlDevice.SelectedIndex = 0;
            this.tabControlDevice.Size = new System.Drawing.Size(1061, 306);
            this.tabControlDevice.TabIndex = 0;
            // 
            // tabPageBC1110
            // 
            this.tabPageBC1110.AutoScroll = true;
            this.tabPageBC1110.AutoScrollMinSize = new System.Drawing.Size(0, 300);
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
            this.tabPageBC1110.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageBC1110.Location = new System.Drawing.Point(4, 25);
            this.tabPageBC1110.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageBC1110.Name = "tabPageBC1110";
            this.tabPageBC1110.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageBC1110.Size = new System.Drawing.Size(1053, 277);
            this.tabPageBC1110.TabIndex = 0;
            this.tabPageBC1110.Text = "BC1110";
            this.tabPageBC1110.UseVisualStyleBackColor = true;
            this.tabPageBC1110.Click += new System.EventHandler(this.tabPageBC1110_Click);
            this.tabPageBC1110.MouseHover += new System.EventHandler(this.tabPageBC1110_MouseHover);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(545, 218);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 16;
            this.button5.Text = "读取";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // buttonResetSet
            // 
            this.buttonResetSet.Location = new System.Drawing.Point(436, 218);
            this.buttonResetSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonResetSet.Name = "buttonResetSet";
            this.buttonResetSet.Size = new System.Drawing.Size(75, 30);
            this.buttonResetSet.TabIndex = 15;
            this.buttonResetSet.Text = "设置";
            this.buttonResetSet.UseVisualStyleBackColor = true;
            this.buttonResetSet.Click += new System.EventHandler(this.buttonResetSet_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(273, 218);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "无";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "重启系统";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(545, 160);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "读取";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // buttonFacRestoreSet
            // 
            this.buttonFacRestoreSet.Location = new System.Drawing.Point(436, 160);
            this.buttonFacRestoreSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFacRestoreSet.Name = "buttonFacRestoreSet";
            this.buttonFacRestoreSet.Size = new System.Drawing.Size(75, 30);
            this.buttonFacRestoreSet.TabIndex = 11;
            this.buttonFacRestoreSet.Text = "设置";
            this.buttonFacRestoreSet.UseVisualStyleBackColor = true;
            this.buttonFacRestoreSet.Click += new System.EventHandler(this.buttonFacRestoreSet_Click);
            // 
            // buttonBaudrateRead
            // 
            this.buttonBaudrateRead.Location = new System.Drawing.Point(545, 106);
            this.buttonBaudrateRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBaudrateRead.Name = "buttonBaudrateRead";
            this.buttonBaudrateRead.Size = new System.Drawing.Size(75, 30);
            this.buttonBaudrateRead.TabIndex = 10;
            this.buttonBaudrateRead.Text = "读取";
            this.buttonBaudrateRead.UseVisualStyleBackColor = true;
            this.buttonBaudrateRead.Click += new System.EventHandler(this.buttonBaudrateRead_Click);
            // 
            // buttonBaudrateSet
            // 
            this.buttonBaudrateSet.Location = new System.Drawing.Point(436, 106);
            this.buttonBaudrateSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBaudrateSet.Name = "buttonBaudrateSet";
            this.buttonBaudrateSet.Size = new System.Drawing.Size(75, 30);
            this.buttonBaudrateSet.TabIndex = 9;
            this.buttonBaudrateSet.Text = "设置";
            this.buttonBaudrateSet.UseVisualStyleBackColor = true;
            this.buttonBaudrateSet.Click += new System.EventHandler(this.buttonBaudrateSet_Click);
            // 
            // buttonNameRead
            // 
            this.buttonNameRead.Location = new System.Drawing.Point(545, 48);
            this.buttonNameRead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNameRead.Name = "buttonNameRead";
            this.buttonNameRead.Size = new System.Drawing.Size(75, 30);
            this.buttonNameRead.TabIndex = 8;
            this.buttonNameRead.Text = "读取";
            this.buttonNameRead.UseVisualStyleBackColor = true;
            this.buttonNameRead.Click += new System.EventHandler(this.buttonNameRead_Click);
            // 
            // buttonNameSet
            // 
            this.buttonNameSet.Location = new System.Drawing.Point(436, 48);
            this.buttonNameSet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonNameSet.Name = "buttonNameSet";
            this.buttonNameSet.Size = new System.Drawing.Size(75, 30);
            this.buttonNameSet.TabIndex = 7;
            this.buttonNameSet.Text = "设置";
            this.buttonNameSet.UseVisualStyleBackColor = true;
            this.buttonNameSet.Click += new System.EventHandler(this.buttonNameSet_Click);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5.Location = new System.Drawing.Point(273, 160);
            this.textBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 30);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "无";
            // 
            // textBoxBaudrate
            // 
            this.textBoxBaudrate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBaudrate.Location = new System.Drawing.Point(273, 106);
            this.textBoxBaudrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxBaudrate.Name = "textBoxBaudrate";
            this.textBoxBaudrate.Size = new System.Drawing.Size(100, 30);
            this.textBoxBaudrate.TabIndex = 5;
            this.textBoxBaudrate.TextChanged += new System.EventHandler(this.textBoxBaudrate_TextChanged);
            this.textBoxBaudrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBaudrate_KeyPress);
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxName.Location = new System.Drawing.Point(273, 48);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 30);
            this.textBoxName.TabIndex = 4;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            this.textBoxName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxName_KeyPress);
            this.textBoxName.MouseHover += new System.EventHandler(this.textBox3_MouseHover);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "恢复出厂设置";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "串口波特率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(489, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 20);
            this.label2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "广播名称";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // splitContainerSettingsAndDebug
            // 
            this.splitContainerSettingsAndDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerSettingsAndDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSettingsAndDebug.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerSettingsAndDebug.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSettingsAndDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerSettingsAndDebug.Name = "splitContainerSettingsAndDebug";
            // 
            // splitContainerSettingsAndDebug.Panel1
            // 
            this.splitContainerSettingsAndDebug.Panel1.AutoScroll = true;
            this.splitContainerSettingsAndDebug.Panel1.AutoScrollMinSize = new System.Drawing.Size(280, 0);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.buttonUartLink);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.buttonSearch);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.comboBoxBaudrate);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.comboBoxUart);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.labelBaudrate);
            this.splitContainerSettingsAndDebug.Panel1.Controls.Add(this.labelSerial);
            // 
            // splitContainerSettingsAndDebug.Panel2
            // 
            this.splitContainerSettingsAndDebug.Panel2.Controls.Add(this.splitContainerDebug);
            this.splitContainerSettingsAndDebug.Size = new System.Drawing.Size(1063, 184);
            this.splitContainerSettingsAndDebug.SplitterDistance = 274;
            this.splitContainerSettingsAndDebug.TabIndex = 0;
            // 
            // buttonUartLink
            // 
            this.buttonUartLink.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUartLink.Location = new System.Drawing.Point(155, 126);
            this.buttonUartLink.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonUartLink.Name = "buttonUartLink";
            this.buttonUartLink.Size = new System.Drawing.Size(96, 40);
            this.buttonUartLink.TabIndex = 5;
            this.buttonUartLink.Text = "连接";
            this.buttonUartLink.UseVisualStyleBackColor = true;
            this.buttonUartLink.Click += new System.EventHandler(this.buttonUartLink_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Enabled = false;
            this.buttonSearch.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSearch.Location = new System.Drawing.Point(20, 126);
            this.buttonSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(96, 40);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(109, 78);
            this.comboBoxBaudrate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(143, 23);
            this.comboBoxBaudrate.TabIndex = 3;
            this.comboBoxBaudrate.Text = "9600";
            this.comboBoxBaudrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxBaudrate_SelectedIndexChanged);
            this.comboBoxBaudrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxBaudrate_KeyPress);
            // 
            // comboBoxUart
            // 
            this.comboBoxUart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUart.FormattingEnabled = true;
            this.comboBoxUart.Items.AddRange(new object[] {
            "abc",
            "efg"});
            this.comboBoxUart.Location = new System.Drawing.Point(109, 22);
            this.comboBoxUart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxUart.Name = "comboBoxUart";
            this.comboBoxUart.Size = new System.Drawing.Size(143, 23);
            this.comboBoxUart.TabIndex = 2;
            this.comboBoxUart.MouseHover += new System.EventHandler(this.comboBoxUart_MouseHover);
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBaudrate.Location = new System.Drawing.Point(16, 80);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(100, 22);
            this.labelBaudrate.TabIndex = 1;
            this.labelBaudrate.Text = "波特率";
            // 
            // labelSerial
            // 
            this.labelSerial.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerial.Location = new System.Drawing.Point(16, 22);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(100, 22);
            this.labelSerial.TabIndex = 0;
            this.labelSerial.Text = "串口";
            // 
            // splitContainerDebug
            // 
            this.splitContainerDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDebug.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDebug.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerDebug.Name = "splitContainerDebug";
            this.splitContainerDebug.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDebug.Panel1
            // 
            this.splitContainerDebug.Panel1.Controls.Add(this.textBoxDebugMsg);
            this.splitContainerDebug.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainerDebug.Panel2
            // 
            this.splitContainerDebug.Panel2.Controls.Add(this.splitContainerDebugSend);
            this.splitContainerDebug.Size = new System.Drawing.Size(785, 184);
            this.splitContainerDebug.SplitterDistance = 155;
            this.splitContainerDebug.TabIndex = 0;
            // 
            // textBoxDebugMsg
            // 
            this.textBoxDebugMsg.ContextMenuStrip = this.contextMenuStripDebugMsg;
            this.textBoxDebugMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDebugMsg.Location = new System.Drawing.Point(0, 0);
            this.textBoxDebugMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDebugMsg.Multiline = true;
            this.textBoxDebugMsg.Name = "textBoxDebugMsg";
            this.textBoxDebugMsg.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDebugMsg.Size = new System.Drawing.Size(783, 153);
            this.textBoxDebugMsg.TabIndex = 0;
            // 
            // contextMenuStripDebugMsg
            // 
            this.contextMenuStripDebugMsg.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStripDebugMsg.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCopy,
            this.toolStripMenuItemClear});
            this.contextMenuStripDebugMsg.Name = "contextMenuStripDebugMsg";
            this.contextMenuStripDebugMsg.Size = new System.Drawing.Size(109, 52);
            // 
            // toolStripMenuItemCopy
            // 
            this.toolStripMenuItemCopy.Name = "toolStripMenuItemCopy";
            this.toolStripMenuItemCopy.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItemCopy.Text = "复制";
            this.toolStripMenuItemCopy.Click += new System.EventHandler(this.toolStripMenuItemCopy_Click);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItemClear.Text = "清空";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // splitContainerDebugSend
            // 
            this.splitContainerDebugSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDebugSend.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDebugSend.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDebugSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerDebugSend.Name = "splitContainerDebugSend";
            // 
            // splitContainerDebugSend.Panel1
            // 
            this.splitContainerDebugSend.Panel1.Controls.Add(this.textBoxDebugSend);
            // 
            // splitContainerDebugSend.Panel2
            // 
            this.splitContainerDebugSend.Panel2.Controls.Add(this.buttonDebugSend);
            this.splitContainerDebugSend.Size = new System.Drawing.Size(783, 23);
            this.splitContainerDebugSend.SplitterDistance = 673;
            this.splitContainerDebugSend.TabIndex = 0;
            // 
            // textBoxDebugSend
            // 
            this.textBoxDebugSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDebugSend.Location = new System.Drawing.Point(0, 0);
            this.textBoxDebugSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxDebugSend.Name = "textBoxDebugSend";
            this.textBoxDebugSend.Size = new System.Drawing.Size(673, 25);
            this.textBoxDebugSend.TabIndex = 0;
            this.textBoxDebugSend.TextChanged += new System.EventHandler(this.textBoxDebugSend_TextChanged);
            this.textBoxDebugSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDebugSend_KeyPress);
            this.textBoxDebugSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxDebugSend_KeyUp);
            this.textBoxDebugSend.MouseHover += new System.EventHandler(this.textBoxDebugSend_MouseHover);
            // 
            // buttonDebugSend
            // 
            this.buttonDebugSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDebugSend.Location = new System.Drawing.Point(0, 0);
            this.buttonDebugSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDebugSend.Name = "buttonDebugSend";
            this.buttonDebugSend.Size = new System.Drawing.Size(106, 23);
            this.buttonDebugSend.TabIndex = 0;
            this.buttonDebugSend.Text = "发送";
            this.buttonDebugSend.UseVisualStyleBackColor = true;
            this.buttonDebugSend.Click += new System.EventHandler(this.buttonDebugSend_Click);
            this.buttonDebugSend.MouseHover += new System.EventHandler(this.buttonDebugSend_MouseHover);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 562);
            this.Controls.Add(this.splitContainerTop1Title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "BPSTool";
            this.splitContainerTop1Title.Panel1.ResumeLayout(false);
            this.splitContainerTop1Title.Panel1.PerformLayout();
            this.splitContainerTop1Title.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop1Title)).EndInit();
            this.splitContainerTop1Title.ResumeLayout(false);
            this.splitContainerTop2DeviceAndDebug.Panel1.ResumeLayout(false);
            this.splitContainerTop2DeviceAndDebug.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerTop2DeviceAndDebug)).EndInit();
            this.splitContainerTop2DeviceAndDebug.ResumeLayout(false);
            this.tabControlDevice.ResumeLayout(false);
            this.tabPageBC1110.ResumeLayout(false);
            this.tabPageBC1110.PerformLayout();
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
            this.ResumeLayout(false);

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
    }
}

