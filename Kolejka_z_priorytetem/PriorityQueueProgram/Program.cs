using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace PriorityQueueProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue(4); //size of queue
            queue.Enqueue(3.6,1);
            queue.Enqueue("kjk",2);
            queue.Enqueue(true,7);
            queue.Enqueue(2.34,8);
            queue.Peek();
            queue.PrintValues();
            queue.Dequeue();

            queue.PrintValues();
            queue.Peek();
            queue.Enqueue(2.344,2);
            queue.PrintValues();

            queue.Enqueue(2.34,5);

            Console.ReadKey();
        }
    }
    public class Queue
    {
        private static object[,] queue;
        private static int start, end, size;

        public Queue(int n)
        {
            size = n;
            queue = new object[size,2];
            start = end = 0;
        }
        public void Enqueue(object data,int priority)
        {
            if (end == size)
            {
                Console.WriteLine("Queue is full");
                return;
            }
            else
            {
                queue[end, 0] = data;
                queue[end, 1] = priority;
                end++;

            }



            return;
        }
        private static void OrderByPriority<T>(T[,] queue)
        {
            int length = queue.GetLength(0);
            T[] dim1 = new T[length];
            T[] dim2 = new T[length];
            for (int i = 0; i < size; i++)
            {
                dim1[i] = queue[i, 0];
                dim2[i] = queue[i, 1];
            }

            Array.Sort(dim2, dim1);
            for (int i = 0; i < length; i++)
            {
                queue[i, 0] = dim1[i];
                queue[i, 1] = dim2[i];

            }
            
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
                    queue[i,0] = queue[i + 1,0];
                    queue[i, 1] = queue[i + 1, 1];

                }
                queue[end - 1,0] = null;
                queue[end - 1,1] = 11;

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
                Console.WriteLine("Peek Item: {0} Priority: {1}", queue[0, 0], queue[0, 1]);
            }
            return;
        }
        public void PrintValues()
        {
            OrderByPriority(queue);

            for (int i = 0; i < size; i++)
            {
                if (queue[i, 0] != null)
                {
                    Console.WriteLine("Item: {0} Priority: {1}", queue[i, 0], queue[i, 1]);
                }

            }
            Console.WriteLine();
        }

    }
}
