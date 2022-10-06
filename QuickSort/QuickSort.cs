namespace QuickSort {
    internal class QuickSort {
        /// <summary>
        /// Starting point of <see cref="QuickSort"/>.
        /// Sends in the <paramref name="array"/> and sorts it.
        /// </summary>
        /// <param name="array">The int array to be sorted.</param>
        /// <returns>The sorted <paramref name="array"/>.</returns>
        public int[] SortStart(int[] array) {
            //Sort the full array
            Sort(array, 0, array.Length - 1);
            //Return the sorted array
            return array;
        }

        /// <summary>
        /// Sort the <paramref name="array"/>.
        /// Sorts higher and lower around the <paramref name="high"/> element using <see cref="Partition"/>.
        /// Splits up recursively around the <paramref name="high"/> and <see cref="Sort"/> the lower and higher parts.
        /// </summary>
        /// <param name="array">The int array to be sorted.</param>
        /// <param name="low">The lowest position where the array sort should start.</param>
        /// <param name="high">The highest position where the array sort should end.</param>
        private void Sort(int[] array, int low, int high) {
            if(low < high) {
                int partIndex = Partition(array, low, high);

                //Sort the lower part of the array
                Sort(array, low, partIndex - 1);
                //Sort the upper part of the array
                Sort(array, partIndex + 1, high);
            }
        }

        /// <summary>
        /// Sets the <paramref name="high"/> value as the <c>pivot</c> and sorts all other <paramref name="array"/> 
        /// elements from <paramref name="low"/> and up around it.
        /// Resulting in the <c>pivot</c> element having smaller elements before it and larger after it.
        /// </summary>
        /// <param name="array">The int array to be sorted.</param>
        /// <param name="low">The lowest position where the array sort should start.</param>
        /// <param name="high">The highest position where the array sort should end.</param>
        /// <returns>The location of the next pivot, in the middle where
        /// all lower elements are smaller and all higher elements are larger.</returns>
        private int Partition(int[] array, int low, int high) {
            //Set the pivot to the last array value
            int pivot = array[high];
            int i = low - 1;
            int temp;

            //Move the smaller items to the start
            for(int j = low; j < high; j++) {
                //Check if the array value is smaller than pivot
                if(array[j] <= pivot) {
                    temp = array[++i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            //Swap the pivot into the middle
            temp = array[i + 1];
            array[i + 1] = pivot;
            array[high] = temp;

            return i + 1;
        }

    }
}
