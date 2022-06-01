namespace TestingTechniques.Tests.Unit;

public class CalculatorTests
{
    private readonly Calculator _sut = new Calculator();

    [Fact]
    public void ExceptionThrownAssertionExample() 
    {
        Action result = () => _sut.Divide(1, 0); //can be an Action or Func

        result.Should()
            .Throw<DivideByZeroException>()
            .WithMessage("Attempted to divide by zero.");
    }    
    
    [Fact]
    public void Divide_ShouldDivideTwoIntegers_WhenBothAreIntegers_AndDivisorIsNot0_AndResultIsInteger() 
    {
        int result = _sut.Divide(10, 5);

        result.Should().Be(2);
    }
}
