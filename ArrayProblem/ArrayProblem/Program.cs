using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayProblem
{
    /// <summary>
    /// The input is a sequence x1,x2,...,xn of integers in an arbitrary order, and another sequence 
//a1,a2,..,an of distinct integers from 1 to n (namely a1,a2,...,an is a permutation of 
//1, 2,..., n). Both sequences are given as arrays. Design an 0(n logn) algorithm to order 
//the first sequence according to the order imposed by the permutation. In other words, for 
//each i, Xi should appear in the position given in ai. For example, if x = 17, 5, 1,9, and a = 
//3, 2, 4, 1, then the outcome should be x = 9, 5, 17, 1. The algorithm should be in-place, so 
//you cannot use an additional array.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter numbers of the array");
            var numbers = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(value => int.Parse(value)).ToArray();

            Console.WriteLine("enter array defining the order");
            var indexArray = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(value => int.Parse(value)).ToArray();

            for (int i = 0; i <= numbers.Length - 1; i++)
            {
                
                int toPlaceIndex = indexArray[i];
                int toPlaceNumber = numbers[i];
                int currentIndex = i;

                if (toPlaceIndex < 0 || currentIndex == toPlaceIndex)
                {
                    continue;
                }

                while (true)
                {
                    if (toPlaceIndex >= 0)
                    {
                        var tempReplacedNumber = numbers[toPlaceIndex];
                        numbers[toPlaceIndex] = toPlaceNumber;
                        
                        // mark as done
                        indexArray[currentIndex] = ~indexArray[currentIndex];
                        
                        currentIndex = toPlaceIndex;
                            toPlaceIndex = indexArray[toPlaceIndex];
                            toPlaceNumber = tempReplacedNumber;
                            
                        
                    }
                    else
                    {
                        break;
                    }
                }
            }

           Array.ForEach(numbers, Console.WriteLine);

           Console.ReadKey();
        }
    }
}
