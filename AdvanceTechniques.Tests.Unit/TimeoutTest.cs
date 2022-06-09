
namespace AdvanceTechniques.Tests.Unit;

public class TimeoutTest
{
    [Fact(Timeout = 500)]
    public async Task SlowTestExample() 
    {
        await Task.Delay(100000);
    }
}
