using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKDataToolbox.Utilities
{
    public class CyberDictionary : SortedDictionary<string, string>
    {
        private object lockObject = new object();
        public CyberDictionary() : base()
        {

        }

        public void Add(string key, string value, bool synchronized = false)
        {
            if (synchronized)
            {
                lock(lockObject)
                {
                    base.Add(key, value);
                }
            }
            else
            {
                base.Add(key, value);
            }
    }
    }
}
