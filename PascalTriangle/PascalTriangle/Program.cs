using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var triangleRows = int.Parse(Console.ReadLine());

            //var pascalMatrix = new int[triangleRows];
            
            //for (int i = 0; i <= triangleRows - 1; i++)
            //{
            //    var newArray = new int[triangleRows];
            //    for (int j = 0; j <= i; j++)
            //    {
            //        if (j == 0)
            //        {
            //            newArray[j] = pascalMatrix[j] = 1;
            //            Console.Write(1 + " ");
            //        }
            //        else
            //        {
            //            int upperValue = 0;
            //            upperValue = j == i ? upperValue : pascalMatrix[j];
            //            newArray[j] = pascalMatrix[j - 1] + upperValue;
            //            Console.Write(newArray[j] + " ");
            //        }
            //    }
            //    pascalMatrix = newArray;
            //    Console.WriteLine();
            //}

            var inputValues = Console.ReadLine().Split(new char[] {' '}).Select(int.Parse).ToList();
            var head = LinkedList.CreateRandomList(inputValues);

            FlattenList(head);

            while (head != null)
            {
                Console.WriteLine(head.Value);
                head = head.Next;
            }

            Console.ReadKey();
        }

        public static List<string> Permute(string input)
        {
            var lenght = input.Length;
            var output = new List<string>();

            if (lenght == 1)
            {
                output.Add(input);
            }

            for (int i = 0; i <= input.Length - 1; i++ )
           {
               char fixedLetter = input[i];

               foreach (var permutation in Permute(input.Substring(0, i) + input.Substring(i + 1, lenght - (i + 1))))
               {
                   output.Add(fixedLetter + permutation);
               }
           }

            return output;
        }

        public class LinkedList
        {
            public int Value;
            public LinkedList Next;
            public LinkedList Another;

            public LinkedList(int value)
                : this(value, null, null)
            {
            }

            public LinkedList(int value, LinkedList next, LinkedList another)
            {
                this.Value = value;
                this.Next = next;
                this.Another = another;
            }

            public static LinkedList CreateRandomList(List<int> valueList)
            {
                var head = new LinkedList(valueList[0]);
                var current = head;
                if (valueList.Any())
                {
                    var count = 0;
                    foreach(var value in valueList)
                    {
                        if (value % 3 == 0)
                        {
                            var anotherNode = new LinkedList(value);
                            current.Another = anotherNode;
                            var temp = current.Another;
                            while (count < 3)
                            {
                                var nextNode = new LinkedList(new Random().Next());
                                temp.Next = nextNode;
                                temp = nextNode;
                                count++;
                            }

                            count = 0;
                        }
                        else
                        {
                            var nextNode = new LinkedList(value);
                            current.Next = nextNode;
                            current = current.Next;
                        }
                    }
                }

                return head;
            }
        }

        public static LinkedList FlattenList(LinkedList head)
        {
            var current = head;
            while (true)
            {
                if (current.Another != null)
                {
                    var nextNode = current.Next;
                    current.Next = current.Another;
                    var last = FlattenList(current.Next);
                    current.Another = null;
                    last.Next = nextNode;
                }

                if (current.Next != null)
                {
                    current = current.Next;
                }
                else
                {
                    break;
                }

            }

            return current;
        }
    }
}
