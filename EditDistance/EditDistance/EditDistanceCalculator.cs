using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    using System.Globalization;

    public class EditDistanceCalculator
    {
        private string word1, word2;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input1"></param>
        /// <param name="input2"></param>
        /// <param name="caseSenstitiveness"></param>
        public EditDistanceCalculator(string input1, string input2, bool caseSenstitiveness)
        {
            if (!caseSenstitiveness)
            {
                this.word1 = input1.ToLower(CultureInfo.InvariantCulture);
                this.word2 = input2.ToLower(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NaiveLevenstienDistanceBetweenWords()
        {
            return NaiveLevenstienDistanceBetweenWords(this.word1, this.word2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public static int NaiveLevenstienDistanceBetweenWords(string word1, string word2)
        {

            if (word1 == word2)
            {
                return 0;
            }

            if (word1.Length == 0)
            {
                return word2.Length;
            }

            if (word2.Length == 0)
            {
                return word1.Length;
            }

            // cost of deletes
            int potentialDeleteCost = NaiveLevenstienDistanceBetweenWords(word1.Remove(word1.Length - 1), word2) + 1;

            // cost of inserts
            int potentialInsertCost = NaiveLevenstienDistanceBetweenWords(word1, word2.Remove(word2.Length - 1)) + 1;
            
            // cost of substitutions
            int cost = word1[word1.Length - 1] == word2[word2.Length - 1] ? 0 : 1;
            int potentialSubstitutionCost =
                NaiveLevenstienDistanceBetweenWords(word1.Remove(word1.Length - 1), word2.Remove(word2.Length - 1)) + cost;

           return Min(potentialDeleteCost, potentialInsertCost, potentialSubstitutionCost);
        }

        /// <summary>
        /// 
        /// </summary>
        public int LevenstienDistanceBetweenWordsWithMemoization()
        {
            return LevenstienDistanceBetweenWordsWithMemoization(this.word1, this.word2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public static int LevenstienDistanceBetweenWordsWithMemoization(string word1, string word2)
        {

            if (word1 == word2)
            {
                return 0;
            }

            if (word1.Length == 0)
            {
                return word2.Length;
            }

            if (word2.Length == 0)
            {
                return word1.Length;
            }

            var editDistances = new int[word1.Length + 1, word2.Length + 1];
            
            int i = 1;
            int j = 1;
            foreach (var letter1 in word1)
            {
                editDistances[i, 0] = i-1;
                j = 1;
                foreach (var letter2 in word2)
                {
                    editDistances[0, j] = j-1;
                    int cost = 0;
                    if (letter1 != letter2)
                    {
                        cost = 1;
                    }

                    editDistances[i,j] = Min(
                        editDistances[i - 1, j] + 1, editDistances[i, j - 1] + 1, editDistances[i - 1, j - 1] + cost);
                    j++;
                }

                i++;
            }

            return editDistances[i-1,j-1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        /// <returns></returns>
        private static int Min(int num1, int num2, int num3)
        {
            // Calculate minimum value
            int minimumValue = num1;

            if (minimumValue > num2)
            {
                minimumValue = num2;
            }

            if (minimumValue > num3)
            {
                minimumValue = num3;
            }

            return minimumValue;
        }
    }
    }
