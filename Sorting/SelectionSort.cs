namespace Sorting {
    internal class SelectionSort {
        /// <summary>
        /// Sort the inputted <c>array</c>.
        /// </summary>
        /// <param name="array"><c>Array</c> to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] Sort(int[] array) {
            int length = array.Length;

            //Loop through the full array
            for(int i = 0; i < length - 1; i++) {
                int minIndex = i;
                //Find the next smallest number and set the swap index
                for(int j = i + 1; j < length; j++) {
                    if(array[j] < array[minIndex])
                        minIndex = j;
                }
                //Swap the numbers if the number is smaller than the current one
                    if(array[j] < array[i])
                        Utilities.Swap(ref array[i], ref array[j]);
            }
            return array;
        }
    }
}
