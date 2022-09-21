namespace DoubleLinkedList {
    internal class ListElement {
        /// <summary>
        /// The value of the current <see cref="ListElement"/>.
        /// </summary>
        private int value;
        /// <summary>
        /// Reference to the next <see cref="ListElement"/>.
        /// </summary>
        private ListElement next;
        /// <summary>
        /// Reference to the previous <see cref="ListElement"/>.
        /// </summary>
        private ListElement previous;

        /// <summary>
        /// Constructor for <see cref="ListElement"/>.
        /// </summary>
        /// <param name="value">The value of the current item.</param>
        /// <param name="next">A reference to the next element.</param>
        /// <param name="previous">A reference to the previous element.</param>
        public ListElement(int value, ListElement next, ListElement previous) {
            this.value = value;
            this.next = next;
            this.previous = previous;
        }

        /// <summary>
        /// Get the value of the current <see cref="ListElement"/>.
        /// </summary>
        /// <returns>A int value of the current element.</returns>
        public int GetValue() => value;
        /// <summary>
        /// Get the reference to the next <see cref="ListElement"/>.
        /// </summary>
        /// <returns>Reference to the next element.</returns>
        public ListElement GetNext() => next;
        /// <summary>
        /// Set the reference to the next <see cref="ListElement"/>.
        /// </summary>
        /// <param name="value">The reference to the next element.</param>
        public void SetNext(ListElement reference) => next = reference;
        /// <summary>
        /// Get the reference to the previous <see cref="ListElement"/> element.
        /// </summary>
        /// <returns>Reference to the previous element.</returns>
        public ListElement GetPrevious() => previous;
        /// <summary>
        /// Set the reference to the previous <see cref="ListElement"/> element.
        /// </summary>
        /// <param name="value">The reference to the previous element.</param>
        public void SetPrevious(ListElement reference) => previous = reference;
    }
}
