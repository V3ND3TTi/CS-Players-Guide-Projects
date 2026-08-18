Console.WriteLine("Please enter a symbol to sort the stones to the appropriate channel:");
Console.WriteLine("^ - Channel 1");
Console.WriteLine("x - Channel 2");
Console.WriteLine("o - Channel 3");
Console.WriteLine("# - Channel 4");
Console.Write("Please enter your choice (^,x,0,#): ");
char choice = char.Parse(Console.ReadLine()!);

string response = choice switch
{
    '^' => "Routing to Channel 1",
    'x' => "Routing to Channel 2",
    'o' => "Routing to Channel 3",
    '#' => "Routing to Channel 4",
    _ => "Invalid choice."
};
Console.WriteLine($"{response}");