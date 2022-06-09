
namespace TestingTechniques;

public class GenerateGreetMessage
{
    //dependencies : inversion control with interface. Remember, make we happy :)
    private readonly IDateTimeProvider _timeProvider;

    public GenerateGreetMessage(IDateTimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string GenerateGreetMessageMethod() 
    {
        var dateTimeNow = _timeProvider.DateTimeNow;
        return dateTimeNow.Hour switch
        {
            >= 5 and < 12 => "Good morning",
            >= 12 and < 18 => "Good afternoon",
            _ => "Good evening"

        };
    }
}
