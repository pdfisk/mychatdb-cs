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
            this.clearBtn = new System.Windows.Forms.Button();
            this.transcriptTextBox = new System.Windows.Forms.TextBox();
            this.pythonBtn = new System.Windows.Forms.Button();
            this.chatBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // transcriptToolStrip
            // 
            this.transcriptToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transcriptToolStrip.Location = new System.Drawing.Point(0, 425);
            this.transcriptToolStrip.Name = "transcriptToolStrip";
            this.transcriptToolStrip.Size = new System.Drawing.Size(477, 25);
            this.transcriptToolStrip.TabIndex = 0;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(228, 427);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clear_btn_clicked);
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
            // 
            // pythonBtn
            // 
            this.pythonBtn.Location = new System.Drawing.Point(30, 427);
            this.pythonBtn.Name = "pythonBtn";
            this.pythonBtn.Size = new System.Drawing.Size(75, 23);
            this.pythonBtn.TabIndex = 3;
            this.pythonBtn.Text = "Python";
            this.pythonBtn.UseVisualStyleBackColor = true;
            this.pythonBtn.Click += new System.EventHandler(this.python_btn_clicked);
            // 
            // chatBtn
            // 
            this.chatBtn.Location = new System.Drawing.Point(129, 427);
            this.chatBtn.Name = "chatBtn";
            this.chatBtn.Size = new System.Drawing.Size(75, 23);
            this.chatBtn.TabIndex = 4;
            this.chatBtn.Text = "Chat";
            this.chatBtn.UseVisualStyleBackColor = true;
            this.chatBtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chatBtn_MouseClick);
            // 
            // ConsoleWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.chatBtn);
            this.Controls.Add(this.pythonBtn);
            this.Controls.Add(this.transcriptTextBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.transcriptToolStrip);
            this.Name = "ConsoleWindow";
            this.Text = "Console";
            this.Load += new System.EventHandler(this.Transcript_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip transcriptToolStrip;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.TextBox transcriptTextBox;
        private System.Windows.Forms.Button pythonBtn;
        private System.Windows.Forms.Button chatBtn;
    }
}

