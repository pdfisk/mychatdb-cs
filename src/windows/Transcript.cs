using MyChatDB.core.iron_python;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class Transcript : Form
    {
        public Engine engine;
        public Transcript()
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
            Task<(object result, string stdout, string stderr)> task = engine.ExecuteAsync("print(5+6)");
            await task;
            PrintLn($"Result: {task.Result.result}");
            PrintLn($"Stdout: {task.Result.stdout}");
            PrintLn($"Stderr: {task.Result.stderr}");
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

