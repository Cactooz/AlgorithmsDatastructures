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
            Sort(list.GetNode(), list.GetLast());

            return list;
        }

        /// <summary>
        /// Sorts higher and lower around the <paramref name="high"/> element using <see cref="Partition"/>.
        /// Splits up recursively around the <paramref name="high"/> and <see cref="Sort"/> the lower and higher parts.
        /// </summary>
        /// <param name="low">The lowest <see cref="LinkedList.Node">Node</see> where the <see cref="LinkedList"/> <see cref="Sort">Sort</see> should start.</param>
        /// <param name="high">The highest <see cref="LinkedList.Node">Node</see> where the <see cref="LinkedList"/> <see cref="Sort">Sort</see> should end.</param>
        private void Sort(LinkedList.Node low, LinkedList.Node high) {
            //Return directly if any of the inputted nodes are null or the same node
            if(low == null || high == null || low == high)
                return;

            //Do the first partition for the full list
            LinkedList.Node partIndex = Partition(low, high);

            //Sort the lower parts of the list
            Sort(low, partIndex);

            //Sort the higher parts of the array
            if(partIndex != null && partIndex == low)
                Sort(partIndex.GetNext(), high);
            else if(partIndex != null && partIndex.GetNext() != null)
                Sort(partIndex.GetNext().GetNext(), high);
        }

        /// <summary>
        /// Sets the <paramref name="high"/> value as the <c>pivot</c> and sorts all other list 
        /// elements from <paramref name="low"/> and up around it.
        /// Resulting in the <c>pivot</c> element having smaller elements before it and larger after it.
        /// </summary>
        /// <param name="low">The lowest position where the <see cref="LinkedList"/> <see cref="Sort">sort</see> should start.</param>
        /// <param name="high">The highest position where the <see cref="LinkedList"/> <see cref="Sort">sort</see> should end.</param>
        /// <returns>The <see cref="LinkedList.Node"/> pointing at the used pivot, in the middle where
        /// all lower elements are smaller and all higher elements are larger.</returns>
        private LinkedList.Node Partition(LinkedList.Node low, LinkedList.Node high) {
            if(low == null || high == null || low == high)
                return low;

            //Set the pivot to the last list node value
            int pivot = high.GetValue();

            //The node that end up pointing at the pivot node
            LinkedList.Node pivotNode = low;
            //The actual node that the checks are done on
            LinkedList.Node current = low;

            //Temp int for swapping the node values
            int temp;

            //The next value of the lowest position
            LinkedList.Node next = low.GetNext();

            //Move the smaller items to the start
            while(low != high && next != null) {
                if(low.GetValue() < pivot) {
                    //Move the pivot forward
                    pivotNode = current;

                    //Swap the node values
                    temp = current.GetValue();
                    current.SetValue(low.GetValue());
                    low.SetValue(temp);

                    //Move the next node to swap check with
                    current = current.GetNext();
                }
                //Move to the next node
                low = low.GetNext();
                next = low;
            }

            //Swap the pivot into the middle
            temp = current.GetValue();
            current.SetValue(pivot);
            high.SetValue(temp);

            //Return the node pointing at the current pivot
            return pivotNode;
        }

    }
}
