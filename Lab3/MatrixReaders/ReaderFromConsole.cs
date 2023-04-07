using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    internal class ReaderFromConsole : IReader
    {
        double[,] IReader.Read()
        {
            Console.WriteLine("Input size");
            int size = int.Parse(Console.ReadLine());
            double[,] matrix = new double[size, size + 1];
            for (int i = 0; i < size; i++)
            {
                string[] row = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < size + 1; j++)
                    matrix[i, j] = Convert.ToDouble(row[j]);
            }

            return matrix;
        }


    }
}
