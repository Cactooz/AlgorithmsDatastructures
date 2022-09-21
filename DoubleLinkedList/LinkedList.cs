namespace DoubleLinkedList {
    internal class LinkedList {
        /// <summary>
        /// The linked list contaning all the <see cref="ListElement"/>.
        /// </summary>
        private ListElement list;

        /// <summary>
        /// Constructor for <see cref="LinkedList"/>.
        /// Creates a new linked list with the inputted size, 
        /// with each <see cref="ListElement"/> value getting incremented by one each time.
        /// </summary>
        /// <param name="size">The amount of elements that should be in the list.</param>
        public LinkedList(int size) {
            list = new ListElement(0, null, null);

            //Pointer to the list to not change the original list
            ListElement pointer = list;

            //Loop through and add next references to create the list with the size
            for(int i = 0; i < size - 1; i++) {
                pointer.SetNext(new ListElement(i + 1, null, pointer));
                pointer = pointer.GetNext();
            }
        }

        /// <summary>
        /// Removes a <see cref="ListElement"/> from the specified position.
        /// </summary>
        /// <param name="pos">The position of the element in the list.</param>
        /// <returns>The <see cref="ListElement.value">value</see> of the element that got removed.</returns>
        public int Remove(int pos) {
            //Set the pointer to the beginning of the linked list.
            ListElement pointer = list;

            //Go to the correct position in the linked list.
            for(int i = 0; i < pos; i++)
                pointer = pointer.GetNext();

            //Remove the references to the surrounding elements.
            pointer.GetPrevious().SetNext(pointer.GetNext());
            pointer.GetNext().SetPrevious(pointer.GetPrevious());

            //Return the value of the removed element.
            return pointer.GetValue();
        }

        /// <summary>
        /// Add a new <see cref="ListElement"/> to the beginning of the linked list,
        /// with the inputted value.
        /// </summary>
        /// <param name="value">The value that the element should have.</param>
        public void Add(int value) {
            //Add a new ListElement with the inputted value and next reference to current start element.
            ListElement newList = new ListElement(value, list, null);

            //Set the previous ListElement of the current start element.
            list.SetPrevious(newList);

            //Move the start of the linked list back to the newly added element.
            list = list.GetPrevious();
        }

        /// <summary>
        /// Removes element from the <see cref="LinkedList"/> and places it at the start.
        /// </summary>
        /// <param name="position">The position of the element that should be moved.</param>
        public void RemoveAdd(int position) {
            PrintList();
            int removedValue = Remove(position);
            PrintList();
            Add(removedValue);
            PrintList();
        }

        /// <summary>
        /// Print the contents of the <see cref="LinkedList"/>.
        /// </summary>
        public void PrintList() {
            //Set the pointer to the beginning of the linkedList.
            ListElement pointer = list;

            //Print all values of the elements in the linkedList.
            Console.Write($"{{ {pointer.GetValue()}");
            while(pointer.GetNext() != null) {
                pointer = pointer.GetNext();
                Console.Write($", {pointer.GetValue()}");
            }
            Console.WriteLine(" }");
        }

    }
}
