int currentRound = 1;
int structsDestroyed = 0;
int umbraDamage = 0;
int umbraDistance = Random.Shared.Next(25, 76);
int umbraSpeed = Random.Shared.Next(1, 3);

GameLoop();

void GameLoop()
{
    while (structsDestroyed < 20 && umbraDamage < 20 && umbraDistance > 0)
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
            umbraDistance -= umbraSpeed;
            currentRound++;
            structsDestroyed++;
            Thread.Sleep(1000);
            Console.Clear();
        }
        else if (range > umbraDistance)
        {
            Console.WriteLine("That went too far!");
            umbraDistance -= umbraSpeed;
            currentRound++;
            structsDestroyed++;
            Thread.Sleep(1000);
            Console.Clear();
        }
        else
        {
            Console.WriteLine("That fell short!");
            umbraDistance -= umbraSpeed;
            currentRound++;
            structsDestroyed++;
            Thread.Sleep(1000);
            Console.Clear();
        }
    }

    if (umbraDamage >= 20)
    {
        Console.WriteLine("You have destroyed the Umbra! The city rejoices!");
    }
    else if (umbraDistance <= 0)
    {
        Console.WriteLine("The Umbra has breached the city gates and crushed the Guildhall! You lose.");
    }
    else
    {
        Console.WriteLine("The Umbra has systematically destroyed the city. You lose.");
    }
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