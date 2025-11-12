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
            this.consoleBtn = new System.Windows.Forms.ToolStripButton();
            this.clearBtn = new System.Windows.Forms.ToolStripButton();
            this.transcriptTextBox = new System.Windows.Forms.TextBox();
            this.transcriptToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // transcriptToolStrip
            // 
            this.transcriptToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transcriptToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pythonConsoleBtn,
            this.consoleBtn,
            this.clearBtn});
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
            // consoleBtn
            // 
            this.consoleBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.consoleBtn.Image = ((System.Drawing.Image)(resources.GetObject("consoleBtn.Image")));
            this.consoleBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.consoleBtn.Name = "chatConsoleBtn";
            this.consoleBtn.Size = new System.Drawing.Size(82, 22);
            this.consoleBtn.Text = "Chat Console";
            this.consoleBtn.Click += new System.EventHandler(this.chat_console_btn_clicked);
            // 
            // clearOutBtn
            // 
            this.clearBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearBtn.Image = ((System.Drawing.Image)(resources.GetObject("clearOutBtn.Image")));
            this.clearBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearBtn.Name = "clearOutBtn";
            this.clearBtn.Size = new System.Drawing.Size(38, 22);
            this.clearBtn.Text = "Clear";
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // transcriptTextBox
            // 
            this.transcriptTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transcriptTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transcriptTextBox.Location = new System.Drawing.Point(0, 0);
            this.transcriptTextBox.Multiline = true;
            this.transcriptTextBox.Name = "transcriptTextBox";
            this.transcriptTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.transcriptTextBox.Size = new System.Drawing.Size(477, 425);
            this.transcriptTextBox.TabIndex = 2;
            this.transcriptTextBox.TextChanged += new System.EventHandler(this.transcriptTextBox_TextChanged);
            // 
            // TranscriptWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.transcriptTextBox);
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
        private System.Windows.Forms.TextBox transcriptTextBox;
        private System.Windows.Forms.ToolStripButton consoleBtn;
        private System.Windows.Forms.ToolStripButton clearBtn;
        private System.Windows.Forms.ToolStripButton pythonConsoleBtn;
    }
}

