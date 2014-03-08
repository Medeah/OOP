using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l5
{
    public class MyQueue<T>
    {
        protected T[] data;
        protected int head = 0; // foreste plads i køen
        protected int end = 0; // første tomme plads bagers i køen
        protected int elems = 0;
        public T Head
        {
            get
            {
                if (this.IsEmpty)
                {
                    throw new QueueException("den er tom");
                }
                return data[head];
            }
            set
            {
                data[head] = value;
            }
        }
        public T Tail
        {
            get
            {
                if (this.IsEmpty)
                {
                    throw new QueueException("den er tom");
                }
                int index = end == 0 ? data.Length - 1 : end - 1;
                return data[index];
            }
            set
            {
                int index = end == 0 ? data.Length - 1 : end - 1;
                data[index] = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return elems == 0;
            }
        }
        public bool IsFull
        {
            get
            {
                return elems == data.Length;
            }
        }


        public MyQueue(int size)
        {
            data = new T[size];
        }

        public virtual void Enqueue(T item)
        {
            if (this.IsFull)
            {
                throw new QueueFullException("Der er ikke plads til flere");
            }
            data[end] = item;
            end = (end + 1) % data.Length;
            elems++;
        }
        public T Dequeue()
        {
            if (this.IsEmpty)
            {
                throw new QueueException("Der er ikke flere elementer tilbage");
            }
            int index = head;
            head = (head + 1) % data.Length;
            elems--;
            return data[index];
        }



    }
}
