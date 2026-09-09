var virString = new Vircon<string>("Inception");
Console.WriteLine(virString.Current);
virString.Commit();
Console.WriteLine(virString.Stored);
virString.Current = "Tenet";
Console.WriteLine(virString.Current);
Console.WriteLine(virString.Stored);

var virDouble = new Vircon<double>(3.14);
Console.WriteLine(virDouble.Current);
virDouble.Commit();
Console.WriteLine(virDouble.Stored);
virDouble.Current = 6.28;
Console.WriteLine(virDouble.Current);

public class Vircon<T>(T initial)
{
    public T Current { get; set; } = initial;
    public T Stored { get; private set; }

    public void Commit() => Stored = Current;
    public void Revert() => Current = Stored;
}