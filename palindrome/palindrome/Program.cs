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
                Console.WriteLine("Lenght of longest palindrome with DP = " + palindrome.Lenght);
                Console.WriteLine("longest palindrome with DP = {0}", palindrome.Word );

                palindrome = FindLongestPalindromeNoDp(inputString);
                Console.WriteLine("Lenght of longest palindrome without DP = " + palindrome.Lenght);
                Console.WriteLine("longest palindrome without DP = {0}", palindrome.Word);

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

        /// <summary>
        /// Find longest palindrome without DP
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private static PalindromeStringDataType FindLongestPalindromeNoDp(string inputString)
        {
            if (!inputString.Any() || inputString == null)
            {
                return new PalindromeStringDataType() { Lenght = 0, Word = "" };
            }

            var currentMaxPalindromeLenghtIndexPair = new [] {0, 0};
            int left, right, currentLenght;
            for (var currentCenter = 0; currentCenter <= inputString.Length - 1; currentCenter++)
            {
                currentLenght = 1;
                left  = currentCenter - 1;
                right = currentCenter + 1;
                
                if ((right <= inputString.Length - 1) && inputString[currentCenter] == inputString[right])
                {
                    if (left >= 0 && inputString[currentCenter] == inputString[left])
                    {
                        left--;
                        currentLenght++;
                    }

                    right++;
                    currentLenght++;
                }

                while ((left >= 0 && right <= inputString.Length - 1) && inputString[left] == inputString[right])
                {
                    left--;
                    right++;
                    currentLenght += 2;
                }

                if (currentMaxPalindromeLenghtIndexPair[1] <= currentLenght)
                {
                    //special check for two palindromes of the same lenght centered 1 space frome each other
                    if (currentMaxPalindromeLenghtIndexPair[0] == currentCenter - 1 && currentMaxPalindromeLenghtIndexPair[1] == currentLenght)
                    {
                        currentLenght++;
                    }

                    currentMaxPalindromeLenghtIndexPair[1] = currentLenght;
                    currentMaxPalindromeLenghtIndexPair[0] = currentCenter;
                }

            }

            return new PalindromeStringDataType
            {
                Lenght = currentMaxPalindromeLenghtIndexPair[1],
                Word =
                    inputString.Substring(
                        currentMaxPalindromeLenghtIndexPair[0] - currentMaxPalindromeLenghtIndexPair[1]/2,
                        currentMaxPalindromeLenghtIndexPair[1])
            };

        }
    }
}
