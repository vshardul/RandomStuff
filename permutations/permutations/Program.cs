using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace permutations
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();

            var permutations = new List<string>();

            GetPermutations(word, permutations);
        }

        private static void GetPermutations(char[] word, List<string> permutations)
    }
}
