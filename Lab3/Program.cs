using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            IMetric metric = new ManhattanMetric();

            Console.WriteLine(metric is IMetric);
            Console.ReadKey();
        }
    }
}
