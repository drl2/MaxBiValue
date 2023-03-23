using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBiValue
{
    public static class Utility
    {
        public static int[] StrToIntArray(string src)
        {
            int[] result = new int[1];

            try
            {
                src = src.Replace("[", "").Replace("]", "");
                result = Array.ConvertAll(src.Split(','), int.Parse);
                return result;
            }
            catch (FormatException ex)
            {
                throw new FormatException("Each line of the test file must provide a comma-separated list of integers only.");
            }
        }

        /// <summary>
        /// Output results & metadata around an array solution
        /// </summary>
        /// <param name="solName">Display name for solution type</param>
        /// <param name="sol">Solution class using ISliceSolution</param>
        public static void RunSolution(string solName, ISliceSolution sol)
        {
            var timer = new Stopwatch();
            timer.Start();
            int result = sol.getSolution();
            timer.Stop();
            
            Console.WriteLine("Method: {0}\tMax Bi Value Length:\t{1}\tElapsed time:\t{2}", solName, result, timer.Elapsed.ToString());

        }
    }
}
