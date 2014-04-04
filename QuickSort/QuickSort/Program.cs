using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Enter numbers ");
                var inputLine = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(inputLine))
                {
                    Console.WriteLine("Invalid input, try again");
                    continue;
                }

                var items = inputLine.Split(
                    new[]
                    {
                        ' ',
                        '\t'
                    },
                    StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var sortedItems = QuickSortProvider.NaiveSort(items).ToList();
                sortedItems.ForEach(item =>  Console.Write(string.Format("{0} ", item)));
                Console.WriteLine();

                Console.WriteLine("Enter space to continue, another key to quit");
                var inp = Console.ReadKey().Key;
                if (inp != ConsoleKey.Spacebar)
                {
                    break;
                }
            }
        }
    }
}
