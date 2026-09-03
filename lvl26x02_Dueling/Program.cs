Console.Title = "Boss Battle: Glove Dueling Arena";

Player player1 = new Player("Player 1");
Player player2 = new Player("Player 2");

Duel duel = new Duel(player1, player2);
History history = new History();

while (true)
{
    Outcome result = duel.Run();

    switch (result)
    {
        case Outcome.Player1Won:
            Console.WriteLine($"Result: {player1.Name} wins the clash! The platform shudders.\n");
            break;
        case Outcome.Player2Won:
            Console.WriteLine($"Result: {player2.Name} wins the clash! The platform shudders.\n");
            break;
        case Outcome.Draw:
            Console.WriteLine("Result: Energy deflects in a draw! Both stay grounded.\n");
            break;
    }

    history.Record(result);
    history.Display(player1.Name, player2.Name);

    Console.WriteLine("Press any key to duel again (or close window to exit)...");
    Console.ReadKey(intercept: true);
}


// 3. Player class with masked input selection
public class Player
{
    public string Name { get; }

    public Player(string name)
    {
        Name = name;
    }

    public Attack ChooseAttack()
    {
        while (true)
        {
            Console.WriteLine($"{Name}, choose your stance:");
            Console.WriteLine("  1. Quick Attack (Beats Power)");
            Console.WriteLine("  2. Power Attack (Beats Disruption)");
            Console.WriteLine("  3. Disruption   (Beats Quick)");
            Console.Write("Enter choice (1-3): ");

            // ReadKey(true) masks the input so the opposing player cannot see the key pressed
            char key = Console.ReadKey(intercept: true).KeyChar;
            Console.WriteLine("*"); // Visual feedback that a key was pressed

            if (key == '1') return Attack.QuickAttack;
            if (key == '2') return Attack.PowerAttack;
            if (key == '3') return Attack.Disruption;

            Console.WriteLine("Invalid gesture. Please press 1, 2, or 3.\n");
        }
    }
}

// 4. Duel class resolving rounds between two players
public class Duel
{
    private readonly Player _player1;
    private readonly Player _player2;

    public Duel(Player player1, Player player2)
    {
        _player1 = player1;
        _player2 = player2;
    }

    public Outcome Run()
    {
        Console.Clear();
        Console.WriteLine($"--- {_player1.Name}'s Turn ---");
        Attack p1Attack = _player1.ChooseAttack();

        Console.Clear();
        Console.WriteLine($"--- {_player2.Name}'s Turn ---");
        Attack p2Attack = _player2.ChooseAttack();

        Console.Clear();
        Console.WriteLine($"[Clash] {_player1.Name} used {p1Attack} vs {_player2.Name}'s {p2Attack}!\n");

        if (p1Attack == p2Attack)
        {
            return Outcome.Draw;
        }

        // Quick (1) beats Power (2)
        // Power (2) beats Disruption (3)
        // Disruption (3) beats Quick (1)
        bool player1Wins =
            (p1Attack == Attack.QuickAttack && p2Attack == Attack.PowerAttack) ||
            (p1Attack == Attack.PowerAttack && p2Attack == Attack.Disruption) ||
            (p1Attack == Attack.Disruption && p2Attack == Attack.QuickAttack);

        return player1Wins ? Outcome.Player1Won : Outcome.Player2Won;
    }
}

// 5. History tracker for running tallies
public class History
{
    public int Player1Wins { get; private set; }
    public int Player2Wins { get; private set; }
    public int Draws { get; private set; }

    public void Record(Outcome outcome)
    {
        switch (outcome)
        {
            case Outcome.Player1Won:
                Player1Wins++;
                break;
            case Outcome.Player2Won:
                Player2Wins++;
                break;
            case Outcome.Draw:
                Draws++;
                break;
        }
    }

    public void Display(string p1Name, string p2Name)
    {
        Console.WriteLine("=== ARENA RECORD ===");
        Console.WriteLine($"{p1Name} Wins : {Player1Wins}");
        Console.WriteLine($"{p2Name} Wins : {Player2Wins}");
        Console.WriteLine($"Draws        : {Draws}");
        Console.WriteLine("====================\n");
    }
}

// 1. Represent the three attack gestures
public enum Attack
{
    QuickAttack = 1,
    PowerAttack = 2,
    Disruption = 3
}

// 2. Represent the possible outcomes of a duel
public enum Outcome
{
    Player1Won,
    Player2Won,
    Draw
}