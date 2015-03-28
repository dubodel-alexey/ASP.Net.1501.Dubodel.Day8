using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public static class ArrayExtensions
    {
        public static int BinarySearch<T>(this T[] targetArray, T value, Func<T, T, int> comparison)
        {
            if (comparison == null)
            {
                if (value is IComparable<T>)
                {
                    comparison = (T first, T second) => (first as IComparable<T>).CompareTo(second);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }

            int leftBorder = 0;
            int rightBorder = targetArray.Length - 1;

            while (leftBorder <= rightBorder)
            {
                int middlePosition = (leftBorder + rightBorder) / 2;
                int compareResult = comparison(value, targetArray[middlePosition]);

                if (compareResult > 0)
                {
                    leftBorder = middlePosition + 1;
                }
                else if (compareResult < 0)
                {
                    rightBorder = middlePosition - 1;
                }
                else
                {
                    return middlePosition;
                }
            }
            return -1;
        }

        public static int BinarySearch<T>(this T[] targetArray, T value, IComparer<T> comparer)
        {
            if (comparer == null)
            {
                if (value is IComparable<T>)
                {
                    Func<T, T, int> comparison = (T first, T second) => (first as IComparable<T>).CompareTo(second);
                    return targetArray.BinarySearch(value, comparison);
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            return targetArray.BinarySearch(value, comparer.Compare);
        }

        
        public static int BinarySearch<T>(this T[] targetArray, T value)
        {
            if (value is IComparable<T>)
            {
                Func<T, T, int> comparison = (T first, T second) => (first as IComparable<T>).CompareTo(second);
                return targetArray.BinarySearch(value, comparison);
            }
            throw new ArgumentException();
        }
    }
}
