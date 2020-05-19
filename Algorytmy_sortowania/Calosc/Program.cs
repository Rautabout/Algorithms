using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calosc
{
    class Program
    {
        
        static void Main(string[] args)
        {
          
            SmallDataSort();
            MiddleDataSort();
            BigDataSort();
            Console.ReadKey();


        }
        static void SmallDataSort()
        {
            Console.WriteLine("Small Data");
            int size = 10;
            Algorithms algorithm = new Algorithms();

            int[] arr = new int[size];
            ArrayData(arr, size);

            Stopwatch stopwatch = Stopwatch.StartNew();
            algorithm.BubbleSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time of bubblesort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.QuickSort(arr,0,arr.Length-1);
            stopwatch.Stop();
            Console.WriteLine("Time of quicksort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.HeapSort(arr,  arr.Length );
            stopwatch.Stop();
            Console.WriteLine("Time of heapsort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.ShellSort(arr, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time of shellsort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.MergeSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time of mergesort: " + stopwatch.Elapsed.ToString());

        }
        static void MiddleDataSort()
        {
            Console.WriteLine("Middle Data");
            int size = 1000;
            Algorithms algorithm = new Algorithms();
            int[] arr = new int[size];
            ArrayData(arr, size);
            Stopwatch stopwatch = Stopwatch.StartNew();
            algorithm.BubbleSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time of bubblesort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.QuickSort(arr, 0, arr.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time of quicksort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.HeapSort(arr, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time of heapsort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.ShellSort(arr, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time of shellsort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.MergeSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time of mergesort: " + stopwatch.Elapsed.ToString());

        }
        static void BigDataSort()
        {
            Console.WriteLine("Big Data");
            int size = 100000;
            Algorithms algorithm = new Algorithms();
            int[] arr = new int[size];
            ArrayData(arr, size);
            Stopwatch stopwatch = Stopwatch.StartNew();

            algorithm.BubbleSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time of bubblesort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.QuickSort(arr, 0, arr.Length - 1);
            stopwatch.Stop();
            Console.WriteLine("Time of quicksort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.HeapSort(arr, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time of heapsort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.ShellSort(arr, arr.Length);
            stopwatch.Stop();
            Console.WriteLine("Time of shellsort: " + stopwatch.Elapsed.ToString());

            ArrayData(arr, size);
            stopwatch = Stopwatch.StartNew();
            algorithm.MergeSort(arr);
            stopwatch.Stop();
            Console.WriteLine("Time of mergesort: " + stopwatch.Elapsed.ToString());

        }
        static void ArrayData(int[] arr, int arrSize)
        {
            Random random = new Random();
            for (int i = 0; i < arrSize; i++) {
                arr[i] = random.Next();
            }
        }
        
    }
}
