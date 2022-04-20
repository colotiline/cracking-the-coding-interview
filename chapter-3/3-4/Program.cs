var rode1 = new Stack<int>();
var rode2 = new Stack<int>();
var rode3 = new Stack<int>();

var n = 5;

for (var i = n; i > 0 ; i--) 
{
    rode1.Push(i);
}

Move(n, rode1, rode3, rode2);

foreach (var item in rode3)
{
    Console.WriteLine(item);
}

static void Move
(
    int diskNumber, 
    Stack<int> from,
    Stack<int> to,
    Stack<int> buffer
)
{
    if (diskNumber == 0) 
    {
        return;
    }

    Move(diskNumber - 1, from, buffer, to);

    to.Push(from.Pop());

    Move(diskNumber - 1, buffer, to, from);
}