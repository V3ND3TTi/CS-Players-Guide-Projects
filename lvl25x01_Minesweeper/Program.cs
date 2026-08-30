Board board = new Board(9, 9);

for (int row = 0; row < board.Rows; row++)
{
    for (int column = 0; column < board.Columns; column++)
        Console.Write(board.Cells[row, column].IsMine ? " *" : " .");
    Console.WriteLine();
}

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

    public Board(int rows, int columns)
    {
        Cells = new Cell[rows, columns];
        for (int row = 0; row < rows; row++)
        for (int column = 0; column < columns; column++)
            Cells[row, column] = new Cell(false); // Not mines

        Rows = rows;
        Columns = columns;
    }
}