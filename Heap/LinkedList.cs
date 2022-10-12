namespace Heap {
    internal class LinkedList {
        /// <summary>
        /// Class for the <see cref="Node"/> that the <see cref="LinkedList"/> uses.
        /// </summary>
        public class Node {
            /// <summary>
            /// The <see cref="value">value</see> of the <see cref="Node"/>.
            /// </summary>
            private int value;
            /// <summary>
            /// A <see cref="Nullable"/> reference to the next <see cref="Node"/>.
            /// </summary>
            private Node? next;

            /// <summary>
            /// Constructor for node, without a <see cref="Node.next">next</see> reference.
            /// </summary>
            /// <param name="value">The <see cref="value">value</see> of the <see cref="Node"/>.</param>
            /// <param name="next">A <see cref="Nullable"/> reference to the <see cref="next">next</see> <see cref="Node"/>.</param>
            public Node(int value, Node? next) {
                this.value = value;
                this.next = next;
            }

            /// <summary>
            /// Get the <see cref="value">value</see> of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="value">value</see> of the <see cref="Node"/> as int.</returns>
            public int GetValue() => value;
            /// <summary>
            /// Set the <see cref="value">value</see> of the <see cref="Node"/>.
            /// </summary>
            /// <param name="value">The int value the <see cref="value">value</see> should be.</param>
            public void SetValue(int value) => this.value = value;
            /// <summary>
            /// Get the <see cref="next">next</see> reference of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="next">next</see> <see cref="Node"/> reference.</returns>
            public Node GetNext() => next;
            /// <summary>
            /// Set the <see cref="next">next</see> reference of the <see cref="Node"/>.
            /// </summary>
            /// <param name="node">The reference to the <see cref="next">next</see> <see cref="Node"/>.</param>
            public void SetNext(Node? node) => next = node;
        }

        /// <summary>
        /// The linked list containing all <see cref="Node"/>s.
        /// Points at the first element.
        /// </summary>
        private Node list;

        /// <summary>
        /// Constructor for <see cref="LinkedList"/>.
        /// Creates a new <see cref="LinkedList"/> with the inputted size, 
        /// with each <see cref="Node"/> having a random <see cref="Node.value">value</see>.
        /// </summary>
        /// <param name="size">The amount of <see cref="Node"/>s that should be in the <see cref="LinkedList"/>.</param>
        public LinkedList(int size) {
            //The list has to have elements
            if(size < 0)
                return;

            Random random = new Random();

            //Create root Node with a random value
            list = new Node(random.Next(size * 4), null);

            //Pointer to the list to not change the original list start node reference
            Node pointer = list;

            //Loop through and add next references to create the list with the size
            for(int i = 0; i < size - 1; i++) {
                pointer.SetNext(new Node(random.Next(size * 4), null));
                pointer = pointer.GetNext();
            }
        }

        /// <summary>
        /// Constructor for <see cref="LinkedList"/> taking in a the first <see cref="Node"/>.
        /// </summary>
        /// <param name="start">The first <see cref="Node"/> reference.</param>
        public LinkedList(Node start) {
            list = start;
        }

        /// <summary>
        /// Add a <see cref="Node"/> to the beginning of the <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be added.</param>
        public void Add(Node node) {
            //Set the next ListElement to the old start
            node.SetNext(list);

            //Move the start of the linked list back to the newly added element.
            list = node;
        }

        /// <summary>
        /// Adds a <see cref="Node"/> at the correct sorted location in the <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="node">The <see cref="Node"/> that should be added.</param>
        public void AddSorted(Node node) {
            Node pointer = list;
            Node prevPointer = null;
            int value = node.GetValue();

            //Loop through as long as the new value is bigger and not going past the end
            while(value > pointer.GetValue() && pointer.GetNext() != null) {
                prevPointer = pointer;
                pointer = pointer.GetNext();
            }

            //If the pointer is at the start being null just add the new node
            if(prevPointer == null && value <= pointer.GetValue()) {
                node.SetNext(list);
                list = node;
            }
            else if (value <= pointer.GetValue()) {
                //Make the new node reference the node that should be after it
                node.SetNext(pointer);
                //Add a reference to the new node
                prevPointer.SetNext(node);
            }
            else
                pointer.SetNext(node);

        }

        /// <summary>
        /// Removes the <see cref="Node"/> with the smallest 
        /// <see cref="Node.value">value</see> from the <see cref="LinkedList"/>.
        /// </summary>
        /// <returns>The removed <see cref="Node"/>.</returns>
        public Node Remove() {
            Node pointer = list;
            Node? removalPointer = null;

            //Loop through to the second last element
            while(pointer.GetNext() != null) {
                //Check if the new node has a smaller value
                if(pointer.GetNext().GetValue() < pointer.GetValue())
                    removalPointer = pointer;

                pointer = pointer.GetNext();
            }

            Node returnNode;
            if(removalPointer == null) {
                //Save the node that should be removed
                returnNode = list;

                //Move the list start to the next node
                //Unreferencing the node that is getting removed
                list = list.GetNext();
            }
            else {
                //Save the node that should be removed
                returnNode = removalPointer.GetNext();

                //Unreferencing the node that is getting removed
                if(removalPointer.GetNext().GetNext() == null)
                    removalPointer.SetNext(null);
                else
                    removalPointer.SetNext(removalPointer.GetNext().GetNext());
            }

            return returnNode;
        }

        /// <summary>
        /// Removes the first <see cref="Node"/> from the <see cref="LinkedList"/>. 
        /// Assumes that the list is already sorted, with the smallest item first.
        /// </summary>
        /// <returns>The removed <see cref="Node"/>.</returns>
        public Node RemoveSorted() {
            //Save the node to remove
            Node returnNode = list;

            //Move the list to the next node
            list = list.GetNext();

            return returnNode;
        }

        /// <summary>
        /// Print the contents of the <see cref="LinkedList"/>.
        /// </summary>
        public void PrintList() {
            //Set the pointer to the beginning of the linkedList.
            Node pointer = list;

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
