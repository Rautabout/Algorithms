using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack stack = new Stack(4);
            stack.Peek();

            stack.Push(3);
            stack.Push(7);
            stack.Push("fa");
            stack.Push(2.5);
            stack.Capacity();
            stack.Pop();
            stack.Capacity();

            stack.PrintValues();

            stack.Push("y");
            stack.Capacity();
            stack.Push("fa");
            stack.Push("fa");

            stack.PrintValues();
            stack.Capacity();

            stack.Peek();

            Console.ReadKey();
        }
    }
    public class Stack
    {
        private static object[] stack;
        private static int top, size,stackCount;
        public Stack(int n)
        {
            size = n;
            stack = new object[size];
            top = -1;
        }
        public void Push(object data)
        {
            if ((top + 1) == size)
            {
                Array.Resize(ref stack, ++size);
            }
            top++;
            stack[top] = data;
        
            
        }
        public object Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack empty");
                return false;
            }
            else
            {
                object objectPopped = stack[top];
                Console.WriteLine("Object popped:{0}", objectPopped);
                top--;
                return objectPopped;
            }
        }
        public object Peek()
        {
            if (top == -1)
            {
                Console.WriteLine("Stack empty");
                return false;
            }
            else
            {
                object objectPeeked = stack[top];
                Console.WriteLine("Object peeked:{0}", objectPeeked);
                return objectPeeked;
            }
        }
        public void PrintValues()
        {
            for (int i = top; i > -1; i--)
            {
                if (stack[i] != null)
                {
                    Console.WriteLine("Item: {0} ", stack[i]);
                }
            }
            Console.WriteLine();
        }
        public int Capacity()
        {
            stackCount = 0;

            for (int i = top; i > -1; i--)
            {
                stackCount++;
            }
            Console.WriteLine("Size: {0}", stackCount);
            return stackCount;
        }
    }
}
