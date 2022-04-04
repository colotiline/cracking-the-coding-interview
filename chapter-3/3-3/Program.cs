var stack = new Stack<int>();

stack.Push(3);
stack.Push(2);
stack.Push(1);

Console.WriteLine(stack.Pop()?.Value);
Console.WriteLine(stack.Pop()?.Value);
Console.WriteLine(stack.Pop()?.Value);

Console.WriteLine('-');

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

Console.WriteLine('-');

setOfStacks.Push(6);
setOfStacks.Push(5);
setOfStacks.Push(4);
setOfStacks.Push(3);
setOfStacks.Push(2);
setOfStacks.Push(1);

Console.WriteLine(setOfStacks.PopAt(0)?.Value);

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
        var lastStack = stacks.FirstOrDefault(_ => _.Count != threshold);

        if (lastStack is null || lastStack.Count == threshold || !stacks.Any())
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

    public Node<T>? PopAt(int stackIndex, bool bottom = false)
    {
        var node = 
            bottom 
            ? this.stacks[stackIndex].PopBottom()
            : this.stacks[stackIndex].Pop();        

        if (this.stacks[stackIndex].Count == 0)
        {
            this.stacks.RemoveAt(stackIndex);

            return node;
        }

        if (this.stacks.Count > stackIndex + 1)
        {
            var bottomNode = PopAt(stackIndex + 1, true);

            if (bottomNode is not null)
            {
                Push(bottomNode.Value);
            }
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

        if (this.Top is not null)
        {
            this.Top.Previous = node;
        }

        if (this.Count == 0)
        {
            this.Bottom = node;
        }

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

    public Node<T>? PopBottom()
    {
        var bottom = this.Bottom;

        if (this.Bottom is not null)
        {
            this.Bottom = this.Bottom.Previous;
        }

        this.Count--;

        return bottom;
    }

    private Node<T>? Top { get; set; }
    private Node<T>? Bottom { get; set; }
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
    public Node<T>? Previous { get; set; }
}