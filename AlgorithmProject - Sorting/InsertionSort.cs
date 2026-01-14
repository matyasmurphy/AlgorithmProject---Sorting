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
            for (int i = 1; i < numbers.Length; i++)
            {
                int compareNum = numbers[i];
                int j = i - 1; // aby zacal porovnavat po vybranem cisle

                while (j >= 0 && compareNum < numbers[j])
                {
                    numbers[j + 1] = numbers[j];
                    j--;
                }

                numbers[j + 1] = compareNum;
            }
        }

        public static void Run(string[] words)
        {
            for (int i = 1; i < words.Length; i++)
            {
                string compareWord = words[i];
                int j = i - 1; // aby zacal porovnavat po vybranem cisle

                while (j >= 0 && words[j].CompareTo(compareWord) > 0)
                {
                    words[j + 1] = words[j];
                    j--;
                }

                words[j + 1] = compareWord;
            }
        }
    }
}
