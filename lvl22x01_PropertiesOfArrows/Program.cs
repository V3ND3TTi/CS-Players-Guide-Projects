string arrowheadMenu = """
                       ------ Arrowhead Menu ------
                       1 - Broadhead
                       2 - Field
                       3 - Blunt
                       ----------------------------
                       Please enter a number (1-3):
                       """;
Console.Write(arrowheadMenu);
int arrowheadChoice = int.Parse(Console.ReadLine()!);
var arrowhead = arrowheadChoice switch
{
    1 => Arrowhead.Broadhead,
    2 => Arrowhead.Field,
    3 => Arrowhead.Blunt
};

string fletchingMenu = """
                       ------ Fletching Menu ------
                       1 - Goose Feathers
                       2 - Turkey Feathers
                       3 - Chicken Feathers
                       ----------------------------
                       Please enter a number (1-3):
                       """;
Console.Write(fletchingMenu);
int fletchingChoice = int.Parse(Console.ReadLine()!);
var fletching = fletchingChoice switch
{
    1 => Fletching.Goose,
    2 => Fletching.Turkey,
    3 => Fletching.Chicken
};

Console.Write("Please enter your desired shaft weight (30-50): ");
float weightChoice = float.Parse(Console.ReadLine()!);

while (weightChoice is < 30 or > 50)
{
    Console.Write($"{weightChoice} is invalid. Please enter valid weight (30-50): ");
    weightChoice = float.Parse(Console.ReadLine()!);
}

var customArrow = new Arrow(arrowhead, fletching, weightChoice);
customArrow.DisplayArrow();

public class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _weight;

    public Arrowhead Arrowhead  => _arrowhead;
    public Fletching Fletching  => _fletching;
    public float Weight {get => _weight; private set => SetWeight(value); }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float weight)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _weight = SetWeight(weight);
    }

    private float GetDamage()
    {
        int arrowheadDamage = _arrowhead switch
        {
            Arrowhead.Broadhead => 8,
            Arrowhead.Field => 5,
            Arrowhead.Blunt => 3,
            _ => 0
        };

        int fletchingOffset = _fletching switch
        {
            Fletching.Goose => 0,
            Fletching.Turkey => -1,
            Fletching.Chicken => -2,
            _ => 0
        };

        return (arrowheadDamage + fletchingOffset) * _weight / 50;
    }

    public void DisplayArrow()
    {
        string arrowDisplay = $"""
                               --------------------------
                               Weight: {Weight}
                               Arrowhead: {Arrowhead}
                               Fletching: {Fletching} Feathers
                               Damage: {GetDamage()}
                               --------------------------
                               """;
        Console.WriteLine(arrowDisplay);
    }

    public float SetWeight(float weight)
    {
        if (weight is >= 30 and <= 50) return weight;

        Console.WriteLine($"{weight} is invalid. Setting to default 35.");
        return 35;
    }

}

public enum Arrowhead { Broadhead, Field, Blunt }
public enum Fletching { Goose, Turkey, Chicken }