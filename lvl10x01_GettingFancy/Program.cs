Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Title = "Demo";

Console.Write("Please enter a number: ");
int num1 = int.Parse(Console.ReadLine()!);

Console.Write("Please enter another number: ");
int num2 = int.Parse(Console.ReadLine()!);

Console.Clear();
Console.ForegroundColor = ConsoleColor.Magenta;
Console.BackgroundColor = ConsoleColor.DarkGray;
Console.WriteLine($"{num1} + {num2} = {num1 + num2}.");
Console.ResetColor();
Console.Beep();
Console.Write("Press any key to quit...");
Console.ReadKey(false);
Console.Clear();