using System.Diagnostics.CodeAnalysis;

namespace RealWorld.Model;

//Mark that this class is excluded from the coverage
[ExcludeFromCodeCoverage]
public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string FullName { get; set; } = default!;
}
