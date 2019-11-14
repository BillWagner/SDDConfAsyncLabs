using System;
using System.Collections.Generic;
using System.Linq;

namespace iterators
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (int square in PerfectSquares())
                Console.WriteLine(square);

            foreach (char ch in Letters())
                Console.Write(ch);
            Console.WriteLine();

            foreach (var result in ComputeSquares(Enumerable.Range(1, 50)))
                Console.WriteLine(result);

            foreach (char ch in Sample(Letters()))
                Console.Write(ch);
            Console.WriteLine();

            foreach (char ch in RepeatItems(Letters()))
                Console.Write(ch);
            Console.WriteLine();

        }

        public static IEnumerable<int> PerfectSquares()
        {
            yield return 1;
            yield return 4;
            yield return 9;
            yield return 16;
            yield return 25;

        }

        public static IEnumerable<int> ComputeSquares(IEnumerable<int> inputSequence)
        {
            foreach (var item in inputSequence)
                yield return item * item;
        }

        public static IEnumerable<char> Letters()
        {
            for (char c = 'a'; c < '{'; c++)
                yield return c;

            for (char c = 'A'; c < '['; c++)
                yield return c;
        }

        public static IEnumerable<T> Sample<T>(IEnumerable<T> inputSequence)
        {
            int index = 0;
            foreach(var item in inputSequence)
            {
                if (index++ % 5 == 0)
                    yield return item;
            }
        }
        public static IEnumerable<T> RepeatItems<T>(IEnumerable<T> inputSequence)
        {
            foreach (var item in inputSequence)
            {
                for (int i = 0; i < 5; i++)
                    yield return item;
            }
        }

    }
}
