namespace BPSTool
{
    partial class SearchingForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchingForm));
            this.splitContainerWaiting = new System.Windows.Forms.SplitContainer();
            this.pictureBoxWaiting = new System.Windows.Forms.PictureBox();
            this.labeSearchlNote = new System.Windows.Forms.Label();
            this.timerSearchEndCheck = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWaiting)).BeginInit();
            this.splitContainerWaiting.Panel1.SuspendLayout();
            this.splitContainerWaiting.Panel2.SuspendLayout();
            this.splitContainerWaiting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaiting)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerWaiting
            // 
            resources.ApplyResources(this.splitContainerWaiting, "splitContainerWaiting");
            this.splitContainerWaiting.Name = "splitContainerWaiting";
            // 
            // splitContainerWaiting.Panel1
            // 
            resources.ApplyResources(this.splitContainerWaiting.Panel1, "splitContainerWaiting.Panel1");
            this.splitContainerWaiting.Panel1.Controls.Add(this.pictureBoxWaiting);
            // 
            // splitContainerWaiting.Panel2
            // 
            resources.ApplyResources(this.splitContainerWaiting.Panel2, "splitContainerWaiting.Panel2");
            this.splitContainerWaiting.Panel2.Controls.Add(this.labeSearchlNote);
            // 
            // pictureBoxWaiting
            // 
            resources.ApplyResources(this.pictureBoxWaiting, "pictureBoxWaiting");
            this.pictureBoxWaiting.Image = global::BPSTool.Properties.Resources.waiting;
            this.pictureBoxWaiting.Name = "pictureBoxWaiting";
            this.pictureBoxWaiting.TabStop = false;
            // 
            // labeSearchlNote
            // 
            resources.ApplyResources(this.labeSearchlNote, "labeSearchlNote");
            this.labeSearchlNote.Name = "labeSearchlNote";
            // 
            // timerSearchEndCheck
            // 
            this.timerSearchEndCheck.Enabled = true;
            this.timerSearchEndCheck.Interval = 500;
            this.timerSearchEndCheck.Tick += new System.EventHandler(this.timerSearchEndCheck_Tick);
            // 
            // SearchingForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.splitContainerWaiting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchingForm";
            this.Shown += new System.EventHandler(this.SearchingForm_Shown);
            this.splitContainerWaiting.Panel1.ResumeLayout(false);
            this.splitContainerWaiting.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerWaiting)).EndInit();
            this.splitContainerWaiting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaiting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerWaiting;
        private System.Windows.Forms.PictureBox pictureBoxWaiting;
        private System.Windows.Forms.Label labeSearchlNote;
        private System.Windows.Forms.Timer timerSearchEndCheck;
    }
}