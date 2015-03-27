using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomQueue
{
    public class CustomQueue<T> : IEnumerable<T>
    {
        private T[] array;
        private int firstIndex;
        public int Count { get; private set; }
        public int Capacity { get { return array.Length; } }

        public CustomQueue()
        {
            array = new T[1];
            Count = 0;
            firstIndex = 0;
        }

        public void Enqueue(T item)
        {
            if (firstIndex + Count == Capacity)
            {
                if (firstIndex != 0)
                {
                    for (int i = 0; i < array.Count(); i++)
                    {
                        array[i] = array[firstIndex + i];
                    }
                }
                else
                {
                    var tempArray = new T[array.Length * 2];
                    Array.Copy(array, firstIndex, tempArray, 0, Count);
                    array = tempArray;
                }

                firstIndex = 0;
            }

            array[firstIndex + Count] = item;
            Count++;
        }

        public T Dequeue()
        {
            T result;

            try
            {
                result = Peek();
            }
            catch (EmptyQueueException)
            {
                throw new EmptyQueueException();
            }

            array[firstIndex] = default(T);
            Count--;
            firstIndex = (Count == 0) ? 0 : firstIndex + 1;

            return result;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new EmptyQueueException();
            }

            return array[firstIndex];
        }

        public void Clear()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default(T);
            }

            firstIndex = 0;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CustomEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class CustomEnumerator : IEnumerator<T>
        {
            private readonly CustomQueue<T> queue;
            private int currentIndex;

            public CustomEnumerator(CustomQueue<T> queue)
            {
                this.currentIndex = queue.firstIndex - 1;
                this.queue = queue;
            }

            public bool MoveNext()
            {
                return ++currentIndex < (queue.Count + queue.firstIndex);
            }

            public void Reset()
            {
                currentIndex = queue.firstIndex - 1;
            }

            public void Dispose()
            {

            }

            public T Current
            {
                get
                {
                    if (currentIndex == queue.firstIndex - 1 || currentIndex == queue.Count + queue.firstIndex)
                    {
                        throw new InvalidOperationException();
                    }

                    return queue.array[currentIndex];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }
    }
}
