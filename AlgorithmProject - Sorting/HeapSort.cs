using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AlgorithmProject___Sorting
{
    internal class HeapSort
    {
        public static void Run(int[] numbers)
        {
            int sortLength = numbers.Length;

            for (int i = numbers.Length / 2 - 1; i >= 0; i--) // ziskame index posledniho uzlu, ktery ma alespon jedno dite
            {
                Heapify(numbers, numbers.Length, i);
            }

            // uz vime ze nejvetsi cislo je na indexu 0
            for (int i = numbers.Length - 1; i > 0; i--) //zacina od konce, a postupne vymeni nejvetsi cisla s poslenim
            {
                // vymeni cislo na indexu 0 s poslednim
                int temp = numbers[0];
                numbers[0] = numbers[i];
                numbers[i] = temp;

                Heapify(numbers, i, 0); // zjistime nejvetsi cislo
            }
        }
        private static void Heapify(int[] arr, int n, int i)
        {
            int largest = i; // ocekavame ze i je nejvetsi cislo
            int left = 2 * i + 1; // najdi index leveho ditete
            int right = 2 * i + 2; // najdi index praveho ditete

            if (left < n && arr[left] > arr[largest])    // je leve dite vetsi nez i a existuje
            {
                largest = left; // nastav jako nejvetsi
            }

            if (right < n && arr[right] > arr[largest]) // je prave dite vetsi nez i a existuje
            {
                largest = right; // nastav jako nejvetsi
            }

            if (largest != i) // pokud i neni nejvetsi, tak vymen je
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest); // zkontrolujeme jestli i nema jit jeste vic dolu
            }
        }

        public static void Run(string[] words)
        {
            int sortLength = words.Length;

            for (int i = words.Length / 2 - 1; i >= 0; i--)
            {
                Heapify(words, words.Length, i);
            }

            for (int i = words.Length - 1; i > 0; i--)
            {
                string temp = words[0];
                words[0] = words[i];
                words[i] = temp;

                Heapify(words, i, 0);
            }
        }

        private static void Heapify(string[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left].CompareTo(arr[largest]) > 0) // pokud je vetsi vrati 1
            {
                largest = left;
            }

            if (right < n && arr[right].CompareTo(arr[largest]) > 0)
            {
                largest = right;
            }

            if (largest != i)
            {
                string swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                Heapify(arr, n, largest);
            }
        }
    }
}
