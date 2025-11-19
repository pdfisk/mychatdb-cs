using System.Windows.Forms;

namespace MyChatDB.src.windows.inspectors
{
    public partial class BooleanInspector : Form
    {
        public BooleanInspector(bool b)
        {
            InitializeComponent();
            if (b)             {
                radioButtonTrue.Checked = true;
            }
            else
            {
                radioButtonFalse.Checked = true;
            }
        }
    }
}
