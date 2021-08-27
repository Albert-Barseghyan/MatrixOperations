using System;

namespace _3.MatrixOperations
{
    class Program
    {
        static void Inverse()
        {
            int[,] mat,A;
            int n,D,i,j,a,b,x,y;

            Console.Write("Dimensions for matrix: ");
            n = Convert.ToInt32(Console.ReadLine());
            mat = new int[n, n]; A = new int[n-1, n-1]; InputMatrix(ref mat);
            Console.WriteLine("the matrix"); OutputMatrix(mat);

            D = Determinant(mat);
            if (D == 0) { Console.WriteLine("Error,Determinant = 0");return; }

            for (a = 0; a < n; a++)
            {
                Console.WriteLine("\n");
                for (b = 0; b < n; b++)
                {
                    //minor = new int[n - 1, n - 1];
                    for (i = 0; i < n - 1; i++)
                    {
                        x = i >= a ? 1 : 0;
                        for (j = 0; j < n - 1; j++)
                        {
                            y = j >= b ? 1 : 0;
                            A[i, j] = mat[j + y, i + x];
                        }
                    } 
                    Console.Write("{1}/{0}  ", D ,Determinant(A) * (int)Math.Pow(-1, 2 + a + b));
                }
            } 
        }

        static void CheckOrthagonal()
        {
            int[,] mat;
            int n, m;

            Console.Write("Columns for matrix: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Rows for matrix: ");
            m = Convert.ToInt32(Console.ReadLine());
            mat = new int[n, m]; InputMatrix(ref mat);
            Console.WriteLine("the matrix"); OutputMatrix(mat);
            
            Console.Write("The matrix is ");
            if (Determinant(Multiplication(Transpose(mat), mat)) != 1) Console.Write("not ");
            Console.WriteLine("orthagonal.");
        }

        static void Transpose()
        {
            int[,] mat, Trans;
            int n, m;

            Console.Write("Columns for matrix: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Rows for matrix: ");
            m = Convert.ToInt32(Console.ReadLine());
            mat = new int[n, m]; InputMatrix(ref mat); 
            Console.WriteLine("the matrix"); OutputMatrix(mat);
            Trans = new int[m, n];
            Trans = Transpose(mat);
            Console.WriteLine("transposed matrix");
            OutputMatrix(Trans);

        }

        static int[,] Transpose(in int[,] Trans)
        {
            int[,] mat;
            int n, m, i, j;

            n = Trans.GetLength(0);
            m = Trans.GetLength(1);
            mat = new int[m, n];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    mat[j, i] = Trans[i, j];
                }
            }
            return mat;
        }

        static int Determinant(int[,] mat)
        {
            int[,] minor;
            int i, j, k, n;
            int res = 0;

            n = mat.GetLength(0);
            if (n != 1)
            {
                for (k = 0; k < n; k++)
                {
                    minor = new int[n - 1, n - 1];
                    for (i = 0; i < n - 1; i++)
                    {
                        for (j = 0; j < n - 1; j++)
                        {
                            minor[i, j] = j >= k ? mat[i + 1, j + 1] : mat[i + 1, j];
                        }
                    }
                    res += mat[0, k] * Determinant(minor) * (int)Math.Pow(-1, 2 + k);
                }
                return res;
            }
            else
                return mat[0,0];//(mat[0,0] * mat[1,1] - mat[0,1] * mat[1,0]);
        }

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
                    Console.Write("{0} ", mat1[i, j] + mat2[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void ScalarMul() 
        {
            int[,] mat;
            int n, m, i, j, A;

            Console.Write("Matrix columns: ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Matrix rows: ");
            m = Convert.ToInt32(Console.ReadLine());
            mat = new int[n, m];
            InputMatrix(ref mat);
            Console.WriteLine(); OutputMatrix(mat);
            Console.Write("Multyply with: ");
            A = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Console.Write("{0} ", mat[i, j] * A);
                }
                Console.WriteLine();
            }
        }

        static void Multiplication()
        {
            int[,] mat1,mat2;
            int n1, n2, m1, m2;

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
            OutputMatrix(Multiplication(mat1, mat2));
            
        }

        static int[,] Multiplication(in int [,] mat1, in int[,] mat2)
        {
            int[,] res;
            int n1, n2, m1, m2, i, j, k;
            n1 = mat1.GetLength(0);
            m1 = mat1.GetLength(1);n2 = m1;
            m2 = mat2.GetLength(1);
            res = new int[n1, m2];
            //Console.WriteLine(res[0,0]);
            for (i = 0; i < n1; i++)
            {
                for (j = 0; j < m2; j++)
                {
                    res[i,j] = mat1[i, 0] * mat2[0, j];
                    for (k = 1; k < m1; k++) res[i,j] += mat1[i, k] * mat2[k, j];
                }
            }
            return res;
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
            Console.WriteLine("To transpose the matrix type 4.");
            Console.WriteLine("To inverse the matrix type 5.");
            Console.WriteLine("To determine whether a matrix is orthogonal or not type 6.");
            Console.Write("To find the max and min elements in matrix type 7.\nInput option: ");
            Type = Convert.ToInt32(Console.ReadLine());
           
            switch (Type) 
            {
                case 1: Adition(); break;
                case 2: Multiplication(); break;
                case 3: ScalarMul(); break;
                case 4: Transpose(); break;
                case 5: Inverse(); break; 
                case 6: CheckOrthagonal(); break;
                case 7: MinMax(); break;
            }
            Console.ReadLine();
        }
    }
}
