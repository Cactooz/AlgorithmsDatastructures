namespace QuickSort {
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
            /// A reference to the next <see cref="Node"/>.
            /// </summary>
            private Node? next;

            /// <summary>
            /// Constructor for node, without a <see cref="Node.next">next</see> reference.
            /// </summary>
            /// <param name="value">The <see cref="value">value</see> of the <see cref="Node"/>.</param>
            /// <param name="next">A reference to the <see cref="next">next</see> <see cref="Node"/>.</param>
            public Node(int value, Node? next) {
                this.value = value;
                this.next = next;
            }

            /// <summary>
            /// Get the <see cref="Node.value">value</see> of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="Node.value">value</see> of the <see cref="Node"/> as int.</returns>
            public int GetValue() => value;
            /// <summary>
            /// Set the <see cref="Node.value">value</see> of the <see cref="Node"/>.
            /// </summary>
            /// <param name="value">The int value the <see cref="Node.value">value</see> should be.</param>
            public void SetValue(int value) => this.value = value;
            /// <summary>
            /// Get the <see cref="Node.next">next</see> reference of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="Node.next">next</see> <see cref="Node"/> reference.</returns>
            public Node GetNext() => next;
            /// <summary>
            /// Set the <see cref="Node.next">next</see> reference of the <see cref="Node"/>.
            /// </summary>
            /// <param name="node">The reference to the <see cref="Node.next">next</see> <see cref="Node"/>.</param>
            public void SetNext(Node node) => next = node;
        }

        /// <summary>
        /// The linked list containing all <see cref="Node"/>s.
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
            list = new Node(random.Next(size*4), null);

            //Pointer to the list to not change the original list start node reference
            Node pointer = list;

            //Loop through and add next references to create the list with the size
            for(int i = 0; i < size - 1; i++) {
                pointer.SetNext(new Node(random.Next(size*4), null));
                pointer = pointer.GetNext();
            }
        }

        /// <summary>
        /// Swaps two <see cref="Node"/>s in the <see cref="LinkedList"/>.
        /// It uses the two previous nodes in order to not having to loop through the <see cref="LinkedList"/>.
        /// </summary>
        /// <param name="first">The <see cref="Node"/> before the first <see cref="Node"/> that should be swapped.</param>
        /// <param name="second">The <see cref="Node"/> before the second <see cref="Node"/> that should be swapped.</param>
        public void Swap(Node first, Node second) {
            //The actual Nodes that should be swapped
            Node swap1 = first.GetNext();
            Node swap2 = second.GetNext();
            //The Node after the second swapping Node
            Node after2 = swap2.GetNext();

            //Set the second to point at the swap1
            second.SetNext(swap1);
            //Set the first to point at swap2
            first.SetNext(swap2);
            //Set swap2 to point at the node after swap1
            swap2.SetNext(swap1.GetNext());
            //Set swap1 to point at after2 which was the node after swap2
            swap1.SetNext(after2);
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
