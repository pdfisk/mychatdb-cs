using System;
using System.Windows.Forms;

namespace MyChatDB
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(TranscriptWindow.GetInstance());
        }
    }
}
