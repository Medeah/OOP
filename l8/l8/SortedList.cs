﻿using System;
using System.Collections.Generic;

namespace l8
{
    class SortedList<T> : ICollection<T>
        where T : IComparable<T>
    {
        private readonly List<T> _data = new List<T>();

        public T this[int index]
        {
            get
            {
                return _data[index];
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
            var index = _data.FindIndex(x => x.CompareTo(item) > 0);
            index = index == -1 ? _data.Count : index;
            _data.Insert(index, item);
        }

        public void Clear()
        {
            _data.Clear();
        }

        public bool Contains(T item)
        {
            return _data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get{ return _data.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(T item)
        {
            return _data.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _data)
            {
                yield return item;
            }
        }

        // Exercises says it must return a enumerator, but it is used like a enumarable
        public IEnumerable<T> GetElementsReversed()
        {
            for (int i = _data.Count -1; i >= 0; i--)
            {
                yield return _data[i];
            }
        }

        public IEnumerable<T> GetElements(Predicate<T> fn)
        {
            foreach (var item in _data)
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
