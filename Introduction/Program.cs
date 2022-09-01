﻿// See https://aka.ms/new-console-template for more information

using System.Diagnostics;

class Introduction {
    /// <summary>
    /// Variable for converting GetTimestamp output to nanoseconds
    /// </summary>
    static long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

    /// <summary>
    /// Main public method to run the different tests
    /// </summary>
    public static void Main(String[] args) {
        Console.WriteLine("Started");

        //Accuracy();
        AccuracySum();

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
}
