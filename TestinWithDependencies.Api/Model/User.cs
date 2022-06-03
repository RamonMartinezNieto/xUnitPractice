namespace TestinWithDependencies.Api.Model;

public class User
{
    public Guid Id { get; set; }

    public string FullName { get; set; } = default!;
}
