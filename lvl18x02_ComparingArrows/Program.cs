var practiceArrow = new Arrow
{
    Arrowhead = Arrowhead.Blunt,
    Fletching = Fletching.Chicken,
    Weight = 30
};

var marksmanArrow = new Arrow
{
    Arrowhead = Arrowhead.Field,
    Fletching = Fletching.Turkey,
    Weight = 35
};

var eliteArrow = new Arrow
{
    Arrowhead = Arrowhead.Broadhead,
    Fletching = Fletching.Goose,
    Weight = 45
};

practiceArrow.DisplayArrow();
marksmanArrow.DisplayArrow();
eliteArrow.DisplayArrow();

class Arrow
{
    public Arrowhead Arrowhead;
    public Fletching Fletching;
    public float Weight;

    public float GetDamage()
    {
        int arrowheadDamage = Arrowhead switch
        {
            Arrowhead.Broadhead => 8,
            Arrowhead.Field => 5,
            Arrowhead.Blunt => 3
        };

        int fletchingOffset = Fletching switch
        {
            Fletching.Goose => 0,
            Fletching.Turkey => -1,
            Fletching.Chicken => -2
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