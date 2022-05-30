namespace TestingTechniques.Tests.Unit;

public class ValueSamplesTests
{
    private ValueSamples _sut = new(); //system under tests

    [Fact]
    public void String_ShouldBeTheSameString()
    {
        var result = _sut.FullName; 
        var expected = "Ramón Martínez";

        result.Should().Be(expected);
        result.Should().NotBe("Ramon Martinez");
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().StartWith("Ramón");
        result.Should().EndWith("Martínez");
    }

    [Fact]
    public void Int_ShouldBeTheSameInt()
    {
        var result = _sut.Age; 
        var expected = 33;

        result.Should().Be(expected);
        result.Should().NotBe(22);
        result.Should().BeNegative(); 
        result.Should().NotBeNull();    
    }
}