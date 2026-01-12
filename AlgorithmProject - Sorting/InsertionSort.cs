using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject___Sorting
{
    internal class InsertionSort
    {
        public static void Run(int[] numbers)
        {
            Console.WriteLine($"--- Starting Insertion Sort for {numbers.Length} numbers ---");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long timeLimitMs = 3600000;
            bool isFinished = true;

            for (int i = 1; i < numbers.Length; i++)
            {
                if (stopwatch.ElapsedMilliseconds > timeLimitMs)
                {
                    stopwatch.Stop();
                    isFinished = false;

                    double percentage = ((double)i / numbers.Length) * 100;

                    Console.WriteLine("\n!!! TIME LIMIT EXCEEDED !!!");
                    Console.WriteLine($"Progress: {percentage:F4} % sorted.");
                    break;
                }
                int compareNum = numbers[i];
                int j = i - 1; // aby zacal porovnavat po vybranem cisle

                while (j >= 0 && compareNum < numbers[j])
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = compareNum;
            }

            if (isFinished)
            {
                stopwatch.Stop();
                Console.WriteLine($"\nDONE! Time: {stopwatch.Elapsed}");
            }
        }

        public static void Run(string[] words)
        {
            Console.WriteLine($"--- Starting Insertion Sort for {words.Length} words ---");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long timeLimitMs = 3600000;
            bool isFinished = true;

            for (int i = 1; i < words.Length; i++)
            {
                if (stopwatch.ElapsedMilliseconds > timeLimitMs)
                {
                    stopwatch.Stop();
                    isFinished = false;

                    double percentage = ((double)i / words.Length) * 100;

                    Console.WriteLine("\n!!! TIME LIMIT EXCEEDED !!!");
                    Console.WriteLine($"Progress: {percentage:F4} % sorted.");
                    break;
                }
                string compareWord = words[i];
                int j = i - 1; // aby zacal porovnavat po vybranem cisle

                while (j >= 0 && words[j].CompareTo(compareWord) > 0)
                {
                    words[j + 1] = words[j];
                    j--;
                }

                words[j + 1] = compareWord;
            }

            if (isFinished)
            {
                stopwatch.Stop();
                Console.WriteLine($"\nDONE! Time: {stopwatch.Elapsed}");
            }
        }
    }
}
