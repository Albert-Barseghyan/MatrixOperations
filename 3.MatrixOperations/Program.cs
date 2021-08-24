using System;

namespace _3.MatrixOperations
{
    class Program
    {
        static void Multiplication()
        {
            int[,] mat1,mat2;
            int n1, n2, m1, m2, i, j;

            Console.Write("First matrix columns: ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("First matrix rows: ");
            m1 = Convert.ToInt32(Console.ReadLine());
            mat1 = new int[n1, m1];
            InputMatrix(ref mat1);

            Console.Write("First matrix columns: {0}", m);
            n2 = m1;
            Console.Write("First matrix rows: ");
            m2 = Convert.ToInt32(Console.ReadLine());
            mat2 = new int[n2, m2];
            InputMatrix(ref mat2);

          /*  for (i = 0; i < n3; i++)
            {
                Console.WriteLine();
                for (j = 0; j < m3; j++)
                {
                    c[i][j] = a[i][0] * b[0][j];
                    for (k = 1; k < r; k++) c[i][j] += a[i][k] * b[k][j];
                    System.out.print(c[i][j] + " ");
                }
            }*/
        }

        static void MinMax()
        {

            int[,] mat;
            int n, m, min, max ,i,j;

            Console.Write("Matrix columns: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Matrix rows: ");
            m = Convert.ToInt32(Console.ReadLine());
            mat = new int[n, m];

            InputMatrix(ref mat);
            min = mat[0, 0]; max = min;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (min > mat[i, j]) min = mat[i, j];
                    if (max < mat[i, j]) max = mat[i, j];
                    Console.Write(" {0}", mat[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Min: {0}\nMax: {1}",min,max);

        }

        static void OutputMatrix(in int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int i, j;

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(" {0}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void InputMatrix(ref int[,] matrix)
        {
            Random rand = new Random();
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int i, j;

            Console.WriteLine("Enter matrix elements.");
            Console.Write("For random generation type 1,else type 0: ");
            if (Convert.ToInt32(Console.ReadLine()) == 0)
                for (i = 0; i < n; i++)
                    for (j = 0; j < m; j++)
                    {
                        Console.Write("[{0}][{1}]: ", i, j);
                        matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                    }
            else
                for (i = 0; i < n; i++)
                    for (j = 0; j < m; j++)
                    {
                        matrix[i, j] = rand.Next(-9, 10);
                        Console.WriteLine("[{0}][{1}]: {2}", i, j, matrix[i, j]);                       
                    }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("For matrix adition type 1.");
            Console.WriteLine("For matrix multiplication type 2.");
            Console.WriteLine("For matrix scalar multiplication type 3.");
            Console.WriteLine("To inverse and transpose the matrix type 4.");
            Console.WriteLine("To determine whether a matrix is orthogonal or not type 5.");
            Console.Write("To find the max and min elements in matrix type 6.\nInput option: ");

            //int[,] aaa = new int [2,2];
            // InputMatrix(ref aaa);
            // OutputMatrix(in aaa);
            MinMax();


        }
    }
}
