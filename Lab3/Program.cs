using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab3
{
    class Program
    {
        static void PrintVector(double[] vec)
        {
            foreach (var v in vec)
                Console.Write($"{v} ");
            Console.WriteLine();
        }

        [STAThread] //????
        static void Main(string[] args)
        {
            #region
            /*
            using (StreamWriter sw = new StreamWriter(@"D:\Лабораторки\Численные методы\NumericalMethod_Lab3\Lab3\Matrix100.txt"))
            {
                Random r = new Random();
                int size = 100;
                double[,] m = new double[size, size + 1];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        m[i, j] = r.NextDouble() * 10;
                }    
                for (int i = 0; i < size; i++)
                    m[i, size] = r.NextDouble() * 10;

                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        m[i, i] += m[i, j];
                    }

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size + 1; j++)
                        sw.Write(m[i, j].ToString() + " ");
                    sw.WriteLine();
                }
                
            }
            */
            #endregion

            Console.WriteLine("Как вы хотите задать систему?\n (1 - Открыть файл | 2 - Через консоль)");
            int ans = int.Parse(Console.ReadLine());

            IReader reader;
            if (ans == 1)
                reader = new ReaderFromFile();
            else
                reader = new ReaderFromConsole();

            double[,] matrix = reader.Read();

            Console.WriteLine("Введите точность");
            double eps = double.Parse(Console.ReadLine());
            
            ISolver solver = new Solver(new SimpleIeration());
            ISolver solver2 = new Solver(new SeidelMethod());
            double[] solve = solver.GetSolve(matrix, eps);
            double[] solve2 = solver2.GetSolve(matrix, eps);

            //PrintVector(solve);
            //PrintVector(solve2);

            Console.ReadKey();
        }
    }
}
