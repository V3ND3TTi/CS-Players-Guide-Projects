Console.Write("Please enter a single word: ");
string input = Console.ReadLine()!;

bool isThree = input.Length == 3;

Console.WriteLine(isThree);

int secretNum = 0;

if (input[0] == '#') secretNum += 4;

Console.WriteLine(secretNum);