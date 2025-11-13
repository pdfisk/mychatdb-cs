namespace MyChatDB
{
    partial class PythonConsoleWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PythonConsoleWindow));
            this.transcriptToolStrip = new System.Windows.Forms.ToolStrip();
            this.pythonBtn = new System.Windows.Forms.ToolStripButton();
            this.clearOutBtn = new System.Windows.Forms.ToolStripButton();
            this.clearInBtn = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.coutTB = new System.Windows.Forms.TextBox();
            this.cinTB = new System.Windows.Forms.TextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wrapOutBtn = new System.Windows.Forms.ToolStripButton();
            this.transcriptToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // transcriptToolStrip
            // 
            this.transcriptToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transcriptToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pythonBtn,
            this.toolStripSeparator1,
            this.clearOutBtn,
            this.clearInBtn,
            this.toolStripSeparator2,
            this.wrapOutBtn});
            this.transcriptToolStrip.Location = new System.Drawing.Point(0, 425);
            this.transcriptToolStrip.Name = "transcriptToolStrip";
            this.transcriptToolStrip.Size = new System.Drawing.Size(477, 25);
            this.transcriptToolStrip.TabIndex = 0;
            // 
            // pythonBtn
            // 
            this.pythonBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pythonBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pythonBtn.Name = "pythonBtn";
            this.pythonBtn.Size = new System.Drawing.Size(32, 22);
            this.pythonBtn.Text = "Run";
            this.pythonBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.pythonBtn.Click += new System.EventHandler(this.python_btn_clicked);
            // 
            // clearOutBtn
            // 
            this.clearOutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearOutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearOutBtn.Name = "clearOutBtn";
            this.clearOutBtn.Size = new System.Drawing.Size(61, 22);
            this.clearOutBtn.Text = "Clear Out";
            this.clearOutBtn.Click += new System.EventHandler(this.clear_out_btn_clicked);
            // 
            // clearInBtn
            // 
            this.clearInBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearInBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearInBtn.Image")));
            this.clearInBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearInBtn.Name = "clearInBtn";
            this.clearInBtn.Size = new System.Drawing.Size(51, 22);
            this.clearInBtn.Text = "Clear In";
            this.clearInBtn.Click += new System.EventHandler(this.clearInBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.coutTB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cinTB);
            this.splitContainer1.Size = new System.Drawing.Size(477, 425);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 1;
            // 
            // coutTB
            // 
            this.coutTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coutTB.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coutTB.Location = new System.Drawing.Point(0, 0);
            this.coutTB.Multiline = true;
            this.coutTB.Name = "coutTB";
            this.coutTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.coutTB.Size = new System.Drawing.Size(477, 225);
            this.coutTB.TabIndex = 0;
            this.coutTB.WordWrap = false;
            // 
            // cinTB
            // 
            this.cinTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cinTB.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cinTB.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.cinTB.Location = new System.Drawing.Point(0, 0);
            this.cinTB.Multiline = true;
            this.cinTB.Name = "cinTB";
            this.cinTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cinTB.Size = new System.Drawing.Size(477, 196);
            this.cinTB.TabIndex = 0;
            this.cinTB.WordWrap = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // wrapOutBtn
            // 
            this.wrapOutBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.wrapOutBtn.Image = ((System.Drawing.Image)(resources.GetObject("wrapOutBtn.Image")));
            this.wrapOutBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wrapOutBtn.Name = "wrapOutBtn";
            this.wrapOutBtn.Size = new System.Drawing.Size(23, 22);
            this.wrapOutBtn.Click += new System.EventHandler(this.wrapOutBtn_Click);
            this.wrapOutBtn.Paint += new System.Windows.Forms.PaintEventHandler(this.wrapOutBtn_Paint);
            // 
            // PythonConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.transcriptToolStrip);
            this.Name = "PythonConsoleWindow";
            this.Text = "Python Console";
            this.Load += new System.EventHandler(this.Transcript_Load);
            this.transcriptToolStrip.ResumeLayout(false);
            this.transcriptToolStrip.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton pythonBtn;
        private System.Windows.Forms.ToolStripButton clearOutBtn;
        private System.Windows.Forms.TextBox coutTB;
        private System.Windows.Forms.ToolStripButton clearInBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton wrapOutBtn;
    }
}

