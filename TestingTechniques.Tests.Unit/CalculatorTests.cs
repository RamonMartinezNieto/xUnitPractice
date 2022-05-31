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
}
