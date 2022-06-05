using RealWorld.Model;

namespace RealWorld.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();

    Task<User?> GetByIdAsync(Guid id);

    Task<bool> CreateAsync(User user);

    Task<bool> DeleteByIdAsync(Guid id);
}
