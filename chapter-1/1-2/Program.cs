Console.WriteLine(Reverse("!iH"));
Console.WriteLine(Reverse("radar"));

static string Reverse(string stringToReverse)
{
    var stringChars = stringToReverse.ToCharArray();
    
    Array.Reverse(stringChars);

    return new string(stringChars);    
}
