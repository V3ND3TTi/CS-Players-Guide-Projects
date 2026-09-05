using Dueling;

Console.Title = "Boss Battle: Glove Dueling Arena";

Player player1 = new Player("Player 1");
Player player2 = new Player("Player 2");

Duel duel = new Duel(player1, player2);
History history = new History();

while (true)
{
    Outcome result = duel.Run();

    switch (result)
    {
        case Outcome.Player1Won:
            Console.WriteLine($"Result: {player1.Name} wins the clash! The platform shudders.\n");
            break;
        case Outcome.Player2Won:
            Console.WriteLine($"Result: {player2.Name} wins the clash! The platform shudders.\n");
            break;
        case Outcome.Draw:
            Console.WriteLine("Result: Energy deflects in a draw! Both stay grounded.\n");
            break;
    }

    history.Record(result);
    history.Display(player1.Name, player2.Name);

    Console.WriteLine("Press any key to duel again (or close window to exit)...");
    Console.ReadKey(intercept: true);
}