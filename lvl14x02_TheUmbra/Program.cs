int currentRound = 1;
int structsDestroyed = 0;
int umbraDamage = 0;
int umbraDistance = 50;

GameLoop();

void GameLoop()
{
    while (structsDestroyed < 20 && umbraDamage < 20)
    {
        StatusDisplay();

        Console.Write("Enter the target range (1-100): ");
        int range = int.Parse(Console.ReadLine()!);

        while (range < 1 || range > 100)
        {
            Console.Write("Invalid input. Enter the target range (1-100): ");
            range = int.Parse(Console.ReadLine()!);
        }

        if (range == umbraDistance)
        {
            Console.WriteLine("That was a direct hit!");
            umbraDamage += CalcDamage();
            currentRound++;
            structsDestroyed++;
            Thread.Sleep(1000);
            Console.Clear();
        }
        else if (range > umbraDistance)
        {
            Console.WriteLine("That went too far!");
            currentRound++;
            structsDestroyed++;
            Thread.Sleep(1000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("That fell short!");
            currentRound++;
            structsDestroyed++;
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    Console.WriteLine(umbraDamage >= 20
        ? "You have destroyed the Umbra! The city rejoices!"
        : "The Umbra has destroyed the city. You lose.");
}

void StatusDisplay()
{
    string display = $"""
                      -------------------- STATUS --------------------
                      Round: {currentRound}
                      Structures Destroyed: {structsDestroyed}
                      Umbra Damage: {umbraDamage}
                      A hit will deal {CalcDamage()} damage right now.
                      ------------------------------------------------
                      """;
    Console.WriteLine(display);
}

int CalcDamage()
{
    int damage = (currentRound % 3, currentRound % 5) switch
    {
        (0, 0) => 5,
        (0, _) => 3,
        (_, 0) => 3,
        _ => 1
    };
    return damage;
}

