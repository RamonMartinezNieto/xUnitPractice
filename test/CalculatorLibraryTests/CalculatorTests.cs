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

    public void Add_ShouldAddTwoNumbers_WhenToNumbersAreIntegers()
    {
        //Arrange
        Calculator calculator = new(); 

        //Act
        int result = calculator.Add(5, 4);

        //Assert
        Assert.Equal(9, result);
    }


    [Theory(Skip = "Skip a complete Theory")] //This is not commont and maybe is an error to do that
    [InlineData(0,0,0, Skip = "I can skip a InlineData! :)")]
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


    [Fact(Skip = "Skip this test :)")]
    public void Divide_ShouldDivideTwoNumbers_WhenToNumbersAreIntegers()
        => Assert.Equal(2, _sut.Divide(10, 5));

    //Dispose is the teardown
    public void Dispose()
    {
        _testOutputHelper.WriteLine("Hello from the cleanup."); 
    }



    ///// ******************************************* /////
    ///// ********* Exercise of the course. ********* /////
    ///// ******************************************* /////
    
    [Theory]
    [InlineData(5, 5, 10)]
    [InlineData(-5, 5, 0)]
    [InlineData(-15, (-5), -20)]
    public void AddExercise_ShoulAddTwoNumbers_WhenNUmbersAreIntegers(
        int numberOne, int numberTwo, int expected)
        => Assert.Equal(expected, _sut.Add(numberOne, numberTwo));
    
    [Theory]
    [InlineData(5, 5, 0)]
    [InlineData(15, 5, 10)]
    [InlineData(-5, (-5), 0)]
    [InlineData(-15, (-5), -10)]
    [InlineData(5, 10, -5)]
    public void SubtractExercise_ShoulSubtractTwoNumbers_WhenNUmbersAreIntegers(
        int numberOne, int numberTwo, int expected)
        => Assert.Equal(expected, _sut.Subtract(numberOne, numberTwo));  
    
    [Theory]
    [InlineData(5, 5, 25)]
    [InlineData(50, 0, 0)]
    [InlineData(-5, 5, -25)]
    public void MultiplyExercise_ShoulMultiplyTwoNumbers_WhenNUmbersAreIntegers(
        int numberOne, int numberTwo, int expected)
        => Assert.Equal(expected, _sut.Multiply(numberOne, numberTwo));
    
        
    [Theory]
    [InlineData(5, 5, 1)]
    [InlineData(15, 5, 3)]
    public void DivideExercise_ShoulDivideTwoNumbers_WhenNUmbersAreIntegers(
        int numberOne, int numberTwo, int expected)
        => Assert.Equal(expected, _sut.Divide(numberOne, numberTwo));
    
    
    ///// ******************************************* /////
    ///// ******* End Exercise of the course. ******* /////
    ///// ******************************************* /////
}

//Note: for every single tests xUnit creates a new instance of the private readonly parameter
//sut (system under test) this helps us because every tests is self contained.

//xunit uses C# way to write the setup and the teardown (cleanup) using the constructor and the dispose

//If we have an async tests we can implement IAsyncLifetime and implemente InitializeAsync and DisposeAsync 
//to implement Setup and Teardown, ctor run first than InitializeAsync, it is important to remember. 