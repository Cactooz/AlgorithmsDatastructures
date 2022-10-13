namespace Heap {
    internal class Heap {
        private class Node {
            private int priority, subNodes;
            private Node? left, right;

            public Node(int priority, int subNodes, Node? left = null, Node? right = null) {
                this.priority = priority;
                this.left = left;
                this.right = right;
                this.subNodes = subNodes;
            }

            /// <summary>
            /// Get the <see cref="priority">priority</see> value of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="priority">priority</see> as an <see cref="int"/>.</returns>
            public int GetPriority() => priority;
            /// <summary>
            /// Get the <see cref="subNodes">subNodes</see> of the current <see cref="Node"/>
            /// in the whole <see cref="Heap"/>. Where the <see cref="subNodes">subNodes</see> are the amount of <see cref="Node"/>s
            /// below the current <see cref="Node"/>.
            /// </summary>
            /// <returns>The amount of <see cref="subNodes">subNodes</see> as an <see cref="int"/>.</returns>
            public int GetDepth() => subNodes;
            /// <summary>
            /// Set the amount <see cref="subNodes">subNodes</see> for the <see cref="Node"/> in the <see cref="Heap"/>.
            /// </summary>
            /// <param name="value">The subNodes value as <see cref="int"/> of the <see cref="Node"/> in the <see cref="Heap"/></param>
            public void SetDepth(int value) => subNodes = value;
            /// <summary>
            /// Get the <see cref="Node.left">left</see> of the node.
            /// </summary>
            /// <returns>The <see cref="left"/> reference.</returns>
            public Node? GetLeft() => left;
            /// <summary>
            /// Set the <see cref="Node.left">left</see> reference.
            /// </summary>
            /// <param name="node">The reference to the left <see cref="Node"/>.</param>
            public void SetLeft(Node node) => left = node;
            /// <summary>
            /// Get the <see cref="Node.right">right</see> of the <see cref="Node"/>.
            /// </summary>
            /// <returns>The <see cref="right"/> reference.</returns>
            public Node? GetRight() => right;
            /// <summary>
            /// Set the <see cref="Node.right">right</see> reference.
            /// </summary>
            /// <param name="node">The reference to the right <see cref="Node"/>.</param>
            public void SetRight(Node node) => right = node;
        }
    }
}
