using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    interface ISolver
    {
        double[] GetSolve(double[,] matrix, double eps);
    }
}
