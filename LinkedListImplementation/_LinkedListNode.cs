using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    public class _LinkedListNode<T>
    {
        internal _LinkedList<T> list;
        internal _LinkedListNode<T> next;
        internal _LinkedListNode<T> prev;
        internal T item;

        public _LinkedListNode(T value)
        {
            this.item = value;
        }

        internal _LinkedListNode(_LinkedList<T> list, T value)
        {
            this.list = list;
            this.item = value;
        }

        public _LinkedList<T> List
        {
            get { return list; }
        }

        public _LinkedListNode<T> Next
        {
            get { return next == null || next == list._head ? null : next; }
        }

        public _LinkedListNode<T> Previous
        {
            get { return prev == null || this == list._head ? null : prev; }
        }

        public T Value
        {
            get { return item; }
            set { item = value; }
        }
    }
}
