using System.Collections.Generic;
using System.Windows.Forms;

namespace MyChatDB.src.windows.inspectors
{
    public partial class ListInspector : Form
    {
        List<object> _list;
        public ListInspector(List<object> list)
        {
            InitializeComponent();
            _list = list;
            refreshList();
        }

        void refreshList()
        {
           listBox.Items.Clear();
            for (int i = 0; i < _list.Count; i++)
            {
                listBox.Items.Add(_list[i]?.ToString() ?? "null");
            }
        }
    }
}
