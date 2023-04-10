using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class GetterAlpha
    {

        IMetric metric;



        public double GetAlpha(double[,] matrix, IMetric metric)
        {
            if (metric is ChebyshevMetric)
            {
                double maxSumColumn = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double sumAbsColumn = 0;
                    for (int j = 0; j < matrix.GetLength(0); j++)
                        sumAbsColumn += Math.Abs(matrix[j, i]);

                    maxSumColumn = Math.Max(maxSumColumn, sumAbsColumn);
                }
                return maxSumColumn;
            }
            else if (metric is ManhattanMetric)
            {
                double maxSumRow = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    double sumAbsRow = 0;
                    for (int j = 0; j < matrix.GetLength(0); j++)
                        sumAbsRow += Math.Abs(matrix[i, j]);

                    maxSumRow = Math.Max(maxSumRow, sumAbsRow);
                }
                return maxSumRow;
            }
            else if (metric is EuclidianMetric)
            {
                double sumSquare = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(0); j++)
                        sumSquare += matrix[j, i] * matrix[j, i];

                return Math.Sqrt(sumSquare);
            }
            else
                throw new Exception("For this metric undefined getting method alpha");

        }
    }
}
