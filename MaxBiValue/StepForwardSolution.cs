using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxBiValue
{
    /// <summary>
    /// Step forward through array and track current max length
    /// Only one traversal of the array but always has to search to the end
    /// </summary>
    public class StepForwardSolution : ISliceSolution
    {
        public int[] ints { get; set; }

        public StepForwardSolution(int[] A)
        {
            ints = A;
        }

        public int getSolution(int[] A)
        {
            Console.WriteLine("solution");
            ints = A;
            return getSolution();
        }

        /// <summary>
        /// Solve for longest bi-vaLue by stepping forward through array
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

            if (ints != null && ints.Length > 0)
            {
                int longest = 0, 
                    currentLength = 0,
                    priorLength = 0,
                    lastVal = int.MinValue;

                Queue<int> q = new Queue<int>();

                foreach (int val in ints)
                {   
                    if (int.Abs(val) > 1000000000)
                    {
                        // make sure values are in required range
                        throw new ArgumentOutOfRangeException("Values must be between -1,000,000,000 and 1,000,000,000 - " + val + " is invalid.");
                    }

                    if (q.Contains(val)) // only needs to search max 2 items
                    {
                        // if val is already in the current bi-val pair, just increment the count
                        ++currentLength;
                    }
                    else
                    {
                        //if it's new, need to get the count for the previous one and add to that
                        currentLength = priorLength + 1;
                    }

                    
                    if (val == lastVal)
                    {
                        // if val is repeated from previous position, increment prior length
                        ++priorLength;
                    }
                    else
                    {
                        // new value, so pop the queue and reset the prior count
                        if (q.Count > 1) { q.Dequeue(); }
                        q.Enqueue(val);
                        priorLength = 1;
                    }

                    lastVal = val;
                    if (currentLength > longest) { longest = currentLength; }
                }

                return longest;
            }
            else
            {
                throw new NullReferenceException("No integer array to test.");
            }
        }

    }
}
