public class Food
{
    public string? Name { get; set; }
    public int Points { get; set; }

    public Food(string? name, int points)
    {
        Name = name;
        Points = points;
    }
    public virtual void Eat(Health health) => health.Hunger -= Points;

    public override string ToString() => $"{Name} ({Points})";
}

public class Cookie : Food
{
    public Cookie(string? name = "Cookie", int points = 2) : base(name, points) { }

    public override void Eat(Health health)
    {
        health.Hunger -= Points;
        health.Status = Status.OnFire;
    }
}

public class Turkey : Food
{
    public Turkey(string? name = "Turkey", int points = 5) : base(name, points) { }

    public override void Eat(Health health)
    {
        health.Hunger -= Points;
        health.Status = Status.Sleepy;
    }
}

public class RawTurkey : Food
{
    public RawTurkey(string? name = "Raw Turkey", int points = 1) : base(name, points) { }

    public override void Eat(Health health)
    {
        health.Hunger -= Points;
        health.Status = Random.Shared.NextDouble() < 0.5 ? Status.Poisoned : health.Status;
    }
}

public class Milk : Food
{
    public Milk(string? name = "Milk", int points = 3) : base(name, points) { }

    public override void Eat(Health health)
    {
        health.Hunger -= Points;
        health.Status = Status.None;
    }
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