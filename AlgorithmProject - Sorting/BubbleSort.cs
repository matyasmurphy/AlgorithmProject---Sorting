using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject___Sorting
{
    internal class BubbleSort
    {
        public static void Run(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
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
        }

        public static void Run(string[] words)
        {
            for (int i = 0; i < words.Length - 1; i++)
            {
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
        }
    }
}
