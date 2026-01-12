using System;
using System.Diagnostics;

using System.IO;
using System.Collections.Generic;

namespace AlgorithmProject___Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numberData = null;
            string[] stringData = null;
            bool isWorkingWithNumbers = true;

            Console.WriteLine("=== SELECT DATA TYPE ===");
            Console.WriteLine("1 - Integers (Numbers)");
            Console.WriteLine("2 - Strings (Text)");
            Console.Write("Enter number: ");
            string index = Console.ReadLine();

            if (index == "2")
            {
                isWorkingWithNumbers = false;

                Console.WriteLine("\nData");
                Console.WriteLine("1 - Generate random words");
                Console.WriteLine("2 - Load from file (for 10M strings)");
                Console.Write("Choice: ");
                string source = Console.ReadLine();

                if (source == "2")
                {
                    string path = "C:\\Users\\Murphy Matyáš Josef\\OneDrive - DELTA - SŠIE, s.r.o\\Plocha\\Data pro třídění\\random_words_10M.txt"; // Odstranění uvozovek z cesty
                    stringData = LoadStringsFromFile(path);
                }
                else
                {
                    Console.WriteLine("Generating 5 random words...");
                    stringData = GenerateRandomStrings(5);
                }
            }
            else // Defaultně čísla
            {
                // --- PŘÍPRAVA ČÍSELNÝCH DAT ---
                isWorkingWithNumbers = true;
                Console.WriteLine("\nData");
                Console.WriteLine("1 - Generate random numbers");
                Console.WriteLine("2 - Load from file (for 10M numbers)");
                Console.Write("Choice: ");
                string source = Console.ReadLine();

                if (source == "2")
                {
                    string path = "C:\\Users\\Murphy Matyáš Josef\\OneDrive - DELTA - SŠIE, s.r.o\\Plocha\\Data pro třídění\\random_integers_10M.txt";
                    numberData = LoadNumbersFromFile(path);
                }
                else
                {
                    Console.WriteLine("Generating 5 random numbers...");
                    numberData = GenerateRandomNumbers(5);
                }
            }

            // Kontrola, zda se data načetla správně
            if ((isWorkingWithNumbers && (numberData == null || numberData.Length == 0)) ||
                (!isWorkingWithNumbers && (stringData == null || stringData.Length == 0)))
            {
                Console.WriteLine("No data available. Exiting.");
                return;
            }

            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("============================");
                Console.WriteLine("   PROJEKT TRIZENI - MENU   ");
                Console.WriteLine("============================");
                Console.WriteLine("1 - Selection Sort");
                Console.WriteLine("2 - Bubble Sort");
                Console.WriteLine("3 - Insertion Sort");
                Console.WriteLine("0 - End program");
                Console.Write("Enter number: ");

                string index2 = Console.ReadLine();

                switch (index2)
                {
                    case "1":
                        if (isWorkingWithNumbers)
                        {
                            int[] dataClone = (int[])numberData.Clone();
                            SelectionSort.Run(dataClone);
                        }
                        else
                        {
                            string[] dataClone = (string[])stringData.Clone();
                            SelectionSort.Run(dataClone);
                        }
                        break;

                    case "2":
                        if (isWorkingWithNumbers)
                        {
                            int[] dataClone = (int[])numberData.Clone();
                            BubbleSort.Run(dataClone);
                        }
                        else
                        {
                            string[] dataClone = (string[])stringData.Clone();
                            BubbleSort.Run(dataClone);
                        }
                        break;

                    case "3":
                        if (isWorkingWithNumbers)
                        {
                            int[] dataClone = (int[])numberData.Clone();
                            InsertionSort.Run(dataClone);
                        }
                        else
                        {
                            string[] dataClone = (string[])stringData.Clone();
                            InsertionSort.Run(dataClone);
                        }
                        break;

                    case "0":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Error, try again.");
                        break;
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static int[] GenerateRandomNumbers(int amount)
        {
            Random random = new Random();
            int[] array = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                array[i] = random.Next(1, 101);
            }
            return array;
        }

        static string[] GenerateRandomStrings(int count)
        {
            Random rnd = new Random();
            string[] data = new string[count];
            string chars = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < count; i++)
            {
                int length = rnd.Next(4, 10);
                char[] word = new char[length];
                for (int j = 0; j < length; j++)
                {
                    word[j] = chars[rnd.Next(chars.Length)];
                }
                data[i] = new string(word);
            }
            return data;
        }

        static int[] LoadNumbersFromFile(string filePath)
        {
            List<int> loadedNumbers = new List<int>();

            Console.WriteLine($"Loading File: {filePath} ...");

            if (!File.Exists(filePath)) // kontrola jestli soubor existuje
            {
                Console.WriteLine("Error: File doesnt exist");
                return new int[0]; // pokud ne vratime prazdne pole
            }

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string row;
                    // cte dokud nenarazi na konec souboru
                    while ((row = sr.ReadLine()) != null)
                    {
                        // text na číslo
                        if (int.TryParse(row, out int cislo))
                        {
                            loadedNumbers.Add(cislo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A error occurred during reading: {ex.Message}");
            }

            Console.WriteLine($"Successfully loaded {loadedNumbers.Count} numbers.");
            return loadedNumbers.ToArray(); // prevedeme List na pole int[]
        }

        static string[] LoadStringsFromFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Error: File not found.");
                return new string[0];
            }

            Console.WriteLine("Loading data...");
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                return new string[0];
            }
        }
    }
}
