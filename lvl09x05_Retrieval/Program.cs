Console.Write("Please enter two numbers separated by a comma (ex - 1,2): ");
string input = Console.ReadLine()!;

int commaIndex = input.IndexOf(',');
string input1 = input.Substring(0, commaIndex);
string input2 = input.Substring(commaIndex+1);

int num1 = (int.Parse(input1.Trim())) % 10;
int num2 = (int.Parse(input2.Trim())) % 10;
int num3 = (num1 + num2) % 10;
int num4 = (num1 * num2) % 10;
int num5 = (num1 * 3) % 10;
int num6 = (num2 * 5) % 10;

string grid = $"""
              [{num1}][{num2}]
              [{num3}][{num4}]
              [{num5}][{num6}]
              """;
Console.WriteLine(grid);