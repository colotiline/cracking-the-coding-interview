Console.WriteLine(Reverse("!iH"));
Console.WriteLine(Reverse("radar"));
Console.WriteLine(Reverse(string.Empty));

// Personally I wouldn't care about null string,
// because of <Nullable>enable</Nullable>.
static string Reverse(string stringToReverse)
{
    var stringChars = stringToReverse.ToCharArray();
    
    Array.Reverse(stringChars);

    return new string(stringChars);    
}
