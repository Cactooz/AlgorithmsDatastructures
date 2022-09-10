namespace Sorting {
    class InsertionSort {
        /// <summary>
        /// Sort the inputted <c>array</c>.
        /// </summary>
        /// <param name="array"><c>Array</c> to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] Sort(int[] array) {
            //Loop through the full array
            for(int i = 0; i < array.Length - 1; i++) {
                //Start checking with the next value and look backwards for the correct spot
                for(int j = i + 1; j > 0; j--) {
                    //Swap the two numbers if the one before is larger
                    if(array[j - 1] > array[j])
                        Utilities.Swap(ref array[j - 1], ref array[j]);
                }
            }
            return array;
        }
    }
}
