Console.Write("Please enter the total eggs gathered: ");
int totalEggs = int.Parse(Console.ReadLine()!);

int eggsPerSister = totalEggs / 4;
int eggsForDuckbear = totalEggs % 4;

Console.WriteLine($"Today's Haul - Sisters: {eggsPerSister} eggs, Duckbear: {eggsForDuckbear} eggs.");
