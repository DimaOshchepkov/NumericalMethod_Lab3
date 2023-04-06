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
        public GetterAlpha(IMetric metric)
        {
            this.metric = metric;
        }


        public double GetAlpha(double[,] matrix)
        {
            if (metric is ChebyshevMetric)
            {
                double maxSumColumn = 0;
                for (int i = 0; i < matrix.Length; i++)
                {
                    double sumAbsColumn = 0;
                    for (int j = 0; j < matrix.Length; j++)
                        sumAbsColumn += matrix[j, i];

                    maxSumColumn = Math.Max(maxSumColumn, sumAbsColumn);
                }
                return maxSumColumn;
            }
            else if (metric is ManhattanMetric)
            {
                double maxSumRow = 0;
                for (int i = 0; i < matrix.Length; i++)
                {
                    double sumAbsRow = 0;
                    for (int j = 0; j < matrix.Length; j++)
                        sumAbsRow += matrix[i, j];

                    maxSumRow = Math.Max(maxSumRow, sumAbsRow);
                }
                return maxSumRow;
            }
            else if (metric is EuclidianMetric)
            {
                double sumSquare = 0;
                for (int i = 0; i < matrix.Length; i++)
                    for (int j = 0; j < matrix.Length; j++)
                        sumSquare += matrix[j, i];

                return sumSquare;
            }
            else
                throw new Exception("No such metric");

        }
    }
}
