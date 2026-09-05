namespace Dueling;

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