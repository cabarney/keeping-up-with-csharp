namespace Demo;
#nullable disable

public class Program7
{
    static async Task Main7(string[] args)
    {
        string textInput = args?.FirstOrDefault() ?? throw new ArgumentException("No input provided");
        (string input, int number) = await ParseNumberAsync(textInput);

        Console.WriteLine($"I parsed \"{input}\" as {number}");

        async Task<(string, int)> ParseNumberAsync(string input)
        {
            await Task.Delay(1000);

            if (int.TryParse(input, out var number))
            {
                return (input, number);
            }
            return (input, 0);
        }
    }
}

public class CSharp7
{
    public int Number { get; set; }
    public string Text { get; set; }

    public CSharp7() => Console.WriteLine("Hello, World!");

    public void Deconstruct(out int Number, out int Text)
    {
        Number = this.Number;
        Text = this.Text.Length;
    }
}

#nullable restore