using CalculatorLibrary;
using Xunit;

namespace CalculatorLibraryTests;

public class CalculatorTests
{

    private Calculator _calculator = new();

    [Fact]
    public void TestAdd() 
        => Assert.Equal(9, _calculator.Add(5, 4));

    [Fact]
    public void TestSubtract()
        => Assert.Equal(1, _calculator.Subtract(5, 4));
    

    [Fact]
    public void TestMultiply()
        => Assert.Equal(20, _calculator.Multiply(5, 4));
    
    [Fact]
    public void TestDivide()
        => Assert.Equal(2, _calculator.Divide(10, 5));

}
