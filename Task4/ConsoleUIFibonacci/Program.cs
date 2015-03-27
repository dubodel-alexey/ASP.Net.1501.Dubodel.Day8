using System;
using FibonacciEnumerator;

namespace ConsoleUIFibonacci
{
    class Program
    {
        static void Main()
        {
            int i = 0;
            foreach (var number in FibonacciNumbers.GetNumbers(92))
            {
                i++;
                Console.WriteLine("{0}: {1}", i, number);
            }
            Console.ReadKey();
        }
    }
}
