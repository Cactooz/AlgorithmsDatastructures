// See https://aka.ms/new-console-template for more information
using System.Diagnostics;

// Variable for converting GetTimestamp output to nanoseconds
long nanosecondsPerTick = 1000000000 / Stopwatch.Frequency;
// The minimum time for the benchmark
long minTime = long.MaxValue;
// Amount of additions made in the benchmark
int additions = 5000;
// Amount of runs the benchmark is doing
int runAmount = 500000;

for(int i = 0; i < runAmount; i++) {
    Item[] operations = new Item[additions*2+1];
    //Add the first 5 to add
    operations[0] = new Item(ItemType.VALUE, 5);

    //Loop through adding the resisting additions
    for(int j = 1; j < additions * 2 + 1; j+=2) {
        operations[j] = new Item(ItemType.VALUE, 5);
        operations[j+1] = new Item(ItemType.ADD, 0);
    }

    //Create the calculator with the operations
    Calculator calculator = new Calculator(operations);

    //Run and time the calculations
    long t0 = Stopwatch.GetTimestamp();
    calculator.Run();
    long t1 = Stopwatch.GetTimestamp();

    long time = (t1 - t0) * nanosecondsPerTick;

    //If the new time is smaller, save it
    if(time < minTime)
        minTime = time;
}

//Print the smallest time
Console.WriteLine($"{minTime}ns");

/// <summary>
/// Different <c>ItemType</c>s for math operations
/// </summary>
public enum ItemType { ADD, SUB, MUL, DIV, VALUE, MOD10, MOD, ADDMUL }

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
        stack = new DynamicStack(8);
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
            case ItemType.MOD10:
                stack.Push(stack.Pop() % 10);
                break;
            case ItemType.MOD:
                stack.Push(stack.Pop() % stack.Pop());
                break;
            case ItemType.ADDMUL:
                int sum = stack.Pop() * stack.Pop();
                stack.Push((sum / 10) + (sum % 10));
                break;
        }
    }
}
