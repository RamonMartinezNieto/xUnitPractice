namespace TestinWithDependencies.Api.Services;

public class UsersServices
{
    private readonly IUserRepository _userRepository;

    public UsersServices(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        Stopwatch watcher = Stopwatch.StartNew();
        try 
        {
            return await _userRepository.GetAllAsync();
        }
        finally
        {
            watcher.Stop();
        }   
    }
}
