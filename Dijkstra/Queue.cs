namespace Dijkstra {
	internal class Queue {
		/// <summary>
		/// The <see cref="Nullable"/> <see cref="Dijkstra.Entry"/> <see cref="Array"/> holding the unprocessed <see cref="City"/> objects..
		/// </summary>
		private Dijkstra.Entry?[] queue;
		/// <summary>
		/// The position item before where the next item should be added.
		/// </summary>
		private int index;
		/// <summary>
		/// The amount of items in the heap queue.
		/// </summary>
		private int size;

        /// <summary>
        /// Constructor for <see cref="Queue"/>, creating a new <see cref="queue">queue</see>
        /// <see cref="Nullable"/> <see cref="Dijkstra.Entry"/> <see cref="Array"/> with the inputted <paramref name="size"/>.
        /// </summary>
        /// <param name="size">The size of the <see cref="Nullable"/> <see cref="Dijkstra.Entry"/> <see cref="queue">queue</see> <see cref="Array"/>.</param>
        public Queue(int size) {
			queue = new Dijkstra.Entry?[size];
			this.size = 0;
		}

		/// <summary>
		/// Adds a new item to the <see cref="queue"/> with the <see cref="Dijkstra.Entry.distance"/> as priority.
		/// </summary>
		/// <param name="value">The <see cref="Dijkstra.Entry"/> to add.</param>
		public void Add(Dijkstra.Entry value) {
			//Add at the start if there are no items
			if(queue[0] == null) {
				//Set the entry's location in the heap
				value.HeapIndex = 0;
				queue[0] = value;
				index = 0;
			}
			else {
                //Set the entry's location in the heap
                value.HeapIndex = index + 1;
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
		public void Swap(int? idx) {
			//Stop swapping if there are less than two elements or if the input is null
			if(!idx.HasValue || size < 2)
				return;

			int id = (int)idx;

			//If the item is not already at the start
			if(id != 0) {
				int element;
				//Check where the parent item is located in the array
				if(id % 2 == 0)
					element = (id - 2) / 2;
				else
					element = (id - 1) / 2;

				//Swap the items if the inputted item is smaller than its parent
				if(queue[id]!.Distance < queue[element]!.Distance) {
					Dijkstra.Entry? temp = queue[id];
					queue[id] = queue[element];
					queue[element] = temp;
					//Swap the Heap index values of both entires
					queue[id]!.HeapIndex = id;
					queue[element]!.HeapIndex = element;

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
		public Dijkstra.Entry? Remove() {
			if(size <= 0)
				return null;

			//Save the value of the first item
			Dijkstra.Entry? returnValue = queue[0];

			returnValue!.HeapIndex = null;

			//Move the last element to the start
			queue[0] = queue[index];
			queue[0]!.HeapIndex = 0;
			//Remove the last element
			queue[index--] = null;
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
				if(queue[1]!.Distance < queue[0]!.Distance) {
					Dijkstra.Entry? temp = queue[0];
					queue[0] = queue[1];
					queue[1] = temp;
                    //Swap the Heap index values of both entires
                    queue[0]!.HeapIndex = 0;
					queue[1]!.HeapIndex = 1;
				}
			}
			else {
				//Get the position of the left and right branch items
				int left = 2 * idx + 1;
				int right = 2 * idx + 2;
				int swap;

				//Check that the items are in the array, not null and if any of them are smaller than the inputted item
				if(right < queue.Length && idx < queue.Length && queue[idx] != null && queue[right] != null && queue[left] != null && (queue[right]!.Distance < queue[idx]!.Distance || queue[left]!.Distance < queue[idx]!.Distance)) {
					//Swap with the right if its smaller than the left, otherwise swap with the left
					if(queue[right]!.Distance < queue[left]!.Distance)
						swap = right;
					else
						swap = left;

					//Swap the items
					Dijkstra.Entry? tmp = queue[idx];
					queue[idx] = queue[swap];
					queue[swap] = tmp;
                    //Swap the Heap index values of both entires
                    queue[idx]!.HeapIndex = idx;
					queue[swap]!.HeapIndex = swap;

					//Continue sinking the next items down recursively
					Sink(swap);
				}
			}
		}

		/// <summary>
		/// If the heap <see cref="Queue"/> has <see cref="Dijkstra.Entry"/> in it or not.
		/// </summary>
		/// <returns><see langword="true"/> if the heap is empty,
		/// <see langword="false"/> if the heap has <see cref="Dijkstra.Entry"/> objects left in it</returns>
		public bool Empty() {
			return (size <= 0);
		}

		/// <summary>
		/// Print out the whole <see cref="queue"/> <see cref="int"/> <see cref="Array"/>.
		/// </summary>
		public void Print() {
			Console.Write("{ ");
			for(int i = 0; i < queue.Length; i++) {
				if(queue[i] != null) {
					if(i != 0)
						Console.Write(", ");
					
					Console.Write(queue[i]);
				}
			}
			Console.WriteLine(" }");
		}

	}
}
