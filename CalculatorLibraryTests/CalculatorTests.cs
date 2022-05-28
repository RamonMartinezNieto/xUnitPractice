using CalculatorLibrary;
using Xunit;

namespace CalculatorLibraryTests;

public class CalculatorTests
{
    [Fact]
    public void TestAdd() 
    {
        Calculator calculator = new ();

        int result = calculator.Add(5, 4);

        Assert.Equal(9, result);
    }

}
