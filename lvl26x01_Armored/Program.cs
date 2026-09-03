TestArmorType(ArmorType.Leather);
TestArmorType(ArmorType.Iron);
TestArmorType(ArmorType.DragonScale);

void TestArmorType(ArmorType type)
{
    Console.WriteLine($"--- Testing {type} Armor ---");
    Puppet puppet = new Puppet(new Armor(type));

    for (int i = 1; i <= 7; i++)
    {
        puppet.DealDamage(4);
        Console.WriteLine($"Hit {i}: Puppet HP = {puppet.HP}, Armor Durability = {puppet.Armor?.Durability}");
    }

    Console.WriteLine();
}

public class Puppet
{
    public int HP { get; private set; } = 20;
    public Armor? Armor { get; set; }

    public Puppet(Armor? armor = null)
    {
        Armor = armor ?? new Armor(ArmorType.Iron);
    }

    public void DealDamage(int amount)
    {
        int incomingDamage = amount;

        if (Armor != null)
        {
            incomingDamage = Armor.ReduceDamage(incomingDamage);
        }
        HP = Math.Max(0, HP - incomingDamage);
    }
}

public class Armor
{
    public ArmorType Type { get; }
    public int Durability { get; private set; } = 5;

    public Armor(ArmorType type)
    {
        Type = type;
    }

    public int ReduceDamage(int initialAmount)
    {
        if (initialAmount <= 0 || Durability <= 0)
        {
            return initialAmount;
        }

        Durability--;

        float damageReduction = Type switch
        {
            ArmorType.Leather => 0.75f,
            ArmorType.Iron => 0.5f,
            ArmorType.DragonScale => 0.2f,
            _ => 1.0f
        };

        return (int)(initialAmount * damageReduction);
    }
}

public enum ArmorType { Leather, Iron, DragonScale }