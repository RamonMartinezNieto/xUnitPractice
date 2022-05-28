using Xunit;

namespace CalculatorLibrary.Tests.Unit;

public class CalculatorTests
{

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
    {
        Calculator calculator = new();

        int result = calculator.Subtract(5, 4);

        Assert.Equal(1, result);
    }


    [Fact]
    public void Multiply_ShouldMultiplyTwoNumbers_WhenToNumbersAreIntegers()
    {
        Calculator calculator = new();

        int result = calculator.Multiply(5, 4);

        Assert.Equal(20, result);
    }


    [Fact]
    public void Divide_ShouldDivideTwoNumbers_WhenToNumbersAreIntegers()
    {
        Calculator calculator = new();
        int result = calculator.Divide(10, 5);
        Assert.Equal(2, result);
    }

}
