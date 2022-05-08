using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6._1
{
    class Program
    { 
        static void Main(string[] args)
        {
            BinaryTree<int, int> tree = new BinaryTree<int, int>(new Node<int, int>(null, 5, 0));
            tree.Add(1, 35);
            tree.Add(2, 1);
            tree.Add(3, 20);
            tree.Add(4, 99);
            tree.Add(5, 17);
            tree.Add(6, 18);
            tree.Add(7, 19);
            tree.Add(8, 31);
            tree.Add(9, 4);
            tree.Add(10, 33);
            tree.Add(11, 25);
            tree.Add(12, 15);
            Console.WriteLine(tree.Remove(5));
        }
    }
}