var sumLinkedList = Sum
(
    new LinkedList<int>(new int[] { 3, 1, 5 }),
    new LinkedList<int>(new int[] { 5, 9, 2 })
);

foreach (var item in sumLinkedList)
{
    Console.Write(item);
    Console.Write('\t');
}

Console.Write('\n');

static LinkedList<int> Sum
(
    LinkedList<int> firstLinkedList, 
    LinkedList<int> secondLinkedList
)
{
    var oneNumber = GetNumber(firstLinkedList);
    var secondNumber = GetNumber(secondLinkedList);

    var result = oneNumber + secondNumber;

    return ToLinkedList(result);

    int GetNumber(LinkedList<int> listNumber)
    {
        var number = 0;

        var power = 0;

        foreach (var item in listNumber)
        {
            number += item * (int) Math.Pow(10, power);

            power +=1;
        }

        return number;
    }

    LinkedList<int> ToLinkedList(int number)
    {
        var linkedList = new LinkedList<int>();

        while (number > 0)
        {
            linkedList.AddFirst(number % 10);

            number /= 10;
        }

        return linkedList;
    }
}