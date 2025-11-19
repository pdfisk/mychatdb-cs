using System.Collections.Generic;
using System.Windows.Forms;

namespace MyChatDB.src.windows.inspectors
{
    public partial class ObjectInspector : Form
    {
        Dictionary<string, object> _dictionary;

        public ObjectInspector(Dictionary<string, object> dictionary)
        {
            InitializeComponent();
            _dictionary = dictionary;
            refreshList();
        }

        void refreshList()
        {
            listBox.Items.Clear();
            List<string> keys = new List<string>(_dictionary.Keys);
            keys.Sort();
            foreach (string key in keys)
            {
                object value = _dictionary[key];
                listBox.Items.Add(key);
            }
        }
    }
}
