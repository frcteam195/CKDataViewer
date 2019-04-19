using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKDataViewer.Utilities
{
    public class CyberDictionary : SortedDictionary<string, string>
    {
        private object lockObject = new object();
        public CyberDictionary() : base()
        {

        }

        public void Add(string logItem, bool synchronized = false)
        {
            var l = logItem.Split(':');
            if (l.Length > 1)
            {
                string k = l[0];
                string v = l[1].Split(';')[0];
                if (synchronized)
                {
                    lock(lockObject)
                    {
                        Add(k, v);
                    }
                }
                else
                {
                    Add(k, v);
                }
            }
        }
    }
}
