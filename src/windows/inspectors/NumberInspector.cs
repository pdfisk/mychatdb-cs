using System.Windows.Forms;

namespace MyChatDB.src.windows.inspectors
{
    public partial class NumberInspector : Form
    {
        public NumberInspector(object value)
        {
            InitializeComponent();
            textBox.Text = value.ToString();
            textBox.SelectionStart = 0;
            textBox.SelectionLength = 0;
        }
    }
}
