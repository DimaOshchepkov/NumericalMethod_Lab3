using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class GetterMapping
    {
        public double[,] GetMapping(double[,] matrix)
        {
            double[,] mapping = new double[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy(matrix, mapping, matrix.Length);

            for (int i = 0; i < mapping.GetLength(0); i++)
            {
                for (int j = 0; j < mapping.GetLength(1); j++)
                    if (i != j && j != mapping.GetLength(1) - 1)
                        mapping[i, j] = -mapping[i, j] / mapping[i, i];
                    else if (i != j && j == mapping.GetLength(1) - 1)
                        mapping[i, j] = mapping[i, j] / mapping[i, i];
            }

            for (int i = 0; i < mapping.GetLength(0); i++)
                mapping[i, i] = 0;

            return mapping;
        }
    }
}
