namespace Demo.PatternMatching;

public record Pet(string Name, int Age);
public record Dog(string Breed, string Name, int Age) : Pet(Name, Age);
public record Cat(string Color, string Name, int Age) : Pet(Name, Age);

public class Demo
{
    public static void DeclarationAndTypePatterns(Pet pet)
    {
        if (pet is Dog petDog)
        {
            Console.WriteLine($"{petDog.Name} is a {petDog.Breed}");
        }

        switch (pet)
        {
            case Dog dog:
                Console.WriteLine($"{dog.Name} is a {dog.Breed}");
                break;
            case Cat cat:
                Console.WriteLine($"{cat.Name} is a {cat.Color} cat");
                break;
            default:
                Console.WriteLine($"{pet.Name} is {pet.Age} years old");
                break;
        }
    }

    public static void ConstantPattern(Dog dog)
    {
        var intelligence = dog.Breed switch {
            "Border Collie" => 10,
            "Poodle" => 8,
            "Labrador" => 7,
            "Corgi" => 5,
            "Beagle" => 1,
            _ => 0
        };
    }

    public static void RelationalPattern(Pet pet)
    {
        var ageGroup = pet.Age switch
        {
            <= 1 => "Baby",
            <= 4 => "Young",
            <= 10 => "Middle-aged",
            <= 15 => "Senior",
            > 15 => "Relic"
        };
    }

    public static void LogicalPatterns(Pet? pet)
    {
        if (pet is not null)
        {
            var ageGroup = pet.Age switch
            {
                <= 1 => "Baby",
                > 1 and <= 4 => "Young",
                > 4 and <= 10 => "Middle-aged",
                > 10 and <= 15 => "Senior",
                > 15 => "Relic"
            };
        }
    }

    public record SinglePetOwner(string Name, Pet? Pet);

    public static void PropertyPatterns(SinglePetOwner owner)
    {
        var foo = owner switch {
            { Pet: null } => "No pet",
            { Pet: { Name: "Ralph" } } => "My name is Ralph",
            { Pet.Age: 20 } => "REALLY old pet...",
            { Pet: Dog { Breed: "Husky" } } => "Mush!",
            { Name: "Joe" } or { Pet.Name: "Joe" } => "Someone will answer to Joe",
            { Name: "Adam", Pet: Dog { Breed: "Corgi", Name: "Baxter" } } => "I think I know this guy...",
            { Pet: Dog dog } => $"{dog.Name} is a {dog.Breed}",
            _ => "Unknown"
        };
        if (DateTime.Now.Date is { Year: 2022, Month: 7, Day: 13 or 14 or 15})
        {
            Console.WriteLine("It's Conference time!");
        }
    }

    public static void PositionalPatterns(Dog dog)
    {
        var message = dog switch {
            ("Corgi", "Baxter", _) => "Always young...",
            ("Corgi", _, <= 10) => "Active Corgi!",
            ("Corgi", _, > 10) => "Time to retire",
            ("Husky" or "Border Collie", _, _) => "I like these dogs",
            _ => "Unknown"
        };
    }

    public static bool IsItBaxter_Without_VarPattern()
    {
        var dog = GetDog();
        return dog.Breed == "Corgi" && dog.Name == "Baxter";
    }

    public static bool IsItBaxter_With_VarPattern() => GetDog() is Dog dog && dog.Breed == "Corgi" && dog.Name == "Baxter";

    private static Dog GetDog() => new("Corgi", "Baxter", 9);

    public record MultiPetOwner(string Name, Pet[] Pets);

    public static void ListPatterns(MultiPetOwner owner)
    {
        if (owner.Pets is [Dog, Dog, Dog, Cat])
        {
            Console.WriteLine("Good grief. Too many pets.");
        }

        if (owner is { Name: "Adam", Pets: [
            Dog { Breed: "Corgi", Name: "Baxter" },
            Dog { Breed: "Husky", Name: "Viktor" },
            Dog { Breed: "Quincey", Name: "Border Collie" },
            Cat { Color: "Tabby", Name: "Tippy"}
        ]}) {
            Console.WriteLine("This is me. 😒");
        }

        owner = owner with {Pets = owner.Pets.OrderBy(x=>x.Age).ToArray()};
        var message = $"{owner}'s oldest pet is " + owner switch {
            { Pets: [.., Cat oldest ]} => $"a {oldest.Color} Cat named {oldest.Name}",
            { Pets: [.., Dog oldest ]} => $"a {oldest.Breed} named {oldest.Name}",
            _ => "Unknown"
        };

        if (owner.Pets is [_, Dog { Breed: "Corgi" } pet, ..])
        {
            Console.WriteLine($"{owner.Name}'s has a Corgi, but it's not the youngest.");
        }
    }
}