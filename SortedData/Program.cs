﻿// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

class Searching {
    /// <summary>
    /// Variable for converting GetTimestamp output to nanoseconds.
    /// </summary>
    private static long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;

    /// <summary>
    /// Main public method to run the different tests
    /// </summary>
    public static void Main(string[] args) {
        //The amount of times the benchmark should be run
        int runAmount = 1000;
        Random random = new Random();

        //Do the benchmark for multiple array sizes
        for(int i = 10000; i <= 100000; i += 10000) {
            long time = 0;
            int[] array;
            int[] keys = ArrayFillSorted(new int[i]);

            //Chose if the array should be searched before the search or not
            bool sort = true;

            //Sort the array for sorted array search
            if(sort)
                array = ArrayFillSorted(new int[i]);
            else
                array = ArrayFillRandom(new int[i]);


            for(int j = 0; j < runAmount; j++) {
                //Generate a random key
                int key = random.Next(i*5);

                //Measure the time it takes to search for the key
                long t0 = Stopwatch.GetTimestamp();
                //Search(array, key, sort);
                //BinarySearch(array, key);
                //SearchDuplicatesBinary(array, keys);
                //SearchDuplicates(array, keys);
                SearchDuplicatesScrap(array, keys);
                long t1 = Stopwatch.GetTimestamp();

                //Add to the total time
                time += (t1 - t0) * nanosecondsPerTick;
            }

            Console.WriteLine($"{i}: {time/runAmount}ns");
        }
    }

    /// <summary>
    /// Fill array with random numbers.
    /// </summary>
    /// <param name="array">The array to fill with random numbers.</param>
    /// <returns>The same array with random numbers.</returns>
    private static int[] ArrayFillRandom(int[] array) {
        Random random = new Random();
        for(int i = 0; i < array.Length; i++)
            array[i] = random.Next(array.Length);
        return array;
    }

    /// <summary>
    /// Fill array with sorted random numbers, where there are no duplicate numbers.
    /// </summary>
    /// <param name="array">The array to fill with random numbers.</param>
    /// <returns>The same array with sorted random numbers.</returns>
    private static int[] ArrayFillSorted(int[] array) {
        Random random = new Random();
        int next = 0;
        for(int i = 0; i < array.Length; i++) {
            next += random.Next(10) + 1;
            array[i] = next;
        }
        return array;
    }

    /// <summary>
    /// Searches for a <c>key</c> in an unsorted or sorted <c>array</c>.
    /// </summary>
    /// <param name="array">The array to search through.</param>
    /// <param name="key">The key to search for.</param>
    /// <param name="sorted">It the inputted array is sorted or not</param>
    /// <returns>If the <c>key</c> can be found in the <c>array</c> or not.</returns>
    private static bool Search(int[] array, int key, bool sorted) {
        for(int i = 0; i < array.Length; i++) {
            //Return early if i is larger than the key and the array is sorted
            if(i > key && sorted)
                return false;
            else if(array[i] == key)
                return true;
        }
        return false;
    }

    /// <summary>
    /// Binary searching for <c>key</c> in inputted <c>array</c>.
    /// The <c>array</c> must be sorted.
    /// </summary>
    /// <param name="array">The array to search through.</param>
    /// <param name="key">The key to search for.</param>
    /// <returns>If the <c>key</c> can be found in the <c>array</c> or not.</returns>
    private static bool BinarySearch(int[] array, int key) {
        int first = 0;
        int last = array.Length - 1;

        while(true) {
            //Set the mid between the first and last point
            int mid = (first + last) / 2;

            if(array[mid] == key)
                return true;
            //If the key is larger than the current value, set the first point to current mid
            if(array[mid] < key && mid < last) {
                first = mid + 1;
                continue;
            }
            //If the key is smaller than the current value, set the last point to current mid
            else if(array[mid] > key && mid > first) {
                last = mid - 1;
                continue;
            }
            //If first = last, then there are no value in the array matching the key
            return false;
        }
    }

    /// <summary>
    /// Search for a duplicate item in array from another array with keys using <c>BinarySearch</c>.
    /// </summary>
    /// <param name="array">Array to search in.</param>
    /// <param name="keys">Array with keys to search for.</param>
    private static void SearchDuplicatesBinary(int[] array, int[] keys) {
        foreach(int key in keys)
            BinarySearch(array, key*5);
    }

    /// <summary>
    /// Search for a duplicate item in array from another array with keys using sorted <c>Search</c>.
    /// </summary>
    /// <param name="array">Array to search in.</param>
    /// <param name="keys">Array with keys to search for.</param>
    private static void SearchDuplicates(int[] array, int[] keys) {
        foreach(int key in keys)
            Search(array, key, true);
    }

    /// <summary>
    /// Search for a duplicate item in array from another array with keys by checking through both arrays simultaneously.
    /// Moving forward in one of the arrays if the other arrays item is larger.
    /// </summary>
    /// <param name="array">Sorted array to search in.</param>
    /// <param name="keys">Sorted array with keys to search for.</param>
    private static void SearchDuplicatesScrap(int[] array, int[] keys) {
        int i = 0;
        int j = 0;
        int arrayLength = array.Length;
        int keysLength = keys.Length;
        while(i != arrayLength && j != keysLength) {
            if(array[i] > keys[j])
                j++;
            else
            i++;
        }
    }
}
