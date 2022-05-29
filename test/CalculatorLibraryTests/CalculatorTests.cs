using System;
using Xunit;
using Xunit.Abstractions;

namespace CalculatorLibrary.Tests.Unit;

public class CalculatorTests : IDisposable
{
    private readonly Calculator _sut = new(); //System under test - sut 
    private readonly ITestOutputHelper _testOutputHelper;

    //Setup, in xUnit constructor is using as a Setup
    public CalculatorTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        _testOutputHelper.WriteLine("Hello from the constructor."); //ctor = constructor
    }

    [Fact]
    public void Add_ShouldAddTwoNumbers_WhenToNumbersAreIntegers()
    {
        //Arrange
        Calculator calculator = new(); 

        //Act
        int result = calculator.Add(5, 4);

        //Assert
        Assert.Equal(9, result);
    }


    [Theory]
    [InlineData(0,0,0)]
    [InlineData(5,4,1)]
    [InlineData(5,5,0)]
    [InlineData(5,10,-5)]
    [InlineData(-5,-5,0)]
    [InlineData(-10,5,-15)]
    public void Subtract_ShouldSubtractTwoNumbers_WhenToNumbersAreIntegers(
        int numberOne, int numberTwo, int expected)
        => Assert.Equal(expected, _sut.Subtract(numberOne, numberTwo));


    [Fact]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenToNumbersAreIntegers()
        => Assert.Equal(20, _sut.Multiply(5, 4));


    [Fact]
    public void Divide_ShouldDivideTwoNumbers_WhenToNumbersAreIntegers()
        => Assert.Equal(2, _sut.Divide(10, 5));

    //Dispose is the teardown
    public void Dispose()
    {
        _testOutputHelper.WriteLine("Hello from the cleanup."); 
    }
}

//Note: for every single tests xUnit creates a new instance of the private readonly parameter
//sut (system under test) this helps us because every tests is self contained.

//xunit uses C# way to write the setup and the teardown (cleanup) using the constructor and the dispose

//If we have an async tests we can implement IAsyncLifetime and implemente InitializeAsync and DisposeAsync 
//to implement Setup and Teardown, ctor run first than InitializeAsync, it is important to remember. 