using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class ChebyshevMetric : IMetric
    {
        double IMetric.GetDistance(double[] x1, double[] x2)
        {
            double max = 0;
            for (int i = 0; i < x1.Length; i++)
            {
                max = Math.Max(x1[i] - x2[i], max);
            }
            return max;
        }

        public override string ToString()
        {
            return "ChebyshevMetric";
        }
    }
}
