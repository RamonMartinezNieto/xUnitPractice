


namespace AdvanceTechniques.Tests.Unit;

public class GreeterTest
{
    public GenerateGreetMessage _sut;

    public IDateTimeProvider _timeProvider = Substitute.For<IDateTimeProvider>();

    public GreeterTest()
    {
        _sut = new GenerateGreetMessage(_timeProvider);
    }

    [Fact]
    public void GenerateGreetMEssage_ShouldSayGoodEvening_WhenItsEvening() 
    {
        _timeProvider.DateTimeNow.Returns(new DateTime(2022, 06, 09, 20, 0, 0));
        var result = _sut.GenerateGreetMessageMethod();

        result.Should().Be("Good evening");
    }

    [Fact]
    public void GenerateGreetMEssage_ShouldSayGoodAfertnoon_WhenItsEvening() 
    {
        _timeProvider.DateTimeNow.Returns(new DateTime(2022, 06, 09, 13, 0, 0));
        var result = _sut.GenerateGreetMessageMethod();

        result.Should().Be("Good afternoon");
    }

    [Fact]
    public void GenerateGreetMEssage_ShouldSayGoodMorning_WhenItsEvening() 
    {
        _timeProvider.DateTimeNow.Returns(new DateTime(2022, 06, 09, 07, 0, 0));
        var result = _sut.GenerateGreetMessageMethod();

        result.Should().Be("Good morning");
    }
}
