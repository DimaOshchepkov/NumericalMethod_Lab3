using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class MetricFactory
    {  
        public string[] ExistMetric { get; private set; }

        public MetricFactory()
        {
            ExistMetric = new string[] { "Manhattan", "Chebyshev", "Euclidian" };
        }
        public IMetric GetMetric(string metric)
        {
            if (metric == "Euclidian")
                return new EuclidianMetric();
            else if (metric == "Manhattan")
                return new ManhattanMetric();
            else if (metric == "Chebyshev")
                return new ChebyshevMetric();
            else
                throw new Exception("No such metric");
        }


    }
}
