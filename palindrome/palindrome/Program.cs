using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("enter string");
                var inputString = Console.ReadLine();
                string left = "", right = "";
                var palindrome = FindLongestPalindrome(inputString, left, right);

                Console.WriteLine("Lenght of longest palindrome = " + palindrome);
                Console.WriteLine("longest palindrome = {0}{1}", left, right);

                Console.WriteLine("Enter ESC to quit, any other key to continue");
                var nextKey = Console.ReadKey();
                if (nextKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static Dictionary<string, int> palindromeDict = new Dictionary<string, int>();
        
        private static int FindLongestPalindrome(string inputString, string leftString, string rightString)
        {
            if (inputString.Count() == 0 || inputString == null)
            {
                return 0;
            }

            if (palindromeDict.ContainsKey(inputString))
            {
                return palindromeDict[inputString];
            }

            int lenght = inputString.Length;
            int count1 = 0, count2 = 0, count3 = 0;
            
            int point = 0;
            if (lenght == 1)
            {
                point = 1;
            }
            else
            {
                if (inputString[0] == inputString[lenght - 1])
                {
                    count1 = 2 + FindLongestPalindrome(inputString.Substring(1, lenght - 2), string.Format("{0}{1}", inputString[0], leftString), string.Format("{0}{1}", inputString[lenght - 1], rightString));
                }
                else
                {
                    count1 = 0 + FindLongestPalindrome(inputString.Substring(1, lenght - 2), leftString, rightString);
                }
                
                count2 = 0 + FindLongestPalindrome(inputString.Substring(0, lenght - 1), leftString, rightString);
                count3 = 0 + FindLongestPalindrome(inputString.Substring(1, lenght - 1), leftString, rightString);
            }
            
            int finalcount = new int[] { count1, count2, count3, point }.OrderByDescending(value => value).First();
            palindromeDict[inputString] = finalcount;
            return finalcount;
        }
    }
}
