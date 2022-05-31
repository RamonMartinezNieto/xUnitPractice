namespace TestingTechniques;

public class ValueSamples
{
    public string FullName = "Ramón Martínez";

    public int? Age = 33;

    public DateOnly DataofBirthday = new(1988, 10, 27);

    public User AppUser = new()
    {
        FullName = "Ramon Martinez",
        Age = 33,
        DateOfBirthday = new(1988, 10, 27)
    };
}

public class User 
{
    public string FullName { get; init; } = default!; 

    public int Age { get; init; }

    public DateOnly DateOfBirthday { get; init; }
}