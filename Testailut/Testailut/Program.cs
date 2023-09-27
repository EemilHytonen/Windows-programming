using System;

namespace Assignment1_Dariush
{
    class Program
    {
        static void Main(string[] args)
        {

            Random r = new Random();

            int numRows = r.Next(1, 5);
            int numColumns = r.Next(1, 5);

            int[,] Matrix1 = new int[numRows, numColumns];
            int[,] Matrix2 = new int[numRows, numColumns];

            for (int i = 0; i < Matrix1.GetLength(0); i++)
                for (int j = 0; j < Matrix1.GetLength(1); j++)

                    Matrix1[i, j] = r.Next(100);


            Console.WriteLine("The content of Matrix1:");

            for (int k = 0; k < Matrix1.GetLength(0); k++)
            {
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                    Console.Write("{0,5}", Matrix1[k, j]);

                Console.WriteLine();
            }


            for (int i = 0; i < Matrix2.GetLength(0); i++)
                for (int j = 0; j < Matrix2.GetLength(1); j++)
                    Matrix1[i, j] = r.Next(100);


            Console.WriteLine("The content of Matrix2:");

            for (int i = 0; i < Matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix1.GetLength(1); j++)
                    Console.Write("{0,5}", Matrix1[i, j]);

                Console.WriteLine();
                // Perform operations 
                for (int k = 0; k < Matrix1.GetLength(0); k++)
                {
                    for (int j = 0; j < Matrix1.GetLength(1); j++)
                    {
                        // Addition
                        Matrix1[k, j] += Matrix2[k, j];

                        Console.WriteLine("The content of Matrix after addition:");

                        for (int k = 0; k < Matrix1.GetLength(0); k++)
                        {
                            for (int j = 0; j < Matrix1.GetLength(1); j++)
                                Console.Write("{0,5}", Matrix1[k, j]);

                            Console.WriteLine();
                        }
                    }










                }
            }
        }
    }
}

