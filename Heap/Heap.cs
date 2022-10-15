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
			/// Used to <see cref="Remove"/> a <see cref="Node"/> from the <see cref="Heap"/>.
			/// Recursively makes sure to promote all underlying <see cref="Node"/>s.
			/// </summary>
			/// <returns>The removed <see cref="Nullable"/> <see cref="Node"/>.</returns>
			public Node? Promote() {
				//If there are no branches, return null to remove the current node
				if(left == null && right == null) return null;

				//Promote the right node if the are no left branch node
				if(left == null) return right;

				//Promote the left node if the are no right branch node
				if(right == null) return left;

				//Check if the left node has a smaller priority than the right node
				if(left.GetPriority() < right.GetPriority()) {
					//Set the priority to the left branch nodes priority
					priority = left.GetPriority();
					//Promote all underlying nodes
					left = left.Promote();
				} else {
					//Set the priority to the right branch nodes priority
					priority = right.GetPriority();
					//Promote all underlying nodes
					right = right.Promote();
				}
				//Remove one subNode from the current node
				subNodes--;

				//Return the current node that should be removed
				return this;
			}

			/// <summary>
			/// Add a new <see cref="Node"/> to the tree, moving down through the <see cref="Heap"/> tree
			/// and adds a new <see cref="Node"/> at the bottom of the tree.
			/// </summary>
			/// <param name="value">The <see cref="priority"/> of the new <see cref="Node"/>.</param>
			/// <returns>The <see cref="Node"/> that gets swapped to the new position.</returns>
			public Node Input(int value) {
				//Swap the values if the priority value is smaller than the pointers root priority
				if(value < priority) {
					int temp = priority;
					priority = value;
					Input(temp);
				}
				//If the left branch is empty add the new Heap of nodes there
				else if(left == null) {
					left = new Node(value);
					subNodes++;
					depth++;
				}
				//If the right branch is empty add the new Heap of nodes there
				else if(right == null) {
					right = new Node(value);
					subNodes++;
					depth++;
				}
				//Go recursively down and add the new value at the correct spot in the heap
				else {
					//Go left if the left branch is smaller otherwise go right
					if(left.GetSubNodes() < right.GetSubNodes())
						left = left.Input(value);
					else
						right = right.Input(value);

					subNodes++;
					depth++;
			}

				return this;
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
		/// The depth that a <see cref="Node"/> is getting moved down.
		/// </summary>
		private static int depth = 0;

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
		/// <returns>The amount of steps down the <see cref="Heap"/> tree the <see cref="Node"/> was added, as <see cref="int"/>.</returns>
		public int Add(int value) {
			depth = 0;
            //Add a new root node if there are no current root Node
            if(root == null) {
                root = new Node(value);
				return 0;
			}

			root.Input(value);
			return depth;
            }

		/// <summary>
		/// Removes the <see cref="root"/> <see cref="Node"/> from the <see cref="Heap"/>
		/// and moves up all underlying elements to its correct location based on the <see cref="Node.priority"/>.
		/// </summary>
		/// <returns>The <see cref="Node.priority"/> value of the removed <see cref="Node"/>.</returns>
		public int? Remove() {
			if(root != null) {
				//Save the Node to return
				int returnNode = root.GetPriority();

				//Promote all underlying nodes
				root = root.Promote();

				//Return the removed Nodes priority
				return returnNode;
            }

			//Return null if there are no nodes
			return null;
            }

		/// <summary>
		/// Increment the <see cref="root"/> <see cref="Node"/> with <paramref name="newPriority"/> and Push the <see cref="Node"/>
		/// down the <see cref="Heap"/> tree to its new correct position.
		/// </summary>
		/// <param name="newPriority">The <see cref="int"/> value that the <see cref="Node.priority"/> should be increased with.</param>
            
        }

    }
}
