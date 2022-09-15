namespace LinkedList {
    internal class Arrays {
        private int[] array;

        /// <summary>
        /// Constructor for Arrays
        /// </summary>
        /// <param name="array">The full array with elements</param>
        public Arrays(int[] array) {
            this.array = array;
        }

        /// <summary>
        /// Append an array to the end of this array.
        /// </summary>
        /// <param name="input">The array to append to the current one.</param>
        /// <returns>A bigger array with both arrays combined.</returns>
        public int[] Append(int[] input) {
            //Get the combined length of both arrays
            int length = this.array.Length + input.Length;
            int[] array = new int[length];

            //Add in both arrays after eachother in the new array
            for(int i = 0; i < length; i++) {
                if(i < this.array.Length)
                    array[i] = this.array[i];
                else
                    array[i] = input[i];
            }

            return array;
        }
    }
}
