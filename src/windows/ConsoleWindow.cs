using api;
using MyChatDB.iron_python.engine;
using System;
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

        private async void python_btn_clicked(object sender, EventArgs e)
        {
            var code = transcriptTextBox.Text;
            engine.RunScript(code, TranscriptWindow.GetInstance());
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
            PrintLn(string.Format("Result: [{0}]", resultObject._stdout));
        }

        void TranscriptPrintLn(string text)
        {
            TranscriptWindow.GetInstance().PrintLn(text);
        }

        private void chatBtn_MouseClick(object sender, MouseEventArgs e)
        {
            TranscriptPrintLn("Calling LLM...");
            var startTime = DateTime.Now;
            LmApi.Instance.ChatAsync(transcriptTextBox.Text, "qwen/qwen3-coder-30b").ContinueWith(task =>
             {
                 if (task.Exception != null)
                 {
                     TranscriptWindow.GetInstance().PrintLn("Error: " + task.Exception.InnerException.Message);
                 }
                 else
                 {
                     var endTime = DateTime.Now;
                     var seconds = Math.Round((endTime - startTime).TotalSeconds, 2);
                     TranscriptPrintLn($"Completed in {seconds} seconds.");
                     TranscriptWindow.GetInstance().PrintLn("Response: " + task.Result);
                 }
             });
        }

        private void modelsBtn_Click(object sender, EventArgs e)
        {
            LmApi.Instance.GetModels(TranscriptWindow.GetInstance());

        }
    }

}

