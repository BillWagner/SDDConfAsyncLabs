using System;
using System.Collections.Generic;

namespace Iterators
{
    class Program
    {

        static void Main(string[] args)
        {
            foreach (var square in PerfectSquares())
                Console.WriteLine(square);

            foreach (char c in Sample(Letters()))
                Console.Write(c);
            Console.WriteLine();
        }

        private static IEnumerable<int> ComputeSquares(
            IEnumerable<int> numbers)
        {
            foreach (var value in numbers)
                yield return value * value;
        }

        private static IEnumerable<T> Sample<T>(
            IEnumerable<T> numbers)
        {
            var index = 0;
            foreach(var item in numbers)
            {
                if (index++ % 5 == 0)
                {
                    yield return item;
                }
            }
        }

        private static IEnumerable<T> RepeatItems<T>(IEnumerable<T> sequence)
        {
            foreach(var item in sequence)
            {
                for(int i = 0; i < 5; i++)
                {
                    yield return item;
                }
            }
        }
        private static IEnumerable<int> PerfectSquares()
        {
            yield return 1;
            yield return 4;
            yield return 9;
            yield return 16;
        }

        private static IEnumerable<char> Letters()
        {
            for (char c = 'a'; c < '{'; c++)
                yield return c;
            for (char c = 'A'; c < '['; c++)
                yield return c;
        }
    }
}
