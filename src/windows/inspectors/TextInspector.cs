using System.Windows.Forms;

namespace MyChatDB.src.windows.inspectors
{
    public partial class TextInspector : Form
    {
        public TextInspector(string text)
        {
            InitializeComponent();
            textBox.Text = text;
            textBox.SelectionStart = 0;
            textBox.SelectionLength = 0;
        }
    }
}
