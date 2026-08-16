Console.Write("Enter your symbol of choice: ");
string symbol = Console.ReadLine()!;

Console.WriteLine($"{symbol} {symbol}");
Console.WriteLine($" {symbol} ");
Console.WriteLine($"{symbol} {symbol}");

Console.Write("Please enter another symbol: ");
symbol = Console.ReadLine()!;

Console.WriteLine($"{symbol}.{symbol}..{symbol}");