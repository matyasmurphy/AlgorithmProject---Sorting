using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject___Sorting
{
    internal class QuickSort
    {
        public static void Run(int[] numbers)
        {
            Sort(numbers, 0, numbers.Length - 1);
        }

        static void Sort(int[] numbers, int low, int high)
        {
            if (low < high) // checkne jestli mame vic nez jeden prvek ke trizeni
            {
                int pivotIndex = Partition(numbers, low, high); // vrati index pivotu

                Sort(numbers, low, pivotIndex - 1); // sortne podle pivotu prvky na levou stranu (mensi nez pivot)
                Sort(numbers, pivotIndex + 1, high); // sortne podle pivotu prvky na pravou stranu (vetsi nez pivot)
            }
        }

        static int Partition(int[] numbers, int low, int high)
        {
            int middle = (low + high) / 2; //prostredni index
            Swap(numbers, middle, high); // Schova pivot na konec pole
            int pivot = numbers[high]; // Ulozi hodnotu pivotu

            int i = (low - 1); // Hranice pro mensi cisla

            for (int j = low; j < high; j++) // Projde zbytek pole
            {
                if (numbers[j] < pivot) // Pokud je cislo mensi nez pivot
                {
                    i++;
                    Swap(numbers, i, j); // Presune ho do leve casti
                }
            }

            Swap(numbers, i + 1, high); // Vrati pivot na sve spravne misto mezi mensi a vetsi
            return i + 1; // vrati index, kde pivot skoncil
        }

        static void Swap(int[] numbers, int a, int b)
        {
            int temp = numbers[a];
            numbers[a] = numbers[b];
            numbers[b] = temp;
        }

        public static void Run(string[] words)
        {
            Sort(words, 0, words.Length - 1);
        }

        static void Sort(string[] words, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(words, low, high);
                Sort(words, low, pivotIndex - 1);
                Sort(words, pivotIndex + 1, high);
            }
        }

        static int Partition(string[] words, int low, int high)
        {
            int middle = (low + high) / 2;
            Swap(words, middle, high);
            string pivot = words[high];

            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (words[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(words, i, j);
                }
            }
            Swap(words, i + 1, high);
            return i + 1;
        }

        static void Swap(string[] words, int a, int b)
        {
            string temp = words[a];
            words[a] = words[b];
            words[b] = temp;
        }
    }
}
