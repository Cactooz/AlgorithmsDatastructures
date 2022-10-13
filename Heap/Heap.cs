namespace Heap {
    internal class Heap {
        /// <summary>
        /// A <see cref="Node"/> in the <see cref="Heap"/>.
        /// Having a <see cref="priority">priority</see> value and branches to two other <see cref="Heap"/> with more <see cref="Node"/>.
        /// </summary>
        private class Node {
            /// <summary>
            /// The priority value of the <see cref="Node"/>.
            /// Lower is a higher priority.
            /// </summary>
            private int priority;
            /// <summary>
            /// Branches to a new <see cref="Heap"/>.
            /// </summary>
            private Heap? left, right;

			/// <summary>
			/// Constructor for <see cref="Node"/> with the <paramref name="priority"/> value with optional <paramref name="left"/>
            /// and <paramref name="right"/> <see cref="Heap"/> branches.
			/// </summary>
			/// <param name="priority">The <see cref="priority">priority</see> value of the <see cref="Node"/>.</param>
			/// <param name="left"><see cref="Nullable"/> (optional) <see cref="left">left</see> <see cref="Heap"/> branch.</param>
			/// <param name="right"><see cref="Nullable"/> (optional) <see cref="right">right</see> <see cref="Heap"/> branch.</param>
			public Node(int priority, Heap? left = null, Heap? right = null) {
                this.priority = priority;
                this.left = left;
                this.right = right;
            }

            /// <summary>
            /// Get the <see cref="priority">priority</see> value of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="priority">priority</see> as an <see cref="int"/>.</returns>
            public int GetPriority() => priority;
            /// <summary>
            /// Set the <see cref="priority">priority</see> value of the <see cref="Node"/>.
            /// </summary>
            /// <param name="priority">The new <see cref="priority">priority</see> as an <see cref="int"/>.</param>
            public void SetPriority(int priority) => this.priority = priority;
            /// <summary>
            /// Get the <see cref="left">left</see> <see cref="Heap"/> of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="left"/> <see cref="Heap"/> reference.</returns>
            public Heap? GetLeft() => left;
            /// <summary>
            /// Set the <see cref="left">left</see> <see cref="Heap"/> reference.
            /// </summary>
            /// <param name="node">The reference to the <see cref="left"/> <see cref="Heap"/>.</param>
            public void SetLeft(Heap heap) => left = heap;
            /// <summary>
            /// Get the <see cref="right">right</see> <see cref="Heap"/> of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="right"/> <see cref="Heap"/> reference.</returns>
            public Heap? GetRight() => right;
            /// <summary>
            /// Set the <see cref="right">right</see> <see cref="Heap"/> reference.
            /// </summary>
            /// <param name="node">The reference to the right <see cref="Heap"/>.</param>
            public void SetRight(Heap heap) => right = heap;

			/// <summary>
			/// Recursively print the <see cref="priority">priority</see> values of every <see cref="Node"/>
            /// in the <see cref="Heap"/>. Using the depth first of the left branch and then the right branch.
			/// </summary>
			public void Print() {
				if(left != null)
					left.root.Print();
				Console.Write($" {priority}");
				if(right != null)
					right.root.Print();
			}
		}
            /// <summary>
            /// Set the <see cref="Node.right">right</see> reference.
            /// </summary>
            /// <param name="node">The reference to the right <see cref="Node"/>.</param>
            public void SetRight(Node node) => right = node;
        }
    }
}
