using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedList
{
    public class Node
    {
        public int value;
        public Node next;
    }

    public class TreeNode
    {
        public int value;
        public TreeNode left;
        public TreeNode right;
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var inputArray = Console.ReadLine().Split(' ').Where(entry => !string.IsNullOrWhiteSpace(entry))
            //    .Select(int.Parse).ToArray();

            //var head = new Node() { value = inputArray[0], next = null };
            //Node current = head;
            //foreach (var entry in inputArray.Where((value, index) => index >= 1))
            //{
            //    var temp = new Node { value = entry, next = null };
            //    current.next = temp;
            //    current = current.next;
            //}

            //TreeNode root = CreateTree(head);

            //PrintTree(root);

            //Console.WriteLine("enter inorder value");
            //var inorder = Console.ReadLine().Split(' ').Where(entry => !string.IsNullOrWhiteSpace(entry))
            //                     .Select(int.Parse).ToList();
            //Console.WriteLine("enter preorder value");
            //var preorder = Console.ReadLine().Split(' ').Where(entry => !string.IsNullOrWhiteSpace(entry))
            //                     .Select(int.Parse).ToList();
            //int preorderIndex = -1;
            //TreeNode newTree = CreateTreeFromInorderPreorder(inorder, preorder, ref preorderIndex);
            //PrintTree(newTree);

            //Console.WriteLine(IsBST(newTree));

            //TreeNode bstRoot = CreateBST(head);

            //PrintTree(bstRoot);
            //Console.WriteLine(IsBST(bstRoot));

            //Console.WriteLine("Enter value to get the lowest common ancestor of");
            //var input1 = int.Parse(Console.ReadLine());
            //var input2 = int.Parse(Console.ReadLine());

            //var ancestor = GetLowestCommonAncestor(bstRoot, input1, input2);

            //Console.WriteLine("Lowest common ancestor is " + ancestor.value);

            //var coins = Console.ReadLine().Split(' ').Select(value => value.Trim()).Select(
            //    int.Parse);
            //var sum = int.Parse(Console.ReadLine());

            //var minimumCoins = MinimumNumberOfCoins(sum, coins.ToList());
            //Console.WriteLine(minimumCoins);

            //Console.WriteLine(FindPaths(0, 1, 4, 4));

            var string1 = Console.ReadLine();
            var string2 = Console.ReadLine();

            var result = LongestSubsequence(string1, string2);
            Console.WriteLine(result);

            Console.ReadKey();
        }

        private static string LongestSubsequence(string string1, string string2)
        {
            if (string1.Length == 0 || string2.Length == 0)
            {
                return "";
            }

            var result1 = "";
            if (string1[0] == string2[0])
            {
                result1 = string1[0] + LongestSubsequence(string1.Substring(1), string2.Substring(1));
            }

            var result2 = LongestSubsequence(string1.Substring(1), string2);

            var result3 = LongestSubsequence(string1, string2.Substring(1));

            var result = new[] { result1, result2, result3 }.OrderByDescending(word => word.Length).First();

            return result;
        }

        private static TreeNode GetLowestCommonAncestor(TreeNode root, int input1, int input2)
        {
            if (root == null)
            {
                return null;
            }

            if (root.value >= input1 && root.value <= input2)
            {
                return root;
            }
            
            if (root.value < input1 && root.value < input2)
            {
                return GetLowestCommonAncestor(root.right, input1, input2);
            }
            
            return GetLowestCommonAncestor(root.left, input1, input2);
        }

        private static TreeNode CreateBST(Node head)
        {
            TreeNode root = null;

            while (head != null)
            {
                InsertBST(ref root, head.value);
                head = head.next;
            }

            return root;
        }

        private static void InsertBST(ref TreeNode root, int value)
        {
            if (root == null)
            {
                root = new TreeNode { value = value };
                return;
            }

            if (root.value <= value)
            {
                InsertBST(ref root.right, value);
            }
            else
            {
                InsertBST(ref root.left, value);
            }
        }

        private static bool IsBST(TreeNode node)
        {
            if (node != null)
            {
                var left = node.left != null ? node.left.value : int.MinValue;
                var right = node.right != null ? node.right.value : int.MaxValue;
                if (left > node.value || node.value > right)
                {
                    return false;
                }
                
                return IsBST(node.left) && IsBST(node.right);
            }

            return true;
        }

        private static TreeNode CreateTreeFromInorderPreorder(List<int> inorderList, List<int> preorderList, ref int preorderIndex)
        {
            if (!inorderList.Any() || !preorderList.Any() || preorderIndex >= preorderList.Count)
            {
                return null;
            }

            preorderIndex = preorderIndex + 1;
            var root = new TreeNode { value = preorderList[preorderIndex] };
            var rootIndex = inorderList.IndexOf(preorderList[preorderIndex]);

            var inorderLeft = inorderList.Where((value, index) => index < rootIndex).ToList();
            var inorderRight = inorderList.Where((value, index) => index > rootIndex).ToList();

            //var preorderLeft = preorderList.Where(inorderLeft.Contains).ToList();
            //var preorderRight = preorderList.Where(inorderRight.Contains).ToList();

            root.left = CreateTreeFromInorderPreorder(inorderLeft, preorderList, ref preorderIndex);
            root.right = CreateTreeFromInorderPreorder(inorderRight, preorderList, ref preorderIndex);

            return root;
        }

        private static void PrintTree(TreeNode root)
        {
            Console.WriteLine("Preorder ");
            PrintTreePreOrder(root);
            Console.WriteLine();

            Console.WriteLine("Inorder ");
            PrintTreeInOrder(root);
            Console.WriteLine();

            Console.WriteLine("PostOrder ");
            PrintTreePostOrder(root);
            Console.WriteLine();

            Console.WriteLine("Print level by level ");
            PrintTreeLevelByLevel(root);
            Console.WriteLine();
        }

        private static void PrintTreeLevelByLevel(TreeNode head)
        {
            var nodeQueue = new Queue<TreeNode>();
            nodeQueue.Enqueue(head);

            while (nodeQueue.Count > 0)
            {
                var tempQueue = new Queue<TreeNode>();
                while (nodeQueue.Count > 0)
                {
                    var node = nodeQueue.Dequeue();
                    if (node != null)
                    {
                        Console.Write(node.value + " ");
                        tempQueue.Enqueue(node.left);
                        tempQueue.Enqueue(node.right);
                    }
                }

                Console.WriteLine();
                nodeQueue = tempQueue;
            }
        }

        private static void PrintTreePreOrder(TreeNode head)
        {
            if (head == null)
            {
                return;
            }

            Console.Write(head.value + " ");
            PrintTreePreOrder(head.left);
            PrintTreePreOrder(head.right);
        }

        private static void PrintTreeInOrder(TreeNode head)
        {
            if (head == null)
            {
                return;
            }

            PrintTreeInOrder(head.left);
            Console.Write(head.value + " ");
            PrintTreeInOrder(head.right);
        }

        private static void PrintTreePostOrder(TreeNode head)
        {
            if (head == null)
            {
                return;
            }

            PrintTreePostOrder(head.left);
            PrintTreePostOrder(head.right);
            Console.Write(head.value + " ");
        }

        private static TreeNode CreateTree(Node current)
        {
            if (current == null)
            {
                return null;
            }

            var root = new TreeNode { value = current.value };
            var currentT = root;
            current = current.next;

            int i = 1;
            var treeQueue = new Queue<TreeNode>();
            while (current != null)
            {
                var treeNode = new TreeNode { value = current.value };
                current = current.next;
                if (i == 1)
                {
                    currentT.left = treeNode;
                    treeQueue.Enqueue(currentT.left);
                    i++;
                }
                else if (i == 2)
                {
                    currentT.right = treeNode;
                    treeQueue.Enqueue(currentT.right);
                    i++;
                }
                
                if(i >= 3)
                {
                    i = 1;
                    currentT = treeQueue.Dequeue();
                }
            }

            return root;
        }

        private static int TotalNumberOfBinaryTress(int nodes)
        {
            if (nodes <= 1)
            {
                return 1;
            }

            int total = 0;
            for (int i = 0; i < nodes; i++)
            {
                var leftSum = TotalNumberOfBinaryTress(i);
                var rightSum = TotalNumberOfBinaryTress(nodes - i - 1);
                total += leftSum * rightSum;
            }

            return total;
        }

        private static int MinimumNumberOfCoins(int sum, List<int> coins)
        {
            if (sum == 0)
            {
                return 0;
            }
           
            var minSum = int.MaxValue;
            foreach (var coin in coins)
            {
                if (coin <= sum)
                {
                    var sum1 = 1 + MinimumNumberOfCoins(sum - coin, coins);
                    if (sum1 < minSum)
                    {
                        minSum = sum1;
                    }
                }
            }

            return minSum;
        }

        private static int FindPaths(int x1, int y1, int x2, int y2)
        {
            if (x1 >= 5 || y1 >= 5)
            {
                return 0;
            }

            if (x1 == x2 && y1 == y2)
            {
                return 1;
            }

            var paths = 0;
            paths += FindPaths(x1 + 1, y1, x2, y2);
            paths += FindPaths(x1, y1 + 1, x2, y2);

            return paths;
        }
    }
}
