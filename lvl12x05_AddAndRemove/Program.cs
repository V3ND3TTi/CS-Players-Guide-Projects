string[] names = ["Lexa", "Ada","Skorin"];

for (int i = 0; i < names.Length; i++)
{
    string firstName = names[0];
    string[] lastTwoNames = names[1..];
    names = [..lastTwoNames, firstName];
    Console.WriteLine($"{names[0]} {names[1]} {names[2]}");
}