Arrow[] arrows = new Arrow[30];

for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 10; j++)
    {
        if (i == 0) arrows[j] = Arrow.CreatePracticeArrow();
        if (i == 1) arrows[j + 10] = Arrow.CreateMarksmanArrow();
        if (i == 2) arrows[j + 20] = Arrow.CreateEliteArrow();
    }
}

arrows[0].DisplayArrow();
arrows[10].DisplayArrow();
arrows[20].DisplayArrow();

public class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _weight;

    public Arrowhead Arrowhead  => _arrowhead;
    public Fletching Fletching  => _fletching;

    public float Weight
    {
        get => _weight;
        init
        {
            if (value is >= 30 and <= 50)
            {
                _weight = value;
            }
            else
            {
                Console.WriteLine($"{value} is invalid. Setting to default 35.");
                _weight = 35;
            }
        }
    }

    public Arrow(Arrowhead arrowhead, Fletching fletching, float weight)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        Weight = weight;
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

    public static Arrow CreatePracticeArrow() => new Arrow(Arrowhead.Blunt, Fletching.Turkey, 30f);
    public static Arrow CreateMarksmanArrow() => new Arrow(Arrowhead.Field, Fletching.Goose, 35f);
    public static Arrow CreateEliteArrow() => new Arrow(Arrowhead.Broadhead, Fletching.Goose, 45f);
}

public enum Arrowhead { Broadhead, Field, Blunt }
public enum Fletching { Goose, Turkey, Chicken }