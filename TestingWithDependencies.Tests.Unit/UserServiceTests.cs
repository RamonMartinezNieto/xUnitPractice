using FluentAssertions;
using NSubstitute;
using TestinWithDependencies.Api.Model;
using TestinWithDependencies.Api.Repositories;

namespace TestingWithDependencies.Tests.Unit;

public class UserServiceTests
{
    private readonly UsersServices _sut;
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();

    public UserServiceTests()
    {
        _sut = new UsersServices(_userRepository);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoUsersExists()
    {
        // Arrange
        _userRepository.GetAllAsync().Returns(Array.Empty<User>());

        //Act
        var users = await _sut.GetAllAsync();

        //Assert
        users.Should().BeEmpty();

    }    
    
    
    [Fact]
    public async Task GetAllAsync_ShouldReturnEmptyList_WhenUsersExists()
    {
        var expectedUsers = new User[]
        {
            new User
            {
                Id = Guid.NewGuid(),
                FullName = "Ramón",
            }
        };

        // Arrange
        _userRepository.GetAllAsync().Returns(expectedUsers);
        
        //Act
        var users = await _sut.GetAllAsync();

        //Assert
        users.Should().ContainSingle(x => x.FullName.Equals("Ramón"));

    }
}