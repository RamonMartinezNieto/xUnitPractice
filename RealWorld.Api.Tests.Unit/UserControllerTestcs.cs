using NSubstitute;
using RealWorld.Controllers;
using RealWorld.Model;
using RealWorld.Services;
using Xunit;
using RealWorld.Mappers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using NSubstitute.ReturnsExtensions;
using RealWorld.Contract;
using NSubstitute.ExceptionExtensions;

namespace RealWorld.Api.Tests.Unit;

public class UserControllerTestcs
{
    private readonly UserController _sut;
    private readonly IUserService _userService = Substitute.For<IUserService>();

    public UserControllerTestcs()
    {
        _sut = new UserController(_userService);
    }

    [Fact]
    public async Task GetById_ReturnOkAndObject_WhenUserExist() 
    {
        //arrange
        User user = new() { FullName = "Ramon" };

        _userService.GetByIdAsync(user.Id).Returns(user);
        var userResponse = user.ToUserResponse();

        //act
        var response = (OkObjectResult) await _sut.GetById(user.Id);

        //assert
        response.StatusCode.Should().Be(200);
        response.Value.Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task GetById_ReturnNotFound_WhenUserNoExist() 
    {
        _userService.GetByIdAsync(Arg.Any<Guid>()).ReturnsNull();

        //act
        var response = (NotFoundResult) await _sut.GetById(Arg.Any<Guid>());

        //assert
        response.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task GetAll_ReturnOkAndArrayObject_WhenAnyUserExist()
    {
        //arrange
        User user = new() { FullName = "Ramon" };
        User[] listOfUsers = new User[] { user };

        _userService.GetAllAsync().Returns(listOfUsers);
        var userResponse = listOfUsers.Select(x => x.ToUserResponse());

        //act
        var response = (OkObjectResult)await _sut.GetAll();

        //assert
        response.StatusCode.Should().Be(200);
        response.Value.As<IEnumerable<UserResponse>>().Should().BeEquivalentTo(listOfUsers);
    }
    
    [Fact]
    public async Task GetAll_ReturnUserResponses_WhenUserExist()
    {
        //arrange
        var user = new User() { FullName = "Ramon" };
        var users = new User[] { user };
        var userResponse = users.Select(x => x.ToUserResponse());

        _userService.GetAllAsync().Returns(users);

        //act
        var response = (OkObjectResult)await _sut.GetAll();

        //assert
        response.StatusCode.Should().Be(200);
        
        response.Value.As<IEnumerable<UserResponse>>()
            .Should()
            .BeEquivalentTo(userResponse);
    }
    
    [Fact]
    public async Task GetAll_ReturnNoContent_WhenNoUserExist()
    {
        //arrange
        _userService.GetAllAsync().Returns(Enumerable.Empty<User>());

        //act
        var response = (NoContentResult)await _sut.GetAll();

        //assert
        response.StatusCode.Should().Be(204);
    }

        
    [Fact]
    public async Task GetAll_ShouldReturnInternalError_WhenAnyProblemOccur()
    {
        //arrange
        _userService.GetAllAsync().Throws(new Exception("to test"));

        //act
        var response = (StatusCodeResult)await _sut.GetAll();

        //assert
        response.StatusCode.Should().Be(500);
    }
            
    [Fact]
    public async Task Create_ShouldReturnCreateAction201_WhenCreateUserRequestIsValid ()
    {
        CreateUserRequest requestUser = new() 
        {
            FullName = "Ramon"
        };
        User user = new User()
        {
            Id= Guid.NewGuid(),
            FullName = requestUser.FullName
        };
        //arrange

        //Not valid if we wan to validate ID 
        _userService.CreateAsync(Arg.Is<User>(x => x.FullName == user.FullName)).Returns(true);
        
        //the object instantiate within the CreateAsync will be the our user here (overrider user)
        //_userService.CreateAsync(Arg.Do<User>(x => user = x)).Returns(true);
        
        var expectedUserResponse = user.ToUserResponse();
        //act
        var response = (CreatedAtActionResult)await _sut.Create(requestUser);

        //assert
        response.StatusCode.Should().Be(201);


        //With options to exclude ID because is different 
        response.Value.As<UserResponse>().Should()
            .BeEquivalentTo<UserResponse>(expectedUserResponse,
            options => options.Excluding(x => x.Id));

        //response.Value.As<UserResponse>().Should()
        //    .BeEquivalentTo(expectedUserResponse);
        //response.RouteValues!["id"].Should().BeEquivalentTo(user.Id);
    }            

    [Fact]
    public async Task Create_ShouldReturnBadRequest_WhenUserIsNotCreated()
    {
  
        //arrange
        _userService.CreateAsync(Arg.Any<User>()).Returns(false);

        //act
        CreateUserRequest userReq = new() { FullName = "Ramon" };
        var response = (BadRequestResult)await _sut.Create(userReq);

        //assert
        response.StatusCode.Should().Be(400);
    }

    
    [Fact]
    public async Task DeleteById_ShouldReturnOk_WhenUserDeleted()
    {
        Guid guid = Guid.NewGuid();
        //arrange
        _userService.DeleteByIdAsync(guid).Returns(true);

        //act
        var response = (OkResult)await _sut.DeleteById(guid);

        //assert
        response.StatusCode.Should().Be(200);
    }

        
    [Fact]
    public async Task DeleteById_ShouldReturnNotFound_WhenUserNotDeleted()
    {
        Guid guid = Guid.NewGuid();
        //arrange
        _userService.DeleteByIdAsync(guid).Returns(false);

        //act
        var response = (NotFoundResult)await _sut.DeleteById(guid);

        //assert
        response.StatusCode.Should().Be(404);
    }


}
