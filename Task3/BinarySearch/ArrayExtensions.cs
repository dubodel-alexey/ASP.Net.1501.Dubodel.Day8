﻿using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetArray">
        ///     Sorted array
        /// </param>
        /// <param name="value">
        ///     Value, yoy want to find in targetArray
        /// </param>
        /// <param name="comparison">
        ///     function, that compare two values of type T. 
        ///     Should return 1, if first param > second one;
        ///     Returns -1, if  second > first;
        ///     Returns 0, if equals.
        /// </param>
        /// <returns>
        ///     Index in targetArray if found, othrwise -1.
        /// </returns>
        public static int BinarySearch<T>(this T[] targetArray, T value, Func<T, T, int> comparison)
        {
            if (targetArray == null)
            {
                throw new ArgumentNullException("targetArray");
            }
            if (comparison == null)
            {
                if (value is IComparable)
                {
                    comparison = Comparer<T>.Default.Compare;
                }
                else
                {
                    throw new ArgumentNullException("comparison");
                }
            }

            int leftBorder = 0;
            int rightBorder = targetArray.Length - 1;

            while (leftBorder <= rightBorder)
            {
                int middlePosition = (leftBorder + rightBorder)/2;
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetArray">
        ///     Sorted array
        /// </param>
        /// <param name="value">
        ///     Value, yoy want to find in targetArray
        /// </param>
        /// <param name="comparer">
        ///     Object, that implements IComparer<T>. 
        ///     Compare method should return 1, if first param > second one;
        ///     Returns -1, if  second > first;
        ///     Returns 0, if equals.
        /// </param>
        /// <returns>
        ///     Index in targetArray if found, othrwise -1.
        /// </returns>
        public static int BinarySearch<T>(this T[] targetArray, T value, IComparer<T> comparer)
        {
            if (targetArray == null)
            {
                throw new ArgumentNullException("targetArray");
            }
            if (comparer == null)
            {
                if (value is IComparable)
                {
                    Func<T, T, int> comparison = Comparer<T>.Default.Compare;
                    return targetArray.BinarySearch(value, comparison);
                }
                throw new ArgumentNullException("comparer");
            }
            return targetArray.BinarySearch(value, comparer.Compare);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Should implements IComparable</typeparam>
        /// <param name="targetArray">
        ///     Sorted array
        /// </param>
        /// <param name="value">
        ///     Value, yoy want to find in targetArray
        /// </param>
        /// <returns>
        ///     Index in targetArray if found, othrwise -1.
        /// </returns>
        public static int BinarySearch<T>(this T[] targetArray, T value)
        {
            if (targetArray == null)
            {
                throw new ArgumentNullException("targetArray");
            }
            if (value is IComparable)
            {
                Func<T, T, int> comparison = Comparer<T>.Default.Compare;
                return targetArray.BinarySearch(value, comparison);
            }

            string message = String.Format("Can't compare values of type {0}", typeof(T));
            throw new ArgumentException(message);
        }
    }
}