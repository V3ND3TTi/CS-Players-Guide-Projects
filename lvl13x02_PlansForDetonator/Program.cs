char[] detonator = "__.__.XX.___.X".ToCharArray();
DisplayDetonator(detonator);

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
}