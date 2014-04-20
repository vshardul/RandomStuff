namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BinaryTreeNode<T> where T : IComparable
    {
        public  T value;
        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;

        public BinaryTreeNode() { }

        public BinaryTreeNode (T value) : this(value, null, null)
        { }
        
        public BinaryTreeNode (T value, BinaryTreeNode<T> left, BinaryTreeNode<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        /// <summary>
        /// Creates a balanced binary tree
        /// </summary>
        /// <param name="valueArray"></param>
        /// <returns></returns>
        public static BinaryTreeNode<T> CreateTree(T[] valueArray)
        {
            BinaryTreeNode<T> root = new BinaryTreeNode<T>(valueArray[0]);
            var current = root;
            Queue<BinaryTreeNode<T>> candidateCurrent = new Queue<BinaryTreeNode<T>>();

            for (int i = 1; i <= valueArray.Length - 1; i++)
            {
                var node = new BinaryTreeNode<T>(valueArray[i]);
                if (current.left == null)
                {
                    current.left = node;
                    candidateCurrent.Enqueue(node);
                }
                else if (current.right == null)
                {
                    current.right = node;
                    candidateCurrent.Enqueue(node);
                }
                else
                {
                    current = candidateCurrent.Dequeue();
                    i--;
                }
            }

            return root;
        }

        /// <summary>
        /// Prints a tree in level order
        /// </summary>
        /// <param name="root"></param>
        public static void PrintBinaryTree(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            Queue<BinaryTreeNode<T>> nodeQueue = new Queue<BinaryTreeNode<T>>();
            nodeQueue.Enqueue(root);

            while (nodeQueue.Any())
            {
                var tempQueue = new Queue<BinaryTreeNode<T>>(); 
                while (nodeQueue.Any())
                {
                    var current = nodeQueue.Dequeue();
                    if (current != null)
                    {
                        Console.Write(current.value + "   ");
                        tempQueue.Enqueue(current.left);
                        tempQueue.Enqueue(current.right);
                    }
                }

                Console.WriteLine();
                nodeQueue = tempQueue;
            }
        }

        /// <summary>
        /// Prints a tree in level order
        /// </summary>
        /// <param name="root"></param>
        public static void PrintBinaryTreeImproved(BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            Queue<BinaryTreeNode<T>> nodeQueue = new Queue<BinaryTreeNode<T>>();
            BinaryTreeNode<T> last = root;
            nodeQueue.Enqueue(root);
            nodeQueue.Enqueue(null);
            
            while (nodeQueue.Any())
            {
                BinaryTreeNode<T> current = nodeQueue.Dequeue();
                last = current;
                while (current != null)
                {
                    Console.Write(current.value + "   ");
                    nodeQueue.Enqueue(current.left);
                    nodeQueue.Enqueue(current.right);
                    current = nodeQueue.Dequeue();
                }

                Console.WriteLine();
                if (last != null)
                {
                    nodeQueue.Enqueue(current);
                }
             }
        }

        /// <summary>
        /// Creates a BST from a value array
        /// </summary>
        /// <param name="valueArray"></param>
        /// <returns></returns>
        public static BinaryTreeNode<T> CreateBST (T[] valueArray)
        {
            var root = new BinaryTreeNode<T>(valueArray[0]);
            //var current = root;
            for (int i = 1; i <= valueArray.Length - 1; i++)
            {
                AddtoBST(ref root, valueArray[i]);
            }

            return root;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="root"></param>
        /// <param name="value"></param>
        public static void  AddtoBST(ref BinaryTreeNode<T> root, T value) 
        {

            if (root == null)
            {
                root = new BinaryTreeNode<T>(value);
            }
            else
            {
                if (value.CompareTo(root.value) < 0)
                {
                    AddtoBST(ref root.left, value);
                }
                else
                {
                    AddtoBST(ref root.right, value);
                }
            }
        }

        public static List<T> InorderTraversal(BinaryTreeNode<T> root)
        {
            var inorderList = new List<T>();
            InorderTraversal(root, inorderList);
            return inorderList;
        }

        private static void InorderTraversal(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            InorderTraversal(node.left, list);
            list.Add(node.value);
            InorderTraversal(node.right, list);
        }

        public static List<T> PreorderTraversal(BinaryTreeNode<T> root)
        {
            var preorderList = new List<T>();
            PreorderTraversal(root, preorderList);
            return preorderList;
        }

        private static void PreorderTraversal(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            list.Add(node.value);
            PreorderTraversal(node.left, list);
            PreorderTraversal(node.right, list);
        }

        /// <summary>
        /// Posty order traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static List<T> PostorderTraversal(BinaryTreeNode<T> root)
        {
            var postorderList = new List<T>();
            PostorderTraversal(root, postorderList);
            return postorderList;
        }

        private static void PostorderTraversal(BinaryTreeNode<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            PostorderTraversal(node.left, list);
            PostorderTraversal(node.right, list);
            list.Add(node.value);
        }

    }
}
