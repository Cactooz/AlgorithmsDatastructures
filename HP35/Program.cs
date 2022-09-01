// See https://aka.ms/new-console-template for more information

//Create a simple calculator operation and run it
Calculator calculator = new Calculator(new Item[]{new Item(ItemType.VALUE,3), new Item(ItemType.VALUE, 4), new Item(ItemType.ADD, 0), new Item(ItemType.VALUE, 2), new Item(ItemType.VALUE, 4), new Item(ItemType.ADD, 0), new Item(ItemType.MUL, 0)});
Console.WriteLine(calculator.Run());

/// <summary>
/// Different <c>ItemType</c>s for math operations
/// </summary>
public enum ItemType { ADD, SUB, MUL, DIV, VALUE }

/// <summary>
/// <c>Item</c> containing a value and the type of the value
/// </summary>
public class Item {
    /// <summary>
    /// The type of operation for the <c>Item</c>
    /// </summary>
    private ItemType type;
    /// <summary>
    /// The value of the <c>Item</c>, if the <c>type</c> is <c>VALUE</c>
    /// </summary>
    private int value;

    /// <summary>
    /// Constructor for <c>Item</c>
    /// </summary>
    /// <param name="type">The type of operation from <c>ItemType</c></param>
    /// <param name="value">The value if the operation is VALUE, otherwise it defaults to <c>NULL</c></param>
    public Item(ItemType type, int value) {
        this.type = type;
        if(type == ItemType.VALUE)
            this.value = value;
    }

    /// <summary>
    /// Get and Set the <c>ItemType</c> for the <c>Item</c>
    /// </summary>
    public ItemType Type { get => type; set => type = value; }
    /// <summary>
    /// Get and Set the <c>Value</c> for the <c>Item</c>
    /// </summary>
    public int Value { get => value; set => this.value = value; }
}

/// <summary>
/// Calculates the inputed array of <c>Item</c>s like an HP35 calculator
/// </summary>
public class Calculator {
    /// <summary>
    /// Array of <c>Item</c>s storing all the operations and values
    /// </summary>
    private Item[] expressions;
    /// <summary>
    /// Points at the instruction location in the stack
    /// </summary>
    private int instructionPointer;
    /// <summary>
    /// The stack storing all pushed operations and values in the form of <c>Item</c>
    /// </summary>
    private DynamicStack stack;

    /// <summary>
    /// Construcor for <c>Calculator</c>
    /// </summary>
    /// <param name="expr">The expression the calculator should use</param>
    public Calculator(Item[] expressions) {
        this.expressions = expressions;
        instructionPointer = 0;
        stack = new DynamicStack(2);
    }

    /// <summary>
    /// Run the <c>Calculator</c>
    /// </summary>
    /// <returns>Calculated output</returns>
    public int Run() {
        while(instructionPointer < expressions.Length) {
            Step();
        }
        return stack.Pop();
    }

    /// <summary>
    /// Step through the stack and do the operations
    /// </summary>
    private void Step() {
        Item next = expressions[instructionPointer++];
        int x, y;

        switch(next.Type) {
            case ItemType.VALUE:
                stack.Push(next.Value);
                break;
            case ItemType.ADD:
                stack.Push(stack.Pop() + stack.Pop());
                break;
            case ItemType.SUB:
                stack.Push(stack.Pop() - stack.Pop());
                break;
            case ItemType.MUL:
                stack.Push(stack.Pop() * stack.Pop());
                break;
            case ItemType.DIV:
                stack.Push(stack.Pop() / stack.Pop());
                break;
        }
    }
}
