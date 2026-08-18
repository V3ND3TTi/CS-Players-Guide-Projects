Console.WriteLine("Please enter a symbol to sort the stones to the appropriate channel:");
Console.WriteLine("^ - Channel 1");
Console.WriteLine("x - Channel 2");
Console.WriteLine("o - Channel 3");
Console.WriteLine("# - Channel 4");
Console.Write("Please enter your choice (^,x,0,#): ");
char choice = char.Parse(Console.ReadLine()!);

switch (choice)
{
    case '^':
        Console.WriteLine("Routing to Channel 1");
        break;
    case 'x':
        Console.WriteLine("Routing to Channel 2");
        break;
    case 'o':
        Console.WriteLine("Routing to Channel 3");
        break;
    case '#':
        Console.WriteLine("Routing to Channel 4");
        break;
    default:
        Console.WriteLine("Invalid choice");
        break;
}