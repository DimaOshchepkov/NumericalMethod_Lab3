using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Solver : ISolver
    {
        public Solver(IIterationMethod iterMethod)
        {
            iterationMethod = iterMethod;
        }
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

                return null;
            }
            else
                return iterationMethod.GetSolve(mapping, metric, alpha, eps); 
        }

        MetricFactory metricFactory = new MetricFactory();
        IMetric metric;
        GetterAlpha getterAlpha;
        GetterMapping getterMapping = new GetterMapping();
        IIterationMethod iterationMethod;
    }
}
