using Xunit;

namespace CalculatorLibrary.Tests.Unit;

public class CalculatorTests
{
    private readonly Calculator _sut = new(); //System under test - sut 

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


    [Fact]
    public void Subtract_ShouldSubtractTwoNumbers_WhenToNumbersAreIntegers()
        => Assert.Equal(1, _sut.Subtract(5, 4));


    [Fact]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenToNumbersAreIntegers()
        => Assert.Equal(20, _sut.Multiply(5, 4));


    [Fact]
    public void Divide_ShouldDivideTwoNumbers_WhenToNumbersAreIntegers()
        => Assert.Equal(2, _sut.Divide(10, 5));

}

//Note: for every single tests xUnit creates a new instance of the private readonly parameter
//sut (system under test) this helps us because every tests is self contained.
