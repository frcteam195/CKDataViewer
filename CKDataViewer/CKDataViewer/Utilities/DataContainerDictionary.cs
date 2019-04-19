using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CKDataViewer.Utilities
{
    public class DataContainerDictionary : SortedDictionary<string, ConstrainedList<string>>
    {
        public event EventHandler ItemAdded;
        protected virtual void OnItemAdded(DataItemEventArgs e)
        {
            EventHandler handler = ItemAdded;
            handler?.Invoke(this, e);
        }

        public event EventHandler ItemRemoved;
        protected virtual void OnItemRemoved(DataItemEventArgs e)
        {
            EventHandler handler = ItemRemoved;
            handler?.Invoke(this, e);
        }

        public readonly int MaxNumValues;

        public DataContainerDictionary(int maxValues) : base()
        {
            MaxNumValues = maxValues;
        }

        public void Add(CyberDictionary data, bool resync = false)
        {
            object lockObject = new object();
            Parallel.ForEach(data, (d) =>
            {
                lock(lockObject)
                {
                    Add(d.Key, d.Value);
                }
            });

            if (resync)
            {
                SyncDictionaries(data);
            }
        }

        public void Add(string key, string value)
        {
            if (ContainsKey(key))
            {
                ConstrainedList<string> refVal;
                if (TryGetValue(key, out refVal))
                {
                    refVal.Enqueue(value);
                }
            }
            else
            {
                ConstrainedList<string> cl = new ConstrainedList<string>(MaxNumValues);
                cl.Enqueue(value);
                Add(key, cl);
            }
        }

        public new void Add(string key, ConstrainedList<string> value)
        {
            base.Add(key, value);
            OnItemAdded(new DataItemEventArgs(key, value.Peek()));
        }

        public new void Remove(string key)
        {
            base.Remove(key);
            OnItemRemoved(DataItemEventArgs.Empty);
        }

        public void SyncDictionaries(CyberDictionary referenceList)
        {
            var removeKeys = Keys.Where((k) => !referenceList.ContainsKey(k));
            foreach (var k in removeKeys)
            {
                Remove(k);
            }
        }
    }
}
