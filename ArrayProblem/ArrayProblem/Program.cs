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
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("enter numbers of the array");
        //    var numbers = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(value => int.Parse(value)).ToArray();

        //    Console.WriteLine("enter array defining the order");
        //    var indexArray = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(value => int.Parse(value)).ToArray();

        //    for (int i = 0; i <= numbers.Length - 1; i++)
        //    {

        //        int toPlaceIndex = indexArray[i];
        //        int toPlaceNumber = numbers[i];
        //        int currentIndex = i;

        //        if (toPlaceIndex < 0 || currentIndex == toPlaceIndex)
        //        {
        //            continue;
        //        }

        //        while (true)
        //        {
        //            if (toPlaceIndex >= 0)
        //            {
        //                var tempReplacedNumber = numbers[toPlaceIndex];
        //                numbers[toPlaceIndex] = toPlaceNumber;

        //                // mark as done
        //                indexArray[currentIndex] = ~indexArray[currentIndex];

        //                currentIndex = toPlaceIndex;
        //                    toPlaceIndex = indexArray[toPlaceIndex];
        //                    toPlaceNumber = tempReplacedNumber;


        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }

        //   Array.ForEach(numbers, Console.WriteLine);

        //   Console.ReadKey();
        //}

        //        static void Main(string[] args)
        //        {
        //            var head = new Node() { value = 1, next =null};

        //            var current = head;
        //            for (int i = 2; i <= 5; i++)
        //            {
        //                var tempNode = new Node() { value = i, next = null };
        //                current.next = tempNode;
        //                current = tempNode;
        //            }

        //            Console.WriteLine("Original List");
        //            current = head;
        //            while (current != null)
        //            {
        //                Console.Write(string.Format(" {0} ", current.value));
        //                current = current.next;
        //            }

        //            Console.WriteLine();

        //            //ReverseList(ref head);

        //            //Console.WriteLine("reversed List");
        //            //current = head;
        //            //while (current != null)
        //            //{
        //            //    Console.Write(string.Format(" {0} ", current.value));
        //            //    current = current.next;
        //            //}

        //            Console.WriteLine();
        //            Console.WriteLine("reversed List pairwise recursive");
        //            ReverseListPair(ref head);

        //            current = head;
        //            while (current != null)
        //            {
        //                Console.Write(string.Format(" {0} ", current.value));
        //                current = current.next;
        //            }

        //            Console.WriteLine();
        //            Console.WriteLine("reversed whole List recursive");
        //            head = ReverseListRecursive(head, null);

        //            current = head;
        //            while (current != null)
        //            {
        //                Console.Write(string.Format(" {0} ", current.value));
        //                current = current.next;
        //            }

        //            Console.ReadKey();

        //        }

        //        public class Node
        //        {
        //            public int value;
        //            public Node next;
        //        }


        //        public static void ReverseListPair(ref Node head)
        //        {
        //            if (head == null)
        //            {
        //                return;
        //            }

        //            Node previousNode = head;
        //            var firstNode = head;
        //            var secondNode = firstNode.next;
        //            int firstIteration = 0;

        //            while (firstNode != null && secondNode != null)
        //            {
        //                var nextNode = secondNode.next;
        //                secondNode.next = firstNode;
        //                firstNode.next = nextNode;

        //                if (firstIteration == 0)
        //                {
        //                    head = secondNode;
        //                    firstIteration++;
        //                }
        //                else
        //                {
        //                    previousNode.next = secondNode;
        //                }

        //                // assign nodes for next iteration
        //                previousNode = firstNode;
        //                firstNode = nextNode;
        //                secondNode = firstNode == null ? null : firstNode.next;
        //            }
        //        }

        //        public void ReverseListPairRecursive(ref Node head)
        //        {
        //            if(head == null)
        //            {
        //                return;
        //            }

        //            var secondNode = head.next;
        //            if(secondNode != null)
        //            {
        //                 var nextNode = secondNode.next;
        //                 secondNode.next = head;
        //                 head.next = nextNode;
        //                 ReverseListPair(ref head.next);
        //                 head = secondNode;
        //             }
        //        }

        //        public static Node ReverseListRecursive(Node head, Node previous)
        //        {
        //            if (head == null)
        //            {
        //                if (previous != null)
        //                {
        //                    head = previous;
        //                }

        //                return head;
        //            }

        //            var secondNode = head.next;
        //            head.next = previous;
        //            if (secondNode != null)
        //            {
        //                var nextNode = secondNode.next;
        //                secondNode.next = head;
        //                head = ReverseListRecursive(nextNode, secondNode);
        //            }

        //            return head;
        //        }
        //    }

        //    '1' -> 'A', 'B', 'C'
        //2 -> D, E, F
        //3 -> G, H, I
        //...
        //0 -> X

        //Input: 12

        //Output: AD, AE, AF, BD, BE, BF, CD, ...

        //123

        //ADG ADH ADI AEG AEH AEI ...

        //public list<string> GetCombinations(Dictionary<string, string> inputDictionary, sting inputString)
        //{
        //    if(inputString == null || inputString.IsNuLLOrWhitespace())
        //    {
        //        return new List<string>();
        //    }

        //    var list1 = inputDictionary[inputString[0];
        //    for(int j = 1; j <= inputString.Lenght -1; j++)
        //    {
        //        var list2 = inputDictionary[j];
        //        var outputList = new List<string>();

        //        foreach(var character in list1)
        //        {
        //            foreach(var char2 in list2)
        //            {          
        //              outputlist.add(character + char2);   
        //            }
        //        }
        //         list1 = outputList;
        //    }

        //    return list1; 
        //}





        //function cd(curr, input)

        //curr="/home", input="foo" => "/home/foo"
        //curr="/home/foo", input="../bar/.." => "/home"

        //cd ../foo

        //pubic string GenerateCd(string currentdir, string input)
        //{
        //    var baseDirs = currentDir.split(new []{'\'});
        //    var dirStack = new Stack<string>();
        //    foreach(var dir in baseDirs)
        //    {
        //        dirStack.add(dir);
        //    }

        //    var iputDirs = input.split(new []{'\'});
        //    foreach(var input in inputdir)
        //    {
        //        if(input == "..")
        //        {
        //            dirStack.pop();
        //        }
        //        else
        //        {
        //            dirStack.insert(input);
        //        }
        //    }

        //    string output = null;
        //    while(!dirStack.IsEmpty())
        //    {
        //    var item = dirStack.pop();
        //    output = item + "\" + output;
        //    }

        //    if(output[0] != "\")
        //    {
        //        output = "\" + output;
        //    }

        //    return output;
        //} 

        public static void Main(string[] args)
        {
            var input = Console.ReadLine();
            CreateCasePermutations(input);

            Console.ReadKey();
        }

        public static void CreateCasePermutations(string inputString)
        {
            var numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var listStrings = new List<string> { inputString };

            int i = 0;
            foreach (var character in inputString)
            {
                if (numbers.Contains(character))
                {
                    i++;
                    continue;
                }

                var tmpList = listStrings.Where(entry => entry != null).ToList();
                foreach (var word in tmpList)
                {
                    var tempWord = word.ToCharArray();
                    char letter = tempWord[i];

                    if (letter <= 90)
                    {
                        tempWord[i] = word[i].ToString().ToLower().ToCharArray()[0];
                    }
                    else
                    {
                        tempWord[i] = word[i].ToString().ToUpper().ToCharArray()[0];
                    }

                    listStrings.Add(new string(tempWord));
                    
                }

                i++;
            }

            listStrings.ForEach(Console.WriteLine);
        }
    }

}
