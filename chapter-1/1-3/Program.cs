// See https://aka.ms/new-console-template for more information
Console.WriteLine(RemoveDuplicates("Hello, World!"));
Console.WriteLine(RemoveDuplicates("aaa"));
Console.WriteLine(RemoveDuplicates("abababa"));
Console.WriteLine(RemoveDuplicates("No duplicates!"));

static string RemoveDuplicates(string stringToRemoveDuplicates)
{
    if (stringToRemoveDuplicates.Length < 2)
    {
        return stringToRemoveDuplicates;
    }

    var stringWithoutDuplicates = string.Empty;

    foreach (var character in stringToRemoveDuplicates)
    {
        if (stringWithoutDuplicates.Contains(character))
        {
            continue;
        }

        stringWithoutDuplicates += character;
    }

    return stringWithoutDuplicates;
}