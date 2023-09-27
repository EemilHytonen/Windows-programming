/*
Write an application in C# which initializes two matrices randomly and calculates the sum, 
subtraction and multiplication of them and prints the result to the standard output device. 
The application should also determine the dimensions of matrices randomly, 
but it should take care that generated matrices have proper dimensions to go through basic operations. 
Matrices for addition and subtraction do not need to be the same as the ones for multiplication operation.

e2101439 Eemil Hytönen

*/

using System;

namespace Assignment_1
{
    class Matrix
    {
        //Variables always private
        private int[][] matrix;
        private int rows;
        private int cols;

        public Matrix(int rows, int cols)
        {
            //Create a matrix function. The number of rolw and columns is randomized on lines 131 and 132. Currently they are set between 1-4. 
            this.rows = rows;
            this.cols = cols;
            matrix = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new int[cols];
            }
        }

        public void FillRandomValues()
        {
            //Function to fill our generated matrix with random values (next 10 values so 0-9)
            Random r = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] = r.Next(10);
                }
            }
        }

        public void PrintMatrix()
        {
            //Function to print our matrix
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void Subtract(Matrix otherMatrix)
        {
            //This just checks if the matrix dimensions match at he sart of every math function
            if (rows != otherMatrix.rows || cols != otherMatrix.cols)
            {
                Console.WriteLine("Matrices must have the same dimensions for subtraction.");
                return;
            }
            //Loops through our matrixes and subtracts i values and j values and sets the new value to the result
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] -= otherMatrix.matrix[i][j];
                }
            }
        }

        public void Add(Matrix otherMatrix)
        {
            if (rows != otherMatrix.rows || cols != otherMatrix.cols)
            {
                Console.WriteLine("Matrices must have the same dimensions for addition.");
                return;
            }
            //Loops through our matrixes and adds i values and j values and sets the new value to the result
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i][j] += otherMatrix.matrix[i][j];
                }
            }
        }

        public void Multiply(Matrix otherMatrix)
        {
            if (cols != otherMatrix.rows)
            {
                Console.WriteLine("Matrix multiplication not possible due to invalid dimensions.");
                return;
            }

            //Multiplication function really starts here. First we create a result matrix 

            int[][] result = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                result[i] = new int[otherMatrix.cols];

                for (int j = 0; j < otherMatrix.cols; j++)
                {
                    result[i][j] = 0;

                    //Here is the actual calculations for the new matrix (called result)

                    for (int k = 0; k < cols; k++)
                    {
                        result[i][j] += matrix[i][k] * otherMatrix.matrix[k][j];
                    }
                }
            }

            //After the calculations we update our matrix with the result matrix while alos updating the numbers of colums as needed

            matrix = result;
            cols = otherMatrix.cols;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //Basic main here we call our functions 

            Random r = new Random();

            int rows = r.Next(2, 6);
            int cols = r.Next(2, 6);

            Matrix matrix1 = new Matrix(rows, cols);
            Matrix matrix2 = new Matrix(rows, cols); //Generates 2nd matrix based on the dimensions of the first randomly generated matrix so they should match (there is failsafe/check for this in the functions)

            //I'll comment only one of these but all parts work similiarly

            Console.WriteLine("Random matrix 1 is:"); //Writes "martix X is" to console
            matrix1.FillRandomValues(); //Calls function to fill our generated matrix with random values
            matrix1.PrintMatrix(); //Calls function to print our randomly fileld matrix to console

            Console.WriteLine("Random matrix 2 (matching dimensions) is:");
            matrix2.FillRandomValues();
            matrix2.PrintMatrix();

            Console.WriteLine("Subtracting matrix 2 from matrix 1:");
            matrix1.Subtract(matrix2);
            matrix1.PrintMatrix();

            Console.WriteLine("Adding matrix 2 to matrix 1:");
            matrix1.Add(matrix2);
            matrix1.PrintMatrix();

            //Multiplication doesn't have to use the same matrixes as sum/subtract

            int cols2 = r.Next(1, 5); //Random number of columns between 1 and 4 for matrix multiplication
            Matrix matrix3 = new Matrix(cols, cols2);
            Matrix matrix4 = new Matrix(cols2, cols2); //Generates 4th matrix based on the dimensions of the first randomly generated matrix so they should match (there is failsafe/check for this in the functions)

            Console.WriteLine("Random matrix 3 for multiplication is:");
            matrix3.FillRandomValues();
            matrix3.PrintMatrix();

            Console.WriteLine("Random matrix 4 (matching dimensions for multiplication) is:");
            matrix4.FillRandomValues();
            matrix4.PrintMatrix();

            Console.WriteLine("Multiplying matrix 3 by matrix 4:");
            matrix3.Multiply(matrix4);
            matrix3.PrintMatrix();
        }
    }
}

