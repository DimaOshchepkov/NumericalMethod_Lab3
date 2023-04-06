using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class EuclidianMetric : IMetric
    {
        double IMetric.GetDistance(double[] x1, double[] x2)
        {
            double sum = 0;
            for (int i = 0; i < x1.Length; i++)
            {
                sum += Math.Pow(x1[i] - x2[i], 2);
            }

            return Math.Sqrt(sum);
        }
    }
}
