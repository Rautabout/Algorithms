using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneWayList
{

    
    
    public class OneWayList
    {
        public static void Main(string[] args)
        {
            object[] array = { 12, "ff", 234.3, 23, 65, 87 };
            Node head = ArrayToList(array, array.Length);
            Show(head);

            Console.ReadKey();

        }
        public class Node
        {
            public object data;
            public Node next;
            
        };
        
        
        static Node ArrayToList(object []array, int size)
        {
            Node head = null;
            for(int i = 0; i < size; i++)
            {
                head = Add(head, array[i]);
            }
            return head;
        }

        static Node Add(Node head, object data)
        {
            Node temp = new Node
            {
                data = data,
                next = head
            };
            head = temp;
            return head;
        }
        static void Show(Node head)
        {
            while (head != null)
            {
                Console.Write(head.data + ",");
                head = head.next;
            }
        }
        
    }

}
