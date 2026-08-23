char[] detonator = "_._.__.___._____.________".ToCharArray();

while (true)
{
    DisplayDetonator(detonator);
    int index = GetANumber("Enter the number of the detonator slot you would like to fill: ");
    Fill(detonator, index);
}

void DisplaySingleChar(char c)
{
    Console.ForegroundColor = c switch
    {
        'X' => ConsoleColor.Cyan,
        '_' => ConsoleColor.DarkGray,
        '.' => ConsoleColor.Yellow,
        _ => ConsoleColor.White
    };
    Console.Write(c);
    Console.ResetColor();
}

void DisplayDetonator(char[] chars)
{
    DisplaySingleChar('[');
    foreach (var c in chars)
    {
        DisplaySingleChar(c);
    }
    DisplaySingleChar(']');
    Console.WriteLine();
}

int GetANumber(string prompt)
{
    Console.Write(prompt);
    return int.Parse(Console.ReadLine()!);
}

void Fill(char[] det, int location)
{
    if (location < 0 || location >= det.Length)
    {
        Console.WriteLine("Invalid location.");
        return;
    }

    if (det[location] == 'X' || det[location] == '.')
    {
        Console.WriteLine("Invalid placement.");
        return;
    }

    if (det[location] == '_')
    {
        det[location] = 'X';
        Fill(det, location + 1);
        Fill(det, location - 1);
    }
}