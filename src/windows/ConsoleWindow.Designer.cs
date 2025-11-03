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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleWindow));
            this.transcriptToolStrip = new System.Windows.Forms.ToolStrip();
            this.pythonBtn = new System.Windows.Forms.ToolStripButton();
            this.chatBtn = new System.Windows.Forms.ToolStripButton();
            this.modelsBtn = new System.Windows.Forms.ToolStripButton();
            this.clearBtn = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cinTB = new System.Windows.Forms.TextBox();
            this.coutTB = new System.Windows.Forms.TextBox();
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
            this.chatBtn,
            this.modelsBtn,
            this.clearBtn});
            this.transcriptToolStrip.Location = new System.Drawing.Point(0, 425);
            this.transcriptToolStrip.Name = "transcriptToolStrip";
            this.transcriptToolStrip.Size = new System.Drawing.Size(477, 25);
            this.transcriptToolStrip.TabIndex = 0;
            this.transcriptToolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.transcriptToolStrip_ItemClicked);
            // 
            // pythonBtn
            // 
            this.pythonBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.pythonBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pythonBtn.Name = "pythonBtn";
            this.pythonBtn.Size = new System.Drawing.Size(49, 22);
            this.pythonBtn.Text = "Python";
            this.pythonBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.pythonBtn.Click += new System.EventHandler(this.python_btn_clicked);
            // 
            // chatBtn
            // 
            this.chatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.chatBtn.Image = ((System.Drawing.Image)(resources.GetObject("chatBtn.Image")));
            this.chatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(36, 22);
            this.chatBtn.Text = "Chat";
            this.chatBtn.Click += new System.EventHandler(this.chatBtn_Click);
            // 
            // modelsBtn
            // 
            this.modelsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.modelsBtn.Image = ((System.Drawing.Image)(resources.GetObject("modelsBtn.Image")));
            this.modelsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.modelsBtn.Name = "modelsBtn";
            this.modelsBtn.Size = new System.Drawing.Size(50, 22);
            this.modelsBtn.Text = "Models";
            this.modelsBtn.Click += new System.EventHandler(this.modelsBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearBtn.Image")));
            this.clearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(38, 22);
            this.clearBtn.Text = "Clear";
            this.clearBtn.Click += new System.EventHandler(this.clear_btn_clicked);
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
            this.splitContainer1.Panel1.Controls.Add(this.cinTB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.coutTB);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(477, 425);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 1;
            // 
            // cinTB
            // 
            this.cinTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cinTB.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cinTB.Location = new System.Drawing.Point(0, 0);
            this.cinTB.Multiline = true;
            this.cinTB.Name = "cinTB";
            this.cinTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.cinTB.Size = new System.Drawing.Size(477, 225);
            this.cinTB.TabIndex = 0;
            this.cinTB.WordWrap = false;
            // 
            // coutTB
            // 
            this.coutTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coutTB.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coutTB.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.coutTB.Location = new System.Drawing.Point(0, 0);
            this.coutTB.Multiline = true;
            this.coutTB.Name = "coutTB";
            this.coutTB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.coutTB.Size = new System.Drawing.Size(477, 196);
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
        private System.Windows.Forms.TextBox coutTB;
        private System.Windows.Forms.ToolStripButton pythonBtn;
        private System.Windows.Forms.ToolStripButton chatBtn;
        private System.Windows.Forms.ToolStripButton modelsBtn;
        private System.Windows.Forms.ToolStripButton clearBtn;
        private System.Windows.Forms.TextBox cinTB;
    }
}

