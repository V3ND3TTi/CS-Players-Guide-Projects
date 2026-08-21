int[] array = new int[100];

for (var i = 0; i < array.Length; i++)
{
    array[i] = i + 1;
}

for (var i = 0; i < array.Length; i++)
{
    Console.WriteLine(array[i]);
}