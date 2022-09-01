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

/// <summary>
/// A dynamic stack that gets larger and smaller over time.
/// </summary>
public class DynamicStack {
    /// <summary>
    /// The size of the stack.
    /// </summary>
    private int size;
    /// <summary>
    /// The amount of elements that the stack should be changed by.
    /// </summary>
    private readonly int changeSize = 4;
    /// <summary>
    /// Pointer keeping track of where in the arrayStack the last item is.
    /// </summary>
    private int pointer = 0;
    private int[] arrayStack;

    /// <summary>
    /// Constructor for the <c>DynamicStack</c> that has a starting size.
    /// </summary>
    /// <param name="size">The starting size of the stack.</param>
    public DynamicStack(int size) {
        this.size = size;
        arrayStack = new int[size];
    }

    /// <summary>
    /// Takes the top/last item from the stack, returns it and moves the pointer to the previous one.
    /// </summary>
    /// <returns>The number of the current top item in the stack.</returns>
    public int Pop() {
        //Throw exception if the pointer is outside of the stack
        if(pointer <= 0)
            throw new IndexOutOfRangeException("Stack Underflow");
        
        //Decrease the stack size if the stack is too small, to save memory
        if(pointer < size - changeSize - (changeSize / 2))
            DecreaseStackSize();

        //Remove and return the last item from stack
        return arrayStack[--pointer];
    }

    /// <summary>
    /// Adds the inputed value to the top of the stack.
    /// </summary>
    /// <param name="value">The number that should be pushed to the top of the stack.</param>
    public void Push(int value) {
        //If the stack is to small, increase its size
        if(pointer >= size)
            IncreaseStackSize();

        //Set the next value of the stack to the inputed value
        arrayStack[pointer++] = value;
    }

    /// <summary>
    /// Increases the <c>arrayStack</c> by <c>changeSize</c> elements.
    /// </summary>
    private void IncreaseStackSize() {
        //Make a new temporary array stack with the larger size
        size += changeSize;
        int[] tmpArrayStack = new int[size];

        //Fill the new temporary array stack with all the old items
        for(int i = 0; i < size - changeSize; i++)
            tmpArrayStack[i] = arrayStack[i];

        //Overwrite the old arrayStack with the new larger array stack
        arrayStack = tmpArrayStack;
    }

    /// <summary>
    /// Decreases the <c>arrayStack</c> by <c>changeSize</c> elements.
    /// </summary>
    private void DecreaseStackSize() {
        //Make a new temporary array stack with the smaller size
        size -= changeSize;
        int[] tmpArrayStack = new int[size];

        //Fill the new temporary array stack with all the old items
        for(int i = 0; i < size; i++)
            tmpArrayStack[i] = arrayStack[i];

        //Overwrite the old arrayStack with the new smaller array stack
        arrayStack = tmpArrayStack;
    }
}
