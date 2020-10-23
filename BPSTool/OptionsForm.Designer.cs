namespace BPSTool
{
    partial class OptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxMasterAddr = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSlaveAddr = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBoxMasterAddr
            // 
            resources.ApplyResources(this.comboBoxMasterAddr, "comboBoxMasterAddr");
            this.comboBoxMasterAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMasterAddr.FormattingEnabled = true;
            this.comboBoxMasterAddr.Items.AddRange(new object[] {
            resources.GetString("comboBoxMasterAddr.Items"),
            resources.GetString("comboBoxMasterAddr.Items1"),
            resources.GetString("comboBoxMasterAddr.Items2"),
            resources.GetString("comboBoxMasterAddr.Items3"),
            resources.GetString("comboBoxMasterAddr.Items4"),
            resources.GetString("comboBoxMasterAddr.Items5"),
            resources.GetString("comboBoxMasterAddr.Items6"),
            resources.GetString("comboBoxMasterAddr.Items7"),
            resources.GetString("comboBoxMasterAddr.Items8"),
            resources.GetString("comboBoxMasterAddr.Items9"),
            resources.GetString("comboBoxMasterAddr.Items10"),
            resources.GetString("comboBoxMasterAddr.Items11"),
            resources.GetString("comboBoxMasterAddr.Items12"),
            resources.GetString("comboBoxMasterAddr.Items13"),
            resources.GetString("comboBoxMasterAddr.Items14")});
            this.comboBoxMasterAddr.Name = "comboBoxMasterAddr";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBoxSlaveAddr
            // 
            resources.ApplyResources(this.comboBoxSlaveAddr, "comboBoxSlaveAddr");
            this.comboBoxSlaveAddr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSlaveAddr.FormattingEnabled = true;
            this.comboBoxSlaveAddr.Items.AddRange(new object[] {
            resources.GetString("comboBoxSlaveAddr.Items"),
            resources.GetString("comboBoxSlaveAddr.Items1"),
            resources.GetString("comboBoxSlaveAddr.Items2"),
            resources.GetString("comboBoxSlaveAddr.Items3"),
            resources.GetString("comboBoxSlaveAddr.Items4"),
            resources.GetString("comboBoxSlaveAddr.Items5"),
            resources.GetString("comboBoxSlaveAddr.Items6"),
            resources.GetString("comboBoxSlaveAddr.Items7"),
            resources.GetString("comboBoxSlaveAddr.Items8"),
            resources.GetString("comboBoxSlaveAddr.Items9"),
            resources.GetString("comboBoxSlaveAddr.Items10"),
            resources.GetString("comboBoxSlaveAddr.Items11"),
            resources.GetString("comboBoxSlaveAddr.Items12"),
            resources.GetString("comboBoxSlaveAddr.Items13"),
            resources.GetString("comboBoxSlaveAddr.Items14")});
            this.comboBoxSlaveAddr.Name = "comboBoxSlaveAddr";
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // OptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.comboBoxSlaveAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMasterAddr);
            this.Controls.Add(this.label1);
            this.Name = "OptionsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxMasterAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSlaveAddr;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}