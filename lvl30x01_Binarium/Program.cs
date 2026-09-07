Health health = new();

while (true)
{
    Console.WriteLine($"Hunger: {health.Hunger}, Status: {health.Status}, Binarium Created: {health.Binarium:F2}.");
    Console.WriteLine($"1=Cookie 2=Turkey 3=RawTurkey 4=Milk 5=CodeDust");
    char input = Console.ReadKey(true).KeyChar;

    IConsumable? food = null;
    food = input switch
    {
        '1' => new Cookie(),
        '2' => new Turkey(),
        '3' => new RawTurkey(),
        '4' => new Milk(),
        '5' => new CodeDust(),
        _ => null
    };

    if (food == null)
    {
        health.Hunger++;
        Console.WriteLine("Ate nothing. Hunger has increased by 1.");
    }
    else
    {
        Console.WriteLine($"Eating {food}.");
        food?.Eat(health);
    }
}