namespace Dueling;

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