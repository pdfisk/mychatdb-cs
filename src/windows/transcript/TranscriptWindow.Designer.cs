namespace MyChatDB
{
    partial class TranscriptWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TranscriptWindow));
            this.transcriptToolStrip = new System.Windows.Forms.ToolStrip();
            this.pythonConsoleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.consoleBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.clearBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.wrapOutBtn = new System.Windows.Forms.ToolStripButton();
            this.coutTB = new System.Windows.Forms.TextBox();
            this.inspectorBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.transcriptToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // transcriptToolStrip
            // 
            this.transcriptToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transcriptToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pythonConsoleBtn,
            this.toolStripSeparator1,
            this.consoleBtn,
            this.toolStripSeparator4,
            this.inspectorBtn,
            this.toolStripSeparator2,
            this.clearBtn,
            this.toolStripSeparator3,
            this.wrapOutBtn});
            this.transcriptToolStrip.Location = new System.Drawing.Point(0, 425);
            this.transcriptToolStrip.Name = "transcriptToolStrip";
            this.transcriptToolStrip.Size = new System.Drawing.Size(477, 25);
            this.transcriptToolStrip.TabIndex = 0;
            // 
            // pythonConsoleBtn
            // 
            this.pythonConsoleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pythonConsoleBtn.Image = ((System.Drawing.Image)(resources.GetObject("pythonConsoleBtn.Image")));
            this.pythonConsoleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pythonConsoleBtn.Name = "pythonConsoleBtn";
            this.pythonConsoleBtn.Size = new System.Drawing.Size(95, 22);
            this.pythonConsoleBtn.Text = "Python Console";
            this.pythonConsoleBtn.Click += new System.EventHandler(this.python_console_btn_clicked);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // consoleBtn
            // 
            this.consoleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.consoleBtn.Image = ((System.Drawing.Image)(resources.GetObject("consoleBtn.Image")));
            this.consoleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.consoleBtn.Name = "consoleBtn";
            this.consoleBtn.Size = new System.Drawing.Size(82, 22);
            this.consoleBtn.Text = "Chat Console";
            this.consoleBtn.Click += new System.EventHandler(this.chat_console_btn_clicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // clearBtn
            // 
            this.clearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(38, 22);
            this.clearBtn.Text = "Clear";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            // coutTB
            // 
            this.coutTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coutTB.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coutTB.Location = new System.Drawing.Point(0, 0);
            this.coutTB.Multiline = true;
            this.coutTB.Name = "coutTB";
            this.coutTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.coutTB.Size = new System.Drawing.Size(477, 425);
            this.coutTB.TabIndex = 2;
            this.coutTB.WordWrap = false;
            // 
            // inspectorBtn
            // 
            this.inspectorBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.inspectorBtn.Image = ((System.Drawing.Image)(resources.GetObject("inspectorBtn.Image")));
            this.inspectorBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inspectorBtn.Name = "inspectorBtn";
            this.inspectorBtn.Size = new System.Drawing.Size(60, 22);
            this.inspectorBtn.Text = "Inspector";
            this.inspectorBtn.Click += new System.EventHandler(this.inspectorBtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // TranscriptWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.coutTB);
            this.Controls.Add(this.transcriptToolStrip);
            this.Name = "TranscriptWindow";
            this.Text = "Transcript";
            this.Load += new System.EventHandler(this.Transcript_Load);
            this.transcriptToolStrip.ResumeLayout(false);
            this.transcriptToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip transcriptToolStrip;
        private System.Windows.Forms.TextBox coutTB;
        private System.Windows.Forms.ToolStripButton consoleBtn;
        private System.Windows.Forms.ToolStripButton clearBtn;
        private System.Windows.Forms.ToolStripButton pythonConsoleBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton wrapOutBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton inspectorBtn;
    }
}

