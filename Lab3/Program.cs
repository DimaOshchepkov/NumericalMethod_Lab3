using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("Как вы хотите задать систему?\n (1 - Открыть файл | 2 - Через консоль)");
            int ans = int.Parse(Console.ReadLine());

            IReader reader;
            if (ans == 1)
                reader = new ReaderFromFile();
            else
                reader = new ReaderFromConsole();

            double[,] matrix = reader.Read();

            Console.WriteLine("Введите точность");
            double eps = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            ISolver solver = new Solver(new SimpleIeration());
            double[] solve = solver.GetSolve(matrix, 1e-6);

            PrintVector(solve);

            Console.ReadKey();
        }
    }
}
