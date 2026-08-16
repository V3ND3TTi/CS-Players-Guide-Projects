Console.Write("Please enter the X-coordinate of the location: ");
double x = double.Parse(Console.ReadLine()!);

Console.Write("Please enter the Y-coordinate of the location: ");
double y = double.Parse(Console.ReadLine()!);

double distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

Console.WriteLine($"The distance to the location is : {distance:F2}.");