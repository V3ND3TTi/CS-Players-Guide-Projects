Console.Write("Please enter the width of the field: ");
int width = int.Parse(Console.ReadLine()!);

Console.Write("Please enter the length of the field: ");
int length = int.Parse(Console.ReadLine()!);

var ditchLength1 = width + length / 2 * width;
var ditchLength2 = length + width / 2 * length;

Console.WriteLine($"Ditch length from the width of the field is {ditchLength1}.");
Console.WriteLine($"Ditch length from the length of the field is {ditchLength2}.");
