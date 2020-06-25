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
            this.splitContainerWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerWaiting.Location = new System.Drawing.Point(0, 0);
            this.splitContainerWaiting.Name = "splitContainerWaiting";
            // 
            // splitContainerWaiting.Panel1
            // 
            this.splitContainerWaiting.Panel1.Controls.Add(this.pictureBoxWaiting);
            // 
            // splitContainerWaiting.Panel2
            // 
            this.splitContainerWaiting.Panel2.Controls.Add(this.labeSearchlNote);
            this.splitContainerWaiting.Size = new System.Drawing.Size(540, 200);
            this.splitContainerWaiting.SplitterDistance = 180;
            this.splitContainerWaiting.TabIndex = 0;
            // 
            // pictureBoxWaiting
            // 
            this.pictureBoxWaiting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxWaiting.Image = global::BPSTool.Properties.Resources.waiting;
            this.pictureBoxWaiting.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxWaiting.Name = "pictureBoxWaiting";
            this.pictureBoxWaiting.Size = new System.Drawing.Size(180, 200);
            this.pictureBoxWaiting.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxWaiting.TabIndex = 0;
            this.pictureBoxWaiting.TabStop = false;
            // 
            // labeSearchlNote
            // 
            this.labeSearchlNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labeSearchlNote.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labeSearchlNote.Location = new System.Drawing.Point(0, 0);
            this.labeSearchlNote.Name = "labeSearchlNote";
            this.labeSearchlNote.Size = new System.Drawing.Size(356, 200);
            this.labeSearchlNote.TabIndex = 0;
            this.labeSearchlNote.Text = "波特率9600搜索(5)...";
            this.labeSearchlNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerSearchEndCheck
            // 
            this.timerSearchEndCheck.Enabled = true;
            this.timerSearchEndCheck.Interval = 500;
            this.timerSearchEndCheck.Tick += new System.EventHandler(this.timerSearchEndCheck_Tick);
            // 
            // SearchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(540, 200);
            this.Controls.Add(this.splitContainerWaiting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SearchingForm";
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