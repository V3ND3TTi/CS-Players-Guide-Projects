Console.Write("Enter a number (1-100): ");
int number = int.Parse(Console.ReadLine()!);
int guess;

Console.Clear();
Console.Write("Guess the number between 1 and 100: ");

while (true)
{
    do
    {
        guess = int.Parse(Console.ReadLine()!);
        if (guess < 0 || guess > 100) Console.Write("Invalid input. Pick another number: ");

    } while (guess < 0 || guess > 100);

    if (guess == number) break;
    if (guess > number) Console.Write("Too high! Pick a lower number: ");
    if (guess < number) Console.Write("Too low! Pick a higher number: ");
}

Console.WriteLine("Congrats! You picked the correct number!");