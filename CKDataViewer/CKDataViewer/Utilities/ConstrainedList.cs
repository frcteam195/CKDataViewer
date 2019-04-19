using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CKDataViewer.Utilities
{
    public class ConstrainedList<T> : Queue<T>
    {

        private readonly int mMaxSize;
        public T LatestValue { get; private set; }
        public ConstrainedList(int maxSize) : base()
        {
            mMaxSize = maxSize;
        }

        public new void Enqueue(T item)
        {
            while (Count > mMaxSize)
            {
                Dequeue();
            }

            base.Enqueue(item);
            LatestValue = item;
        }
    }
}
