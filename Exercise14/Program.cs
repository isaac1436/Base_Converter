class Exercise14
{
    static void Main()
    {
        float @float = 0.000001f;
        float @floatRes = 0.0f;

        double @double = 0.000001d;
        double @doubleRes = 0.0d;

        decimal @decimal = 0.000001m;
        decimal @decimalRes = 0.0m;

        for (int i = 0; i < 50000000; i++)
        {
            @floatRes += @float;
            @doubleRes += @double;
            @decimalRes += @decimal;
        }
        Console.WriteLine(@floatRes);
        Console.WriteLine(@doubleRes);
        Console.WriteLine(@decimalRes);
    }
}