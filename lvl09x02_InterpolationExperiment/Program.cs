Console.Write("Please enter any number (1-20): ");
int num1 = int.Parse(Console.ReadLine()!);
Console.Write("Please enter another number (1-20): ");
int num2 = int.Parse(Console.ReadLine()!);

Console.WriteLine($"{num1} + {num2} = {num1 + num2}");