using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmProject___Sorting
{
    internal class MergeSort
    {
        public static void Run(int[] numbers)
        {
            if (numbers == null || numbers.Length <= 1)
                return;

            int[] temp = new int[numbers.Length];

            SortRecursive(numbers, temp, 0, numbers.Length - 1);
        }

        private static void SortRecursive(int[] numbers, int[] temp, int left, int right)
        {
            if (left >= right) return;  //pokud je 1 nebo min prvku v arrayi

            int mid = (left + right) / 2;  // najde stredni index, aby mohl rozpulit array

            SortRecursive(numbers, temp, left, mid);      // rozpuli levou stranu
            SortRecursive(numbers, temp, mid + 1, right);  // rozpuli pravou stranu

            Merge(numbers, temp, left, mid, right);       // mergne vse
        }

        static void Merge(int[] numbers, int[] temp, int left, int mid, int right)
        {
            //Pointry
            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (numbers[i] <= numbers[j]) // je ten vlevo mensi nebo stejny?
                {
                    // levy je mensi
                    // vezme cislo zleva a zapise ho do temp arraye na pozici k
                    temp[k] = numbers[i];
                    i++; // pricteme 1 k i, abychom priste porovnavali dalsi cislo v rade
                }
                else
                {
                    temp[k] = numbers[j];
                    j++;
                }
                k++; //posuneme index pro temp pole
            }

            // Pokud hlavni loop skoncil, protoze dosla prava strana
            // znamena to, ze v leve casti jeste zbyla cisla
            // Ta cisla uz jsou serazena, takze je jen presuneme
            while (i <= mid)
            {
                //zbyle cislo z leve casti jsou pridani do temp arraye
                temp[k] = numbers[i];
                i++; k++;
            }

            while (j <= right)
            {
                temp[k] = numbers[j];
                j++; k++;
            }

            // z temp arraye do originalniho arraye
            for (int index = left; index <= right; index++)
            {
                numbers[index] = temp[index];
            }
        }

        public static void Run(string[] words)
        {
            if (words == null || words.Length <= 1) return;
            string[] temp = new string[words.Length];
            SortRecursive(words, temp, 0, words.Length - 1);
        }

        private static void SortRecursive(string[] words, string[] temp, int left, int right)
        {
            if (left >= right) return;
            int mid = (left + right) / 2;
            SortRecursive(words, temp, left, mid);
            SortRecursive(words, temp, mid + 1, right);
            Merge(words, temp, left, mid, right);
        }

        private static void Merge(string[] words, string[] temp, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int k = left;

            while (i <= mid && j <= right)
            {
                if (string.Compare(words[i], words[j]) <= 0)
                {
                    temp[k] = words[i];
                    i++;
                }
                else
                {
                    temp[k] = words[j];
                    j++;
                }
                k++;
            }

            while (i <= mid) { temp[k] = words[i]; i++; k++; }
            while (j <= right) { temp[k] = words[j]; j++; k++; }
            for (int index = left; index <= right; index++) { words[index] = temp[index]; }
        }
    }
}
