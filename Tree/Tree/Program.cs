using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            bool shouldCreateTree;
            if (args.Any())
            {
                bool.TryParse(args[0], out shouldCreateTree);
            }
            else
            {
                shouldCreateTree = true;
            }

            if (shouldCreateTree)
            {
                Console.WriteLine("Enter node values");
                var valueArray = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                
                // Normal binary tree
                //var root =  BinaryTreeNode<string>.CreateTree(valueArray);
                //Console.WriteLine("Print binary tree level by level");
                //BinaryTreeNode<string>.PrintBinaryTree(root);
                //Console.WriteLine("Compare two implementations");
                //BinaryTreeNode<string>.PrintBinaryTreeImproved(root);

                // BST
                Console.WriteLine("now create a BST out of it");
                var bstRoot = BinaryTreeNode<int>.CreateBST(valueArray.Select(value => int.Parse(value)).ToArray());
                Console.WriteLine("printing bst level by level");
                BinaryTreeNode<int>.PrintBinaryTree(bstRoot);

                BinaryTreeNode<int>.PrintPathToLeaf(bstRoot, 100);
                Console.WriteLine();
                BinaryTreeNode<int>.PrintPathToLeafWithoutRecursion(bstRoot, 100);

                ////replace each node with sum of all node which are greater then of equal to current node.
                //Console.WriteLine("printing bst level by level");
                //BinaryTreeNode<int>.StoreAllHighValuesInNode(bstRoot);
                //Console.WriteLine("printing bst level by level with each node with sum of all node which are greater then of equal to current node ");
                //BinaryTreeNode<int>.PrintBinaryTree(bstRoot);

                // Traversals
                //Console.WriteLine("In order traversal of bst");
                //var list = BinaryTreeNode<int>.InorderTraversal(bstRoot);
                //list.ForEach(Console.WriteLine);

                //Console.WriteLine("Pre order traversal of bst");
                //list = BinaryTreeNode<int>.PreorderTraversal(bstRoot);
                //list.ForEach(Console.WriteLine);

                //Console.WriteLine("Post order traversal of bst");
                //list = BinaryTreeNode<int>.PostorderTraversal(bstRoot);
                //list.ForEach(Console.WriteLine);
                
                Console.ReadKey();
            }
        }
    }
}
