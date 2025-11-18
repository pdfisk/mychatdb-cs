using MyChatDB.iron_python.engine;
using System;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class PythonConsoleWindow : Form, IResultHandler
    {
        public Engine engine;
        string wrapOutput = "Wrap Output";
        string unwrapOutput = "Unwrap Output";

        public PythonConsoleWindow()
        {
            InitializeComponent();
            this.engine = Engine.GetInstance();
        }

        private void Transcript_Load(object sender, EventArgs e)
        {

        }

        private void clear_out_btn_clicked(object sender, EventArgs e)
        {
            ClearTextOut();
        }

        private void python_btn_clicked(object sender, EventArgs e)
        {
            var code = cinTB.Text;
            engine.RunScript(code, this);
        }

        public void AppendTextIn(string text)
        {
            if (cinTB.InvokeRequired)
            {
                cinTB.Invoke(new Action<string>(AppendTextIn), text);
            }
            else
            {
                cinTB.AppendText(text);
            }
        }

        public void AppendTextOut(string text)
        {
            if (coutTB.InvokeRequired)
            {
                coutTB.Invoke(new Action<string>(AppendTextOut), text);
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
            AppendTextOut(text + Environment.NewLine);
        }

        public void SetTextIn(string text)
        {
            ClearTextIn();
            AppendTextIn(text);
        }

        public void SetTextOut(string text)
        {
            ClearTextOut();
            AppendTextOut(text);
        }

        public void HandleResult(ResultObject resultObject)
        {
            PrintLn(resultObject._stdout);
        }


        private void clearInBtn_Click(object sender, EventArgs e)
        {
            ClearTextIn();
        }

        private void wrapOutBtn_Paint(object sender, PaintEventArgs e)
        {
            if (wrapOutBtn.Text == "")
                wrapOutBtn.Text = wrapOutput;
        }

        private void wrapOutBtn_Click(object sender, EventArgs e)
        {
            coutTB.WordWrap = !coutTB.WordWrap;
            wrapOutBtn.Text = coutTB.WordWrap ? unwrapOutput : wrapOutput;
        }
    }

}

