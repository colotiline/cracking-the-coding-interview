var stack = new Stack<int>();

stack.Push(3);
stack.Push(2);
stack.Push(1);

Console.WriteLine(stack.Pop()?.Value);
Console.WriteLine(stack.Pop()?.Value);
Console.WriteLine(stack.Pop()?.Value);

var setOfStacks = new SetOfStacks<int>(3);

setOfStacks.Push(9);
setOfStacks.Push(8);
setOfStacks.Push(7);
setOfStacks.Push(6);
setOfStacks.Push(5);
setOfStacks.Push(4);
setOfStacks.Push(3);
setOfStacks.Push(2);
setOfStacks.Push(1);

Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);
Console.WriteLine(setOfStacks.Pop()?.Value);

public sealed class SetOfStacks<T>
{
    private readonly int threshold;
    private readonly List<Stack<T>> stacks;

    public SetOfStacks(int threshold)
    {
        this.threshold = threshold;
        this.stacks = new List<Stack<T>>();
    }

    public void Push(T value)
    {
        var lastStack = stacks.LastOrDefault();

        if (lastStack is null || lastStack.Count > threshold || !stacks.Any())
        {
            lastStack = new Stack<T>();

            stacks.Add(lastStack);
        }

        lastStack.Push(value);
    }

    public Node<T>? Pop()
    {        
        var lastStack = stacks.LastOrDefault();

        if (lastStack is null)
        {
            return null;
        }

        var node = lastStack.Pop();

        if (lastStack.Count == 0)
        {
            stacks.RemoveAt(stacks.Count - 1);
        }

        return node;
    }
}

public sealed class Stack<T>
{
    public void Push(T value)
    {
        var node = new Node<T>(value);
        node.Next = this.Top;

        this.Top = node;
        this.Count++;
    }

    public Node<T>? Pop()
    {
        if (this.Top is null) 
        {
            return null;
        }

        var item = this.Top;

        this.Top = this.Top.Next;
        this.Count--;

        return item;
    }

    private Node<T>? Top { get; set; }
    public int Count { get; private set;}
}

public sealed class Node<T>
{
    public Node(T value)
    {
        this.Value = value;        
    }
    
    public T Value { get; }
    public Node<T>? Next { get; set; }
}