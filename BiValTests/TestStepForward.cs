using MaxBiValue;

namespace BiValTests
{
    [TestClass]
    public class TestStepForward
    {
        /*
         * Unit tests based on these requirements from the PDF results
         * -----------------------------------------------------------
         * 
         * trivial_test
         * Small number of elements.
         * 
         * extreme
         * List consisting either of one or two different values.
         * 
         * small_pyramid
         * Small pyramid - the sequence is first decreasing, then increasing.
         * 
         * small_random_test
         * Small random test.
         * 
         * medium_test
         * Medium random test.
         * 
         * medium_random_three_values
         * Medium random consisting of three values.
         * 
         * all_same_elements
         * Whole array is made of same value.
         * 
         * three_different_elements
         * Random array consisting of three different values with one of the values occuring only once.
         * 
         * random_small_range
         * Big random array consisting of small range of numbers.
         * 
         * random_with_long_bi_valued_slice
         * Random test with long bi-valued slice.
         * 
         * minimal_and_maximal
         * Array contains only values around minimal and maximal
         *
         *
         *Additional tests
         *-----------------------------------------------------------
         *
         * too_many
         * more than the defined max 100 elements in the array
         * 
         * too_few
         * empty array
         * 
         * outside_bounds
         * values in array are outside the defined +-1,000,000,000 limits
         * 
         * 
         * 
         * Only testing StepForwardSolution since that's the one that performs well
         * Pre-set some arrays to use in various tests
        */
        private static readonly int[] trivial_test = { 1, 2, 3 };  // return 2
        private static readonly int[] extreme = { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 }; //return 15
        private static readonly int[] small_pyramid = { -15, -12, -10, -7, -4, -1, 0, 1, 3, 5, 7, 12, 14, 15 }; // return 2
        private static readonly int[] small_random_test = { -252, -221, -29, 168, 729 }; // return 2
        private static readonly int[] medium_test = { -273, -496, 994, 917, 362, 101, 647, -267, -15, -611, -365, 1000, 878, -443, -791, -834, 837, 424, 341, -518, -923, -871, -503, 954, -297, 827, -418, 472, -172, 418, 144, -294, 95, -781, 326, -16, 818, -88, 54, 68, 770, 686, -220, -499, 481, 694, 905, 289, 234, 634 }; // return 2
        private static readonly int[] medium_random_three_values = { 1, 1, 1, 3, 1, 2, 2, 2, 3, 2, 1, 1, 2, 3, 2, 2, 3, 3, 1, 2, 3, 2, 3, 1, 1, 3, 3, 1, 3, 3, 1, 2, 2, 1, 2, 1, 3, 3, 3, 3, 2, 1, 1, 1, 3, 3, 3, 2, 2, 2 }; // return 9
        private static readonly int[] all_same_elements = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // return 59
        private static readonly int[] three_different_elements = { -5, -4, -5, -4, -5, 42, -5, -5, -4, -5, -5, -5, -4, -5, -5, -5, -4, -5, -5, -5, -4, -5, -5, -4, -5, -4, -5, -4, -4, -4, -4, -4, -4, -4, -4, -4, -5, -4, -5, -4, -5, -4, -4, -5, -5, -5, -4, -5, -5, -4, -4 };  // return 45
        private static readonly int[] random_small_range = { 9, 8, 8, 10, 7, 8, 9, 9, 10, 10, 10, 7, 7, 8, 10, 9, 9, 10, 8, 10, 8, 7, 9, 8, 8, 8, 9, 7, 8, 8, 8, 10, 9, 7, 9, 7, 7, 8, 9, 7, 9, 9, 7, 9, 10, 7, 8, 10, 10, 9, 9, 9, 10, 9, 9, 7, 9, 10, 10, 7, 9, 7, 8, 7, 9, 8, 9, 9, 8, 7, 7, 8, 9, 8, 9, 9, 9, 8, 9, 7, 10, 9, 10, 9, 10, 8, 10, 7, 10, 7, 7, 10, 7, 9, 10, 8, 9, 9, 8, 8 }; // return 8
        private static readonly int[] random_with_long_bi_valued_slice = { 9, 8, 8, 10, 7, 8, 9, 9, 10, 10, 10, 7, 7, 8, 10, 9, 9, 10, 8, 10, 8, 7, 9, 8, 8, 8, 9, 7, 8, 8, 8, 10, 9, 7, 9, 7, 7, 8, 9, 7, 9, 9, 7, 9, 10, 7, 8, 10, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 10, 9, 10, 9, 10, 8, 10, 7, 10, 7, 7, 10, 7, 9, 10, 8, 9, 9, 8, 8 }; // return 32
        private static readonly int[] minimal_and_maximal = { -999999999, -1000000000, -999999990, -999999995, -999999996, -1000000000, -999999997, -999999992, -999999995, -999999997, -999999990, -999999994, -1000000000, -999999997, -999999991, -999999991, -999999991, -999999999, -999999998, -999999996, -999999991, -999999997, -999999991, -999999998, -999999999, -999999994, -999999991, -1000000000, -1000000000, -999999994, 999999995, 999999993, 999999992, 1000000000, 999999995, 999999991, 999999997, 1000000000, 1000000000, 999999992, 999999995, 999999993, 999999999, 999999995, 999999997, 999999996, 999999990, 999999994, 999999998, 1000000000, 999999991, 999999993, 999999992, 999999998, 999999998, 999999994, 999999998, 999999999, 999999995, 999999995 }; // return 4

        private static readonly int[] too_many = { 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0 };
        private static readonly int[] too_few = { };
        private static readonly int[] outside_bounds = { -1100000000, 1100000000 };


        [TestMethod]
        public void Trivial_Test()
        {
            ISliceSolution sol = new StepForwardSolution(trivial_test);
            int result = sol.getSolution();
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Extreme_Test()
        {
            ISliceSolution sol = new StepForwardSolution(extreme);
            int result = sol.getSolution();
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void Small_Pyramid_Test()
        {
            ISliceSolution sol = new StepForwardSolution(small_pyramid);
            int result = sol.getSolution();
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Small_Random_Test()
        {
            ISliceSolution sol = new StepForwardSolution(small_random_test);
            int result = sol.getSolution();
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Medium_Test()
        {
            ISliceSolution sol = new StepForwardSolution(medium_test);
            int result = sol.getSolution();
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Medium_Random_Three_Values_Test()
        {
            ISliceSolution sol = new StepForwardSolution(medium_random_three_values);
            int result = sol.getSolution();
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void All_Same_Elements_Test()
        {
            ISliceSolution sol = new StepForwardSolution(all_same_elements);
            int result = sol.getSolution();
            Assert.AreEqual(59, result);
        }

        [TestMethod]
        public void Three_Different_Elements_Test()
        {
            ISliceSolution sol = new StepForwardSolution(three_different_elements);
            int result = sol.getSolution();
            Assert.AreEqual(45, result);
        }

        [TestMethod]
        public void Random_Small_Range_Test()
        {
            ISliceSolution sol = new StepForwardSolution(random_small_range);
            int result = sol.getSolution();
            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Random_With_Long_Bi_Valued_Slice_Test()
        {
            ISliceSolution sol = new StepForwardSolution(random_with_long_bi_valued_slice);
            int result = sol.getSolution();
            Assert.AreEqual(32, result);
        }

        [TestMethod]
        public void Minimal_And_Maximal_Test()
        {
            ISliceSolution sol = new StepForwardSolution(minimal_and_maximal);
            int result = sol.getSolution();
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Too_Many_Exception_Test()
        {
            ISliceSolution sol = new StepForwardSolution(too_many);
            int result = sol.getSolution(); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Too_Few_Exception_Test()
        {
            ISliceSolution sol = new StepForwardSolution(too_few);
            int result = sol.getSolution();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Outside_Bounds_Exception_Test()
        {
            ISliceSolution sol = new StepForwardSolution(outside_bounds);
            int result = sol.getSolution();
        }
    }
}