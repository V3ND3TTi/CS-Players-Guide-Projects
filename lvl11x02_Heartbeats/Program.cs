for (var i = 1; i <= 100; i++)
{
   var heartbeat = (i % 3, i % 5) switch
   {
      (0, 0) => "OO",
      (0, _) => "o.",
      (_, 0) => ".o",
      _ => ".."
   };
   Console.WriteLine(heartbeat);
}


/* using if statements
for (var i = 1; i <= 100; i++)
{
   if (i % 3 == 0 && i % 5 == 0)
      Console.WriteLine("OO");
   else if (i % 3 == 0)
      Console.WriteLine("o.");
   else if (i % 5 == 0)
      Console.WriteLine(".o");
   else
      Console.WriteLine("..");
}
*/