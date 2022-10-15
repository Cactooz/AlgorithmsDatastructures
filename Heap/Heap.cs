using System.Text;

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
			/// Branches to a new <see cref="Nullable"/> <see cref="Node"/>.
            /// </summary>
			private Node? left, right;
			/// <summary>
			/// The amount of <see cref="Node"/>s that are below the current <see cref="Node"/>.
			/// Not counting itself, but going down all the way counting every single <see cref="Node"/> below.
			/// </summary>
			private int subNodes;

			/// <summary>
			/// Constructor for <see cref="Node"/> with the <paramref name="priority"/> value with optional <paramref name="left"/>
            /// and <paramref name="right"/> <see cref="Heap"/> branches.
			/// </summary>
			/// <param name="priority">The <see cref="priority">priority</see> value of the <see cref="Node"/>.</param>
			/// <param name="subNodes">The amount of <see cref="Node"/>s that are below this <see cref="Node"/> in the <see cref="Heap"/> tree structure.</param>
			/// <param name="left"><see cref="Nullable"/> (optional) <see cref="left">left</see> <see cref="Node"/> branch.</param>
			/// <param name="right"><see cref="Nullable"/> (optional) <see cref="right">right</see> <see cref="Node"/> branch.</param>
			public Node(int priority, int subNodes = 0, Node? left = null, Node? right = null) {
                this.priority = priority;
				this.subNodes = subNodes;
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
			public void SetPriority(int value) => this.priority = value;
            /// <summary>
			/// Get the amount of <see cref="subNodes">subNodes</see> that the <see cref="Node"/>
			/// has. Not counting itself, only all left and right <see cref="Node"/>s.
            /// </summary>
			/// <returns>The amount of <see cref="Node"/>s as <see cref="int"/>.</returns>
			public int GetSubNodes() => subNodes;
            /// <summary>
			/// Get the <see cref="left">left</see> <see cref="Node"/> branch of the <see cref="Node"/>.
            /// </summary>
			/// <returns>The <see cref="left"/> <see cref="Node"/> reference.</returns>
			public Node? GetLeft() => left;
            /// <summary>
			/// Set the <see cref="left">left</see> <see cref="Node"/> reference.
            /// </summary>
			/// <param name="node">The reference to the <see cref="left"/> <see cref="Node"/>.</param>
			public void SetLeft(Node value) => left = value;
            /// <summary>
			/// Get the <see cref="right">right</see> <see cref="Node"/> branch of the <see cref="Node"/>.
            /// </summary>
			/// <returns>The <see cref="right"/> <see cref="Node"/> reference.</returns>
			public Node? GetRight() => right;
			/// <summary>
			/// Set the <see cref="right">right</see> <see cref="Node"/> reference.
			/// </summary>
			/// <param name="node">The reference to the right <see cref="Node"/>.</param>
			public void SetRight(Node value) => right = value;

			/// <summary>
			/// Recursively print the <see cref="priority">priority</see> values of every <see cref="Node"/>
            /// in the <see cref="Heap"/>. Using the depth first of the left branch and then the right branch.
			/// </summary>
			/// <returns>The removed <see cref="Nullable"/> <see cref="Node"/>.</returns>
			public Node? Promote() {
				//If there are no branches, return null to remove the current node
				if(left == null && right == null) return null;

				//Promote the right node if the are no left branch node
			}

			/// <summary>
			/// Recursively print a tree visualization of the whole <see cref="Heap"/> tree with all the 
			/// <see cref="priority">priority</see> values. 
			/// </summary>
			/// <param name="buffer">The text buffer with already added output.</param>
			/// <param name="prefix">What should be printed before the <see cref="priority"/> value.</param>
			/// <param name="depthPrefix">What should be printed left of the <see cref="priority"/> value <paramref name="prefix"/>
            /// to make space for the underlying branches.</param>
			public void Print(StringBuilder buffer, string prefix = "", string depthPrefix = "") {
				//Print the node
				buffer.Append($"{prefix}[{priority}:{subNodes}]\n");
				//Go down the right branch
				if(right != null)
					right.Print(buffer, depthPrefix + " ├─ R:", depthPrefix + " │   ");
				else
					buffer.Append($"{depthPrefix} ├─ R:\n");
				//Go down the left branch
				if(left != null)
                    left.Print(buffer, depthPrefix + " └─ L:", depthPrefix + "     ");
				else
                    buffer.Append($"{depthPrefix} └─ L:\n");
				}

		}

        /// <summary>
        /// The base root <see cref="Nullable"/> <see cref="Node"/>.
        /// </summary>
        private Node? root;

		/// <summary>
		/// The amount of other <see cref="Node"/>s in the <see cref="Node.left">left</see> and
        /// <see cref="Node.right">right</see> branches below the <see cref="root"/> <see cref="Node"/>.
		/// </summary>
		private int size = 0;

		/// <summary>
		/// Empty constructor for <see cref="Heap"/> not adding any <see cref="root">root</see> <see cref="Node"/>.
		/// </summary>
		public Heap() { }

        /// <summary>
        /// Constructor for <see cref="Heap"/> with a single <see cref="root">root</see> <see cref="Node"/>.
        /// </summary>
        /// <param name="value">The <see cref="Node.priority"/> value.</param>
		public Heap(int value) {
            root = new Node(value);
			}

        /// <summary>
        /// Print out the whole <see cref="Heap"/> using the <see cref="Node.Print()"/>.
        /// Printing it in a tree in a visual way with branches.
        /// </summary>
		public void Print() {
            if(root != null) {
                StringBuilder buffer = new();
				root.Print(buffer);
                Console.WriteLine(buffer.ToString());
			} else
                Console.WriteLine("The Heap is empty");
        }

		/// <summary>
		/// Add a new <see cref="Node"/> to the <see cref="Heap"/> in the correct location.
		/// Depending on the inputted <paramref name="value"/> for the <see cref="Node.priority">priority</see>.
		/// </summary>
		/// <param name="value">The <see cref="Node.priority">priority</see> of the <see cref="Node"/>.</param>
		public void Add(int value) {
            //Add a new root node if there are no current root Node
            if(root == null) {
                root = new Node(value);
                size++;
                return;
            }

            Heap pointer = this;

            //Swap the values if the priority value is smaller than the pointers root priority
            if(value < pointer.root.GetPriority()) {
                int temp = value;
                value = pointer.root.GetPriority();
                pointer.root.SetPriority(temp);

                pointer.size++;
            }

            //If the left branch is empty add the new Heap of nodes there
            if(pointer.root.GetLeft() == null) {
                pointer.root.SetLeft(new Heap(value));
            }
            //If the right branch is empty add the new Heap of nodes there
            else if(pointer.root.GetRight() == null) {
                pointer.root.SetRight(new Heap(value));
            }
            //Go recursively down and add the new value at the correct spot in the heap
            else {
                //Go left if the left branch is smaller otherwise go right
                if(pointer.root.GetLeft().size < pointer.root.GetRight().size)
                    pointer = pointer.root.GetLeft();
                else
                    pointer = pointer.root.GetRight();

                //Increase the size of that heap branch
                pointer.size++;
                //Recursively go down and put the value at the correct location
                pointer.Add(value);
            }
            
        }

    }
}
