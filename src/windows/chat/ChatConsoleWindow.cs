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
        string wrapOutput = "Wrap Output";
        string unwrapOutput = "Unwrap Output";

        public ChatConsoleWindow()
        {
            InitializeComponent();
        }

        private void Transcript_Load(object sender, EventArgs e)
        {

        }

        private void clear_out_btn_clicked(object sender, EventArgs e)
        {
            ClearTextOut();
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

        public void ClearTextIn()
        {
            if (cinTB.InvokeRequired)
            {
                cinTB.Invoke(new Action(ClearTextIn));
            }
            else
            {
                cinTB.Clear();
            }
        }

        public void ClearTextOut()
        {
            if (coutTB.InvokeRequired)
            {
                coutTB.Invoke(new Action(ClearTextOut));
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

        public void HandleResult(ResultObject resultObject)
        {
            PrintLn(resultObject._stdout);
        }

        private void chatBtn_Click(object sender, EventArgs e)
        {
            var startTime = DateTime.Now;
            var prompt = cinTB.Text;
            client.sendMessage(prompt, this);
        }

        private void modelsBtn_Click(object sender, EventArgs e)
        {
            PrintLn("Fetching models...");
            client.getModels(this);
        }

        private void clear_in_btn_click(object sender, EventArgs e)
        {
            ClearTextIn();
        }

        private void wrapOutBtn_Click(object sender, EventArgs e)
        {
            coutTB.WordWrap = !coutTB.WordWrap;
            wrapOutBtn.Text = coutTB.WordWrap ? unwrapOutput : wrapOutput;
        }

        private void wrapOutBtn_Paint(object sender, PaintEventArgs e)
        {
            if (wrapOutBtn.Text == "")
                wrapOutBtn.Text = wrapOutput;
        }
    }
}

