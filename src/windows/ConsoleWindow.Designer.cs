namespace MyChatDB
{
    partial class ConsoleWindow
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
            this.transcriptToolStrip = new System.Windows.Forms.ToolStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cinTB = new System.Windows.Forms.TextBox();
            this.coutTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // transcriptToolStrip
            // 
            this.transcriptToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transcriptToolStrip.Location = new System.Drawing.Point(0, 425);
            this.transcriptToolStrip.Name = "transcriptToolStrip";
            this.transcriptToolStrip.Size = new System.Drawing.Size(477, 25);
            this.transcriptToolStrip.TabIndex = 0;
            this.transcriptToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.transcriptToolStrip_ItemClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cinTB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.coutTB);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(477, 425);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 1;
            // 
            // cinTB
            // 
            this.cinTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cinTB.Location = new System.Drawing.Point(0, 0);
            this.cinTB.Multiline = true;
            this.cinTB.Name = "cinTB";
            this.cinTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cinTB.Size = new System.Drawing.Size(235, 425);
            this.cinTB.TabIndex = 0;
            this.cinTB.WordWrap = false;
            // 
            // coutTB
            // 
            this.coutTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coutTB.Location = new System.Drawing.Point(0, 0);
            this.coutTB.Multiline = true;
            this.coutTB.Name = "coutTB";
            this.coutTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.coutTB.Size = new System.Drawing.Size(238, 425);
            this.coutTB.TabIndex = 0;
            this.coutTB.WordWrap = false;
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.transcriptToolStrip);
            this.Name = "ConsoleWindow";
            this.Text = "Console";
            this.Load += new System.EventHandler(this.Transcript_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip transcriptToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox cinTB;
        private System.Windows.Forms.TextBox coutTB;
    }
}

