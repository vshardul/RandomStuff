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
        private readonly string word1;
        private readonly string word2;

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
           // dummy
            char operation;
           return Min(potentialDeleteCost, potentialInsertCost, potentialSubstitutionCost, out operation);
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
            var operations = new char[word1.Length + 1, word2.Length + 1];
            
            int i = 1;
            int j = 1;
            string sequence = "";
            editDistances[0, 0] = 0;

            foreach (var letter1 in word1)
            {
                editDistances[i, 0] = i;
                operations[i, 0] = 'D';
                j = 1;
                foreach (var letter2 in word2)
                {
                    editDistances[0, j] = j;
                    operations[0, j] = 'I';
                    int cost = 0;
                    if (letter1 != letter2)
                    {
                        cost = 1;
                    }

                    editDistances[i,j] = Min(
                        editDistances[i - 1, j] + 1, editDistances[i, j - 1] + 1, editDistances[i - 1, j - 1] + cost, out operations[i,j]);

                    // bug here - operation sequence not correct
                    if (i == j)
                    {
                        if (cost != 0)
                        {
                            sequence += operations[i, j];
                        }
                        else
                        {
                            sequence += " ";
                        }
                    }
                    j++;
                }

                i++;
            }

            Console.WriteLine("Sequence of Operations - ");
            Console.Write(sequence);
            Console.WriteLine();

            Console.WriteLine("The entrire matrix of operations are - ");
            for (int k = 0; k < i; k++)
            {
                for (int l = 0; l < j; l++)
                {
                    Console.Write(
                        string.Format(" {0} ", operations[k, l]));
                }
                Console.WriteLine();
            }
            
            Console.WriteLine();
            return editDistances[i-1,j-1];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="num3"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        private static int Min(int num1, int num2, int num3, out char operation)
        {
            // Calculate minimum value
            int minimumValue = num1;
            operation = 'D';

            if (minimumValue > num2)
            {
                minimumValue = num2;
                operation = 'I';
            }

            if (minimumValue > num3)
            {
                minimumValue = num3;
                operation = 'S';
            }

            return minimumValue;
        }
    }
    }
