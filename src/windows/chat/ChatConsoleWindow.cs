using MyChatDB.iron_python.engine;
using src.chatgpt;
using System;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class ChatConsoleWindow : Form, IResultHandler
    {
        public Engine engine;
        LMStudioClient client = new LMStudioClient();
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

        private void chatBtn_Click(object sender, EventArgs e)
        {
            PrintLn("Calling LLM...");
            var startTime = DateTime.Now;
            var prompt = cinTB.Text;
            client.sendMessage(prompt, this);
        }

        private void modelsBtn_Click(object sender, EventArgs e)
        {
            PrintLn("Fetching models...");
            client.getModels(this);
        }

        private void transcriptToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}

