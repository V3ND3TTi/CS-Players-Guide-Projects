var coords1 = new Coordinate(1, 1);
var coords2 = new Coordinate(1, 2);
var coords3 = new Coordinate(2, 2);

Console.WriteLine(coords1.AdjacentTo(coords2));
Console.WriteLine(coords1.AdjacentTo(coords3));
Console.WriteLine(coords2.AdjacentTo(coords3));

public struct Coordinate
{
    public int Row { get; init; }
    public int Col { get; init; }

    public Coordinate(int row, int col)
    {
        Row = row;
        Col = col;
    }

    public bool AdjacentTo(Coordinate coord)
    {
        bool isAdjacent = (Row - coord.Row, Col - coord.Col) switch
        {
            (-1,0) => true, // North
            (1,0) => true, // South
            (0,1) => true, // East
            (0,-1) => true, //West
            (_, _) => false
        };
        return isAdjacent;
    }
}