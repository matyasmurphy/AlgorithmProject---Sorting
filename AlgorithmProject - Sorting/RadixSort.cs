using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject___Sorting
{
    internal class RadixSort
    {
        public static void Run(int[] numbers)
        {
            if (numbers.Length == 0) return;
            int max = numbers.Max(); // nejvetsi hodnota v arraye

            List<int>[] buckets = new List<int>[10];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int placeValue = 1; max / placeValue > 0; placeValue *= 10) // zajisti, ze zpracujeme kazdou pozici cislice, dokud nam cislice nedojdou
            {
                foreach (int num in numbers) //rozdeli cisla do prislusneho oddilu
                {
                    int digit = (num / placeValue) % 10;
                    buckets[digit].Add(num);
                }

                int index = 0;
                for (int i = 0; i < 10; i++) //navstevujeme postupne oddily v poradni od 0 do 9 a pridame do puvodniho arraye
                {
                    foreach (int num in buckets[i])
                    {
                        numbers[index++] = num; //index++ - pouzi aktualni index a zvis pro dalsi
                    }

                    buckets[i].Clear(); // vymaze data v listu aby jsme ho mohli zas pouzivat
                }
            }
        }

        public static void Run(string[] words)
        {
            if (words.Length == 0) return;

            int maxLength = words.Max(s => s.Length);

            List<string>[] buckets = new List<string>[256];

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new List<string>();
            }

            for (int charIndex = maxLength - 1; charIndex >= 0; charIndex--) // zajistuje, ze zpracujeme kazdou pozici pismen, ale postupujeme pozadu
            {
                foreach (string word in words) // rozdeli cisla do prislusneho oddilu
                {
                    int charCode;
                    if (charIndex < word.Length) //pokud je slovo dostatecne dlouhe, tak ho pridej do prislusneho oddilu
                        charCode = word[charIndex];
                    else
                        charCode = 0; //pokud ne, dej ho na zacatek

                    buckets[charCode].Add(word);
                }

                int index = 0;
                for (int i = 0; i < buckets.Length; i++) //navstevujeme postupne oddily v poradni a pridame do puvodniho arraye
                {
                    foreach (string word in buckets[i])
                    {
                        words[index++] = word;
                    }
                    buckets[i].Clear();
                }
            }
        }
    }
}
