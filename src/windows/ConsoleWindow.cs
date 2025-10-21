using MyChatDB.core.iron_python;
using MyChatDB.src.iron_python.util;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class ConsoleWindow : Form, IResultHandler
    {
        public Engine engine;
        public ConsoleWindow()
        {
            InitializeComponent();
            this.engine = Engine.GetInstance(this);
        }

        private void Transcript_Load(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void clear_btn_clicked(object sender, EventArgs e)
        {
            ClearText();
        }

        private async void run_btn_clicked(object sender, EventArgs e)
        {
            PrintLn("run_btn_clicked");
            var code = "print(5+6)";
            engine.RunScript(code, this);
            Task<(object result, string stdout, string stderr)> task = engine.ExecuteAsync(code);
            await task;
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

        public void HandleResult(ResultObject resultObject)
        {
            PrintLn(string.Format("HandleResult called: {0}", resultObject._stdout));
        }
    }

}

