var practiceSword = new Sword(Material.Iron, Gemstone.None, 100, 25);
var battleSword = practiceSword with { Mat = Material.Steel, Gem = Gemstone.Sapphire };
var binariumSword = practiceSword with { Mat = Material.Binarium, Gem = Gemstone.Bitstone };

Console.WriteLine(practiceSword);
Console.WriteLine(battleSword);
Console.WriteLine(binariumSword);

public record Sword(Material Mat, Gemstone Gem, int Length, int CrossguardWidth);

public enum Material { Wood, Bronze, Iron, Steel, Binarium }
public enum Gemstone { None, Emerald, Amber, Sapphire, Diamond, Bitstone }