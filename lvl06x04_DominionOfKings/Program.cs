Console.Write("Please enter the number of provinces: ");
int province = int.Parse(Console.ReadLine()!);

Console.Write("Please enter the number of duchy: ");
int duchy = int.Parse(Console.ReadLine()!);

Console.Write("Please enter the number of estates: ");
int estate = int.Parse(Console.ReadLine()!);

var totalHoldings = (province * 6) + (duchy * 3) + estate;

Console.WriteLine($"The total holdings are {totalHoldings}.");