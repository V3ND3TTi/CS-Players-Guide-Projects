Console.Write("Please enter two numbers separated by a comma (ex - 1,2): ");
string input = Console.ReadLine()!;

int commaIndex = input.IndexOf(',');
string input1 = input.Substring(0, commaIndex);
string input2 = input.Substring(commaIndex+1);

int num1 = int.Parse(input1.Trim());
int num2 = int.Parse(input2.Trim());

Console.WriteLine($"You entered: {num1} & {num2}.");