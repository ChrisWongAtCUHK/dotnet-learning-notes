await Demo.RunAsync();

class NumberAdder
{
    public int A;
    public int B;
    public override string ToString() => $"{A} + {B} = {A + B}";
}

static class Demo
{
    private static readonly Random rand = new();
    static NumberAdder adder = new();

    public static async Task RunAsync()
    {
        await Task.WhenAll(
            TestNumAdder("Alice", 1, 2),
            TestNumAdder("Bob", 3, 4),
            TestNumAdder("Charlie", 5, 6),
            TestNumAdder("Diana", 7, 8),
            TestNumAdder("Eve", 3, 8)
        );
    }

    static async Task TestNumAdder(string user, int a, int b)
    {
        await Task.Delay(rand.Next(5, 700));
        adder.A = a;
        await Task.Delay(rand.Next(5, 700));
        adder.B = b;
        Console.WriteLine($" - {user,-10} Test {a} + {b} / Result: {adder, -12} T:{Thread.CurrentThread.ManagedThreadId}");
    }
}