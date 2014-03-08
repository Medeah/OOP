using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    class MyFlexibleOrderedQueue<T> : MyQueue<T>
    {
        private MyComparer<T> comparer;
        public MyFlexibleOrderedQueue(int size, MyComparer<T> com)
            : base(size)
        {
            this.comparer = com;
        }

        public override void Enqueue(T item)
        {
            if (this.IsFull)
            {
                throw new QueueFullException("Der er ikke plads til flere");
            }

            int i = head;

            while (i != end && (comparer.Compare(item, data[i]) > 0))
            {
                i = (i + 1) % this.data.Length;
            }


            for (int j = end; j != i; j = j == 0 ? this.data.Length - 1 : j - 1)
            {
                int index = j == 0 ? this.data.Length - 1 : j - 1;
                this.data[j] = this.data[index];
            }

            this.data[i] = item;
            end = (end + 1) % data.Length;
            elems++;
        }
    }
}
