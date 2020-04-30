using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static int V = 7;//Number of vertexes
        int minDistance(int[] distance,bool[] shortestPathSet)
        {
            int min = int.MaxValue;
            int minIndex = -1;
            for(int vertex = 0; vertex < V; vertex++)
            {
                if (shortestPathSet[vertex] == false && distance[vertex] <= min)
                {
                    min = distance[vertex];
                    minIndex = vertex;
                }
            }
            return minIndex;
        }
        void Print(int[] distance)
        {
            Console.WriteLine("Vertex | Distance");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine("{0} | {1}", i, distance[i]);
            }

        }
        void Dijkstra(int[,] graph, int source)
        {
            int[] distance = new int[V];
            bool[] sptSet = new bool[V];

            for (int i = 0; i < V; i++)
            {
                distance[i] = int.MaxValue;
                sptSet[i] = false;
            }

            distance[source] = 0;

            for (int j = 0; j < V - 1; j++)
            {
                int u = minDistance(distance, sptSet);
                sptSet[u] = true;
                for (int v = 0; v < V; v++)
                {
                    if (!sptSet[v] && graph[u, v] != 0 && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }

                }
            }

            Print(distance);
        }
        static void Main(string[] args)
        {
            int[,] graph = new int[,] {  
                         {0, 0, 0, 3, 0, 0, 7},
                         {0, 0, 2, 0, 4, 0, 1},
                         {0, 2, 0, 4, 1, 2, 3},
                         {3, 0, 4, 0, 5, 3, 3},
                         {0, 4, 1, 5, 0, 1, 2},
                         {0, 0, 2, 3, 1, 0, 2},
                         {7, 1, 3, 3, 2, 2, 0} };
            Program t = new Program();
            t.Dijkstra(graph, 0);
            Console.ReadKey();
        }
    }
}
