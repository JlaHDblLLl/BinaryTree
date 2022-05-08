using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6._1
{
    public class BinaryTree<K, T> where K : IComparable<K>
    {
		Node<K, T> Root { get; set; }

		public BinaryTree(Node<K,T> node)
        {
			Root = node;
        }

		public bool Add(T value, K key)
        {
			if (Find(key) != null) return false;
			return _add(this.Root, new Node<K, T>(null, key, value));
        }

        private bool _add(Node<K,T> root, Node<K ,T> node)
        {
            if (node.Key.CompareTo(root.Key) < 0)
            {
                if (root.Left == null)
                {
                    root.Left = new Node<K,T>(root, node.Key, node.Value);
					return true;
				}
                else
                {
                    _add(root.Left, node);
                }
            }
            else
            {
				if (root.Right == null)
				{
					root.Right = new Node<K, T>(root, node.Key, node.Value);
					return true;
				}
				else
				{
					_add(root.Right, node);
				}
            }
			return false; 
        }

		public Node<K, T>? Find(K key)
        {
			return _find(this.Root, key);
        }
        public Node<K,T>? _find(Node<K,T> root, K key)
        {
			if (root == null)
			{ 
				return null;
			}
			
			if (root.Key.CompareTo(key) == 0)
            {
                return root;
            }
            else if (key.CompareTo(root.Key) < 0)
            {
				if (root.Left != null)
				{
					return _find(root.Left, key);
				}
            }
            else
            {
				if (root.Right != null)
				{
					return _find(root.Right, key);
				}
			}
			return null;
        }

		public bool Remove(K key)
		{
			Node<K, T>? tree_del = _find(this.Root, key);
			if (tree_del == null)
			{
				return false;
			}
			Node<K, T>? min_of_tree;

			//Удаление корня
			if (tree_del == this.Root)
			{
				if (tree_del.Right != null)
				{
					min_of_tree = tree_del.Right;
				}
				else min_of_tree = tree_del.Left;

				while (min_of_tree.Left != null)
				{
					min_of_tree = min_of_tree.Left;
				}
				T temp_v = min_of_tree.Value;
				K temp_k = min_of_tree.Key;
				this.Remove(min_of_tree.Key);
				tree_del.Value = temp_v;
				tree_del.Key = temp_k;


				return true;
			}

			//Удаление листьев
			if (tree_del.Left == null && tree_del.Right == null && tree_del.Parent != null)
			{
				if (tree_del == tree_del.Parent.Left)
					tree_del.Parent.Left = null;
				else
				{
					tree_del.Parent.Right = null;
				}
				return true;
			}

			//Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
			if (tree_del.Left != null && tree_del.Right == null)
			{
				tree_del.Left.Parent = tree_del.Parent;
				if (tree_del == tree_del.Parent.Left)
				{
					tree_del.Parent.Left = tree_del.Left;
				}
				else if (tree_del == tree_del.Parent.Right)
				{
					tree_del.Parent.Right = tree_del.Left;
				}
				return true;
			}

			//Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
			if (tree_del.Left == null && tree_del.Right != null)
			{
				tree_del.Right.Parent = tree_del.Parent;
				if (tree_del == tree_del.Parent.Left)
				{
					tree_del.Parent.Left = tree_del.Right;
				}
				else if (tree_del == tree_del.Parent.Right)
				{
					tree_del.Parent.Right = tree_del.Right;
				}
				return true;
			}

			//Удаление узла, где поддеревья с обеих сторон
			if (tree_del.Right != null && tree_del.Left != null)
			{
				min_of_tree = tree_del.Right;

				while (min_of_tree.Left != null)
				{
					min_of_tree = min_of_tree.Left;
				}

				//Если самый левый элемент является первым потомком
				if (min_of_tree.Parent == tree_del)
				{
					min_of_tree.Left = tree_del.Left;
					tree_del.Left.Parent = min_of_tree;
					min_of_tree.Parent = tree_del.Parent;
					if (tree_del == tree_del.Parent.Left)
					{
						tree_del.Parent.Left = min_of_tree;
					}
					else if (tree_del == tree_del.Parent.Right)
					{
						tree_del.Parent.Right = min_of_tree;
					}
					return true;
				}
				//Если самый левый элемент НЕ является первым потомком
				else
				{
					if (min_of_tree.Right != null)
					{
						min_of_tree.Right.Parent = min_of_tree.Parent;
					}
					min_of_tree.Parent.Left = min_of_tree.Right;
					min_of_tree.Right = tree_del.Right;
					min_of_tree.Left = tree_del.Left;
					tree_del.Left.Parent = min_of_tree;
					tree_del.Right.Parent = min_of_tree;
					min_of_tree.Parent = tree_del.Parent;
					if (tree_del == tree_del.Parent.Left)
					{
						tree_del.Parent.Left = min_of_tree;
					}
					else if (tree_del == tree_del.Parent.Right)
					{
						tree_del.Parent.Right = min_of_tree;
					}

					return true;
				}
			}
			return false;
		}
	}
}
