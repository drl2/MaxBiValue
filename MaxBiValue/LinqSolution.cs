using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBiValue
{
    /// <summary>
    /// Use linq functions & working backward from the full array, go through increasingly smaller groupings until
    /// the largest one with only 2 distinct elements is found
    /// Lots of array searches but can knows when it has found the largest and can stop there, so for certain cases may
    /// perform better than some other methods
    /// </summary>
    public class LinqSolution : ISliceSolution
    {
        public int[] ints { get; set; }


        public LinqSolution(int[] A)
        {
            ints = A;
        }


        /// <summary>
        /// Solve for longest bi-vaLue using linq-based array manipulation
        /// </summary>
        /// <param name="A">Array of ints to check for longest bi-value</param>
        /// <returns>Largest consecutive bi-value</returns>
        public int getSolution()
        {
            // need to pre-check for meeting required limits
            if (ints.Length > 100)
            {
                throw new ArgumentOutOfRangeException("Array can contain a maximum of 100 values.");
            }
            else if (ints.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Can't process an empty array!.");
            }

            foreach (int val in ints)
            {
                if (int.Abs(val) > 1000000000)
                {
                    // make sure values are in required range
                    throw new ArgumentOutOfRangeException("Values must be between -1,000,000,000 and 1,000,000,000 - " + val + " is invalid.");
                }
            }


            if (ints != null)
            {
                int maxLength = ints.Length;
                int increment = 0;

                // start at longest and work backwards.
                // need to loop through each possible smaller arrangement of contents to find bi-valued set

                while (increment < maxLength)
                {
                    //need to figure out how many times to iterate through based on size of current segment
                    int segment = maxLength - increment;
                    int startingPoint = 0;

                    while ((startingPoint + segment) < maxLength)
                    {
                        int[] checkArray = ints.Skip(startingPoint).Take(segment).ToArray();
                        if (isBiValued(checkArray)) return checkArray.Length;
                        startingPoint++;
                    }
                    increment++;
                }
                return 1;
            }
            else
            {
                throw new NullReferenceException("No integer array to test.");
            }
        }


        public int getSolution(int[] A)
        {
            Console.WriteLine("solution");
            ints = A;
            return getSolution();
        }


        /// <summary>
        /// Check for BiValued set
        /// </summary>
        /// <param name="A">Array of ints to check for bi-value</param>
        /// <returns>bool to indicate bi-valued (true) or not (false)</returns>
        private bool isBiValued(int[] A)
        {
            int[] uniqueVals = A.Distinct().ToArray();
            return (uniqueVals.Length < 3);
        }
    }
}
