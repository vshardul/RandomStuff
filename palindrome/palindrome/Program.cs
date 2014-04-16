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
                var palindrome = FindLongestPalindrome(inputString);

                Console.WriteLine("Lenght of longest palindrome = " + palindrome.Lenght);
                Console.WriteLine("longest palindrome = {0}", palindrome.Word );

                Console.WriteLine("Enter ESC to quit, any other key to continue");
                var nextKey = Console.ReadKey();
                if (nextKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static readonly Dictionary<string, PalindromeStringDataType> PalindromeDict = new Dictionary<string, PalindromeStringDataType>();
        
        private static PalindromeStringDataType FindLongestPalindrome(string inputString)
        {
            if (!inputString.Any() || inputString == null)
            {
                return new PalindromeStringDataType(){Lenght = 0, Word = ""};
            }

            if (PalindromeDict.ContainsKey(inputString))
            {
                return PalindromeDict[inputString];
            }

            int lenght = inputString.Length;
            var initType = new PalindromeStringDataType { Lenght = 0, Word = "" };
            PalindromeStringDataType count2, count3, point;
            PalindromeStringDataType count1 = count2 = count3 = point = initType;
            
            if (lenght == 1)
            {
                point = new PalindromeStringDataType { Lenght = 1, Word = inputString};
            }
            else
            {
                var temp = FindLongestPalindrome(inputString.Substring(1, lenght - 2));
                if (inputString[0] == inputString[lenght - 1])
                {
                    count1 = new PalindromeStringDataType() { Lenght = 2 + temp.Lenght, Word = inputString[0] + temp.Word + inputString[lenght - 1] };
                }
                else
                {
                    count1 = temp;
                }
                
                count2 = FindLongestPalindrome(inputString.Substring(0, lenght - 1));
                count3 = FindLongestPalindrome(inputString.Substring(1, lenght - 1));
            }
            
            var finalPalindrome = new PalindromeStringDataType[] { count1, count2, count3, point }.OrderByDescending(entry => entry.Lenght).First();
            PalindromeDict[inputString] = finalPalindrome;
            return finalPalindrome;
        }
    }
}
