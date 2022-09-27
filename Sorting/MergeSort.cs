namespace Sorting {
    class MergeSort {
        /// <summary>
        /// Start the sorting of the inputted <c>array</c>.
        /// </summary>
        /// <param name="array"><c>Array</c> to be sorted.</param>
        /// <returns>The sorted array.</returns>
        public static int[] Sort(int[] array) {
            Split(array, 0, array.Length - 1);
            return array;
        }

        /// <summary>
        /// Sort the array by splitting it up, sorting it recursively and finally merging it.
        /// </summary>
        /// <param name="input">The <c>array</c> to sort.</param>
        /// <param name="low">The lowest value.</param>
        /// <param name="high">The highest value.</param>
        private static void Split(int[] input, int low, int high) {
            if(low < high) {
                //Get the middle value of the inputted array
                int middle = (low + high) / 2;

                //Split the array into two parts
                Split(input, low, middle);
                Split(input, middle + 1, high);

                //Merge the two parts back together
                Merge(input, low, middle, high);
            }
        }

        /// <summary>
        /// Sort the parts and merge them together.
        /// </summary>
        /// <param name="input">The <c>array</c> to sort.</param>
        /// <param name="low">The lowest value.</param>
        /// <param name="middle">The middle location of the <c>array</c></param>
        /// <param name="high">The highest value.</param>
        private static void Merge(int[] input, int low, int middle, int high) {
            //Index for the left part
            int left = low;
            //Index for the right part
            int right = middle + 1;

            //New temporary array
            int[] temp = new int[(high - low) + 1];
            int tempIndex = 0;

            //Sort the left and right parts into the temporary array
            while(left <= middle && right <= high) {
                //Add the left value if it's smaller than the right
                if(input[left] < input[right])
                    temp[tempIndex++] = input[left++];
                //Otherwise add the right value
                else
                    temp[tempIndex++] = input[right++];
            }

            //Add the remaining items from the left part to the temporary array
            while(left <= middle)
                temp[tempIndex++] = input[left++];

            //Add the remaining items from the right part to the temporary array
            while(right <= high)
                temp[tempIndex++] = input[right++];

            //Fill the input array with the values form the temporary array
            for(int i = 0; i < temp.Length; i++)
                input[low + i] = temp[i];
        }
    }
}
