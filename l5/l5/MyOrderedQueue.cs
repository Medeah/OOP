using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    public class MyOrderedQueue<U> : MyQueue<U>
        where U : IComparable<U>
    {
        public MyOrderedQueue(int size) : base(size) { }

        public override void Enqueue(U item)
        {
            if (this.IsFull)
            {
                throw new QueueFullException("Der er ikke plads til flere");
            }

            int i = head;
            while (i != end && (item.CompareTo(this.data[i]) > 0))
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
