using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using RealWorld.Logger;
using RealWorld.Model;
using RealWorld.Repositories;
using RealWorld.Services;
using Xunit;

namespace RealWorld.Api.Tests.Unit;

public class UserServicesTests
{
    private readonly UserService _sut;

    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly ILoggerAdapter<UserService> _logger = Substitute.For<ILoggerAdapter<UserService>>();

    public UserServicesTests()
    {
        _sut = new UserService(_logger, _userRepository);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExistt() 
    {

        //Arrange
        _userRepository.GetAllAsync().Returns(Enumerable.Empty<User>());

        //Act
        var result = await _sut.GetAllAsync();

        //Assert
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenSomeUsersExistt() 
    {
        //Arrange
        var ramon = new User
        {
            Id = Guid.NewGuid(),
            FullName = "Ramon"
        };

        var expectedUsers = new[]
        {
            ramon
        };

        _userRepository.GetAllAsync().Returns(expectedUsers);

        //Act
        var result = await _sut.GetAllAsync();

        //Assert
        result.Single().Should().BeEquivalentTo(ramon);
        result.Should().BeEquivalentTo(expectedUsers);
        result.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetAllAsync_ShouldLogMessages_WhenInvoked()
    {
        //Arrange
        _userRepository.GetAllAsync().Returns(Enumerable.Empty<User>());

        //Act
        await _sut.GetAllAsync();

        //Assert

        //logger receive 2 calls
        _logger.Received(2);

        //we can check for each call with specifics arguments
        //To know if _logger receive one call with arguments
        //we use a LoggerAddapter to test it, because static methods and extension methods are so difficult to tests 
        _logger.Received(1).LogInformation(Arg.Is("Retrieving all users")); 
        _logger.Received(1).LogInformation(Arg.Is<string?>(x => x!.StartsWith("Retrieving"))); 
        
        _logger.Received(1).LogInformation(Arg.Is("All users retrieved in {0}ms"), Arg.Any<long>());
    }    
    
    [Fact]
    public async Task GetAllAsync_ShouldLogMessages_WhenInvokedWithExceptionThrown()
    {
        //Arrange
        var sqlLIteException = new SqliteException("Something wen wrong", 500);
        _userRepository.GetAllAsync().Throws(sqlLIteException);

        //Act
        var requestAction = async () => await _sut.GetAllAsync();

        //Assert
        await requestAction.Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Something wen wrong");

        _logger.Received(1).LogError(Arg.Is(sqlLIteException), Arg.Is("Something went wrong while retrieving all users"));
    }

}
