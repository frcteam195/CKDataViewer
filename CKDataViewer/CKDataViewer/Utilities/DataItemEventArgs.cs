using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKDataViewer.Utilities
{
    public class DataItemEventArgs : EventArgs
    {

        public new static DataItemEventArgs Empty = new DataItemEventArgs("", "");
        public string Key { get; set; }
        public string Value { get; set; }

        public DataItemEventArgs(string key, string value) : base()
        {
            Key = key;
            Value = value;
        }
    }
}
