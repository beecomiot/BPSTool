using BPSTool.CustomWidget;
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
    public partial class LanguageForm : Form
    {
        List<String> languageIndex2Code;

        public string langSelected;

        public LanguageForm()
        {
            InitializeComponent();
            langSelected = "NONE";

            languageIndex2Code = new List<string>();

            picComboxLang.Items.Add(new PicComboxItem("English", Properties.Resources.united_kingdom_flag_icon_64));
            languageIndex2Code.Add("en");

            picComboxLang.Items.Add(new PicComboxItem("中文", Properties.Resources.china_flag_icon_64));
            languageIndex2Code.Add("zh-Hans");

            picComboxLang.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                langSelected = languageIndex2Code[picComboxLang.SelectedIndex];
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
