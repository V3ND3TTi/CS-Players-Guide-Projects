Board board = new FixedBoardGenerator().Generate();
ConsoleRenderer renderer = new();
PlayerInput input = new();
Game game = new(board, renderer, input);

game.Run();

public class Cell(bool isMine) // Primary Constructor
{
    public bool IsCovered { get; private set; } = true;
    public bool IsMine { get; } = isMine;

    public void Uncover() => IsCovered = false;
}

public class Board
{
    public Cell[,] Cells { get; }
    public int Rows { get; }
    public int Columns { get; }

    public Board(int rows, int columns, Location[] mineLocations)
    {
        Cells = new Cell[rows, columns];
        for (int row = 0; row < rows; row++)
            for (int column = 0; column < columns; column++)
                Cells[row, column] = new Cell(false); // Not mines

        foreach (Location location in mineLocations)
            Cells[location.Row, location.Column] = new Cell(true); // Mines

        Rows = rows;
        Columns = columns;
    }

    public int CountAdjacentMines(int row, int column)
    {
        (int, int)[] neighbors = AdjacentTo(row, column);

        int count = 0;

        foreach ((int r, int c) in neighbors)
            if (IsOnBoard(r, c) && Cells[r, c].IsMine)
                count++;

        return count;
    }

    private (int, int)[] AdjacentTo(int row, int column) =>
    [
        (row - 1, column - 1), (row - 1, column), (row - 1, column + 1),
        (row, column - 1), (row, column + 1),
        (row + 1, column - 1), (row + 1, column), (row + 1, column + 1)
    ];

    private bool IsOnBoard(int row, int column)
    {
        if (row < 0 || row >= Rows) return false;
        if (column < 0 || column >= Columns) return false;
        return true;
    }

    public void Uncover(int row, int column)
    {
        if (!IsOnBoard(row, column)) return;
        Cell cell = Cells[row, column];

        if (!cell.IsCovered) return;
        cell.Uncover();

        if (cell.IsMine) return;
        if (CountAdjacentMines(row, column) > 0) return;

        foreach ((int r, int c) in AdjacentTo(row, column))
            Uncover(r, c);
    }
}

public class Location(int row, int column)
{
    public int Row { get; } = row;
    public int Column { get; } = column;
}

public class FixedBoardGenerator
{
    public Board Generate() => new Board(9, 9,
    [
        new(1, 1), new(1, 5), new(2, 4),
        new(2, 8), new(3, 5), new(5, 2), new(5, 7),
        new(7, 2), new(7, 6), new(8, 4)
    ]);
}

public class ConsoleRenderer
{
    private static readonly string Color0 = "12;12;12";
    private static readonly string Color1 = "0;113;188";
    private static readonly string Color2 = "34;181;115";
    private static readonly string Color3 = "241;90;36";
    private static readonly string Color4 = "237;28;36";
    private static readonly string Color5 = "158;0;93";
    private static readonly string Color6 = "102;45;145";
    private static readonly string Color7 = "237;30;181";
    private static readonly string Color8 = "230;230;230";

    private static readonly string White = "230;230;230";
    private static readonly string Grid = "77;77;77";
    private static readonly string Black = "12;12;12";
    private static readonly string Red = "237;28;36";

    private static string Foreground(string color) => $"\e[38;2;{color}m]";
    private static string Background(string color) => $"\e[48;2;{color}m]";

    public void Render(Game game)
    {
        Board board = game.Board;

        Console.Clear();
        for (int row = 0; row < board.Rows; row++)
        {
            Console.Write($"{Background(Black)}{Foreground(Grid)}" + (row + 1));
            for (int column = 0; column < board.Columns; column++)
            {
                Cell cell = board.Cells[row, column];
                int adjacentMines = board.CountAdjacentMines(row, column); // <!>
                RenderData renderData = DecideData(cell, adjacentMines);
                Display(renderData);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"{Foreground(Grid)}     1   2   3   4   5   6   7   8   9");
        Console.Write($"{Foreground(White)}");

        DisplayStatus(game.Status);
    }

    private void Display(RenderData data)
    {
        string background = Background(data.Background);
        string foreground = Foreground(data.Foreground);
        Console.Write($"{background} {foreground}{data.Text}");
    }

    private void DisplayStatus(GameStatus status)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        if (status == GameStatus.Win) Console.Write("😎");
        if (status == GameStatus.Loss) Console.Write("☠️");
    }

    private RenderData DecideData(Cell cell, int adjacentMineCount)
    {
        if (cell.IsCovered) return new(White, Black, ".");
        if (cell.IsMine) return new(White, Red, "*");

        string color = adjacentMineCount switch
        {
            0 => Color0,
            1 => Color1,
            2 => Color2,
            3 => Color3,
            4 => Color4,
            5 => Color5,
            6 => Color6,
            7 => Color7,
            8 => Color8
        };
        return new(color, Black, adjacentMineCount.ToString());
    }
}

public class RenderData(string foreground, string background, string text)
{
    public string Foreground { get; } = foreground;
    public string Background { get; } = background;
    public string Text { get; } = text;
}

public class PlayerInput
{
    public Location PickLocation(Board board)
    {
        int row = -1;
        while (row == -1) row = GetDigit();
        int column = -1;
        while (column == -1) column = GetDigit();
        return new Location(row, column);
    }

    private int GetDigit() => Console.ReadKey(true).KeyChar switch
    {
        '1' => 0,
        '2' => 1,
        '3' => 2,
        '4' => 3,
        '5' => 4,
        '6' => 5,
        '7' => 6,
        '8' => 7,
        '9' => 8,
        _ => -1
    };
}

public class Game(Board board, ConsoleRenderer renderer, PlayerInput input)
{
    private readonly Board _board = board;
    public Board Board => _board;
    private readonly ConsoleRenderer _renderer = renderer;
    private readonly PlayerInput _input = input;

    public GameStatus Status
    {
        get
        {
            if (HasLost()) return GameStatus.Loss;
            if (IsOngoing()) return GameStatus.Ongoing;
            return GameStatus.Win;
        }
    }

    public void Run()
    {
        while (Status == GameStatus.Ongoing)
        {
            _renderer.Render(this);
            Location toReveal = _input.PickLocation(_board);
            _board.Uncover(toReveal.Row, toReveal.Column);
        }

        _renderer.Render(this); // Render again, after the game ends
    }

    private bool HasLost()
    {
        for (int row = 0; row < _board.Rows; row++)
            for (int column = 0; column < _board.Columns; column++)
                if (IsUncoveredMine(_board.Cells[row, column]))
                    return true;
        return false;
    }

    private bool IsOngoing()
    {
        for (int row = 0; row < _board.Rows; row++)
            for (int column = 0; column < _board.Columns; column++)
                if (IsCoveredOpen(_board.Cells[row, column]))
                    return true;
        return false;
    }

    private bool IsUncoveredMine(Cell cell) => cell.IsMine && !cell.IsCovered;
    private bool IsCoveredOpen(Cell cell) => !cell.IsMine && cell.IsCovered;
}

public enum GameStatus
{
    Ongoing,
    Win,
    Loss
}