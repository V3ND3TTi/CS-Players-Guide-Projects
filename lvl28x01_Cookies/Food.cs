public class Food
{
    public string? Name { get; set; }
    public int Points { get; set; }

    public Food(string? name, int points)
    {
        Name = name;
        Points = points;
    }

    public void Eat(Health health) => health.Hunger -= Points;
}

public class Cookie : Food
{
    public Cookie(string? name = "Cookie", int points = 2) : base(name, points) { }
}

public class Turkey : Food
{
    public Turkey(string? name = "Turkey", int points = 5) : base(name, points) { }
}

public class RawTurkey : Food
{
    public RawTurkey(string? name = "Raw Turkey", int points = 1) : base(name, points) { }
}

public class Milk : Food
{
    public Milk(string? name = "Milk", int points = 3) : base(name, points) { }
}


public class Health
{
    public int Hunger
    {
        get;
        set { field = Math.Clamp(value, 0, 10); }
    }
    public Status Status { get; set; } = Status.None;
}

public enum Status { None, Sleepy, OnFire, Poisoned }