using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace floydMethod
{

    partial class Matrix
    {
        int colNumb;
        int rowNumb;
        double[,] matrix;

        public Matrix(int rows, int cols)
        {
            colNumb = cols;
            rowNumb = rows;

            matrix = new double[rows, cols];

        }

        public Matrix(Matrix copyMatrix)
        {
            rowNumb = copyMatrix.rowNumb;
            colNumb = copyMatrix.colNumb;

            matrix = new double[rowNumb, colNumb];
            //for algorithm of Floyd next row have to be commented.
            //SetSize(copyMatrix.rowNumb);

            for (int i = 0; i < rowNumb; i++)
            {
                for (int j = 0; j < colNumb; j++)
                {
                    matrix[i, j] = copyMatrix.matrix[i, j];
                    //next is only for Floyd.
                    if (i == j) matrix[i, j] = 0;
                }
            }
        }

        public void OutputMatrix()
        {
            for (int i = 0; i < rowNumb; i++)
            {
                for (int j = 0; j < colNumb; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void createMatrix()
        {
            var rand = new Random();

            for (int i = 0; i < rowNumb; i++)
            {
                for (int j = 0; j < colNumb; j++)
                {
                    matrix[i, j] = rand.Next(-1, 10);
                }
            }
        }

        private void SetSize(int size)
        {
            rowNumb = size;
            colNumb = size + 1;

            matrix = new double[rowNumb, colNumb];
        }




    }
    partial class Matrix
    {
        public class FloydAlgorithm
        {
            Matrix startedMatrix;
            int size;

            public FloydAlgorithm(int _size)
            {
                size = _size;
                startedMatrix = new Matrix(_size, _size);
                startedMatrix.createMatrix();
            }

            public void FloydAlgSimple()
            {
                var resultedMatrix = new Matrix(startedMatrix);
                var previousMatrix = new Matrix(startedMatrix);

                //  Console.WriteLine("matrix 0 :");
                // resultedMatrix.OutputMatrix();

                for (int k = 0; k < size; k++)
                {
                    for (int i = 0; i < size; i++)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            if (previousMatrix.matrix[i, j] == -1) resultedMatrix.matrix[i, j] = -1;

                            resultedMatrix.matrix[i, j] = Math.Min(previousMatrix.matrix[i, j], previousMatrix.matrix[i, k] + previousMatrix.matrix[k, j]);
                        }
                    }
                    //  Console.WriteLine($"matrix {k} : ");
                    previousMatrix = new Matrix(resultedMatrix);
                    //  resultedMatrix.OutputMatrix();
                }
            }

            public void FloydAlgParallel(int threadsNumber)
            {
                var resultedMatrix = new Matrix(startedMatrix);
                var previousMatrix = new Matrix(startedMatrix);

                for (int k = 0; k < size; k++)
                {
                    Thread[] threads = new Thread[threadsNumber];
                    for (int t = 0; t < threadsNumber; t++)
                    {
                        var upperRowNumb = size / threadsNumber * t;
                        var lowerRowNumb = size / threadsNumber * (t + 1);

                        if (t == (threadsNumber - 1))
                        {
                            lowerRowNumb = size;
                        }

                        threads[t] = new Thread(() =>
                        {
                            for (int i = upperRowNumb; i < lowerRowNumb; i++)
                            {
                                for (int j = 0; j < size; j++)
                                {
                                    if (previousMatrix.matrix[i, j] == -1) resultedMatrix.matrix[i, j] = -1;
                                    resultedMatrix.matrix[i, j] = Math.Min(previousMatrix.matrix[i, j], previousMatrix.matrix[i, k] + previousMatrix.matrix[k, j]);
                                }
                            }
                        });

                    }

                    previousMatrix = new Matrix(resultedMatrix);

                }

            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int size = 400;

                int threadsNumber = 32;

                Matrix.FloydAlgorithm floyd = new Matrix.FloydAlgorithm(size);


                // var matrixA = new Matrix(size);
                // matrixA.createMatrix();

                // simple solution
                Stopwatch stopwatch_simple = new Stopwatch();
                stopwatch_simple.Start();
                floyd.FloydAlgSimple();
                stopwatch_simple.Stop();
                Console.WriteLine($"Simple solution time: {stopwatch_simple.ElapsedMilliseconds} ;");

                // parallel solution
                Stopwatch stopwatch_parallel = new Stopwatch();
                stopwatch_parallel.Start();
                floyd.FloydAlgParallel(threadsNumber);
                stopwatch_parallel.Stop();
                Console.WriteLine($"Parallel solution time: {stopwatch_parallel.ElapsedMilliseconds} ;");

                /*
                Matrix.PrintSolution(XSimple);
                Console.WriteLine("----------------------");
                Matrix.PrintSolution(XParallel);
                */

               

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }
    }
    }

