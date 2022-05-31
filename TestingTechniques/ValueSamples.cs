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

    public IEnumerable<User> Users = new[]
    {
        new User()
        {
            FullName = "Ramon Martinez",
            Age = 33,
            DateOfBirthday = new(1988, 10, 27)
        },
        new User()
        {
            FullName = "User two",
            Age = 33,
            DateOfBirthday = new(1990, 11, 07)
        },
        new User()
        {
            FullName = "User three",
            Age = 33,
            DateOfBirthday = new(1992, 8, 17)
        },
    };

    public IEnumerable<int> Numbers = new[] { 1, 5, 10, 15 };

    public event EventHandler ExampleEvent;

    internal int InternalSecretNumber = 42;

    public virtual void RaiseExampleEvent()
    {
        ExampleEvent(this, EventArgs.Empty);
    }

}

public class User 
{
    public string FullName { get; init; } = default!; 

    public int Age { get; init; }

    public DateOnly DateOfBirthday { get; init; }
}