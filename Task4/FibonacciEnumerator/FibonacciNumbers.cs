using System;
using System.Collections.Generic;

namespace FibonacciEnumerator
{
    public class FibonacciNumbers
    {
        public static IEnumerable<long> GetNumbers(long count)
        {
            if (count <= 0) yield break;
             
            yield return 1;

            long first = 0, second = 1;
            for (int i = 0; i < count - 1; i++)
            {
                long nextNumber;
                try
                {
                    nextNumber = checked(first + second);
                }
                catch (OverflowException e)
                {
                    string message = "Can't calculate more than " + (i + 1);
                    throw new OverflowException(message, e); //or maybe: yield break;
                }
                
                first = second;
                second = nextNumber;
                yield return nextNumber;
            }

        }
    }
}
