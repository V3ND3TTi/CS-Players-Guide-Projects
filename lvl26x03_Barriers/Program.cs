var game = new Game();
game.Run();


public class Cell(int index)
{
    public int Index { get; } = index;
    public Mark Mark { get; set; } = Mark.Empty;

    public bool IsEmpty => Mark is Mark.Empty;

    // Switch expression mapping mark to visual character
    public char Symbol => Mark switch
    {
        Mark.X => 'X',
        Mark.O => 'O',
        _ => (char)('0' + Index)
    };
}

public class Player(string name, Mark mark)
{
    public string Name { get; } = name;
    public Mark Mark { get; } = mark;
}

public class Board
{
    // Keypad layout: 7 8 9 (row 0), 4 5 6 (row 1), 1 2 3 (row 2)
    // Internal index 0..8 maps directly to keypad numbers 1..9 via (keypad - 1)
    private readonly Cell[] _cells = [.. Enumerable.Range(1, 9).Select(i => new Cell(i))];

    private static readonly int[][] WinningLines =
    [
        [7, 8, 9], [4, 5, 6], [1, 2, 3], // Rows
        [7, 4, 1], [8, 5, 2], [9, 6, 3], // Columns
        [7, 5, 3], [1, 5, 9]             // Diagonals
    ];

    public Cell GetCell(int keypadNumber) => _cells[keypadNumber - 1];

    public bool TryPlaceMark(int keypadNumber, Mark mark)
    {
        if (keypadNumber is < 1 or > 9) return false;

        var cell = GetCell(keypadNumber);
        if (!cell.IsEmpty) return false;

        cell.Mark = mark;
        return true;
    }

    public GameState CheckGameState()
    {
        foreach (var line in WinningLines)
        {
            var m1 = GetCell(line[0]).Mark;
            var m2 = GetCell(line[1]).Mark;
            var m3 = GetCell(line[2]).Mark;

            var winner = (m1, m2, m3) switch
            {
                (Mark.X, Mark.X, Mark.X) => GameState.XWon,
                (Mark.O, Mark.O, Mark.O) => GameState.OWon,
                _ => GameState.InProgress
            };

            if (winner is not GameState.InProgress)
                return winner;
        }

        return _cells.All(c => !c.IsEmpty) ? GameState.Draw : GameState.InProgress;
    }
}

public class BoardRenderer
{
    public void Render(Board board)
    {
        Console.Clear();
        Console.WriteLine("=== TIC-TAC-TOE ===");
        Console.WriteLine("Use Numpad keys (1-9) to choose your square:\n");

        // Top row: 7 | 8 | 9
        Console.WriteLine($" {board.GetCell(7).Symbol} | {board.GetCell(8).Symbol} | {board.GetCell(9).Symbol} ");
        Console.WriteLine("---+---+---");
        // Middle row: 4 | 5 | 6
        Console.WriteLine($" {board.GetCell(4).Symbol} | {board.GetCell(5).Symbol} | {board.GetCell(6).Symbol} ");
        Console.WriteLine("---+---+---");
        // Bottom row: 1 | 2 | 3
        Console.WriteLine($" {board.GetCell(1).Symbol} | {board.GetCell(2).Symbol} | {board.GetCell(3).Symbol} ");
        Console.WriteLine();
    }
}

public class Game
{
    private readonly Board _board = new();
    private readonly BoardRenderer _renderer = new();
    private readonly Player[] _players = [new("Player 1", Mark.X), new("Player 2", Mark.O)];
    private int _turnIndex;

    public void Run()
    {
        var state = GameState.InProgress;

        while (state is GameState.InProgress)
        {
            var currentPlayer = _players[_turnIndex % 2];
            _renderer.Render(_board);

            var chosenSquare = GetValidMove(currentPlayer);
            _board.TryPlaceMark(chosenSquare, currentPlayer.Mark);

            state = _board.CheckGameState();
            _turnIndex++;
        }

        _renderer.Render(_board);

        // Switch expression for end-game message
        var outcome = state switch
        {
            GameState.XWon => $"{_players[0].Name} (X) wins!",
            GameState.OWon => $"{_players[1].Name} (O) wins!",
            GameState.Draw => "It's a draw!",
            _ => string.Empty
        };

        Console.WriteLine(outcome);
    }

    private int GetValidMove(Player player)
    {
        while (true)
        {
            Console.Write($"{player.Name} ({player.Mark}), enter square (1-9): ");
            var keyInfo = Console.ReadKey(intercept: true);
            Console.WriteLine(keyInfo.KeyChar);

            // Switch expression mapping keypad and number row inputs to cell numbers
            var move = keyInfo.Key switch
            {
                ConsoleKey.NumPad1 or ConsoleKey.D1 => 1,
                ConsoleKey.NumPad2 or ConsoleKey.D2 => 2,
                ConsoleKey.NumPad3 or ConsoleKey.D3 => 3,
                ConsoleKey.NumPad4 or ConsoleKey.D4 => 4,
                ConsoleKey.NumPad5 or ConsoleKey.D5 => 5,
                ConsoleKey.NumPad6 or ConsoleKey.D6 => 6,
                ConsoleKey.NumPad7 or ConsoleKey.D7 => 7,
                ConsoleKey.NumPad8 or ConsoleKey.D8 => 8,
                ConsoleKey.NumPad9 or ConsoleKey.D9 => 9,
                _ => -1
            };

            if (move is not -1 && _board.GetCell(move).IsEmpty)
                return move;

            Console.WriteLine("Invalid move. Cell is taken or out of range. Try again.");
        }
    }
}

public enum Mark { Empty, X, O }
public enum GameState { InProgress, XWon, OWon, Draw }