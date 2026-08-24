FirstMethod();

void FirstMethod()
{
    SecondMethod();
}

void SecondMethod()
{
    ThirdMethod();
}

void ThirdMethod()
{
    FourthMethod();
}

void FourthMethod()
{
    Console.WriteLine(Environment.StackTrace);
}