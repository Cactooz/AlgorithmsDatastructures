namespace Heap {
	internal class HeapArray {
		/// <summary>
		/// The <see cref="int"/> <see cref="Array"/> holding the Heap priority values.
		/// Using 0 as null.
		/// </summary>
		private int[] queue;
		/// <summary>
		/// The position item before where the next item should be added.
		/// </summary>
		private int index;
		/// <summary>
		/// The amount of items in the heap array.
		/// </summary>
		private int size;

		/// <summary>
		/// Constructor for <see cref="HeapArray"/>, creating a new <see cref="queue">queue</see>
		/// <see cref="int"/> <see cref="Array"/> with the inputted <paramref name="size"/>.
		/// </summary>
		/// <param name="size"></param>
		public HeapArray(int size) {
			queue = new int[size];
			this.size = 0;
		}

		/// <summary>
		/// Adds a new item to the <see cref="queue"/> with the <paramref name="value"/>
		/// as the priority value.
		/// </summary>
		/// <param name="value"></param>
		public void Add(int value) {
			//Add at the start if there are no items
			if(queue[0] == 0) {
				queue[0] = value;
				index = 0;
			}
			else {
				//Add a new item at the next position
				queue[index + 1] = value;
				index++;
				//Swap it up to its correct location
				Swap(index);
			}
			//Increase the size of the amount of elements in the heap
			size++;
		}

		/// <summary>
		/// Swap the item upwards, like bubbles, checking with its parent item if its bigger or smaller.
		/// </summary>
		/// <param name="idx">The position of the item in the <see cref="queue"/>.</param>
		private void Swap(int idx) {
			//If the item is not already at the start
			if(idx != 0) {
				int element;
				//Check where the parent item is located in the array
				if(idx % 2 == 0)
					element = (idx - 2) / 2;
				else
					element = (idx - 1) / 2;

				//Swap the items if the inputted item is smaller than its parent
				if(queue[idx] < queue[element]) {
					int temp = queue[idx];
					queue[idx] = queue[element];
					queue[element] = temp;

					//Continue recursively up through the start of the array
					Swap(element);
				}
			}
		}

		/// <summary>
		/// Removes the first item in the <see cref="queue"/> and moves all
		/// underlying elements up to their correct location.
		/// </summary>
		/// <returns>The <see cref="int"/> value of the removed item.</returns>
		public int Remove() {
			//Save the value of the first item
			int returnValue = queue[0];

			//Move the last element to the start
			queue[0] = queue[index];
			//Remove the last element
			queue[index--] = 0;
			size--;

			//Swap the first item down through the array
			Sink(0);

			//Return the removed item
			return returnValue;
		}

		/// <summary>
		/// Let the inputted by <paramref name="idx"/> item sink down through the array.
		/// Swapping all items in its way making all items finding its correct location,
		/// based on their priority values.
		/// </summary>
		/// <param name="idx">The location of the item to sink down.</param>
		private void Sink(int idx) {
			//Swap the two first items around if there are only two items left
			if(size == 2) {
				if(queue[1] < queue[0]) {
					int temp = queue[0];
					queue[0] = queue[1];
					queue[1] = temp;
				}
			}
			else {
				//Get the position of the left and right branch items
				int left = 2 * idx + 1;
				int right = 2 * idx + 2;
				int swap;

				//Check that the items are in the array, not null (0) and if any of them are smaller than the inputted item
				if(right < queue.Length && idx < queue.Length && queue[idx] != 0 && queue[right] != 0 && queue[left] != 0 && (queue[right] < queue[idx] || queue[left] < queue[idx])) {
					//Swap with the right if its smaller than the left, otherwise swap with the left
					if(queue[right] < queue[left])
						swap = right;
					else
						swap = left;

					//Swap the items
					int tmp = queue[idx];
					queue[idx] = queue[swap];
					queue[swap] = tmp;

					//Continue sinking the next items down recursively
					Sink(swap);
				}
			}
		}

		/// <summary>
		/// Print out the whole <see cref="queue"/> <see cref="int"/> <see cref="Array"/>.
		/// Where 0 are representing null.
		/// </summary>
		public void Print() {
			Console.WriteLine($"{{ {string.Join(",", queue)} }}");
		}

	}
}
