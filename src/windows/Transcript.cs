using MyChatDB.core.iron_python;
using System;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class Transcript : Form
    {
        public Engine engine;
        public Transcript(Engine engine)
        {
            InitializeComponent();
            this.engine = engine;
        }

        private void Transcript_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var s = string.Format("engine.Instance {0}", engine == null);
            PrintLn(s);
        }

        public void AppendText(string text)
        {
            if (transcriptTextBox.InvokeRequired)
            {
                transcriptTextBox.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                transcriptTextBox.AppendText(text);
            }
        }

        public void ClearText()
        {
            if (transcriptTextBox.InvokeRequired)
            {
                transcriptTextBox.Invoke(new Action(ClearText));
            }
            else
            {
                transcriptTextBox.Clear();
            }
        }

        public void PrintLn(string text)
        {
            AppendText(text + Environment.NewLine);
        }

        public void SetText(string text)
        {
            ClearText();
            AppendText(text);
        }
    }

}

