using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class SeidelMethod : IIterationMethod
    {
        double[] IIterationMethod.GetSolve(double[,] mapping, IMetric metric, double alpha, double eps)
        {
            double[] prevIter = new double[mapping.GetLength(0)];
            double[] currIter = new double[mapping.GetLength(0)];
            int countIter = 0;
            do
            {
                countIter++;
                Array.Copy(currIter, prevIter, currIter.Length);
                for (int i = 0; i < currIter.Length; i++)
                {
                    currIter[i] = mapping[i, currIter.Length];
                    for (int j = 0; j < currIter.Length; j++)
                        currIter[i] += mapping[i, j] * currIter[j];
                }
            }
            while (metric.GetDistance(prevIter, currIter) > (1 - alpha) / alpha * eps);
            Console.WriteLine($"Количество итераций метода Зейделя {countIter}");
            return currIter;
        }
    }
}
