using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWayList
{
    class Program
    {
        static void Main(string[] args)
        {
            object[] array = { 12, "ff", 234.3, 23, 65, 87 };
            int size = array.Length;
            Node start = null;

            start = ArrayToList(array, size, start);
            Show(start);
            Console.ReadKey();
        }
        public class Node
        {
            public object data;
            public Node next;
            public Node prev;

        }
        static Node NewNode()
        {
            return new Node();
        }
        static int Show(Node temp)
        {
            Node t = temp;
            if (temp == null)
                return 0;
            else
            {

                while (temp.next != t)
                {
                    Console.Write(temp.data + ",");
                    temp = temp.next;
                }

                Console.Write(temp.data);

                return 1;
            }
        }
        static Node ArrayToList(object[] arr, int size, Node start)
        {
            Node newNode, temp;
            int i;

            for (i = 0; i < size; i++)
            {
                newNode = NewNode();

                newNode.data = arr[i];

                if (i == 0)
                {
                    start = newNode;
                    newNode.prev = start;
                    newNode.next = start;
                }
                else
                {
                    temp = (start).prev;

                    temp.next = newNode;
                    newNode.next = start;
                    newNode.prev = temp;
                    temp = start;
                    temp.prev = newNode;
                }
            }
            return start;
        }
    }

}
