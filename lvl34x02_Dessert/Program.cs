var ingredients = new List<string>() { "butter", "peaches", "honey", "vanilla", "cinnamon", "sugar", "flour", "salt", "milk" };

while (ingredients.Count > 0)
{
    Console.Write("Enter the name of an ingredient: ");
    var name = Console.ReadLine();
    if (ingredients.Remove(name)) Console.WriteLine($"{name} removed from list and added to mixing bowl.");
    else Console.WriteLine($"{name} not found.");
}

Console.WriteLine("You have listed all the ingredients. Peach cobbler is served!");