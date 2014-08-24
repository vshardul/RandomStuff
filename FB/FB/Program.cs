using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FB
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    var number = int.Parse(Console.ReadLine());
        //    int reverse = 0;
        //    bool isNegative = false;
            
        //    if (number < 0)
        //    {
        //        number *= -1;
        //        isNegative = true;
        //    }

        //    while (number > 0)
        //    {
        //        reverse = reverse * 10;
        //        reverse += (number % 10);
        //        number = number / 10;
        //    }

        //    if (isNegative)
        //    {
        //        reverse *= -1;
        //    }

        //    Console.WriteLine(reverse);
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var anagrams = new List<string>();
            //GetAnagrams(0, word, anagrams);
            GetAnagrams2(word, "", anagrams);
            anagrams.ForEach(Console.WriteLine);
            Console.ReadKey();
        }

        private static void GetAnagrams(int indexToSwap, string word, List<string> anagrams)
        {
            if (indexToSwap >= word.Length - 1)
            {
                anagrams.Add(word);
                return;
            }

            var wordArray = word.ToCharArray();

            for (int i = indexToSwap; i <= word.Length - 1; i++)
            {
                Swap(wordArray, indexToSwap, i);
                GetAnagrams(indexToSwap + 1, new string(wordArray), anagrams);
                Swap(wordArray, i, indexToSwap);
            }
        }

        private static void Swap(IList<char> word, int index1, int index2)
        {
            var temp = word[index1];
            word[index1] = word[index2];
            word[index2] = temp;
        }

        private static void GetAnagrams2(string word, string result, List<string> anagrams)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                anagrams.Add(result);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                GetAnagrams2((i > 0 ? word.Substring(0, i) : "") + word.Substring(i + 1), result + word[i], anagrams);
            }
        }
    }
}
