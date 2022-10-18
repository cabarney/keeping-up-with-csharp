#nullable enable
#if false // Not implemented fully (yet)
using System.Diagnostics.CodeAnalysis;
public class CSharp11
{
    public void RawStringLiterals()
    {
        var name = "Bob";
        var json = $$"""
            {
                "name": "{{name}}",
                "age": 30,
                "pets": [
                    "Dog",
                    "Cat"
                ]
            }
            """;
            Console.WriteLine(json);
/*
{
    "name": "Bob",
    "age": 30,
    "pets": [
        "Dog",
        "Cat"
    ]
}
*/
    }

    public CSharp11() { }
    [SetsRequiredMembers]
    public CSharp11(string name) => Name = name;

    /***** REQUIRED MEMBERS *****/
    // NO NO NO: public string Name { get; init; } = default!;
    // Use the required keyword instead:
    public required string Name { get; init; }

    /***** SEMI-AUTO PROPERTIES *****/
    // field represents a backing field that you don't need to define yourself
    public string Description { get; set => field = value.Trim(); }
    public string Status => field ??= GetStatus();
    public string FetchStatus() => $"{Random.Shared.Next(100)}% done";

}
#endif
#nullable restore