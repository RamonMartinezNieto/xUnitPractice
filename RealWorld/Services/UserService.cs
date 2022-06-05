using RealWorld.Logger;
using RealWorld.Model;
using RealWorld.Repositories;
using System.Diagnostics;

namespace RealWorld.Services;

public class UserService : IUserService
{
    private readonly ILoggerAdapter<UserService> _logger;
    private readonly IUserRepository _userRepository;

    public UserService(ILoggerAdapter<UserService> logger, IUserRepository userRepository)
    {
        _logger = logger;
        _userRepository = userRepository;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation("Retrieving user with id: {0}", id);
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await _userRepository.GetByIdAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Something went wrong while retrieving user with id {0}", id);
            throw;
        }
        finally
        {
            stopWatch.Stop();
            _logger.LogInformation("User with id {0} retrieved in {1}ms", id, stopWatch.ElapsedMilliseconds);
        }
    }

    public async Task<bool> CreateAsync(User user)
    {
        _logger.LogInformation("Creating user with id {0} and name: {1}", user.Id, user.FullName);
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await _userRepository.CreateAsync(user);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Something went wrong while creating a user");
            throw;
        }
        finally
        {
            stopWatch.Stop();
            _logger.LogInformation("User with id {0} created in {1}ms", user.Id, stopWatch.ElapsedMilliseconds);
        }
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        _logger.LogInformation("Deleting user with id: {0}", id);
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await _userRepository.DeleteByIdAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Something went wrong while deleting user with id {0}", id);
            throw;
        }
        finally
        {
            stopWatch.Stop();
            _logger.LogInformation("User with id {0} deleted in {1}ms", id, stopWatch.ElapsedMilliseconds);
        }
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        _logger.LogInformation("Retrieving all users");
        var stopWatch = Stopwatch.StartNew();
        try
        {
            return await _userRepository.GetAllAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Something went wrong while retrieving all users");
            throw;
        }
        finally
        {
            stopWatch.Stop();
            _logger.LogInformation("All users retrieved in {0}ms", stopWatch.ElapsedMilliseconds);
        }
    }

}
