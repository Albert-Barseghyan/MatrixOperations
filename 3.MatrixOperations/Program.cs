using System;

namespace _3.MatrixOperations
{
    class Program
    {
        static void Adition()
        {
            int[,] mat1,mat2;
            int n, m, i, j;

            Console.Write("Columns for both matrixes: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Rows for both matrixes: ");
            m = Convert.ToInt32(Console.ReadLine());
            mat1 = new int[n, m]; InputMatrix(ref mat1);
            mat2 = new int[n, m]; InputMatrix(ref mat2);
            Console.WriteLine(); OutputMatrix(mat1); OutputMatrix(mat2);

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write(" {0}", mat1[i, j] + mat2[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void Multiplication()
        {
            int[,] mat1,mat2;
            int n1, n2, m1, m2, i, j, k, R;

            Console.Write("First matrix columns: ");
            n1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("First matrix rows: ");
            m1 = Convert.ToInt32(Console.ReadLine());
            mat1 = new int[n1, m1];
            InputMatrix(ref mat1);

            Console.WriteLine("Secons matrix columns: {0}", m1);
            n2 = m1;
            Console.Write("Second matrix rows: ");
            m2 = Convert.ToInt32(Console.ReadLine());
            mat2 = new int[n2, m2];
            InputMatrix(ref mat2);

            Console.WriteLine(); OutputMatrix(mat1); OutputMatrix(mat2);

            Console.WriteLine("Result");

            for (i = 0; i < n1; i++)
            {
                Console.WriteLine();
                for (j = 0; j < m2; j++)
                {
                    R = mat1[i, 0] * mat2[0, j];
                    for (k = 1; k < m1; k++) R += mat1[i, k] * mat2[k, j];
                    Console.Write("{0} ", R);
                }
            }
            
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
            Console.WriteLine();
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
            int Type;

            Console.WriteLine("For matrix adition type 1.");
            Console.WriteLine("For matrix multiplication type 2.");
            Console.WriteLine("For matrix scalar multiplication type 3.");
            Console.WriteLine("To inverse and transpose the matrix type 4.");
            Console.WriteLine("To determine whether a matrix is orthogonal or not type 5.");
            Console.Write("To find the max and min elements in matrix type 6.\nInput option: ");
            Type = Convert.ToInt32(Console.ReadLine());
           
            switch (Type) 
            {
                case 1: Adition(); break;
                case 2: Multiplication(); break;
                //case 3: ScalarMul(); break;
                //case 4: InverseTranspose(); break;
                //case 5: checkedOrthagonal(); break;
                case 6: MinMax(); break;
            }
            Console.ReadLine();
        }
    }
}
