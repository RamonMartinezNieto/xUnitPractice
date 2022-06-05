namespace RealWorld.Contract;

public class UserResponse
{
    public Guid Id { get; init; }

    public string FullName { get; init; } = default!;
}
