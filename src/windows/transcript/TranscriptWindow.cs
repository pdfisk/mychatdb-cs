using MyChatDB.iron_python.engine;
using System;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class TranscriptWindow : Form, IResultHandler
    {
        public Engine engine;
        static TranscriptWindow instance;

        public static TranscriptWindow GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new TranscriptWindow();
            }
            return instance;
        }

        public void PrintLn(string text)
        {
            var window = GetInstance();
            window.PrintLn_(text);
        }

        TranscriptWindow()
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
        private async void chat_console_btn_clicked(object sender, EventArgs e)
        {
            PrintLn_("Open Chat Console Window");
            new ChatConsoleWindow().Show();
        }

        private async void python_console_btn_clicked(object sender, EventArgs e)
        {
            PrintLn_("Open Python Console Window");
            new PythonConsoleWindow().Show();
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

        public void PrintLn_(string text)
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
            PrintLn_(resultObject._stdout);
        }

        private void transcriptTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
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

        private void consoleBtn_Click(object sender, EventArgs e)
        {
            PrintLn_("Open Python Console Window");
            new PythonConsoleWindow().Show();
        }
    }

}

