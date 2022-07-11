using System.Runtime.CompilerServices;

namespace Demo;

public class CSharp10
{
    const string Color = "Orange";
    const string Text = $"{Color} is a color.";

    public static int DoSomething(Func<int, int> func, int input,
        [CallerArgumentExpression("func")] string? funcExpression = null)
    {
        try
        {
            return func(input);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\"{funcExpression}\" threw {ex.GetType().Name}");
            throw;
        }
    }
}
