Console.Write("Please enter a number (1-15): ");
int length = int.Parse(Console.ReadLine()!);
Console.Write("Please enter a number (1-15): ");
int width = int.Parse(Console.ReadLine()!);
Console.Write("Please enter a number (1-15): ");
int height = int.Parse(Console.ReadLine()!);

if (length == width)
{
    if (length == height)
    {
        Console.WriteLine("A");
    }
    else
    {
        // We matched length and width, but height is different.
        // We must check if any individual dimension is > 10.
        if (length > 10)      Console.WriteLine("B");
        else if (width > 10)  Console.WriteLine("B");
        else if (height > 10) Console.WriteLine("B");
        else                  Console.WriteLine("C");
    }
}
else
{
    // Length and width are not equal.
    if (length > 10)      Console.WriteLine("B");
    else if (width > 10)  Console.WriteLine("B");
    else if (height > 10) Console.WriteLine("B");
    else                  Console.WriteLine("C");
}