using MaxBiValue;
using System.IO;
 
//simple command line: MaxBiValue filename.txt


if (args.Length != 1)
{
    throw new ArgumentException("Requires a single file name argument");
}

string textFile = args[0];

try
{
    // let's load them all into a list first to catch any format errors before real processing starts
    // and to remove i/o from perf timings
    List<int[]> arrays = new List<int[]>();

    using (StreamReader sr = new StreamReader(textFile))
    {
        string line;

        while ((line = sr.ReadLine()) != null)
        {
            if (line.Trim().Length > 0) // ignore blank lines
            {
                int[] A = Utility.StrToIntArray(line);
                arrays.Add(A);
            }
        }
    }


    // now process each one
    if (arrays.Count > 0)
    {
        foreach (int[] A in arrays)
        {
            Console.WriteLine("Array:");
            Console.WriteLine("[{0}]", string.Join(",", A));

            Utility.RunSolution("Linq Based, Work backward", new LinqSolution(A));
            Utility.RunSolution("Step forward through array", new StepForwardSolution(A));

            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("No int arrays specified in " + textFile);
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine("File '{0}' not found.", textFile);
}
catch (Exception ex)
{ 
    Console.WriteLine(ex.ToString());
}





