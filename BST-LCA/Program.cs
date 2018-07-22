using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST_LCA
{
    class Program
    {
        class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        class BinarySearchTree
        {
            public Node Root { get; set; }

            public void Add(Node root, int data)
            {
                Root = AddRec(root, data);
            }

            public Node AddRec(Node root, int data)
            {
                if (root == null)
                {
                    root = new Node(data);
                    return root;
                }

                if (data < root.Data)
                {
                    root.Left = AddRec(root.Left, data);
                }
                else if (data > root.Data)
                {
                    root.Right =  AddRec(root.Right, data);
                }

                return root;
            }

            public Node LCA(Node node, int d1, int d2)
            {
                if (node == null)
                {
                    return null;
                }

                if (node.Data > d1 && node.Data > d2)
                {
                    return LCA(node.Left, d1, d2);
                }
                
                if (node.Data < d1 && node.Data < d2)
                {
                    return LCA(node.Right, d1, d2);
                }
                    
                return node;
            }

            public void PrintInOrder(Node root)
            {
                if (root != null)
                {
                    PrintInOrder(root.Left);
                    Console.WriteLine(root.Data);
                    PrintInOrder(root.Right);
                }
            }
        }

        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.Add(bst.Root, 30);
            bst.Add(bst.Root, 20);
            bst.Add(bst.Root, 10);
            bst.Add(bst.Root, 40);
            bst.Add(bst.Root, 50);
            bst.Add(bst.Root, 60);

            Console.WriteLine("The resulting BST is:");
            bst.PrintInOrder(bst.Root);

            Node lca = bst.LCA(bst.Root, 10, 60);

            Console.WriteLine("The LCA of 10 and 60 is:");
            Console.WriteLine(lca.Data);

        }
    }
}
