using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    public class _LinkedList<T>
    {
        internal _LinkedListNode<T> _head;
        internal int count;
        internal int version;
        public _LinkedList()
        {
        }
        public void Add(T value)
        {
            AddLast(value);
        }
        public int Count
        {
            get { return count; }
        }
        public _LinkedListNode<T> First
        {
            get { return _head; }
        }
        public _LinkedListNode<T> Last
        {
            get { return _head == null ? null : _head.prev; }
        }
        public _LinkedListNode<T> AddAfter(_LinkedListNode<T> node, T value)
        {
            
            _LinkedListNode<T> result = new _LinkedListNode<T>(node.list, value);
            return result;
        }
        public _LinkedListNode<T> AddFirst(T value)
        {
            _LinkedListNode<T> result = new _LinkedListNode<T>(this, value);
            if (_head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(_head, result);
                _head = result;
            }
            return result;
        }
        public void AddFirst(_LinkedListNode<T> node)
        {
            if (_head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(_head, node);
                _head = node;
            }
            node.list = this;
        }
        public _LinkedListNode<T> AddLast(T value)
        {
            _LinkedListNode<T> result = new _LinkedListNode<T>(this, value);
            if (_head == null)
            {
                InternalInsertNodeToEmptyList(result);
            }
            else
            {
                InternalInsertNodeBefore(_head, result);
            }
            return result;
        }
        public void AddLast(_LinkedListNode<T> node)
        {
            if (_head == null)
            {
                InternalInsertNodeToEmptyList(node);
            }
            else
            {
                InternalInsertNodeBefore(_head, node);
            }
            node.list = this;
        }
        public void Clear()
        {
            _LinkedListNode<T> current = _head;
            while (current != null)
            {
                _LinkedListNode<T> temp = current;
                current = current.Next;   // use Next the instead of "next", otherwise it will loop forever
            }

            _head = null;
            count = 0;
            version++;
        }
        public bool Contains(T value)
        {
            return Find(value) != null;
        }
        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - index < Count)
            {
                throw new ArgumentException();
            }

            _LinkedListNode<T> node = _head;
            if (node != null)
            {
                do
                {
                    array[index++] = node.item;
                    node = node.next;
                } while (node != _head);
            }
        }
        public _LinkedListNode<T> Find(T value)
        {
            _LinkedListNode<T> node = _head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node.item, value))
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != _head);
                }
                else
                {
                    do
                    {
                        if (node.item == null)
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != _head);
                }
            }
            return null;
        }
        public bool Remove(T value)
        {
            _LinkedListNode<T> node = Find(value);
            if (node != null)
            {
                InternalRemoveNode(node);
                return true;
            }
            return false;
        }

        public void Remove(_LinkedListNode<T> node)
        {
            InternalRemoveNode(node);
        }
        private void InternalInsertNodeToEmptyList(_LinkedListNode<T> newNode)
        {
            newNode.next = newNode;
            newNode.prev = newNode;
            _head = newNode;
            version++;
            count++;
        }
        private void InternalInsertNodeBefore(_LinkedListNode<T> node, _LinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            version++;
            count++;
        }
        internal void InternalRemoveNode(_LinkedListNode<T> node)
        {
            if (node.next == node)
            {
                _head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (_head == node)
                {
                    _head = node.next;
                }
            }
            count--;
            version++;
        }
    }
}
