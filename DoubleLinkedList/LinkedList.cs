namespace DoubleLinkedList {
    internal class LinkedList {
        /// <summary>
        /// The value of the current <seealso cref="LinkedList"/> element.
        /// </summary>
        private int value;
        /// <summary>
        /// Reference to the next <seealso cref="LinkedList"/> element.
        /// </summary>
        private LinkedList next;
        /// <summary>
        /// Reference to the previous <seealso cref="LinkedList"/> element.
        /// </summary>
        private LinkedList previous;

        /// <summary>
        /// Constructor for <seealso cref="LinkedList"/>.
        /// </summary>
        /// <param name="value">The value of the current item.</param>
        /// <param name="next">A reference to the next element.</param>
        /// <param name="previous">A reference to the previous element.</param>
        public LinkedList(int value, LinkedList next, LinkedList previous) {
            this.value = value;
            this.next = next;
            this.previous = previous;
        }

        /// <summary>
        /// Get the value of the current <seealso cref="LinkedList"/> element.
        /// </summary>
        /// <returns>A int value of the current element.</returns>
        public int GetValue() => value;
        /// <summary>
        /// Get the reference to the next <seealso cref="LinkedList"/> element.
        /// </summary>
        /// <returns>Reference to the next element.</returns>
        public LinkedList GetNext() => next;
        /// <summary>
        /// Set the reference to the next <seealso cref="LinkedList"/> element.
        /// </summary>
        /// <param name="value">The reference to the next element.</param>
        public void SetNext(LinkedList reference) => next = reference;
        /// <summary>
        /// Get the reference to the previous <seealso cref="LinkedList"/> element.
        /// </summary>
        /// <returns>Reference to the previous element.</returns>
        public LinkedList GetPrevious() => previous;
        /// <summary>
        /// Set the reference to the previous <seealso cref="LinkedList"/> element.
        /// </summary>
        /// <param name="value">The reference to the previous element.</param>
        public void SetPrevious(LinkedList reference) => previous = reference;

    }
}
