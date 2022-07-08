namespace Demo;
#nullable disable

public class CSharp6
{
    private readonly ILogger _logger;
    public double Value { get; set; } = 42;

    public CSharp6(ILogger logger, double value)
    {
        _logger = logger;
        Value = value;
    }

    public string GetValueText() => $"{nameof(Value)} is {Value}";

    public double DivideByValue(ComplexObject input)
    {
        try
        {
            if (input?.Thing?.Value == null)
            {
                return 0;
            }
            return input.Thing.Value / Value;
        }
        catch(Exception) when (Value == 0)
        {
            _logger?.Log("Dang." + GetValueText());
            throw;
        }
    }
}



public interface ILogger {
    void Log(string message);
}

public class ComplexObject
{
    public Thing Thing { get; set; }
}

public class Thing
{
    public double Value { get; set; }
}

#nullable restore