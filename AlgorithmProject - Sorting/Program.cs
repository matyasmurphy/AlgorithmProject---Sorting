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
                    Console.WriteLine("Generating 5000 random words...");
                    stringData = GenerateRandomStrings(5000);
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
                    Console.WriteLine("Generating 20,000 random numbers...");
                    numberData = GenerateRandomNumbers(20000);
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
                Console.WriteLine("2 - Bubble Sort (not implemented)");
                Console.WriteLine("0 - End program");
                Console.Write("Enter number: ");

                string index2 = Console.ReadLine();

                switch (index2)
                {
                    case "1":
                        if (isWorkingWithNumbers)
                        {
                            // Vytvoříme kopii, abychom neseřadili originál (pro další testy)
                            int[] dataClone = (int[])numberData.Clone();
                            SelectionSort.Run(dataClone);
                        }
                        else
                        {
                            // Vytvoříme kopii textových dat
                            string[] dataClone = (string[])stringData.Clone();
                            SelectionSort.Run(dataClone);
                        }
                        break;

                    case "2":
                        // BubbleSort.Run(dataProTest);
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
                Console.Clear(); // Vyčistí konzoli, aby to vypadalo hezky
            }
        }

        // Pomocná metoda pro generování čísel
        static int[] GenerateRandomNumbers(int amount)
        {
            Random random = new Random();
            int[] array = new int[amount];
            for (int i = 0; i < amount; i++)
            {
                array[i] = random.Next(1, 1000000); // Náhodná čísla od 1 do milionu
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
            // List je "nafukovací" pole, protože nevíme přesně, kolik řádků soubor má
            List<int> loadedNumbers = new List<int>();

            Console.WriteLine($"Loading File: {filePath} ...");

            // Kontrola, zda soubor existuje
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Error: File doesnt exist");
                return new int[0]; // Vrátíme prázdné pole
            }

            try
            {
                // StreamReader je nejrychlejší způsob čtení velkých souborů
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string row;
                    // Čteme dokud nenarazíme na konec souboru
                    while ((row = sr.ReadLine()) != null)
                    {
                        // Zkusíme převést text na číslo
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
            return loadedNumbers.ToArray(); // Převedeme List zpět na klasické pole int[]
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
