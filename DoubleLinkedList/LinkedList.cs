namespace DoubleLinkedList {
    internal class LinkedList {
        /// <summary>
        /// The linked list contaning all the <see cref="ListElement"/>.
        /// </summary>
        private ListElement list;
        /// <summary>
        /// Optional array for keeping the references to the <see cref="ListElement"/> in the <see cref="list">list</see>.
        /// </summary>
        private ListElement[] elementArray;

        /// <summary>
        /// Constructor for <see cref="LinkedList"/>.
        /// Creates a new linked list with the inputted size, 
        /// with each <see cref="ListElement"/> value getting incremented by one each time.
        /// </summary>
        /// <param name="size">The amount of elements that should be in the list.</param>
        public LinkedList(int size, bool array = false) {
            //The list has to have elements
            if(size < 0)
                return;

            //Create root ListElemenet
            list = new ListElement(0, null, null);

            //Pointer to the list to not change the original list
            ListElement pointer = list;

            //Loop through and add next references to create the list with the size
            for(int i = 0; i < size - 1; i++) {
                pointer.SetNext(new ListElement(i + 1, null, pointer));
                pointer = pointer.GetNext();
            }

            //Fill an array with the node references
            if(array && size > 0)
                GenerateArray(size);
        }

        /// <summary>
        /// Get the <see cref="ListElement"/> reference from the list using the array.
        /// The array is created by the constructor if the <c>bool array = true</c>.
        /// </summary>
        /// <param name="position">The position in the array.</param>
        /// <returns>A <see cref="ListElement"/> from the inputted position.</returns>
        public ListElement GetNode(int position) => elementArray[position];

        /// <summary>
        /// Genereate an array with all the <see cref="ListElement"/> in the <see cref="list">list</see>.
        /// </summary>
        /// <param name="size">The size of the array that should be.</param>
        public void GenerateArray(int size) {
            //Create an empty array with the size.
            elementArray = new ListElement[size];

            //Set the pointer to the beginning of the linked list.
            ListElement pointer = list;
            int i = 0;

            //Add all the element from the list into the array.
            while(pointer != null) {
                elementArray[i++] = pointer;
                pointer = pointer.GetNext();
            }
        }

        /// <summary>
        /// Removes element from the <see cref="LinkedList"/> and places it at the start.
        /// </summary>
        /// <param name="element">The <see cref="ListElement"/> that should be moved.</param>
        public void RemoveAdd(ListElement element) {
            Remove(element);
            Add(element);
        }

        /// <summary>
        /// Removes element from the <see cref="LinkedList"/> and places it at the start.
        /// </summary>
        /// <param name="position">The position of the element that should be moved.</param>
        public void RemoveAdd(int position) {
            int removedValue = Remove(position);
            Add(removedValue);
        }

        /// <summary>
        /// Removes a <see cref="ListElement"/> from the list.
        /// </summary>
        /// <param name="element">The <see cref="ListElement"/> that should be removed.</param>
        public void Remove(ListElement element) {
            //Check if it is the first element
            if(element.GetPrevious() == null) {
                //Move the list to start at the second element.
                list = list.GetNext();
                //Remove the reference to the element before.
                list.SetPrevious(null);
            }
            else if(element.GetNext() == null)
                //Remove the reference to the removed element on the previous element.
                element.GetPrevious().SetNext(null);
            else {
                //Remove the references on the surrounding elements.
                element.GetPrevious().SetNext(element.GetNext());
                element.GetNext().SetPrevious(element.GetPrevious());
            }

            //Clear the removed elements next and previous elment refrences.
            element.SetNext(null);
            element.SetPrevious(null);
        }

        /// <summary>
        /// Removes a <see cref="ListElement"/> from the specified position.
        /// </summary>
        /// <param name="pos">The position of the element in the list.</param>
        /// <returns>The <see cref="ListElement.value">value</see> of the element that got removed.</returns>
        public int Remove(int pos) {
            //Throw exception if the inputted index is to small.
            if(pos < 0)
                throw new IndexOutOfRangeException("Index out of bounds of the linked list.");

            //Check if it is the first element
            if(pos == 0) {
                //Get the value of the current element.
                int value = list.GetValue();
                //Move the list to start at the second element.
                list = list.GetNext();
                //Remove the reference to the element before.
                list.SetPrevious(null);

                return value;
            }

            //Set the pointer to the beginning of the linked list.
            ListElement pointer = list;

            //Go to the correct position in the linked list.
            for(int i = 0; i < pos; i++) {
                //Throw exception if the inputted index is to large.
                if(pointer.GetNext() == null)
                    throw new IndexOutOfRangeException("Index out of bounds of the linked list.");

                pointer = pointer.GetNext();
            }

            //Check if it is the last element
            if(pointer.GetNext() == null)
                //Remove the reference on the previous element
                pointer.GetPrevious().SetNext(null);
            else {
                //Remove the references on the surrounding elements.
                pointer.GetPrevious().SetNext(pointer.GetNext());
                pointer.GetNext().SetPrevious(pointer.GetPrevious());
            }

            //Return the value of the removed element.
            return pointer.GetValue();
        }

        /// <summary>
        /// Add a <see cref="ListElement"/> to the beginning of the <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="element">The <see cref="ListElement"/> that should be added.</param>
        public void Add(ListElement element) {
            //Set the next ListElement to the old start
            element.SetNext(list);

            //Set the previous ListElement of the current start element.
            list.SetPrevious(element);

            //Move the start of the linked list back to the newly added element.
            list = list.GetPrevious();
        }

        /// <summary>
        /// Add a new <see cref="ListElement"/> to the beginning of the <see cref="LinkedList"/>,
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
