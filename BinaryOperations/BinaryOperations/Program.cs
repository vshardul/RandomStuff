using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var inputNum = int.Parse(Console.ReadLine());

                int count = 0;
                while (inputNum != 0)
                {
                    if ((inputNum & 1) == 1)
                    {
                        count++;
                    }

                    inputNum = inputNum >> 1;
                }

                Console.WriteLine("The 1's in the number = " + count);

                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
