Console.Write("Please enter a number (1-15): ");
int length = int.Parse(Console.ReadLine()!);
Console.Write("Please enter a number (1-15): ");
int width = int.Parse(Console.ReadLine()!);
Console.Write("Please enter a number (1-15): ");
int height = int.Parse(Console.ReadLine()!);

if (length == width && length == height)
{
    Console.WriteLine("A");
}
else if (length > 10 || width > 10 || height > 10)
{
    Console.WriteLine("B");
}
else
{
    Console.WriteLine("C");
}