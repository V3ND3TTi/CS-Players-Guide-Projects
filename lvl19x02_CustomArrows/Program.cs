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

var customArrow = new Arrow(arrowhead, fletching, weightChoice);
customArrow.DisplayArrow();

class Arrow
{
    public Arrowhead Arrowhead;
    public Fletching Fletching;
    public float Weight;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float weight)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Weight = weight;
    }

    public float GetDamage()
    {
        int arrowheadDamage = Arrowhead switch
        {
            Arrowhead.Broadhead => 8,
            Arrowhead.Field => 5,
            Arrowhead.Blunt => 3,
            _ => 0
        };

        int fletchingOffset = Fletching switch
        {
            Fletching.Goose => 0,
            Fletching.Turkey => -1,
            Fletching.Chicken => -2,
            _ => 0
        };

        return (arrowheadDamage + fletchingOffset) * Weight / 50;
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
}

enum Arrowhead { Broadhead, Field, Blunt }
enum Fletching { Goose, Turkey, Chicken }