namespace LinkedList {
    internal class LinkedList {
        /// <summary>
        /// The value of the current <seealso cref="LinkedList"/> item.
        /// </summary>
        private int value;
        /// <summary>
        /// Reference to the next <seealso cref="LinkedList"/> item.
        /// </summary>
        private LinkedList next;

        /// <summary>
        /// Constructor for <seealso cref="LinkedList"/>.
        /// </summary>
        /// <param name="value">The value of the current item.</param>
        /// <param name="next">A reference to the next value.</param>
        public LinkedList(int value, LinkedList next) {
            this.value = value;
            this.next = next;
        }

        /// <summary>
        /// Get the value of the current <seealso cref="LinkedList"/> item.
        /// </summary>
        /// <returns>A int value of the current item.</returns>
        public int GetValue() => value;
        /// <summary>
        /// Get the reference to the next <seealso cref="LinkedList"/> item.
        /// </summary>
        /// <returns>Reference to the next item.</returns>
        public LinkedList GetNext() => next;
        /// <summary>
        /// Set the reference to the next <seealso cref="LinkedList"/> item.
        /// </summary>
        /// <param name="value">The reference to the next item.</param>
        public void SetNext(LinkedList reference) => next = reference;

        /// <summary>
        /// Append a <see cref="LinkedList"/> to the end of this <seealso cref="LinkedList"/>.
        /// </summary>
        /// <param name="input">The list to append to the current one.</param>
        public void Append(LinkedList input) {
            LinkedList current = this;
            //Loop through to the last item in the LinkedList.
            while(current.next != null)
                current = current.next;

            //Set the last next to the first in the input.
            current.next = input;
        }
    }
}
