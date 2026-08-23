while (true)
{
    int num = GetANumber("Enter a number 1-100 (0 to exit): ");
    if (num == 0)
    {
        break;
    }
    Console.WriteLine(num);
}

int GetANumber(string prompt)
{
    Console.Write(prompt);
    return int.Parse(Console.ReadLine()!);
}