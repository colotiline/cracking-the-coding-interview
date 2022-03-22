// See https://aka.ms/new-console-template for more information
Console.WriteLine(IsAnagrams("banana", "apple"));
Console.WriteLine(IsAnagrams("night", "thing"));

static bool IsAnagrams(string oneString, string anotherString)
{
    var oneStringArray = oneString.ToArray();
    var anotherStringArray = anotherString.ToArray();

    Array.Sort(oneStringArray);
    Array.Sort(anotherStringArray);

    for (var i = 0; i < oneStringArray.Length; i++)
    {
        if (oneStringArray[i] != anotherStringArray[i])
        {
            return false;
        }
    }

    return true;
}