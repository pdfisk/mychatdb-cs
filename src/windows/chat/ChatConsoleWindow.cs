using MyChatDB.api;
using MyChatDB.iron_python.engine;
using System;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class ChatConsoleWindow : Form, IResultHandler
    {
        public Engine engine;
        OpenAIChatService client =new OpenAIChatService();
        public ChatConsoleWindow()
        {
            InitializeComponent();
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

        public void AppendText(string text)
        {
            if (coutTB.InvokeRequired)
            {
                coutTB.Invoke(new Action<string>(AppendText), text);
            }
            else
            {
                coutTB.AppendText(text);
            }
        }

        public void ClearText()
        {
            if (coutTB.InvokeRequired)
            {
                coutTB.Invoke(new Action(ClearText));
            }
            else
            {
                coutTB.Clear();
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
            PrintLn(resultObject._stdout);
        }

        void TranscriptPrintLn(string text)
        {
            TranscriptWindow.GetInstance().PrintLn(text);
        }

        private void chatBtn_Click(object sender, MouseEventArgs e)
        {
            client.sendMessage(cinTB.Text);
        }

        private void modelsBtn_Click(object sender, EventArgs e)
        {
            //LmApi.Instance.GetModels(this);

        }

        private void transcriptToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void chatBtn_Click(object sender, EventArgs e)
        //{
        //    PrintLn("Calling LLM...");
        //    var startTime = DateTime.Now;
        //    LmApi.Instance.ChatAsync(cinTB.Text, "qwen/qwen3-coder-30b").ContinueWith(task =>
        //    {
        //        if (task.Exception != null)
        //        {
        //            PrintLn("Error: " + task.Exception.InnerException.Message);
        //        }
        //        else
        //        {
        //            var endTime = DateTime.Now;
        //            var seconds = Math.Round((endTime - startTime).TotalSeconds, 2);
        //            PrintLn($"Completed in {seconds} seconds.");
        //            PrintLn("Response: " + task.Result.Trim());
        //        }
        //    });

        //}
    }

}

