var linkedList = new LinkedList<int>();

linkedList.AddLast(1);
linkedList.AddLast(2);
linkedList.AddLast(3);
linkedList.AddLast(4);
linkedList.AddLast(5);

Console.WriteLine(FindNthToLast(linkedList, 1).Value);
Console.WriteLine(FindNthToLast(linkedList, 4).Value);
Console.WriteLine(FindNthToLast(linkedList, 0).Value);

static LinkedListNode<int> FindNthToLast
(
    LinkedList<int> linkedList,
    int n
)
{
    var position = linkedList.Count - n;
    var nthNode = linkedList.First;

    while (position > 1)
    {
        nthNode = nthNode!.Next;

        position--;
    }

    return nthNode!;
}