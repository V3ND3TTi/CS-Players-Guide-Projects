Console.Write("Please enter a combination of symbols (x, o, ^, #): ");
string input = Console.ReadLine()!;

bool isThree = input.Length == 3;

Console.WriteLine(isThree);

int secretNum = 0;
string passphrase = "";

if (input[0] == '#')
{
    secretNum += 4;
    passphrase += "dah";
}

Console.WriteLine(secretNum);
Console.WriteLine(passphrase);