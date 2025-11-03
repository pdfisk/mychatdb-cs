namespace MyChatDB.src.windows.console
{
    partial class ConsoleButtons
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pythonBtn = new System.Windows.Forms.Button();
            this.ChatBtn = new System.Windows.Forms.Button();
            this.modelsBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pythonBtn
            // 
            this.pythonBtn.Location = new System.Drawing.Point(10, 6);
            this.pythonBtn.Name = "pythonBtn";
            this.pythonBtn.Size = new System.Drawing.Size(75, 23);
            this.pythonBtn.TabIndex = 0;
            this.pythonBtn.Text = "Python";
            this.pythonBtn.UseVisualStyleBackColor = true;
            // 
            // ChatBtn
            // 
            this.ChatBtn.Location = new System.Drawing.Point(97, 6);
            this.ChatBtn.Name = "ChatBtn";
            this.ChatBtn.Size = new System.Drawing.Size(75, 23);
            this.ChatBtn.TabIndex = 1;
            this.ChatBtn.Text = "Chat";
            this.ChatBtn.UseVisualStyleBackColor = true;
            this.ChatBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // modelsBtn
            // 
            this.modelsBtn.Location = new System.Drawing.Point(184, 6);
            this.modelsBtn.Name = "modelsBtn";
            this.modelsBtn.Size = new System.Drawing.Size(75, 23);
            this.modelsBtn.TabIndex = 2;
            this.modelsBtn.Text = "Models";
            this.modelsBtn.UseVisualStyleBackColor = true;
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(271, 6);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 3;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // ConsoleButtons
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.modelsBtn);
            this.Controls.Add(this.ChatBtn);
            this.Controls.Add(this.pythonBtn);
            this.Name = "ConsoleButtons";
            this.Size = new System.Drawing.Size(680, 36);
            this.Load += new System.EventHandler(this.ConsoleButtons_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button pythonBtn;
        private System.Windows.Forms.Button ChatBtn;
        private System.Windows.Forms.Button modelsBtn;
        private System.Windows.Forms.Button clearBtn;
    }
}
