// Program.cs
var game = new Game();
game.Run();

// --------------------------------------------------
// Core Types & Records
// --------------------------------------------------
public readonly record struct Location(int Row, int Col)
{
    public override string ToString() => $"Row={Row}, Column={Col}";
}

// --------------------------------------------------
// Rooms
// --------------------------------------------------
public class Room { }

public class EntranceRoom : Room { }

public class FountainRoom : Room
{
    public bool IsActive { get; set; }
}

// --------------------------------------------------
// Senses
// --------------------------------------------------
public interface ISense
{
    string? Sense(Game game);
}

public class LightSense : ISense
{
    public string? Sense(Game game) =>
        game.CurrentRoom is EntranceRoom
            ? "You see light coming from the cavern entrance."
            : null;
}

public class FountainSense : ISense
{
    public string? Sense(Game game)
    {
        if (game.CurrentRoom is FountainRoom fountain)
        {
            return fountain.IsActive
                ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!"
                : "You hear water dripping in this room. The Fountain of Objects is here!";
        }
        return null;
    }
}

// --------------------------------------------------
// Cavern (Map & Spatial Rules)
// --------------------------------------------------
public class Cavern
{
    public int Rows { get; }
    public int Cols { get; }
    private readonly Room[,] _grid;

    public Cavern(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        _grid = new Room[rows, cols];

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                _grid[r, c] = new Room();
            }
        }

        // Hardcoded positions for this base challenge
        _grid[0, 0] = new EntranceRoom();
        _grid[0, 2] = new FountainRoom();
    }

    public bool IsOnMap(Location loc) =>
        loc.Row >= 0 && loc.Row < Rows && loc.Col >= 0 && loc.Col < Cols;

    public Room GetRoomAt(Location loc) => _grid[loc.Row, loc.Col];
}

// --------------------------------------------------
// Game Controller & Loop
// --------------------------------------------------
public class Game
{
    public Cavern Cavern { get; }
    public Location PlayerLocation { get; private set; }
    public Room CurrentRoom => Cavern.GetRoomAt(PlayerLocation);

    private readonly List<ISense> _senses = [new LightSense(), new FountainSense()];
    private bool _hasEscaped;

    public Game()
    {
        Cavern = new Cavern(4, 4);
        PlayerLocation = new Location(0, 0);
    }

    public void Run()
    {
        while (!_hasEscaped)
        {
            Console.WriteLine(new string('-', 82));
            Console.WriteLine($"You are in the room at ({PlayerLocation}).");

            // 1. Evaluate and display senses
            foreach (var sense in _senses)
            {
                string? message = sense.Sense(this);
                if (!string.IsNullOrEmpty(message))
                {
                    Console.WriteLine(message);
                }
            }

            // 2. Win check (entrance + active fountain)
            if (CurrentRoom is EntranceRoom && Cavern.GetRoomAt(new Location(0, 2)) is FountainRoom { IsActive: true })
            {
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
                Console.WriteLine("You win!");
                _hasEscaped = true;
                break;
            }

            // 3. Command resolution
            Console.Write("What do you want to do? ");
            string? command = Console.ReadLine()?.Trim().ToLowerInvariant();

            HandleCommand(command);
        }
    }

    private void HandleCommand(string? command)
    {
        Location target = command switch
        {
            "move north" => PlayerLocation with { Row = PlayerLocation.Row - 1 },
            "move south" => PlayerLocation with { Row = PlayerLocation.Row + 1 },
            "move west"  => PlayerLocation with { Col = PlayerLocation.Col - 1 },
            "move east"  => PlayerLocation with { Col = PlayerLocation.Col + 1 },
            _ => PlayerLocation
        };

        if (command is "move north" or "move south" or "move west" or "move east")
        {
            if (Cavern.IsOnMap(target))
            {
                PlayerLocation = target;
            }
            else
            {
                Console.WriteLine("You run into a solid cavern wall. You cannot move that way.");
            }
            return;
        }

        if (command == "restore fountain")
        {
            if (CurrentRoom is FountainRoom fountain)
            {
                fountain.IsActive = true;
            }
            else
            {
                Console.WriteLine("There is no fountain here to restore.");
            }
            return;
        }

        Console.WriteLine("Unknown command. Try 'move north', 'move south', 'move east', 'move west', or 'restore fountain'.");
    }
}