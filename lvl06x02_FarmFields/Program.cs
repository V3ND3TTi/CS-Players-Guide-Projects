int length, width;

Console.Write("Enter the length of the field: ");
length = int.Parse(Console.ReadLine()!);

Console.Write("Enter the width of the field: ");
width = int.Parse(Console.ReadLine()!);

Console.WriteLine($"The area of the field is {length * width}.");