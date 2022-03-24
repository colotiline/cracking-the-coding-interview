var linkedList = new LinkedList<int>();

linkedList.AddLast(2);
linkedList.AddLast(1);
linkedList.AddLast(7);
linkedList.AddLast(5);
linkedList.AddLast(5);
linkedList.AddLast(1);
linkedList.AddLast(2);
linkedList.AddLast(3);
linkedList.AddLast(4);
linkedList.AddLast(5);
linkedList.AddLast(6);
linkedList.AddLast(7);

RemoveDuplicates(linkedList);

foreach (var item in linkedList)
{
    Console.WriteLine(item);
}

static void RemoveDuplicates(LinkedList<int> linkedList)
{
    if (!linkedList.Any())
    {
        return;
    }

    var currentNode = linkedList.First!;
    var nextNode = currentNode.Next;

    while (currentNode is not null)
    {
        while (nextNode is not null)
        {
            if (currentNode.Value == nextNode.Value)
            {
                linkedList.Remove(nextNode);
            }

            nextNode = nextNode.Next;
        }

        currentNode = currentNode.Next;
        nextNode = currentNode?.Next;
    }
}