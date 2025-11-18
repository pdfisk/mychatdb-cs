using MyChatDB.iron_python.engine;
using MyChatDB.src.windows.inspectors;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyChatDB
{
    public partial class TranscriptWindow : Form, IResultHandler
    {
        public Engine _engine;
        static TranscriptWindow _instance;
        string _wrapOutput = "Wrap Output";
        string _unwrapOutput = "Unwrap Output";

        public static TranscriptWindow GetInstance(Engine engine=null)
        {
            if (_instance == null)
            {
                _instance = new TranscriptWindow();
                if (engine != null)
                    _instance._engine = engine;
            }
            return _instance;
        }

        public void PrintLn(string text)
        {
            var window = GetInstance();
            window.PrintLn_(text);
        }

        TranscriptWindow()
        {
            InitializeComponent();
        }

        private void Transcript_Load(object sender, EventArgs e)
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

        private void clearBtn_Click(object sender, EventArgs e)
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

        private void consoleBtn_Click(object sender, EventArgs e)
        {
            PrintLn_("Open Python Console Window");
            new PythonConsoleWindow().Show();
        }

        private void wrapOutBtb_Paint(object sender, PaintEventArgs e)
        {
            wrapOutBtn.Text = _wrapOutput;
        }

        private void wrapOutBtb_Click(object sender, EventArgs e)
        {
            coutTB.WordWrap = !coutTB.WordWrap;
            wrapOutBtn.Text = coutTB.WordWrap ? _unwrapOutput : _wrapOutput;
        }

        private void wrapOutBtn_Click(object sender, EventArgs e)
        {
            coutTB.WordWrap = !coutTB.WordWrap;
            wrapOutBtn.Text = coutTB.WordWrap ? _unwrapOutput : _wrapOutput;
        }

        private void wrapOutBtn_Paint(object sender, PaintEventArgs e)
        {
            if (wrapOutBtn.Text == "")
                wrapOutBtn.Text = coutTB.WordWrap ? _unwrapOutput : _wrapOutput;
        }

        private void inspectorBtn_Click(object sender, EventArgs e)
        {
            PrintLn_("Open Object Inspector Window");
            openObjectInspectorWindow();
        }

        private void openBooleanInspectorWindow(bool value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    new BooleanInspector(value).Show();
                });
            }
            else
                new BooleanInspector(value).Show();
        }

        private void openListInspectorWindow(List<object> list)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    new ListInspector(list).Show();
                });
            }
            else
                new ListInspector(list).Show();
        }

        private void openNumberInspectorWindow(object value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    new NumberInspector(value).Show();
                });
            }
            else
                new NumberInspector(value).Show();
        }

        private void openObjectInspectorWindow(Dictionary<string, object> dictionary=null)
        {
           if (dictionary == null)
                dictionary = Engine.GetInstance().GetVariables();
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    new ObjectInspector(dictionary).Show();
                });
            }
            else
                new ObjectInspector(dictionary).Show(); 
        }

        private void openTextInspectorWindow(string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    new TextInspector(value).Show();
                });
            }
            else
                new TextInspector(value).Show();
        }

        public static void OpenBooleanInspector(bool value)
        {
            GetInstance().openBooleanInspectorWindow(value);
        }

        public static void OpenListInspector(List<object> list)
        {
            GetInstance().openListInspectorWindow(list);
        }

        public static void OpenNumberInspector(object value)
        {
            GetInstance().openNumberInspectorWindow(value);
        }

        public static void OpenObjectInspector(Dictionary<string, object> dictionary = null)
        {
           GetInstance().openObjectInspectorWindow(dictionary);
        }

        public static void OpenTextInspector(string value)
        {
            GetInstance().openTextInspectorWindow(value);
        }

    }

}

