using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("Hello, World!");
#nullable enable

var p = new Person
{
  FirstName = "Adam",
  LastName = "Barney"
};

SayHello(p);

static void SayHello(Person p)
{
  Console.WriteLine($"Hello, {p.LastName.ToUpper()}, {p.FirstName} {p.MiddleName}");
}

public class Person
{
  public Person() { }
  [SetsRequiredMembers]
  public Person(string first, string? middle, string last)
  {
    FirstName = first;
    MiddleName = middle;
    LastName = last;
  }
  public required string FirstName { get; init; }
  public string? MiddleName { get; init; }
  public required string LastName { get; init; }
  public List<Person> Children { get; set; } = new();
}