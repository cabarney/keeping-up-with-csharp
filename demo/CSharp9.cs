List<DogRecord> dogs = new();

var dog1 = new DogClass("Corgi", "Baxter");
var dog2 = new DogClass("Corgi", "Baxter");
var dogA = new DogRecord("Corgi", "Baxter");
var dogB = new DogRecord("Corgi", "Baxter");

// DogRecord { Breed = Corgi, Name = Baxter }
Console.WriteLine($"{dog1 == dog2}, {dogA == dogB}");
// dogB.Breed = "Labrador";   ** ERROR **
dogB = dogA with { Breed = "Labrador" };
// dog2.Breed = "Labrador";  ** ERROR **
dog2.Name = "Larry";

Console.WriteLine(dogA);

public class DogClass
{
    public string Breed { get; init; }
    public string Name { get; set; }

    public DogClass(string breed, string name)
    {
        Breed = breed;
        Name = name;
    }
}


public record DogRecord(string Breed, string Name);