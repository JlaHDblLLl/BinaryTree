using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_6._1
{
    public class Node<K, T> where K : IComparable<K>
    {
        public K Key { get; set; }
        public Node<K, T>? Parent { get; set; }
        public Node<K, T>? Left { get; set; }
        public Node<K, T>? Right { get; set; }
        public T Value { get; set; }

        public Node(Node<K,T>? parent, K key, T value)
        {
            this.Key = key;
            this.Value = value;
            Parent = parent;
            Left = null;
            Right = null;

        }
    }
}
