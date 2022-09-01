/// <summary>
/// A static stack that has a pre-defined size set up with the constructor.
/// </summary>
public class StaticStack {
    /// <summary>
    /// The size of the stack
    /// </summary>
    private readonly int size;
    /// <summary>
    /// Pointer keeping track of where in the arrayStack the last item is
    /// </summary>
    private int pointer = 0;
    private int[] arrayStack;

    /// <summary>
    /// Constructor for the <c>StaticStack</c> that has a pre-defined size
    /// </summary>
    /// <param name="size">The size of the stack</param>
    public StaticStack(int size) {
        this.size = size;
        arrayStack = new int[size];
    }

    /// <summary>
    /// Takes the top/last item from the stack, returns it and moves the pointer to the previous one.
    /// </summary>
    /// <returns>The number of the current top item in the stack</returns>
    public int Pop() {
        //Throw exception if the pointer is outside of the stack
        if(pointer <= 0)
            throw new IndexOutOfRangeException("Stack Underflow");

        //Remove and return the last item from stack
        return arrayStack[--pointer];
    }

    /// <summary>
    /// Adds the inputed value to the top of the stack.
    /// </summary>
    /// <param name="value">The number that should be pushed to the top of the stack</param>
    public void Push(int value) {
        //Throw exception if the pointer is outside of the stack
        if(pointer >= size)
            throw new IndexOutOfRangeException($"Stack Overflow, stack size is: {size}");

        //Set the next value of the stack to the inputed value
        arrayStack[pointer++] = value;
    }
}
