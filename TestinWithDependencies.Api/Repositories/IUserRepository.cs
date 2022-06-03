namespace TestinWithDependencies.Api.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
}
