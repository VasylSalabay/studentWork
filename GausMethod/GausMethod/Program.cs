using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;


namespace GausMethod
{
    class Program
    {
        private static void RandomMatrix(double[,] matrix, int n)
        {
            var random = new Random();
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n + 1; ++j)
                {

                    matrix[i, j] = random.Next(-n * n / 2, n * n / 2);
                }

            }

        }
        private static void PrintMatrix(double[,] matrix, int n)
        {
            for (int i = 0; i < n; ++i)

            {
                for (int j = 0; j < n + 1; ++j)
                {
                    Console.WriteLine(matrix[i, j]);
                }
            }
        }
        private static void SimpleGauss(double[,] matrix, double[] x)

        {
            int n = x.Length;

            for (int i = 0; i < n; i++)
            {
                double maxEl = Math.Abs(matrix[i, i]);
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(matrix[k, i]) > maxEl)
                    {
                        maxEl = Math.Abs(matrix[k, i]);
                        maxRow = k;
                    }
                }

                for (int k = i; k < n + 1; k++)
                {
                    double tmp = matrix[maxRow, k];
                    matrix[maxRow, k] = matrix[i, k];
                    matrix[i, k] = tmp;
                }

                for (int k = i + 1; k < n; k++)
                {
                    double c = -matrix[k, i] / matrix[i, i];
                    for (int j = i; j < n + 1; j++)
                    {
                        if (i == j)
                        {
                            matrix[k, j] = 0;
                        }
                        else
                        {
                            matrix[k, j] += c * matrix[i, j];
                        }
                    }
                }
            }
          //  побудова масиву результатів
            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = matrix[i, n] / matrix[i, i];
                for (int k = i - 1; k >= 0; k--)
                {
                    matrix[k, n] -= matrix[k, i] * x[i];

                }
                
            }
        }

        private static void ParallelGauss(double[,] matrix, double[] x, int threads)
        {
            int n = x.Length;
            var tasks = new Task[threads];

            for (int i = 0; i < n; i++)
            {
                double maxEl = Math.Abs(matrix[i, i]);
                int maxRow = i;
                for (int k = i + 1; k < n; k++)
                {
                    if (Math.Abs(matrix[k, i]) > maxEl)
                    {
                        maxEl = Math.Abs(matrix[k, i]);
                        maxRow = k;
                    }
                }

                for (int t = 0; t < threads; ++t)
                {
                    int tCopy = t;
                    tasks[t] = Task.Run(() =>
                    {
                        for (int k = i + tCopy; k < n + 1; k += threads)
                        {
                            double tmp = matrix[maxRow, k];
                            matrix[maxRow, k] = matrix[i, k];
                            matrix[i, k] = tmp;
                        }
                    });
                }
                Task.WaitAll(tasks);

                for (int t = 0; t < threads; ++t)
                {
                    int tCopy = t;
                    tasks[t] = Task.Run(() =>
                    {
                        for (int k = i + 1 + tCopy; k < n; k += threads)
                        {
                            double c = -matrix[k, i] / matrix[i, i];
                            for (int j = i; j < n + 1; j++)
                            {
                                if (i == j)
                                {
                                    matrix[k, j] = 0;
                                }
                                else
                                {
                                    matrix[k, j] += c * matrix[i, j];
                                }
                            }
                        }
                    });
                }
                Task.WaitAll(tasks);
            }

            for (int i = n - 1; i >= 0; i--)
            {
                x[i] = matrix[i, n] / matrix[i, i];
                for (int k = i - 1; k >= 0; k--)
                {
                    matrix[k, n] -= matrix[k, i] * x[i];
                }
            }
        }
        static void Main(string[] args)
        {
            const int n = 500;

            var matrix = new double[n, n + 1];
            var x = new double[n];

         RandomMatrix(matrix, n);

          //  PrintMatrix(matrix, n);

            Stopwatch stopWatch = new Stopwatch();


            var CopyMatrix = matrix.Clone() as double[,];
            stopWatch.Start();
           SimpleGauss(CopyMatrix, x);
            stopWatch.Stop();
            Console.WriteLine("Gauss without threads " + stopWatch.ElapsedMilliseconds);
            stopWatch.Reset();
           

            for (int i = 4; i < 17; i += 4)
            {
                stopWatch.Start();
                ParallelGauss(matrix, x, i);
                stopWatch.Stop();
                Console.WriteLine("Gauss in " + i + " threads " + stopWatch.ElapsedMilliseconds);
                stopWatch.Reset();
            }


        
    }
    }
}
