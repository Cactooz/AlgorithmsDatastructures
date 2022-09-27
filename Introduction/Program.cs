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

        for(int i = 0; i < 10; i++)
            Console.WriteLine($"Resolution {Accuracy()}ns");

        //AccuracySum();
        //Console.WriteLine($"1000: {RandomArraySum(1000, true)}ns");
        //Console.WriteLine($"1000: {RandomArraySum(1000, false)}ns");

        /*Console.WriteLine($"10:     {Access(10)}ns");
        Console.WriteLine($"25:     {Access(25)}ns");
        Console.WriteLine($"50:     {Access(50)}ns");
        Console.WriteLine($"100:    {Access(100)}ns");
        Console.WriteLine($"500:    {Access(500)}ns");
        Console.WriteLine($"1000:   {Access(1000)}ns");
        Console.WriteLine($"10000:  {Access(10000)}ns");
        Console.WriteLine($"25000:  {Access(25000)}ns");
        Console.WriteLine($"50000:  {Access(50000)}ns");
        Console.WriteLine($"100000: {Access(100000)}ns");
        Console.WriteLine($"1000000:{Access(1000000)}ns");*/

        /*Console.WriteLine($"10:  {Search(10)}ns");
        Console.WriteLine($"25:  {Search(25)}ns");
        Console.WriteLine($"50:  {Search(50)}ns");
        Console.WriteLine($"100: {Search(100)}ns");
        Console.WriteLine($"250: {Search(250)}ns");
        Console.WriteLine($"500: {Search(500)}ns");*/

        /*Console.WriteLine($"10:  {SearchDuplicates(10)}ns");
        Console.WriteLine($"25:  {SearchDuplicates(25)}ns");
        Console.WriteLine($"50:  {SearchDuplicates(50)}ns");
        Console.WriteLine($"100: {SearchDuplicates(100)}ns");
        Console.WriteLine($"250: {SearchDuplicates(250)}ns");
        Console.WriteLine($"500: {SearchDuplicates(500)}ns");*/

        Console.WriteLine("Done");
    }

    /// <summary>
    /// Prints the time it takes for 0 operations, 10 times.
    /// Used to see the accuracy of the <c>Stopwatch</c>.
    /// </summary>
    /// <returns>Measured time in nanoseconds.</returns>
    private static double Accuracy() {
        long n0 = Stopwatch.GetTimestamp();
        long n1 = Stopwatch.GetTimestamp();

        return (n1 - n0) * nanosecondsPerTick;
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
    /// <param name="rngFirst">Decides if the random numbers should be generated on the fly
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

            //Sum the numbers together from index positions
            for(int i = 0; i < n; i++) {
                sum += array[index[i]];
            }
        } else {
            t0 = Stopwatch.GetTimestamp();

            //Sum the numbers together from random positions
            for(int i = 0; i < n; i++) {
                sum += array[rand.NextInt64(n)];
            }
        }

        long t1 = Stopwatch.GetTimestamp();

        return (t1 - t0) * nanosecondsPerTick;
    }

    /// <summary>
    /// Measures the time it takes access elements in arrays.
    /// </summary>
    /// <param name="n">The size of the array</param>
    /// <returns>Average of the measured run time in nanoseconds.</returns>
    private static double Access(int n) {
        int k = 10_000_000; //Amount of times the test is run
        int l = 100; //Amount of additions per test

        //Get random index points
        int[] index = new int[l];
        for(int i = 0; i < l; i++)
            index[i] = (int)rand.NextInt64(n);

        //Fill the base array
        int[] array = new int[n];
        for(int i = 0; i < n; i++)
            array[i] = 1;

        int sum = 0;
        long t0 = Stopwatch.GetTimestamp();

        //Add the random index numbers together
        for(int i = 0; i < k; i++) {
            for(int j = 0; j < l; j++)
                sum += array[index[j]];
        }

        long tAccess = Stopwatch.GetTimestamp() - t0;

        int dummySum = 0;
        t0 = Stopwatch.GetTimestamp();

        //Dummy loop to get time for the loop
        for(int i = 0; i < k; i++) {
            for(int j = 0; j < l; j++)
                dummySum += 1;
        }

        long tDummy = Stopwatch.GetTimestamp() - t0;

        //Return just the time to access the array
        return (tAccess - tDummy) * nanosecondsPerTick / (double)(k * l);
    }

    /// <summary>
    /// Measures the time it takes to search for a specific key in an array.
    /// </summary>
    /// <param name="n">The size of the array</param>
    /// <returns>Average of the measured run time in nanoseconds.</returns>
    private static double Search(int n) {
        int k = 1000; //Amount of times the test is run
        int m = 1000; //Number of searches for each run

        int[] keys = new int[m];
        int[] array = new int[n];

        long tTotal = 0;

        for(int i = 0; i < k; i++) {
            //Fill the array with random numbers
            for(int j = 0; j < n; j++)
                array[j] = (int)rand.NextInt64(n * 10);

            //Get random numbers for the keys
            for(int j = 0; j < m; j++)
                keys[j] = (int)rand.NextInt64(n * 10);

            int sum = 0;
            long t0 = Stopwatch.GetTimestamp();

            //Search for the keys in the array and sum them together
            for(int ki = 0; ki < m; ki++) {
                int key = keys[ki];
                for(int j = 0; j < n; j++) {
                    if(array[j] == key) {
                        sum++;
                        break;
                    }
                }
            }
            //Add to the total time
            tTotal += Stopwatch.GetTimestamp() - t0;
        }

        return tTotal * nanosecondsPerTick / (double)(k * m);
    }

    /// <summary>
    /// Measures the time it takes to search up all the duplicates of an array of specific keys in another array.
    /// </summary>
    /// <param name="n">The size of the array</param>
    /// <returns>Average of the measured run time in nanoseconds.</returns>
    private static double SearchDuplicates(int n) {
        int k = 1000; //Amount of times the test is run
        int m = 1000; //Number of searches for each run

        int[] keys = new int[m];
        int[] array = new int[n];

        long tTotal = 0;

        for(int i = 0; i < k; i++) {
            //Fill the array with random numbers
            for(int j = 0; j < n; j++)
                array[j] = (int)rand.NextInt64(n * 10);

            //Get random numbers for the keys
            for(int j = 0; j < m; j++)
                keys[j] = (int)rand.NextInt64(n * 10);

            int sum = 0;
            long t0 = Stopwatch.GetTimestamp();

            //Search for the keys in the array and sum them together
            for(int ki = 0; ki < m; ki++) {
                int key = keys[ki];
                for(int j = 0; j < n; j++) {
                    if(array[j] == key)
                        sum++;
                }
            }
            //Add to the total time
            tTotal += Stopwatch.GetTimestamp() - t0;
        }

        return tTotal * nanosecondsPerTick / (double)(k);
    }
}
