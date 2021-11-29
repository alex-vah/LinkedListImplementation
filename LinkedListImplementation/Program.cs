using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _LinkedList<int> linkedList = new _LinkedList<int> ();
            int[] arr = new int[56];
            linkedList.AddFirst(5);
            linkedList.AddLast(156);
            linkedList.Add(12);
            linkedList.AddAfter(linkedList.First.Next, 0);
            linkedList.Remove(linkedList.First.Next.Next);
            linkedList.Contains(5);
            linkedList.CopyTo(arr, 4);
            linkedList.Find(12);
            Console.WriteLine(linkedList.First);
            Console.WriteLine(linkedList.Last);
            linkedList.Clear();
        }
    }
}
