using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBiValue
{
    public interface ISliceSolution
    {
        int[] ints { get; set; }
        int getSolution();
        int getSolution(int[] A);
    }
}
