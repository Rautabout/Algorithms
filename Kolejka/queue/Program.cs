using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(4); //size of queue
            queue.Enqueue(3);
            queue.Enqueue("kjk");
            queue.Enqueue(true);
            queue.Enqueue(2.34);
            queue.Peek();
            queue.PrintValues();
            queue.Dequeue();

            queue.PrintValues();
            queue.Peek();
            queue.Enqueue(2.344);
            queue.PrintValues();

            queue.Enqueue(2.34);

            Console.ReadKey();
        }
    }
    public class Queue
    {
        private static object[] queue;
        private static int start, end, size;
        public Queue(int n)
        {
            size = n;
            queue = new object[size];
            start = end = 0;
        }
        public void Enqueue(object data)
        {
            if (end == size)
            {
                Console.WriteLine("Queue is full");
                return;
            }
            else
            {
                queue[end] = data;
                end++;
            }
            return;
        }
        public void Dequeue()
        {
            if (start == end)
            {
                Console.WriteLine("Queue is empty!");
                return;
            }
            else
            {
                for (int i = 0; i < end - 1; i++)
                {
                    queue[i] = queue[i + 1];
                }
                queue[end-1] = null;
                end--;
            }
            return;
        }
        public void Peek()
        {
            if (start == end)
            {
                Console.WriteLine("Queue is empty!");
                return;
            }
            else
            {
                Console.WriteLine(queue[start]);
            }
            return;
        }
        public void PrintValues()
        {
            for(int i = 0; i < queue.Length; i++)
            {
                if (queue[i] != null)
                {
                    Console.WriteLine("Item: {0} ", queue[i]);
                }
            }
            Console.WriteLine();
        }

    }
}
