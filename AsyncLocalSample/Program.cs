await Demo.RunAsync();

class NumberAdder
{
    public AsyncLocal<int> A = new();
    public AsyncLocal<int> B = new();

    public override string ToString() => $"{A.Value} + {B.Value} = {A.Value + B.Value}";
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
            TestNumAdder("Eve", 6, 9)
        );
    }

    static async Task TestNumAdder(string user, int a, int b)
    {
        await Task.Delay(rand.Next(5, 500));
        adder.A.Value = a;
        await Task.Delay(rand.Next(5, 500));
        adder.B.Value = b;
        Console.WriteLine(
            $" - {user, -10} Test {a} + {b} / Result: {adder, -12} T:{Thread.CurrentThread.ManagedThreadId}"
        );
    }
}
