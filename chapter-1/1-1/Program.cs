// See https://aka.ms/new-console-template for more information
Console.WriteLine(IsAllCharactersUnique("nonunique"));
Console.WriteLine(IsAllCharactersUnique("fine"));

// There is a restriction to this solution that we will have only a-z letters.
// If you need to check unique characters for a larger set of characters,
// you need an extra space to create an array – 0(n) array size to get
// O(n) algorithm solution.
// Or you will need to sort an input string and check every next character
// with previous. But you will get 0(nlogn) algorithm solution and will need
// some extra space to sort your input string.
static bool IsAllCharactersUnique(string stringToCheck)
{
    // Using int as a bit vector.
    // Assume it like a line of zeros - 00000000000000000000000000000000.
    var checker = 0;

    for (var i = 0; i < stringToCheck.Length; i++)
    {
        // Minus 'a' required to put value of a leter to a possible 
        // position from 0 to 25.
        // E.g. t - a means 116 - 97 = 19.
        var bitAtIndex = stringToCheck[i] - 'a';

        // 1 << bitAtIndex is a bitwise shifter which place 1 in a line of
        // zeros at bitAtIndex position.
        // E.g. 1 << 0 = 00000000000000000000000000000001.
        // & is a bit 'AND'. 
        // 0 AND 0 = 0.
        // 0 AND 1 = 0.
        // 1 AND 0 = 0.
        // 1 AND 1 = 1.
        // Basically you get checker and compare bits in it with a shifted
        // representation of a letter position.
        // E.g. 00000000000000000000000000000000 & 
        // 00000000000000000000000000000001 
        // = 00000000000000000000000000000000
        if ((checker & (1 << bitAtIndex)) > 0)
        {
            return false;
        }

        // You set a bit position of a letter to 1.
        // So in the future upper condition could be True if there is a 
        // duplicate letter.
        // E.g. 
        // 00000000000000000000000000000000 |= (1 << 0)
        // Equals to 00000000000000000000000000000001.
        // So if you will have another letter 'a', upper condition will be true.
        checker |= (1 << bitAtIndex);
    }

    return true;
}