using NSubstitute;
using RealWorld.Logger;
using RealWorld.Model;
using RealWorld.Repositories;
using RealWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReturnsExtensions;

namespace RealWorld.Api.Tests.Unit;

public class ExercisesUnitTestRealWorld
{

    public readonly UserService _sut;

    public readonly IUserRepository _userRepository = Substitute.For<IUserRepository>(); 
    public readonly ILoggerAdapter<UserService> _loggerAdapter = Substitute.For<ILoggerAdapter<UserService>>(); 


    public ExercisesUnitTestRealWorld()
    {
        _sut = new UserService(_loggerAdapter, _userRepository);
    }


    [Fact]
    public async Task GetByIdAsync_ShouldReturnAUser_WhenUserExists() 
    {
        var existingUser = new User
        {
            Id = Guid.NewGuid(),
            FullName = "Ramon"
        };
        //mocking
        _userRepository.GetByIdAsync(existingUser.Id).Returns(existingUser);

        //Action
        User? result = await _sut.GetByIdAsync(existingUser.Id);

        //Assert
        result.Should().BeEquivalentTo<User>(existingUser);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenUserDoesntExist() 
    {
        //Arrange
        _userRepository.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        //Action
        User? result = await _sut.GetByIdAsync(Guid.NewGuid()); //doesn't exist

        //Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByIdAsync_ShouldLogCorrectMessage_WhenRetrievengTheUsers() 
    {
        var returnUser = new User()
        {
            Id = Guid.NewGuid(),
            FullName = "Ramon"
        };

        //Arrange
        _userRepository.GetByIdAsync(Arg.Is(returnUser.Id)).Returns(returnUser);

        //Action
        var result = await _sut.GetByIdAsync(returnUser.Id);

        //Assert
        _loggerAdapter.Received(2);

        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("Retrieving user with")), 
            Arg.Is(returnUser.Id));

        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("User with id")),
            Arg.Is<Guid>(returnUser.Id),
            Arg.Any<long>());
    }

    [Fact]
    public async Task GetByIdAsync_ShouldLogCorrectMessage_WhenThrownException()
    {
        //Arrange
        Guid userId = Guid.NewGuid();
        var sqlLIteException = new SqliteException("Something wen wrong", 500);
        _userRepository.GetByIdAsync(userId).Throws(sqlLIteException);

        //Action
        var result = async () => await _sut.GetByIdAsync(userId);

        await result
            .Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Something wen wrong");

        //Assert
        _loggerAdapter.Received(2);
        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("Retrieving user with")),
            Arg.Is<Guid>(userId));
        
        _loggerAdapter.Received(1).LogError(
            Arg.Is<SqliteException>(sqlLIteException),
            Arg.Is<string?>(x => x!.StartsWith("Something went wrong while retrieving user with")),
            Arg.Is<Guid>(userId));
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateAUser_WhenDetailsAreValid()
    {
        User user = new () { FullName = "Ramon" };

        _userRepository.CreateAsync(user).Returns(true);

        var result = await _sut.CreateAsync(user);

        result.Should().BeTrue();
    }

    [Fact]
    public async Task CreateAsync_ShouldLogCorrectMessage_WhenCreateUser()
    {
        //arrange
        User user = new ()
        {
            FullName = "Ramon"
        };

        //action
        var result = await _sut.CreateAsync(user);

        //assert
        _loggerAdapter.Received(2);

        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("Creating user with id ")),
            Arg.Is(user.Id), 
            Arg.Is(user.FullName));

        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("User with id")),
            Arg.Is(user.Id),
            Arg.Any<long>());
    }

    [Fact]
    public async Task CreateAsync_ShouldLogCorrectMessage_WhenThrownException()
    {
        User user = new()
        {
            FullName = "Ramon"
        };

        SqliteException exception = new ("Wrooooong", 500);
        _userRepository.CreateAsync(user).Throws(exception);

        var result = async () => await _sut.CreateAsync(user);

        await result.Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Wrooooong"); //check if there are any way to check the error code 

        _loggerAdapter.Received(3);
        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("Creating user with id ")),
            Arg.Is(user.Id),
            Arg.Is(user.FullName));

        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("User with id")),
            Arg.Is(user.Id),
            Arg.Any<long>());

        _loggerAdapter.Received(1).LogError(
            Arg.Any<SqliteException>(),
            Arg.Is("Something went wrong while creating a user"));
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldDeleteUser_WhenUserExist()
    {
        //Arrange
        User user = new(){ FullName = "Ramon" };
        //Mocking
        _userRepository.DeleteByIdAsync(user.Id).Returns(true);
        //Action
        var result = await _sut.DeleteByIdAsync(user.Id);
        //Assert
        result.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldNotDeleteUser_WhenUserDoesntExist()
    {
        User user = new() { FullName = "Ramon" };
        Guid guidTest = Guid.NewGuid();

        _userRepository.DeleteByIdAsync(user.Id).Returns(true);
        _userRepository.DeleteByIdAsync(guidTest).Returns(false);

        var result = await _sut.DeleteByIdAsync(guidTest);
        var result2 = await _sut.DeleteByIdAsync(user.Id);

        result.Should().BeFalse();
        result2.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldLogCorrectMessage_WhenDeletingUser()
    {
        User user = new() { FullName = "Ramon" };

        _userRepository.DeleteByIdAsync(user.Id).Returns(true);

        await _sut.DeleteByIdAsync(user.Id);

        //assert
        _loggerAdapter.Received(2);

        _loggerAdapter.Received(1)
            .LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("Deleting user with id")),
            Arg.Is(user.Id));

        _loggerAdapter.Received(1)
            .LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("User with id {0} deleted in {1}ms")),
            Arg.Is(user.Id),
            Arg.Any<long>());
    }

    [Fact]
    public async Task DeleteByIdAsync_ShouldLogCorrectMessage_WhenExceptionThrow()
    {
        User user = new() { FullName = "Ramon" };

        SqliteException exception = new("Wrooooong deleting", 500);
        _userRepository.DeleteByIdAsync(user.Id).Throws(exception);

        var result = async () => await _sut.DeleteByIdAsync(user.Id);

        await result.Should()
            .ThrowAsync<SqliteException>()
            .WithMessage("Wrooooong deleting"); //check if there are any way to check the error code 

        _loggerAdapter.Received(3);
        _loggerAdapter.Received(1).LogInformation(
           Arg.Is<string?>(str => str!.StartsWith("Deleting user with id")),
           Arg.Is(user.Id));

        _loggerAdapter.Received(1).LogInformation(
            Arg.Is<string?>(str => str!.StartsWith("User with id {0} deleted in {1}ms")),
            Arg.Is(user.Id),
            Arg.Any<long>());

        _loggerAdapter.Received(1).LogError(
            Arg.Any<SqliteException>(),
            Arg.Is<string?>(x => x!.StartsWith("Something went wrong while deleting user with")),
            Arg.Any<Guid>());

    }
}
