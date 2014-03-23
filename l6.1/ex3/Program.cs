using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex3
{
    static class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>();
            Random r = new Random();

            for (int i = 1; i < 30; i++)
            {
                numbers.Add(r.Next(0, 100));
            }

            numbers.Filter(x => x % 2 == 0)
                .Map(x => x + 1)
                .QSorted()
                .MyForEach((x) => Console.WriteLine(x));


            List<int> num = new List<int>() { -1, -3};

            Console.WriteLine(num.MyMax());
            Console.ReadLine();
        }

        // 1
        public static void MyForEach<T>(this IEnumerable<T> source, Action<T> fn)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
                
            foreach (T element in source)
            {
                fn(element);
            }
        }

        //2
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> fn)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (T element in source)
            {
                if (fn(element))
                {
                    yield return element;
                }
            }
        }

        //3
        public static T MyMax<T>(this IEnumerable<T> source)
            where T : IComparable
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            T max;

            using (var enumerator = source.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    max = enumerator.Current;
                }
                else
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
            }

            foreach (T element in source) {
                if (element.CompareTo(max) > 0)
                {
                    max = element;
                }
            }

            return max;

        }

        //4
        public static IEnumerable<U> Map<T, U>(this IEnumerable<T> source, Func<T, U> fn)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (T element in source)
            {
                yield return fn(element);
            }
        }

        //5
        // Selection sort
        public static IEnumerable<T> Sorted<T>(this IEnumerable<T> source)
            where T : IComparable
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var list = source.ToList();
            for (int i = 0; list.Count > 0; i++)
            {
                T min = list[0];
                foreach (T element in list)
                {
                    if (element.CompareTo(min) < 0)
                    {
                        min = element;
                    }
                }
                list.Remove(min);
                yield return min;
            }
        }


        // http://en.wikipedia.org/wiki/Quicksort#In-place_version
        public static IEnumerable<T> QSorted<T>(this IEnumerable<T> source)
            where T : IComparable
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var list = source.ToArray();
            Quicksort(list, 0, list.Length - 1);

            foreach (var element in list)
            {
                yield return element;
            }

        }

        private static void Quicksort<T>(T[] array, int left, int right)
            where T : IComparable
        {
            if (left < right)
            {
                int pivotIndex = new Random().Next(left, right + 1);
                int pivotNewIndex = Partition(array, left, right, pivotIndex);
                Quicksort(array, left, pivotNewIndex - 1);
                Quicksort(array, pivotNewIndex + 1, right);
            }
        }

        private static int Partition<T>(T[] array, int left, int right, int pivotIndex)
            where T : IComparable
        {
            T pivotValue = array[pivotIndex];

            T temp = array[pivotIndex];
            array[pivotIndex] = array[right];
            array[right] = temp;

            int storeIndex = left;
            for (int i = left; i < right; i++)
			{
			    if (array[i].CompareTo(pivotValue) <= 0)
	            {
		            temp = array[i];
                    array[i] = array[storeIndex];
                    array[storeIndex] = temp;

                    storeIndex++;
	            }
			}

            temp = array[right];
            array[right] = array[storeIndex];
            array[storeIndex] = temp;
            return storeIndex;
        }

        public static IEnumerable<U> FlatMap<T, U>(this IEnumerable<T> source, Func<T, IEnumerable<U>> fn)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (T enumerable in source)
            {
                foreach (U element in fn(enumerable))
                {
                    yield return element;
                }
            }
        }


        public static T Reduce<T>(this IEnumerable<T> source, Func<T, T, T> fn)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            T folded;
            using (var enumerator = source.GetEnumerator())
            {
                if (!enumerator.MoveNext())
                {
                    throw new InvalidOperationException("Sequence contains no elements");
                }
                folded = enumerator.Current;
            }

            foreach (var element in source.Skip(1))
            {
                folded = fn(folded, element);
            }

            return folded;
        }

        public static U Fold<T, U>(this IEnumerable<T> source, U init, Func<U, T, U> fn)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            foreach (var element in source)
            {
                init = fn(init, element);
            }

            return init;
        }

        // TODO: test sorting, tid
        // insetion sort
    }
}
