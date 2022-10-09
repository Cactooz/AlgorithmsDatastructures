namespace QuickSort {
    internal class QuickSortList {
        /// <summary>
        /// Starting point of <see cref="QuickSortList"/>.
        /// Sends in the <paramref name="list"/> and sorts it.
        /// </summary>
        /// <param name="list">The int <see cref="LinkedList"/> to be sorted.</param>
        /// <returns>The sorted <paramref name="list"/>.</returns>
        public LinkedList SortStart(LinkedList list) {
            //Sort the whole list
            Sort(list, 0, list.GetLength());
            //Return the sorted list
            return list;
        }

        /// <summary>
        /// Sort the <paramref name="list"/>.
        /// Sorts higher and lower around the <paramref name="high"/> element using <see cref="Partition"/>.
        /// Splits up recursively around the <paramref name="high"/> and <see cref="Sort"/> the lower and higher parts.
        /// </summary>
        /// <param name="list">The int <see cref="LinkedList"/> to be sorted.</param>
        /// <param name="low">The lowest position where the array sort should start.</param>
        /// <param name="high">The highest position where the array sort should end.</param>
        private void Sort(LinkedList list, int low, int high) {
            if(low < high) {
                int partIndex = Partition(list, low, high);

                //Sort the lower part of the list
                Sort(list, low, partIndex - 1);
                //Sort the upper part of the list
                Sort(list, partIndex + 1, high);
            }
        }

        /// <summary>
        /// Sets the <paramref name="high"/> value as the <c>pivot</c> and sorts all other <paramref name="list"/> 
        /// elements from <paramref name="low"/> and up around it.
        /// Resulting in the <c>pivot</c> element having smaller elements before it and larger after it.
        /// </summary>
        /// <param name="list">The int <see cref="LinkedList"/> to be sorted.</param>
        /// <param name="low">The lowest position where the array sort should start.</param>
        /// <param name="high">The highest position where the array sort should end.</param>
        /// <returns>The location of the next pivot, in the middle where
        /// all lower elements are smaller and all higher elements are larger.</returns>
        private int Partition(LinkedList list, int low, int high) {
            //Create a pointer to the list
            LinkedList.Node pointer = list.GetNode();

            //Loop through to the pivot node
            for(int i = 0; i < high - 1; i++)
                pointer.GetNext();

            //Set the pivot to the last list node value
            int pivot = pointer.GetNext().GetValue();
            //Save the reference to the second last list node
            //The node before the pivot node
            LinkedList.Node pivotNode = pointer;

            //Loop through to the lowest node
            LinkedList.Node lowNode = list.GetNode();
            for(int i = 0; i < low - 1; i++)
                lowNode.GetNext();

            //Get the node to check the value for
            LinkedList.Node jNode = lowNode.GetNext();

            int lowIndex = low - 1;
            int j = low;

            //Move the smaller items to the start
            while(jNode != null && j < high) {
                //Check if the list value is smaller than pivot
                if(jNode.GetValue() <= pivot) {
                    list.Swap(lowNode, jNode);
                    lowIndex++;
                    if(lowNode != null)
                        lowNode = lowNode.GetNext();
                }
                //Move to the next node
                jNode = jNode.GetNext();
                j++;
            }

            if(lowNode != null)
                lowNode = lowNode.GetNext();

            //Swap the pivot into the middle
            list.Swap(lowNode, pivotNode);

            return lowIndex + 1;
        }

    }
}
