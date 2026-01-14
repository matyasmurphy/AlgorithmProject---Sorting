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
            for (int i = 0; i < numbers.Length - 1; i++) // - 1 protoze posledni prvek, bych porovnaval sam se sebou
            {
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
        }

        public static void Run(string[] words)
        {

            for (int i = 0; i < words.Length - 1; i++)
            {

                int minIndex = i;
                for (int j = i + 1; j < words.Length; j++)
                {
                    // Porovnání řetězců (String Comparison)
                    // CompareTo vrati zaporne cislo, pokud je words[j] abededne pred words[minIndex]
                    if (words[j].CompareTo(words[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Prohozeni
                string temp = words[minIndex];
                words[minIndex] = words[i];
                words[i] = temp;
            }
        }
    }
}