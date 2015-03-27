using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    public static class Extensions
    {
        public static IEnumerable<T> GetElement<T>(this IEnumerable<T> list, Func<T, bool> filter)
        {
            foreach (var element in list)
            {
                if (filter(element))
                    yield return element;
            }
        }
    }

    public class CustomList<T> : ICollection<T>
    {
        private T[] array;

        CustomList() : this(new T[1]) { }

        public CustomList(params T[] data)
        {
            array = (T[])data.Clone();
            Count = array.Length;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in array)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            if (Count >= Capacity)
            {
                var tempArray = new T[array.Length * 2];
                Array.Copy(array, tempArray, array.Length);
                array = tempArray;
            }

            array[Count] = item;
            Count++;
        }

        public void Clear()
        {
            array = new T[1];
            Count = 0;
        }

        public bool Contains(T item)
        {
            return array.Contains(item);
        }

        public void CopyTo(T[] destinationArray, int destinatioArrayIndex)
        {
            Array.Copy(array, 0, destinationArray, destinatioArrayIndex, Count);
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(array, item);
            if (index < 0)
            {
                return false;
            }

            array = array.Where((val, idx) => idx != index).ToArray();
            Count--;

            return true;

        }

        public int Count { get; private set; }

        public int Capacity
        {
            get { return array.Length; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }
    }
}
