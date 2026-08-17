Console.Write("Please enter a combination of 3 symbols (x, o, ^, #): ");
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
else if (input[0] == 'o')
{
    secretNum += -3;
    passphrase += "fus";
}
else if (input[0] == 'x')
{
    secretNum += 1;
    passphrase += "bex";
}
else if (input[0] == '^')
{
    secretNum += -2;
    passphrase += "ro";
}
else
{
    passphrase += "?";
}

if (input[1] == '#')
{
    secretNum += 4;
    passphrase += "dah";
}
else if (input[1] == 'o')
{
    secretNum += -3;
    passphrase += "fus";
}
else if (input[1] == 'x')
{
    secretNum += 1;
    passphrase += "bex";
}
else if (input[1] == '^')
{
    secretNum += -2;
    passphrase += "ro";
}
else
{
    passphrase += "?";
}

if (input[2] == '#')
{
    secretNum += 4;
    passphrase += "dah";
}
else if (input[2] == 'o')
{
    secretNum += -3;
    passphrase += "fus";
}
else if (input[2] == 'x')
{
    secretNum += 1;
    passphrase += "bex";
}
else if (input[2] == '^')
{
    secretNum += -2;
    passphrase += "ro";
}
else
{
    passphrase += "?";
}

Console.WriteLine(secretNum);
Console.WriteLine(passphrase);