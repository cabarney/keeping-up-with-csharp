namespace Demo;

public class CSharp8: ICSharp {
    private readonly ILogger _logger;
    private string? _message;

    public CSharp8(ILogger logger) => _logger = logger;

    public string Message => _message ??= ReadMessage();

    public void DoSomething(string[] items)
    {
        foreach (var item in items[..^1])
        {
            Console.WriteLine(item);
        }
        Console.WriteLine($"The last item is {items[^1]}");
    }

    private string ReadMessage()
    {
        using var file = new StreamReader("message.txt");
        return file.ReadToEnd();
    }
}

interface ICSharp {
    void DoSomething(string[] items);
    void DoSomethingElse() => Console.WriteLine("Hello, World!");
}