namespace Sorting {
    class Utilities {
        /// <summary>
        /// Swaps the two inputed numbers with each other.
        /// </summary>
        public static void Swap(ref int a, ref int b) {
            int temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Creates a array with the inputted <c>size</c> and fills it with random numbers.
        /// </summary>
        /// <param name="size">The size of the array.</param>
        /// <returns>Array with random numbers.</returns>
        public static int[] RandomArray(int size) {
            Random random = new Random();
            int[] array = new int[size];
            //Fill the array with random values
            for(int i = 0; i < array.Length; i++)
                array[i] = random.Next(array.Length*5);
            return array;
        }
    }
}
