using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmProject___Sorting
{
    internal class BubbleSort
    {
        public static void Run(int[] numbers)
        {
            Console.WriteLine($"--- Starting Bubble Sort for {numbers.Length} numbers ---");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long timeLimitMs = 3600000;
            bool isFinished = true;

            for (int i = 0; i < numbers.Length - 1; i++)
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
                for (int j = 0; j < numbers.Length - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int tempNum = numbers[j];

                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = tempNum;
                    }
                }
            }

            if (isFinished)
            {
                stopwatch.Stop();
                Console.WriteLine($"\nDONE! Time: {stopwatch.Elapsed}");
            }
        }

        public static void Run(string[] words)
        {
            Console.WriteLine($"--- Starting Bubble Sort for {words.Length} numbers ---");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long timeLimitMs = 3600000;
            bool isFinished = true;

            for (int i = 0; i < words.Length - 1; i++)
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
                for (int j = 0; j < words.Length - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        string tempWord = words[j];

                        words[j] = words[j + 1];
                        words[j + 1] = tempWord;
                    }
                }
            }

            if (isFinished)
            {
                stopwatch.Stop();
                Console.WriteLine($"\nDONE! Time: {stopwatch.Elapsed}");
            }
        }
    }
}
