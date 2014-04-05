using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter two words ");
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
                    StringSplitOptions.RemoveEmptyEntries);
                var editDistanceCalculator = new EditDistanceCalculator(items[0], items[1], false);
                var distance = editDistanceCalculator.LevenstienDistanceBetweenWordsWithMemoization();
                Console.WriteLine(string.Format("Edit Distance = {0}",distance));

                Console.WriteLine("Enter ESC to quit");
                var inp = Console.ReadKey().Key;
                if (inp == ConsoleKey.Escape)
                {
                    break;
                }
            }

        }
    }
}
