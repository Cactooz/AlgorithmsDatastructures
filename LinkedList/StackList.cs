namespace LinkedList {
    internal class StackList {
        private LinkedList stack;
        private LinkedList stackPointer;

        /// <summary>
        /// Add a new <seealso cref="LinkedList"/> element to the top of the stack.
        /// </summary>
        /// <param name="value">The value the next <seealso cref="LinkedList"/> element should have.</param>
        public void Push(int value) {
            //Create a new stack if the stack is null.
            if(stack == null) {
                stack = new LinkedList(value, null);
                //Point the stackPointer to the stack.
                stackPointer = stack;
            } else {
                //Add new LinkedList element to stack.
                stackPointer.SetNext(new LinkedList(value, null));

                //Move the stackPointer to next element in the stack.
                stackPointer = stackPointer.GetNext();
            }
        }

        /// <summary>
        /// Get the last value from the <seealso cref="StackList"/> element on the stack and remove the element.
        /// </summary>
        /// <returns>Int value from the last <seealso cref="LinkedList"/> element.</returns>
        /// <exception cref="NullReferenceException"></exception>
        public int Pop() {
            //Throw error if the stack does not exist.
            if(stack == null)
                throw new NullReferenceException("Could not pop, stack does not exist.");
            
            //Set the pointer to the beginning of the stack.
            stackPointer = stack;

            //Returning value.
            int value;

            //If there are more elements than on in the stack.
            if(stack.GetNext() != null) {
                //Loop through and set stackPointer to the second last element.
                while(stackPointer.GetNext().GetNext() != null)
                    stackPointer = stackPointer.GetNext();

                //Get the value of the last element.
                value = stackPointer.GetNext().GetValue();

                //Remove reference to next element.
                stackPointer.SetNext(null);
            } else {
                //Get the value of the first element.
                value = stackPointer.GetValue();

                //Unreference both the stack and stackPointer.
                stack = null;
                stackPointer = null;
            }

            //Return the last elements value.
            return value;
        }

        /// <summary>
        /// Print the contents of the <seealso cref="StackList"/>.
        /// </summary>
        public void PrintStack() {
            if(stack == null) {
                Console.WriteLine("Stack does not exist");
                return;
            }

            //Set the pointer to the beginning of the stack.
            LinkedList pointer = stack;

            //Print all values of the elements in the stack.
            Console.Write($"{{ {pointer.GetValue()}");
            while(pointer.GetNext() != null) {
                pointer = pointer.GetNext();
                Console.Write($", {pointer.GetValue()}");
            }
            Console.WriteLine(" }");
        }
    }
}
