using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task_10._7
{
    class BinarySearchTree<T>
    {
        private Node<T> root;
        private int count;
        private IComparer<T> MyComparer { get; set; }

        public BinarySearchTree(IComparer<T> comparer)
        {
            MyComparer = comparer;
        }

        public void Add(T value)
        {
            if (value == null)
                throw new NullReferenceException("Value must ve not null");
            count++;
            if (root == null)
            {
                root = new Node<T>(value);
            }
            else
            {
                AddTo(root, value);
            }
        }

        public void AddRange(IEnumerable<T> values)
        {
            if (values == null)
                throw new NullReferenceException("You sent null");

            foreach (var value in values)
            {
                Add(value);
            }
        }


        private void AddTo(Node<T> node, T value)
        {
            if (MyComparer.Compare(value, node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Left, value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(value);
                }
                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public bool Contains(T value)
        {
            Node<T> parent;
            return FindWithParent(value,out parent) != null;
        }

        private Node<T> FindWithParent(T value, out Node<T> parent)
        {
            Node<T> current = root;
            parent = null;
            while (current != null)
            {
                var result = MyComparer.Compare(current.Value, value);
                if (result > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }

        public int Count()
        {
            return count;
        }

        public void Remove(T value)
        {
            Node<T> parent;
            var current = FindWithParent(value, out parent);
            if (current == null)
                throw new InvalidOperationException("There not this value in tree");
            count--;

            if (current.Right == null)
            {
                if (parent == null)
                {
                    root = current.Left;
                }
                else
                {
                    var result = MyComparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                    {
                        parent.Left = current.Left;
                    }
                    else
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;

                if (parent == null)
                {
                    root = current.Right;
                }
                else
                {
                    var result = MyComparer.Compare(parent.Value, current.Value); 
                    if (result > 0)
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;
                    }
                }
            }
            else
            {
                Node<T> leftmost = current.Right.Left;
                Node<T> leftmostParent = current.Right;

                while (leftmost.Left != null)
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;

                leftmost.Left = current.Left;
                leftmost.Right = current.Right;

                if (parent == null)
                {
                    root = leftmost;
                }
                else
                {
                    var result = MyComparer.Compare(parent.Value, current.Value);
                    if (result > 0)
                    {
                        parent.Left = leftmost;
                    }
                    else if (result < 0)
                    {
                        parent.Right = leftmost;
                    }
                }
            }
        }

        public void Clear()
        {
            root = null;
            count = 0;
        }

        public IEnumerable<T> PreOrderTraversal()
        {
            var stack = new Stack<Node<T>>();
            stack.Push(root);
            var curCount = count;
            while (curCount > 0)
            {
                var node = stack.Pop();

                yield return node.Value;

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }

                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
                curCount--;

            }
        }

        public IEnumerable<T> PostOrderTraversal()
        {
            var stack = new Stack<Node<T>>();
            Node<T> lastNode = null;
            var node = root;
            while (stack.Count > 0 || node != null) 
            {
                
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    var peek = stack.Peek();
                    if ((peek.Right != null) && (lastNode != peek.Right))
                    {
                        node = peek.Right;
                    }
                    else
                    {
                        yield return peek.Value;
                        lastNode = stack.Pop();
                    }
                }

            }

        }

        public IEnumerable<T> InOrderTraversal()
        {
            var stack = new Stack<Node<T>>();
            var node = root;
            while (stack.Count > 0 || node != null)
            {
                if (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }
                else
                {
                    node = stack.Pop();
                    yield return node.Value;
                    node = node.Right;
                }
            }
        }
    }
}
