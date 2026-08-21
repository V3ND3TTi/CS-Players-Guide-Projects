int[,] map = new [,]
{
    { 0, 1, 0, 1, 1, 3 }, { 2, 1, 4, 2, 3, 1 }, { 1, 2, 2, 3, 1, 0 }, { 2, 2, 3, 5, 0, 1 }, { 3, 3, 2, 1, 1, 1 },
    { 1, 2, 3, 1, 0, 0 }
};

for (var i = 0; i < 6; i++)
{
    for (var j = 0; j < 6; j++)
    {
        // 1. Set the color based on terrain value before writing
        Console.ForegroundColor = map[i, j] switch
        {
            0 => ConsoleColor.Black,
            1 => ConsoleColor.DarkGray,
            2 => ConsoleColor.Gray,
            3 => ConsoleColor.Cyan,
            4 => ConsoleColor.Red,
            5 => ConsoleColor.Blue,
            _ => ConsoleColor.White
        };

        // 2. Fetch the terrain symbol
        string printout = map[i, j] switch
        {
            0 => "  ",
            1 => "..",
            2 => "##",
            3 => "~~",
            4 => "[]",
            5 => "()",
            _ => "??"
        };
        Console.Write($"{printout}");
    }
    Console.WriteLine();
}
Console.ResetColor();



