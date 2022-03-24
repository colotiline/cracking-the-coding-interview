// See https://aka.ms/new-console-template for more information
Console.WriteLine(ReplaceSpaces("  He llo, World! "));

static string ReplaceSpaces(string stringToReplaceSpaces)
{
    // https://referencesource.microsoft.com/#mscorlib/system/string.cs,69fc1d0aa6df8a90
    // Or use a StringBuilder if you need to show that you can use a 
    // StringBuilder.
    return stringToReplaceSpaces.Replace(" ", "%20");
}