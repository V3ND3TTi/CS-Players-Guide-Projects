Console.Write("Please enter the 3 digit combination: ");
string combo = Console.ReadLine()!;

if (combo.Length == 3)
{
    if (char.IsDigit(combo[0]) && char.IsDigit(combo[1]) && char.IsDigit(combo[2]))
    {
        Console.WriteLine($"{combo}");
    }
}