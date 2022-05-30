namespace TestingTechniques.Tests.Unit;

public class ValueSamplesTests
{
    private ValueSamples _sut = new(); //system under tests

    [Fact]
    public void String_ShouldBeTheSameString()
    {
        var result = _sut.FullName; 
        var expected = "Ram�n Mart�nez";

        result.Should().Be(expected);
        result.Should().NotBe("Ramon Martinez");
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().StartWith("Ram�n");
        result.Should().EndWith("Mart�nez");
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