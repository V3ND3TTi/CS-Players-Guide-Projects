var chest = Chest.Locked;
string choice = " ";

while (choice != "quit")
{
    if (chest == Chest.Locked)
    {
        Console.Write($"The chest is {chest.ToString().ToLower()}. You can unlock it only. Enter your command (quit to exit): ");
        choice = Console.ReadLine()!;
        if (choice == "unlock") chest = Chest.Closed;
    }
    else if (chest == Chest.Closed)
    {
        Console.Write($"The chest is {chest.ToString().ToLower()}. You can lock or open the chest. Enter your command (quit to exit): ");
        choice = Console.ReadLine()!;
        if (choice == "lock") chest = Chest.Locked;
        if (choice == "open") chest = Chest.Open;
    }
    else if (chest == Chest.Open)
    {
        Console.Write($"The chest is {chest.ToString().ToLower()}. You can close it only. Enter your command (quit to exit): ");
        choice = Console.ReadLine()!;
        if (choice == "close") chest = Chest.Closed;
    }
}

enum Chest { Open, Closed, Locked }
