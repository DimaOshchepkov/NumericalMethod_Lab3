using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class SolverSimpleIter : ISolver
    {
        double[] ISolver.GetSolve(double[,] matrix, double eps)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1) - 1)
                throw new Exception("The matrix does not satisfy the condition");

            double[,] mapping = getterMapping.GetMapping(matrix);

            double alpha = 2;
            for (int i = 0; i < metricFactory.ExistMetric.Length && alpha >= 1; i++)
            {
                metric = metricFactory.GetMetric(metricFactory.ExistMetric[i]);
                alpha = (new GetterAlpha(metric)).GetAlpha(mapping);
            }

            if (alpha >= 1)
            {
                Console.WriteLine("No compressive mapping found for all metrics");
                Console.WriteLine("We checked the preconditions for these metrics:");
                foreach (var metric in metricFactory.ExistMetric)
                    Console.WriteLine(metric.ToString());

                return new double[0];
            }
            else
            {
                double[] prevIter = new double[matrix.GetLength(0)];
                double[] currIter = new double[matrix.GetLength(0)];
                int countIter = 0;
                do
                {
                    countIter++;
                    Array.Copy(currIter, prevIter, currIter.Length);
                    for (int i = 0; i < currIter.Length; i++)
                    {
                        for (int j = 0; j < currIter.Length; j++)
                            currIter[i] += mapping[i, j] * prevIter[j];
                        currIter[i] += mapping[i, currIter.Length];
                    }
                }
                while (metric.GetDistance(prevIter, currIter) > (1 - alpha) / alpha * eps);
                return currIter;
            }   
        }

        MetricFactory metricFactory = new MetricFactory();
        IMetric metric;
        GetterAlpha getterAlpha;
        GetterMapping getterMapping = new GetterMapping();
    }
}
