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
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonNameRead = new System.Windows.Forms.Button();
            this.buttonNameSet = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBoxBaudrate = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.splitContainerDebugSend = new System.Windows.Forms.SplitContainer();
            this.textBoxDebugSend = new System.Windows.Forms.TextBox();
            this.buttonDebugSend = new System.Windows.Forms.Button();
            this.serialPortBPS = new System.IO.Ports.SerialPort(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
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
            this.buttonCheckVersion.Location = new System.Drawing.Point(929, 17);
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
            this.linkLabelVersionUpdate.Location = new System.Drawing.Point(577, 19);
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
            this.checkBoxDebugEnable.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxDebugEnable.Location = new System.Drawing.Point(25, 19);
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
            this.splitContainerTop2DeviceAndDebug.SplitterDistance = 305;
            this.splitContainerTop2DeviceAndDebug.TabIndex = 0;
            // 
            // tabControlDevice
            // 
            this.tabControlDevice.Controls.Add(this.tabPageBC1110);
            this.tabControlDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDevice.Location = new System.Drawing.Point(0, 0);
            this.tabControlDevice.Name = "tabControlDevice";
            this.tabControlDevice.SelectedIndex = 0;
            this.tabControlDevice.Size = new System.Drawing.Size(1061, 303);
            this.tabControlDevice.TabIndex = 0;
            // 
            // tabPageBC1110
            // 
            this.tabPageBC1110.AutoScroll = true;
            this.tabPageBC1110.AutoScrollMinSize = new System.Drawing.Size(0, 300);
            this.tabPageBC1110.Controls.Add(this.button5);
            this.tabPageBC1110.Controls.Add(this.button6);
            this.tabPageBC1110.Controls.Add(this.textBox1);
            this.tabPageBC1110.Controls.Add(this.label5);
            this.tabPageBC1110.Controls.Add(this.button3);
            this.tabPageBC1110.Controls.Add(this.button4);
            this.tabPageBC1110.Controls.Add(this.button1);
            this.tabPageBC1110.Controls.Add(this.button2);
            this.tabPageBC1110.Controls.Add(this.buttonNameRead);
            this.tabPageBC1110.Controls.Add(this.buttonNameSet);
            this.tabPageBC1110.Controls.Add(this.textBox5);
            this.tabPageBC1110.Controls.Add(this.textBoxBaudrate);
            this.tabPageBC1110.Controls.Add(this.textBox3);
            this.tabPageBC1110.Controls.Add(this.label4);
            this.tabPageBC1110.Controls.Add(this.label3);
            this.tabPageBC1110.Controls.Add(this.label2);
            this.tabPageBC1110.Controls.Add(this.label1);
            this.tabPageBC1110.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPageBC1110.Location = new System.Drawing.Point(4, 25);
            this.tabPageBC1110.Name = "tabPageBC1110";
            this.tabPageBC1110.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBC1110.Size = new System.Drawing.Size(1053, 274);
            this.tabPageBC1110.TabIndex = 0;
            this.tabPageBC1110.Text = "BC1110";
            this.tabPageBC1110.UseVisualStyleBackColor = true;
            this.tabPageBC1110.Click += new System.EventHandler(this.tabPageBC1110_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(545, 217);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 30);
            this.button5.TabIndex = 16;
            this.button5.Text = "读取";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(436, 217);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 30);
            this.button6.TabIndex = 15;
            this.button6.Text = "设置";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(273, 217);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 14;
            this.textBox1.Text = "无";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 227);
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
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 12;
            this.button3.Text = "读取";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(436, 160);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 30);
            this.button4.TabIndex = 11;
            this.button4.Text = "设置";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(545, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "读取";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(436, 106);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 9;
            this.button2.Text = "设置";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonNameRead
            // 
            this.buttonNameRead.Location = new System.Drawing.Point(545, 48);
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
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 30);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "无";
            // 
            // textBoxBaudrate
            // 
            this.textBoxBaudrate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBaudrate.Location = new System.Drawing.Point(273, 106);
            this.textBoxBaudrate.Name = "textBoxBaudrate";
            this.textBoxBaudrate.Size = new System.Drawing.Size(100, 30);
            this.textBoxBaudrate.TabIndex = 5;
            this.textBoxBaudrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxBaudrate_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(273, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 30);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.MouseHover += new System.EventHandler(this.textBox3_MouseHover);
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
            this.label2.Location = new System.Drawing.Point(489, 127);
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
            this.splitContainerSettingsAndDebug.Size = new System.Drawing.Size(1063, 187);
            this.splitContainerSettingsAndDebug.SplitterDistance = 274;
            this.splitContainerSettingsAndDebug.TabIndex = 0;
            // 
            // buttonUartLink
            // 
            this.buttonUartLink.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonUartLink.Location = new System.Drawing.Point(155, 126);
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
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(96, 40);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "搜索";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Location = new System.Drawing.Point(109, 77);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(142, 23);
            this.comboBoxBaudrate.TabIndex = 3;
            this.comboBoxBaudrate.Text = "9600";
            this.comboBoxBaudrate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxBaudrate_KeyPress);
            // 
            // comboBoxUart
            // 
            this.comboBoxUart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUart.FormattingEnabled = true;
            this.comboBoxUart.Items.AddRange(new object[] {
            "abc",
            "efg"});
            this.comboBoxUart.Location = new System.Drawing.Point(109, 23);
            this.comboBoxUart.Name = "comboBoxUart";
            this.comboBoxUart.Size = new System.Drawing.Size(142, 23);
            this.comboBoxUart.TabIndex = 2;
            this.comboBoxUart.MouseHover += new System.EventHandler(this.comboBoxUart_MouseHover);
            // 
            // labelBaudrate
            // 
            this.labelBaudrate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelBaudrate.Location = new System.Drawing.Point(16, 80);
            this.labelBaudrate.Name = "labelBaudrate";
            this.labelBaudrate.Size = new System.Drawing.Size(100, 23);
            this.labelBaudrate.TabIndex = 1;
            this.labelBaudrate.Text = "波特率";
            // 
            // labelSerial
            // 
            this.labelSerial.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSerial.Location = new System.Drawing.Point(16, 23);
            this.labelSerial.Name = "labelSerial";
            this.labelSerial.Size = new System.Drawing.Size(100, 23);
            this.labelSerial.TabIndex = 0;
            this.labelSerial.Text = "串口";
            // 
            // splitContainerDebug
            // 
            this.splitContainerDebug.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainerDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDebug.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDebug.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDebug.Name = "splitContainerDebug";
            this.splitContainerDebug.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDebug.Panel1
            // 
            this.splitContainerDebug.Panel1.Controls.Add(this.textBox2);
            this.splitContainerDebug.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainerDebug.Panel2
            // 
            this.splitContainerDebug.Panel2.Controls.Add(this.splitContainerDebugSend);
            this.splitContainerDebug.Size = new System.Drawing.Size(785, 187);
            this.splitContainerDebug.SplitterDistance = 158;
            this.splitContainerDebug.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(783, 156);
            this.textBox2.TabIndex = 0;
            // 
            // splitContainerDebugSend
            // 
            this.splitContainerDebugSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDebugSend.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerDebugSend.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainerDebugSend.SplitterDistance = 670;
            this.splitContainerDebugSend.TabIndex = 0;
            // 
            // textBoxDebugSend
            // 
            this.textBoxDebugSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDebugSend.Location = new System.Drawing.Point(0, 0);
            this.textBoxDebugSend.Name = "textBoxDebugSend";
            this.textBoxDebugSend.Size = new System.Drawing.Size(670, 25);
            this.textBoxDebugSend.TabIndex = 0;
            this.textBoxDebugSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxDebugSend_KeyPress);
            this.textBoxDebugSend.MouseHover += new System.EventHandler(this.textBoxDebugSend_MouseHover);
            // 
            // buttonDebugSend
            // 
            this.buttonDebugSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDebugSend.Enabled = false;
            this.buttonDebugSend.Location = new System.Drawing.Point(0, 0);
            this.buttonDebugSend.Name = "buttonDebugSend";
            this.buttonDebugSend.Size = new System.Drawing.Size(109, 23);
            this.buttonDebugSend.TabIndex = 0;
            this.buttonDebugSend.Text = "发送";
            this.buttonDebugSend.UseVisualStyleBackColor = true;
            this.buttonDebugSend.MouseHover += new System.EventHandler(this.buttonDebugSend_MouseHover);
            // 
            // serialPortBPS
            // 
            this.serialPortBPS.ReadTimeout = 500;
            this.serialPortBPS.WriteTimeout = 500;
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
        private System.Windows.Forms.TextBox textBox2;
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
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonNameRead;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.IO.Ports.SerialPort serialPortBPS;
        private System.IO.Ports.SerialPort serialPort1;
    }
}

