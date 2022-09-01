// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

class Introduction {
    /// <summary>
    /// Variable for converting GetTimestamp output to nanoseconds
    /// </summary>
    static long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
    static Random rand = new Random();

    /// <summary>
    /// Main public method to run the different tests
    /// </summary>
    public static void Main(String[] args) {
        Console.WriteLine("Started");

        //Accuracy();
        //AccuracySum();
        Console.WriteLine($"1000: {RandomArraySum(1000, true)} ns");
        Console.WriteLine($"1000: {RandomArraySum(1000, false)} ns");

        Console.WriteLine("Done");
    }

    /// <summary>
    /// Prints the time it takes for 0 operations, 10 times.
    /// Used to see the accuracy of the <c>Stopwatch</c>.
    /// </summary>
    private static void Accuracy() {
        for(int i = 0; i < 10; i++) {
            long n0 = Stopwatch.GetTimestamp();
            long n1 = Stopwatch.GetTimestamp();
            Console.WriteLine($"Resolution {(n1 - n0) * nanosecondsPerTick} ns");
        }
    }

    /// <summary>
    /// Prints the time it takes for an addition operation from an array, 10 times.
    /// </summary>
    private static void AccuracySum() {
        int[] given = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
        int sum = 0;

        for(int i = 0; i < 10; i++) {
            long n0 = Stopwatch.GetTimestamp();
            sum += given[i];
            long n1 = Stopwatch.GetTimestamp();
            Console.WriteLine($"Resolution {(n1 - n0) * nanosecondsPerTick} ns");
        }
    }

    /// <summary>
    /// Sums up numbers in an array from random positions in the array.
    /// </summary>
    /// <param name="n">The size of the index array</param>
    /// <param name="rngFirst">Desides if the random numbers should be generated on the fly
    /// or if there are an index array where there random positions are already generated.</param>
    private static double RandomArraySum(int n, bool rngFirst) {

        //Create and fill the array
        int[] array = new int[n];
        for(int i = 0; i < n; i++) {
            array[i] = i;
        }

        int sum = 0;
        long t0 = 0;

        if(rngFirst) {
            //Get random index for where to check in the array
            int[] index = new int[n];
            for(int i = 0; i < n; i++) {
                index[i] = (int)rand.NextInt64(n);
            }

            t0 = Stopwatch.GetTimestamp();

            //Sum the numbers togheter from index positions
            for(int i = 0; i < n; i++) {
                sum += array[index[i]];
            }
        } else {
            t0 = Stopwatch.GetTimestamp();

            //Sum the numbers togheter from random positions
            for(int i = 0; i < n; i++) {
                sum += array[rand.NextInt64(n)];
            }
        }

        long t1 = Stopwatch.GetTimestamp();

        return (t1 - t0) * nanosecondsPerTick;
    }
}
