using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace deixtriMethod
{
    class Range
    {
        public int from { get; set; }
        public int to { get; set; }

        public Range(int _from, int _to)
        {
            from = _from;
            to = _to;
        }
    }
    class Program
    {
        public static int[,] RandomFillMatrix(int n)
        {
            Random type = new Random();
            Random r = new Random();
            int a;
            int[,] G = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    //a = type.Next(0,25);
                    //Console.WriteLine(a);
                    if (type.Next(0, 2000) % 2 == 0)
                    {
                        a = 0;
                    }
                    else
                    {
                        a = r.Next(1, 25);
                    }
                    G[i, j] = a;
                    G[j, i] = a;
                }
            }
            return G;
        }
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        public static void Dijkstra(int[,] graph, int source, int verticesCount, int quantityTask)
        {
            int step1 = verticesCount / quantityTask;
            Range range = new Range(0, step1);
            Range[] ranges = new Range[quantityTask];
            ranges[0] = new Range(0, step1);
            for (int i = 1; i < quantityTask; i++)
            {
                ranges[i] = new Range(ranges[i - 1].from + step1, ranges[i - 1].to + step1);
            }

            Task[] tasks = new Task[quantityTask];
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int k = 0; k < quantityTask; k++)
            {
                int h = k;
                tasks[k] = Task.Factory.StartNew(() =>
                {
                    for (int i = ranges[h].from; i < ranges[h].to; i++)
                    {
                        distance[i] = int.MaxValue;
                        shortestPathTreeSet[i] = false;
                    }
                });
            }
            
            Task.WaitAll(tasks);

            distance[source] = 0;

            int step2 = verticesCount / quantityTask;
            Range range2 = new Range(0, step2);
            Range[] ranges2 = new Range[quantityTask];
            ranges[0] = new Range(0, step2);
            for (int i = 1; i < quantityTask - 1; i++)
            {
                ranges[i] = new Range(ranges[i - 1].from + step2, ranges[i - 1].to + step2);

            }
            if (quantityTask != 1)
            {
                int last = quantityTask - 1;
                ranges[last] = new Range(ranges[last - 1].from + step2, ranges[last - 1].to + step2 - 1);

            }

            Task[] tasks2 = new Task[quantityTask];

            for (int k = 0; k < quantityTask; k++)
            {
                int h = k;
                tasks2[k] = Task.Factory.StartNew(() =>
                {
                    for (int i = ranges[h].from; i < ranges[h].to; i++)
                    {
                        int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                        shortestPathTreeSet[u] = true;

                        for (int v = 0; v < verticesCount; ++v)
                            if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                                distance[v] = distance[u] + graph[u, v];
                    }
                });
            }

            Task.WaitAll(tasks2);
        }
            static void Main(string[] args)
        {
            int n = 800;
            int[,] graph = RandomFillMatrix(n);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            Dijkstra(graph, 0, n, 1);
            stopWatch.Stop();
            Console.WriteLine("time in milliseconds: " + stopWatch.ElapsedMilliseconds + " without paralel");
            stopWatch.Reset();

            stopWatch.Start();
            Dijkstra(graph, 0, n, 4);
            stopWatch.Stop();
            Console.WriteLine("time in milliseconds: " + stopWatch.ElapsedMilliseconds + " in " + 4 + " tasks");
            stopWatch.Reset();

            stopWatch.Start();
            Dijkstra(graph, 0, n, 5);
            stopWatch.Stop();
            Console.WriteLine("time in milliseconds: " + stopWatch.ElapsedMilliseconds + " in " + 5 + " tasks");
            stopWatch.Reset();


            stopWatch.Start();
            Dijkstra(graph, 0, n, 100);
            stopWatch.Stop();
            Console.WriteLine("time in milliseconds: " + stopWatch.ElapsedMilliseconds + " in " + 100 + " tasks");
            stopWatch.Reset();


            stopWatch.Start();
            Dijkstra(graph, 0, n, 20);
            stopWatch.Stop();
            Console.WriteLine("time in milliseconds: " + stopWatch.ElapsedMilliseconds + " in " + 20 + " tasks");
            stopWatch.Reset();
        }
    }
}
