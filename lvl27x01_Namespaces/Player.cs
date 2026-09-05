namespace Dueling;

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