Console.Write("Please enter the radius of the circle: ");
double radius = double.Parse(Console.ReadLine()!);

double area = Math.PI * Math.Pow(radius, 2);

Console.WriteLine($"The area of the circle is: {area:F2}");