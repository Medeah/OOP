using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l8
{
    class SortedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        private List<T> data = new List<T>();

        public T this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public static SortedList<T> operator +(SortedList<T> left, T item)
        {
            left.Add(item);
            return left;
        }

        public static SortedList<T> operator -(SortedList<T> left, T item)
        {
            left.Remove(item);
            return left;
        }

        public void Add(T item)
        {
            int index = this.data.FindIndex(x => x.CompareTo(item) > 0);
            if (index == -1)
            {
                index = data.Count;
            }
            data.Insert(index, item);
        }

        public void Clear()
        {
            data.Clear();
        }

        public bool Contains(T item)
        {
            return data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get{ return data.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            return data.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        // Exercises says it must return a enumerator, but it is used like a enumarable
        public IEnumerable<T> GetElementsReversed()
        {
            for (int i = data.Count -1; i >= 0; i--)
            {
                yield return data[i];
            }
        }

        public IEnumerable<T> GetElements(Predicate<T> fn)
        {
            foreach (var item in data)
            {
                if (fn(item))
                {
                    yield return item;
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
