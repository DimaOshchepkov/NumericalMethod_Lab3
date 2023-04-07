using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    interface IMetric
    {
        double GetDistance(double[] x1, double[] x2);
    }
}
