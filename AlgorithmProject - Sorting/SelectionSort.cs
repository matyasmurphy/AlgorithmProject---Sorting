using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject___Sorting
{
    internal class SelectionSort
    {
        public static void Run(int[] numbers)
        {
            Console.WriteLine($"--- Starting Selection Sort for {numbers.Length} numbers ---");

            Stopwatch stopky = new Stopwatch();
            stopky.Start();

            long timeLimitMs = 3600000; //1h
            bool finished = true;

            for (int i = 0; i < numbers.Length - 1; i++) // - 1 protoze posledni prvek, bych porovnaval sam se sebou
            {
                // --- KONTROLA ČASU ---
                if (stopky.ElapsedMilliseconds > timeLimitMs)
                {
                    stopky.Stop();
                    finished = false;

                    // Výpočet procent
                    double procenta = ((double)i / numbers.Length) * 100;

                    Console.WriteLine("\n!!! TIME LIMIT EXPIRED !!!");
                    Console.WriteLine($"Algorithm sorted: {procenta:F2} % of the array.");
                    break; // Vyskočíme z cyklu ven
                }
                // ---------------------

                int minIndex = i;

                for (int j = i + 1; j < numbers.Length; j++) // j = i + 1 - aby nezacal nazacatku a neporovnaval se sam se 
                {
                    if (numbers[j] < numbers[minIndex])
                    {
                        minIndex = j; //pozice minima
                    }
                }

                //prohodit promene
                int temp = numbers[i];

                numbers[i] = numbers[minIndex]; //nastavi hodnotu, kterou prave kontrolujeme s nejmensim cislem
                numbers[minIndex] = temp;
            }

            if (finished)
            {
                stopky.Stop();
                Console.WriteLine($"Time elapsed: {stopky.Elapsed}");
                // Vypsat pole, pokud je hodnot do 100
                if (numbers.Length <= 100) PrintArray(numbers, "Sorted:");
            }
        }

        // ... (zde končí tvá metoda Run pro int[] numbers) ...

        // --- NOVÁ METODA PRO TEXT ---
        public static void Run(string[] words)
        {
            Console.WriteLine($"--- Starting Selection Sort for {words.Length} words ---");

            if (words.Length <= 100) PrintArray(words, "Original: ");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long timeLimitMs = 3600000; // Limit 5 sekund (nastav si dle potřeby)
            bool isFinished = true;
            int n = words.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // --- KONTROLA ČASU (TIME CHECK) ---
                if (stopwatch.ElapsedMilliseconds > timeLimitMs)
                {
                    stopwatch.Stop();
                    isFinished = false;
                    double percentage = ((double)i / n) * 100;

                    Console.WriteLine("\n!!! TIME LIMIT EXCEEDED !!!");
                    Console.WriteLine($"Progress: {percentage:F4} % sorted.");
                    break;
                }

                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    // Porovnání řetězců (String Comparison)
                    // CompareTo vrátí záporné číslo, pokud je words[j] abecedně před words[minIndex]
                    if (words[j].CompareTo(words[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Prohození (Swap)
                string temp = words[minIndex];
                words[minIndex] = words[i];
                words[i] = temp;
            }

            if (isFinished)
            {
                stopwatch.Stop();
                Console.WriteLine($"\nDONE! Time: {stopwatch.Elapsed}");
                if (words.Length <= 100) PrintArray(words, "Sorted:   ");
            }
        }

        private static void PrintArray(int[] data, string label)
        {
            Console.Write(label);
            foreach (var item in data) Console.Write(item + " ");
            Console.WriteLine();
        }

        private static void PrintArray(string[] data, string label)
        {
            Console.Write(label);
            foreach (var item in data) Console.Write(item + ", ");
            Console.WriteLine();
        }
    }
}