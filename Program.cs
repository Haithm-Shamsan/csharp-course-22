using System;
using System.Collections.Generic;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Linq;

using System.Runtime.Remoting.Channels;
using System.Diagnostics;
using System.Net.Cache;
using System.Collections;
using System.Runtime.InteropServices;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.ComponentModel.Design.Serialization;
using static Course_22.Program;

namespace Course_22
{
    internal class Program
    {
            class SelectionSort
        {
 public static int GetTheIndexOfTheMinmumNumber(IEnumerable< int >Names)
        {
           int [] Ar = Names.ToArray();
            return Array.IndexOf(Ar, Ar.Min());
        }


            //    int[] Numbers = { 4, 3, 6, 34, 7, 2, 53 };
            //    for(int i=0;i<Numbers.Length;i++)
            //    {
            //        int MinNumber = GetTheIndexOfTheMinmumNumber(Numbers.Skip(i))+i;


            //        if (Numbers[MinNumber] < Numbers[i])
            //        {
            //            (Numbers[MinNumber], Numbers[i]) = (Numbers[i], Numbers[MinNumber]);
            //        }

            //    }

            //  foreach(var i in Numbers)
            //    {
            //        Console.WriteLine(i);
            //    }


            //    Console.WriteLine("Filteration using BubbleSort");
            //    int[] ArrNumber = { 4, 54, 6, 34, 74, 42, 56 };

            //    BubbleSort(ArrNumber);

            //    foreach(int i in ArrNumber)
            //    {
            //        Console.WriteLine(i);
            //    }
        }

        

        public class TreeNode<T>
        {
            public T Value { get; set; }
            public List<TreeNode<T>> Children { get; set; }


            public TreeNode(T value)
            {
                this.Value = value;
                this.Children = new List<TreeNode<T>>();
            }


            // Method to add a child node to the node
            public void AddChild(TreeNode<T> child)
            {
                Children.Add(child);
            }
            public bool Find(T Value)
            {
                if (EqualityComparer<T>.Default.Equals(this.Value, Value))
                    return true;

                foreach (var Item in Children)
                {
                    var IsFound =Item.Find(Value);

                    if (IsFound != null)
                        return true;
                }
                return false;
            }
        }

        public class Tree<T>
        {
            public TreeNode<T> Root { get; private set; }

            public Tree(T root)
            {
                this.Root = new TreeNode<T>(root);
            }

           
        }
        static void BubbleSort(int[] arr)
            {
                int n = arr.Length;
                for (int i = 0; i < n ; i++)
                    for (int j = 0; j < n - i - 1; j++)
                        if (arr[j] > arr[j + 1])
                        {
                            // Swap temp and arr[i]
                            int temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = temp;
                        }
       
            } 

      static void BubllSort(int[]arr)
        {  // 3 6 5 3 2 
            for (int i = 0;i < arr.Length;i++)
            {
              for(int j=0;j<arr.Length-i-1;j++)
                    if (arr[j] < arr[j+1])
                    {
                        (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                    }
                
            }
        }
        public class BinarySearchTreeNode<T> where T : IComparable<T>
        {
            public T Value { get; set; }
            public BinarySearchTreeNode<T> Left { get; set; }
            public BinarySearchTreeNode<T> Right { get; set; }

            public BinarySearchTreeNode(T value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public class BinarySearchTree<T> where T : IComparable<T>
        {
            public BinarySearchTreeNode<T> Root { get; private set; }

            public BinarySearchTree()
            {
                Root = null;
            }

            public void Insert(T value)
            {
                Root = Insert(Root, value);
            }

            private BinarySearchTreeNode<T> Insert(BinarySearchTreeNode<T> node, T value)
            {
                if (node == null)
                {
                    return new BinarySearchTreeNode<T>(value);
                }
                else if (value.CompareTo(node.Value) < 0)
                {
                    node.Left = Insert(node.Left, value);
                }
                else if (value.CompareTo(node.Value) > 0)
                {
                    node.Right = Insert(node.Right, value);
                }

                return node;
            }

            public bool Search(T Value)
            {
               return Search(this.Root, Value) != null;
            }

            private BinarySearchTreeNode<T> Search(BinarySearchTreeNode<T> Node, T Value)
            {
                if(Node==null || Node.Value.Equals(Value))
                {
                    return Node;
                }
                
                if(Node.Value.CompareTo(Value) < 0)
                {
                   return Search(Node.Left, Value);
                }else
                {
                   return Search(Node.Right, Value);
                }
               
            }
            public void InOrderTraversal()
            {
                InOrderTraversal(Root);
                Console.WriteLine();
            }

            private void InOrderTraversal(BinarySearchTreeNode<T> node)
            {
                if (node != null)
                {
                    InOrderTraversal(node.Left);
                    Console.Write(node.Value + " ");
                    InOrderTraversal(node.Right);
                }
            }

            public void PreOrderTraversal()
            {
                PreOrderTraversal(Root);
                Console.WriteLine();
            }

            private void PreOrderTraversal(BinarySearchTreeNode<T> node)
            {
                if (node != null)
                {
                    Console.Write(node.Value + " ");
                    PreOrderTraversal(node.Left);
                    PreOrderTraversal(node.Right);
                }
            }

            public void PostOrderTraversal()
            {
                PostOrderTraversal(Root);
                Console.WriteLine();
            }

            private void PostOrderTraversal(BinarySearchTreeNode<T> node)
            {
                if (node != null)
                {
                    PostOrderTraversal(node.Left);
                    PostOrderTraversal(node.Right);
                    Console.Write(node.Value + " ");
                }
            }

            // Print the tree visually
            public void PrintTree()
            {
                PrintTree(Root, 0);
            }


            private void PrintTree(BinarySearchTreeNode<T> root, int space)
            {
                int COUNT = 10;  // Distance between levels
                if (root == null)
                    return;

                space += COUNT;
                PrintTree(root.Right, space);

                Console.WriteLine();
                for (int i = COUNT; i < space; i++)
                    Console.Write(" ");
                Console.WriteLine(root.Value);
                PrintTree(root.Left, space);
            }

        }

        static void Main(string[] args)
        {
       
            var BinaryTree = new BinarySearchTree<int>();
            BinaryTree.Insert(45);
            BinaryTree.Insert(15);
            BinaryTree.Insert(79);
            BinaryTree.Insert(90);
            BinaryTree.Insert(10);
            BinaryTree.Insert(55);
            BinaryTree.Insert(12);
            BinaryTree.Insert(20);
            BinaryTree.Insert(50);




            BinaryTree.PrintTree();

            if (BinaryTree.Search(667))
                Console.WriteLine("We Found The Number :)");
            else
                Console.WriteLine("We didnt Found The Number :(");


            Console.Read();


        }

     
        public static void InsertionSort(int[] Arr)
        {
            
                int length = Arr.Length;

                // Iterate through each element starting from index 1
               for(int i=1;i<length;i++)
            {
                int CurrentValue = Arr[i];
                int PrivesIndex = i - 1;

                while (PrivesIndex != 0 && Arr[PrivesIndex]>CurrentValue)
                {
                    Arr[PrivesIndex + 1] = Arr[PrivesIndex];
                    PrivesIndex--;
                }
                Arr[PrivesIndex + 1] = CurrentValue;
            }
            }

        }








    }

